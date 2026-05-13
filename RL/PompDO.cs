using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class PompDO
    {
        #region Variables

        private int id;
        private string pompLeverancier;
        private string pomp;
  
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string PompLeverancier
        {
            get { return pompLeverancier; }
            set { pompLeverancier = value; }
        }

        public string Pomp
        {
            get { return pomp; }
            set { pomp = value; }
        }
        #endregion

        #region Contructors
        public PompDO()
        {
        }
        public PompDO(string pompLeverancier, string pomp)
        {
            PompLeverancier = pompLeverancier;
            Pomp = pomp;

        
        }
        public PompDO(int id,string pompLeverancier, string pomp)
            : this(pompLeverancier, pomp)
        {
            ID = id;
        }
        #endregion
    }
}
