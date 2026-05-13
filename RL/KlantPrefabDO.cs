using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class KlantPrefabDO
    {
        #region variables
        private int id;
        private string naam;
        private string straat;
        private string postcode;
        private string gemeente;



        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }



        public string Straat
        {
            get { return straat; }
            set { straat = value; }
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
        public KlantPrefabDO()
        {

        }

        public KlantPrefabDO(string naam, string straat, string postcode, string gemeente)
        {
            Naam = naam;
            Straat = straat;
            Postcode = postcode;
            Gemeente = gemeente;
        }

        public KlantPrefabDO(int id, string naam, string straat, string postcode, string gemeente)
            : this(naam, straat, postcode, gemeente)
        {
            ID = id;
        }
        #endregion
    }
}
