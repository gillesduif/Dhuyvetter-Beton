using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class SoortenHulpstofDO
    {
        #region variables
        private int id;
        private string naam;

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
        #endregion

        #region constructors
        public SoortenHulpstofDO()
        {
       
        }
        public SoortenHulpstofDO(string naam)
        {
            Naam = naam;
        }

        public SoortenHulpstofDO(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        #endregion

    }
}
