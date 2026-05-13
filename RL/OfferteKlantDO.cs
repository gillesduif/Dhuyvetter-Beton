using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class OfferteKlantDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
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

        public KlantDO KlantDO
        {
            get { return klantDO; }
            set { klantDO = value; }
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
        public OfferteKlantDO()
        {

        }
        public OfferteKlantDO(KlantDO klantDO, double transport, double onvolledigeLading, double bedrag, string opmerking)
        {
            KlantDO = klantDO;
            Transport = transport;
            OnvolledigeLading = onvolledigeLading;
            Bedrag = bedrag;
            Opmerking = opmerking;
        }
        public OfferteKlantDO(int id, KlantDO klantDO, double transport, double onvolledigeLading, double bedrag, string opmerking)
            : this(klantDO, transport, onvolledigeLading, bedrag, opmerking)
        {
            ID = id;
        }
        #endregion
    }
}
