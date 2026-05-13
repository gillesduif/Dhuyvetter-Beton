using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pomp
    {
        #region Variables

        private int id;
        private string pompLeverancier;
        private string pomp;
        

        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string PompLeverancier
        {
            get { return pompLeverancier; }
            set { pompLeverancier = value; }
        }

        public string Pompdetails
        {
            get { return pomp; }
            set { pomp = value; }
        }




        #endregion

        #region Contructors
        public Pomp()
        {

        }
        public Pomp(string pompLeverancier, string pomp)
        {
            PompLeverancier = pompLeverancier;
            Pompdetails = pomp;
          
        }
        public Pomp(int id,string pompLeverancier, string pomp)
            : this(pompLeverancier, pomp)
        {
            ID = id;
        }
        #endregion

        #region Methods

        public static Pomp ConvertFromDO(PompDO pompDO)
        {
            if(pompDO != null)
            {
                return new Pomp(pompDO.ID, pompDO.PompLeverancier, pompDO.Pomp);
            }
            else
            {
                return new Pomp(0,"","");
            }
           
        }

        public PompDO ConvertToDO(Pomp pomp)
        {
            return new PompDO(ID, PompLeverancier, Pompdetails);
        }

        public static List<Pomp> KrijgAllePompen()
        {
            List<PompDO> PompDOs = DataAccess.KrijgAllePompen();
            List<Pomp> pomps = new List<Pomp>();
            foreach (PompDO pompDO in PompDOs)
            { 
                pomps.Add(ConvertFromDO(pompDO));
            }
            return pomps;
        }

        public override string ToString()
        {
            return PompLeverancier + " - " + Pompdetails;
        }

        public void MaakNieuwePomp()
        {
            PompDO pompDO = DataAccess.MaakNieuwePomp(ConvertToDO(this));
        }

        public void UpdateGegevens()
        {
            PompDO pompDO = DataAccess.UpdatePomp(ConvertToDO(this));
        }
        #endregion
    }
}
