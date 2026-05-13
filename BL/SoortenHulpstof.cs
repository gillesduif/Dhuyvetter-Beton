using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using RL;


namespace BL
{
    public class SoortenHulpstof
    {
        #region variables
        private int id;
        private string naam;
       
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
        #endregion

        #region constructors
        public SoortenHulpstof(string naam)
        {
            Naam = naam;
        }

        public SoortenHulpstof(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static SoortenHulpstof ConvertFromDO(SoortenHulpstofDO soortenHulpstofDO)
        {
            SoortenHulpstof soortenHulpstof = new SoortenHulpstof(soortenHulpstofDO.ID, soortenHulpstofDO.Naam);
            return soortenHulpstof;
        }

        public SoortenHulpstofDO ConvertToDO(Hulpstof hulpstof)
        {
            SoortenHulpstofDO soortenHulpstofDO = new SoortenHulpstofDO(hulpstof.ID, hulpstof.Naam);
            return soortenHulpstofDO;
        }

        public override string ToString()
        {
            return Naam;
        }
        public static List<SoortenHulpstof> KrijgAlleSoortenHulpstof()
        {
            List<SoortenHulpstofDO> SoortenHulpstofDOs = DataAccess.KrijgAlleSoortenHulpstoffen();
            List<SoortenHulpstof> SoortenHulpstofen = new List<SoortenHulpstof>();
            foreach (SoortenHulpstofDO soortenHulpstofDO in SoortenHulpstofDOs)
            {
                SoortenHulpstofen.Add(ConvertFromDO(soortenHulpstofDO));
            }
            return SoortenHulpstofen;
        }
        #endregion
    }
}
