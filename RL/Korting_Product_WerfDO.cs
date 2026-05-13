using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Korting_Product_WerfDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
        private WerfDO werfDO;
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
        public WerfDO WerfDO
        {
            get { return werfDO; }
            set { werfDO = value; }
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
        public Korting_Product_WerfDO()
        {

        }
        public Korting_Product_WerfDO(KlantDO klantDO,WerfDO werfDO, FormuleDO formuleDO, double bedrag)
        {
            KlantDO = klantDO;
            WerfDO = werfDO;
            FormuleDO = formuleDO;
            Bedrag = bedrag;
        }
        public Korting_Product_WerfDO(int id, KlantDO klantDO,WerfDO werfDO, FormuleDO formuleDO, double bedrag)
            : this(klantDO,werfDO, formuleDO, bedrag)
        {
            ID = id;
        }
        #endregion
    }
}
