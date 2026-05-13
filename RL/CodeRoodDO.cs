using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class CodeRoodDO
    {
        #region variables
        private int id;
        private int bestelID;
        private int klantID;
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

        public int KlantID
        {
            get { return klantID; }
            set { klantID = value; }
        }

        #endregion


        #region constructors

        public CodeRoodDO()
        {

        }

        public CodeRoodDO(int bestelID, int klantID)
        {
            BestelID = bestelID;
            KlantID = klantID;
        }
        public CodeRoodDO(int id, int bestelID, int klantID)
            : this(bestelID, klantID)
        {
            ID = id;
        }
        #endregion

    }
}
