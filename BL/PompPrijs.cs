using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PompPrijs
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
        public PompPrijs()
        {
        }
        public PompPrijs(string giek,double bedrag, double suppliment)
        {
            Giek = giek;
            Bedrag = bedrag;
            Suppliment = suppliment;
        }
        public PompPrijs(int id, string giek, double bedrag, double suppliment)
            : this(giek,bedrag, suppliment)
        {
            ID = id;
        }

        public object ToStringGiek()
        {
            return giek;
        }
        #endregion

        #region methods
        public static PompPrijs ConvertFromDO(PompPrijsDO pompPrijsDO)
        {
            PompPrijs pompPrijs = new PompPrijs(pompPrijsDO.ID, pompPrijsDO.Giek,pompPrijsDO.Bedrag, pompPrijsDO.Suppliment);

            return pompPrijs;
        }

        public PompPrijsDO ConvertToDO(PompPrijs pompPrijs)
        {
            PompPrijsDO pompPrijsDO = new PompPrijsDO(ID,giek,bedrag,suppliment);

            return pompPrijsDO;
        }
        public override string ToString()
        {
            return Bedrag.ToString();
            
        }
        public static List<PompPrijs> KrijgAllePompPrijzen()
        {
            List<PompPrijsDO> PompPrijsDOs = DataAccess.KrijgAllePompPrijzen();
            List<PompPrijs> pompprijss = new List<PompPrijs>();
            foreach (PompPrijsDO pompPrijsDO in PompPrijsDOs)
            {
                pompprijss.Add(ConvertFromDO(pompPrijsDO));
            }
            return pompprijss;
        }

        public void Wijzigen()
        {
            PompPrijsDO pompPrijsDO = DataAccess.UpdatePompPrijs(ConvertToDO(this));
        }
        #endregion
    }
}
