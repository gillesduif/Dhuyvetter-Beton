using BL;
using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Bestelling
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
        private Formule formule;
        private Pomp pomp;
        private string giek;
        private double m3;
        private DateTime besteldatum;
        private DateTime datum;
        private int levering;
        private string leveringWijze;
        private string loswijze;
        private string comment;
        private Hulpstof hulpstof;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Klant Klant
        {
            get { return klant; }
            set { klant = value; }
        }

       

        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
        }

        public Formule Formule
        {
            get { return formule; }
            set { formule = value; }
        }
      

        public Pomp Pomp
        {
            get { return pomp; }
            set { pomp = value; }
        }

        public string Giek
        {
            get { return giek; }
            set { giek = value; }
        }

        public double M3
        {
            get { return m3; }
            set { m3 = value; }
        }

        public DateTime Besteldatum
        {
            get { return besteldatum; }
            set { besteldatum = value; }
        }

  

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        
        public int Levering
        {
            get { return levering; }
            set { levering = value; }
        }
        public string LeveringWijze
        {
            get { return leveringWijze; }
            set { leveringWijze = value; }
        }
        public string Loswijze
        {
            get { return loswijze; }
            set { loswijze = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

       

        public Hulpstof Hulpstof
        {
            get { return hulpstof; }
            set { hulpstof = value; }
        }
        

        #endregion

        #region constructors

        public Bestelling()
        {
         
        }

        public Bestelling(Klant klant, Werf werf, Formule formule,Pomp pomp,string giek, double m3, DateTime besteldatum, DateTime datum, int levering, string leveringWijze, string loswijze, string comment)
        {
            Klant = klant;
            Werf = werf;
            Formule = formule;
            Pomp = pomp;
            Giek = giek;
            M3 = m3;
            Besteldatum = besteldatum;
            Datum = datum;
            Levering = levering;
            LeveringWijze = leveringWijze;
            Loswijze = loswijze;
            Comment = comment;
        }

        public Bestelling(int id, Klant klant, Werf werf, Formule formule, Pomp pomp, string giek, double m3, DateTime besteldatum, DateTime datum, int levering, string LeveringWijze, string Loswijze, string Comment)
            : this(klant, werf, formule, pomp, giek, m3, besteldatum, datum, levering, LeveringWijze,Loswijze,Comment)
        {
            ID = id;
        }
        #endregion

        #region methods
   
        public static Bestelling ConvertFromDO(BestellingDO bestellingDO)
        {
            if (bestellingDO != null)
            {
                Bestelling bestelling = new Bestelling(bestellingDO.ID, Klant.ConvertFromDO(bestellingDO.KlantDO), Werf.ConvertFromDO(bestellingDO.WerfDO), Formule.ConvertFromDO(bestellingDO.FormuleDO), Pomp.ConvertFromDO(bestellingDO.PompDO), bestellingDO.Giek, bestellingDO.M3, bestellingDO.Besteldatum, bestellingDO.Datum, bestellingDO.Levering, bestellingDO.LeveringWijze, bestellingDO.Loswijze, bestellingDO.Comment);
                return bestelling;
            }
            else
            {
                return null;
            }
           
        }

        public BestellingDO ConvertToDO(Bestelling bestelling)
        {
            BestellingDO bestellingDO = new BestellingDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf), Formule.ConvertToDO(formule),Pomp.ConvertToDO(pomp),Giek ,M3,Besteldatum, Datum, Levering, LeveringWijze,Loswijze,Comment); 
            return bestellingDO;
        }

        public override string ToString()
        {
            return Klant.Naam + " - " + Datum;
        }
        public void GeneerExcellRec(bool saldo, string CAW,string USER)
        {
            Dictionary<string, object> cellenDictionary = new Dictionary<string, object>();

            #region wegschrijven datum+tijd 
            string datumCorrigeren = Datum.ToLongDateString();

            if (Datum.ToLongDateString().Contains("lundi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("lundi", "maandag");
            }
            else if (Datum.ToLongDateString().Contains("mardi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("mardi", "dinsdag");
            }
            else if (Datum.ToLongDateString().Contains("mercredi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("mercredi", "woensdag");
            }
            else if (Datum.ToLongDateString().Contains("jeudi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("jeudi", "donderdag");
            }
            else if (Datum.ToLongDateString().Contains("vendredi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("vendredi", "vrijdag");
            }
            else if (Datum.ToLongDateString().Contains("samedi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("samedi", "zaterdag");
            }
            else if (Datum.ToLongDateString().Contains("dimanche"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("dimanche", "zondag");
            }

            cellenDictionary.Add("B1", datumCorrigeren);   
            cellenDictionary.Add("C1", datum.ToShortTimeString());

            #endregion

            #region wegschrijven Klant

            cellenDictionary.Add("B3", Klant.Naam);
            cellenDictionary.Add("D3", Klant.Gsm);
            cellenDictionary.Add("B4", Klant.Adres);
            cellenDictionary.Add("D4", Klant.Postcode + " " + Klant.Gemeente);
            cellenDictionary.Add("B5", Klant.Telefoon);
            cellenDictionary.Add("D5", Klant.Email);
            cellenDictionary.Add("B6", Klant.Btw);

            #endregion

            #region wegschrijven Werf

            if (Werf != null)
            {
                cellenDictionary.Add("B8", Werf.Adres);
                cellenDictionary.Add("D8", Werf.Postcode + " " + Werf.Gemeente);
            
                cellenDictionary.Add("B9", Werf.Telefoon);
                if (CAW != string.Empty)
                {
                    cellenDictionary.Add("C9", "CAW:");
                    cellenDictionary.Add("D9", CAW);
                }
            }
            #endregion

            #region wegschrijven Pomp

            if (Pomp != null)
            {
                cellenDictionary.Add("B11", Giek);
                cellenDictionary.Add("D11", Pomp.PompLeverancier);
            }


            #endregion
            OmschrijvingProduct omschrijvingProduct = OmschrijvingProduct.KrijgOmschrijvingenViaFormule(Formule.Naam);
            #region wegschrijven Formule
            cellenDictionary.Add("B12", Formule.Omschrijving);
            cellenDictionary.Add("B13", Formule.Naam);
            cellenDictionary.Add("C13", Formule.MaatEenheid + ":");
            if (saldo == false)
            {

                cellenDictionary.Add("D13", M3);
            }
            else
            {
                cellenDictionary.Add("D13", M3 + "+saldo");
            }
            cellenDictionary.Add("B14", Formule.Samenstelling);
            cellenDictionary.Add("D14", Formule.Vloeibaarheid);
            cellenDictionary.Add("B15", Formule.GranuleDiameter);
            cellenDictionary.Add("D15", LeveringWijze);
            cellenDictionary.Add("B16", Loswijze);
            cellenDictionary.Add("D16", Comment);

            #endregion

            #region wegschrijven Hulpstof

            List<Hulpstof> hulpstofList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(ID);
            int counterhulpstof = 18;
            int counter = 0;
            foreach (Hulpstof hulpstof in hulpstofList)
            {
                cellenDictionary.Add("B" + counterhulpstof, hulpstofList[counter].Naam);
                cellenDictionary.Add("D" + counterhulpstof, hulpstofList[counter].Hoeveelheid);
                counter++;
                counterhulpstof++;
            }
            #endregion

            #region wegschrijven
            string[,] cellenArray = new string[22, 4];

            foreach (KeyValuePair<string, object> pair in cellenDictionary)
            {
                int kollom = Convert.ToChar(pair.Key.Substring(0, 1)) - 65;
                int rij = Convert.ToInt32(pair.Key.Substring(1)) - 1;
                if (pair.Value == null)
                {

                }
                else
                {
                    cellenArray[rij, kollom] = pair.Value.ToString();
                }

            }
            try
            {
                string bestandsNaam = klant.Naam + " " + Datum.Hour.ToString() + "u" + Datum.Minute.ToString();
                string strFullpath = @"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy");
                if (!Directory.Exists(strFullpath))
                {
                    string folderName = @"Z:\Bestellingen\";
                    string pathString = System.IO.Path.Combine(folderName, datum.ToString("dd MMMM yyyy"));
                    System.IO.Directory.CreateDirectory(pathString);
                    Excell1.CreateDocument(@"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray, USER);
                }
                else
                {
                    Excell1.CreateDocument(@"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray, USER);
                }
            }
            catch
            {
                
            }
            
            #endregion
        }
        public void GenereerExcell(string USER)
        {
            Dictionary<string, object> cellenDictionary = new Dictionary<string, object>();

            cellenDictionary.Add("B3", ID);

            string datumCorrigeren = Datum.ToLongDateString();

            if (Datum.ToLongDateString().Contains("lundi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("lundi", "maandag");
            }
            else if (Datum.ToLongDateString().Contains("mardi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("mardi", "dinsdag");
            }
            else if (Datum.ToLongDateString().Contains("mercredi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("mercredi", "woensdag");
            }
            else if (Datum.ToLongDateString().Contains("jeudi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("jeudi", "donderdag");
            }
            else if (Datum.ToLongDateString().Contains("vendredi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("vendredi", "vrijdag");
            }
            else if (Datum.ToLongDateString().Contains("samedi"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("samedi", "zaterdag");
            }
            else if (Datum.ToLongDateString().Contains("dimanche"))
            {
                datumCorrigeren = Datum.ToLongDateString().Replace("dimanche", "zondag");
            }

   
            cellenDictionary.Add("D3", datumCorrigeren);
            cellenDictionary.Add("E3", datum.ToShortTimeString());
            cellenDictionary.Add("B6", Klant.Naam);
            cellenDictionary.Add("D6", Klant.Gsm);
            cellenDictionary.Add("B7", Klant.Adres);
            cellenDictionary.Add("D7", Klant.Postcode + " " + Klant.Gemeente);
            cellenDictionary.Add("B8", Klant.Telefoon);
            cellenDictionary.Add("D8", Klant.Email);
            cellenDictionary.Add("B9", Klant.Btw);

            if (Werf != null)
            {
                cellenDictionary.Add("B12", Werf.Adres + " " + Werf.Postcode + " " + Werf.Gemeente);
                cellenDictionary.Add("D12", LeveringWijze);
                cellenDictionary.Add("B13", Werf.Telefoon);
                cellenDictionary.Add("D13", Loswijze);

            }

            if (Pomp != null)
            {
                cellenDictionary.Add("B16",Pomp.Pompdetails );
                cellenDictionary.Add("D16", Pomp.PompLeverancier);
                cellenDictionary.Add("B17", giek);
               
            }

            cellenDictionary.Add("E12", " ");
            cellenDictionary.Add("B20", Formule.Naam);
            cellenDictionary.Add("D21", Formule.Vloeibaarheid);
            cellenDictionary.Add("B21", Formule.Samenstelling);
            cellenDictionary.Add("D20", M3);
            cellenDictionary.Add("B22", Formule.GranuleDiameter);
         //   cellenDictionary.Add("F10", " ");

            List<Hulpstof> hulpstofList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(ID);
            int counterhulpstof = 25;
            int counter = 0;
            foreach(Hulpstof hulpstof in hulpstofList)
            {
                cellenDictionary.Add("B"+ counterhulpstof, hulpstofList[counter].Naam);
                cellenDictionary.Add("D"+ counterhulpstof, hulpstofList[counter].Hoeveelheid);
                counter++;
                counterhulpstof++;
            }
       //     cellenDictionary.Add("B30", Comment);

         


            string[,] cellenArray = new string[40, 6];

            foreach (KeyValuePair<string, object> pair in cellenDictionary)
            {
                int kollom = Convert.ToChar(pair.Key.Substring(0, 1)) - 65;
                int rij = Convert.ToInt32(pair.Key.Substring(1)) - 1;
                if(pair.Value == null)
                {

                }
                else
                {
                    cellenArray[rij, kollom] = pair.Value.ToString();
                }
               
            }

            string bestandsNaam = klant.Naam + " " + Datum.Hour.ToString() + "u" + Datum.Minute.ToString();
            string strFullpath = @"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy");
             if (!Directory.Exists(strFullpath))
                {
                    string folderName = @"Z:\Bestellingen\";
                    string pathString = System.IO.Path.Combine(folderName, datum.ToString("dd MMMM yyyy"));
                    System.IO.Directory.CreateDirectory(pathString);
                    Excell1.CreateDocument(@"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray,USER);
                }
                else
                {
                    Excell1.CreateDocument(@"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray,USER);
                }
           
        }

        public Bestelling MaakNieuweBestelling()
        {
            BestellingDO bestellingDO = DataAccess.MaakNieuweBestelling(ConvertToDO(this));
            return ConvertFromDO(bestellingDO);
        }
        public static Bestelling KrijgBestellingenDoorID(int bestelID)
        {
            BestellingDO bestellingDO = DataAccess.krijgBestellingDoorID(bestelID);
            Bestelling bestelling = ConvertFromDO(bestellingDO);
            return bestelling;
        }
        public static List<Bestelling> KrijgBestellingenDoorKlantID(int ID)
        {
            List<BestellingDO> bestellingDOs = DataAccess.SelecteerBestellingenVanKlant(ID);
            List<Bestelling> bestellingen = new List<Bestelling>();
            foreach (BestellingDO bestellingDO in bestellingDOs)
            {
                bestellingen.Add(ConvertFromDO(bestellingDO));
            }
            return bestellingen;
        }
        public static List<Bestelling> KrijgBestellingenDoorDatumEnKlant(int iD, DateTime dateTime1, DateTime dateTime2)
        {
            List<BestellingDO> bestellingDOs = DataAccess.SelecteerBestellingenVanKlantEnTussenTweeDatum(iD,dateTime1,dateTime2);
            List<Bestelling> bestellingen = new List<Bestelling>();
            foreach (BestellingDO bestellingDO in bestellingDOs)
            {
                bestellingen.Add(ConvertFromDO(bestellingDO));
            }
            return bestellingen;
        }
        public static List<Bestelling> KrijgBestellingenDoorDatumEnPompID(DateTime datum1, int pompID)
        {
            List<BestellingDO> bestellingDOs = DataAccess.SelecteerBestellingenVoorEenDatumEnPomp(datum1,pompID);
            List<Bestelling> bestellingen = new List<Bestelling>();
            foreach (BestellingDO bestellingDO in bestellingDOs)
            {
                bestellingen.Add(ConvertFromDO(bestellingDO));
            }
            return bestellingen;
        }
        public static List<Bestelling> KrijgBestellingenDoorDatum(DateTime datum1)
        {
            List<BestellingDO> bestellingDOs = DataAccess.SelecteerBestellingenVoorEenDatum(datum1);
            List<Bestelling> bestellingen = new List<Bestelling>();
            foreach (BestellingDO bestellingDO in bestellingDOs)
            {
                bestellingen.Add(ConvertFromDO(bestellingDO));
            }
            return bestellingen;
        }

        public void UpdateBestelling()
        {
            BestellingDO bestellingDO = DataAccess.UpdateBestelling(ConvertToDO(this));
        }

        public void VerwijderBestelling()
        {
            BestellingDO bestellingDO = DataAccess.VerwijderBestelling(ConvertToDO(this));
        }

        public void AgendaPuntSluiten()
        {
            BestellingDO bestellingDO = DataAccess.VerwijderAgendaPunt(ConvertToDO(this));
        }
        public void GeneerPompExcell(bool opmerking)
        {
            Dictionary<string, object> cellenDictionary = new Dictionary<string, object>();

            #region wegschrijven Klant

            cellenDictionary.Add("B3", Klant.Naam);
            cellenDictionary.Add("B4", Klant.Adres);
            cellenDictionary.Add("B5", Klant.Postcode + " " + Klant.Gemeente);
            cellenDictionary.Add("B6", Klant.Gsm);
            cellenDictionary.Add("B7", Klant.Btw);


            #endregion

            #region werf
            if (Werf != null)
            {
                cellenDictionary.Add("B9", Werf.Adres);
                cellenDictionary.Add("B10", Werf.Postcode + " " + Werf.Gemeente);
                cellenDictionary.Add("B11", Werf.Telefoon);

            }
            #endregion

            #region wegschrijven datum+tijd
            cellenDictionary.Add("B13", Datum.ToLongDateString());
            cellenDictionary.Add("B14", datum.ToShortTimeString());
            #endregion
           
            cellenDictionary.Add("B16", Formule.Omschrijving);
            cellenDictionary.Add("B17", M3);
            cellenDictionary.Add("B18", Giek);
            if (opmerking == true) { cellenDictionary.Add("B19", Comment); }

            #region wegschrijven
            string[,] cellenArray = new string[20, 2];

            foreach (KeyValuePair<string, object> pair in cellenDictionary)
            {
                int kollom = Convert.ToChar(pair.Key.Substring(0, 1)) - 65;
                int rij = Convert.ToInt32(pair.Key.Substring(1)) - 1;
                if (pair.Value == null)
                {

                }
                else
                {
                    cellenArray[rij, kollom] = pair.Value.ToString();
                }

            }

            string bestandsNaam = klant.Naam + " " + Datum.Hour.ToString() + "u" + Datum.Minute.ToString();
            string strFullpath = @"Z:\PompFiches\" + datum.ToString("dd MMMM yyyy");
            if (!Directory.Exists(strFullpath))
            {
                string folderName = @"Z:\PompFiches\";
                string pathString = System.IO.Path.Combine(folderName, datum.ToString("dd MMMM yyyy"));
                System.IO.Directory.CreateDirectory(pathString);
                ExcellPomp.CreateDocument(@"Z:\PompFiches\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray);
            }
            else
            {
                ExcellPomp.CreateDocument(@"Z:\PompFiches\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray);
            }

            #endregion
        }

        public static Bestelling KrijgBestellingDoor(Klant klant, Werf werf, DateTime value)
        {
            BestellingDO bestellingDO = DataAccess.krijgBestellingDoorKlantWerfDatum(klant.ID, werf.ID, value);
            Bestelling bestelling = ConvertFromDO(bestellingDO);
            return bestelling;
        }
        public static int krijgAantalBestellingen()
        {
            int aantalBestellingen = DataAccess.TelBestellingen();
            return aantalBestellingen;
        }

        public static int KrijgAantalFacturen()
        {
            int AantalFacturen = DataAccess.TelFacturen();
            return AantalFacturen;
        }

        public static int KrijgLaatsteBestelIDdoorDatum(DateTime date)
        {
            int laatsteBestellingID = DataAccess.KrijgLaatsteBestelIDdoorDatum(date);
            //NormaleLeveringBon normaleLeveringBon = ConvertFromDO(normaleLeveringBonDO);
            return laatsteBestellingID;
        }
        #endregion
    }
}