using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Factuur_ItemDO
    {
        #region Variables

        private int id;
        private WerfDO werfDO;
        private FactuurDO factuurDO;
        private OmschrijvingProductDO omschrijvingProductDO;
        private PompPrijsDO pompPrijsDO;
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
        public WerfDO WerfDO
        {
            get { return werfDO; }
            set { werfDO = value; }
        }
        public FactuurDO FactuurDO
        {
            get { return factuurDO; }
            set { factuurDO = value; }
        }
        public OmschrijvingProductDO OmschrijvingProductDO
        {
            get { return omschrijvingProductDO; }
            set { omschrijvingProductDO = value; }
        }
        public PompPrijsDO PompPrijsDO
        {
            get { return pompPrijsDO; }
            set { pompPrijsDO = value; }
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
        public Factuur_ItemDO()
        {

        }
        public Factuur_ItemDO(WerfDO werfDO, FactuurDO factuurDO, OmschrijvingProductDO omschrijvingProductDO, PompPrijsDO pompPrijsDO, DateTime bestelDatum, double transportTotaal, double pompSuplimentEenheidsPrijs, double pompTotaalSuplimentPrijs, double pompWachtTijd, double gepompteM3, double laadEnLosTijdenTotaal, double onvolledige_lading_Hoeveelheid, double onvolledige_lading_Prijs, double hoeveelheidProduct, double productPrijs, double eenheidsPrijs, double subtotaal)
        {
            WerfDO = werfDO;
            FactuurDO = factuurDO;
            OmschrijvingProductDO = omschrijvingProductDO;
            PompPrijsDO = pompPrijsDO;
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
        public Factuur_ItemDO(int id, WerfDO werfDO, FactuurDO factuurDO, OmschrijvingProductDO omschrijvingProductDO, PompPrijsDO pompPrijsDO, DateTime bestelDatum, double transportTotaal, double pompSuplimentEenheidsPrijs, double pompTotaalSuplimentPrijs, double pompWachtTijd, double gepompteM3, double laadEnLosTijdenTotaal, double onvolledige_lading_Hoeveelheid, double onvolledige_lading_Prijs, double hoeveelheidProduct, double productPrijs, double eenheidsPrijs, double subtotaal)
            : this(werfDO, factuurDO, omschrijvingProductDO, pompPrijsDO, bestelDatum, transportTotaal, pompSuplimentEenheidsPrijs, pompTotaalSuplimentPrijs, pompWachtTijd, gepompteM3, laadEnLosTijdenTotaal, onvolledige_lading_Hoeveelheid, onvolledige_lading_Prijs, hoeveelheidProduct, productPrijs, eenheidsPrijs, subtotaal)
        {
            ID = id;
        }
        #endregion
    }
}
