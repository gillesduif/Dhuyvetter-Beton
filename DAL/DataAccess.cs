using DAL.Properties;
using RL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Configuration;
using System.Diagnostics;

namespace DAL
{   
    public class DataAccess
    {
        #region connection
        //static string connectionstringBestelling = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Dhuyvetbestelling;User ID=Gilles_Dhuyvetter;Password=test;"; //TODO fix 
        // static string connectionstringLevering = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DhuyvetLevering;User ID=Gilles_Dhuyvetter;Password=test;";
        static string connectionstringBestelling = @"Data Source=DHUAPP02\SQLEXPRESS;Initial Catalog=Dhuyvetbestelling;Persist Security Info=True;User ID=sa;Password=nYHZgDE5hG3rttU3"; //TODO fix                                                                                                                                                                          // static string connectionstringBestelling = ConfigurationManager.ConnectionStrings["DhuyvetterBeton.Beton.Properties.Settings.DhuyvetBestelllingConnectionString"].ConnectionString;
        static string connectionstringLevering = @"Data Source=DHUAPP02\SQLEXPRESS;Initial Catalog=DhuyvetLevering;Persist Security Info=True;User ID=sa;Password=nYHZgDE5hG3rttU3";//ConfigurationManager.ConnectionStrings["DhuyvetterBeton.Beton.Properties.Settings.DhuyvetLeveringConnectionString"].ConnectionString;
        //  static string connectionstringBestelling = @"Data Source=DHUAPP01\SQLEXPRESS;Initial Catalog=Dhuyvetbestelling;User ID=sa;Password=nYHZgDE5hG3rttU3;"; //TODO fix 
        //static string connectionstringLevering = @"Data Source=DHUAPP01\SQLEXPRESS;Initial Catalog=DhuyvetLevering;User ID=sa;Password=nYHZgDE5hG3rttU3;";
        static string connectionstringCBAS = @"Data Source=mssql.doubledot-vps.be;Initial Catalog=TFC_Dhuyvetter_Beton;User ID=Gilles;Password=xXsg94!0tIUfaxpw;";
        #endregion


        #region straten
        //public static List<StraatnaamDO> KrijgAlleStraten()
        //{
        //    SqlConnection DBconnection = new SqlConnection(connectionstringStraten);

        //    DBconnection.Open();

        //    using (SqlCommand command = new SqlCommand("select * from STRAATNAAM;", DBconnection))
        //    using (SqlDataReader reader = command.ExecuteReader())
        //    {
        //        List<StraatnaamDO> StraatnaamDOs = new List<StraatnaamDO>();

        //        while (reader.Read())
        //        {
        //            StraatnaamDO straatnaamDO = new StraatnaamDO();
        //            {
        //                straatnaamDO.ID = Convert.ToInt32(reader["ID"]);
        //                straatnaamDO.Straat = reader["StraatNaam"].ToString();

        //                StraatnaamDOs.Add(straatnaamDO);
        //            }

        //        }
        //        DBconnection.Close();
        //        return StraatnaamDOs;
        //    }
        //}

        public static List<BenorCategorieDO> KrijgAlleBenorCategories()
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from BenorCategorie;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<BenorCategorieDO> CategorieDOs = new List<BenorCategorieDO>();

