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
    public class BestellingPrefab
    {
        #region variables
        private int id;
        private KlantPrefab klantPrefab;
        private WerfPrefab werfPrefab;
        private List<ProductPrefab> productPrefab;
        private DateTime datum;
        private string levering;
        private string opmerking;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        public KlantPrefab KlantPrefab
        {
            get { return klantPrefab; }
            set { klantPrefab = value; }
        }

        public WerfPrefab WerfPrefab
        {
            get { return werfPrefab; }
            set { werfPrefab = value; }
        }

        public List<ProductPrefab> ProductPrefab
        {
            get { return productPrefab; }
            set { productPrefab = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public string Levering
        {
            get { return levering; }
            set { levering = value; }
        }
        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }

        #endregion
        #region constructors

        public BestellingPrefab()
        {

        }

        public BestellingPrefab(KlantPrefab klantPrefab, WerfPrefab werfPrefab, List<ProductPrefab> productPrefab, DateTime datum, string levering,string opmerking)
        {
            KlantPrefab = klantPrefab;
            WerfPrefab = werfPrefab;
            ProductPrefab = productPrefab; 
            Datum = datum;
            Levering = levering;
            Opmerking = opmerking;
        }
        public BestellingPrefab(int id,KlantPrefab klantPrefab, WerfPrefab werfPrefab, List<ProductPrefab> productPrefab, DateTime datum,string levering, string opmerking)
            :this(klantPrefab,werfPrefab,productPrefab,datum, levering,opmerking)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static  BestellingPrefab ConvertFromDO(BestellingPrefabDO bestellingPrefabDO)
        {
            List<ProductPrefabDO> ProductPrefabDOs = bestellingPrefabDO.ProductPrefabDO;
            List<ProductPrefab> ProductPrefabs = new List<ProductPrefab>();
            foreach (ProductPrefabDO productPrefabDO in ProductPrefabDOs)
            {
                ProductPrefab ProductPrefab = new ProductPrefab(productPrefabDO.ID,productPrefabDO.Lot,productPrefabDO.Aantalstuks, productPrefabDO.LangsteElement, productPrefabDO.M3, productPrefabDO.PrefabBestellingID);
                ProductPrefabs.Add(ProductPrefab);
            }
            BestellingPrefab bestellingPrefab = new BestellingPrefab(bestellingPrefabDO.ID, KlantPrefab.ConvertFromDO(bestellingPrefabDO.KlantPrefabDO), WerfPrefab.ConvertFromDO(bestellingPrefabDO.WerfPrefabDO), ProductPrefabs, bestellingPrefabDO.Datum, bestellingPrefabDO.Levering,bestellingPrefabDO.Opmerking);
            return bestellingPrefab;
        }

        public static BestellingPrefabDO ConvertToDO(BestellingPrefab bestellingPrefab)
        {
            List<ProductPrefab> ProductPrefabs = bestellingPrefab.ProductPrefab;
            List<ProductPrefabDO> ProductPrefabDOs = new List<ProductPrefabDO>();
            foreach (ProductPrefab productPrefab in ProductPrefabs)
            {
                ProductPrefabDO productPrefabDO = new ProductPrefabDO(productPrefab.Lot,productPrefab.Aantalstuks, productPrefab.LangsteElement, productPrefab.M3);
                ProductPrefabDOs.Add(productPrefabDO);
            }
            BestellingPrefabDO bestellingPrefabDO = new BestellingPrefabDO(bestellingPrefab.ID, bestellingPrefab.KlantPrefab.ConvertToDO(bestellingPrefab.klantPrefab), bestellingPrefab.WerfPrefab.ConvertToDO(bestellingPrefab.werfPrefab), ProductPrefabDOs, bestellingPrefab.Datum, bestellingPrefab.Levering, bestellingPrefab.Opmerking);
            return bestellingPrefabDO;
        }

        public void WijzigBestelling()
        {
            BestellingPrefabDO bestellingPrefabDO = DataAccess.WijzigBestellingPrefab(ConvertToDO(this));
        }

        public BestellingPrefab MaakNieuweBestellingPrefab()
        {
            BestellingPrefabDO bestellingPrefabDO = DataAccess.MaakNieuweBestellingPrefab(ConvertToDO(this));
            return ConvertFromDO(bestellingPrefabDO);
        }

        public static List<BestellingPrefab> KrijgAlleBestellingenDoorDatum(DateTime datum1, DateTime datum2)
        {
            List<BestellingPrefabDO> BestellingPrefabDOs = DataAccess.SelecteerBestellingenPrefabDatum(datum1,datum2);
            List<BestellingPrefab> BestellingPrefabs = new List<BestellingPrefab>();
            foreach (BestellingPrefabDO bestellingDO in BestellingPrefabDOs)
            {
                BestellingPrefabs.Add(ConvertFromDO(bestellingDO));
            }
            return BestellingPrefabs;
        }

        public void Verwijderen(int bID)
        {
           DataAccess.VerwijderbestellingPrefab(bID);
        }

        #endregion
        public override string ToString()
        {
            return KlantPrefab.Naam + " - " + Datum.ToLongDateString();
        }
        public void GeneerExcellRec(string user)
        {
            Dictionary<string, object> cellenDictionary = new Dictionary<string, object>();

            #region wegschrijven datum+tijd
            cellenDictionary.Add("B1", Datum.ToLongDateString());
            cellenDictionary.Add("C1", datum.ToShortTimeString());

            #endregion

            #region wegschrijven Klant

            cellenDictionary.Add("B3", KlantPrefab.Naam);
            cellenDictionary.Add("D3", KlantPrefab.Postcode);
            cellenDictionary.Add("B4", KlantPrefab.Straat);
            cellenDictionary.Add("D4", KlantPrefab.Gemeente);


            #endregion

            #region wegschrijven Werf

            if (WerfPrefab != null)
            {
                cellenDictionary.Add("B6", WerfPrefab.Adres);
                cellenDictionary.Add("D6", WerfPrefab.Gemeente);
                cellenDictionary.Add("B7", WerfPrefab.Postcode);
            }
            #endregion
            #region wegschrijven Contact

            if (WerfPrefab != null)
            {
                cellenDictionary.Add("B9", WerfPrefab.ContactPersoonPrefab.Naam);
                cellenDictionary.Add("B10", WerfPrefab.ContactPersoonPrefab.Voornaam);
                cellenDictionary.Add("D9", WerfPrefab.ContactPersoonPrefab.GSM);
                cellenDictionary.Add("D10", WerfPrefab.ContactPersoonPrefab.Telefoon);
            }
            #endregion

            List<ProductPrefab> producten = ProductPrefab;
            if (producten.Count == 1)
            {
                cellenDictionary.Add("B12", producten[0].Lot + "Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " | " + producten[0].M3 + "M3");
            }
            else if (producten.Count == 2)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
            }
            else if (producten.Count == 3)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
            }
            else if (producten.Count == 4)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
            }
            else if (producten.Count == 5)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
                cellenDictionary.Add("B16", producten[4].Lot + " Stuks: " + producten[4].Aantalstuks);
                cellenDictionary.Add("D16", producten[4].LangsteElement + " |           " + producten[4].M3 + " M3");
            }
            else if (producten.Count == 6)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
                cellenDictionary.Add("B16", producten[4].Lot + " Stuks: " + producten[4].Aantalstuks);
                cellenDictionary.Add("D16", producten[4].LangsteElement + " |           " + producten[4].M3 + " M3");
                cellenDictionary.Add("B17", producten[5].Lot + " Stuks: " + producten[5].Aantalstuks);
                cellenDictionary.Add("D17", producten[5].LangsteElement + " |           " + producten[5].M3 + " M3");
            }
            else if (producten.Count == 7)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
                cellenDictionary.Add("B16", producten[4].Lot + " Stuks: " + producten[4].Aantalstuks);
                cellenDictionary.Add("D16", producten[4].LangsteElement + " |           " + producten[4].M3 + " M3");
                cellenDictionary.Add("B17", producten[5].Lot + " Stuks: " + producten[5].Aantalstuks);
                cellenDictionary.Add("D17", producten[5].LangsteElement + " |           " + producten[5].M3 + " M3");
                cellenDictionary.Add("B18", producten[6].Lot + " Stuks: " + producten[6].Aantalstuks);
                cellenDictionary.Add("D18", producten[6].LangsteElement + " |           " + producten[6].M3 + " M3");
            }
            else if (producten.Count == 8)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
                cellenDictionary.Add("B16", producten[4].Lot + " Stuks: " + producten[4].Aantalstuks);
                cellenDictionary.Add("D16", producten[4].LangsteElement + " |           " + producten[4].M3 + " M3");
                cellenDictionary.Add("B17", producten[5].Lot + " Stuks: " + producten[5].Aantalstuks);
                cellenDictionary.Add("D17", producten[5].LangsteElement + " |           " + producten[5].M3 + " M3");
                cellenDictionary.Add("B18", producten[6].Lot + " Stuks: " + producten[6].Aantalstuks);
                cellenDictionary.Add("D18", producten[6].LangsteElement + " |           " + producten[6].M3 + " M3");
                cellenDictionary.Add("B19", producten[7].Lot + " Stuks: " + producten[7].Aantalstuks);
                cellenDictionary.Add("D19", producten[7].LangsteElement + " |           " + producten[7].M3 + " M3");
            }
            else if (producten.Count == 9)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
                cellenDictionary.Add("B16", producten[4].Lot + " Stuks: " + producten[4].Aantalstuks);
                cellenDictionary.Add("D16", producten[4].LangsteElement + " |           " + producten[4].M3 + " M3");
                cellenDictionary.Add("B17", producten[5].Lot + " Stuks: " + producten[5].Aantalstuks);
                cellenDictionary.Add("D17", producten[5].LangsteElement + " |           " + producten[5].M3 + " M3");
                cellenDictionary.Add("B18", producten[6].Lot + " Stuks: " + producten[6].Aantalstuks);
                cellenDictionary.Add("D18", producten[6].LangsteElement + " |           " + producten[6].M3 + " M3");
                cellenDictionary.Add("B19", producten[7].Lot + " Stuks: " + producten[7].Aantalstuks);
                cellenDictionary.Add("D19", producten[7].LangsteElement + " |           " + producten[7].M3 + " M3");
                cellenDictionary.Add("B20", producten[8].Lot + " Stuks: " + producten[8].Aantalstuks);
                cellenDictionary.Add("D20", producten[8].LangsteElement + " |           " + producten[8].M3 + " M3");
            }
            else if (producten.Count == 10)
            {
                cellenDictionary.Add("B12", producten[0].Lot + " Stuks: " + producten[0].Aantalstuks);
                cellenDictionary.Add("D12", producten[0].LangsteElement + " |           " + producten[0].M3 + " M3");
                cellenDictionary.Add("B13", producten[1].Lot + " Stuks: " + producten[1].Aantalstuks);
                cellenDictionary.Add("D13", producten[1].LangsteElement + " |           " + producten[1].M3 + " M3");
                cellenDictionary.Add("B14", producten[2].Lot + " Stuks: " + producten[2].Aantalstuks);
                cellenDictionary.Add("D14", producten[2].LangsteElement + " |           " + producten[2].M3 + " M3");
                cellenDictionary.Add("B15", producten[3].Lot + " Stuks: " + producten[3].Aantalstuks);
                cellenDictionary.Add("D15", producten[3].LangsteElement + " |           " + producten[3].M3 + " M3");
                cellenDictionary.Add("B16", producten[4].Lot + " Stuks: " + producten[4].Aantalstuks);
                cellenDictionary.Add("D16", producten[4].LangsteElement + " |           " + producten[4].M3 + " M3");
                cellenDictionary.Add("B17", producten[5].Lot + " Stuks: " + producten[5].Aantalstuks);
                cellenDictionary.Add("D17", producten[5].LangsteElement + " |           " + producten[5].M3 + " M3");
                cellenDictionary.Add("B18", producten[6].Lot + " Stuks: " + producten[6].Aantalstuks);
                cellenDictionary.Add("D18", producten[6].LangsteElement + " |           " + producten[6].M3 + " M3");
                cellenDictionary.Add("B19", producten[7].Lot + " Stuks: " + producten[7].Aantalstuks);
                cellenDictionary.Add("D19", producten[7].LangsteElement + " |           " + producten[7].M3 + " M3");
                cellenDictionary.Add("B20", producten[8].Lot + " Stuks: " + producten[8].Aantalstuks);
                cellenDictionary.Add("D20", producten[8].LangsteElement + " |           " + producten[8].M3 + " M3");
                cellenDictionary.Add("B21", producten[9].Lot + " Stuks: " + producten[9].Aantalstuks);
                cellenDictionary.Add("D21", producten[9].LangsteElement + " |           " + producten[9].M3 + " M3");
            }
            cellenDictionary.Add("B23", Levering);
            cellenDictionary.Add("D23", Opmerking);
            //#endregion
            //OmschrijvingProduct omschrijvingProduct = OmschrijvingProduct.KrijgOmschrijvingenViaFormule(Formule.Naam);
            //#region wegschrijven Formule
            //cellenDictionary.Add("B12", omschrijvingProduct.Omschrijving);
            //cellenDictionary.Add("B13", Formule.Naam);
            //if (formule.Naam == "10 Teelaar" || formule.Naam == "13 Spuitza" || formule.Naam == "14 Bakstee" || formule.Naam == "3 Breekza" || formule.Naam == "4 0/2 Zand" || formule.Naam == "5 0/5 Zand" || formule.Naam == "6 0/7 Zand" || formule.Naam == "7 2/6 Gr" || formule.Naam == "8 6/14 Gr" || formule.Naam == "9 3/10" || formule.Naam == "betonzand" || formule.Naam == "zeezand" || formule.Naam == "2" || formule.Naam == "pousse")
            //{
            //    cellenDictionary.Add("C13", "Ton:");
            //}
            //else if (formule.Naam == "Mortel")
            //{
            //    cellenDictionary.Add("C13", "Liter:");
            //}
            //else if (formule.Naam == "betonblokken")
            //{
            //    cellenDictionary.Add("C13", "Stuk:");
            //}
            //else
            //{
            //    cellenDictionary.Add("C13", "M3:");
            //}
            //if (saldo == false)
            //{

            //    cellenDictionary.Add("D13", M3);
            //}
            //else
            //{
            //    cellenDictionary.Add("D13", M3 + "+saldo");
            //}
            //cellenDictionary.Add("B14", Formule.Samenstelling);
            //cellenDictionary.Add("D14", Formule.Vloeibaarheid);
            //cellenDictionary.Add("B15", Formule.GranuleDiameter);
            //cellenDictionary.Add("D15", LeveringWijze);
            //cellenDictionary.Add("B16", Loswijze);
            //cellenDictionary.Add("D16", Comment);



            //#region wegschrijven Hulpstof

            //List<Hulpstof> hulpstofList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(ID);
            //int counterhulpstof = 18;
            //int counter = 0;
            //foreach (Hulpstof hulpstof in hulpstofList)
            //{
            //    cellenDictionary.Add("B" + counterhulpstof, hulpstofList[counter].Naam);
            //    cellenDictionary.Add("D" + counterhulpstof, hulpstofList[counter].Hoeveelheid);
            //    counter++;
            //    counterhulpstof++;
            //}
            //#endregion

            #region wegschrijven
            string[,] cellenArray = new string[23, 4];

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

            string bestandsNaam = KlantPrefab.Naam + " " + Datum.Hour.ToString() + "u" + Datum.Minute.ToString();
            string strFullpath = @"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy");
            if (!Directory.Exists(strFullpath))
            {
                string folderName = @"Z:\Bestellingen\";
                string pathString = System.IO.Path.Combine(folderName, datum.ToString("dd MMMM yyyy"));
                System.IO.Directory.CreateDirectory(pathString);
                ExcellPrefab.CreateDocument(@"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray, user);
            }
            else
            {
                ExcellPrefab.CreateDocument(@"Z:\Bestellingen\" + datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx", bestandsNaam, cellenArray,user);
            }

            #endregion
        }
    }
}
