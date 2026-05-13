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
    public class Factuur
    {
        #region Variables

        private int id;
        private Klant klant;
        private string factuurNummer;
        private DateTime datum;
        private double totaalExclBtw;
        private double totaalVerlegd;
        private double totaalIncl6Btw;
        private double totaalIncl21Btw;
        private double totaal;
        private byte controle;
      
        #endregion

        #region Properties
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
        public string FactuurNummer
        {
            get { return factuurNummer; }
            set { factuurNummer = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public double TotaalExclBtw
        {
            get { return totaalExclBtw; }
            set { totaalExclBtw = value; }
        }
        public double TotaalVerlegd
        {
            get { return totaalVerlegd; }
            set { totaalVerlegd = value; }
        }

     

        public double TotaalIncl6Btw
        {
            get { return totaalIncl6Btw; }
            set { totaalIncl6Btw = value; }
        }
        public double TotaalIncl21Btw
        {
            get { return totaalIncl21Btw; }
            set { totaalIncl21Btw = value; }
        }
        public double Totaal
        {
            get { return totaal; }
            set { totaal = value; }
        }
        public byte Controle
        {
            get { return controle; }
            set { controle = value; }
        }
        #endregion

        #region Contructors
        public Factuur()
        {

        }
        public Factuur(Klant klant,string factuurNummer,DateTime datum, double totaalExclBtw,double totaalVerlegd, double totaalIncl6Btw, double totaalIncl21Btw, double totaal, byte controle)
        {
            Klant = klant;
            FactuurNummer = factuurNummer;
            Datum = datum;
            TotaalExclBtw = totaalExclBtw;
            TotaalVerlegd = totaalVerlegd;
            TotaalIncl6Btw = totaalIncl6Btw;
            TotaalIncl21Btw = totaalIncl21Btw;
            Totaal = totaal;
            Controle = controle;
        }
        public Factuur(int id, Klant klant, string factuurNummer, DateTime datum, double totaalExclBtw, double btwVerlegd, double totaalIncl6Btw, double totaalIncl21Btw, double totaal, byte controle)
            :this(klant,factuurNummer,datum, totaalExclBtw,btwVerlegd,totaalIncl6Btw,totaalIncl21Btw,totaal,controle)
        {
            ID = id;
        }


        #endregion
        public override string ToString()
        {
            return factuurNummer + " - " + klant.Naam + " "+ datum.ToShortDateString() ;
        }
        #region Methods
        public static Factuur ConvertFromDO(FactuurDO factuurDO)
        {
            Factuur factuur = new Factuur(factuurDO.ID, Klant.ConvertFromDO(factuurDO.KlantDO),factuurDO.FactuurNummer, factuurDO.Datum,factuurDO.TotaalExclBtw,factuurDO.TotaalVerlegd,factuurDO.TotaalIncl6Btw,factuurDO.TotaalIncl21Btw,factuurDO.Totaal,factuurDO.Controle);

            return factuur;
        }
        public static List<Factuur> KrijgAlleAfgekeurdeFacturen()
        {
            List<FactuurDO> FactuurDOs = DataAccess.KrijgAfgekeurdeFacturen();
            List<Factuur> Factuurs = new List<Factuur>();
            foreach (FactuurDO factuurDO in FactuurDOs)
            {
                Factuurs.Add(ConvertFromDO(factuurDO));
            }
            return Factuurs;
        }


        public FactuurDO ConvertToDO(Factuur factuur)
        {
            FactuurDO factuurDO = new FactuurDO(ID, Klant.ConvertToDO(klant),FactuurNummer,Datum,TotaalExclBtw,TotaalVerlegd,TotaalIncl6Btw,TotaalIncl21Btw,Totaal,Controle);

            return factuurDO;
        }
        public void MaakNieuweFactuur()
        {
            FactuurDO factuurDO = DataAccess.MaakNieuweFactuur(ConvertToDO(this));
        }
        public void wijzigFactuur()
        {
            FactuurDO factuurDO = DataAccess.WijzigFactuur(ConvertToDO(this));
        }
        public static Factuur KrijgFactuurViaFactuurNummer(string FactuurNummer)
        {
            FactuurDO factuurDO = DataAccess.krijgFactuurDoorFactuurNummer(FactuurNummer);
            Factuur factuur = ConvertFromDO(factuurDO);
            return factuur;
        }
        public static Factuur KrijgLaatsteFactuur()
        {
            FactuurDO factuurDO = DataAccess.KrijgLaatsteFactuur();
            Factuur factuur = ConvertFromDO(factuurDO);
            return factuur;
        }
        public void GeneerFactuurExcell(int factuurID)
        {
            #region listing
            Dictionary<string, object> cellenDictionary = new Dictionary<string, object>();
            List<Factuur_Item> factuur_Items = Factuur_Item.krijgAlleFactuurItemsDoorFactuurID(factuurID);
         
            factuur_Items.Sort((x, y) => x.BestelDatum.CompareTo(y.BestelDatum));
            #endregion

            #region wegschrijven Klant

            string laatste3Chars = Klant.Naam.Substring(Klant.Naam.Length - 3);
            if (laatste3Chars.Contains("BTW") || laatste3Chars.Contains("btw"))
            {
                string klantnaam = klant.Naam;
                string naamCorrect = klantnaam.Remove(klantnaam.Length - 3);
                cellenDictionary.Add("D7", naamCorrect);
            }
            else
            {
                cellenDictionary.Add("D7", Klant.Naam);
            }
          
            cellenDictionary.Add("D9", Klant.Adres);
            cellenDictionary.Add("D11", Klant.Postcode + " " + Klant.Gemeente);
            //cellenDictionary.Add("B6", Klant.Gsm);
            if(klant.Btw != string.Empty && klant.Btw.Contains("BE")) { cellenDictionary.Add("D13", Klant.Btw); }
            else if (klant.Btw != string.Empty && klant.Btw.Contains("FR")) { cellenDictionary.Add("D13", Klant.Btw); }
            else if (klant.Btw != string.Empty) { cellenDictionary.Add("D13", "BE" + Klant.Btw); }



            #endregion

            #region FactuurNummer
            cellenDictionary.Add("A17", "Factuurnummer : " + factuurNummer);
            cellenDictionary.Add("D15", "Avelgem, " + datum.Date.ToShortDateString());
            cellenDictionary.Add("A18", "Klantennummer : " + klant.Nummer.ToString());
            #endregion

            #region Aantal items
            void FactuurItem1()
            {
                #region werfdetail 

                cellenDictionary.Add("A20", factuur_Items[0].Werf.Gemeente + " " + factuur_Items[0].BestelDatum.Day + "/" + factuur_Items[0].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A21", factuur_Items[0].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[0].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[0].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[0].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[0].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[0].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[0].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[0].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[0].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[0].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[0].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[0].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[0].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[0].OmschrijvingProduct.Formule == "2" || factuur_Items[0].OmschrijvingProduct.Formule == "pousse" || factuur_Items[0].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B21", "Ton");
                }
                else if (factuur_Items[0].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B21", "Liter");
                }
                else if (factuur_Items[0].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B21", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B21", "M3");
                }
                
                cellenDictionary.Add("C21", factuur_Items[0].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D21", factuur_Items[0].EenheidsPrijs.ToString());
                cellenDictionary.Add("E21", factuur_Items[0].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[0].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A22", "Onvolledige lading");
                    cellenDictionary.Add("B22", "M3");
                    cellenDictionary.Add("C22", factuur_Items[0].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D22", "20");
                    cellenDictionary.Add("E22", factuur_Items[0].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = new List<Hulpstof_Factuur_Item>();
                hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[0].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A23", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B23", "M3");
                    cellenDictionary.Add("C23", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D23", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E23", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A23", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B23", "M3");
                    cellenDictionary.Add("C23", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D23", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E23", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A24", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B24", "M3");
                    cellenDictionary.Add("C24", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D24", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E24", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[0].PompPrijs.Bedrag != 0 && factuur_Items[0].GepompteM3 != 0) 
                {
                    cellenDictionary.Add("A25", "Pomp " + factuur_Items[0].PompPrijs.Giek);
                    cellenDictionary.Add("B25", " FF");
                    cellenDictionary.Add("C25", 1);
                    cellenDictionary.Add("D25", factuur_Items[0].PompPrijs.Bedrag);
                    cellenDictionary.Add("E25", factuur_Items[0].PompPrijs.Bedrag);
                    cellenDictionary.Add("A26", "Gepompte M3 ");
                    cellenDictionary.Add("B26", "M3");
                    cellenDictionary.Add("C26", factuur_Items[0].GepompteM3);
                    cellenDictionary.Add("D26", factuur_Items[0].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E26", factuur_Items[0].PompTotaalSuplimentPrijs);
                    if (factuur_Items[0].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A27", "Wachttijd pomp");
                        cellenDictionary.Add("B27", "Minuten");
                        cellenDictionary.Add("C27", ((factuur_Items[0].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D27", "1,20");
                        cellenDictionary.Add("E27", factuur_Items[0].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[0].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A28", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B28", "Minuten ");
                    cellenDictionary.Add("C28", ((factuur_Items[0].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D28", "1,20");
                    cellenDictionary.Add("E28", factuur_Items[0].LaadEnLosTijdenTotaal.ToString());
                    
                }
                #endregion

                #region Transport
                if (factuur_Items[0].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A29", "Transport");
                    cellenDictionary.Add("B29", "FF");
                    cellenDictionary.Add("C29", "1");
                    cellenDictionary.Add("D29", "0");
                    cellenDictionary.Add("E29", factuur_Items[0].TransportTotaal.ToString());

                }
                #endregion
            }
            void FactuurItem2()
            {
                #region werfdetail 

                cellenDictionary.Add("A30", factuur_Items[1].Werf.Gemeente + " " + factuur_Items[1].BestelDatum.Day + "/" + factuur_Items[1].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A31", factuur_Items[1].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[1].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[1].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[1].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[1].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[1].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[1].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[1].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[1].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[1].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[1].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[1].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[1].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[1].OmschrijvingProduct.Formule == "2" || factuur_Items[1].OmschrijvingProduct.Formule == "pousse" || factuur_Items[1].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B31", "Ton");
                }
                else if (factuur_Items[1].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B31", "Liter");
                }
                else if (factuur_Items[1].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B31", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B31", "M3");
                }
              
                cellenDictionary.Add("C31", factuur_Items[1].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D31", factuur_Items[1].EenheidsPrijs.ToString());
                cellenDictionary.Add("E31", factuur_Items[1].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[1].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A32", "Onvolledige lading");
                    cellenDictionary.Add("B32", "M3");
                    cellenDictionary.Add("C32", factuur_Items[1].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D32", "20");
                    cellenDictionary.Add("E32", factuur_Items[1].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = new List<Hulpstof_Factuur_Item>();
                hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[1].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A33", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B33", "M3");
                    cellenDictionary.Add("C33", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D33", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E33", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A33", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B33", "M3");
                    cellenDictionary.Add("C33", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D33", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E33", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A34", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B34", "M3");
                    cellenDictionary.Add("C34", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D34", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E34", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[1].PompPrijs.Bedrag != 0 && factuur_Items[1].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A35", "Pomp " + factuur_Items[1].PompPrijs.Giek);
                    cellenDictionary.Add("B35", " FF");
                    cellenDictionary.Add("C35", 1);
                    cellenDictionary.Add("D35", factuur_Items[1].PompPrijs.Bedrag);
                    cellenDictionary.Add("E35", factuur_Items[1].PompPrijs.Bedrag);
                    cellenDictionary.Add("A36", "Gepompte M3 ");
                    cellenDictionary.Add("B36", "M3");
                    cellenDictionary.Add("C36", factuur_Items[1].GepompteM3);
                    cellenDictionary.Add("D36", factuur_Items[1].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E36", factuur_Items[1].PompTotaalSuplimentPrijs);
                    if (factuur_Items[1].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A37", "Wachttijd pomp");
                        cellenDictionary.Add("B37", "Minuten");
                        cellenDictionary.Add("C37", ((factuur_Items[1].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D37", "1,20");
                        cellenDictionary.Add("E37", factuur_Items[1].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[1].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A38", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B38", "Minuten ");
                    cellenDictionary.Add("C38", ((factuur_Items[1].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D38", "1,20");
                    cellenDictionary.Add("E38", factuur_Items[1].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[1].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A39", "Transport");
                    cellenDictionary.Add("B39", "FF");
                    cellenDictionary.Add("C39", "1");
                    cellenDictionary.Add("D39", "0");
                    cellenDictionary.Add("E39", factuur_Items[1].TransportTotaal.ToString());

                }
                #endregion
            }
            void FactuurItem3()
            {
                #region werfdetail 

                cellenDictionary.Add("A40", factuur_Items[2].Werf.Gemeente + " " + factuur_Items[2].BestelDatum.Day + "/" + factuur_Items[2].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A41", factuur_Items[2].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[2].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[2].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[2].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[2].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[2].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[2].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[2].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[2].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[2].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[2].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[2].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[2].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[2].OmschrijvingProduct.Formule == "2" || factuur_Items[2].OmschrijvingProduct.Formule == "pousse" || factuur_Items[2].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B41", "Ton");
                }
                else if (factuur_Items[2].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B41", "Liter");
                }
                else if (factuur_Items[2].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B41", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B41", "M3");
                }
          
                cellenDictionary.Add("C41", factuur_Items[2].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D41", factuur_Items[2].EenheidsPrijs.ToString());
                cellenDictionary.Add("E41", factuur_Items[2].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[2].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A42", "Onvolledige lading");
                    cellenDictionary.Add("B42", "M3");
                    cellenDictionary.Add("C42", factuur_Items[2].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D42", "20");
                    cellenDictionary.Add("E42", factuur_Items[2].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[2].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A43", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B43", "M3");
                    cellenDictionary.Add("C43", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D43", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E43", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A43", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B43", "M3");
                    cellenDictionary.Add("C43", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D43", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E43", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A44", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B44", "M3");
                    cellenDictionary.Add("C44", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D44", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E44", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[2].PompPrijs.Bedrag != 0 && factuur_Items[2].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A45", "Pomp " + factuur_Items[2].PompPrijs.Giek);
                    cellenDictionary.Add("B45", " FF");
                    cellenDictionary.Add("C45", 1);
                    cellenDictionary.Add("D45", factuur_Items[2].PompPrijs.Bedrag);
                    cellenDictionary.Add("E45", factuur_Items[2].PompPrijs.Bedrag);
                    cellenDictionary.Add("A46", "Gepompte M3 ");
                    cellenDictionary.Add("B46", "M3");
                    cellenDictionary.Add("C46", factuur_Items[2].GepompteM3);
                    cellenDictionary.Add("D46", factuur_Items[2].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E46", factuur_Items[2].PompTotaalSuplimentPrijs);
                    if (factuur_Items[2].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A47", "Wachttijd pomp");
                        cellenDictionary.Add("B47", "Minuten");
                        cellenDictionary.Add("C47", ((factuur_Items[2].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D47", "1,20");
                        cellenDictionary.Add("E47", factuur_Items[2].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[2].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A48", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B48", "Minuten ");
                    cellenDictionary.Add("C48", ((factuur_Items[2].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D48", "1,20");
                    cellenDictionary.Add("E48", factuur_Items[2].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[2].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A49", "Transport");
                    cellenDictionary.Add("B49", "FF");
                    cellenDictionary.Add("C49", "1");
                    cellenDictionary.Add("D49", "0");
                    cellenDictionary.Add("E49", factuur_Items[2].TransportTotaal.ToString());

                }
                #endregion
            }
            void FactuurItem4()
            {
                #region werfdetail 

                cellenDictionary.Add("A50", factuur_Items[3].Werf.Gemeente + " " + factuur_Items[3].BestelDatum.Day + "/" + factuur_Items[3].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A51", factuur_Items[3].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[3].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[3].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[3].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[3].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[3].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[3].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[3].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[3].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[3].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[3].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[3].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[3].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[3].OmschrijvingProduct.Formule == "2" || factuur_Items[3].OmschrijvingProduct.Formule == "pousse" || factuur_Items[3].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B51", "Ton");
                }
                else if (factuur_Items[3].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B51", "Liter");
                }
                else if (factuur_Items[3].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B51", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B51", "M3");
                }
                cellenDictionary.Add("C51", factuur_Items[3].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D51", factuur_Items[3].EenheidsPrijs.ToString());
                cellenDictionary.Add("E51", factuur_Items[3].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[3].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A52", "Onvolledige lading");
                    cellenDictionary.Add("B52", "M3");
                    cellenDictionary.Add("C52", factuur_Items[3].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D52", "20");
                    cellenDictionary.Add("E52", factuur_Items[3].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[3].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A53", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B53", "M3");
                    cellenDictionary.Add("C53", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D53", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E53", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A53", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B53", "M3");
                    cellenDictionary.Add("C53", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D53", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E53", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A54", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B54", "M3");
                    cellenDictionary.Add("C54", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D54", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E54", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[3].PompPrijs.Bedrag != 0 && factuur_Items[3].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A55", "Pomp " + factuur_Items[3].PompPrijs.Giek);
                    cellenDictionary.Add("B55", " FF");
                    cellenDictionary.Add("C55", 1);
                    cellenDictionary.Add("D55", factuur_Items[3].PompPrijs.Bedrag);
                    cellenDictionary.Add("E55", factuur_Items[3].PompPrijs.Bedrag);
                    cellenDictionary.Add("A56", "Gepompte M3 ");
                    cellenDictionary.Add("B56", "M3");
                    cellenDictionary.Add("C56", factuur_Items[3].GepompteM3);
                    cellenDictionary.Add("D56", factuur_Items[3].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E56", factuur_Items[3].PompTotaalSuplimentPrijs);
                    if (factuur_Items[3].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A57", "Wachttijd pomp");
                        cellenDictionary.Add("B57", "Minuten");
                        cellenDictionary.Add("C57", ((factuur_Items[3].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D57", "1,20");
                        cellenDictionary.Add("E57", factuur_Items[3].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[3].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A58", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B58", "Minuten ");
                    cellenDictionary.Add("C58", ((factuur_Items[3].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D58", "1,20");
                    cellenDictionary.Add("E58", factuur_Items[3].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[3].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A59", "Transport");
                    cellenDictionary.Add("B59", "FF");
                    cellenDictionary.Add("C59", "1");
                    cellenDictionary.Add("D59", "0");
                    cellenDictionary.Add("E59", factuur_Items[3].TransportTotaal.ToString());

                }
                #endregion
            }
            void FactuurItem5()
            {
                #region werfdetail 

                cellenDictionary.Add("A60", factuur_Items[4].Werf.Gemeente + " " + factuur_Items[4].BestelDatum.Day + "/" + factuur_Items[4].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A61", factuur_Items[4].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[4].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[4].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[4].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[4].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[4].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[4].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[4].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[4].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[4].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[4].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[4].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[4].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[4].OmschrijvingProduct.Formule == "2" || factuur_Items[4].OmschrijvingProduct.Formule == "pousse" || factuur_Items[4].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B61", "Ton");
                }
                else if (factuur_Items[4].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B61", "Liter");
                }
                else if (factuur_Items[4].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B61", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B61", "M3");
                }
               
                cellenDictionary.Add("C61", factuur_Items[4].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D61", factuur_Items[4].EenheidsPrijs.ToString());
                cellenDictionary.Add("E61", factuur_Items[4].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[4].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A62", "Onvolledige lading");
                    cellenDictionary.Add("B62", "M3");
                    cellenDictionary.Add("C62", factuur_Items[4].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D62", "20");
                    cellenDictionary.Add("E62", factuur_Items[4].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[4].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A63", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B63", "M3");
                    cellenDictionary.Add("C63", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D63", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E63", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A63", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B63", "M3");
                    cellenDictionary.Add("C63", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D63", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E63", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A64", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B64", "M3");
                    cellenDictionary.Add("C64", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D64", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E64", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[4].PompPrijs.Bedrag != 0 && factuur_Items[4].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A65", "Pomp " + factuur_Items[4].PompPrijs.Giek);
                    cellenDictionary.Add("B65", " FF");
                    cellenDictionary.Add("C65", 1);
                    cellenDictionary.Add("D65", factuur_Items[4].PompPrijs.Bedrag);
                    cellenDictionary.Add("E65", factuur_Items[4].PompPrijs.Bedrag);
                    cellenDictionary.Add("A66", "Gepompte M3 ");
                    cellenDictionary.Add("B66", "M3");
                    cellenDictionary.Add("C66", factuur_Items[4].GepompteM3);
                    cellenDictionary.Add("D66", factuur_Items[4].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E66", factuur_Items[4].PompTotaalSuplimentPrijs);
                    if (factuur_Items[4].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A67", "Wachttijd pomp");
                        cellenDictionary.Add("B67", "Minuten");
                        cellenDictionary.Add("C67", ((factuur_Items[4].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D67", "1,20");
                        cellenDictionary.Add("E67", factuur_Items[4].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[4].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A68", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B68", "Minuten ");
                    cellenDictionary.Add("C68", ((factuur_Items[4].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D68", "1,20");
                    cellenDictionary.Add("E68", factuur_Items[4].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[4].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A69", "Transport");
                    cellenDictionary.Add("B69", "FF");
                    cellenDictionary.Add("C69", "1");
                    cellenDictionary.Add("D69", "0");
                    cellenDictionary.Add("E69", factuur_Items[4].TransportTotaal.ToString());

                }
                #endregion
            }
            void FactuurItem6()
                {
                    #region werfdetail 

                    cellenDictionary.Add("A70", factuur_Items[5].Werf.Gemeente + " " + factuur_Items[5].BestelDatum.Day + "/" + factuur_Items[5].BestelDatum.Month);
                    #endregion

                    #region productOmschrijving
                    cellenDictionary.Add("A71", factuur_Items[5].OmschrijvingProduct.Omschrijving);
                    if (factuur_Items[5].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[5].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[5].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[5].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[5].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[5].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[5].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[5].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[5].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[5].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[5].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[5].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[5].OmschrijvingProduct.Formule == "2" || factuur_Items[5].OmschrijvingProduct.Formule == "pousse" || factuur_Items[5].OmschrijvingProduct.Formule == "9 6/20")
                    {
                        cellenDictionary.Add("B71", "Ton");
                    }
                    else if (factuur_Items[5].OmschrijvingProduct.Formule == "Mortel")
                    {
                        cellenDictionary.Add("B71", "Liter");
                    }
                    else if (factuur_Items[5].OmschrijvingProduct.Formule == "betonblokken")
                    {
                        cellenDictionary.Add("B71", "Stuk");
                    }
                    else
                    {
                        cellenDictionary.Add("B71", "M3");
                    }

                    cellenDictionary.Add("C71", factuur_Items[5].HoeveelheidProduct.ToString());
                    cellenDictionary.Add("D71", factuur_Items[5].EenheidsPrijs.ToString());
                    cellenDictionary.Add("E71", factuur_Items[5].ProductPrijs.ToString());
                    #endregion

                    #region onvolledigelading
                    if (factuur_Items[5].Onvolledige_Lading_Hoeveelheid != 0)
                    {
                        cellenDictionary.Add("A72", "Onvolledige lading");
                        cellenDictionary.Add("B72", "M3");
                        cellenDictionary.Add("C72", factuur_Items[5].Onvolledige_Lading_Hoeveelheid);
                        cellenDictionary.Add("D72", "20");
                        cellenDictionary.Add("E72", factuur_Items[5].Onvolledige_Lading_Prijs);
                    }
                    #endregion

                    #region hulpstoffen
                    List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[5].ID);
                    if (hulpstof_Factuur_Items.Count == 1)
                    {
                        cellenDictionary.Add("A73", hulpstof_Factuur_Items[0].Hulpstof);
                        cellenDictionary.Add("B73", "M3");
                        cellenDictionary.Add("C73", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                        cellenDictionary.Add("D73", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                        cellenDictionary.Add("E73", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    }
                    else if (hulpstof_Factuur_Items.Count == 2)
                    {
                        #region hulpstof1
                        cellenDictionary.Add("A73", hulpstof_Factuur_Items[0].Hulpstof);
                        cellenDictionary.Add("B73", "M3");
                        cellenDictionary.Add("C73", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                        cellenDictionary.Add("D73", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                        cellenDictionary.Add("E73", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                        #endregion

                        #region hulpstof2
                        cellenDictionary.Add("A74", hulpstof_Factuur_Items[1].Hulpstof);
                        cellenDictionary.Add("B74", "M3");
                        cellenDictionary.Add("C74", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                        cellenDictionary.Add("D74", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                        cellenDictionary.Add("E74", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                        #endregion
                    }

                    #endregion

                    #region pomp

                    if (factuur_Items[5].PompPrijs.Bedrag != 0  && factuur_Items[5].GepompteM3 != 0)
                    {
                        cellenDictionary.Add("A75", "Pomp " + factuur_Items[5].PompPrijs.Giek);
                        cellenDictionary.Add("B75", " FF");
                        cellenDictionary.Add("C75", 1);
                        cellenDictionary.Add("D75", factuur_Items[5].PompPrijs.Bedrag);
                        cellenDictionary.Add("E75", factuur_Items[5].PompPrijs.Bedrag);
                        cellenDictionary.Add("A76", "Gepompte M3 ");
                        cellenDictionary.Add("B76", "M3");
                        cellenDictionary.Add("C76", factuur_Items[5].GepompteM3);
                        cellenDictionary.Add("D76", factuur_Items[5].PompSuplimentEenheidsPrijs);
                        cellenDictionary.Add("E76", factuur_Items[5].PompTotaalSuplimentPrijs);
                        if (factuur_Items[5].PompWachtTijd != 0)
                        {
                            cellenDictionary.Add("A77", "Wachttijd pomp");
                            cellenDictionary.Add("B77", "Minuten");
                            cellenDictionary.Add("C77", ((factuur_Items[5].PompWachtTijd / 1.35).ToString()));
                            cellenDictionary.Add("D77", "1,20");
                            cellenDictionary.Add("E77", factuur_Items[5].PompWachtTijd);
                        }
                    }
                    #endregion

                    #region laadenlostijdenmixer
                    if (factuur_Items[5].LaadEnLosTijdenTotaal != 0)
                    {
                        cellenDictionary.Add("A78", "Laad en los tijden mixer ");
                        cellenDictionary.Add("B78", "Minuten ");
                        cellenDictionary.Add("C78", ((factuur_Items[5].LaadEnLosTijdenTotaal / 1.2).ToString()));
                        cellenDictionary.Add("D78", "1,20");
                        cellenDictionary.Add("E78", factuur_Items[5].LaadEnLosTijdenTotaal.ToString());

                    }
                    #endregion

                    #region Transport
                    if (factuur_Items[5].TransportTotaal != 0)
                    {
                        cellenDictionary.Add("A79", "Transport");
                        cellenDictionary.Add("B79", "FF");
                        cellenDictionary.Add("C79", "1");
                        cellenDictionary.Add("D79", "0");
                        cellenDictionary.Add("E79", factuur_Items[5].TransportTotaal.ToString());

                    }
                    #endregion
                
                }
            void FactuurItem7()
            {
                #region werfdetail 

                cellenDictionary.Add("A90", factuur_Items[6].Werf.Gemeente + " " + factuur_Items[6].BestelDatum.Day + "/" + factuur_Items[6].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A91", factuur_Items[6].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[6].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[6].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[6].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[6].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[6].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[6].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[6].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[6].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[6].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[6].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[6].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[6].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[6].OmschrijvingProduct.Formule == "2" || factuur_Items[6].OmschrijvingProduct.Formule == "pousse" || factuur_Items[6].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B91", "Ton");
                }
                else if (factuur_Items[6].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B91", "Liter");
                }
                else if (factuur_Items[6].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B91", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B91", "M3");
                }

                cellenDictionary.Add("C91", factuur_Items[6].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D91", factuur_Items[6].EenheidsPrijs.ToString());
                cellenDictionary.Add("E91", factuur_Items[6].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[6].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A92", "Onvolledige lading");
                    cellenDictionary.Add("B92", "M3");
                    cellenDictionary.Add("C92", factuur_Items[6].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D92", "20");
                    cellenDictionary.Add("E92", factuur_Items[6].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[6].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A93", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B93", "M3");
                    cellenDictionary.Add("C93", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D93", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E93", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A93", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B93", "M3");
                    cellenDictionary.Add("C93", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D93", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E93", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A94", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B94", "M3");
                    cellenDictionary.Add("C94", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D94", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E94", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[6].PompPrijs.Bedrag != 0 && factuur_Items[6].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A95", "Pomp " + factuur_Items[6].PompPrijs.Giek);
                    cellenDictionary.Add("B95", " FF");
                    cellenDictionary.Add("C95", 1);
                    cellenDictionary.Add("D95", factuur_Items[6].PompPrijs.Bedrag);
                    cellenDictionary.Add("E95", factuur_Items[6].PompPrijs.Bedrag);
                    cellenDictionary.Add("A96", "Gepompte M3 ");
                    cellenDictionary.Add("B96", "M3");
                    cellenDictionary.Add("C96", factuur_Items[6].GepompteM3);
                    cellenDictionary.Add("D96", factuur_Items[6].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E96", factuur_Items[6].PompTotaalSuplimentPrijs);
                    if (factuur_Items[6].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A97", "Wachttijd pomp");
                        cellenDictionary.Add("B97", "Minuten");
                        cellenDictionary.Add("C97", ((factuur_Items[6].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D97", "1,20");
                        cellenDictionary.Add("E97", factuur_Items[6].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[6].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A98", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B98", "Minuten ");
                    cellenDictionary.Add("C98", ((factuur_Items[6].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D98", "1,20");
                    cellenDictionary.Add("E98", factuur_Items[6].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[6].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A99", "Transport");
                    cellenDictionary.Add("B99", "FF");
                    cellenDictionary.Add("C99", "1");
                    cellenDictionary.Add("D99", "0");
                    cellenDictionary.Add("E99", factuur_Items[6].TransportTotaal.ToString());

                }
                #endregion

            }
            void FactuurItem8()
            {
                #region werfdetail 

                cellenDictionary.Add("A100", factuur_Items[7].Werf.Gemeente + " " + factuur_Items[7].BestelDatum.Day + "/" + factuur_Items[7].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A101", factuur_Items[7].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[7].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[7].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[7].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[7].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[7].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[7].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[7].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[7].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[7].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[7].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[7].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[7].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[7].OmschrijvingProduct.Formule == "2" || factuur_Items[7].OmschrijvingProduct.Formule == "pousse" || factuur_Items[7].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B101", "Ton");
                }
                else if (factuur_Items[7].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B101", "Liter");
                }
                else if (factuur_Items[7].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B101", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B101", "M3");
                }

                cellenDictionary.Add("C101", factuur_Items[7].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D101", factuur_Items[7].EenheidsPrijs.ToString());
                cellenDictionary.Add("E101", factuur_Items[7].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[7].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A102", "Onvolledige lading");
                    cellenDictionary.Add("B102", "M3");
                    cellenDictionary.Add("C102", factuur_Items[7].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D102", "20");
                    cellenDictionary.Add("E102", factuur_Items[7].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[7].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A103", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B103", "M3");
                    cellenDictionary.Add("C103", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D103", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E103", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A103", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B103", "M3");
                    cellenDictionary.Add("C103", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D103", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E103", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A104", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B104", "M3");
                    cellenDictionary.Add("C104", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D104", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E104", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[7].PompPrijs.Bedrag != 0  && factuur_Items[7].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A105", "Pomp " + factuur_Items[7].PompPrijs.Giek);
                    cellenDictionary.Add("B105", " FF");
                    cellenDictionary.Add("C105", 1);
                    cellenDictionary.Add("D105", factuur_Items[7].PompPrijs.Bedrag);
                    cellenDictionary.Add("E105", factuur_Items[7].PompPrijs.Bedrag);
                    cellenDictionary.Add("A106", "Gepompte M3 ");
                    cellenDictionary.Add("B106", "M3");
                    cellenDictionary.Add("C106", factuur_Items[7].GepompteM3);
                    cellenDictionary.Add("D106", factuur_Items[7].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E106", factuur_Items[7].PompTotaalSuplimentPrijs);
                    if (factuur_Items[7].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A107", "Wachttijd pomp");
                        cellenDictionary.Add("B107", "Minuten");
                        cellenDictionary.Add("C107", ((factuur_Items[7].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D107", "1,20");
                        cellenDictionary.Add("E107", factuur_Items[7].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[7].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A108", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B108", "Minuten ");
                    cellenDictionary.Add("C108", ((factuur_Items[7].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D108", "1,20");
                    cellenDictionary.Add("E108", factuur_Items[7].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[7].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A109", "Transport");
                    cellenDictionary.Add("B109", "FF");
                    cellenDictionary.Add("C109", "1");
                    cellenDictionary.Add("D109", "0");
                    cellenDictionary.Add("E109", factuur_Items[7].TransportTotaal.ToString());

                }
                #endregion

            }

            void FactuurItem9()
            {
                #region werfdetail 

                cellenDictionary.Add("A110", factuur_Items[8].Werf.Gemeente + " " + factuur_Items[8].BestelDatum.Day + "/" + factuur_Items[8].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A111", factuur_Items[8].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[8].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[8].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[8].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[8].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[8].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[8].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[8].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[8].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[8].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[8].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[8].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[8].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[8].OmschrijvingProduct.Formule == "2" || factuur_Items[8].OmschrijvingProduct.Formule == "pousse" || factuur_Items[8].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B111", "Ton");
                }
                else if (factuur_Items[8].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B111", "Liter");
                }
                else if (factuur_Items[8].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B111", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B111", "M3");
                }

                cellenDictionary.Add("C111", factuur_Items[8].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D111", factuur_Items[8].EenheidsPrijs.ToString());
                cellenDictionary.Add("E111", factuur_Items[8].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[8].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A112", "Onvolledige lading");
                    cellenDictionary.Add("B112", "M3");
                    cellenDictionary.Add("C112", factuur_Items[8].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D112", "20");
                    cellenDictionary.Add("E112", factuur_Items[8].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[8].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A113", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B113", "M3");
                    cellenDictionary.Add("C113", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D113", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E113", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A113", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B113", "M3");
                    cellenDictionary.Add("C113", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D113", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E113", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A114", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B114", "M3");
                    cellenDictionary.Add("C114", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D114", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E114", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[8].PompPrijs.Bedrag != 0 && factuur_Items[1].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A115", "Pomp " + factuur_Items[8].PompPrijs.Giek);
                    cellenDictionary.Add("B115", " FF");
                    cellenDictionary.Add("C115", 1);
                    cellenDictionary.Add("D115", factuur_Items[8].PompPrijs.Bedrag);
                    cellenDictionary.Add("E115", factuur_Items[8].PompPrijs.Bedrag);
                    cellenDictionary.Add("A116", "Gepompte M3 ");
                    cellenDictionary.Add("B116", "M3");
                    cellenDictionary.Add("C116", factuur_Items[8].GepompteM3);
                    cellenDictionary.Add("D116", factuur_Items[8].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E116", factuur_Items[8].PompTotaalSuplimentPrijs);
                    if (factuur_Items[8].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A117", "Wachttijd pomp");
                        cellenDictionary.Add("B117", "Minuten");
                        cellenDictionary.Add("C117", ((factuur_Items[8].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D117", "1,20");
                        cellenDictionary.Add("E117", factuur_Items[8].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[8].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A118", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B118", "Minuten ");
                    cellenDictionary.Add("C118", ((factuur_Items[8].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D118", "1,20");
                    cellenDictionary.Add("E118", factuur_Items[8].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[8].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A119", "Transport");
                    cellenDictionary.Add("B119", "FF");
                    cellenDictionary.Add("C119", "1");
                    cellenDictionary.Add("D119", "0");
                    cellenDictionary.Add("E119", factuur_Items[8].TransportTotaal.ToString());

                }
                #endregion

            }

            void FactuurItem10()
            {
                #region werfdetail 

                cellenDictionary.Add("A120", factuur_Items[9].Werf.Gemeente + " " + factuur_Items[9].BestelDatum.Day + "/" + factuur_Items[9].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A121", factuur_Items[9].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[9].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[9].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[9].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[9].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[9].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[9].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[9].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[9].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[9].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[9].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[9].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[9].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[9].OmschrijvingProduct.Formule == "2" || factuur_Items[9].OmschrijvingProduct.Formule == "pousse" || factuur_Items[9].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B121", "Ton");
                }
                else if (factuur_Items[9].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B121", "Liter");
                }
                else if (factuur_Items[9].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B121", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B121", "M3");
                }

                cellenDictionary.Add("C121", factuur_Items[9].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D121", factuur_Items[9].EenheidsPrijs.ToString());
                cellenDictionary.Add("E121", factuur_Items[9].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[9].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A122", "Onvolledige lading");
                    cellenDictionary.Add("B122", "M3");
                    cellenDictionary.Add("C122", factuur_Items[9].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D122", "20");
                    cellenDictionary.Add("E122", factuur_Items[9].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[9].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A123", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B123", "M3");
                    cellenDictionary.Add("C123", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D123", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E123", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A123", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B123", "M3");
                    cellenDictionary.Add("C123", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D123", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E123", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A124", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B124", "M3");
                    cellenDictionary.Add("C124", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D124", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E124", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[9].PompPrijs.Bedrag != 0 && factuur_Items[9].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A125", "Pomp " + factuur_Items[9].PompPrijs.Giek);
                    cellenDictionary.Add("B125", " FF");
                    cellenDictionary.Add("C125", 1);
                    cellenDictionary.Add("D125", factuur_Items[9].PompPrijs.Bedrag);
                    cellenDictionary.Add("E125", factuur_Items[9].PompPrijs.Bedrag);
                    cellenDictionary.Add("A126", "Gepompte M3 ");
                    cellenDictionary.Add("B126", "M3");
                    cellenDictionary.Add("C126", factuur_Items[9].GepompteM3);
                    cellenDictionary.Add("D126", factuur_Items[9].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E126", factuur_Items[9].PompTotaalSuplimentPrijs);
                    if (factuur_Items[9].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A127", "Wachttijd pomp");
                        cellenDictionary.Add("B127", "Minuten");
                        cellenDictionary.Add("C127", ((factuur_Items[9].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D127", "1,20");
                        cellenDictionary.Add("E127", factuur_Items[9].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[9].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A128", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B128", "Minuten ");
                    cellenDictionary.Add("C128", ((factuur_Items[9].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D128", "1,20");
                    cellenDictionary.Add("E128", factuur_Items[9].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[9].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A129", "Transport");
                    cellenDictionary.Add("B129", "FF");
                    cellenDictionary.Add("C129", "1");
                    cellenDictionary.Add("D129", "0");
                    cellenDictionary.Add("E129", factuur_Items[9].TransportTotaal.ToString());

                }
                #endregion

            }

            void FactuurItem11()
            {
                #region werfdetail 

                cellenDictionary.Add("A130", factuur_Items[10].Werf.Gemeente + " " + factuur_Items[10].BestelDatum.Day + "/" + factuur_Items[10].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A131", factuur_Items[10].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[10].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[10].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[10].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[10].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[10].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[10].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[10].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[10].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[10].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[10].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[10].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[10].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[10].OmschrijvingProduct.Formule == "2" || factuur_Items[10].OmschrijvingProduct.Formule == "pousse" || factuur_Items[10].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B131", "Ton");
                }
                else if (factuur_Items[10].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B131", "Liter");
                }
                else if (factuur_Items[10].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B131", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B131", "M3");
                }

                cellenDictionary.Add("C131", factuur_Items[10].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D131", factuur_Items[10].EenheidsPrijs.ToString());
                cellenDictionary.Add("E131", factuur_Items[10].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[10].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A132", "Onvolledige lading");
                    cellenDictionary.Add("B132", "M3");
                    cellenDictionary.Add("C132", factuur_Items[10].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D132", "20");
                    cellenDictionary.Add("E132", factuur_Items[10].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[10].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A133", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B133", "M3");
                    cellenDictionary.Add("C133", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D133", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E133", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A133", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B133", "M3");
                    cellenDictionary.Add("C133", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D133", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E133", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A134", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B134", "M3");
                    cellenDictionary.Add("C134", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D134", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E134", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[10].PompPrijs.Bedrag != 0 && factuur_Items[10].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A135", "Pomp " + factuur_Items[10].PompPrijs.Giek);
                    cellenDictionary.Add("B135", " FF");
                    cellenDictionary.Add("C135", 1);
                    cellenDictionary.Add("D135", factuur_Items[10].PompPrijs.Bedrag);
                    cellenDictionary.Add("E135", factuur_Items[10].PompPrijs.Bedrag);
                    cellenDictionary.Add("A136", "Gepompte M3 ");
                    cellenDictionary.Add("B136", "M3");
                    cellenDictionary.Add("C136", factuur_Items[10].GepompteM3);
                    cellenDictionary.Add("D136", factuur_Items[10].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E136", factuur_Items[10].PompTotaalSuplimentPrijs);
                    if (factuur_Items[10].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A137", "Wachttijd pomp");
                        cellenDictionary.Add("B137", "Minuten");
                        cellenDictionary.Add("C137", ((factuur_Items[10].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D137", "1,20");
                        cellenDictionary.Add("E137", factuur_Items[10].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[10].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A138", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B138", "Minuten ");
                    cellenDictionary.Add("C138", ((factuur_Items[10].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D138", "1,20");
                    cellenDictionary.Add("E138", factuur_Items[10].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[10].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A139", "Transport");
                    cellenDictionary.Add("B139", "FF");
                    cellenDictionary.Add("C139", "1");
                    cellenDictionary.Add("D139", "0");
                    cellenDictionary.Add("E139", factuur_Items[10].TransportTotaal.ToString());

                }
                #endregion

            }

            void FactuurItem12()
            {
                #region werfdetail 

                cellenDictionary.Add("A140", factuur_Items[11].Werf.Gemeente + " " + factuur_Items[11].BestelDatum.Day + "/" + factuur_Items[11].BestelDatum.Month);
                #endregion

                #region productOmschrijving
                cellenDictionary.Add("A141", factuur_Items[11].OmschrijvingProduct.Omschrijving);
                if (factuur_Items[11].OmschrijvingProduct.Formule == "10 Teelaar" || factuur_Items[11].OmschrijvingProduct.Formule == "13 Spuitza" || factuur_Items[11].OmschrijvingProduct.Formule == "14 Bakstee" || factuur_Items[11].OmschrijvingProduct.Formule == "3 Breekza" || factuur_Items[11].OmschrijvingProduct.Formule == "4 0/2 Zand" || factuur_Items[11].OmschrijvingProduct.Formule == "5 0/5 Zand" || factuur_Items[11].OmschrijvingProduct.Formule == "6 0/7 Zand" || factuur_Items[11].OmschrijvingProduct.Formule == "7 2/6 Gr" || factuur_Items[11].OmschrijvingProduct.Formule == "8 6/14 Gr" || factuur_Items[11].OmschrijvingProduct.Formule == "9 3/10" || factuur_Items[11].OmschrijvingProduct.Formule == "betonzand" || factuur_Items[11].OmschrijvingProduct.Formule == "zeezand" || factuur_Items[11].OmschrijvingProduct.Formule == "2" || factuur_Items[11].OmschrijvingProduct.Formule == "pousse" || factuur_Items[11].OmschrijvingProduct.Formule == "9 6/20")
                {
                    cellenDictionary.Add("B141", "Ton");
                }
                else if (factuur_Items[11].OmschrijvingProduct.Formule == "Mortel")
                {
                    cellenDictionary.Add("B141", "Liter");
                }
                else if (factuur_Items[11].OmschrijvingProduct.Formule == "betonblokken")
                {
                    cellenDictionary.Add("B141", "Stuk");
                }
                else
                {
                    cellenDictionary.Add("B141", "M3");
                }

                cellenDictionary.Add("C141", factuur_Items[11].HoeveelheidProduct.ToString());
                cellenDictionary.Add("D141", factuur_Items[11].EenheidsPrijs.ToString());
                cellenDictionary.Add("E141", factuur_Items[11].ProductPrijs.ToString());
                #endregion

                #region onvolledigelading
                if (factuur_Items[11].Onvolledige_Lading_Hoeveelheid != 0)
                {
                    cellenDictionary.Add("A142", "Onvolledige lading");
                    cellenDictionary.Add("B142", "M3");
                    cellenDictionary.Add("C142", factuur_Items[11].Onvolledige_Lading_Hoeveelheid);
                    cellenDictionary.Add("D142", "20");
                    cellenDictionary.Add("E142", factuur_Items[11].Onvolledige_Lading_Prijs);
                }
                #endregion

                #region hulpstoffen
                List<Hulpstof_Factuur_Item> hulpstof_Factuur_Items = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuur_Items[11].ID);
                if (hulpstof_Factuur_Items.Count == 1)
                {
                    cellenDictionary.Add("A143", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B143", "M3");
                    cellenDictionary.Add("C143", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D143", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E143", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                }
                else if (hulpstof_Factuur_Items.Count == 2)
                {
                    #region hulpstof1
                    cellenDictionary.Add("A143", hulpstof_Factuur_Items[0].Hulpstof);
                    cellenDictionary.Add("B143", "M3");
                    cellenDictionary.Add("C143", ((hulpstof_Factuur_Items[0].TotaalPrijsHulpstof / hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D143", hulpstof_Factuur_Items[0].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E143", hulpstof_Factuur_Items[0].TotaalPrijsHulpstof.ToString());
                    #endregion

                    #region hulpstof2
                    cellenDictionary.Add("A144", hulpstof_Factuur_Items[1].Hulpstof);
                    cellenDictionary.Add("B144", "M3");
                    cellenDictionary.Add("C144", ((hulpstof_Factuur_Items[1].TotaalPrijsHulpstof / hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof).ToString()));
                    cellenDictionary.Add("D144", hulpstof_Factuur_Items[1].EenheidsPrijsHulpstof.ToString());
                    cellenDictionary.Add("E144", hulpstof_Factuur_Items[1].TotaalPrijsHulpstof.ToString());
                    #endregion
                }

                #endregion

                #region pomp

                if (factuur_Items[11].PompPrijs.Bedrag != 0  && factuur_Items[11].GepompteM3 != 0)
                {
                    cellenDictionary.Add("A145", "Pomp " + factuur_Items[11].PompPrijs.Giek);
                    cellenDictionary.Add("B145", " FF");
                    cellenDictionary.Add("C145", 1);
                    cellenDictionary.Add("D145", factuur_Items[11].PompPrijs.Bedrag);
                    cellenDictionary.Add("E145", factuur_Items[11].PompPrijs.Bedrag);
                    cellenDictionary.Add("A146", "Gepompte M3 ");
                    cellenDictionary.Add("B146", "M3");
                    cellenDictionary.Add("C146", factuur_Items[11].GepompteM3);
                    cellenDictionary.Add("D146", factuur_Items[11].PompSuplimentEenheidsPrijs);
                    cellenDictionary.Add("E146", factuur_Items[11].PompTotaalSuplimentPrijs);
                    if (factuur_Items[11].PompWachtTijd != 0)
                    {
                        cellenDictionary.Add("A147", "Wachttijd pomp");
                        cellenDictionary.Add("B147", "Minuten");
                        cellenDictionary.Add("C147", ((factuur_Items[11].PompWachtTijd / 1.35).ToString()));
                        cellenDictionary.Add("D147", "1,20");
                        cellenDictionary.Add("E147", factuur_Items[11].PompWachtTijd);
                    }
                }
                #endregion

                #region laadenlostijdenmixer
                if (factuur_Items[11].LaadEnLosTijdenTotaal != 0)
                {
                    cellenDictionary.Add("A148", "Laad en los tijden mixer ");
                    cellenDictionary.Add("B148", "Minuten ");
                    cellenDictionary.Add("C148", ((factuur_Items[11].LaadEnLosTijdenTotaal / 1.2).ToString()));
                    cellenDictionary.Add("D148", "1,20");
                    cellenDictionary.Add("E148", factuur_Items[11].LaadEnLosTijdenTotaal.ToString());

                }
                #endregion

                #region Transport
                if (factuur_Items[11].TransportTotaal != 0)
                {
                    cellenDictionary.Add("A149", "Transport");
                    cellenDictionary.Add("B149", "FF");
                    cellenDictionary.Add("C149", "1");
                    cellenDictionary.Add("D149", "0");
                    cellenDictionary.Add("E149", factuur_Items[11].TransportTotaal.ToString());

                }
                #endregion

            }
            #endregion

            #region wegschrijven factuur item Weg
            int aantalFactuurItems = factuur_Items.Count;
            if (aantalFactuurItems == 1)
            {
                FactuurItem1();
            }
            else if (aantalFactuurItems == 2)
            {
                FactuurItem1();

                FactuurItem2();
            }
            else if (aantalFactuurItems == 3)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();
            }
            else if (aantalFactuurItems == 4)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();
            }
            else if (aantalFactuurItems == 5)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();
            }
            else if (aantalFactuurItems == 6)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();
            }
            else if (aantalFactuurItems == 7)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();

                FactuurItem7();
            }

            else if (aantalFactuurItems == 8)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();

                FactuurItem7();

                FactuurItem8();
            }
            else if (aantalFactuurItems == 9)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();

                FactuurItem7();

                FactuurItem8();

                FactuurItem9();
            }
            else if (aantalFactuurItems == 10)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();

                FactuurItem7();

                FactuurItem8();

                FactuurItem9();

                FactuurItem10();
            }
            else if (aantalFactuurItems == 11)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();

                FactuurItem7();

                FactuurItem8();

                FactuurItem9();

                FactuurItem10();

                FactuurItem11();
            }
            else if (aantalFactuurItems == 12)
            {
                FactuurItem1();

                FactuurItem2();

                FactuurItem3();

                FactuurItem4();

                FactuurItem5();

                FactuurItem6();

                FactuurItem7();

                FactuurItem8();

                FactuurItem9();

                FactuurItem10();

                FactuurItem11();

                FactuurItem12();
            }
              
       

            #endregion

            #region factuur
                if (aantalFactuurItems <= 5)
                {
                    if (TotaalVerlegd != 0) { cellenDictionary.Add("C66", (TotaalVerlegd).ToString()); }
                    cellenDictionary.Add("E66", totaalVerlegd.ToString("F2"));
                    cellenDictionary.Add("E67", totaalExclBtw.ToString("F2"));
                    cellenDictionary.Add("E68", totaalIncl6Btw.ToString("F2"));
                    cellenDictionary.Add("E69", totaalIncl21Btw.ToString("F2"));
                    if (TotaalIncl21Btw != 0) { cellenDictionary.Add("C69", ((totaal - totaalVerlegd - totaalExclBtw - totaalIncl6Btw) - TotaalIncl21Btw).ToString()); }
                    cellenDictionary.Add("E70", totaal);
                    #region wegschrijven
                    string[,] cellenArray = new string[70, 5];

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

                    string bestandsNaam = factuurNummer + " " + klant.Naam;
                    string strFullpath = @"Z:\\Facturatie\" + datum.ToString("dd MMMM yyyy");
                    if (!Directory.Exists(strFullpath))
                    {
                        string folderName = @"Z:\\Facturatie\";
                        string pathString = System.IO.Path.Combine(folderName, datum.ToString("dd MMMM yyyy"));
                        System.IO.Directory.CreateDirectory(pathString);
                        ExcellFactuur.CreateDocument(@"Z:\\Facturatie\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray);
                    }
                    else
                    {
                        ExcellFactuur.CreateDocument(@"Z:\\Facturatie\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray);
                    }

                    #endregion
                }
                 if (aantalFactuurItems > 5)
                {
                    if (TotaalVerlegd != 0) { cellenDictionary.Add("C150", (TotaalVerlegd).ToString()); }
                    cellenDictionary.Add("E150", totaalVerlegd.ToString("F2"));
                    cellenDictionary.Add("E151", totaalExclBtw.ToString("F2"));
                    cellenDictionary.Add("E152", totaalIncl6Btw.ToString("F2"));
                    cellenDictionary.Add("E153", totaalIncl21Btw.ToString("F2"));
                    if (TotaalIncl21Btw != 0) { cellenDictionary.Add("C153", ((totaal - totaalVerlegd - totaalExclBtw - totaalIncl6Btw) - TotaalIncl21Btw).ToString()); }
                    cellenDictionary.Add("E154", totaal);

                    #region wegschrijven
                    string[,] cellenArray = new string[154, 5];

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

                    string bestandsNaam = factuurNummer + " " + klant.Naam;
                    string strFullpath = @"Z:\\Facturatie\" + datum.ToString("dd MMMM yyyy");
                    if (!Directory.Exists(strFullpath))
                    {
                        string folderName = @"Z:\\Facturatie\";
                        string pathString = System.IO.Path.Combine(folderName, datum.ToString("dd MMMM yyyy"));
                        System.IO.Directory.CreateDirectory(pathString);
                        ExcellFactuur10.CreateDocument(@"Z:\\Facturatie\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray);
                    }
                    else
                    {
                        ExcellFactuur10.CreateDocument(@"Z:\\Facturatie\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray);
                    }

                    #endregion
                }

            #endregion


            //#region factuur
            //if (TotaalVerlegd != 0) { cellenDictionary.Add("C80", (TotaalVerlegd).ToString()); }
            //cellenDictionary.Add("E80", totaalVerlegd);
            //cellenDictionary.Add("E81", totaalExclBtw);
            //cellenDictionary.Add("E82", totaalIncl6Btw);
            //cellenDictionary.Add("E83", totaalIncl21Btw);
            //if (TotaalIncl21Btw != 0) { cellenDictionary.Add("C83", ((totaal - totaalVerlegd - totaalExclBtw - totaalIncl6Btw) - TotaalIncl21Btw).ToString()); }
            //cellenDictionary.Add("E84", totaal);
            //#endregion


        }
        public static List<Factuur> KrijgTeControlerenFacturen()
        {
            List<FactuurDO> FactuurDOs = DataAccess.KrijgTeControlerenFacturen();
            List<Factuur> Factuurs = new List<Factuur>();
            foreach (FactuurDO factuurDO in FactuurDOs)
            {
                Factuurs.Add(ConvertFromDO(factuurDO));
            }
            return Factuurs;
        }
        public static List<Factuur> KrijgAlleFacturenVanDatum(DateTime date)
        {
            List<FactuurDO> FactuurDOs = DataAccess.KrijgAlleFacturenDoorDatum(date);
            List<Factuur> Factuurs = new List<Factuur>();
            foreach (FactuurDO factuurDO in FactuurDOs)
            {
                Factuurs.Add(ConvertFromDO(factuurDO));
            }
            return Factuurs;
        }

        public void VerwijderFactuur()
        {
            FactuurDO factuurDO = DataAccess.VerwijderFactuur(ConvertToDO(this));
        }
        public static List<Factuur> KrijgAlleFacturenVanKlant(int klantID)
        {
            List<FactuurDO> FactuurDOs = DataAccess.KrijgAlleFacturenDoorKlantID(klantID);
            List<Factuur> Factuurs = new List<Factuur>();
            foreach (FactuurDO factuurDO in FactuurDOs)
            {
                Factuurs.Add(ConvertFromDO(factuurDO));
            }
            return Factuurs;
        }
        public static List<Factuur> KrijgAlleFacturenVanKlantEnDatum(int klantID, DateTime date)
        {
            List<FactuurDO> FactuurDOs = DataAccess.KrijgAlleFacturenDoorKlantIDEnDatum(klantID,date);
            List<Factuur> Factuurs = new List<Factuur>();
            foreach (FactuurDO factuurDO in FactuurDOs)
            {
                Factuurs.Add(ConvertFromDO(factuurDO));
            }
            return Factuurs;
        }
        public void update()
        {
            FactuurDO factuurDO = DataAccess.UpdateFactuur(ConvertToDO(this));
        }
        #endregion
    }
}
 