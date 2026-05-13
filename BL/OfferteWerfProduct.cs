using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OfferteWerfProduct
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
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
        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
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
        public OfferteWerfProduct()
        {

        }
        public OfferteWerfProduct(Klant klant, Werf werf, OmschrijvingProduct product, double transport, double onvolledigeLading, double bedrag, string opmerking)
        {
            Klant = klant;
            Werf = werf;
            Product = product;
            Transport = transport;
            OnvolledigeLading = onvolledigeLading;
            Bedrag = bedrag;
            Opmerking = opmerking;
        }
        public OfferteWerfProduct(int id, Klant klant, Werf werf, OmschrijvingProduct product, double transport, double onvolledigeLading, double bedrag, string opmerking)
            : this(klant,werf, product, transport, onvolledigeLading, bedrag,opmerking)
        {
            ID = id;
        }
        #endregion



        #region methods
        public override string ToString()
        {
            return "Klant: " + klant.Naam + " Werf: " + werf.Adres + " Product: " + product.Omschrijving ;
        }

        public static OfferteWerfProduct ConvertFromDO(OfferteWerfProductDO offerteWerfProductDO)
        {
            OfferteWerfProduct offerteWerfProduct = new OfferteWerfProduct (offerteWerfProductDO.ID, Klant.ConvertFromDO(offerteWerfProductDO.KlantDO), Werf.ConvertFromDO(offerteWerfProductDO.WerfDO),OmschrijvingProduct.ConvertFromDO(offerteWerfProductDO.ProductDO), offerteWerfProductDO.Transport, offerteWerfProductDO.OnvolledigeLading, offerteWerfProductDO.Bedrag, offerteWerfProductDO.Opmerking);
            return offerteWerfProduct;
        }
        public OfferteWerfProductDO ConvertToDO(OfferteWerfProduct offerteWerfProduct)
        {
            OfferteWerfProductDO offerteWerfProductDO = new OfferteWerfProductDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf),Product.ConvertToDO(product), Transport, OnvolledigeLading, Bedrag, Opmerking);
            return offerteWerfProductDO;
        }

        public void MaakNieuweOfferte()
        {
            OfferteWerfProductDO offerteWerfProductDO =  DataAccess.MaakNieuweofferteWerfProduct(ConvertToDO(this));
        }

        public void WijzigOfferte()
        {
            OfferteWerfProductDO offerteWerfProductDO = DataAccess.WijzigOfferteWerfProduct(ConvertToDO(this));
        }

        public static List<OfferteWerfProduct> KrijgAlleOffertesDoorKlantID(int iD)
        {
            List<OfferteWerfProductDO> OfferteWerfProductDOs = DataAccess.KrijgAlleOffertesWervenEnProductVanKlant(iD);
            List<OfferteWerfProduct> OfferteWerfProducts = new List<OfferteWerfProduct>();
            foreach (OfferteWerfProductDO offerteWerfProductDO in OfferteWerfProductDOs)
            {
                OfferteWerfProducts.Add(ConvertFromDO(offerteWerfProductDO));
            }
            return OfferteWerfProducts;
        }
        #endregion
    }
}
