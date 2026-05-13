using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Korting_ProductDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
        private FormuleDO formuleDO;
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

        public FormuleDO FormuleDO
        {
            get { return formuleDO; }
            set { formuleDO = value; }
        }

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_ProductDO()
        {

        }
        public Korting_ProductDO(KlantDO klantDO, FormuleDO formuleDO, double bedrag)
        {
            KlantDO = klantDO;
            FormuleDO = formuleDO;
            Bedrag = bedrag;
        }
        public Korting_ProductDO(int id, KlantDO klantDO, FormuleDO formuleDO, double bedrag)
            : this(klantDO, formuleDO, bedrag)
        {
            ID = id;
        }
        #endregion
    }
}
