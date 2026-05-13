using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Korting_KlantDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
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

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_KlantDO()
        {

        }
        public Korting_KlantDO(KlantDO klantDO, double bedrag)
        {
            KlantDO = klantDO;
            Bedrag = bedrag;
        }
        public Korting_KlantDO(int id, KlantDO klantDO, double bedrag)
            : this(klantDO, bedrag)
        {
            ID = id;
        }
        #endregion

      
    }
}
