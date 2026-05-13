# Dhuyvetter Beton - Orderbeheer & Bedrijfsbeheerprogramma

> Een volledig productierijpe Windows desktop applicatie ontwikkeld als schoolverlater voor **D'huyvetter Beton**, een betoncentrale. Het systeem vervangt de volledige administratieve en operationele workflow van het bedrijf: van bestellingen en facturatie tot personeelsplanning en SMS-communicatie.

---

## Inhoudsopgave

- [Overzicht](#overzicht)
- [Architectuur](#architectuur)
- [Functionaliteiten](#functionaliteiten)
- [Technologiestack](#technologiestack)
- [Projectstructuur](#projectstructuur)
- [Installatie & Configuratie](#installatie--configuratie)
- [Databasestructuur](#databasestructuur)
- [Externe Integraties](#externe-integraties)

---

## Overzicht

Dit project is een volledig zelfstandig ontwikkelde bedrijfsapplicatie die dagelijks in productie draaide op het interne netwerk van D'huyvetter Beton. Het programma centraliseert alle kernprocessen van de betoncentrale in één overzichtelijke Windows Forms interface gebouwd met DevExpress-componenten.

**Kernfuncties in één oogopslag:**

- 📦 Bestellingen aanmaken, wijzigen en opvolgen met automatische Excel-export
- 👥 Klanten- en werfbeheer met betaalstatus- en kortingssysteem
- 🧾 Facturatiebeheer met BTW-berekeningen en e-mailfunctie
- 📅 Personeels- en verlofplanning met kalenderweergave
- 💬 SMS-communicatie via Twilio
- 🗺️ Google Maps integratie voor werflocaties
- 🔥 Firebase/Firestore voor real-time synchronisatie

---

## Architectuur

De applicatie is opgebouwd volgens een **strikte 4-lagenarchitectuur**. Dit garandeert een heldere scheiding van verantwoordelijkheden, maakt de code onderhoudbaar en uitbreidbaar, en zorgt ervoor dat elke laag onafhankelijk getest en aangepast kan worden.

```
┌─────────────────────────────────────────────────────────┐
│              UI-LAAG  (DhuyvetterBeton.Beton)           │
│         Windows Forms · DevExpress · Schermen           │
│     Bestelling · Klanten · Facturen · Agenda · ...      │
└───────────────────────┬─────────────────────────────────┘
                        │  roept aan
                        ▼
┌─────────────────────────────────────────────────────────┐
│                   BL-LAAG  (BL)                         │
│              Business Logic Layer                       │
│  Domeinobjecten: Bestelling, Klant, Werf, Formule,      │
│  Factuur, Pomp, Hulpstof, Korting, Offerte, Account…    │
│  ConvertFromDO() ◄──────────────────► ConvertToDO()     │
└──────────┬────────────────────────────────┬─────────────┘
           │  roept aan                     │  ontvangt DO's
           ▼                                │
┌─────────────────────────┐                 │
│      DAL-LAAG  (DAL)    │                 │
│   Data Access Layer     │                 │
│  SqlConnection          │                 │
│  SqlCommand             │─────────────────┘
│  SqlDataReader          │  geeft terug via RL
│  ADO.NET raw queries    │
└──────────┬──────────────┘
           │  SQL queries
           ▼
┌──────────────────────────────────────────┐
│         SQL SERVER DATABASES             │
│  Dhuyvetbestelling  ·  DhuyvetLevering   │
└──────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────┐
│                   RL-LAAG  (RL)                         │
│              Runner Layer / Data Objects                │
│  BestellingDO · KlantDO · WerfDO · FormuleDO ·          │
│  FactuurDO · PompDO · HulpstofDO · KortingDO …          │
│  Pure datadragerklassen — geen logica                   │
└─────────────────────────────────────────────────────────┘
```

### De 4 lagen in detail

#### 1. UI-laag — `DhuyvetterBeton.Beton`

De presentatielaag bevat alle Windows Forms schermen en user controls, opgebouwd met de **DevExpress**-componentenbibliotheek. De UI is bewust zo slank mogelijk gehouden: ze bevat **geen businesslogica** en roept enkel methodes aan op de BL-laag. Schermen zijn georganiseerd per domein in submappen (Bestelling, Klanten, Facturen, Werven, Offertes, PersoneelD, …).

#### 2. BL-laag — Business Logic

Het hart van de applicatie. Elke domeinentiteit heeft zijn eigen klasse met private fields, publieke properties, constructors en methodes. Het patroon dat door de hele codebase consistent wordt toegepast:

```csharp
// Stap 1: BL vraagt data op via DAL
public static List<Bestelling> KrijgBestellingenDoorDatum(DateTime datum)
{
    List<BestellingDO> bestellingDOs = DataAccess.SelecteerBestellingenVoorEenDatum(datum);
    List<Bestelling> bestellingen = new List<Bestelling>();
    foreach (BestellingDO bestellingDO in bestellingDOs)
    {
        bestellingen.Add(ConvertFromDO(bestellingDO));
    }
    return bestellingen;
}

// Stap 2: Omzetting van RL DataObject naar BL domeinobject
public static Bestelling ConvertFromDO(BestellingDO bestellingDO)
{
    return new Bestelling(
        bestellingDO.ID,
        Klant.ConvertFromDO(bestellingDO.KlantDO),
        Werf.ConvertFromDO(bestellingDO.WerfDO),
        Formule.ConvertFromDO(bestellingDO.FormuleDO),
        Pomp.ConvertFromDO(bestellingDO.PompDO),
        bestellingDO.Giek, bestellingDO.M3,
        bestellingDO.Besteldatum, bestellingDO.Datum,
        bestellingDO.Levering, bestellingDO.LeveringWijze,
        bestellingDO.Loswijze, bestellingDO.Comment
    );
}
```

#### 3. DAL-laag — Data Access Layer

Alle databasecommunicatie loopt via de centrale klasse `DataAccess`. Maakt gebruik van **ADO.NET** (geen ORM) voor directe SQL-queries op twee SQL Server-databases. Elke methode opent een verbinding, voert de query uit, leest het resultaat rij per rij en geeft een lijst van DO's terug.

```csharp
public static List<BenorCategorieDO> KrijgAlleBenorCategories()
{
    using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand("SELECT * FROM BenorCategorie;", connection))
        using (SqlDataReader reader = command.ExecuteReader())
        {
            List<BenorCategorieDO> result = new List<BenorCategorieDO>();
            while (reader.Read())
            {
                result.Add(new BenorCategorieDO {
                    ID   = Convert.ToInt32(reader["ID"]),
                    Naam = reader["Naam"].ToString()
                });
            }
            return result;
        }
    }
}
```

#### 4. RL-laag — Runner Layer (Data Objects)

Bevat uitsluitend pure datadragerklassen (DO's). Ze hebben alleen fields, properties en constructors — **geen methodes, geen logica**. Ze dienen als transportcontainer tussen DAL en BL, zodat beide lagen volledig van elkaar ontkoppeld blijven.

```csharp
public class BestellingDO
{
    public int ID           { get; set; }
    public KlantDO KlantDO  { get; set; }
    public WerfDO WerfDO    { get; set; }
    public FormuleDO FormuleDO { get; set; }
    public PompDO PompDO    { get; set; }
    public string Giek      { get; set; }
    public double M3        { get; set; }
    public DateTime Datum   { get; set; }
    // ...
}
```

---

## Functionaliteiten

### Bestellingsbeheer
- Nieuwe bestellingen aanmaken met koppeling aan klant, werf, betonformule, pomp en hulpstoffen
- Bestellingen wijzigen, verwijderen en opzoeken op datum, klant of werf
- Automatische **Excel-exportfiche** per bestelling, georganiseerd per datum in mappenstructuur op netwerkschijf
- Aparte **pompfiche** in Excel voor leverancier van betonpomp
- Afleveragenda per dag met overzichtsvenster

### Klantenbeheer
- Volledig CRUD-beheer van klanten met adres, BTW-nummer, contactgegevens
- Automatische detectie van klanten in achterstand (betaalcode "Rood")
- Klantnotities aanmaken en beheren
- Koppeling met Belgische btw-validatiedienst (buitenlandse BTW)

### Werfbeheer
- Werven aanmaken en koppelen aan klanten
- Werflocaties visueel bekijken via Google Maps-integratie

### Facturatiebeheer
- Facturen aanmaken met regelitems per product en hulpstof
- BTW-berekeningen: **6% / 21% / verlegd**
- Facturen per e-mail verzenden
- Openstaande facturen opvolgen
- Excel-export van facturen

### Kortingssysteem
Meervoudig kortingenmodel:
- Korting per klant
- Korting per product
- Korting per werf
- Korting per product-werf combinatie

### Offertebeheer
- Offertes aanmaken per klant en werf
- Offerteproducten en -prijzen beheren
- Offertes omzetten naar bestelling

### Personeels- en verlofplanning
- Personeelsbeheer met kalenderweergave
- Verlofregistratie per medewerker
- Agendaoverzicht voor leveringen

### Prijslijstbeheer
- Productprijzen (formules) beheren
- Pompprijzen per leverancier
- Hulpstofprijzen

### SMS-communicatie
- **Twilio** integratie voor het versturen van SMS-berichten aan klanten en chauffeurs
- Aparte **ASP.NET Core 2.1 microservice** (`TwilioReceive`) voor het ontvangen en verwerken van inkomende SMS-berichten

### Gebruikersbeheer & Beveiliging
- Login met gebruikersniveaus (`userlevel`)
- Wachtwoorden opgeslagen als **SHA-512 hash** (UTF-32 encoded)

```csharp
public static string Hash(string text)
{
    return Convert.ToBase64String(
        SHA512.Create().ComputeHash(Encoding.UTF32.GetBytes(text))
    );
}
```

### Overige modules
- **Logboek**: activiteitenregistratie per gebruiker
- **Bugrapportering**: ingebouwd systeem voor foutrapportage en opvolging
- **Code Rood**: signalering van probleemklanten
- **Websiteintegratie**: productbeheer voor de webshop van het bedrijf
- **Barcode scanning** via ZXing.NET
- **Crystal Reports** voor rapportage en leveringsbonnen
- **Firebase/Firestore** voor real-time synchronisatie tussen werkstations

---

## Technologiestack

| Categorie | Technologie |
|---|---|
| Taal | C# (.NET Framework 4.6 / 4.8) |
| UI-framework | Windows Forms + DevExpress |
| Database | SQL Server Express (ADO.NET) |
| ORM / Lokale DB | Entity Framework + SQLite |
| Real-time sync | Google Cloud Firestore |
| SMS | Twilio |
| Kaarten | Google Maps API + GMap.NET |
| Rapporten | Crystal Reports |
| Excel | OpenXML / EPPlus |
| Browser-embedding | Microsoft WebView2 + CefSharp |
| SMS microservice | ASP.NET Core 2.1 |
| Barcode | ZXing.NET |
| Beveiliging | SHA-512 (System.Security.Cryptography) |
| Notificaties | Tulpep.NotificationWindow |

---

## Projectstructuur

```
Bestellingen/
│
├── DhuyvetterBeton.Beton/          # UI-laag (Windows Forms)
│   ├── Agenda/                     # Verlofagenda, logboek, bugrapportage
│   ├── Bestelling/                 # Bestellingschermen & tools
│   │   └── Tools/                  # SMS, hulpstof- en pompwijzigingen
│   ├── Facturen/                   # Facturatieschermen
│   ├── Klanten/                    # Klantenbeheer
│   ├── Kortingen/                  # Kortingsbeheer
│   ├── Offertes/                   # Offertes
│   ├── PersoneelD/                 # Personeels- en verlofplanning
│   ├── Pompen/                     # Pompbeheer
│   ├── PrijsLijst/                 # Prijs- en hulpstofbeheer
│   ├── Producten/                  # Productbeheer
│   ├── Website/                    # Webshop productbeheer
│   └── Werven/                     # Werfbeheer
│
├── BL/                             # Business Logic Layer
│   ├── Bestelling.cs               # Domeinklasse + Excel-export logica
│   ├── Klant.cs                    # Klantenlogica
│   ├── Werf.cs                     # Werflogica
│   ├── Formule.cs                  # Betonformules
│   ├── Factuur.cs                  # Facturatie
│   ├── Hulpstof.cs                 # Hulpstoffen per bestelling
│   ├── Pomp.cs                     # Betonpompen
│   ├── Korting_*.cs                # Kortingssysteem (4 types)
│   ├── Hasher.cs                   # SHA-512 wachtwoordhashing
│   ├── Excell*.cs                  # Excel-generatoren
│   └── ...
│
├── DAL/                            # Data Access Layer
│   └── DataAccess.cs               # Centrale klasse, alle SQL-queries
│
├── RL/                             # Runner Layer — Data Objects
│   ├── BestellingDO.cs
│   ├── KlantDO.cs
│   ├── WerfDO.cs
│   └── ...                         # DO voor elke entiteit
│
└── TwilioReceive/                  # ASP.NET Core microservice
    └── Controllers/HomeController  # Inkomende SMS-verwerking
```

---

## Installatie & Configuratie

> **Let op:** Dit project is ontwikkeld voor intern gebruik op het bedrijfsnetwerk van D'huyvetter Beton. De onderstaande stappen beschrijven hoe de applicatie destijds werd geconfigureerd.

### Vereisten
- Windows 10 of hoger
- .NET Framework 4.6.1 of hoger
- SQL Server Express (lokaal of op netwerkserver)
- Visual Studio 2019 of hoger

### Databaseverbinding instellen

In `DAL/DataAccess.cs` staan de connection strings. Pas deze aan naar jouw SQL Server instantie:

```csharp
static string connectionstringBestelling =
    @"Data Source=JOUW_SERVER\SQLEXPRESS;Initial Catalog=Dhuyvetbestelling;
      User ID=sa;Password=jouw_wachtwoord";

static string connectionstringLevering =
    @"Data Source=JOUW_SERVER\SQLEXPRESS;Initial Catalog=DhuyvetLevering;
      User ID=sa;Password=jouw_wachtwoord";
```

### NuGet-pakketten herstellen

```bash
nuget restore DhuyvetterBeton.Bestelling.sln
```

### TwilioReceive microservice

De SMS-ontvangstservice is een aparte ASP.NET Core 2.1 applicatie. Configureer je Twilio-webhook URL om naar het `/` endpoint te wijzen.

```bash
cd TwilioReceive
dotnet run
```

---

## Databasestructuur

De applicatie gebruikt twee aparte SQL Server-databases:

| Database | Inhoud |
|---|---|
| `Dhuyvetbestelling` | Klanten, werven, bestellingen, formules, pompen, hulpstoffen, facturen, kortingen, offertes, accounts, personeel |
| `DhuyvetLevering` | Leveringsbonnen, leveringsagenda |

---

## Externe Integraties

### Google Cloud Firestore
Gebruikt voor real-time dataopslag en synchronisatie tussen meerdere werkstations. Geconfigureerd via een Firebase service account JSON (`dbintern-*.json`).

### Twilio SMS
- **Uitgaande SMS**: via de Twilio C# SDK vanuit de BL-laag
- **Inkomende SMS**: afgehandeld door de `TwilioReceive` ASP.NET Core microservice

### Google Maps
Werflocaties worden visueel weergegeven via GMap.NET en de Google Maps API. De `FrmGoogleMaps.cs` vorm toont werven op een interactieve kaart.

### Crystal Reports
Gebruikt voor het genereren van geformatteerde leveringsbonnen en rapporten.

---

## Over de ontwikkelaar

Dit project werd volledig zelfstandig ontwikkeld door **Gilles D'huyvetter** als schoolverlater. Het toont aan hoe een doordachte gelaagde architectuur, koppeling met externe diensten en een productierijpe implementatie gerealiseerd kunnen worden vanaf dag één.

---

*Developed with ❤️ for D'huyvetter Beton*
