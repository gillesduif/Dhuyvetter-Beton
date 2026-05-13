using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Straatnaam
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
        public Straatnaam(int id, string straat)
        {
            ID = id;
            Straat= straat;
        }
        #endregion

        #region methods
        public static Straatnaam ConvertFromDO(StraatnaamDO straatnaamDO)
        {
            return new Straatnaam(straatnaamDO.ID, straatnaamDO.Straat);
        }
        public override string ToString()
        {
            return Straat;
        }
        public static List<Straatnaam> KrijgAlleStraten()
        {
            List<StraatnaamDO> StratenDOs = new List<StraatnaamDO>();
            List<Straatnaam> stratens = new List<Straatnaam>();
            foreach (StraatnaamDO straatnaamDO in StratenDOs)
            {
                stratens.Add(ConvertFromDO(straatnaamDO));
            }
            return stratens;
        }
        #endregion
    }
}
