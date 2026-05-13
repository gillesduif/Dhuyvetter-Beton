using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OfferteProduct
    {
        #region variables
        private int id;
        private Klant klant;
        private OmschrijvingProduct product;
        private double transport;
        private double onvolledigeLading;
        private double bedrag;
        private string opmerking;
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
        public OmschrijvingProduct Product
        {
            get { return product; }
            set { product = value; }
        }
        public double Transport
        {
            get { return transport; }
            set { transport = value; }
        }
        public double OnvolledigeLading
        {
            get { return onvolledigeLading; }
            set { onvolledigeLading = value; }
        }
        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }
        #endregion


        #region constructors
        public OfferteProduct()
        {

        }
        public OfferteProduct(Klant klant, OmschrijvingProduct product, double transport, double onvolledigeLading, double bedrag, string opmerking)
        {
            Klant = klant;
            Product = product;
            Transport = transport;
            OnvolledigeLading = onvolledigeLading;
            Bedrag = bedrag;
            Opmerking = opmerking;
        }
        public OfferteProduct(int id, Klant klant, OmschrijvingProduct product, double transport, double onvolledigeLading, double bedrag, string opmerking)
            : this(klant, product, transport, onvolledigeLading, bedrag, opmerking)
        {
            ID = id;
        }
        #endregion



        #region methods
        public override string ToString()
        {
            return "Klant: " + klant.Naam + " Product: " + Product.Omschrijving;
        }

        public static OfferteProduct ConvertFromDO(OfferteProductDO offerteProductDO)
        {
            OfferteProduct offerteProduct = new OfferteProduct(offerteProductDO.ID, Klant.ConvertFromDO(offerteProductDO.KlantDO), OmschrijvingProduct.ConvertFromDO(offerteProductDO.ProductDO), offerteProductDO.Transport, offerteProductDO.OnvolledigeLading, offerteProductDO.Bedrag, offerteProductDO.Opmerking);
            return offerteProduct;
        }
        public OfferteProductDO ConvertToDO(OfferteProduct offerteProduct)
        {
            OfferteProductDO offerteProductDO = new OfferteProductDO(ID, Klant.ConvertToDO(klant),Product.ConvertToDO(product), Transport, OnvolledigeLading, Bedrag, Opmerking);
            return offerteProductDO;
        }

        public void MaakNieuweOfferte()
        {
            OfferteProductDO offerteProductDO = DataAccess.MaakNieuweOfferteProduct(ConvertToDO(this));
        }

        public void WijzigOfferte()
        {
            OfferteProductDO offerteProductDO = DataAccess.WijzigOfferteProduct(ConvertToDO(this));
        }

        public static List<OfferteProduct> KrijgAlleOffertesDoorKlantID(int iD)
        {
            List<OfferteProductDO> OfferteProductDOs = DataAccess.KrijgAlleOffertesProductenVanKlant(iD);
            List<OfferteProduct> OfferteProducts = new List<OfferteProduct>();
            foreach (OfferteProductDO offerteProductDO in OfferteProductDOs)
            {
                OfferteProducts.Add(ConvertFromDO(offerteProductDO));
            }
            return OfferteProducts;
        }
        #endregion
    }
}
