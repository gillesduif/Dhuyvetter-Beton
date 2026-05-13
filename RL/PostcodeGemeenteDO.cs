using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class PostcodeGemeenteDO
    {
        #region variables
        private int id;
        private string postcode;
        private string gemeente;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }
        #endregion

        #region constructors
        public PostcodeGemeenteDO()
        {

        }
        public PostcodeGemeenteDO(int id, string postcode, string gemeente)
        {
            ID = id;
            Postcode = postcode;
            Gemeente = gemeente;
        }
        #endregion

      
    }
}
