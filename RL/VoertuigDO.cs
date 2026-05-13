using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class VoertuigDO
    {
        #region Variables

        private int id;
        private string nummerplaat;

        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nummerplaat
        {
            get { return nummerplaat; }
            set { nummerplaat = value; }
        }
        #endregion

        #region constructors
        public VoertuigDO()
        {
        }
        public VoertuigDO(string nummerplaat)
        {
            Nummerplaat = nummerplaat;
        }

        public VoertuigDO(int id, string nummerplaat)
            : this(nummerplaat)
        {
            ID = id;
        }
        #endregion
    }
}
