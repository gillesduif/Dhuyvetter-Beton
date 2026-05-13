using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class Hulpstof_Factuur_ItemDO
    {
        #region variables
        private int id;
        private Factuur_ItemDO factuur_ItemDO;
        private string hulpstof;
        private double eenheidsPrijsHulpstof;
        private double totaalPrijsHulpstof;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Factuur_ItemDO Factuur_ItemDO
        {
            get { return factuur_ItemDO; }
            set { factuur_ItemDO = value; }
        }
        public string Hulpstof
        {
            get { return hulpstof; }
            set { hulpstof = value; }
        }
        public double EenheidsPrijsHulpstof
        {
            get { return eenheidsPrijsHulpstof; }
            set { eenheidsPrijsHulpstof = value; }
        }
        public double TotaalPrijsHulpstof
        {
            get { return totaalPrijsHulpstof; }
            set { totaalPrijsHulpstof = value; }
        }
        #endregion

        #region constructors
        public Hulpstof_Factuur_ItemDO()
        {
        }
        public Hulpstof_Factuur_ItemDO(Factuur_ItemDO factuur_ItemDO, string hulpstof, double eenheidsPrijsHulpstof, double totaalPrijsHulpstof)
        {
            Factuur_ItemDO = factuur_ItemDO;
            Hulpstof = hulpstof;
            EenheidsPrijsHulpstof = eenheidsPrijsHulpstof;
            TotaalPrijsHulpstof = totaalPrijsHulpstof;
        }

        public Hulpstof_Factuur_ItemDO(int id, Factuur_ItemDO factuur_ItemDO, string hulpstof, double eenheidsPrijsHulpstof, double totaalPrijsHulpstof)
          : this(factuur_ItemDO, hulpstof, eenheidsPrijsHulpstof, totaalPrijsHulpstof)
        {
            ID = id;
        }
        #endregion
    }
}
