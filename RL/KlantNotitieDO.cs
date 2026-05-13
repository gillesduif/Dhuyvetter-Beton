using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class KlantNotitieDO
    {
        #region Variables
        private int id;
        private KlantDO klantDO;
        private string notitie;
        #endregion
        #region Properties
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
        public string Notitie
        {
            get { return notitie; }
            set { notitie = value; }
        }
        #endregion

        #region Contructors
        public KlantNotitieDO()
        {

        }
        public KlantNotitieDO(KlantDO klantDO, string notitie)
        {
            KlantDO = klantDO;
            Notitie = notitie;
        }
        public KlantNotitieDO(int id, KlantDO klantDO, string notitie)
            :this(klantDO,notitie)
        {
            ID = id;
        }
        #endregion
    }
}
