using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class SaldoDO
    {
        #region variables
        private int id;
        private int bestelID;
        private int normaleleveringID;
        private double m3;
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
        public int NormaleLeveringID
        {
            get { return normaleleveringID; }
            set { normaleleveringID = value; }
        }
        public double M3
        {
            get { return m3; }
            set { m3 = value; }
        }
        #endregion
        #region constructors
        public SaldoDO()
        {

        }
        public SaldoDO(int id)
        {
            ID = id;
        }
        public SaldoDO(int id,int bestellingID)
            :this(id)
        {
            bestelID = bestellingID;
        }
        #endregion
    }
}
