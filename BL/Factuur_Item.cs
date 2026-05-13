using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Factuur_Item
    {
        #region Variables
        private int id;
        private Werf werf;
        private Factuur factuur;
        private OmschrijvingProduct omschrijvingProduct;
        private PompPrijs pompPrijs;
        private DateTime bestelDatum;
        private double transportTotaal;
        private double pompSuplimentEenheidsPrijs;
        private double pompTotaalSuplimentPrijs;
        private double pompWachtTijd;
        private double gepompteM3;
        private double laadEnLosTijdenTotaal;
        private double onvolledige_Lading_Hoeveelheid;
        private double onvolledige_Lading_Prijs;
        private double hoeveelheidProduct;
        private double productPrijs;
        private double eenheidsPrijs;
        private double subtotaal;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
        }
        public Factuur Factuur
        {
            get { return factuur; }
            set { factuur = value; }
        }
        public OmschrijvingProduct OmschrijvingProduct
        {
            get { return omschrijvingProduct; }
            set { omschrijvingProduct = value; }
        }
        public PompPrijs PompPrijs
        {
            get { return pompPrijs; }
            set { pompPrijs = value; }
        }
        public DateTime BestelDatum
        {
            get { return bestelDatum; }
            set { bestelDatum = value; }
        }
        public double PompSuplimentEenheidsPrijs
        {
            get { return pompSuplimentEenheidsPrijs; }
            set { pompSuplimentEenheidsPrijs = value; }
        }
        public double PompTotaalSuplimentPrijs
        {
            get { return pompTotaalSuplimentPrijs; }
            set { pompTotaalSuplimentPrijs = value; }
        }
        public double PompWachtTijd
        {
            get { return pompWachtTijd; }
            set { pompWachtTijd = value; }
        }

        public double GepompteM3
        {
            get { return gepompteM3; }
            set { gepompteM3 = value; }
        }
        public double Onvolledige_Lading_Hoeveelheid
        {
            get { return onvolledige_Lading_Hoeveelheid; }
            set { onvolledige_Lading_Hoeveelheid = value; }
        }
        public double Onvolledige_Lading_Prijs
        {
            get { return onvolledige_Lading_Prijs; }
            set { onvolledige_Lading_Prijs = value; }
        }
        public double TransportTotaal
        {
            get { return transportTotaal; }
            set { transportTotaal = value; }
        }

        public double LaadEnLosTijdenTotaal
        {
            get { return laadEnLosTijdenTotaal; }
            set { laadEnLosTijdenTotaal = value; }
        }
        public double EenheidsPrijs
        {
            get { return eenheidsPrijs; }
            set { eenheidsPrijs = value; }
        }
        public double HoeveelheidProduct
        {
            get { return hoeveelheidProduct; }
            set { hoeveelheidProduct = value; }
        }


        public double ProductPrijs
        {
            get { return productPrijs; }
            set { productPrijs = value; }
        }
        public double Subtotaal
        {
            get { return subtotaal; }
            set { subtotaal = value; }
        }
        #endregion

        #region Contructors
        public Factuur_Item()
        {

        }
        public Factuur_Item(Werf werf, Factuur factuur, OmschrijvingProduct omschrijvingProduct,PompPrijs pompPrijs, DateTime bestelDatum, double transportTotaal, double pompSuplimentEenheidsPrijs ,double pompTotaalSuplimentPrijs, double pompWachtTijd, double gepompteM3, double laadEnLosTijdenTotaal, double onvolledige_lading_Hoeveelheid, double onvolledige_lading_Prijs, double hoeveelheidProduct, double productPrijs, double eenheidsPrijs, double subtotaal)
        {
            Werf = werf;
            Factuur = factuur;
            OmschrijvingProduct = omschrijvingProduct;
            PompPrijs = pompPrijs;
            BestelDatum = bestelDatum;
            TransportTotaal = transportTotaal;
            PompSuplimentEenheidsPrijs = pompSuplimentEenheidsPrijs;
            PompTotaalSuplimentPrijs = pompTotaalSuplimentPrijs;
            PompWachtTijd = pompWachtTijd;
            GepompteM3 = gepompteM3;
            LaadEnLosTijdenTotaal = laadEnLosTijdenTotaal;
            Onvolledige_Lading_Hoeveelheid = onvolledige_lading_Hoeveelheid;
            Onvolledige_Lading_Prijs = onvolledige_lading_Prijs;
            HoeveelheidProduct = hoeveelheidProduct;
            ProductPrijs = productPrijs;
            EenheidsPrijs = eenheidsPrijs;
            Subtotaal = subtotaal;
        }
        public Factuur_Item(int id, Werf werf, Factuur factuur, OmschrijvingProduct omschrijvingProduct, PompPrijs pompPrijs, DateTime bestelDatum, double transportTotaal, double pompSuplimentEenheidsPrijs, double pompTotaalSuplimentPrijs, double pompWachtTijd, double gepompteM3, double laadEnLosTijdenTotaal, double onvolledige_lading_Hoeveelheid, double onvolledige_lading_Prijs, double hoeveelheidProduct, double productPrijs, double eenheidsPrijs, double subtotaal )
            : this(werf, factuur, omschrijvingProduct, pompPrijs, bestelDatum, transportTotaal, pompSuplimentEenheidsPrijs, pompTotaalSuplimentPrijs, pompWachtTijd, gepompteM3, laadEnLosTijdenTotaal, onvolledige_lading_Hoeveelheid, onvolledige_lading_Prijs, hoeveelheidProduct, productPrijs, eenheidsPrijs, subtotaal)
        {
            ID = id;
        }
        #endregion

        #region Methods
        public static Factuur_Item ConvertFromDO(Factuur_ItemDO factuur_ItemDO)
        {
            Factuur_Item factuur_Item = new Factuur_Item(factuur_ItemDO.ID, Werf.ConvertFromDO(factuur_ItemDO.WerfDO), Factuur.ConvertFromDO(factuur_ItemDO.FactuurDO), OmschrijvingProduct.ConvertFromDO(factuur_ItemDO.OmschrijvingProductDO),PompPrijs.ConvertFromDO(factuur_ItemDO.PompPrijsDO), factuur_ItemDO.BestelDatum, factuur_ItemDO.TransportTotaal, factuur_ItemDO.PompSuplimentEenheidsPrijs, factuur_ItemDO.PompTotaalSuplimentPrijs, factuur_ItemDO.PompWachtTijd, factuur_ItemDO.GepompteM3, factuur_ItemDO.LaadEnLosTijdenTotaal, factuur_ItemDO.Onvolledige_Lading_Hoeveelheid, factuur_ItemDO.Onvolledige_Lading_Prijs, factuur_ItemDO.HoeveelheidProduct, factuur_ItemDO.ProductPrijs, factuur_ItemDO.EenheidsPrijs, factuur_ItemDO.Subtotaal);

            return factuur_Item;
        }
        public  Factuur_ItemDO ConvertToDO(Factuur_Item factuur_Item)
        {
            Factuur_ItemDO factuur_ItemDO = new Factuur_ItemDO(ID,Werf.ConvertToDO(werf),Factuur.ConvertToDO(factuur),OmschrijvingProduct.ConvertToDO(omschrijvingProduct),PompPrijs.ConvertToDO(pompPrijs),BestelDatum,TransportTotaal,PompSuplimentEenheidsPrijs,PompTotaalSuplimentPrijs,PompWachtTijd,gepompteM3,LaadEnLosTijdenTotaal,Onvolledige_Lading_Hoeveelheid,Onvolledige_Lading_Prijs,HoeveelheidProduct,ProductPrijs,EenheidsPrijs,Subtotaal);

            return factuur_ItemDO;
        }

        public void MaakNieuweFactuurItem()
        {
            Factuur_ItemDO factuur_ItemDO = DataAccess.MaakNieuweFactuurItem(ConvertToDO(this));
        }

        public static List<Factuur_Item> krijgAlleFactuurItemsDoorFactuurID(int FactuurID)
        {
            List<Factuur_ItemDO> Factuur_ItemDOs = DataAccess.KrijgAlleFactuurItemsDoorFactuurID(FactuurID);
            List<Factuur_Item> Factuur_Items = new List<Factuur_Item>();
            foreach (Factuur_ItemDO factuur_ItemDO in Factuur_ItemDOs)
            {
                Factuur_Items.Add(ConvertFromDO(factuur_ItemDO));
            }
            return Factuur_Items;
        }


        public static Factuur_Item KrijgDoorItemID(int factuurItemID)
        {
            Factuur_ItemDO factuur_ItemDO = DataAccess.KrijgFactuurItemDoorEigenID(factuurItemID);
            Factuur_Item factuur_Item = ConvertFromDO(factuur_ItemDO);
            return factuur_Item;
        }

        public  Factuur_Item krijgFactuurItemDoorGegevens()
        {
            try
            {
                Factuur_ItemDO factuur_ItemDO = DataAccess.krijgFactuurItemgDoorGegevens(ConvertToDO(this));
                Factuur_Item factuur_Item1 = ConvertFromDO(factuur_ItemDO);
                return factuur_Item1;
            }
            catch
            {
                return null;
            }
        }


        #endregion
    }
}