                    while (reader.Read())
                    {
                        BenorCategorieDO categorieDO = new BenorCategorieDO();
                        {
                            categorieDO.ID = Convert.ToInt32(reader["ID"]);
                            categorieDO.Naam = reader["Naam"].ToString();

                            CategorieDOs.Add(categorieDO);
                        }

                    }
                    connection1.Close();
                    return CategorieDOs;
                }
            }
        }

        public static KlantDO krijglaatsteKlant()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Klant WHERE ID = (SELECT MAX(ID) FROM Klant);", connection))
                {
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KlantDO klantDO = new KlantDO();
                        while (reader.Read())
                        {

                            {
                                klantDO.ID = Convert.ToInt32(reader["ID"]);
                                klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                                klantDO.Naam = reader["naam"].ToString();
                                string adres = reader["adres"].ToString();
                                string gemeente = reader["gemeente"].ToString();
                                string postcode = reader["postcode"].ToString();
                                string gsm = reader["gsm"].ToString();
                                string telefoon = reader["telefoon"].ToString();
                                string email = reader["email"].ToString();
                                string fax = reader["fax"].ToString();
                                string btw = reader["btw"].ToString();
                                string buitenlandsebtw = reader["buitenlandseBTW"].ToString();
                                klantDO.BetaalCode = reader["betaalCode"].ToString();
                                if (adres != null)
                                {
                                    klantDO.Adres = adres;
                                }
                                else
                                {
                                    klantDO.Adres = "";
                                }
                                if (gemeente != null)
                                {
                                    klantDO.Gemeente = gemeente;
                                }
                                else
                                {
                                    klantDO.Gemeente = "";
                                }
                                if (postcode != null)
                                {
                                    klantDO.Postcode = postcode;
                                }
                                else
                                {
                                    klantDO.Postcode = "";
                                }
                                if (gsm != null)
                                {
                                    klantDO.Gsm = gsm;
                                }
                                else
                                {
                                    klantDO.Gsm = "";
                                }
                                if (telefoon != null)
                                {
                                    klantDO.Telefoon = telefoon;
                                }
                                else
                                {
                                    klantDO.Telefoon = "";
                                }
                                if (email != null)
                                {
                                    klantDO.Email = email;
                                }
                                else
                                {
                                    klantDO.Email = "";
                                }
                                if (fax != null)
                                {
                                    klantDO.Fax = fax;
                                }
                                else
                                {
                                    klantDO.Fax = "";
                                }
                                if (btw != null)
                                {
                                    klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.Btw = "";
                                }
                                if (buitenlandsebtw != null)
                                {
                                    klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.BuitenlandseBtw = "";
                                }

                            }

                        }
                        connection.Close();
                        return klantDO;
                    }
                }
            }
        }

        public static PompPrijsDO UpdatePompPrijs(PompPrijsDO pompPrijsDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update PompPrijs set Giek=@Giek,Bedrag=@Bedrag,Suppliment=@Suppliment where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", pompPrijsDO.ID);
                    command.Parameters.AddWithValue("@Giek", pompPrijsDO.Giek);
                    command.Parameters.AddWithValue("@Bedrag", pompPrijsDO.Bedrag);
                    command.Parameters.AddWithValue("@Suppliment", pompPrijsDO.Suppliment);

                    pompPrijsDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return pompPrijsDO;
                }
            }
        }

        public static PrijsLijstDO krijgPrijsDoorFormuleNaam(string naam)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from PrijsLijst where Formule=@Formule;  ", connection))
                {
                    command.Parameters.AddWithValue("@Formule", naam);
                    PrijsLijstDO prijsLijstDO = new PrijsLijstDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                  

                        while (reader.Read())
                        {

                               
                            prijsLijstDO.ID = Convert.ToInt32(reader["ID"]);
                            prijsLijstDO.Formule = reader["Formule"].ToString();
                            if (reader["Aannemer"] == null)
                            {
                                prijsLijstDO.Aannemer = 0;
                            }
                            else
                            {
                                prijsLijstDO.Aannemer = Convert.ToDouble(reader["Aannemer"]);
                            }

                            if (reader["Particulier"] == null)
                            {
                                prijsLijstDO.Particulier = 0;
                            }
                            else
                            {
                                prijsLijstDO.Particulier = Convert.ToDouble(reader["Particulier"]);
                            }


                        }
                        connection.Close();
                        return prijsLijstDO;
                    }
                }
            }
        }

        public static BenorCategorieDO MaakNieuweBenorCategorie(BenorCategorieDO benorCategorieDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into BenorCategorie (Naam) values(@Naam);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", benorCategorieDO.Naam);
                    benorCategorieDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return benorCategorieDO;
                }
            }
        }
        #endregion

        #region programma

        public static int TelKlanten()
        {try
            {
                using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
                {
                    using (SqlCommand command = new SqlCommand("select COUNT (*) from Klant;", connection))
                    {

                        connection.Open();
                        int count1 = 0;


                        Int32 count = (Int32)command.ExecuteScalar();
                        count1 = count;






                        connection.Close();
                        return count1;

                    }
                }
            }
           catch
            {
                return 0;
            }
        }
        public static int TelFormules()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select COUNT (*) from formule ;", connection))
                {

                    connection.Open();
                    int count1 = 0;


                    Int32 count = (Int32)command.ExecuteScalar();
                    count1 = count;






                    connection.Close();
                    return count1;

                }
            }
        }

        public static List<VerlofDO> KrijgAlleVerlofDagenvoorJaar(DateTime dateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Verlof where year(Startdatum) = @Maand;", connection))
                {
                    command.Parameters.AddWithValue("@Maand", dateTime.Year);
                    command.Parameters.AddWithValue("@Jaar", dateTime.Year);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<VerlofDO> VerlofDOs = new List<VerlofDO>();

                        while (reader.Read())
                        {
                            VerlofDO verlofDO = new VerlofDO();
                            {
                                verlofDO.ID = Convert.ToInt32(reader["ID"]);
                                verlofDO.PersoneelsLid = GetPersoneelsLidByID(Convert.ToInt32(reader["PersoneelID"]));
                                verlofDO.Startdatum = Convert.ToDateTime(reader["Startdatum"]);
                                verlofDO.Einddatum = Convert.ToDateTime(reader["Einddatum"]);
                                VerlofDOs.Add(verlofDO);
                            }

                        }
                        connection.Close();
                        return VerlofDOs;
                    }
                }

            }
        }

        public static List<KlantDO> KrijgAlleKlantenViaKleurCode(string kleurcode)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from klant where betaalCode=@betaalCode;", connection))
                {
                    command.Parameters.AddWithValue("@betaalCode", kleurcode);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<KlantDO> klantDOs = new List<KlantDO>();

                        while (reader.Read())
                        {
                            KlantDO klantDO = new KlantDO();
                            {
                                klantDO.ID = Convert.ToInt32(reader["ID"]);
                                klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                                klantDO.Naam = reader["naam"].ToString();

                                string adres = reader["adres"].ToString();
                                string gemeente = reader["gemeente"].ToString();
                                string postcode = reader["postcode"].ToString();
                                string gsm = reader["gsm"].ToString();
                                string telefoon = reader["telefoon"].ToString();
                                string email = reader["email"].ToString();
                                string fax = reader["fax"].ToString();
                                string btw = reader["btw"].ToString();
                                string buitenlandsebtw = reader["buitenlandseBTW"].ToString();
                                string betaalcode = reader["betaalCode"].ToString();

                                if (adres != null)
                                {
                                    klantDO.Adres = adres;
                                }
                                else
                                {
                                    klantDO.Adres = "";
                                }
                                if (gemeente != null)
                                {
                                    klantDO.Gemeente = gemeente;
                                }
                                else
                                {
                                    klantDO.Gemeente = "";
                                }
                                if (postcode != null)
                                {
                                    klantDO.Postcode = postcode;
                                }
                                else
                                {
                                    klantDO.Postcode = "";
                                }
                                if (gsm != null)
                                {
                                    klantDO.Gsm = gsm;
                                }
                                else
                                {
                                    klantDO.Gsm = "";
                                }
                                if (telefoon != null)
                                {
                                    klantDO.Telefoon = telefoon;
                                }
                                else
                                {
                                    klantDO.Telefoon = "";
                                }
                                if (email != null)
                                {
                                    klantDO.Email = email;
                                }
                                else
                                {
                                    klantDO.Email = "";
                                }
                                if (fax != null)
                                {
                                    klantDO.Fax = fax;
                                }
                                else
                                {
                                    klantDO.Fax = "";
                                }
                                if (btw != null)
                                {
                                    klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.Btw = "";
                                }
                                if (buitenlandsebtw != null)
                                {
                                    klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.BuitenlandseBtw = "";
                                }

                                klantDO.BetaalCode = betaalcode;
                                klantDOs.Add(klantDO);
                            }
                        }
                        connection.Close();
                        return klantDOs;
                    }
                }
            }
        }

        public static VerlofDO krijgVerlofDoorID(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Verlof where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", iD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        VerlofDO verlofDO = new VerlofDO();
                        while (reader.Read())
                        {


                            verlofDO.ID = Convert.ToInt32(reader["ID"]);
                            verlofDO.PersoneelsLid = GetPersoneelsLidByID(Convert.ToInt32(reader["PersoneelID"]));
                            verlofDO.Startdatum = Convert.ToDateTime(reader["Startdatum"]);
                            verlofDO.Einddatum = Convert.ToDateTime(reader["Einddatum"]);

                        }
                        connection.Close();
                        return verlofDO;
                    }
                }
            }
        }
        public static List<CategorieDO> KrijgAlleCategories()
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from categorie;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<CategorieDO> CategorieDOs = new List<CategorieDO>();

                    while (reader.Read())
                    {
                        CategorieDO categorieDO = new CategorieDO();
                        {
                            categorieDO.ID = Convert.ToInt32(reader["ID"]);
                            categorieDO.Naam = reader["Naam"].ToString();

                            CategorieDOs.Add(categorieDO);
                        }

                    }
                    connection1.Close();
                    return CategorieDOs;
                }
            }
        }

       

        public static List<FactuurDO> KrijgAfgekeurdeFacturen()
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur where controle=3;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<FactuurDO> FactuurDOs = new List<FactuurDO>();

                    while (reader.Read())
                    {
                        FactuurDO factuurDO = new FactuurDO();
                        {
                            factuurDO.ID = Convert.ToInt32(reader["ID"]);
                            factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                            factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                            factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                            factuurDO.TotaalVerlegd = Convert.ToDouble(reader["Totaalverlegd"]);
                            factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                            factuurDO.Totaal = Convert.ToDouble(reader["totaal"]);
                            factuurDO.Controle = Convert.ToByte(reader["controle"]);

                            FactuurDOs.Add(factuurDO);
                        }
                        FactuurDOs.Sort((x,y) => x.FactuurNummer.CompareTo(y.FactuurNummer));
                    }
                    connection1.Close();
                    return FactuurDOs;
                }
            }
        }

        public static List<BestellingDO> SelecteerBestellingenVanKlantEnTussenTweeDatum(int iD, DateTime dateTime1, DateTime dateTime2)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from bestelling where klantID=@klantID and datum between @datum1 and @datum2;", connection))
                {
                    command.Parameters.AddWithValue("@klantID", iD);
                    command.Parameters.AddWithValue("@datum1", dateTime1);
                    command.Parameters.AddWithValue("@datum2", dateTime2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BestellingDO> bestellingDOs = new List<BestellingDO>();

                        while (reader.Read())
                        {
                            BestellingDO bestellingDO = new BestellingDO();
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingDO.Giek = reader["Giek"].ToString();
                            bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                            bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                            bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingDO.Comment = reader["comment"].ToString();

                            bestellingDOs.Add(bestellingDO);
                        }
                        connection.Close();
                        return bestellingDOs;
                    }
                }
            }
        }

        public static FactuurDO KrijgLaatsteFactuur()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from factuur WHERE ID = (SELECT MAX(ID) FROM factuur);;", connection))
                {
                 

                    connection.Open();
                    FactuurDO factuurDO = new FactuurDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            factuurDO.ID = Convert.ToInt32(reader["ID"]);
                            factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                            factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                            factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["Totaalverlegd"]);
                            factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaal"]);
                        }

                    }
                    connection.Close();
                    return factuurDO;
                }
            }
        }

        public static FormuleDO UpdateFormuleAA(FormuleDO formuleDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update formuleAA set Naam=@Naam,SterkteKlasse=@SterkteKlasse,Vloeibaarheid=@Vloeibaarheid,OmgevingsKlasse=@OmgevingsKlasse,GranuleDiameter=@GranuleDiameter,Samenstelling=@Samenstelling,CemmentType=@CemmentType,Omschrijving=@Omschrijving where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", formuleDO.ID);
                    command.Parameters.AddWithValue("@Naam", formuleDO.Naam);
                    command.Parameters.AddWithValue("@SterkteKlasse", formuleDO.SterkteKlasse);
                    command.Parameters.AddWithValue("@Vloeibaarheid", formuleDO.Vloeibaarheid);
                    command.Parameters.AddWithValue("@OmgevingsKlasse", formuleDO.OmgevingsKlasse);
                    command.Parameters.AddWithValue("@GranuleDiameter", formuleDO.GranuleDiameter);
                    command.Parameters.AddWithValue("@Samenstelling", formuleDO.Samenstelling);
                    command.Parameters.AddWithValue("@CemmentType", formuleDO.CemmentType);
                    command.Parameters.AddWithValue("@Omschrijving", formuleDO.Omschrijving);
                    formuleDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return formuleDO;
                }
            }
        }

        public static Factuur_ItemDO KrijgFactuurItemDoorEigenID(int factuurItemID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from factuur_Item where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", factuurItemID);
                 
                    connection.Open();
                    Factuur_ItemDO factuur_ItemDO = new Factuur_ItemDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            factuur_ItemDO.ID = Convert.ToInt32(reader["ID"]);
                            factuur_ItemDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            factuur_ItemDO.FactuurDO = GetFactuurByID(Convert.ToInt32(reader["factuurID"]));
                            factuur_ItemDO.OmschrijvingProductDO = GetOmschrijvingByID(Convert.ToInt32(reader["omschrijvingProductID"]));
                            factuur_ItemDO.PompPrijsDO = GetPompPrijsByID(Convert.ToInt32(reader["pompSoortID"]));
                            factuur_ItemDO.BestelDatum = Convert.ToDateTime(reader["bestelDatum"]);
                            factuur_ItemDO.TransportTotaal = Convert.ToDouble(reader["transportTotaal"]);
                            factuur_ItemDO.PompSuplimentEenheidsPrijs = Convert.ToDouble(reader["pompSuplimentEenheidsPrijs"]);
                            factuur_ItemDO.PompTotaalSuplimentPrijs = Convert.ToDouble(reader["pompTotaalSuplimentPrijs"]);
                            factuur_ItemDO.PompWachtTijd = Convert.ToDouble(reader["pompWachtTijd"]);
                            factuur_ItemDO.GepompteM3 = Convert.ToDouble(reader["gepompteM3"]);
                            factuur_ItemDO.LaadEnLosTijdenTotaal = Convert.ToDouble(reader["laadEnLosTijdenTotaal"]);
                            factuur_ItemDO.Onvolledige_Lading_Hoeveelheid = Convert.ToDouble(reader["onvolledige_Lading_Hoeveelheid"]);
                            factuur_ItemDO.Onvolledige_Lading_Prijs = Convert.ToDouble(reader["onvolledige_Lading_Prijs"]);
                            factuur_ItemDO.ProductPrijs = Convert.ToDouble(reader["productPrijs"]);
                            factuur_ItemDO.EenheidsPrijs = Convert.ToDouble(reader["eenheidsPrijs"]);
                            factuur_ItemDO.HoeveelheidProduct = Convert.ToDouble(reader["hoeveelheidProduct"]);
                            factuur_ItemDO.Subtotaal = Convert.ToDouble(reader["subtotaal"]);
                        }
                    }
                    connection.Close();
                    return factuur_ItemDO;
                }
            }
        }

        public static AfvoerInvoerDO MaakNieuwAfvoerInvoer(AfvoerInvoerDO afvoerInvoerDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into AfvoerInvoer(KlantID,DatumTijd,AfvoerInvoer,Chauffeur,Nummerplaat,FormuleID,Ton,Productiebatchnr,Bruto,Tarra,Netto) values(@KlantID,@DatumTijd,@AfvoerInvoer,@Chauffeur,@Nummerplaat,@FormuleID,@Ton,@Productiebatchnr,@Bruto,@Tarra,@Netto);", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", afvoerInvoerDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@DatumTijd", afvoerInvoerDO.DatumTijd);
                    command.Parameters.AddWithValue("@AfvoerInvoer", afvoerInvoerDO.Afvoer_Invoer);
                    command.Parameters.AddWithValue("@Chauffeur", afvoerInvoerDO.Chauffeur);
                    command.Parameters.AddWithValue("@Nummerplaat", afvoerInvoerDO.Nummerplaat);
                    command.Parameters.AddWithValue("@FormuleID", afvoerInvoerDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@Ton", afvoerInvoerDO.Ton);
                    command.Parameters.AddWithValue("@Productiebatchnr", afvoerInvoerDO.Productiebatchnr);
                    command.Parameters.AddWithValue("@Bruto", afvoerInvoerDO.Bruto);
                    command.Parameters.AddWithValue("@Tarra", afvoerInvoerDO.Tarra);
                    command.Parameters.AddWithValue("@Netto", afvoerInvoerDO.Netto);
                    afvoerInvoerDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return afvoerInvoerDO;
                }
            }
        }

        public static List<FormuleDO> KrijgAlleFormulesBA()
        {
            List<FormuleDO> FormuleDOs = new List<FormuleDO>();
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from formule;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FormuleDO formuleDO = new FormuleDO();
                        {
                            formuleDO.ID = Convert.ToInt32(reader["ID"]);
                            formuleDO.Naam = reader["Naam"].ToString();
                            formuleDO.OmgevingsKlasse = reader["OmgevingsKlasse"].ToString();
                            formuleDO.Samenstelling = reader["Samenstelling"].ToString();
                            formuleDO.SterkteKlasse = reader["SterkteKlasse"].ToString();
                            formuleDO.Vloeibaarheid = reader["Vloeibaarheid"].ToString();
                            formuleDO.GranuleDiameter = reader["GranuleDiameter"].ToString();
                            formuleDO.CemmentType = reader["CemmentType"].ToString();
                            formuleDO.IsBenor = Convert.ToBoolean(reader["IsBenor"]);
                            formuleDO.BenorCategorieDO = GetBenorCategoryByID(Convert.ToInt32(reader["BenorCategorieID"]));
                            formuleDO.MaatEenheid = reader["MaatEenheid"].ToString();
                            formuleDO.Omschrijving = reader["Omschrijving"].ToString();
                            Debug.WriteLine(formuleDO.MaatEenheid.ToString());
                            FormuleDOs.Add(formuleDO);
                        }

                    }
                    connection1.Close();
                
                }
            }
            using (SqlConnection connection2 = new SqlConnection(connectionstringBestelling))
            {

                connection2.Open();
                using (SqlCommand command = new SqlCommand("select * from formuleAA;", connection2))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FormuleDO formuleDO = new FormuleDO();
                        {
                            formuleDO.ID = Convert.ToInt32(reader["ID"]);
                            formuleDO.Naam = reader["Naam"].ToString();
                            formuleDO.OmgevingsKlasse = reader["OmgevingsKlasse"].ToString();
                            formuleDO.Samenstelling = reader["Samenstelling"].ToString();
                            formuleDO.SterkteKlasse = reader["SterkteKlasse"].ToString();
                            formuleDO.Vloeibaarheid = reader["Vloeibaarheid"].ToString();
                            formuleDO.GranuleDiameter = reader["GranuleDiameter"].ToString();
                            formuleDO.CemmentType = reader["CemmentType"].ToString();
                            formuleDO.BenorCategorieDO = GetBenorCategoryByID(1);
                            formuleDO.Omschrijving = reader["Omschrijving"].ToString();
                            FormuleDOs.Add(formuleDO);
                        }

                    }
                    connection2.Close();

                }
            }
            return FormuleDOs;
        }

        public static FormuleDO MaakNieuweAAFormule(FormuleDO formuleDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into formuleAA (Naam,SterkteKlasse,Vloeibaarheid,OmgevingsKlasse,GranuleDiameter,Samenstelling,CemmentType,Omschrijving) values(@Naam,@SterkteKlasse,@Vloeibaarheid,@OmgevingsKlasse,@GranuleDiameter,@Samenstelling,@CemmentType,@Omschrijving);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", formuleDO.Naam);
                    command.Parameters.AddWithValue("@SterkteKlasse", formuleDO.SterkteKlasse);
                    command.Parameters.AddWithValue("@Vloeibaarheid", formuleDO.Vloeibaarheid);
                    command.Parameters.AddWithValue("@OmgevingsKlasse", formuleDO.OmgevingsKlasse);
                    command.Parameters.AddWithValue("@GranuleDiameter", formuleDO.GranuleDiameter);
                    command.Parameters.AddWithValue("@Samenstelling", formuleDO.Samenstelling);
                    command.Parameters.AddWithValue("@CemmentType", formuleDO.CemmentType);
                    command.Parameters.AddWithValue("@Omschrijving", formuleDO.Omschrijving);

                    formuleDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return formuleDO;
                }
            }
        }

        public static List<AfvoerInvoerDO> SelecteerAfVoerInvoerItemsVoorDatums(DateTime datum1, DateTime datum2)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from AfvoerInvoer where DatumTijd between @datum1 and @datum2;", connection))
                {

                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<AfvoerInvoerDO> AfvoerInvoerDOs = new List<AfvoerInvoerDO>();

                        while (reader.Read())
                        {
                            AfvoerInvoerDO afvoerInvoerDO = new AfvoerInvoerDO();
                            afvoerInvoerDO.ID = Convert.ToInt32(reader["ID"]);
                            afvoerInvoerDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            afvoerInvoerDO.WerfDO = GetWerfAAByID(Convert.ToInt32(reader["WerfAAID"]));
                            afvoerInvoerDO.Chauffeur = reader["Chauffeur"].ToString();
                            afvoerInvoerDO.Nummerplaat = reader["Nummerplaat"].ToString();
                            afvoerInvoerDO.DatumTijd = Convert.ToDateTime(reader["DatumTijd"]);
                            afvoerInvoerDO.Afvoer_Invoer = reader["AfvoerInvoer"].ToString();
                            afvoerInvoerDO.FormuleDO = GetFormuleAAByID(Convert.ToInt32(reader["FormuleID"]));
                            afvoerInvoerDO.Ton = Convert.ToDouble(reader["Ton"]);
                            afvoerInvoerDO.Productiebatchnr = reader["Productiebatchnr"].ToString();
                            afvoerInvoerDO.Bruto = reader["Bruto"].ToString();
                            afvoerInvoerDO.Tarra = reader["Tarra"].ToString();
                            afvoerInvoerDO.Netto = reader["Netto"].ToString();
                            afvoerInvoerDO.Dopnummer = reader["DOP"].ToString();
                            afvoerInvoerDO.Opmerking = reader["Opmerking"].ToString();
                            AfvoerInvoerDOs.Add(afvoerInvoerDO);
                        }
                        connection.Close();
                        return AfvoerInvoerDOs;
                    }
                }
            }
        }

        public static FormuleDO GetFormuleAAByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from formuleAA where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        FormuleDO formuleDO = new FormuleDO();
                        while (reader.Read())
                        {
                            {
                                formuleDO.ID = Convert.ToInt32(reader["ID"]);
                                formuleDO.Naam = reader["Naam"].ToString();
                                formuleDO.SterkteKlasse = reader["SterkteKlasse"].ToString();
                                formuleDO.Vloeibaarheid = reader["Vloeibaarheid"].ToString();
                                formuleDO.OmgevingsKlasse = reader["OmgevingsKlasse"].ToString();
                                formuleDO.GranuleDiameter = reader["GranuleDiameter"].ToString();
                                formuleDO.Samenstelling = reader["Samenstelling"].ToString();
                                formuleDO.CemmentType = reader["CemmentType"].ToString();
                                formuleDO.Omschrijving = reader["Omschrijving"].ToString();
                                formuleDO.IsBenor = false;
                                BenorCategorieDO benorCategorieDO = new BenorCategorieDO(0, "");
                                formuleDO.BenorCategorieDO = benorCategorieDO;

                            }
                        }
                        connection.Close();
                        return formuleDO;
                    }
                }
            }
        }

        private static WerfDO GetWerfAAByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from werfAA where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        WerfDO werfDO = new WerfDO();
                        while (reader.Read())
                        {
                            {
                                werfDO.ID = Convert.ToInt32(reader["ID"]);
                                werfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["KlantID"]));
                                werfDO.Adres = reader["Adres"].ToString();
                                werfDO.Gemeente = reader["Gemeente"].ToString();
                                werfDO.Postcode = reader["Postcode"].ToString();
                                werfDO.Telefoon = reader["Telefoon"].ToString();
                            }
                        }
                        connection.Close();
                        return werfDO;
                    }
                }
            }
        }

        public static bool ControleBestaanAgendaPunt(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from AgendaLeveringen where bestelID=@bestelID;  ", connection))
                {
                    command.Parameters.AddWithValue("@bestelID", ID);
                    bool value = false;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                      
                        while (reader.Read())
                        {
                            value = true;
                           


                        }

                        return value;
                    }
                }
            }
        }

        public static int KrijgLaatsteKlantID()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from Klant WHERE ID = (SELECT MAX(ID) FROM Klant);", connection))
                {
                    int klantID = 0;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            klantID = Convert.ToInt32(reader["ID"]);
                           
                        }

                    }
                    connection.Close();
                    return klantID;

                }
            }
        }

        public static AgendaLeveringenDO VerwijderAgendapuntDoorBestellingID(int bestelID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from AgendaLeveringen where bestelID=@bestelID",
                            connection))
                {
                    command.Parameters.AddWithValue("@bestelID", bestelID);

                    command.ExecuteScalar();
                    connection.Close();
                    return null;
                }
            }
        }

        public static PrijsLijstDO ToevoegenPrijsLijst(PrijsLijstDO prijsLijstDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Prijslijst (Formule,Aannemer,Particulier) values(@Formule,@Aannemer,@Particulier) ",
                            connection))
                {
                    command.Parameters.AddWithValue("@Formule", prijsLijstDO.Formule);
                    command.Parameters.AddWithValue("@Aannemer", prijsLijstDO.Aannemer);
                    command.Parameters.AddWithValue("@Particulier", prijsLijstDO.Particulier);

                    prijsLijstDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return prijsLijstDO;
                }
            }
        }

        public static ProductWebshopDO MaakNieuweProductWebshop(ProductWebshopDO productWebshopDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Product (CategorieID,Product_OmschrijvingID,FormuleID,AfbeeldingLocatie,ThumbLocatie) values(@CategorieID,@Product_OmschrijvingID,@FormuleID,@AfbeeldingLocatie,@ThumbLocatie);",
                            connection))
                {
                    command.Parameters.AddWithValue("@CategorieID", productWebshopDO.CategorieDO.ID);
                    command.Parameters.AddWithValue("@Product_OmschrijvingID", productWebshopDO.OmschrijvingProductDO.ID);
                    command.Parameters.AddWithValue("@FormuleID", productWebshopDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@AfbeeldingLocatie", productWebshopDO.AfbeeldingLocatie);
                    command.Parameters.AddWithValue("@ThumbLocatie", productWebshopDO.ThumbLocatie);
                    productWebshopDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return productWebshopDO;
                }
            }
        }

        public static OmschrijvingProductDO WijzigProductOmschrijving(OmschrijvingProductDO omschrijvingProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                
                    using (SqlCommand command = new SqlCommand("update  Product_Omschrijving set Formule=@Formule,Omschrijving=@Omschrijving where ID=@ID;",
                            connection))
                    {
                        command.Parameters.AddWithValue("@ID", omschrijvingProductDO.ID);
                        command.Parameters.AddWithValue("@Formule", omschrijvingProductDO.Formule);
                        command.Parameters.AddWithValue("@Omschrijving", omschrijvingProductDO.Omschrijving);

                        omschrijvingProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        return omschrijvingProductDO;
                    }
            }
        }

        public static CategorieDO MaakNieuweCategorie(CategorieDO categorieDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Categorie (Naam) values(@Naam);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", categorieDO.Naam);
                    categorieDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return categorieDO;
                }
            }
        }
        public static int TelBonnen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {
                using (SqlCommand command = new SqlCommand("select COUNT (*) from NormaleLeveringBons;", connection))
                {

                    connection.Open();
                    int count1 = 0;
                    Int32 count = (Int32)command.ExecuteScalar();
                    count1 = count;

                    connection.Close();
                    return count1;

                }
            }
        }

        public static List<KlantNotitieDO> SelecteerAlleNotitiesVanKlant(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from KlantNotitie where klantID=@klantID;", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<KlantNotitieDO> KlantNotitieDOs = new List<KlantNotitieDO>();

                        while (reader.Read())
                        {
                            KlantNotitieDO klantNotitieDO = new KlantNotitieDO();
                            klantNotitieDO.ID = Convert.ToInt32(reader["ID"]);
                            klantNotitieDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            klantNotitieDO.Notitie = reader["Notitie"].ToString();


                            KlantNotitieDOs.Add(klantNotitieDO);
                        }
                        connection.Close();
                        return KlantNotitieDOs;
                    }
                }
            }
        }

        public static int TelWerven()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select COUNT (*) from Werf;", connection))
                {

                    connection.Open();
                    int count1 = 0;


                    Int32 count = (Int32)command.ExecuteScalar();
                    count1 = count;






                    connection.Close();
                    return count1;

                }
            }
        }
        public static int TelFacturen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select COUNT (*) from factuur;", connection))
                {

                    connection.Open();
                    int count1 = 0;


                    Int32 count = (Int32)command.ExecuteScalar();
                    count1 = count;






                    connection.Close();
                    return count1;

                }
            }
        }
        public static int TelBestellingen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select COUNT (*) from bestelling;", connection))
                {

                    connection.Open();
                    int count1 = 0;


                    Int32 count = (Int32)command.ExecuteScalar();
                    count1 = count;






                    connection.Close();
                    return count1;

                }
            }
        }
        #region werven
        public static WerfDO MaakNieuweWerf(WerfDO werfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into werf (klantID,adres,gemeente,postcode,telefoon) values(@KlantID,@Adres,@Gemeente,@Postcode,@Telefoon);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", werfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Adres", werfDO.Adres);
                    command.Parameters.AddWithValue("@Gemeente", werfDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", werfDO.Postcode);
                    command.Parameters.AddWithValue("@Telefoon", werfDO.Telefoon);

                    werfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return werfDO;
                }
            }
        }

        public static VerlofDO MaakNieuwVerlofPunt(VerlofDO verlofDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Verlof (PersoneelID,Startdatum,Einddatum) values(@PersoneelID,@Startdatum,@Einddatum);",
                            connection))
                {
                    command.Parameters.AddWithValue("@PersoneelID", verlofDO.PersoneelsLid.ID);
                    command.Parameters.AddWithValue("@Startdatum", verlofDO.Startdatum);
                    command.Parameters.AddWithValue("@Einddatum", verlofDO.Einddatum);

                    verlofDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return verlofDO;
                }
            }
        }

        public static AfdrukWachtRijDO KrijgAfdrukTaak(int bestelID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from AfdrukWachtRij where BestellingID=@BestellingID;", connection))
                {
                    command.Parameters.AddWithValue("@BestellingID", bestelID);
          
                    connection.Open();
                    AfdrukWachtRijDO afdrukWachtRijDO = new AfdrukWachtRijDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            afdrukWachtRijDO.ID = Convert.ToInt32(reader["ID"]);
                            afdrukWachtRijDO.BestelID = Convert.ToInt32(reader["BestellingID"]);

                        }

                    }
                    connection.Close();
                    return afdrukWachtRijDO;
                }
            }
        }

        public static PersoneelDO NieuwPersoneelsLid(PersoneelDO personeelDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into PersoneelLijst (Naam,GSM,Email) values(@Naam,@GSM,@Email);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", personeelDO.Naam);
                    command.Parameters.AddWithValue("@GSM", personeelDO.Gsm);
                    command.Parameters.AddWithValue("@Email", personeelDO.Email);
                    personeelDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return personeelDO;
                }
            }
        }

        public static int KrijgLaatsteBestelIDdoorDatum(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("Select Top 50 * from bestelling where datum between @datum1 and @datum2 ORDER BY datum;", connection))
                {
                    command.Parameters.AddWithValue("@datum1", date);
                    command.Parameters.AddWithValue("@datum2", date.AddDays(+1));
                    int bestelID = 0;
                    connection.Open();
                 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            if (bestelID > Convert.ToInt32(reader["ID"]))
                            {

                            }
                            else
                            {
                                bestelID = Convert.ToInt32(reader["ID"]);
                            }
                     

                        }

                    }
                    connection.Close();
                    return bestelID;
                }
            }
        }

        public static PersoneelDO VerwijderPersoneelsLid(PersoneelDO personeelDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from PersoneelLijst where ID=@ID;",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", personeelDO.ID);

                    personeelDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return personeelDO;
                }
            }
        }

        public static List<LogboekDO> SelecteerLogboekPuntenVoorEenDatum(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Logboek where DatumEnTijd between @datum1 and @datum2;", connection))
                {
                    DateTime datum2;
                    command.Parameters.AddWithValue("@datum1", date);
                    datum2 = date.AddDays(1);
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<LogboekDO> LogboekDOs = new List<LogboekDO>();

                        while (reader.Read())
                        {
                            LogboekDO logboekDO = new LogboekDO();
                            logboekDO.ID = Convert.ToInt32(reader["ID"]);
                            logboekDO.DatumEnTijd = Convert.ToDateTime(reader["DatumEnTijd"]);
                            logboekDO.Functie = reader["Functie"].ToString();
                            logboekDO.Taak = reader["Taak"].ToString();
                            logboekDO.Gebruiker = reader["Gebruiker"].ToString();

                            LogboekDOs.Add(logboekDO);
                        }
                        connection.Close();
                        return LogboekDOs;
                    }
                }
            }
        }

        public static VerlofDO VerwijderVerlofPunt(VerlofDO verlofDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from Verlof where ID=@ID;",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", verlofDO.ID);
                 

                    command.ExecuteScalar();
                    connection.Close();
                    return verlofDO;
                }
            }
        }

        public static VerlofDO WijzigVerlofPunt(VerlofDO verlofDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update Verlof set PersoneelID=@PersoneelID,Startdatum=@Startdatum,Einddatum=@Einddatum where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", verlofDO.ID);
                    command.Parameters.AddWithValue("@PersoneelID", verlofDO.PersoneelsLid.ID);
                    command.Parameters.AddWithValue("@Startdatum", verlofDO.Startdatum);
                    command.Parameters.AddWithValue("@Einddatum", verlofDO.Einddatum);

                    verlofDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return verlofDO;
                }
            }
        }

        public  static void  VerwijderbestellingPrefab(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from BestellingPrefab where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);


                    int IDreturn = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                  
                }
            }
        }

        public static List<VerlofDO> KrijgAlleVerlofDagenDatumEnPersoneel(DateTime datum, int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Verlof where month(Startdatum) = @Maand or month(Einddatum) = @Maand and year(Startdatum) =@Jaar;", connection))
                {
                    command.Parameters.AddWithValue("@Maand", datum.Month);
                    command.Parameters.AddWithValue("@Jaar", datum.Year);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<VerlofDO> VerlofDOs = new List<VerlofDO>();
                        List<VerlofDO> verloffilter = new List<VerlofDO>();
                        while (reader.Read())
                        {
                            VerlofDO verlofDO = new VerlofDO();
                            {
                                verlofDO.ID = Convert.ToInt32(reader["ID"]);
                                verlofDO.PersoneelsLid = GetPersoneelsLidByID(Convert.ToInt32(reader["PersoneelID"]));
                                verlofDO.Startdatum = Convert.ToDateTime(reader["Startdatum"]);
                                verlofDO.Einddatum = Convert.ToDateTime(reader["Einddatum"]);
                                VerlofDOs.Add(verlofDO);
                            }
                            foreach (VerlofDO verlof in VerlofDOs)
                            {
                                if(verloffilter.Contains(verlof) != true)
                                {
                                    if (verlof.PersoneelsLid.ID == iD)
                                    {
                                        verloffilter.Add(verlof);
                                    }
                                }
                              
                            }
                        }
                        connection.Close();
                        return verloffilter;
                    }
                }

            }

        }

        public static ProductPrefabDO WijzigProductPrefab(ProductPrefabDO productPrefabDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update ProductPrefab set Lot=@Lot,Aantalstuks=@Aantalstuks,LangsteElement=@LangsteElement,M3=@M3,PrefabBestellingID=@PrefabBestellingID where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", productPrefabDO.ID);
                    command.Parameters.AddWithValue("@Lot", productPrefabDO.Lot);
                    command.Parameters.AddWithValue("@Aantalstuks", productPrefabDO.Aantalstuks);
                    command.Parameters.AddWithValue("@LangsteElement", productPrefabDO.LangsteElement);
                    command.Parameters.AddWithValue("@M3", productPrefabDO.M3);
                    command.Parameters.AddWithValue("@PrefabBestellingID", productPrefabDO.PrefabBestellingID);

                    productPrefabDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return productPrefabDO;
                }
            }
        }

        public static List<LogboekDO> SelecteerLogboekPuntenVoorEenDatumEnGebruiker(DateTime date, string gebruiker)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Logboek where DatumEnTijd between @datum1 and @datum2 and Gebruiker=@Gebruiker;", connection))
                {
                    DateTime datum2;
                    command.Parameters.AddWithValue("@datum1", date);
                    datum2 = date.AddDays(1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@Gebruiker", gebruiker);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<LogboekDO> LogboekDOs = new List<LogboekDO>();

                        while (reader.Read())
                        {
                            LogboekDO logboekDO = new LogboekDO();
                            logboekDO.ID = Convert.ToInt32(reader["ID"]);
                            logboekDO.DatumEnTijd = Convert.ToDateTime(reader["DatumEnTijd"]);
                            logboekDO.Functie = reader["Functie"].ToString();
                            logboekDO.Taak = reader["Taak"].ToString();
                            logboekDO.Gebruiker = reader["Gebruiker"].ToString();

                            LogboekDOs.Add(logboekDO);
                        }
                        connection.Close();
                        return LogboekDOs;
                    }
                }
            }
        }

        public static List<LogboekDO> SelecteerLogboekPuntenVoorEenDatumEnFunctieEnGebruiker(DateTime date, string functie, string gebruiker)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Logboek where DatumEnTijd between @datum1 and @datum2 and Functie=@Functie and Gebruiker=@Gebruiker;", connection))
                {
                    DateTime datum2;
                    command.Parameters.AddWithValue("@datum1", date);
                    datum2 = date.AddDays(1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@Functie", functie);
                    command.Parameters.AddWithValue("@Gebruiker", gebruiker);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<LogboekDO> LogboekDOs = new List<LogboekDO>();

                        while (reader.Read())
                        {
                            LogboekDO logboekDO = new LogboekDO();
                            logboekDO.ID = Convert.ToInt32(reader["ID"]);
                            logboekDO.DatumEnTijd = Convert.ToDateTime(reader["DatumEnTijd"]);
                            logboekDO.Functie = reader["Functie"].ToString();
                            logboekDO.Taak = reader["Taak"].ToString();
                            logboekDO.Gebruiker = reader["Gebruiker"].ToString();

                            LogboekDOs.Add(logboekDO);
                        }
                        connection.Close();
                        return LogboekDOs;
                    }
                }
            }
        }

        public static List<LogboekDO> SelecteerLogboekPuntenVoorEenDatumEnFunctie(DateTime date, string functie)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Logboek where DatumEnTijd between @datum1 and @datum2 and Functie=@Functie;", connection))
                {
                    DateTime datum2;
                    command.Parameters.AddWithValue("@datum1", date);
                    datum2 = date.AddDays(1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@Functie", functie);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<LogboekDO> LogboekDOs = new List<LogboekDO>();

                        while (reader.Read())
                        {
                            LogboekDO logboekDO = new LogboekDO();
                            logboekDO.ID = Convert.ToInt32(reader["ID"]);
                            logboekDO.DatumEnTijd = Convert.ToDateTime(reader["DatumEnTijd"]);
                            logboekDO.Functie = reader["Functie"].ToString();
                            logboekDO.Taak = reader["Taak"].ToString();
                            logboekDO.Gebruiker = reader["Gebruiker"].ToString();

                            LogboekDOs.Add(logboekDO);
                        }
                        connection.Close();
                        return LogboekDOs;
                    }
                }
            }
        }

        public static LogboekDO MaakNieuwLogboekPunt(LogboekDO logboekDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Logboek (DatumEnTijd,Functie,Taak,Gebruiker) values(@DatumEnTijd,@Functie,@Taak,@Gebruiker);select @@identity;",
                            connection))
                {
                    command.Parameters.AddWithValue("@DatumEnTijd", logboekDO.DatumEnTijd);
                    command.Parameters.AddWithValue("@Functie", logboekDO.Functie);
                    command.Parameters.AddWithValue("@Taak", logboekDO.Taak);
                    command.Parameters.AddWithValue("@Gebruiker", logboekDO.Gebruiker);

                    logboekDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return logboekDO;
                }
            }
        }

        public static List<KlantPrefabDO> KrijgAllePrefabKlanten()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from klantPrefab;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<KlantPrefabDO> klantPrefabDOs = new List<KlantPrefabDO>();

                    while (reader.Read())
                    {
                        KlantPrefabDO klantPrefabDO = new KlantPrefabDO();
                        {
                            klantPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                            klantPrefabDO.Naam = reader["Naam"].ToString();
                            klantPrefabDO.Straat= reader["Straat"].ToString();
                            klantPrefabDO.Gemeente = reader["Gemeente"].ToString();
                            klantPrefabDO.Postcode = reader["Postcode"].ToString();



                            klantPrefabDOs.Add(klantPrefabDO);
                        }
                    }
                    connection.Close();
                    return klantPrefabDOs;
                }
            }
        }

     
        public static BestellingPrefabDO MaakNieuweBestellingPrefab(BestellingPrefabDO bestellingPrefabDO)
        {
            int newID = 0;
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into BestellingPrefab (KlantPrefabID,WerfPrefabID,Datum,Levering,Opmerking) values(@KlantPrefabID,@WerfPrefabID,@Datum,@Levering,@Opmerking); select @@identity;",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantPrefabID", bestellingPrefabDO.KlantPrefabDO.ID);
                    command.Parameters.AddWithValue("@WerfPrefabID", bestellingPrefabDO.WerfPrefabDO.ID);
                    command.Parameters.AddWithValue("@Datum", bestellingPrefabDO.Datum);
                    command.Parameters.AddWithValue("@Levering", bestellingPrefabDO.Levering);
                    command.Parameters.AddWithValue("@Opmerking", bestellingPrefabDO.Opmerking);

                    newID = Convert.ToInt32(command.ExecuteScalar());
                    List<ProductPrefabDO> productPrefabDOs = bestellingPrefabDO.ProductPrefabDO;
        
                    foreach (ProductPrefabDO productPrefabDO in productPrefabDOs)
                    {
                        ProductPrefabDO productPrefabDOID = new ProductPrefabDO(productPrefabDO.Lot,productPrefabDO.Aantalstuks, productPrefabDO.LangsteElement, productPrefabDO.M3, newID);
                        maakNieuweProductvoorPrefabBestelling(productPrefabDOID);
                    }
                    connection.Close();
                    return bestellingPrefabDO;
                }
            }
        }

        public static BestellingPrefabDO WijzigBestellingPrefab(BestellingPrefabDO bestellingPrefabDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update BestellingPrefab set KlantPrefabID=@KlantPrefabID,WerfPrefabID=@WerfPrefabID,datum=@datum,levering=@levering,Opmerking=@Opmerking where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", bestellingPrefabDO.ID);
                    command.Parameters.AddWithValue("@KlantPrefabID", bestellingPrefabDO.KlantPrefabDO.ID);
                    command.Parameters.AddWithValue("@WerfPrefabID", bestellingPrefabDO.WerfPrefabDO.ID);
                    command.Parameters.AddWithValue("@datum", bestellingPrefabDO.Datum);
                    command.Parameters.AddWithValue("@levering", bestellingPrefabDO.Levering);
                    command.Parameters.AddWithValue("@Opmerking", bestellingPrefabDO.Opmerking);

                    bestellingPrefabDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bestellingPrefabDO;
                }
            }
        }

        public static List<BestellingPrefabDO> SelecteerBestellingenPrefabDatum(DateTime datum1, DateTime datum2)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from BestellingPrefab where datum between @datum1 and @datum2;", connection))
                {
            
                    command.Parameters.AddWithValue("@datum1", datum1);
             
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BestellingPrefabDO> bestellingDOs = new List<BestellingPrefabDO>();

                        while (reader.Read())
                        {
                            BestellingPrefabDO bestellingDO = new BestellingPrefabDO();
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantPrefabDO = GetPrefabKlantByID(Convert.ToInt32(reader["KlantPrefabID"]));
                            bestellingDO.WerfPrefabDO = GetPrefabWerfByID(Convert.ToInt32(reader["WerfPrefabID"]));
                            List<ProductPrefabDO> productPrefabDOs = KrijgAlleProductenViaID(Convert.ToInt32(reader["ID"]));
                            bestellingDO.ProductPrefabDO = productPrefabDOs;
                            bestellingDO.Datum = Convert.ToDateTime(reader["Datum"]);
                            bestellingDO.Levering = reader["levering"].ToString();
                            bestellingDO.Opmerking = reader["Opmerking"].ToString();
                       
                            bestellingDOs.Add(bestellingDO);
                        }
                        connection.Close();
                        return bestellingDOs;
                    }
                }
            }
        }

        public static List<ProductPrefabDO> KrijgAlleProductenViaID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from ProductPrefab where PrefabBestellingID=@PrefabBestellingID;", connection))
                {

                    command.Parameters.AddWithValue("@PrefabBestellingID", ID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<ProductPrefabDO> ProductPrefabDOs = new List<ProductPrefabDO>();

                        while (reader.Read())
                        {
                            ProductPrefabDO productPrefabDO = new ProductPrefabDO();
                            productPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                            productPrefabDO.Lot = reader["Lot"].ToString();
                            productPrefabDO.Aantalstuks = reader["Aantalstuks"].ToString();
                            productPrefabDO.LangsteElement = reader["LangsteElement"].ToString();
                            productPrefabDO.M3 = reader["M3"].ToString();
                            productPrefabDO.PrefabBestellingID = Convert.ToInt32(reader["PrefabBestellingID"]);
                            Debug.WriteLine(productPrefabDO.Lot);
                            ProductPrefabDOs.Add(productPrefabDO);
                        }
                        connection.Close();
                        return ProductPrefabDOs;
                    }
                }
            }
        }

        private static WerfPrefabDO GetPrefabWerfByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from WerfPrefab where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        WerfPrefabDO werfPrefabDO = new WerfPrefabDO();
                        while (reader.Read())
                        {
                            {
                                werfPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                                werfPrefabDO.KlantPrefabDO = GetPrefabKlantByID(Convert.ToInt32(reader["KlantPrefabID"]));
                                werfPrefabDO.Adres = reader["Adres"].ToString();
                                werfPrefabDO.Gemeente = reader["Gemeente"].ToString();
                                werfPrefabDO.Postcode = reader["Postcode"].ToString();
                                werfPrefabDO.ContactPersoonPrefabDO =  GetContactpersoonByID(Convert.ToInt32(reader["ContactPersoonPrefabID"]));
                            }
                        }
                        connection.Close();
                        return werfPrefabDO;
                    }
                }
            }
        }

        private static ContactPersoonPrefabDO GetContactpersoonByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from ContactpersoonPrefab where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ContactPersoonPrefabDO contactPersoonPrefabDO = new ContactPersoonPrefabDO();
                        while (reader.Read())
                        {
                            {
                                contactPersoonPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                                contactPersoonPrefabDO.KlantPrefabDO = GetPrefabKlantByID(Convert.ToInt32(reader["KlantPrefabID"]));
                                contactPersoonPrefabDO.Naam = reader["Naam"].ToString();
                                contactPersoonPrefabDO.Voornaam = reader["Voornaam"].ToString();
                                contactPersoonPrefabDO.Telefoon = reader["Telefoon"].ToString();
                                contactPersoonPrefabDO.GSM = reader["GSM"].ToString();
                            }
                        }
                        connection.Close();
                        return contactPersoonPrefabDO;
                    }
                }
            }
        }

        private static void maakNieuweProductvoorPrefabBestelling(ProductPrefabDO productPrefabDOID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into ProductPrefab (Lot,Aantalstuks,LangsteElement,M3,PrefabBestellingID) values(@Lot,@Aantalstuks,@LangsteElement,@M3,@PrefabBestellingID);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Lot", productPrefabDOID.Lot);
                    command.Parameters.AddWithValue("@Aantalstuks", productPrefabDOID.Aantalstuks);
                    command.Parameters.AddWithValue("@LangsteElement", productPrefabDOID.LangsteElement);
                    command.Parameters.AddWithValue("@M3", productPrefabDOID.M3);
                    command.Parameters.AddWithValue("@PrefabBestellingID", productPrefabDOID.PrefabBestellingID);
                    
                    productPrefabDOID.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                  
                }
            }
        }

        public static int ControleerBlokeerMailKlant(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from BlokeerMail where klantID=@klantID;", connection))
                {

                    command.Parameters.AddWithValue("klantID", klantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int klantIDGet = -1;
                        while (reader.Read())
                        {
                            klantIDGet = Convert.ToInt32(reader["klantID"]);


                        }
                        if (klantIDGet == -1)
                        {
                            klantIDGet = 0;
                        }

                        connection.Close();
                        return klantIDGet;
                    }
                }

            }
        }

        public static  KlantDO BlokeerMailKlant(KlantDO klantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into BlokeerMail (klantID) values(@klantID);", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantDO.ID);
                 
                    int ID = 0;
                    ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
            }
            return null;
        }

        public static List<WerfPrefabDO> KrijgAlleWervenPrefabDoorKlantID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from WerfPrefab where KlantPrefabID=@KlantPrefabID;", connection))
                {

                    command.Parameters.AddWithValue("@KlantPrefabID", ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        List<WerfPrefabDO> WerfPrefabDOs = new List<WerfPrefabDO>();
                        while (reader.Read())
                        {
                            WerfPrefabDO werfPrefabDO = new WerfPrefabDO();
                            {
                                werfPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                                werfPrefabDO.KlantPrefabDO = GetPrefabKlantByID(Convert.ToInt32(reader["KlantPrefabID"]));
                                werfPrefabDO.Adres = reader["Adres"].ToString();
                                werfPrefabDO.Gemeente = reader["Gemeente"].ToString();
                                werfPrefabDO.Postcode = reader["Postcode"].ToString();
                                werfPrefabDO.ContactPersoonPrefabDO = GetContactPersoonByID(Convert.ToInt32(reader["ContactPersoonPrefabID"]));



                                WerfPrefabDOs.Add(werfPrefabDO);
                            }
                        }
                        connection.Close();
                        return WerfPrefabDOs;
                    }
                }
            }
        }

        private static ContactPersoonPrefabDO GetContactPersoonByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from ContactpersoonPrefab where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ContactPersoonPrefabDO contactPersoonPrefabDO = new ContactPersoonPrefabDO();
                        while (reader.Read())
                        {

                            {
                                contactPersoonPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                                contactPersoonPrefabDO.Naam = reader["Naam"].ToString();
                                contactPersoonPrefabDO.Voornaam = reader["Voornaam"].ToString();
                                contactPersoonPrefabDO.Telefoon = reader["Telefoon"].ToString();
                                contactPersoonPrefabDO.GSM = reader["GSM"].ToString();
                                contactPersoonPrefabDO.KlantPrefabDO = GetPrefabKlantByID(Convert.ToInt32(reader["KlantPrefabID"]));
                            }

                        }
                        connection.Close();
                        return contactPersoonPrefabDO;
                    }
                }
            }
        }

        public static ContactPersoonPrefabDO MaakNieuweContactpersoonPrefab(ContactPersoonPrefabDO contactPersoonPrefabDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into ContactpersoonPrefab (Naam,Voornaam,Telefoon,GSM,KlantPrefabID) values(@Naam,@Voornaam,@Telefoon,@GSM,@KlantPrefabID);",
                            connection))
                {
                  
                    command.Parameters.AddWithValue("@Naam", contactPersoonPrefabDO.Naam);
                    command.Parameters.AddWithValue("@Voornaam", contactPersoonPrefabDO.Voornaam);
                    command.Parameters.AddWithValue("@Telefoon", contactPersoonPrefabDO.Telefoon);
                    command.Parameters.AddWithValue("@GSM", contactPersoonPrefabDO.GSM);
                    command.Parameters.AddWithValue("@KlantPrefabID", contactPersoonPrefabDO.KlantPrefabDO.ID);
                    contactPersoonPrefabDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return contactPersoonPrefabDO;
                }
            }
        }

        public static WerfPrefabDO MaakNieuweWerfPrefab(WerfPrefabDO werfPrefabDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into WerfPrefab (KlantPrefabID,adres,gemeente,postcode,ContactPersoonPrefabID) values(@KlantPrefabID,@Adres,@Gemeente,@Postcode,@ContactPersoonPrefabID);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantPrefabID", werfPrefabDO.KlantPrefabDO.ID);
                    command.Parameters.AddWithValue("@Adres", werfPrefabDO.Adres);
                    command.Parameters.AddWithValue("@Gemeente", werfPrefabDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", werfPrefabDO.Postcode);
                    command.Parameters.AddWithValue("@ContactPersoonPrefabID", werfPrefabDO.ContactPersoonPrefabDO.ID);

                    werfPrefabDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return werfPrefabDO;
                }
            }
        }

        public static List<ContactPersoonPrefabDO> KrijgAlleContactpersonenDoorKlantID(int prefabKlantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from ContactpersoonPrefab where KlantPrefabID=@KlantPrefabID;", connection))
                {

                    command.Parameters.AddWithValue("@KlantPrefabID", prefabKlantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        List<ContactPersoonPrefabDO> ContactPersoonPrefabDOs = new List<ContactPersoonPrefabDO>();
                        while (reader.Read())
                        {
                            ContactPersoonPrefabDO contactPersoonPrefabDO = new ContactPersoonPrefabDO();
                            {
                                contactPersoonPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                                contactPersoonPrefabDO.Naam = reader["Naam"].ToString();
                                contactPersoonPrefabDO.Voornaam = reader["Voornaam"].ToString();
                                contactPersoonPrefabDO.Telefoon = reader["Telefoon"].ToString();
                                contactPersoonPrefabDO.GSM = reader["GSM"].ToString();
                                contactPersoonPrefabDO.KlantPrefabDO = GetPrefabKlantByID(Convert.ToInt32(reader["KlantPrefabID"]));


                                ContactPersoonPrefabDOs.Add(contactPersoonPrefabDO);
                            }
                        }
                        connection.Close();
                        return ContactPersoonPrefabDOs;
                    }
                }
            }
        }

        private static KlantPrefabDO GetPrefabKlantByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from KlantPrefab where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KlantPrefabDO klantPrefabDO = new KlantPrefabDO();
                        while (reader.Read())
                        {

                            {
                                klantPrefabDO.ID = Convert.ToInt32(reader["ID"]);
                                klantPrefabDO.Naam = reader["naam"].ToString();
                                klantPrefabDO.Straat = reader["Straat"].ToString();
                                klantPrefabDO.Postcode = reader["Postcode"].ToString();
                                klantPrefabDO.Gemeente = reader["Gemeente"].ToString();
                            }

                        }
                        connection.Close();
                        return klantPrefabDO;
                    }
                }
            }
        }

        public static KlantPrefabDO MaakNieuwePrefabKlant(KlantPrefabDO klantPrefabDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into klantPrefab (Naam,Straat,Gemeente,Postcode) values(@Naam,@Straat,@Gemeente,@Postcode);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", klantPrefabDO.Naam);
                    command.Parameters.AddWithValue("@Straat", klantPrefabDO.Straat);
                    command.Parameters.AddWithValue("@Gemeente", klantPrefabDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", klantPrefabDO.Postcode);


                    klantPrefabDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return klantPrefabDO;
                }
            }
        }

        public void VerwijderBugReport(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from Bug_Report where ID=@ID;",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                   
                }
            }
         
        }

        public static List<VerlofDO> KrijgAlleVerlofDagenvoorMaand(DateTime datum)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Verlof where month(Startdatum) = @Maand or month(Einddatum) = @Maand and year(Startdatum) =@Jaar;", connection))
                {
                    command.Parameters.AddWithValue("@Maand", datum.Month);
                    command.Parameters.AddWithValue("@Jaar", datum.Year);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<VerlofDO> VerlofDOs = new List<VerlofDO>();

                        while (reader.Read())
                        {
                            VerlofDO verlofDO = new VerlofDO();
                            {
                                verlofDO.ID = Convert.ToInt32(reader["ID"]);
                                verlofDO.PersoneelsLid = GetPersoneelsLidByID(Convert.ToInt32(reader["PersoneelID"]));
                                verlofDO.Startdatum = Convert.ToDateTime(reader["Startdatum"]);
                                verlofDO.Einddatum = Convert.ToDateTime(reader["Einddatum"]);
                                VerlofDOs.Add(verlofDO);
                            }

                        }
                        connection.Close();
                        return VerlofDOs;
                    }
                }
               
            }
        }

        public static List<VerlofDO> KrijgAlleVerlofDagenvoordag(DateTime dateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Verlof where Startdatum = @Startdatum;", connection))
                {
                    command.Parameters.AddWithValue("@Startdatum", dateTime);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<VerlofDO> VerlofDOs = new List<VerlofDO>();

                        while (reader.Read())
                        {
                            VerlofDO verlofDO = new VerlofDO();
                            {
                                verlofDO.ID = Convert.ToInt32(reader["ID"]);
                                verlofDO.PersoneelsLid = GetPersoneelsLidByID(Convert.ToInt32(reader["PersoneelID"]));
                                verlofDO.Startdatum = Convert.ToDateTime(reader["Startdatum"]);
                                verlofDO.Einddatum = Convert.ToDateTime(reader["Einddatum"]);
                                VerlofDOs.Add(verlofDO);
                            }

                        }
                        connection.Close();
                        return VerlofDOs;
                    }
                }

            }
        }

        private static PersoneelDO GetPersoneelsLidByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from PersoneelLijst where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        PersoneelDO personeelDO = new PersoneelDO();
                        while (reader.Read())
                        {
                            {
                                personeelDO.ID = Convert.ToInt32(reader["ID"]);
                                personeelDO.Naam = reader["Naam"].ToString();
                                personeelDO.Gsm = reader["GSM"].ToString();
                                personeelDO.Email = reader["Email"].ToString();
                            
                            }
                        }
                        connection.Close();
                        return personeelDO;
                    }
                }
            }
        }

        public static CodeRoodDO MaakNieuwCodeRood(CodeRoodDO codeRoodDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into CodeRood (BestelID,KlantID) values(@BestelID,@KlantID);",
                            connection))
                {
                    command.Parameters.AddWithValue("@BestelID", codeRoodDO.BestelID);
                    command.Parameters.AddWithValue("@KlantID", codeRoodDO.KlantID);
              
                    codeRoodDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return codeRoodDO;
                }
            }
        }

        public static OfferteKlantDO MaakNieuweOfferteKlant(OfferteKlantDO offerteKlantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into OfferteKlant (KlantID,Transport,OnvolledigeLading,Bedrag,Opmerking) values(@KlantID,@Transport,@OnvolledigeLading,@Bedrag,@Opmerking);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", offerteKlantDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteKlantDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteKlantDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteKlantDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteKlantDO.Opmerking);
                    offerteKlantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteKlantDO;
                }
            }
        }

        public static OfferteWerfProductDO WijzigOfferteWerfProduct(OfferteWerfProductDO offerteWerfProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update offerteWerfProduct set KlantID=@KlantID,werfID=@werfID,ProductID=@ProductID,Transport=@Transport,OnvolledigeLading=@OnvolledigeLading,Bedrag=@Bedrag,Opmerking=@Opmerking where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", offerteWerfProductDO.ID);
                    command.Parameters.AddWithValue("@KlantID", offerteWerfProductDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", offerteWerfProductDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@ProductID", offerteWerfProductDO.ProductDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteWerfProductDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteWerfProductDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteWerfProductDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteWerfProductDO.Opmerking);


                    offerteWerfProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteWerfProductDO;
                }
            }
        }

        public static List<OfferteWerfProductDO> KrijgAlleOffertesWervenEnProductVanKlant(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from OfferteWerfProduct where KlantID=@KlantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", iD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OfferteWerfProductDO> offerteWerfProductDOs = new List<OfferteWerfProductDO>();

                        while (reader.Read())
                        {

                            OfferteWerfProductDO offerteWerfProductDO = new OfferteWerfProductDO();
                            {
                                offerteWerfProductDO.ID = Convert.ToInt32(reader["ID"]);
                                offerteWerfProductDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["KlantID"]));
                                offerteWerfProductDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["WerfID"]));
                                offerteWerfProductDO.ProductDO = GetOmschrijvingByID(Convert.ToInt32(reader["ProductID"]));
                                offerteWerfProductDO.Transport = Convert.ToDouble(reader["Transport"]);
                                offerteWerfProductDO.OnvolledigeLading = Convert.ToDouble(reader["OnvolledigeLading"]);
                                offerteWerfProductDO.Bedrag = Convert.ToDouble(reader["Bedrag"]);
                                offerteWerfProductDO.Opmerking = reader["Opmerking"].ToString();

                                offerteWerfProductDOs.Add(offerteWerfProductDO);
                            }

                        }
                        connection.Close();
                        return offerteWerfProductDOs;
                    }
                }
            }
        }

        public static OfferteProductDO WijzigOfferteProduct(OfferteProductDO offerteProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update offerteProduct set KlantID=@KlantID,productID=@productID,Transport=@Transport,OnvolledigeLading=@OnvolledigeLading,Bedrag=@Bedrag,Opmerking=@Opmerking where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", offerteProductDO.ID);
                    command.Parameters.AddWithValue("@KlantID", offerteProductDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@productID", offerteProductDO.ProductDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteProductDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteProductDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteProductDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteProductDO.Opmerking);


                    offerteProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteProductDO;
                }
            }
        }

        public static List<OfferteProductDO> KrijgAlleOffertesProductenVanKlant(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from OfferteProduct where KlantID=@KlantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", iD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OfferteProductDO> offerteProductDOs = new List<OfferteProductDO>();

                        while (reader.Read())
                        {

                            OfferteProductDO offerteProductDO = new OfferteProductDO();
                            {
                                offerteProductDO.ID = Convert.ToInt32(reader["ID"]);
                                offerteProductDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["KlantID"]));
                                offerteProductDO.ProductDO = GetOmschrijvingByID(Convert.ToInt32(reader["ProductID"]));
                                offerteProductDO.Transport = Convert.ToDouble(reader["Transport"]);
                                offerteProductDO.OnvolledigeLading = Convert.ToDouble(reader["OnvolledigeLading"]);
                                offerteProductDO.Bedrag = Convert.ToDouble(reader["Bedrag"]);
                                offerteProductDO.Opmerking = reader["Opmerking"].ToString();

                                offerteProductDOs.Add(offerteProductDO);
                            }

                        }
                        connection.Close();
                        return offerteProductDOs;
                    }
                }
            }
        }

        public static List<OfferteWerfDO> KrijgAlleOffertesWervenVanKlant(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from OfferteWerf where KlantID=@KlantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", iD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OfferteWerfDO> OfferteWerfDOs = new List<OfferteWerfDO>();

                        while (reader.Read())
                        {

                            OfferteWerfDO offerteWerfDO = new OfferteWerfDO();
                            {
                                offerteWerfDO.ID = Convert.ToInt32(reader["ID"]);
                                offerteWerfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["KlantID"]));
                                offerteWerfDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["WerfID"]));
                                offerteWerfDO.Transport = Convert.ToDouble(reader["Transport"]);
                                offerteWerfDO.OnvolledigeLading = Convert.ToDouble(reader["OnvolledigeLading"]);
                                offerteWerfDO.Bedrag = Convert.ToDouble(reader["Bedrag"]);
                                offerteWerfDO.Opmerking = reader["Opmerking"].ToString();

                                OfferteWerfDOs.Add(offerteWerfDO);
                            }

                        }
                        connection.Close();
                        return OfferteWerfDOs;
                    }
                }
            }
        }

        public static OfferteWerfDO WijzigOfferteWerf(OfferteWerfDO offerteWerfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update offerteWerf set KlantID=@KlantID,werfID=@werfID,Transport=@Transport,OnvolledigeLading=@OnvolledigeLading,Bedrag=@Bedrag,Opmerking=@Opmerking where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", offerteWerfDO.ID);
                    command.Parameters.AddWithValue("@KlantID", offerteWerfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", offerteWerfDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteWerfDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteWerfDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteWerfDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteWerfDO.Opmerking);


                    offerteWerfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteWerfDO;
                }
            }
        }

        public static OfferteKlantDO WijzigOfferteKlant(OfferteKlantDO offerteKlantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update OfferteKlant set KlantID=@KlantID,Transport=@Transport,OnvolledigeLading=@OnvolledigeLading,Bedrag=@Bedrag,Opmerking=@Opmerking where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", offerteKlantDO.ID);
                    command.Parameters.AddWithValue("@KlantID", offerteKlantDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteKlantDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteKlantDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteKlantDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteKlantDO.Opmerking);


                    offerteKlantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteKlantDO;
                }
            }
        }

        public static List<OfferteKlantDO> KrijgAlleOffertesVanKlant(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from OfferteKlant where klantID=@klantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@klantID", iD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OfferteKlantDO> OfferteKlantDOs = new List<OfferteKlantDO>();

                        while (reader.Read())
                        {

                            OfferteKlantDO offerteKlantDO = new OfferteKlantDO();
                                {
                                offerteKlantDO.ID = Convert.ToInt32(reader["ID"]);
                                offerteKlantDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                offerteKlantDO.Transport = Convert.ToDouble(reader["Transport"]);
                                offerteKlantDO.OnvolledigeLading = Convert.ToDouble(reader["OnvolledigeLading"]);
                                offerteKlantDO.Bedrag = Convert.ToDouble(reader["Bedrag"]);
                                offerteKlantDO.Opmerking = reader["Opmerking"].ToString();

                                OfferteKlantDOs.Add(offerteKlantDO);
                                }
                            
                        }
                        connection.Close();
                        return OfferteKlantDOs;
                    }
                }
            }
        }

        public static OfferteWerfProductDO MaakNieuweofferteWerfProduct(OfferteWerfProductDO offerteWerfProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into offerteWerfProduct (KlantID,WerfID,ProductID,Transport,OnvolledigeLading,Bedrag,Opmerking) values(@KlantID,@WerfID,@ProductID,@Transport,@OnvolledigeLading,@Bedrag,@Opmerking);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", offerteWerfProductDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@WerfID", offerteWerfProductDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@ProductID", offerteWerfProductDO.ProductDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteWerfProductDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteWerfProductDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteWerfProductDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteWerfProductDO.Opmerking);
                    offerteWerfProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteWerfProductDO;
                }
            }
        }

        public static OfferteWerfDO MaakNieuweOfferteWerf(OfferteWerfDO offerteWerfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into OfferteWerf (KlantID,WerfID,Transport,OnvolledigeLading,Bedrag,Opmerking) values(@KlantID,@WerfID,@Transport,@OnvolledigeLading,@Bedrag,@Opmerking);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", offerteWerfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@WerfID", offerteWerfDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteWerfDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteWerfDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteWerfDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteWerfDO.Opmerking);
                    offerteWerfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteWerfDO;
                }
            }
        }

        public static OfferteProductDO MaakNieuweOfferteProduct(OfferteProductDO offerteProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into OfferteProduct (KlantID,ProductID,Transport,OnvolledigeLading,Bedrag,Opmerking) values(@KlantID,@ProductID,@Transport,@OnvolledigeLading,@Bedrag,@Opmerking);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", offerteProductDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@ProductID", offerteProductDO.ProductDO.ID);
                    command.Parameters.AddWithValue("@Transport", offerteProductDO.Transport);
                    command.Parameters.AddWithValue("@OnvolledigeLading", offerteProductDO.OnvolledigeLading);
                    command.Parameters.AddWithValue("@Bedrag", offerteProductDO.Bedrag);
                    command.Parameters.AddWithValue("@Opmerking", offerteProductDO.Opmerking);
                    offerteProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return offerteProductDO;
                }
            }
        }

    

        public static CodeRoodDO VerwijderCodeRooddoorBestelID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from CodeRood where ID=@ID;",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return null;
                }
            }
        }

        public static CodeRoodDO krijgCodeRoodDoorBestellingID(int bestelID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from CodeRood where BestelID=@BestelID;  ", connection))
                {
                    command.Parameters.AddWithValue("@BestelID", bestelID);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        CodeRoodDO CodeRoodDO = new CodeRoodDO();
                        while (reader.Read())
                        {

                            CodeRoodDO.ID = Convert.ToInt32(reader["ID"]);
                            CodeRoodDO.BestelID = Convert.ToInt32(reader["BestelID"]);
                            CodeRoodDO.KlantID = Convert.ToInt32(reader["KlantID"]);
                        }

                        return CodeRoodDO;
                    }
                }
            }
        }

        public static List<AfdrukWachtRijDO> SelecteerAfdrukOpdrachten()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from AfdrukWachtRij;", connection))
                {
                 

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<AfdrukWachtRijDO> AfdrukWachtRijDOs = new List<AfdrukWachtRijDO>();

                        while (reader.Read())
                        {
                            AfdrukWachtRijDO afdrukWachtRijDO = new AfdrukWachtRijDO();
                            afdrukWachtRijDO.ID = Convert.ToInt32(reader["ID"]);
                            afdrukWachtRijDO.BestelID = Convert.ToInt32(reader["BestellingID"]);
                           

                            AfdrukWachtRijDOs.Add(afdrukWachtRijDO);
                        }
                        connection.Close();
                        return AfdrukWachtRijDOs;
                    }
                }
            }
        }

        public static AfdrukWachtRijDO MaakNieuweAfdrukTaak(AfdrukWachtRijDO afdrukWachtRijDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into AfdrukWachtRij (BestellingID) values (@BestellingID);",
                            connection))
                {
                    command.Parameters.AddWithValue("@BestellingID", afdrukWachtRijDO.BestelID);

                    afdrukWachtRijDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return afdrukWachtRijDO;
                }
            }
        }

        public static AfdrukWachtRijDO VerwijderAfdrukItem(AfdrukWachtRijDO afdrukWachtRijDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from AfdrukWachtRij where BestellingID=@BestellingID;",
                            connection))
                {
                    command.Parameters.AddWithValue("@BestellingID", afdrukWachtRijDO.BestelID);

                    afdrukWachtRijDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return afdrukWachtRijDO;
                }
            }
        }

        public static PrijsSettingDO MaakNieuwePrijsSetting(PrijsSettingDO prijsSettingDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into PrijsSetting (Soort,KlantID) values(@Soort,@KlantID);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", prijsSettingDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Soort", prijsSettingDO.Soort);


                    prijsSettingDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return prijsSettingDO;
                }
            }
        }

        public static Korting_KlantDO UpdateKlantKorting(Korting_KlantDO korting_KlantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update Korting_Klant set KlantID=@KlantID,bedrag=@bedrag where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", korting_KlantDO.ID);
                    command.Parameters.AddWithValue("@KlantID", korting_KlantDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@bedrag", korting_KlantDO.Bedrag);

                    korting_KlantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_KlantDO;
                }
            }
        }

        public static List<BugReportDO> KrijgAlleBugReports()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Bug_Report ;", connection))
                {
          

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BugReportDO> BugReportDOs = new List<BugReportDO>();

                        while (reader.Read())
                        {
                            BugReportDO bugReportDO = new BugReportDO();
                            bugReportDO.ID = Convert.ToInt32(reader["ID"]);
                            bugReportDO.Type = reader["Type"].ToString();
                            bugReportDO.Prioriteit = reader["Prioriteit"].ToString();
                            bugReportDO.Sectie = reader["Sectie"].ToString();
                            bugReportDO.Omschrijving = reader["Omschrijving"].ToString();
                            bugReportDO.Afbeelding = ((byte[])reader["Afbeelding"]);
                            bugReportDO.Gebruiker = reader["Gebruiker"].ToString();
                            BugReportDOs.Add(bugReportDO);
                        }
                        connection.Close();
                        return BugReportDOs;
                    }
                }
            }
        }

        public static BugReportDO MaakNieuwRapport(BugReportDO bugReportDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Bug_Report (Type,Prioriteit,Sectie,Omschrijving,Afbeelding,Gebruiker) values(@Type,@Prioriteit,@Sectie,@Omschrijving,@Afbeelding,@Gebruiker);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Type", bugReportDO.Type);
                    command.Parameters.AddWithValue("@Prioriteit", bugReportDO.Prioriteit);
                    command.Parameters.AddWithValue("@Sectie", bugReportDO.Sectie);
                    command.Parameters.AddWithValue("@Omschrijving", bugReportDO.Omschrijving);
                    command.Parameters.AddWithValue("@Afbeelding", bugReportDO.Afbeelding);
                    command.Parameters.AddWithValue("@Gebruiker", bugReportDO.Gebruiker);
                    
                    bugReportDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bugReportDO;
                }
            }
        }

        public static List<Korting_KlantDO> KrijgAlleKortingenDooKlantID(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Korting_Klant where KlantID=@KlantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_KlantDO> Korting_KlantDOList = new List<Korting_KlantDO>();

                        while (reader.Read())
                        {
                            Korting_KlantDO korting_KlantDO = new Korting_KlantDO();
                            {
                                korting_KlantDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_KlantDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                        
                                korting_KlantDO.Bedrag = Convert.ToDouble(reader["bedrag"]);


                                Korting_KlantDOList.Add(korting_KlantDO);
                            }

                        }
                        connection.Close();
                        return Korting_KlantDOList;
                    }
                }
            }
        }

        public static FactuurDO WijzigFactuur(FactuurDO factuurDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update factuur set KlantID=@KlantID,factuurnummer=@factuurnummer,datum=@datum,totaalExclBtw=@totaalExclBtw,Totaalverlegd=@Totaalverlegd,totaalIncl6Btw=@totaalIncl6Btw,totaalIncl21Btw=@totaalIncl21Btw,totaal=@totaal where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", factuurDO.ID);
                    command.Parameters.AddWithValue("@KlantID", factuurDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@factuurnummer", factuurDO.FactuurNummer);
                    command.Parameters.AddWithValue("@datum", factuurDO.Datum);
                    command.Parameters.AddWithValue("@totaalExclBtw", factuurDO.TotaalExclBtw);
                    command.Parameters.AddWithValue("@Totaalverlegd", factuurDO.TotaalVerlegd);
                    command.Parameters.AddWithValue("@totaalIncl6Btw", factuurDO.TotaalIncl6Btw);
                    command.Parameters.AddWithValue("@totaalIncl21Btw", factuurDO.TotaalIncl21Btw);
                    command.Parameters.AddWithValue("@totaal", factuurDO.Totaal);
                
                    factuurDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return factuurDO;
                }
            }
        }

        public static List<FactuurDO> KrijgTeControlerenFacturen()
        {
                using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from factuur where controle=2;  ", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<FactuurDO> FactuurDOList = new List<FactuurDO>();

                            while (reader.Read())
                            {
                                FactuurDO factuurDO = new FactuurDO();
                                {
                                    factuurDO.ID = Convert.ToInt32(reader["ID"]);
                                    factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                    factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                                    factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                                    factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                                    factuurDO.TotaalVerlegd = Convert.ToDouble(reader["Totaalverlegd"]);
                                    factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                                    factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                                    factuurDO.Totaal = Convert.ToDouble(reader["totaal"]);
                                    factuurDO.Controle = Convert.ToByte(reader["controle"]);
                                }
                                FactuurDOList.Add(factuurDO);
                            }
                            connection.Close();
                            return FactuurDOList;
                        }
                    }
                }
        }

        public static Korting_WerfDO UpdateKorting_WerfDO(Korting_WerfDO korting_WerfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update korting_werf set KlantID=@KlantID,werfID=@werfID,bedrag=@bedrag where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", korting_WerfDO.ID);
                    command.Parameters.AddWithValue("@KlantID", korting_WerfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", korting_WerfDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@bedrag", korting_WerfDO.Bedrag);

                    korting_WerfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_WerfDO;
                }
            }
        }

        public static Korting_Product_WerfDO UpdateKorting_WerfProductDO(Korting_Product_WerfDO korting_Product_WerfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update korting_product_werf set KlantID=@KlantID,werfID=@werfID,productID=@productID,bedrag=@bedrag where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", korting_Product_WerfDO.ID);
                    command.Parameters.AddWithValue("@KlantID", korting_Product_WerfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", korting_Product_WerfDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@productID", korting_Product_WerfDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@bedrag", korting_Product_WerfDO.Bedrag);

                    korting_Product_WerfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_Product_WerfDO;
                }
            }
        }

        public static Korting_ProductDO UpdateKorting_ProductDO(Korting_ProductDO korting_ProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update korting_product set KlantID=@KlantID,productID=@productID,bedrag=@bedrag where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", korting_ProductDO.ID);
                    command.Parameters.AddWithValue("@KlantID", korting_ProductDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@productID", korting_ProductDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@bedrag", korting_ProductDO.Bedrag);

                    korting_ProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_ProductDO;
                }
            }
        }

        public static List<Korting_Product_WerfDO> KrijgAlleKortingenWerfProductDoorKlantID(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from korting_Product_Werf where klantID=@klantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantID);
                  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_Product_WerfDO> Korting_Product_WerfDOList = new List<Korting_Product_WerfDO>();

                        while (reader.Read())
                        {
                            Korting_Product_WerfDO korting_Product_WerfDO = new Korting_Product_WerfDO();
                            {
                                korting_Product_WerfDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_Product_WerfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                korting_Product_WerfDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                korting_Product_WerfDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                                korting_Product_WerfDO.Bedrag = Convert.ToDouble(reader["bedrag"]);

                                Korting_Product_WerfDOList.Add(korting_Product_WerfDO);
                            }

                        }
                        connection.Close();
                        return Korting_Product_WerfDOList;
                    }
                }
            }
        }

        public static BestellingDO krijgBestellingDoorID(int bestelID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from Bestelling where ID=@ID ;", connection))
                {
                    command.Parameters.AddWithValue("@ID", bestelID);
                   
                    connection.Open();
                    BestellingDO bestellingDO = new BestellingDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingDO.Giek = reader["Giek"].ToString();
                            bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                            bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                            bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingDO.Comment = reader["comment"].ToString();
                        }

                    }
                    connection.Close();
                    return bestellingDO;
                }
            }
        }

        public static List<Korting_WerfDO> KrijgAlleKortingenDoorWerfKlantID(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from korting_werf where klantID=@klantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_WerfDO> Korting_WerfDOList = new List<Korting_WerfDO>();

                        while (reader.Read())
                        {
                            Korting_WerfDO korting_WerfDO = new Korting_WerfDO();
                            {
                                korting_WerfDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_WerfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                korting_WerfDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                korting_WerfDO.Bedrag = Convert.ToDouble(reader["bedrag"]);


                                Korting_WerfDOList.Add(korting_WerfDO);
                            }

                        }
                        connection.Close();
                        return Korting_WerfDOList;
                    }
                }
            }
        }

        public static List<Korting_WerfDO> KrijgAlleKortingenDoorKlantID(int klantID)
        {
            throw new NotImplementedException();
        }

        public static List<Korting_ProductDO> KrijgAlleKortingenProductDoorKlantID(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from korting_product where klantID=@klantID;", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_ProductDO> Korting_ProductDOList = new List<Korting_ProductDO>();

                        while (reader.Read())
                        {
                            Korting_ProductDO korting_ProductDO = new Korting_ProductDO();
                            {
                                korting_ProductDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_ProductDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                korting_ProductDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                                korting_ProductDO.Bedrag = Convert.ToDouble(reader["bedrag"]);


                                Korting_ProductDOList.Add(korting_ProductDO);
                            }

                        }
                        connection.Close();
                        return Korting_ProductDOList;
                    }
                }
            }
        }

        public static List<FactuurDO> KrijgAlleFacturenDoorKlantID(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur where KlantID=@KlantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<FactuurDO> FactuurDOList = new List<FactuurDO>();

                        while (reader.Read())
                        {
                            FactuurDO factuurDO = new FactuurDO();
                            {
                                factuurDO.ID = Convert.ToInt32(reader["ID"]);
                                factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                                factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                                factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                                factuurDO.TotaalVerlegd = Convert.ToDouble(reader["Totaalverlegd"]);
                                factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                                factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                                factuurDO.Totaal = Convert.ToDouble(reader["totaal"]);


                                FactuurDOList.Add(factuurDO);
                            }

                        }
                        connection.Close();
                        return FactuurDOList;
                    }
                }
            }
        }

        public static Korting_KlantDO MaakNieuweKortingKlant(Korting_KlantDO korting_KlantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Korting_Klant (klantID,bedrag) values(@klantID,@Bedrag);",
                            connection))
                {
                    command.Parameters.AddWithValue("@klantID", korting_KlantDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Bedrag", korting_KlantDO.Bedrag);

                    korting_KlantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_KlantDO;
                }
            }
        }

     

        public static AgendaLeveringenDO krijgAgendaPuntDoorBestellingID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                 connection.Open();
                using (SqlCommand command = new SqlCommand("select * from AgendaLeveringen where bestelID=@bestelID;  ", connection))
                {
                    command.Parameters.AddWithValue("@bestelID", ID);
                

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        AgendaLeveringenDO agendaLeveringenDO = new AgendaLeveringenDO();
                        while ( reader.Read())
                        {
                           
                            agendaLeveringenDO.ID = Convert.ToInt32(reader["ID"]);
                            agendaLeveringenDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            agendaLeveringenDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            agendaLeveringenDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            agendaLeveringenDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            agendaLeveringenDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            agendaLeveringenDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            agendaLeveringenDO.Giek = reader["Giek"].ToString();
                            agendaLeveringenDO.M3 = Convert.ToDouble(reader["M3"]);
                            agendaLeveringenDO.Datum = Convert.ToDateTime(reader["datumTijd"]);
                            //     agendaLeveringenDO.HulpstofDO = GethulpstofByID(Convert.ToInt32(reader["hulpstofID"]));
                            agendaLeveringenDO.Levering = Convert.ToInt32(reader["levering"]);
                            agendaLeveringenDO.LeveringWijze = reader["leveringWijze"].ToString();
                            //     agendaLeveringenDO.HoeveelheidHulpstof = Convert.ToInt32(reader["hoeveelheidHulpstof"]);
                            agendaLeveringenDO.Loswijze = reader["loswijze"].ToString();
                            agendaLeveringenDO.Comment = reader["comment"].ToString();
                            agendaLeveringenDO.BestellingDO = GetBestellingByID(Convert.ToInt32(reader["bestelID"]));

                           
                        }

                        return agendaLeveringenDO;
                    }
                }
            }
        }

        public static OmschrijvingProductDO KrijgProductOmschrijvingviaFormule(string naam)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Product_Omschrijving where Formule=@Naam;  ", connection))
                {
                    command.Parameters.AddWithValue("@Naam", naam);
                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                     
                        OmschrijvingProductDO omschrijvingProductDO = new OmschrijvingProductDO(); ;
                        while (reader.Read())
                        {
                   
                            omschrijvingProductDO.ID = Convert.ToInt32(reader["ID"]);
           
                            omschrijvingProductDO.Omschrijving = reader["Omschrijving"].ToString();
                    
                            omschrijvingProductDO.Formule = reader["Formule"].ToString();
            
                        }
                        connection.Close();
                        return omschrijvingProductDO;
                    }
                }
            }
        }



        public static List<Hulpstof_Factuur_ItemDO> KrijgAlleHulpstofFactuurItemsDoorFactuurID(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from HulpstofFactuurItem where FactuurItemID=@FactuurItemID;  ", connection))
                {
                    command.Parameters.AddWithValue("@FactuurItemID", iD);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Hulpstof_Factuur_ItemDO> Factuur_ItemDOList = new List<Hulpstof_Factuur_ItemDO>();

                        while (reader.Read())
                        {
                            Hulpstof_Factuur_ItemDO Hulpstof_Factuur_ItemDO = new Hulpstof_Factuur_ItemDO();
                            {
                                Hulpstof_Factuur_ItemDO.ID = Convert.ToInt32(reader["ID"]);
                                Hulpstof_Factuur_ItemDO.Factuur_ItemDO = krijgFactuurItemDoorID(Convert.ToInt32(reader["FactuurItemID"]));
                                Hulpstof_Factuur_ItemDO.Hulpstof = reader["Hulpstof"].ToString();
                                Hulpstof_Factuur_ItemDO.EenheidsPrijsHulpstof = Convert.ToDouble(reader["EenheidsPrijsHulpstof"]);
                                Hulpstof_Factuur_ItemDO.TotaalPrijsHulpstof = Convert.ToDouble(reader["TotaalPrijsHulpstof"]);

                                Factuur_ItemDOList.Add(Hulpstof_Factuur_ItemDO);
                            }

                        }
                        connection.Close();
                        return Factuur_ItemDOList;
                    }
                }
            }
        }

      

        private static Factuur_ItemDO krijgFactuurItemDoorID(int ID)
        {
            Factuur_ItemDO factuur_ItemDO;
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur_Item where ID=@ID; ",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        factuur_ItemDO = new Factuur_ItemDO();
                        while (reader.Read())
                        {

                            {
                                factuur_ItemDO.ID = Convert.ToInt32(reader["ID"]);
                                factuur_ItemDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                factuur_ItemDO.FactuurDO = GetFactuurByID(Convert.ToInt32(reader["factuurID"]));
                                factuur_ItemDO.OmschrijvingProductDO = GetOmschrijvingByID(Convert.ToInt32(reader["omschrijvingProductID"]));
                                factuur_ItemDO.PompPrijsDO = GetPompPrijsByID(Convert.ToInt32(reader["pompSoortID"]));
                                factuur_ItemDO.BestelDatum = Convert.ToDateTime(reader["bestelDatum"]);
                                factuur_ItemDO.TransportTotaal = Convert.ToDouble(reader["transportTotaal"]);
                                factuur_ItemDO.PompSuplimentEenheidsPrijs = Convert.ToDouble(reader["pompSuplimentEenheidsPrijs"]);
                                factuur_ItemDO.PompTotaalSuplimentPrijs = Convert.ToDouble(reader["pompTotaalSuplimentPrijs"]);
                                factuur_ItemDO.PompWachtTijd = Convert.ToDouble(reader["pompWachtTijd"]);
                                factuur_ItemDO.GepompteM3 = Convert.ToDouble(reader["gepompteM3"]);
                                factuur_ItemDO.LaadEnLosTijdenTotaal = Convert.ToDouble(reader["laadEnLosTijdenTotaal"]);
                                factuur_ItemDO.Onvolledige_Lading_Hoeveelheid = Convert.ToDouble(reader["onvolledige_Lading_Hoeveelheid"]);
                                factuur_ItemDO.Onvolledige_Lading_Prijs = Convert.ToDouble(reader["onvolledige_Lading_Prijs"]);
                                factuur_ItemDO.ProductPrijs = Convert.ToDouble(reader["productPrijs"]);
                                factuur_ItemDO.EenheidsPrijs = Convert.ToDouble(reader["eenheidsPrijs"]);
                                factuur_ItemDO.HoeveelheidProduct = Convert.ToDouble(reader["hoeveelheidProduct"]);
                                factuur_ItemDO.Subtotaal = Convert.ToDouble(reader["subtotaal"]);

                            }

                        }
                    }
                    connection.Close();
                    return factuur_ItemDO;

                }
            }
        }

        public static Hulpstof_Factuur_ItemDO MaakNieuweHulpstofFactuurItem(Hulpstof_Factuur_ItemDO hulpstof_Factuur_ItemDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into HulpstofFactuurItem (FactuurItemID,Hulpstof,EenheidsPrijsHulpstof,TotaalPrijsHulpstof) values(@FactuurItemID,@Hulpstof,@EenheidsPrijsHulpstof,@TotaalPrijsHulpstof);",
                            connection))
                {
                    command.Parameters.AddWithValue("@FactuurItemID", hulpstof_Factuur_ItemDO.Factuur_ItemDO.ID);
                    command.Parameters.AddWithValue("@Hulpstof", hulpstof_Factuur_ItemDO.Hulpstof);
                    command.Parameters.AddWithValue("@EenheidsPrijsHulpstof", hulpstof_Factuur_ItemDO.EenheidsPrijsHulpstof);
                    command.Parameters.AddWithValue("@TotaalPrijsHulpstof", hulpstof_Factuur_ItemDO.TotaalPrijsHulpstof);

                    hulpstof_Factuur_ItemDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return hulpstof_Factuur_ItemDO;
                }
            }
        }

        public static List<KlantNotitieDO> SelecteerAlleNotities()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from KlantNotitie;", connection))
                {
           

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<KlantNotitieDO> KlantNotitieDOs = new List<KlantNotitieDO>();

                        while (reader.Read())
                        {
                            KlantNotitieDO klantNotitieDO = new KlantNotitieDO();
                            klantNotitieDO.ID = Convert.ToInt32(reader["ID"]);
                            klantNotitieDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            klantNotitieDO.Notitie = reader["Notitie"].ToString();


                            KlantNotitieDOs.Add(klantNotitieDO);
                        }
                        connection.Close();
                        return KlantNotitieDOs;
                    }
                }
            }
        }

        public static KlantNotitieDO MaakNieuweKlantNotitie(KlantNotitieDO klantNotitieDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into KlantNotitie (klantID,Notitie) values(@KlantID,@Notitie);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", klantNotitieDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Notitie", klantNotitieDO.Notitie);

                    klantNotitieDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return klantNotitieDO;
                }
            }
        }

        public static PrijsSettingDO KrijgPrijsSettingViaKlantID(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from PrijsSetting where KlantID=@KlantID;", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", iD);


                    PrijsSettingDO prijsSettingDO = new PrijsSettingDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            prijsSettingDO.ID = Convert.ToInt32(reader["ID"]);
                            prijsSettingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["KlantID"]));
                            prijsSettingDO.Soort = Convert.ToByte(reader["Soort"]);
                          
                        }

                    }
                    connection.Close();
                    return prijsSettingDO;
                }
            
            }
        }

        public static AccountDO UpdateWachtwoord(AccountDO accountDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update Account set wachtwoord=@wachtwoord where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", accountDO.ID);
                    command.Parameters.AddWithValue("@wachtwoord", accountDO.Wachtwoord);



                    accountDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return accountDO;
                }
            }
        }

        public static List<BestellingDO> SelecteerBestellingenVanKlant(int iD)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from bestelling where klantID=@klantID;", connection))
                {
                    command.Parameters.AddWithValue("@klantID", iD);
               

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BestellingDO> bestellingDOs = new List<BestellingDO>();

                        while (reader.Read())
                        {
                            BestellingDO bestellingDO = new BestellingDO();
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingDO.Giek = reader["Giek"].ToString();
                            bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                            bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                            bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingDO.Comment = reader["comment"].ToString();

                            bestellingDOs.Add(bestellingDO);
                        }
                        connection.Close();
                        return bestellingDOs;
                    }
                }
            }
        }

        public static Factuur_ItemDO krijgFactuurItemgDoorGegevens(Factuur_ItemDO factuur_ItemDO1)
        {
            Factuur_ItemDO factuur_ItemDO;
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur_Item where werfID=@werfID and factuurID=@factuurID and omschrijvingProductID=@omschrijvingProductID and bestelDatum=@bestelDatum and transportTotaal=@transportTotaal and pompSuplimentEenheidsPrijs=@pompSuplimentEenheidsPrijs and pompTotaalSuplimentPrijs=@pompTotaalSuplimentPrijs and pompWachtTijd=@pompWachtTijd and gepompteM3=@gepompteM3 and laadEnLosTijdenTotaal=@laadEnLosTijdenTotaal and onvolledige_Lading_Hoeveelheid=@onvolledige_Lading_Hoeveelheid and onvolledige_Lading_Prijs=@onvolledige_Lading_Prijs and productPrijs=@productPrijs  and eenheidsPrijs=@eenheidsPrijs  and hoeveelheidProduct=@hoeveelheidProduct and subtotaal=@subtotaal;",
                            connection))
                {
                    command.Parameters.AddWithValue("@werfID", factuur_ItemDO1.WerfDO.ID);
                    command.Parameters.AddWithValue("@factuurID", factuur_ItemDO1.FactuurDO.ID);
                    command.Parameters.AddWithValue("@omschrijvingProductID", factuur_ItemDO1.OmschrijvingProductDO.ID);
            
                    command.Parameters.AddWithValue("@bestelDatum", factuur_ItemDO1.BestelDatum);
                    command.Parameters.AddWithValue("@transportTotaal", factuur_ItemDO1.TransportTotaal);
                    command.Parameters.AddWithValue("@pompSuplimentEenheidsPrijs", factuur_ItemDO1.PompSuplimentEenheidsPrijs);
                    command.Parameters.AddWithValue("@pompTotaalSuplimentPrijs", factuur_ItemDO1.PompTotaalSuplimentPrijs);
                    command.Parameters.AddWithValue("@pompWachtTijd", factuur_ItemDO1.PompWachtTijd);
                    command.Parameters.AddWithValue("@gepompteM3", factuur_ItemDO1.GepompteM3);
                    command.Parameters.AddWithValue("@laadEnLosTijdenTotaal", factuur_ItemDO1.LaadEnLosTijdenTotaal);
                    command.Parameters.AddWithValue("@onvolledige_Lading_Hoeveelheid", factuur_ItemDO1.Onvolledige_Lading_Hoeveelheid);
                    command.Parameters.AddWithValue("@onvolledige_Lading_Prijs", factuur_ItemDO1.Onvolledige_Lading_Prijs);
                    command.Parameters.AddWithValue("@productPrijs", factuur_ItemDO1.ProductPrijs);
                    command.Parameters.AddWithValue("@eenheidsPrijs", factuur_ItemDO1.EenheidsPrijs);
                    command.Parameters.AddWithValue("@hoeveelheidProduct", factuur_ItemDO1.HoeveelheidProduct);
                    command.Parameters.AddWithValue("@subtotaal", factuur_ItemDO1.Subtotaal);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        factuur_ItemDO = new Factuur_ItemDO();
                        while (reader.Read())
                        {
                           
                            {
                                factuur_ItemDO.ID = Convert.ToInt32(reader["ID"]);
                                factuur_ItemDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                factuur_ItemDO.FactuurDO = GetFactuurByID(Convert.ToInt32(reader["factuurID"]));
                                factuur_ItemDO.OmschrijvingProductDO = GetOmschrijvingByID(Convert.ToInt32(reader["omschrijvingProductID"]));
                                factuur_ItemDO.PompPrijsDO = GetPompPrijsByID(Convert.ToInt32(reader["pompSoortID"]));
                                factuur_ItemDO.BestelDatum = Convert.ToDateTime(reader["bestelDatum"]);
                                factuur_ItemDO.TransportTotaal = Convert.ToDouble(reader["transportTotaal"]);
                                factuur_ItemDO.PompSuplimentEenheidsPrijs = Convert.ToDouble(reader["pompSuplimentEenheidsPrijs"]);
                                factuur_ItemDO.PompTotaalSuplimentPrijs = Convert.ToDouble(reader["pompTotaalSuplimentPrijs"]);
                                factuur_ItemDO.PompWachtTijd = Convert.ToDouble(reader["pompWachtTijd"]);
                                factuur_ItemDO.GepompteM3 = Convert.ToDouble(reader["gepompteM3"]);
                                factuur_ItemDO.LaadEnLosTijdenTotaal = Convert.ToDouble(reader["laadEnLosTijdenTotaal"]);
                                factuur_ItemDO.Onvolledige_Lading_Hoeveelheid = Convert.ToDouble(reader["onvolledige_Lading_Hoeveelheid"]);
                                factuur_ItemDO.Onvolledige_Lading_Prijs = Convert.ToDouble(reader["onvolledige_Lading_Prijs"]);
                                factuur_ItemDO.ProductPrijs = Convert.ToDouble(reader["productPrijs"]);
                                factuur_ItemDO.EenheidsPrijs = Convert.ToDouble(reader["eenheidsPrijs"]);
                                factuur_ItemDO.HoeveelheidProduct = Convert.ToDouble(reader["hoeveelheidProduct"]);
                                factuur_ItemDO.Subtotaal = Convert.ToDouble(reader["subtotaal"]);
                                
                            }

                        }
                    }
                    connection.Close();
                    return factuur_ItemDO;
           
                }
            }
        }

        public static BestellingWebsiteDO VerwijderBestellingWebsite(BestellingWebsiteDO bestellingWebsiteDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from BestellingWebsite where ID=@ID",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", bestellingWebsiteDO.ID);

                    bestellingWebsiteDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bestellingWebsiteDO;
                }
            }
        }

        public static List<BestellingWebsiteDO> krijgAlleWebsiteBestellingen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from BestellingWebsite;", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BestellingWebsiteDO> BestellingWebsiteDOs = new List<BestellingWebsiteDO>();

                        while (reader.Read())
                        {
                            BestellingWebsiteDO bestellingWebsiteDO = new BestellingWebsiteDO();
                            bestellingWebsiteDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingWebsiteDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingWebsiteDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingWebsiteDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingWebsiteDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingWebsiteDO.Giek = reader["Giek"].ToString();
                            bestellingWebsiteDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingWebsiteDO.Datum = Convert.ToDateTime(reader["datum"]);          
                            bestellingWebsiteDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingWebsiteDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingWebsiteDO.Comment = reader["comment"].ToString();

                            BestellingWebsiteDOs.Add(bestellingWebsiteDO);
                        }
                        connection.Close();
                        return BestellingWebsiteDOs;
                    }
                }
            }
        }

     

        public static List<WerfDO> KrijgAlleWerven()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from werf;  ", connection))
                {
            

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<WerfDO> werfDOs = new List<WerfDO>();

                        while (reader.Read())
                        {
                            WerfDO werfDO = new WerfDO();
                            {
                                werfDO.ID = Convert.ToInt32(reader["ID"]);
                                werfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                werfDO.Adres = reader["adres"].ToString();
                                werfDO.Gemeente = reader["gemeente"].ToString();
                                werfDO.Postcode = reader["postcode"].ToString();
                                werfDO.Telefoon = reader["telefoon"].ToString();

                                werfDOs.Add(werfDO);
                            }

                        }
                        connection.Close();
                        return werfDOs;
                    }
                }
            }
        }

        public static List<FactuurDO> KrijgAlleFacturenDoorKlantIDEnDatum(int klantID, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur where KlantID=@KlantID and datum=@datum;  ", connection))
                {
                    command.Parameters.AddWithValue("@KlantID", klantID);
                    command.Parameters.AddWithValue("@datum", date);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<FactuurDO> FactuurDOList = new List<FactuurDO>();

                        while (reader.Read())
                        {
                            FactuurDO factuurDO = new FactuurDO();
                            {
                                factuurDO.ID = Convert.ToInt32(reader["ID"]);
                                factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                                factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                                factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                                factuurDO.TotaalVerlegd = Convert.ToDouble(reader["Totaalverlegd"]);
                                factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                                factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                                factuurDO.Totaal = Convert.ToDouble(reader["totaal"]);


                                FactuurDOList.Add(factuurDO);
                            }

                        }
                        connection.Close();
                        return FactuurDOList;
                    }
                }
            }
        }

        public static List<FactuurDO> KrijgAlleFacturenDoorDatum(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur where datum=@datum;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum", date);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<FactuurDO> FactuurDOList = new List<FactuurDO>();

                        while (reader.Read())
                        {
                            FactuurDO factuurDO = new FactuurDO();
                            {
                                factuurDO.ID = Convert.ToInt32(reader["ID"]);
                                factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                                factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                                factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                                factuurDO.TotaalVerlegd = Convert.ToDouble(reader["Totaalverlegd"]);
                                factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                                factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                                factuurDO.Totaal = Convert.ToDouble(reader["totaal"]);
                                factuurDO.Controle = Convert.ToByte(reader["controle"]);

                                FactuurDOList.Add(factuurDO);
                            }

                        }
                        connection.Close();
                        return FactuurDOList;
                    }
                }
            }
        }

        public static AccountUpdateDO VerwijderAccountUpdate(AccountUpdateDO accountUpdateDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from AccountUpdate where ID=@ID",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", accountUpdateDO.ID);

                    accountUpdateDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return accountUpdateDO;
                }
            }
        }

        public static List<AccountUpdateDO> selecteerAlleAccountUpdates()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from AccountUpdate;", connection))
                {
      


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<AccountUpdateDO> accountUpdateDOs = new List<AccountUpdateDO>();

                        while (reader.Read())
                        {
                            AccountUpdateDO accountUpdateDO = new AccountUpdateDO();
                            accountUpdateDO.ID = Convert.ToInt32(reader["ID"]);
                            accountUpdateDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            accountUpdateDO.Naam = reader["Naam"].ToString();
                            accountUpdateDO.Adres = reader["Adres"].ToString();
                            accountUpdateDO.Gemeente = reader["Gemeente"].ToString();
                            accountUpdateDO.Postcode = reader["Postcode"].ToString();
                            accountUpdateDO.Email = reader["Email"].ToString();
                            accountUpdateDO.Gsm = reader["GSM"].ToString();
                            accountUpdateDOs.Add(accountUpdateDO);
                        }
                        connection.Close();
                        return accountUpdateDOs;
                    }
                }
            }
        }

        public static AccountUpdateDO MaakNieuweAccountWijzigen(AccountUpdateDO accountUpdateDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into AccountUpdate (klantID,Naam,Adres,Gemeente,Postcode,Email,GSM) values(@KlantID,@Naam,@Adres,@Gemeente,@Postcode,@Email,@GSM);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", accountUpdateDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Naam", accountUpdateDO.Naam);
                    command.Parameters.AddWithValue("@Adres", accountUpdateDO.Adres);
                    command.Parameters.AddWithValue("@Gemeente", accountUpdateDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", accountUpdateDO.Postcode);
                    command.Parameters.AddWithValue("@Email", accountUpdateDO.Email);
                    command.Parameters.AddWithValue("@GSM", accountUpdateDO.Gsm);
                    accountUpdateDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return accountUpdateDO;
                }
            }
        }

        public static List<AccountDO> KrijgAlleAccounts()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from account;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<AccountDO> accountDOs = new List<AccountDO>();

                    while (reader.Read())
                    {
                        AccountDO accountDO = new AccountDO();
                        {
                            accountDO.ID = Convert.ToInt32(reader["ID"]);
                            accountDO.KlantNummer = Convert.ToInt32(reader["KlantNummer"]);
                            accountDO.Wachtwoord = reader["wachtwoord"].ToString();
                            accountDO.Email = reader["email"].ToString();
                            accountDO.Userlevel = Convert.ToByte(reader["userlevel"]);
                            accountDOs.Add(accountDO);
                        }

                    }
                    connection.Close();
                    return accountDOs;
                }
            }
        }

        public static List<PompPrijsDO> KrijgAllePompPrijzen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from pompPrijs;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PompPrijsDO> PompDOs = new List<PompPrijsDO>();

                    while (reader.Read())
                    {
                        PompPrijsDO pompPrijsDO = new PompPrijsDO();
                        {
                            pompPrijsDO.ID = Convert.ToInt32(reader["ID"]);
                            pompPrijsDO.Giek = reader["giek"].ToString();
                            pompPrijsDO.Bedrag = Convert.ToDouble(reader["bedrag"]);
                            pompPrijsDO.Suppliment = Convert.ToDouble(reader["suppliment"]);
                            PompDOs.Add(pompPrijsDO);
                        }

                    }
                    connection.Close();
                    return PompDOs;
                }
            }
        }

        public static List<PersoneelDO> KrijgAllePersoneelLeden()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from PersoneelLijst;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PersoneelDO> PersoneelDOs = new List<PersoneelDO>();

                    while (reader.Read())
                    {
                        PersoneelDO personeelDO = new PersoneelDO();
                        {
                            personeelDO.ID = Convert.ToInt32(reader["ID"]);
                            personeelDO.Naam = reader["Naam"].ToString();
                            personeelDO.Gsm = reader["GSM"].ToString();
                            personeelDO.Email = reader["Email"].ToString();
                            PersoneelDOs.Add(personeelDO);
                        }

                    }
                    connection.Close();
                    return PersoneelDOs;
                }
            }
        }

        public static AccountDO KrijgAccountDoorKlantNummerEnWachtwoord(int klantnummer, string wachtwoord)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select ID, KlantNummer, wachtwoord , Email, Userlevel from Account where KlantNummer=@KlantNummer and wachtwoord=@wachtwoord",
                           connection))
                {
                    command.Parameters.AddWithValue("@klantNummer", klantnummer);
                    command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        AccountDO accountDO = new AccountDO();
                        while (reader.Read())
                        {
                            accountDO = new AccountDO(
                                Convert.ToInt32(reader["ID"]),
                                Convert.ToInt32(reader["klantNummer"]),
                                reader["wachtwoord"].ToString(),
                                reader["Email"].ToString(),
                                Convert.ToByte(reader["Userlevel"]));
                        }
                        return accountDO;
                    }
                }
            }
        }

        public static AccountDO MaakNieuweAccount(AccountDO accountDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Account (KlantNummer,wachtwoord,email,userlevel) values(@KlantNummer,@wachtwoord,@email,@userlevel);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantNummer", accountDO.KlantNummer);
                    command.Parameters.AddWithValue("@wachtwoord", accountDO.Wachtwoord);
                    command.Parameters.AddWithValue("@email", accountDO.Email);
                    command.Parameters.AddWithValue("@userlevel", accountDO.Userlevel);
                    accountDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return accountDO;
                }
            }
        }

        public static List<HulpstofPrijsDO> KrijgAllePrijzenHulpstoffen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from HulpstofPrijs;", connection))
                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<HulpstofPrijsDO> HulpstofPrijsDOs = new List<HulpstofPrijsDO>();

                        while (reader.Read())
                        {
                            HulpstofPrijsDO hulpstofPrijsDO = new HulpstofPrijsDO();
                            {

                                hulpstofPrijsDO.ID = Convert.ToInt32(reader["ID"]);
                                hulpstofPrijsDO.Naam = reader["Naam"].ToString();
                                hulpstofPrijsDO.Bedrag = Convert.ToInt32(reader["Bedrag"]);

                                HulpstofPrijsDOs.Add(hulpstofPrijsDO);
                            }

                        }
                        connection.Close();
                        return HulpstofPrijsDOs;
                    }
                }
            }
        }

        public static OmschrijvingProductDO MaakNieuweProductOmschrijving(OmschrijvingProductDO omschrijvingProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Product_Omschrijving (Formule,Omschrijving) values(@Formule,@Omschrijving);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Formule", omschrijvingProductDO.Formule);
                    command.Parameters.AddWithValue("@Omschrijving", omschrijvingProductDO.Omschrijving);
                  
                    omschrijvingProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return omschrijvingProductDO;
                }
            }
        }

        public static SaldoDO MaakNieuweSaldo(SaldoDO saldoDO)
        {
            throw new NotImplementedException();
        }

        public static List<SoortenHulpstofDO> KrijgAlleSoortenHulpstoffen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Soorten_Hulpstof;", connection))
                {

                   
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<SoortenHulpstofDO> SoortenhulpstofDOs = new List<SoortenHulpstofDO>();

                        while (reader.Read())
                        {
                            SoortenHulpstofDO soortenHulpstofDO = new SoortenHulpstofDO();
                            {

                                soortenHulpstofDO.ID = Convert.ToInt32(reader["ID"]);
                                soortenHulpstofDO.Naam = reader["Naam"].ToString();


                                SoortenhulpstofDOs.Add(soortenHulpstofDO);
                            }

                        }
                        connection.Close();
                        return SoortenhulpstofDOs;
                    }
                }
            }
        }

        public static FactuurDO VerwijderFactuur(FactuurDO factuurDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from Factuur where ID=@ID",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", factuurDO.ID);

                    factuurDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return factuurDO;
                }
            }
        }

        public static KlantDO krijgKlantDoorKlantNummer(int klantNummer)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                using (SqlCommand command = new SqlCommand("select * from klant where nummer=@klantNummer;", connection))
            {
                command.Parameters.AddWithValue("@klantNummer", klantNummer);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    KlantDO klantDO = new KlantDO();
                    while (reader.Read())
                    {

                        {
                            klantDO.ID = Convert.ToInt32(reader["ID"]);
                            klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                            klantDO.Naam = reader["naam"].ToString();

                            string adres = reader["adres"].ToString();
                            string gemeente = reader["gemeente"].ToString();
                            string postcode = reader["postcode"].ToString();
                            string gsm = reader["gsm"].ToString();
                            string telefoon = reader["telefoon"].ToString();
                            string email = reader["email"].ToString();
                            string fax = reader["fax"].ToString();
                            string btw = reader["btw"].ToString();
                            string buitenlandsebtw = reader["buitenlandseBTW"].ToString();
                           klantDO.BetaalCode = reader["betaalCode"].ToString();
                                if (adres != null)
                            {
                                klantDO.Adres = adres;
                            }
                            else
                            {
                                klantDO.Adres = "";
                            }
                            if (gemeente != null)
                            {
                                klantDO.Gemeente = gemeente;
                            }
                            else
                            {
                                klantDO.Gemeente = "";
                            }
                            if (postcode != null)
                            {
                                klantDO.Postcode = postcode;
                            }
                            else
                            {
                                klantDO.Postcode = "";
                            }
                            if (gsm != null)
                            {
                                klantDO.Gsm = gsm;
                            }
                            else
                            {
                                klantDO.Gsm = "";
                            }
                            if (telefoon != null)
                            {
                                klantDO.Telefoon = telefoon;
                            }
                            else
                            {
                                klantDO.Telefoon = "";
                            }
                            if (email != null)
                            {
                                klantDO.Email = email;
                            }
                            else
                            {
                                klantDO.Email = "";
                            }
                            if (fax != null)
                            {
                                klantDO.Fax = fax;
                            }
                            else
                            {
                                klantDO.Fax = "";
                            }
                            if (btw != null)
                            {
                                klantDO.Btw = btw;
                            }
                            else
                            {
                                klantDO.Btw = "";
                            }
                            if (buitenlandsebtw != null)
                            {
                                klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                            }
                            else
                            {
                                klantDO.BuitenlandseBtw = "";
                            }

                        }

                    }
                    connection.Close();
                    return klantDO;
                }
            }
        }
    }

        public static KlantDO VerwijderKlant(KlantDO klantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from klant where ID=@ID",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", klantDO.ID);

                    klantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return klantDO;
                }
            }
        }

        public static List<Factuur_ItemDO> KrijgAlleFactuurItemsDoorFactuurID(int factuurID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from factuur_Item where factuurID=@factuurID;  ", connection))
                {
                    command.Parameters.AddWithValue("@factuurID", factuurID);
                 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Factuur_ItemDO> Factuur_ItemDOList = new List<Factuur_ItemDO>();

                        while (reader.Read())
                        {
                            Factuur_ItemDO factuur_ItemDO = new Factuur_ItemDO();
                            {
                                factuur_ItemDO.ID = Convert.ToInt32(reader["ID"]);
                                factuur_ItemDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                factuur_ItemDO.FactuurDO = GetFactuurByID(factuurID);
                                factuur_ItemDO.OmschrijvingProductDO = GetOmschrijvingByID(Convert.ToInt32(reader["omschrijvingProductID"]));
                                factuur_ItemDO.PompPrijsDO = GetPompPrijsByID(Convert.ToInt32(reader["pompSoortID"]));
                                factuur_ItemDO.BestelDatum = Convert.ToDateTime(reader["bestelDatum"]);
                                factuur_ItemDO.TransportTotaal = Convert.ToDouble(reader["transportTotaal"]);
                                factuur_ItemDO.PompSuplimentEenheidsPrijs = Convert.ToDouble(reader["pompSuplimentEenheidsPrijs"]);
                                factuur_ItemDO.PompTotaalSuplimentPrijs = Convert.ToDouble(reader["pompTotaalSuplimentPrijs"]);
                                factuur_ItemDO.PompWachtTijd = Convert.ToDouble(reader["pompWachtTijd"]);
                                factuur_ItemDO.GepompteM3 = Convert.ToDouble(reader["gepompteM3"]);
                                factuur_ItemDO.LaadEnLosTijdenTotaal = Convert.ToDouble(reader["laadEnLosTijdenTotaal"]);
                                factuur_ItemDO.Onvolledige_Lading_Hoeveelheid = Convert.ToDouble(reader["onvolledige_Lading_Hoeveelheid"]);
                                factuur_ItemDO.Onvolledige_Lading_Prijs = Convert.ToDouble(reader["onvolledige_Lading_Prijs"]);
                                factuur_ItemDO.ProductPrijs = Convert.ToDouble(reader["productPrijs"]);
                                factuur_ItemDO.EenheidsPrijs = Convert.ToDouble(reader["eenheidsPrijs"]);
                                factuur_ItemDO.HoeveelheidProduct = Convert.ToDouble(reader["hoeveelheidProduct"]);
                                factuur_ItemDO.Subtotaal = Convert.ToDouble(reader["subtotaal"]);
                                Factuur_ItemDOList.Add(factuur_ItemDO);
                            }

                        }
                        connection.Close();
                        return Factuur_ItemDOList;
                    }
                }
            }
        }

        private static PompPrijsDO GetPompPrijsByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from pompPrijs where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        PompPrijsDO pompPrijsDO = new PompPrijsDO();
                        while (reader.Read())
                        {
                            {
                                pompPrijsDO.ID = Convert.ToInt32(reader["ID"]);
                                pompPrijsDO.Giek = reader["Giek"].ToString();
                                pompPrijsDO.Bedrag = Convert.ToDouble(reader["Bedrag"]);

                            }
                        }
                        connection.Close();
                        return pompPrijsDO;
                    }
                }
            }
        }

        private static OmschrijvingProductDO GetOmschrijvingByID(int ID)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                OmschrijvingProductDO omschrijvingProductDO = new OmschrijvingProductDO();
                using (SqlCommand command = new SqlCommand("select * from Product_Omschrijving where ID=@ID;", connection1))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            {
                                omschrijvingProductDO.ID = Convert.ToInt32(reader["ID"]);
                                omschrijvingProductDO.Formule = reader["Formule"].ToString();
                                omschrijvingProductDO.Omschrijving = reader["Omschrijving"].ToString();
                            }

                        }
                        connection1.Close();
                        return omschrijvingProductDO;
                    }
                }
            }
        }
        private static FactuurDO GetFactuurByID(int factuurID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from factuur where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", factuurID);

                    connection.Open();
                    FactuurDO factuurDO = new FactuurDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            factuurDO.ID = Convert.ToInt32(reader["ID"]);
                            factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                            factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                            factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["Totaalverlegd"]);
                           factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaal"]);
                        }

                    }
                    connection.Close();
                    return factuurDO;
                }
            }
        }

        public static Factuur_ItemDO MaakNieuweFactuurItem(Factuur_ItemDO factuur_ItemDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into factuur_Item (werfID,factuurID,omschrijvingProductID,pompSoortID,bestelDatum,transportTotaal,pompSuplimentEenheidsPrijs,pompTotaalSuplimentPrijs,pompWachtTijd,gepompteM3,laadEnLosTijdenTotaal,onvolledige_Lading_Hoeveelheid,onvolledige_Lading_Prijs,productPrijs,eenheidsPrijs,hoeveelheidProduct,subtotaal) values(@werfID,@factuurID,@omschrijvingProductID,@pompSoortID,@bestelDatum,@transportTotaal,@pompSuplimentEenheidsPrijs,@pompTotaalSuplimentPrijs,@pompWachtTijd,@gepompteM3,@laadEnLosTijdenTotaal,@onvolledige_Lading_Hoeveelheid,@onvolledige_Lading_Prijs,@productPrijs,@eenheidsPrijs,@hoeveelheidProduct,@subtotaal);",
                            connection))
                {
                    command.Parameters.AddWithValue("@werfID", factuur_ItemDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@factuurID", factuur_ItemDO.FactuurDO.ID);
                    command.Parameters.AddWithValue("@omschrijvingProductID", factuur_ItemDO.OmschrijvingProductDO.ID);
                    command.Parameters.AddWithValue("@pompSoortID", factuur_ItemDO.PompPrijsDO.ID);
                    command.Parameters.AddWithValue("@bestelDatum", factuur_ItemDO.BestelDatum);
                    command.Parameters.AddWithValue("@transportTotaal", factuur_ItemDO.TransportTotaal);
                    command.Parameters.AddWithValue("@pompSuplimentEenheidsPrijs", factuur_ItemDO.PompSuplimentEenheidsPrijs);
                    command.Parameters.AddWithValue("@pompTotaalSuplimentPrijs", factuur_ItemDO.PompTotaalSuplimentPrijs);
                    command.Parameters.AddWithValue("@pompWachtTijd", factuur_ItemDO.PompWachtTijd);
                    command.Parameters.AddWithValue("@gepompteM3", factuur_ItemDO.GepompteM3);
                    command.Parameters.AddWithValue("@laadEnLosTijdenTotaal", factuur_ItemDO.LaadEnLosTijdenTotaal);
                    command.Parameters.AddWithValue("@onvolledige_Lading_Hoeveelheid", factuur_ItemDO.Onvolledige_Lading_Hoeveelheid);
                    command.Parameters.AddWithValue("@onvolledige_Lading_Prijs", factuur_ItemDO.Onvolledige_Lading_Prijs);
                    command.Parameters.AddWithValue("@productPrijs", factuur_ItemDO.ProductPrijs);
                    command.Parameters.AddWithValue("@eenheidsPrijs", factuur_ItemDO.EenheidsPrijs);
                    command.Parameters.AddWithValue("@hoeveelheidProduct", factuur_ItemDO.HoeveelheidProduct);
                    command.Parameters.AddWithValue("@subtotaal", factuur_ItemDO.Subtotaal);

                    factuur_ItemDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return factuur_ItemDO;
                }
            }
        }

        public static NormaleLeveringBonDO KrijgLeveringbonDoorID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {
                using (SqlCommand command = new SqlCommand("select * from NormaleLeveringBons where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    connection.Open();
                    NormaleLeveringBonDO normaleLeveringbonDO = new NormaleLeveringBonDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            normaleLeveringbonDO.ID = Convert.ToInt32(reader["ID"]);
                            normaleLeveringbonDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            normaleLeveringbonDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            normaleLeveringbonDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            normaleLeveringbonDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            normaleLeveringbonDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            normaleLeveringbonDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            normaleLeveringbonDO.Giek = reader["giek"].ToString();
                            normaleLeveringbonDO.M3 = Convert.ToDouble(reader["m3"]);
                            normaleLeveringbonDO.Datum = Convert.ToDateTime(reader["datum"]);
                            normaleLeveringbonDO.Levering = Convert.ToInt32(reader["levering"]);
                            normaleLeveringbonDO.Leveringwijze = reader["leveringwijze"].ToString();
                            normaleLeveringbonDO.Leveringwijze = reader["loswijze"].ToString();
                            normaleLeveringbonDO.Leveringwijze = reader["opmerking"].ToString();
                        }

                    }
                    connection.Close();
                    return normaleLeveringbonDO;
                }
            }
        }
        public static List<HulpstofDO> KrijgAlleHulpstoffenVoorlevering(int leveringID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from hulpstof where leveringbonID=@leveringbonID ;", connection))
                {

                    command.Parameters.AddWithValue("@leveringbonID", leveringID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<HulpstofDO> hulpstofDOs = new List<HulpstofDO>();

                        while (reader.Read())
                        {
                            HulpstofDO hulpstofDO = new HulpstofDO();
                            {

                                hulpstofDO.ID = Convert.ToInt32(reader["ID"]);
                                hulpstofDO.Naam = reader["Naam"].ToString();
                                hulpstofDO.Hoeveelheid = reader["hoeveelheid"].ToString();
                                hulpstofDO.NormaleLeveringBonDO = KrijgLeveringbonDoorID(Convert.ToInt32(reader["leveringbonID"]));
                                hulpstofDOs.Add(hulpstofDO);
                            }

                        }
                        connection.Close();
                        return hulpstofDOs;
                    }
                }
            }
        }

        public static List<Korting_Product_WerfDO> KrijgAlleKortingenDoorProductIDenWerfID(int productID, int werfID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from korting_Product_Werf where werfID=@werfID and productID=@productID;  ", connection))
                {
                    command.Parameters.AddWithValue("@productID", productID);
                    command.Parameters.AddWithValue("@werfID", werfID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_Product_WerfDO> Korting_Product_WerfDOList = new List<Korting_Product_WerfDO>();

                        while (reader.Read())
                        {
                            Korting_Product_WerfDO korting_Product_WerfDO = new Korting_Product_WerfDO();
                            {
                                korting_Product_WerfDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_Product_WerfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                korting_Product_WerfDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                korting_Product_WerfDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                                korting_Product_WerfDO.Bedrag = Convert.ToDouble(reader["bedrag"]);

                                Korting_Product_WerfDOList.Add(korting_Product_WerfDO);
                            }

                        }
                        connection.Close();
                        return Korting_Product_WerfDOList;
                    }
                }
            }
        }

        public static List<Korting_ProductDO> KrijgAlleKortingenDoorProductID(int klantID,int productID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from korting_product where klantID=@klantID and productID=@productID;  ", connection))
                {
                    command.Parameters.AddWithValue("@productID", productID);
                    command.Parameters.AddWithValue("@klantID", klantID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_ProductDO> Korting_ProductDOList = new List<Korting_ProductDO>();

                        while (reader.Read())
                        {
                            Korting_ProductDO korting_ProductDO = new Korting_ProductDO();
                            {
                                korting_ProductDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_ProductDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                korting_ProductDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                                korting_ProductDO.Bedrag = Convert.ToDouble(reader["bedrag"]);


                                Korting_ProductDOList.Add(korting_ProductDO);
                            }

                        }
                        connection.Close();
                        return Korting_ProductDOList;
                    }
                }
            }
        }

        public static List<BestellingDO> SelecteerBestellingenVoorEenDatumEnPomp(DateTime datum1, int pompID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from bestelling where pompID=@pompID and datum between @datum1 and @datum2;", connection))
                {
                    command.Parameters.AddWithValue("@pompID", pompID);
                    DateTime datum2;
                    command.Parameters.AddWithValue("@datum1", datum1);
                    datum2 = datum1.AddDays(1);
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BestellingDO> bestellingDOs = new List<BestellingDO>();

                        while (reader.Read())
                        {
                            BestellingDO bestellingDO = new BestellingDO();
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingDO.Giek = reader["Giek"].ToString();
                            bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                            bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                            bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingDO.Comment = reader["comment"].ToString();

                            bestellingDOs.Add(bestellingDO);
                        }
                        connection.Close();
                        return bestellingDOs;
                    }
                }
            }
        }

        public static List<AgendaLeveringenDO> SelecteerAgendaPuntenTussenTweeDatums(DateTime datum1, DateTime datum2)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from AgendaLeveringen where datumTijd between @datum1 and @datum2;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<AgendaLeveringenDO> agendaLeveringenDOs = new List<AgendaLeveringenDO>();
                        AgendaLeveringenDO agendaLeveringenDO;
                        while (reader.Read())
                        {
                            agendaLeveringenDO = new AgendaLeveringenDO();
                            agendaLeveringenDO.ID = Convert.ToInt32(reader["ID"]);
                            agendaLeveringenDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            agendaLeveringenDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            agendaLeveringenDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            agendaLeveringenDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            agendaLeveringenDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            agendaLeveringenDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            agendaLeveringenDO.Giek = reader["Giek"].ToString();
                            agendaLeveringenDO.M3 = Convert.ToDouble(reader["M3"]);
                            agendaLeveringenDO.Datum = Convert.ToDateTime(reader["datumTijd"]);

                            //     agendaLeveringenDO.HulpstofDO = GethulpstofByID(Convert.ToInt32(reader["hulpstofID"]));
                            agendaLeveringenDO.Levering = Convert.ToInt32(reader["levering"]);
                            agendaLeveringenDO.LeveringWijze = reader["leveringWijze"].ToString();
                            //     agendaLeveringenDO.HoeveelheidHulpstof = Convert.ToInt32(reader["hoeveelheidHulpstof"]);
                            agendaLeveringenDO.Loswijze = reader["loswijze"].ToString();
                            agendaLeveringenDO.Comment = reader["comment"].ToString();
                            agendaLeveringenDO.BestellingDO = GetBestellingByID(Convert.ToInt32(reader["bestelID"]));

                            agendaLeveringenDOs.Add(agendaLeveringenDO);
                        }
                        connection.Close();
                        return agendaLeveringenDOs;
                    }
                }
            }
        }

        public static List<Korting_WerfDO> KrijgAlleKortingenDoorWerfID(int werfID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from korting_werf where werfID=@werfID;  ", connection))
                {
                    command.Parameters.AddWithValue("@werfID", werfID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Korting_WerfDO> Korting_WerfDOList = new List<Korting_WerfDO>();

                        while (reader.Read())
                        {
                            Korting_WerfDO korting_WerfDO = new Korting_WerfDO();
                            {
                                korting_WerfDO.ID = Convert.ToInt32(reader["ID"]);
                                korting_WerfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                korting_WerfDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                korting_WerfDO.Bedrag = Convert.ToDouble(reader["bedrag"]);


                                Korting_WerfDOList.Add(korting_WerfDO);
                            }

                        }
                        connection.Close();
                        return Korting_WerfDOList;
                    }
                }
            }
        }

        public static FactuurDO krijgFactuurDoorFactuurNummer(string factuurNummer)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from factuur where factuurnummer=@factuurnummer;", connection))
                {
                    command.Parameters.AddWithValue("@factuurnummer", factuurNummer);

                    connection.Open();
                    FactuurDO factuurDO= new FactuurDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            factuurDO.ID = Convert.ToInt32(reader["ID"]);
                            factuurDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            factuurDO.FactuurNummer = reader["factuurnummer"].ToString();
                            factuurDO.Datum = Convert.ToDateTime(reader["datum"]);
                            factuurDO.TotaalExclBtw = Convert.ToDouble(reader["totaalExclBtw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["Totaalverlegd"]);
                            factuurDO.TotaalIncl6Btw = Convert.ToDouble(reader["totaalIncl6Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaalIncl21Btw"]);
                            factuurDO.TotaalIncl21Btw = Convert.ToDouble(reader["totaal"]);
                        }

                    }
                    connection.Close();
                    return factuurDO;
                }
            }
        }

        public static FactuurDO MaakNieuweFactuur(FactuurDO factuurDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into factuur (klantID,factuurnummer,datum,totaalExclBtw,totaalVerlegd,totaalIncl6Btw,totaalIncl21Btw,totaal) values(@KlantID,@factuurnummer,@datum,@totaalExclBtw,@totaalVerlegd,@totaalIncl6Btw,@totaalIncl21Btw,@totaal);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", factuurDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@factuurnummer", factuurDO.FactuurNummer);
                    command.Parameters.AddWithValue("@datum", factuurDO.Datum);
                    command.Parameters.AddWithValue("@totaalExclBtw", factuurDO.TotaalExclBtw);
                    command.Parameters.AddWithValue("@totaalVerlegd", factuurDO.TotaalVerlegd);
                    command.Parameters.AddWithValue("@totaalIncl6Btw", factuurDO.TotaalIncl6Btw);
                    command.Parameters.AddWithValue("@totaalIncl21Btw", factuurDO.TotaalIncl21Btw);
                    command.Parameters.AddWithValue("@totaal", factuurDO.Totaal);
                    command.Parameters.AddWithValue("@controle", 2);
                    factuurDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return factuurDO;
                }
            }
        }

        public static List<NormaleLeveringBonDO> SelecteerLeveringenKlantWervenTussenTweeDatums(int klantID, int werfID, DateTime datum1, DateTime datum2)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from NormaleLeveringBons where klantID=@klantID and werfID=@werfID and datum between @datum1 and @datum2 ;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@klantID", klantID);
                    command.Parameters.AddWithValue("@werfID", werfID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<NormaleLeveringBonDO> NormaleLeveringBonDOs = new List<NormaleLeveringBonDO>();
                        NormaleLeveringBonDO normaleLeveringBonDO;
                        while (reader.Read())
                        {
                            normaleLeveringBonDO = new NormaleLeveringBonDO();
                            normaleLeveringBonDO.ID = Convert.ToInt32(reader["ID"]);
                            normaleLeveringBonDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            normaleLeveringBonDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            normaleLeveringBonDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            normaleLeveringBonDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            normaleLeveringBonDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            normaleLeveringBonDO.Giek = reader["Giek"].ToString();
                            normaleLeveringBonDO.M3 = Convert.ToDouble(reader["M3"]);
                            normaleLeveringBonDO.Datum = Convert.ToDateTime(reader["datum"]);
                            normaleLeveringBonDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));

                            normaleLeveringBonDO.Giek = reader["Giek"].ToString();
                            normaleLeveringBonDO.Levering = Convert.ToInt32(reader["Levering"]);
                            normaleLeveringBonDO.Leveringwijze = reader["leveringwijze"].ToString();
                            NormaleLeveringBonDOs.Add(normaleLeveringBonDO);
                        }
                        connection.Close();
                        return NormaleLeveringBonDOs;
                    }
                }
            }
        }

        public static List<NormaleLeveringBonDO> SelecteerLeveringenTussenTweeDatumsVanKlantEnProductEnWerf(DateTime datum1, DateTime datum2, int klantID, int formuleID, int werfID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from NormaleLeveringBons where klantID=@klantID and formuleID=@formuleID and werfID=@werfID and datum between @datum1 and @datum2 ;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@klantID", klantID);
                    command.Parameters.AddWithValue("@formuleID", formuleID);
                    command.Parameters.AddWithValue("@werfID", werfID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<NormaleLeveringBonDO> NormaleLeveringBonDOs = new List<NormaleLeveringBonDO>();
                        NormaleLeveringBonDO normaleLeveringBonDO;
                        while (reader.Read())
                        {
                            normaleLeveringBonDO = new NormaleLeveringBonDO();
                            normaleLeveringBonDO.ID = Convert.ToInt32(reader["ID"]);
                            normaleLeveringBonDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            normaleLeveringBonDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            normaleLeveringBonDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            normaleLeveringBonDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            normaleLeveringBonDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            normaleLeveringBonDO.M3 = Convert.ToDouble(reader["M3"]);
                            normaleLeveringBonDO.Datum = Convert.ToDateTime(reader["datum"]);
                            normaleLeveringBonDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            normaleLeveringBonDO.Giek = reader["Giek"].ToString();
                            normaleLeveringBonDO.Levering = Convert.ToInt32(reader["Levering"]);
                            normaleLeveringBonDO.Leveringwijze = reader["leveringwijze"].ToString();
                            normaleLeveringBonDO.Loswijze = reader["loswijze"].ToString();
                            normaleLeveringBonDO.Opmerking = reader["opmerking"].ToString();

                            NormaleLeveringBonDOs.Add(normaleLeveringBonDO);
                        }
                        connection.Close();
                        return NormaleLeveringBonDOs;
                    }
                }
            }
        }

        public static List<NormaleLeveringBonDO> SelecteerLeveringenTussenTweeDatumsVanKlantEnProduct(DateTime datum1, DateTime datum2, int klantID, int formuleID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from NormaleLeveringBons where klantID=@klantID and formuleID=@formuleID and datum between @datum1 and @datum2 ;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@klantID", klantID);
                    command.Parameters.AddWithValue("@formuleID", formuleID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<NormaleLeveringBonDO> NormaleLeveringBonDOs = new List<NormaleLeveringBonDO>();
                        NormaleLeveringBonDO normaleLeveringBonDO;
                        while (reader.Read())
                        {
                            normaleLeveringBonDO = new NormaleLeveringBonDO();
                            normaleLeveringBonDO.ID = Convert.ToInt32(reader["ID"]);
                            normaleLeveringBonDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            normaleLeveringBonDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            normaleLeveringBonDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            normaleLeveringBonDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            normaleLeveringBonDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            normaleLeveringBonDO.M3 = Convert.ToDouble(reader["M3"]);
                            normaleLeveringBonDO.Datum = Convert.ToDateTime(reader["datum"]);
                            normaleLeveringBonDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            normaleLeveringBonDO.Giek = reader["Giek"].ToString();
                            normaleLeveringBonDO.Levering = Convert.ToInt32(reader["Levering"]);
                            normaleLeveringBonDO.Leveringwijze = reader["leveringwijze"].ToString();
                            normaleLeveringBonDO.Loswijze = reader["loswijze"].ToString();
                            normaleLeveringBonDO.Opmerking = reader["opmerking"].ToString();

                            NormaleLeveringBonDOs.Add(normaleLeveringBonDO);
                        }
                        connection.Close();
                        return NormaleLeveringBonDOs;
                    }
                }
            }
        }

        public static Korting_Product_WerfDO MaakNieuweKortingProductWerf(Korting_Product_WerfDO korting_Product_WerfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into korting_Product_werf (klantID,werfID,productID,bedrag) values(@klantID,@werfID,@productID,@Bedrag);",
                            connection))
                {
                    command.Parameters.AddWithValue("@klantID", korting_Product_WerfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", korting_Product_WerfDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@productID", korting_Product_WerfDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@Bedrag", korting_Product_WerfDO.Bedrag);

                    korting_Product_WerfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_Product_WerfDO;
                }
            }
        }

        public static Korting_ProductDO MaakNieuweKortingProduct(Korting_ProductDO korting_ProductDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into korting_Product (klantID,productID,bedrag) values(@klantID,@productID,@Bedrag);",
                            connection))
                {
                    command.Parameters.AddWithValue("@klantID", korting_ProductDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@productID", korting_ProductDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@Bedrag", korting_ProductDO.Bedrag);

                    korting_ProductDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_ProductDO;
                }
            }
        }
        private static VoertuigDO GetVoertuigByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {
                using (SqlCommand command = new SqlCommand("select * from Voertuig where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        VoertuigDO voertuigDO = new VoertuigDO();
                        while (reader.Read())
                        {
                            {
                                voertuigDO.ID = Convert.ToInt32(reader["ID"]);
                                voertuigDO.Nummerplaat = reader["Nummerplaat"].ToString();
                            }
                        }
                        connection.Close();
                        return voertuigDO;
                    }
                }
            }
        }

        public static List<NormaleLeveringBonDO> SelecteerLeveringenTussenTweeDatums(DateTime datum1, DateTime datum2)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from NormaleLeveringBons where datum between @datum1 and @datum2;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<NormaleLeveringBonDO> NormaleLeveringBonDOs = new List<NormaleLeveringBonDO>();
                        NormaleLeveringBonDO normaleLeveringBonDO;
                        while (reader.Read())
                        {
                          
                            normaleLeveringBonDO = new NormaleLeveringBonDO();
                            normaleLeveringBonDO.ID = Convert.ToInt32(reader["ID"]);
                            normaleLeveringBonDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            if (NormaleLeveringBonDOs.Exists(X => X.KlantDO.Naam == normaleLeveringBonDO.KlantDO.Naam )) { }
                            else
                            {
                                //normaleLeveringBonDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                //normaleLeveringBonDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                                //normaleLeveringBonDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                                //normaleLeveringBonDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                                //normaleLeveringBonDO.Giek = reader["Giek"].ToString();
                                //normaleLeveringBonDO.M3 = Convert.ToDouble(reader["M3"]);
                                //normaleLeveringBonDO.Datum = Convert.ToDateTime(reader["datum"]);
                                //normaleLeveringBonDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));

                                //normaleLeveringBonDO.Levering = Convert.ToInt32(reader["levering"]);
                                //normaleLeveringBonDO.Leveringwijze = reader["leveringWijze"].ToString();
                                //normaleLeveringBonDO.Loswijze = reader["loswijze"].ToString();
                                //normaleLeveringBonDO.Opmerking = reader["opmerking"].ToString();
                                NormaleLeveringBonDOs.Add(normaleLeveringBonDO);
                            }
                           
                        }
                        connection.Close();
                        return NormaleLeveringBonDOs;
                    }
                }
            }
        }

        private static ChauffeurDO GetChauffeurByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {
                using (SqlCommand command = new SqlCommand("select * from Chauffeurs where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ChauffeurDO chauffeurDO = new ChauffeurDO();
                        while (reader.Read())
                        {
                            {
                                chauffeurDO.ID = Convert.ToInt32(reader["ID"]);
                                chauffeurDO.Naam = reader["Naam"].ToString();

                            }
                        }
                        connection.Close();
                        return chauffeurDO;
                    }
                }
            }
        }
        public static List<NormaleLeveringBonDO> SelecteerLeveringenTussenTweeDatumsVanKlant(DateTime datum1, DateTime datum2, int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from NormaleLeveringBons where klantID=@klantID and datum between @datum1 and @datum2 ;  ", connection))
                {
                    command.Parameters.AddWithValue("@datum1", datum1);
                    command.Parameters.AddWithValue("@datum2", datum2);
                    command.Parameters.AddWithValue("@klantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<NormaleLeveringBonDO> NormaleLeveringBonDOs = new List<NormaleLeveringBonDO>();
                        NormaleLeveringBonDO normaleLeveringBonDO;
                        while (reader.Read())
                        {
                            normaleLeveringBonDO = new NormaleLeveringBonDO();
                            normaleLeveringBonDO.ID = Convert.ToInt32(reader["ID"]);
                            normaleLeveringBonDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            normaleLeveringBonDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            normaleLeveringBonDO.VoertuigDO = GetVoertuigByID(Convert.ToInt32(reader["voertuigID"]));
                            normaleLeveringBonDO.ChauffeurDO = GetChauffeurByID(Convert.ToInt32(reader["chauffeurID"]));
                            normaleLeveringBonDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["formuleID"]));
                            normaleLeveringBonDO.M3 = Convert.ToDouble(reader["M3"]);
                            normaleLeveringBonDO.Datum = Convert.ToDateTime(reader["datum"]);
                            normaleLeveringBonDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));

                            normaleLeveringBonDO.Giek = reader["Giek"].ToString();
                            normaleLeveringBonDO.Levering = Convert.ToInt32(reader["Levering"]);
                            normaleLeveringBonDO.Leveringwijze = reader["leveringwijze"].ToString();
                            normaleLeveringBonDO.Loswijze = reader["loswijze"].ToString();
                            normaleLeveringBonDO.Opmerking = reader["opmerking"].ToString();

                            NormaleLeveringBonDOs.Add(normaleLeveringBonDO);
                        }
                        connection.Close();
                        return NormaleLeveringBonDOs;
                    }
                }
            }
        }

        public static Korting_WerfDO MaakNieuweKortingWerf(Korting_WerfDO korting_WerfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Korting_werf (klantID,werfID,bedrag) values(@klantID,@werfID,@Bedrag);",
                            connection))
                {
                    command.Parameters.AddWithValue("@klantID", korting_WerfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", korting_WerfDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@Bedrag", korting_WerfDO.Bedrag);


                    korting_WerfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return korting_WerfDO;
                }
            }
        }

        public static PrijsLijstDO UpdatePrijsLijst(PrijsLijstDO prijsLijstDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update Prijslijst set Formule=@Formule,Aannemer=@Aannemer,Particulier=@Particulier where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", prijsLijstDO.ID);
                    command.Parameters.AddWithValue("@Formule", prijsLijstDO.Formule);
                    command.Parameters.AddWithValue("@Aannemer", prijsLijstDO.Aannemer);
                    command.Parameters.AddWithValue("@Particulier", prijsLijstDO.Particulier);
            

                    prijsLijstDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return prijsLijstDO;
                }
            }
        }

        public static List<PrijsLijstDO> KrijgAllePrijzen()
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from PrijsLijst;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PrijsLijstDO> prijsLijstDOs = new List<PrijsLijstDO>();

                    while (reader.Read())
                    {
                        PrijsLijstDO prijsLijstDO = new PrijsLijstDO();
                        {
                            prijsLijstDO.ID = Convert.ToInt32(reader["ID"]);
                            prijsLijstDO.Formule = reader["Formule"].ToString();
                            if(reader["Aannemer"] == null)
                            {
                                prijsLijstDO.Aannemer = 0;
                            }
                            else
                            {
                                prijsLijstDO.Aannemer = Convert.ToDouble(reader["Aannemer"]);
                            }

                            if(reader["Particulier"] == null)
                            {
                                prijsLijstDO.Particulier = 0;
                            }
                            else
                            {
                                prijsLijstDO.Particulier = Convert.ToDouble(reader["Particulier"]);
                            }
                            
                            

                            prijsLijstDOs.Add(prijsLijstDO);
                        }

                    }
                    connection1.Close();
                    return prijsLijstDOs;
                }
            }
        }

        public static List<OmschrijvingProductDO> KrijgAlleProductOmschrijving()
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {

                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from Product_Omschrijving;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<OmschrijvingProductDO> omschrijvingProductDOs = new List<OmschrijvingProductDO>();

                    while (reader.Read())
                    {
                        OmschrijvingProductDO omschrijvingProductDO = new OmschrijvingProductDO();
                        {
                            omschrijvingProductDO.ID = Convert.ToInt32(reader["ID"]);
                            omschrijvingProductDO.Formule = reader["Formule"].ToString();
                            omschrijvingProductDO.Omschrijving = reader["Omschrijving"].ToString();

                            omschrijvingProductDOs.Add(omschrijvingProductDO);
                        }

                    }
                    connection1.Close();
                    return omschrijvingProductDOs;
                }
            }
        }

        public static HulpstofDO VoegHulpstofToeAanBestelling(HulpstofDO hulpstofDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into hulpstof (naam,bestellingID,hoeveelheid) values(@naam,@bestellingID,@Hoeveelheid);",
                            connection))
                {
                    command.Parameters.AddWithValue("@naam", hulpstofDO.Naam);
                    command.Parameters.AddWithValue("@bestellingID", hulpstofDO.BestellingDO.ID);
                    command.Parameters.AddWithValue("@Hoeveelheid", hulpstofDO.Hoeveelheid);

                    hulpstofDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return hulpstofDO;
                }
            }
        }

        public static WerfDO VerwijderWerf(WerfDO werfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update werf set Visible=1 where ID=@ID;",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", werfDO.ID);

                    werfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return werfDO;
                }
            }
        }

        public static List<WerfDO> KrijgAlleWervenDoorKlantID(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from werf where klantID=@klantID;  ", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<WerfDO> werfDOs = new List<WerfDO>();
                    
                        while (reader.Read())
                        {
                            int verwijderd = 0;
                     
                                try
                                {
                                verwijderd = Convert.ToInt32(reader["Visible"]);
                                }
                                catch
                                {
                                verwijderd = 0;
                                }
                            if (verwijderd == 0)
                            {
                                WerfDO werfDO = new WerfDO();
                                {
                                    werfDO.ID = Convert.ToInt32(reader["ID"]);
                                    werfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                    werfDO.Adres = reader["adres"].ToString();
                                    werfDO.Gemeente = reader["gemeente"].ToString();
                                    werfDO.Postcode = reader["postcode"].ToString();
                                    werfDO.Telefoon = reader["telefoon"].ToString();
                                    bool afhalingBug = false;
                                    if(werfDO.Adres == "afhaling")
                                    {
                                        foreach(WerfDO werfDO1 in werfDOs)
                                        {
                                            if(werfDO1.Adres == "afhaling")
                                            {
                                                afhalingBug = true;
                                            }
                                        }
                                    }
                                    if(afhalingBug == false)
                                    {
                                        werfDOs.Add(werfDO);
                                    }
                                }
                            }
                        }
                        connection.Close();
                        return werfDOs;
                    }
                }
            }
        }

        public static WerfDO UpdateWerf(WerfDO werfDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update werf set klantID=@klantID,Adres=@Adres,Gemeente=@Gemeente,Postcode=@Postcode,Telefoon=@Telefoon where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", werfDO.ID);
                    command.Parameters.AddWithValue("@klantID", werfDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@Adres", werfDO.Adres);
                    command.Parameters.AddWithValue("@Gemeente", werfDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", werfDO.Postcode);
                    command.Parameters.AddWithValue("@Telefoon", werfDO.Telefoon);

                    werfDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return werfDO;
                }
            }
        }

        private static WerfDO GetWerfByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from werf where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        WerfDO werfDO = new WerfDO();
                        while (reader.Read())
                        {
                            {
                                werfDO.ID = Convert.ToInt32(reader["ID"]);
                                werfDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                werfDO.Adres = reader["Adres"].ToString();
                                werfDO.Gemeente = reader["Gemeente"].ToString();
                                werfDO.Postcode = reader["Postcode"].ToString();
                                werfDO.Telefoon = reader["Telefoon"].ToString();
                            }
                        }
                        connection.Close();
                        return werfDO;
                    }
                }
            }
        }
        #endregion 

        #region Klanten
        public static  List<KlantDO> KrijgAlleKlanten()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from klant;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<KlantDO> klantDOs = new List<KlantDO>();

                    while (reader.Read())
                    {
                        KlantDO klantDO = new KlantDO();
                        {
                            klantDO.ID = Convert.ToInt32(reader["ID"]);
                            klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                            klantDO.Naam = reader["naam"].ToString();

                            string adres = reader["adres"].ToString();
                            string gemeente = reader["gemeente"].ToString();
                            string postcode = reader["postcode"].ToString();
                            string gsm = reader["gsm"].ToString();
                            string telefoon = reader["telefoon"].ToString();
                            string email = reader["email"].ToString();
                            string fax = reader["fax"].ToString();
                            string btw = reader["btw"].ToString();
                            string buitenlandsebtw = reader["buitenlandseBTW"].ToString();
                            klantDO.BetaalCode = reader["betaalCode"].ToString();
                            if (adres != null)
                            {
                                klantDO.Adres = adres;
                            }
                            else
                            {
                                klantDO.Adres = "";
                            }
                            if (gemeente != null)
                            {
                                klantDO.Gemeente = gemeente;
                            }
                            else
                            {
                                klantDO.Gemeente = "";
                            }
                            if (postcode != null)
                            {
                                klantDO.Postcode = postcode;
                            }
                            else
                            {
                                klantDO.Postcode = "";
                            }
                            if (gsm != null)
                            {
                                klantDO.Gsm = gsm;
                            }
                            else
                            {
                                klantDO.Gsm = "";
                            }
                            if (telefoon != null)
                            {
                                klantDO.Telefoon = telefoon;
                            }
                            else
                            {
                                klantDO.Telefoon = "";
                            }
                            if (email != null)
                            {
                                klantDO.Email = email;
                            }
                            else
                            {
                                klantDO.Email = "";
                            }
                            if (fax != null)
                            {
                                klantDO.Fax = fax;
                            }
                            else
                            {
                                klantDO.Fax = "";
                            }
                            if (btw != null)
                            {
                                klantDO.Btw = btw;
                            }
                            else
                            {
                                klantDO.Btw = "";
                            }
                            if (buitenlandsebtw != null)
                            {
                                klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                            }
                            else
                            {
                                klantDO.BuitenlandseBtw = "";
                            }

                            klantDOs.Add(klantDO);
                        }
                    }
                    connection.Close();
                    return klantDOs;
                }
            }
        }
        public static KlantDO MaakNieuweKlant(KlantDO klantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into klant (Naam,Nummer,adres,gemeente,postcode,gsm,telefoon,email,fax,btw,buitenlandseBTW,betaalCode) values(@Naam,@Nummer,@Adres,@Gemeente,@Postcode,@Gsm,@Telefoon,@Email,@Fax,@Btw,@BuitenlandseBTW,@betaalCode);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", klantDO.Naam);
                    command.Parameters.AddWithValue("@Nummer", klantDO.Nummer);
                    command.Parameters.AddWithValue("@Adres", klantDO.Adres);
                    command.Parameters.AddWithValue("@Gemeente", klantDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", klantDO.Postcode);
                    command.Parameters.AddWithValue("@Gsm", klantDO.Gsm);
                    command.Parameters.AddWithValue("@Telefoon", klantDO.Telefoon);
                    command.Parameters.AddWithValue("@Email", klantDO.Email);
                    command.Parameters.AddWithValue("@Fax", klantDO.Fax);
                    command.Parameters.AddWithValue("@Btw", klantDO.Btw);
                    command.Parameters.AddWithValue("@BuitenlandseBTW", klantDO.BuitenlandseBtw);
                    command.Parameters.AddWithValue(@"betaalCode", klantDO.BetaalCode);

                    klantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return klantDO;
                }
            }
        }

        private static KlantDO GetKlantByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from klant where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KlantDO klantDO = new KlantDO();
                        while (reader.Read())
                        {
                        
                            {
                                klantDO.ID = Convert.ToInt32(reader["ID"]);
                                klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                                klantDO.Naam = reader["naam"].ToString();

                                string adres = reader["adres"].ToString();
                                string gemeente = reader["gemeente"].ToString();
                                string postcode = reader["postcode"].ToString();
                                string gsm = reader["gsm"].ToString();
                                string telefoon = reader["telefoon"].ToString();
                                string email = reader["email"].ToString();
                                string fax = reader["fax"].ToString();
                                string btw = reader["btw"].ToString();
                                string buitenlandsebtw = reader["buitenlandseBTW"].ToString();

                                if (adres != null)
                                {
                                    klantDO.Adres = adres;
                                }
                                else
                                {
                                    klantDO.Adres = "";
                                }
                                if (gemeente != null)
                                {
                                    klantDO.Gemeente = gemeente;
                                }
                                else
                                {
                                    klantDO.Gemeente = "";
                                }
                                if (postcode != null)
                                {
                                    klantDO.Postcode = postcode;
                                }
                                else
                                {
                                    klantDO.Postcode = "";
                                }
                                if (gsm != null)
                                {
                                    klantDO.Gsm = gsm;
                                }
                                else
                                {
                                    klantDO.Gsm = "";
                                }
                                if (telefoon != null)
                                {
                                    klantDO.Telefoon = telefoon;
                                }
                                else
                                {
                                    klantDO.Telefoon = "";
                                }
                                if (email != null)
                                {
                                    klantDO.Email = email;
                                }
                                else
                                {
                                    klantDO.Email = "";
                                }
                                if (fax != null)
                                {
                                    klantDO.Fax = fax;
                                }
                                else
                                {
                                    klantDO.Fax = "";
                                }
                                if (btw != null)
                                {
                                    klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.Btw = "";
                                }
                                if (buitenlandsebtw != null)
                                {
                                    klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.BuitenlandseBtw = "";
                                }

                            }
                         
                        }
                        connection.Close();
                        return klantDO;
                    }
                }
            }
        }

        public static BestellingDO krijgBestellingDoorKlantWerfDatum(int iD1, int iD2, DateTime value)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from Bestelling where klantID=@klantID and werfID=@werfID and datum=@datum;", connection))
                {
                    command.Parameters.AddWithValue("@klantID", iD1);
                    command.Parameters.AddWithValue("@werfID", iD2);
                    command.Parameters.AddWithValue("@datum", value);
                    connection.Open();
                    BestellingDO bestellingDO = new BestellingDO();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingDO.Giek = reader["Giek"].ToString();
                            bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                            bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                            bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingDO.Comment = reader["comment"].ToString();
                        }

                    }
                    connection.Close();
                    return bestellingDO;
                }
            }
        }

        public static KlantDO UpdateKlant(KlantDO klantDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update klant set naam=@Naam,Nummer=@Nummer,Adres=@Adres,Gemeente=@Gemeente,Postcode=@Postcode,Gsm=@Gsm,Telefoon=@Telefoon,Email=@Email,Fax=@Fax,Btw=@Btw,betaalCode=@betaalCode where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", klantDO.ID);
                    command.Parameters.AddWithValue("@Naam", klantDO.Naam);
                    command.Parameters.AddWithValue("@Nummer", klantDO.Nummer);
                    command.Parameters.AddWithValue("@Adres", klantDO.Adres);
                    command.Parameters.AddWithValue("@Gemeente", klantDO.Gemeente);
                    command.Parameters.AddWithValue("@Postcode", klantDO.Postcode);
                    command.Parameters.AddWithValue("@Gsm", klantDO.Gsm);
                    command.Parameters.AddWithValue("@Telefoon", klantDO.Telefoon);
                    command.Parameters.AddWithValue("@Email", klantDO.Email);
                    command.Parameters.AddWithValue("@Fax", klantDO.Fax);
                    command.Parameters.AddWithValue("@Btw", klantDO.Btw);
                    command.Parameters.AddWithValue("@betaalCode", klantDO.BetaalCode);
                    //command.Parameters.AddWithValue("@BuitenlandseBTW", klantDO.BuitenlandseBtw);
                    klantDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return klantDO;
                }
            }
        }

        #endregion

        #region formules
        public static List<FormuleDO> KrijgAlleFormules()
        {
            using (SqlConnection connection1 = new SqlConnection(connectionstringBestelling))
            {
                connection1.Open();
                using (SqlCommand command = new SqlCommand("select * from formule;", connection1))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<FormuleDO> FormuleDOs = new List<FormuleDO>();

                    while (reader.Read())
                    {
                        FormuleDO formuleDO = new FormuleDO();
                        {
                            formuleDO.ID = Convert.ToInt32(reader["ID"]);
                            formuleDO.Naam = reader["Naam"].ToString();
                            formuleDO.OmgevingsKlasse = reader["OmgevingsKlasse"].ToString();
                            formuleDO.Samenstelling = reader["Samenstelling"].ToString();
                            formuleDO.SterkteKlasse = reader["SterkteKlasse"].ToString();
                            formuleDO.Vloeibaarheid = reader["Vloeibaarheid"].ToString();
                            formuleDO.GranuleDiameter = reader["GranuleDiameter"].ToString();
                            formuleDO.CemmentType = reader["CemmentType"].ToString();
                            formuleDO.IsBenor = Convert.ToBoolean(reader["IsBenor"]);
                            formuleDO.BenorCategorieDO = GetBenorCategoryByID(Convert.ToInt32(reader["BenorCategorieID"]));
                            formuleDO.MaatEenheid = reader["MaatEenheid"].ToString();
                            formuleDO.Omschrijving = reader["Omschrijving"].ToString();
                            Debug.WriteLine(formuleDO.MaatEenheid.ToString());
                            FormuleDOs.Add(formuleDO);
                        }

                    }
                    connection1.Close();
                    return FormuleDOs;
                }
            }
        }

        private static BenorCategorieDO GetBenorCategoryByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from BenorCategorie where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        BenorCategorieDO benorCategorieDO = new BenorCategorieDO();
                        while (reader.Read())
                        {
                            {
                                benorCategorieDO.ID = Convert.ToInt32(reader["ID"]);
                                benorCategorieDO.Naam = reader["Naam"].ToString();
                              
                            }
                        }
                        connection.Close();
                        return benorCategorieDO;
                    }
                }
            }
        }

        public static FormuleDO MaakNieuweFormule(FormuleDO formuleDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into formule (Naam,SterkteKlasse,Vloeibaarheid,OmgevingsKlasse,GranuleDiameter,Samenstelling,CemmentType,IsBenor,BenorCategorieID,Omschrijving) values(@Naam,@SterkteKlasse,@Vloeibaarheid,@OmgevingsKlasse,@GranuleDiameter,@Samenstelling,@CemmentType,@IsBenor,@BenorCategorieID,@Omschrijving);",
                            connection))
                {
                    command.Parameters.AddWithValue("@Naam", formuleDO.Naam);
                    command.Parameters.AddWithValue("@SterkteKlasse", formuleDO.SterkteKlasse);
                    command.Parameters.AddWithValue("@Vloeibaarheid", formuleDO.Vloeibaarheid);
                    command.Parameters.AddWithValue("@OmgevingsKlasse", formuleDO.OmgevingsKlasse);
                    command.Parameters.AddWithValue("@GranuleDiameter", formuleDO.GranuleDiameter);
                    command.Parameters.AddWithValue("@Samenstelling", formuleDO.Samenstelling);
                    command.Parameters.AddWithValue("@CemmentType", formuleDO.CemmentType);
                    command.Parameters.AddWithValue("@IsBenor", formuleDO.IsBenor);
                    command.Parameters.AddWithValue("@BenorCategorieID", formuleDO.BenorCategorieDO.ID);
                    command.Parameters.AddWithValue("@Omschrijving", formuleDO.Omschrijving);
                    formuleDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return formuleDO;
                }
            }
        }
        public static FormuleDO GetFormuleByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from formule where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        FormuleDO formuleDO = new FormuleDO();
                        while (reader.Read())
                        {
                            {
                                formuleDO.ID = Convert.ToInt32(reader["ID"]);
                                formuleDO.Naam = reader["Naam"].ToString();
                                formuleDO.SterkteKlasse = reader["SterkteKlasse"].ToString();
                                formuleDO.Vloeibaarheid = reader["Vloeibaarheid"].ToString();
                                formuleDO.OmgevingsKlasse = reader["OmgevingsKlasse"].ToString();
                                formuleDO.GranuleDiameter = reader["GranuleDiameter"].ToString();
                                formuleDO.Samenstelling = reader["Samenstelling"].ToString();
                                formuleDO.CemmentType = reader["CemmentType"].ToString();
                                formuleDO.IsBenor = Convert.ToBoolean(reader["IsBenor"]);
                                formuleDO.BenorCategorieDO = GetBenorCategoryByID(Convert.ToInt32(reader["BenorCategorieID"]));
                                formuleDO.MaatEenheid = reader["MaatEenheid"].ToString();
                                formuleDO.Omschrijving = reader["Omschrijving"].ToString();
                            }
                        }
                        connection.Close();
                        return formuleDO;
                    }
                }
            }
        }
        public static FormuleDO UpdateFormule(FormuleDO formuleDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update formule set Naam=@Naam,SterkteKlasse=@SterkteKlasse,Vloeibaarheid=@Vloeibaarheid,OmgevingsKlasse=@OmgevingsKlasse,GranuleDiameter=@GranuleDiameter,Samenstelling=@Samenstelling,CemmentType=@CemmentType,IsBenor=@IsBenor,BenorCategorieID=@BenorCategorieID,MaatEenheid=@MaatEenheid,Omschrijving=@Omschrijving where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", formuleDO.ID);
                    command.Parameters.AddWithValue("@Naam", formuleDO.Naam);
                    command.Parameters.AddWithValue("@SterkteKlasse", formuleDO.SterkteKlasse);
                    command.Parameters.AddWithValue("@Vloeibaarheid", formuleDO.Vloeibaarheid);
                    command.Parameters.AddWithValue("@OmgevingsKlasse", formuleDO.OmgevingsKlasse);
                    command.Parameters.AddWithValue("@GranuleDiameter", formuleDO.GranuleDiameter);
                    command.Parameters.AddWithValue("@Samenstelling", formuleDO.Samenstelling);
                    command.Parameters.AddWithValue("@CemmentType", formuleDO.CemmentType);
                    command.Parameters.AddWithValue("@IsBenor", formuleDO.IsBenor);
                    command.Parameters.AddWithValue("@BenorCategorieID", formuleDO.BenorCategorieDO.ID);
                    command.Parameters.AddWithValue("@MaatEenheid", formuleDO.MaatEenheid);
                    command.Parameters.AddWithValue("@Omschrijving", formuleDO.Omschrijving);
                    formuleDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return formuleDO;
                }
            }
        }

        #endregion

        #region bestellingen
        public static BestellingDO MaakNieuweBestelling(BestellingDO bestellingDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into bestelling (klantID,werfID,productID,pompID,giek,m3,besteldatum,datum,levering,leveringwijze,loswijze,comment) values(@KlantID,@werfID,@productID,@PompID,@giek,@m3,@besteldatum,@datum,@levering,@leveringwijze,@Loswijze,@comment);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", bestellingDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", bestellingDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@productID", bestellingDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@pompID", bestellingDO.PompDO.ID);
                    command.Parameters.AddWithValue("@giek", bestellingDO.Giek);
                    command.Parameters.AddWithValue("@m3", bestellingDO.M3);
                    command.Parameters.AddWithValue("@besteldatum", bestellingDO.Besteldatum);
                    command.Parameters.AddWithValue("@datum", bestellingDO.Datum);
                    command.Parameters.AddWithValue("@levering", bestellingDO.Levering);
                    if (bestellingDO.LeveringWijze == null)
                    {
                        bestellingDO.LeveringWijze = " ";
                    }
                    command.Parameters.AddWithValue("@leveringwijze", bestellingDO.LeveringWijze);
                    command.Parameters.AddWithValue("@Loswijze", bestellingDO.Loswijze);
                    command.Parameters.AddWithValue("@comment", bestellingDO.Comment);
                    bestellingDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bestellingDO;
                }
            }
        }

        public static List<BestellingDO> SelecteerBestellingenVoorEenDatum(DateTime datum1)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from bestelling where datum between @datum1 and @datum2;", connection))
                {
                    DateTime datum2;
                    command.Parameters.AddWithValue("@datum1", datum1);
                    datum2 = datum1.AddDays(1);
                    command.Parameters.AddWithValue("@datum2", datum2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<BestellingDO> bestellingDOs = new List<BestellingDO>();

                        while (reader.Read())
                        {
                            BestellingDO bestellingDO = new BestellingDO();
                            bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                            bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                            bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                            bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                            bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                            bestellingDO.Giek = reader["Giek"].ToString();
                            bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                            bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                            bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                            bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            bestellingDO.Loswijze = reader["Loswijze"].ToString();
                            bestellingDO.Comment = reader["comment"].ToString();

                            bestellingDOs.Add(bestellingDO);
                        }
                        connection.Close();
                        return bestellingDOs;
                    }
                }
            }
        }
        public static BestellingDO UpdateBestelling(BestellingDO bestellingDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update bestelling set KlantID=@KlantID,werfID=@werfID,productID=@productID,pompID=@pompID,giek=@giek,m3=@m3,datum=@datum,levering=@levering,leveringwijze=@leveringwijze,Loswijze=@Loswijze,comment=@comment where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", bestellingDO.ID);
                    command.Parameters.AddWithValue("@KlantID", bestellingDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", bestellingDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@productID", bestellingDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@pompID", bestellingDO.PompDO.ID);
                    command.Parameters.AddWithValue("@giek", bestellingDO.Giek);
                    command.Parameters.AddWithValue("@m3", bestellingDO.M3);
                    command.Parameters.AddWithValue("@datum", bestellingDO.Datum);
                    command.Parameters.AddWithValue("@levering", bestellingDO.Levering);
                    if (bestellingDO.LeveringWijze == null)
                    {
                        bestellingDO.LeveringWijze = " ";
                    }
                    command.Parameters.AddWithValue("@leveringwijze", bestellingDO.LeveringWijze);
                    command.Parameters.AddWithValue("@Loswijze", bestellingDO.Loswijze);
                    command.Parameters.AddWithValue("@comment", bestellingDO.Comment);

                    bestellingDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bestellingDO;
                }
            }
        }
        public static BestellingDO VerwijderBestelling(BestellingDO bestellingDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from bestelling where ID=@ID",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", bestellingDO.ID);
                    command.Parameters.AddWithValue("@Visible", 1);
                    bestellingDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bestellingDO;
                }
            }
        }
        public static BestellingDO VerwijderAgendaPunt(BestellingDO bestellingDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into GeslotenAgendaPunten (klantID,werfID,formuleID,pompID,m3,datum,levering,leveringWijze) values(@KlantID,@werfID,@formuleID,@PompID,@HulpstofID,@m3,@datumTijd,@levering,@leveringWijze,@hoeveelheidHulpstof);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", bestellingDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", bestellingDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@formuleID", bestellingDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@pompID", bestellingDO.PompDO.ID);
                   
                    command.Parameters.AddWithValue("@m3", bestellingDO.M3);
                    command.Parameters.AddWithValue("@datumTijd", bestellingDO.Datum);
                    command.Parameters.AddWithValue("@levering", bestellingDO.Levering);
                    command.Parameters.AddWithValue("@leveringWijze", bestellingDO.LeveringWijze);
                   
                    bestellingDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return bestellingDO;
                }
            }
        }
        #endregion

        #region pomp

        public static List<PompDO> KrijgAllePompen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from pomp;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PompDO> PompDOs = new List<PompDO>();

                    while (reader.Read())
                    {
                        PompDO pompDO = new PompDO();
                        {
                            pompDO.ID = Convert.ToInt32(reader["ID"]);
                            pompDO.PompLeverancier = reader["pompLeverancier"].ToString();
                            pompDO.Pomp = reader["pomp"].ToString();
                           

                            PompDOs.Add(pompDO);
                        }

                    }
                    connection.Close();
                    return PompDOs;
                }
            }
        }
        private static PompDO GetPompByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from pomp where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        PompDO pompDO = new PompDO();
                        while (reader.Read())
                        {
                            {
                                pompDO.ID = Convert.ToInt32(reader["ID"]);
                                pompDO.PompLeverancier = reader["PompLeverancier"].ToString();
                                pompDO.Pomp = reader["Pomp"].ToString();
                         
                            }
                        }
                        connection.Close();
                        return pompDO;
                    }
                }
            }
        }
        public static PompDO MaakNieuwePomp(PompDO pompDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into pomp (pompLeverancier,pomp) values(@pompLeverancier,@pomp);",
                            connection))
                {
                    command.Parameters.AddWithValue("@pompLeverancier", pompDO.PompLeverancier);
                    command.Parameters.AddWithValue("@pomp", pompDO.Pomp);
               

                    pompDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return pompDO;
                }
            }
        }
        public static PompDO UpdatePomp(PompDO pompDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update pomp set PompLeverancier=@PompLeverancier,Pomp=@Pomp where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", pompDO.ID);
                    command.Parameters.AddWithValue("@PompLeverancier", pompDO.PompLeverancier);
                    command.Parameters.AddWithValue("@Pomp", pompDO.Pomp);
                

                    pompDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return pompDO;
                }
            }
        }

        #endregion


        public static List<PostcodeGemeenteDO> KrijgAllePostcodeGemeentes()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from PostcodePerGemeente;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PostcodeGemeenteDO> PostcodeGemeenteDOs = new List<PostcodeGemeenteDO>();

                    while (reader.Read())
                    {
                        PostcodeGemeenteDO postcodeGemeenteDO = new PostcodeGemeenteDO();
                        {
                            postcodeGemeenteDO.ID = Convert.ToInt32(reader["ID"]);
                            postcodeGemeenteDO.Postcode = reader["Postcode"].ToString();
                            postcodeGemeenteDO.Gemeente = reader["Gemeente"].ToString();


                            PostcodeGemeenteDOs.Add(postcodeGemeenteDO);
                        }

                    }
                    connection.Close();
                    return PostcodeGemeenteDOs;
                }
            }
        }
        #region hulpstof
        public static HulpstofDO VerwijderHulpstof(HulpstofDO hulpstofDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("delete from hulpstof where ID=@ID",
                            connection))
                {

                    command.Parameters.AddWithValue("@ID", hulpstofDO.ID);

                    hulpstofDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return hulpstofDO;
                }
            }
        }

        public static FactuurDO UpdateFactuur(FactuurDO factuurDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("update factuur set totaalExclBtw=@totaalExclBtw,Totaalverlegd=@Totaalverlegd,totaalIncl6Btw=@totaalIncl6Btw,totaalIncl21Btw=@totaalIncl21Btw,totaal=@totaal where ID=@ID",
                            connection))
                {
                    command.Parameters.AddWithValue("@ID", factuurDO.ID);
                    command.Parameters.AddWithValue("@totaalExclBtw", factuurDO.TotaalExclBtw);
                    command.Parameters.AddWithValue("@Totaalverlegd", factuurDO.TotaalVerlegd);
                    command.Parameters.AddWithValue("@totaalIncl6Btw", factuurDO.TotaalIncl6Btw);
                    command.Parameters.AddWithValue("@totaalIncl21Btw", factuurDO.TotaalIncl21Btw);
                    command.Parameters.AddWithValue("@totaal", factuurDO.Totaal);

                    factuurDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return factuurDO;
                }
            }
        }
        public static List<HulpstofDO> KrijgAlleHulpstoffen(int bestellingID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from hulpstof where bestellingID=@bestellingID ;", connection)) { 

                   command.Parameters.AddWithValue("@bestellingID", bestellingID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<HulpstofDO> hulpstofDOs = new List<HulpstofDO>();

                        while (reader.Read())
                        {
                            HulpstofDO hulpstofDO = new HulpstofDO();
                            {

                                hulpstofDO.ID = Convert.ToInt32(reader["ID"]);
                                hulpstofDO.Naam = reader["Naam"].ToString();
                                hulpstofDO.Hoeveelheid = reader["hoeveelheid"].ToString();
                                hulpstofDO.BestellingDO = GetBestellingByID(Convert.ToInt32(reader["bestellingID"]));
                                hulpstofDOs.Add(hulpstofDO);
                            }

                        }
                        connection.Close();
                        return hulpstofDOs;
                    }
                }
            }
        }

        private static BestellingDO GetBestellingByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from bestelling where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        BestellingDO bestellingDO = new BestellingDO();
                        while (reader.Read())
                        {
                            {
                                bestellingDO.ID = Convert.ToInt32(reader["ID"]);
                                bestellingDO.KlantDO = GetKlantByID(Convert.ToInt32(reader["klantID"]));
                                bestellingDO.WerfDO = GetWerfByID(Convert.ToInt32(reader["werfID"]));
                                bestellingDO.FormuleDO = GetFormuleByID(Convert.ToInt32(reader["productID"]));
                                bestellingDO.PompDO = GetPompByID(Convert.ToInt32(reader["pompID"]));
                                bestellingDO.Giek = reader["Giek"].ToString();
                                bestellingDO.M3 = Convert.ToDouble(reader["m3"]);
                                bestellingDO.Datum = Convert.ToDateTime(reader["datum"]);
                                bestellingDO.Levering = Convert.ToInt32(reader["levering"]);
                                bestellingDO.LeveringWijze = reader["leveringwijze"].ToString();
                            }
                        }
                        connection.Close();
                        return bestellingDO;
                    }
                }
            }
        }

        private static HulpstofDO GethulpstofByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringBestelling))
            {
                using (SqlCommand command = new SqlCommand("select * from hulpstof where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        HulpstofDO hulpstofDO = new HulpstofDO();
                        while (reader.Read())
                        {
                            {
                                hulpstofDO.ID = Convert.ToInt32(reader["ID"]);
                                hulpstofDO.Naam = reader["Naam"].ToString();
                            }
                        }
                        connection.Close();
                        return hulpstofDO;
                    }
                }
            }
        }

        #endregion

        #region voertuigen
        public static List<VoertuigDO> KrijgAlleVoertuigen()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Voertuig;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<VoertuigDO> VoertuigDOs = new List<VoertuigDO>();

                    while (reader.Read())
                    {
                        VoertuigDO voertuigDO = new VoertuigDO();
                        {
                            voertuigDO.ID = Convert.ToInt32(reader["ID"]);
                            voertuigDO.Nummerplaat = reader["Nummerplaat"].ToString();

                            VoertuigDOs.Add(voertuigDO);
                        }

                    }
                    connection.Close();
                    return VoertuigDOs;
                }
            }
        }

        #endregion

        #region chauffeurs

        public static List<ChauffeurDO> KrijgAlleChauffeurs()
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from Chauffeurs;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<ChauffeurDO> ChauffeurDOs = new List<ChauffeurDO>();

                    while (reader.Read())
                    {
                        ChauffeurDO chauffeurDO = new ChauffeurDO();
                        {
                            chauffeurDO.ID = Convert.ToInt32(reader["ID"]);
                            chauffeurDO.Naam = reader["Naam"].ToString();

                            ChauffeurDOs.Add(chauffeurDO);
                        }

                    }
                    connection.Close();
                    return ChauffeurDOs;
                }
            }
        }

        #endregion

        #region agenda
        public static AgendaLeveringenDO MaakNieuwAgendaPunt(AgendaLeveringenDO agendaLeveringenDO)
        {
            using (SqlConnection connection = new SqlConnection(connectionstringLevering))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into AgendaLeveringen (klantID,werfID,voertuigID,chauffeurID,formuleID,pompID,giek,m3,datumTijd,levering,leveringWijze,Loswijze,comment,bestelID) values(@KlantID,@werfID,@voertuigID,@chauffeurID,@formuleID,@PompID,@giek,@m3,@datumTijd,@levering,@leveringWijze,@Loswijze,@Comment,@bestelID);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantID", agendaLeveringenDO.KlantDO.ID);
                    command.Parameters.AddWithValue("@werfID", agendaLeveringenDO.WerfDO.ID);
                    command.Parameters.AddWithValue("@formuleID", agendaLeveringenDO.FormuleDO.ID);
                    command.Parameters.AddWithValue("@voertuigID", agendaLeveringenDO.VoertuigDO.ID);
                    command.Parameters.AddWithValue("@ChauffeurID", agendaLeveringenDO.ChauffeurDO.ID);
                    command.Parameters.AddWithValue("@pompID", agendaLeveringenDO.PompDO.ID);
                    command.Parameters.AddWithValue("@giek", agendaLeveringenDO.Giek);
                    command.Parameters.AddWithValue("@m3", agendaLeveringenDO.M3);
                    command.Parameters.AddWithValue("@datumTijd", agendaLeveringenDO.Datum);
                    command.Parameters.AddWithValue("@levering", agendaLeveringenDO.Levering);
                    command.Parameters.AddWithValue("@leveringWijze", agendaLeveringenDO.LeveringWijze);
                    command.Parameters.AddWithValue("@Loswijze", agendaLeveringenDO.Loswijze);
                    command.Parameters.AddWithValue("@Comment", agendaLeveringenDO.Comment);
                    command.Parameters.AddWithValue("@bestelID", agendaLeveringenDO.BestellingDO.ID);
                    agendaLeveringenDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return agendaLeveringenDO;
                }
            }
        }

        #endregion

        #endregion

        #region website

        #region klant
        public static List<KlantDO> KrijgAlleKlantenWebsite()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from klant;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<KlantDO> klantDOs = new List<KlantDO>();

                    while (reader.Read())
                    {
                        KlantDO klantDO = new KlantDO();
                        {
                            klantDO.ID = Convert.ToInt32(reader["ID"]);
                            klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                            klantDO.Naam = reader["naam"].ToString();

                            string adres = reader["adres"].ToString();
                            string gemeente = reader["gemeente"].ToString();
                            string postcode = reader["postcode"].ToString();
                            string gsm = reader["gsm"].ToString();
                            string telefoon = reader["telefoon"].ToString();
                            string email = reader["email"].ToString();
                            string fax = reader["fax"].ToString();
                            string btw = reader["btw"].ToString();
                            string buitenlandsebtw = reader["buitenlandseBTW"].ToString();

                            if (adres != null)
                            {
                                klantDO.Adres = adres;
                            }
                            else
                            {
                                klantDO.Adres = "";
                            }
                            if (gemeente != null)
                            {
                                klantDO.Gemeente = gemeente;
                            }
                            else
                            {
                                klantDO.Gemeente = "";
                            }
                            if (postcode != null)
                            {
                                klantDO.Postcode = postcode;
                            }
                            else
                            {
                                klantDO.Postcode = "";
                            }
                            if (gsm != null)
                            {
                                klantDO.Gsm = gsm;
                            }
                            else
                            {
                                klantDO.Gsm = "";
                            }
                            if (telefoon != null)
                            {
                                klantDO.Telefoon = telefoon;
                            }
                            else
                            {
                                klantDO.Telefoon = "";
                            }
                            if (email != null)
                            {
                                klantDO.Email = email;
                            }
                            else
                            {
                                klantDO.Email = "";
                            }
                            if (fax != null)
                            {
                                klantDO.Fax = fax;
                            }
                            else
                            {
                                klantDO.Fax = "";
                            }
                            if (btw != null)
                            {
                                klantDO.Btw = btw;
                            }
                            else
                            {
                                klantDO.Btw = "";
                            }
                            if (buitenlandsebtw != null)
                            {
                                klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                            }
                            else
                            {
                                klantDO.BuitenlandseBtw = "";
                            }

                            klantDOs.Add(klantDO);
                        }
                    }
                    connection.Close();
                    return klantDOs;
                }
            }
        }
        private static KlantDO GetKlantByIDWebsite(int ID)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {
                using (SqlCommand command = new SqlCommand("select * from klant where ID=@ID;", connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KlantDO klantDO = new KlantDO();
                        while (reader.Read())
                        {

                            {
                                klantDO.ID = Convert.ToInt32(reader["ID"]);
                                klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                                klantDO.Naam = reader["naam"].ToString();

                                string adres = reader["adres"].ToString();
                                string gemeente = reader["gemeente"].ToString();
                                string postcode = reader["postcode"].ToString();
                                string gsm = reader["gsm"].ToString();
                                string telefoon = reader["telefoon"].ToString();
                                string email = reader["email"].ToString();
                                string fax = reader["fax"].ToString();
                                string btw = reader["btw"].ToString();
                                string buitenlandsebtw = reader["buitenlandseBTW"].ToString();

                                if (adres != null)
                                {
                                    klantDO.Adres = adres;
                                }
                                else
                                {
                                    klantDO.Adres = "";
                                }
                                if (gemeente != null)
                                {
                                    klantDO.Gemeente = gemeente;
                                }
                                else
                                {
                                    klantDO.Gemeente = "";
                                }
                                if (postcode != null)
                                {
                                    klantDO.Postcode = postcode;
                                }
                                else
                                {
                                    klantDO.Postcode = "";
                                }
                                if (gsm != null)
                                {
                                    klantDO.Gsm = gsm;
                                }
                                else
                                {
                                    klantDO.Gsm = "";
                                }
                                if (telefoon != null)
                                {
                                    klantDO.Telefoon = telefoon;
                                }
                                else
                                {
                                    klantDO.Telefoon = "";
                                }
                                if (email != null)
                                {
                                    klantDO.Email = email;
                                }
                                else
                                {
                                    klantDO.Email = "";
                                }
                                if (fax != null)
                                {
                                    klantDO.Fax = fax;
                                }
                                else
                                {
                                    klantDO.Fax = "";
                                }
                                if (btw != null)
                                {
                                    klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.Btw = "";
                                }
                                if (buitenlandsebtw != null)
                                {
                                    klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.BuitenlandseBtw = "";
                                }

                            }

                        }
                        connection.Close();
                        return klantDO;
                    }
                }
            }
        }
        public static List<WerfDO> KrijgAlleWervenDoorKlantIDWebsite(int klantID)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from werf where klantID=@klantID;", connection))
                {
                    command.Parameters.AddWithValue("@klantID", klantID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<WerfDO> werfDOs = new List<WerfDO>();

                        while (reader.Read())
                        {
                            WerfDO werfDO = new WerfDO();
                            {
                                werfDO.ID = Convert.ToInt32(reader["ID"]);
                                werfDO.KlantDO = GetKlantByIDWebsite(Convert.ToInt32(reader["klantID"]));
                                werfDO.Adres = reader["adres"].ToString();
                                werfDO.Gemeente = reader["gemeente"].ToString();
                                werfDO.Postcode = reader["postcode"].ToString();
                                werfDO.Telefoon = reader["telefoon"].ToString();

                                werfDOs.Add(werfDO);
                            }

                        }
                        connection.Close();
                        return werfDOs;
                    }
                }
            }
        }

        public static List<PostcodeGemeenteDO> KrijgAllePostcodeGemeentesWebsite()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from PostcodePerGemeente;", connection))


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<PostcodeGemeenteDO> PostcodeGemeenteDOs = new List<PostcodeGemeenteDO>();

                    while (reader.Read())
                    {
                        PostcodeGemeenteDO postcodeGemeenteDO = new PostcodeGemeenteDO();
                        {
                            postcodeGemeenteDO.ID = Convert.ToInt32(reader["ID"]);
                            postcodeGemeenteDO.Postcode = reader["Postcode"].ToString();
                            postcodeGemeenteDO.Gemeente = reader["Gemeente"].ToString();


                            PostcodeGemeenteDOs.Add(postcodeGemeenteDO);
                        }

                    }
                    connection.Close();
                    return PostcodeGemeenteDOs;
                }
            }
        }

        public static KlantDO krijgKlantDoorKlantNummerWebsite(int klantNummer)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {

                using (SqlCommand command = new SqlCommand("select * from klant where nummer=@klantNummer;", connection))
                {
                    command.Parameters.AddWithValue("@klantNummer", klantNummer);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        KlantDO klantDO = new KlantDO();
                        while (reader.Read())
                        {

                            {
                                klantDO.ID = Convert.ToInt32(reader["ID"]);
                                klantDO.Nummer = Convert.ToInt32(reader["nummer"]);
                                klantDO.Naam = reader["naam"].ToString();

                                string adres = reader["adres"].ToString();
                                string gemeente = reader["gemeente"].ToString();
                                string postcode = reader["postcode"].ToString();
                                string gsm = reader["gsm"].ToString();
                                string telefoon = reader["telefoon"].ToString();
                                string email = reader["email"].ToString();
                                string fax = reader["fax"].ToString();
                                string btw = reader["btw"].ToString();
                                string buitenlandsebtw = reader["buitenlandseBTW"].ToString();

                                if (adres != null)
                                {
                                    klantDO.Adres = adres;
                                }
                                else
                                {
                                    klantDO.Adres = "";
                                }
                                if (gemeente != null)
                                {
                                    klantDO.Gemeente = gemeente;
                                }
                                else
                                {
                                    klantDO.Gemeente = "";
                                }
                                if (postcode != null)
                                {
                                    klantDO.Postcode = postcode;
                                }
                                else
                                {
                                    klantDO.Postcode = "";
                                }
                                if (gsm != null)
                                {
                                    klantDO.Gsm = gsm;
                                }
                                else
                                {
                                    klantDO.Gsm = "";
                                }
                                if (telefoon != null)
                                {
                                    klantDO.Telefoon = telefoon;
                                }
                                else
                                {
                                    klantDO.Telefoon = "";
                                }
                                if (email != null)
                                {
                                    klantDO.Email = email;
                                }
                                else
                                {
                                    klantDO.Email = "";
                                }
                                if (fax != null)
                                {
                                    klantDO.Fax = fax;
                                }
                                else
                                {
                                    klantDO.Fax = "";
                                }
                                if (btw != null)
                                {
                                    klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.Btw = "";
                                }
                                if (buitenlandsebtw != null)
                                {
                                    klantDO.BuitenlandseBtw = klantDO.Btw = btw;
                                }
                                else
                                {
                                    klantDO.BuitenlandseBtw = "";
                                }

                            }

                        }
                        connection.Close();
                        return klantDO;
                    }
                }
            }
        }
        public static AccountDO MaakNieuweAccountWebsite(AccountDO accountDO)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("insert into Account (KlantNummer,wachtwoord,email,userlevel) values(@KlantNummer,@wachtwoord,@email,@userlevel);",
                            connection))
                {
                    command.Parameters.AddWithValue("@KlantNummer", accountDO.KlantNummer);
                    command.Parameters.AddWithValue("@wachtwoord", accountDO.Wachtwoord);
                    command.Parameters.AddWithValue("@email", accountDO.Email);
                    command.Parameters.AddWithValue("@userlevel", accountDO.Userlevel);
                    accountDO.ID = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return accountDO;
                }
            }
        }
        public static AccountDO KrijgAccountDoorKlantNummerEnWachtwoordWebsite(int klantnummer, string wachtwoord)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=sql2014-1.mijnhostingpartner.nl;Initial Catalog=Dhuyvetbestelling;User ID=Dhuyvetgilles;Password=Elon!1996;"))
            {
                using (SqlCommand command = new SqlCommand("select ID, KlantNummer, wachtwoord , Email, Userlevel from Account where KlantNummer = @KlantNummer and wachtwoord = @wachtwoord",
                           connection))
                {
                    command.Parameters.AddWithValue("@klantNummer", klantnummer);
                    command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        AccountDO accountDO = new AccountDO();
                        while (reader.Read())
                        {
                            accountDO = new AccountDO(
                                Convert.ToInt32(reader["ID"]),
                                Convert.ToInt32(reader["klantNummer"]),
                                reader["wachtwoord"].ToString(),
                                reader["Email"].ToString(),
                                Convert.ToByte(reader["Userlevel"]));
                        }
                        return accountDO;
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}


