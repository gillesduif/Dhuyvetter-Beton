using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class HulpstofPrijsDO
    {
        #region variables
        private int id;
        private string naam;
        private double bedrag;

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
        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public HulpstofPrijsDO()
        {
        }
        public HulpstofPrijsDO(string naam, double bedrag)
        {
            Naam = naam;
            Bedrag = bedrag;
        }

        public HulpstofPrijsDO(int id, string naam, double bedrag)
            : this(naam, bedrag)
        {
            ID = id;
        }
        #endregion
    }
}
