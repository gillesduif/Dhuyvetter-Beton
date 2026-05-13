using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class PrijsSettingDO
    {
        #region variables
        private int id;
        private byte soort;
        private KlantDO klantDO;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public byte Soort
        {
            get { return soort; }
            set { soort = value; }
        }
        public KlantDO KlantDO
        {
            get { return klantDO; }
            set { klantDO = value; }
        }
        #endregion

        #region constructors
        public PrijsSettingDO()
        {

        }
        public PrijsSettingDO(byte soort,KlantDO klantDO)
        {
            Soort = soort;
            KlantDO = klantDO;
        }
        public PrijsSettingDO(int id, byte soort, KlantDO klantDO)
            : this(soort,klantDO)
        {
            ID = id;
        }
        #endregion
    }
}
