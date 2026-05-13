using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class OmschrijvingProductDO
    {
        #region variables
        private int id;
        private string formule;
        private string omschrijving;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Formule
        {
            get { return formule; }
            set { formule = value; }
        }

        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        #endregion

        #region constructors
        public OmschrijvingProductDO()
        {
        }

        public OmschrijvingProductDO(string formule, string omschrijving)
        {
            Formule = formule;
            Omschrijving = omschrijving;
        }

        public OmschrijvingProductDO(int id, string formule, string omschrijving)
            : this(formule, omschrijving)
        {
            ID = id;
        }
        #endregion
    }
}
