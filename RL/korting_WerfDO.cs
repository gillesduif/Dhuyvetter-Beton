using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Korting_WerfDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
        private WerfDO werfDO;
        private double bedrag;
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

        public WerfDO WerfDO
        {
            get { return werfDO; }
            set { werfDO = value; }
        }

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_WerfDO()
        {

        }

        public Korting_WerfDO(KlantDO klantDO, WerfDO werfDO, double bedrag)
        {
            KlantDO = klantDO;
            WerfDO = werfDO;
            Bedrag = bedrag;
        }
        public Korting_WerfDO(int id, KlantDO klantDO, WerfDO werfDO, double bedrag)
            : this(klantDO, werfDO, bedrag)
        {
            ID = id;
        }
        #endregion
    }
}
