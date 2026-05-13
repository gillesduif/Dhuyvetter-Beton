using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class AfdrukWachtRijDO
    {
        #region variables 
        private int id;
        private int bestelID;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int BestelID
        {
            get { return bestelID; }
            set { bestelID = value; }
        }
        #endregion

        #region constructors

        public AfdrukWachtRijDO()
        {

        }
        public AfdrukWachtRijDO(int bestelID)
        {
            BestelID = bestelID;
        }
        public AfdrukWachtRijDO(int id, int bestelID)
            :this(bestelID)
        {
            ID = id;
        }
        #endregion
    }
}
