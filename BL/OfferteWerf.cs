using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OfferteWerf
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
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
        public OfferteWerf()
        {

        }
        public OfferteWerf(Klant klant, Werf werf,double transport, double onvolledigeLading, double bedrag,string opmerking)
        {
            Klant = klant;
            Werf = werf;
            Transport = transport;
            OnvolledigeLading = onvolledigeLading;
            Bedrag = bedrag;
            Opmerking = opmerking;
        }
        public OfferteWerf(int id, Klant klant,Werf werf, double transport, double onvolledigeLading, double bedrag, string opmerking)
            : this(klant,werf, transport, onvolledigeLading, bedrag, opmerking)
        {
            ID = id;
        }
        #endregion
        #region methods
        public override string ToString()
        {
            return "Klant: " +  klant.Naam + " Werf: " + werf.Adres;
        }

        public static OfferteWerf ConvertFromDO(OfferteWerfDO offerteWerfDO)
        {
            OfferteWerf offerteWerf = new OfferteWerf(offerteWerfDO.ID, Klant.ConvertFromDO(offerteWerfDO.KlantDO), Werf.ConvertFromDO(offerteWerfDO.WerfDO),offerteWerfDO.Transport, offerteWerfDO.OnvolledigeLading, offerteWerfDO.Bedrag, offerteWerfDO.Opmerking);
            return offerteWerf;
        }

        public OfferteWerfDO ConvertToDO(OfferteWerf offerteWerf)
        {
            OfferteWerfDO offerteWerfDO = new OfferteWerfDO(ID, Klant.ConvertToDO(klant),Werf.ConvertToDO(werf), Transport, OnvolledigeLading, Bedrag, Opmerking);
            return offerteWerfDO;
        }
        public void MaakNieuweOfferte()
        {
            OfferteWerfDO offerteWerfDO = DataAccess.MaakNieuweOfferteWerf(ConvertToDO(this));
        }

        public void WijzigOfferte()
        {
            OfferteWerfDO offerteWerfDO = DataAccess.WijzigOfferteWerf(ConvertToDO(this));
        }

        public static List<OfferteWerf> KrijgAlleOffertesDoorKlantID(int iD)
        {
            List<OfferteWerfDO> OfferteWerfDOs = DataAccess.KrijgAlleOffertesWervenVanKlant(iD);
            List<OfferteWerf> OfferteWerfs = new List<OfferteWerf>();
            foreach (OfferteWerfDO offerteWerfDO in OfferteWerfDOs)
            {
                OfferteWerfs.Add(ConvertFromDO(offerteWerfDO));
            }
            return OfferteWerfs;
        }

        #endregion
    }
}
