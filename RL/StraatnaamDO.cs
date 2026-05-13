using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class StraatnaamDO
    {
        #region variables
        private int id;
        private string straat;

        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Straat
        {
            get { return straat; }
            set { straat = value; }
        }


        #endregion

        #region constructors
        public StraatnaamDO(int id, string straat, string gemeente)
        {
            ID = id;
            Straat = straat;
        }

        public StraatnaamDO()
        {
        }
        #endregion
    }
}
