using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class HulpstofPrijs
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
        public HulpstofPrijs()
        {
        
        }
        public HulpstofPrijs(string naam,double bedrag)
        {
            Naam = naam;
            Bedrag = bedrag;
        }

        public HulpstofPrijs(int id, string naam, double bedrag)
            : this(naam,bedrag)
        {
            ID = id;
        }
        #endregion
        #region methods
        public static HulpstofPrijs ConvertFromDO(HulpstofPrijsDO hulpstofPrijsDO)
        {
            HulpstofPrijs hulpstofPrijs = new HulpstofPrijs(hulpstofPrijsDO.ID, hulpstofPrijsDO.Naam, hulpstofPrijsDO.Bedrag);
            return hulpstofPrijs;
        }

        public HulpstofPrijsDO ConvertToDO(HulpstofPrijs hulpstofPrijs)
        {
            HulpstofPrijsDO hulpstofPrijsDO = new HulpstofPrijsDO(hulpstofPrijs.ID, hulpstofPrijs.Naam, hulpstofPrijs.Bedrag);
            return hulpstofPrijsDO;
        }

        public override string ToString()
        {
            return Naam;
        }

        public static List<HulpstofPrijs> KrijgAllePrijzenHulpstof()
        {
            List<HulpstofPrijsDO> HulpstofPrijsDOs = DataAccess.KrijgAllePrijzenHulpstoffen();
            List<HulpstofPrijs> HulpstofPrijss = new List<HulpstofPrijs>();
            foreach (HulpstofPrijsDO hulpstofPrijsDO in HulpstofPrijsDOs)
            {
                HulpstofPrijss.Add(ConvertFromDO(hulpstofPrijsDO));
            }
            return HulpstofPrijss;
        }
        #endregion
    }
}
