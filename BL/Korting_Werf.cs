using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Korting_Werf
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
        private double bedrag;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Klant Klant
        {
            get { return klant; }
            set { klant = value; }
        }

        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
        }

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_Werf()
        {

        }
        public Korting_Werf(Klant klant, Werf werf, double bedrag)
        {
            Klant = klant;
            Werf = werf;
            Bedrag = bedrag;
        }
        public Korting_Werf(int id,Klant klant, Werf werf, double bedrag)
            :this(klant,werf,bedrag)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static Korting_Werf ConvertFromDO(Korting_WerfDO korting_WerfDO)
        {
            Korting_Werf korting_Werf= new Korting_Werf(korting_WerfDO.ID, Klant.ConvertFromDO(korting_WerfDO.KlantDO), Werf.ConvertFromDO(korting_WerfDO.WerfDO), korting_WerfDO.Bedrag);
            return korting_Werf;
        }
        public  Korting_WerfDO ConvertToDO(Korting_Werf korting_Werf)
        {
            Korting_WerfDO korting_WerfDO = new Korting_WerfDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf),Bedrag);
            return korting_WerfDO;
        }
        public void maakNieuweKortingWerf()
        {
            Korting_WerfDO korting_WerfDO = DataAccess.MaakNieuweKortingWerf(ConvertToDO(this));
        }
        public override string ToString()
        {
            return "€" + Bedrag.ToString();
        }
        public static List<Korting_Werf> KrijgKortingDoorWerfID(int werfID)
        {
            List<Korting_WerfDO> Korting_WerfDOs = DataAccess.KrijgAlleKortingenDoorWerfID(werfID);
            List<Korting_Werf> Korting_Werfs = new List<Korting_Werf>();
            foreach (Korting_WerfDO korting_WerfDO in Korting_WerfDOs)
            {
                Korting_Werfs.Add(ConvertFromDO(korting_WerfDO));
            }
            return Korting_Werfs;
        }

        public static List<Korting_Werf> KrijgKortingDoorKlantID(int klantID)
        {
            List<Korting_WerfDO> Korting_WerfDOs = DataAccess.KrijgAlleKortingenDoorWerfKlantID(klantID);
            List<Korting_Werf> Korting_Werfs = new List<Korting_Werf>();
            foreach (Korting_WerfDO korting_WerfDO in Korting_WerfDOs)
            {
                Korting_Werfs.Add(ConvertFromDO(korting_WerfDO));
            }
            return Korting_Werfs;
        }

        public void UpdateKortingWerf()
        {
            Korting_WerfDO korting_WerfDO = DataAccess.UpdateKorting_WerfDO(ConvertToDO(this));
        }
        #endregion
    }
}
