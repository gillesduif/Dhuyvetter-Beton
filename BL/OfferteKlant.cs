using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OfferteKlant
    {
        #region variables
        private int id;
        private Klant klant;
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
        public OfferteKlant()
        {

        }
        public OfferteKlant(Klant klant, double transport, double onvolledigeLading, double bedrag, string opmerking)
        {
            Klant = klant;
            Transport = transport;
            OnvolledigeLading = onvolledigeLading;
            Bedrag = bedrag;
            Opmerking = opmerking;
        }
        public OfferteKlant(int id, Klant klant, double transport, double onvolledigeLading, double bedrag, string opmerking)
            : this(klant,transport,onvolledigeLading, bedrag,opmerking)
        {
            ID = id;
        }
        #endregion
        #region methods
        public static OfferteKlant ConvertFromDO(OfferteKlantDO offerteKlantDO)
        {
            OfferteKlant offerteKlant = new OfferteKlant(offerteKlantDO.ID, Klant.ConvertFromDO(offerteKlantDO.KlantDO), offerteKlantDO.Transport,offerteKlantDO.OnvolledigeLading,offerteKlantDO.Bedrag, offerteKlantDO.Opmerking);
            return offerteKlant;
        }

        public OfferteKlantDO ConvertToDO(OfferteKlant offerteKlant)
        {
            OfferteKlantDO offerteKlantDO = new OfferteKlantDO(ID, Klant.ConvertToDO(klant),Transport,OnvolledigeLading, Bedrag, Opmerking);
            return offerteKlantDO;
        }
        public static List<OfferteKlant> KrijgAlleOffertesDoorKlantID(int ID)
        {
            List<OfferteKlantDO> OfferteKlantDOs = DataAccess.KrijgAlleOffertesVanKlant(ID);
            List<OfferteKlant> OfferteKlants = new List<OfferteKlant>();
            foreach (OfferteKlantDO offerteKlantDO in OfferteKlantDOs)
            {
                OfferteKlants.Add(ConvertFromDO(offerteKlantDO));
            }
            return OfferteKlants;
        }

        public override string ToString()
        {
            return "Klant: " + klant.Naam;
        }

      

        public void MaakNieuweOfferte()
        {
            OfferteKlantDO offerteKlantDO = DataAccess.MaakNieuweOfferteKlant(ConvertToDO(this));
        }
        public void WijzigOfferte()
        {
            OfferteKlantDO offerteKlantDO = DataAccess.WijzigOfferteKlant(ConvertToDO(this));
        }
        #endregion
    }
}
