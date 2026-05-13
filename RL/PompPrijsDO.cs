using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class PompPrijsDO
    {
        #region variables
        private int id;
        private string giek;
        private double bedrag;
        private double suppliment;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Giek
        {
            get { return giek; }
            set { giek = value; }
        }
        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        public double Suppliment
        {
            get { return suppliment; }
            set { suppliment = value; }
        }


        #endregion

        #region constructors
        public PompPrijsDO()
        {
        }
        public PompPrijsDO(string giek, double bedrag ,double suppliment)
        {
            Giek = giek;
            Bedrag = bedrag;
            Suppliment = suppliment;
        }
        public PompPrijsDO(int id, string giek, double bedrag, double suppliment)
            : this(giek, bedrag, suppliment)
        {
            ID = id;
        }
        #endregion
    }
}
