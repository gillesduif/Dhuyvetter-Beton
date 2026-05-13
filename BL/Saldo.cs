
using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Saldo
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
        public Saldo()
        {

        }
        public Saldo(int id)
        {
            ID = id;
        }
        public Saldo(int id, int bestellingID)
            : this(id)
        {
            BestelID = bestellingID;
        }
        #endregion
        #region methods
        public static Saldo ConvertFromDO(SaldoDO saldoDO)
        {
            Saldo saldo = new Saldo(saldoDO.ID, saldoDO.BestelID);
            return saldo;
        }

        public SaldoDO ConvertToDO(Saldo saldo)
        {
            SaldoDO saldoDO = new SaldoDO(ID,bestelID);
            return saldoDO;
        }


        public Saldo MaakNieuweSaldo()
        {
            SaldoDO saldoDO = DataAccess.MaakNieuweSaldo(ConvertToDO(this));
            return ConvertFromDO(saldoDO);
        }
        #endregion
    }
}
