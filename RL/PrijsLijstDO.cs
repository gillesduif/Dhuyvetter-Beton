using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class PrijsLijstDO
    {
        #region variables
        private int id;
        private string formule;
        private double aannemer;
        private double particulier;
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

        public double Aannemer
        {
            get { return aannemer; }
            set { aannemer = value; }
        }
        public double Particulier
        {
            get { return particulier; }
            set { particulier = value; }
        }
        #endregion

        #region constructors
        public PrijsLijstDO()
        {

        }
        public PrijsLijstDO(string formule, double aannemer, double particulier)
        {
            Formule = formule;
            Aannemer = aannemer;
            Particulier = particulier;
        }

        public PrijsLijstDO(int id, string formule, double aannemer, double particulier)
            : this(formule, aannemer, particulier)
        {
            ID = id;
        }
        #endregion
        #region methods

        #endregion

    }
}
