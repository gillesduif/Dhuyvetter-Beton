using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Korting_Klant
    {
        #region variables
        private int id;
        private Klant klant;
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

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_Klant()
        {

        }
        public Korting_Klant(Klant klant, double bedrag)
        {
            Klant = klant;
       
            Bedrag = bedrag;
        }
        public Korting_Klant(int id, Klant klant, double bedrag)
            : this(klant, bedrag)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static Korting_Klant ConvertFromDO(Korting_KlantDO korting_KlantDO)
        {
            Korting_Klant korting_Klant = new Korting_Klant(korting_KlantDO.ID, Klant.ConvertFromDO(korting_KlantDO.KlantDO), korting_KlantDO.Bedrag);
            return korting_Klant;
        }
        public Korting_KlantDO ConvertToDO(Korting_Klant korting_Klant)
        {
            Korting_KlantDO korting_KlantDO = new Korting_KlantDO(ID, Klant.ConvertToDO(klant),Bedrag);
            return korting_KlantDO;
        }
        public void maakNieuweKortingKlant()
        {
            Korting_KlantDO korting_KlantDO = DataAccess.MaakNieuweKortingKlant(ConvertToDO(this));
        }
        public override string ToString()
        {
            return "€" + Bedrag.ToString();
        }
        public static List<Korting_Klant> KrijgKortingDoorKlantID(int klantID)
        {
            List<Korting_KlantDO> Korting_KlantDOs = DataAccess.KrijgAlleKortingenDooKlantID(klantID);
            List<Korting_Klant> Korting_Klants = new List<Korting_Klant>();
            foreach (Korting_KlantDO korting_KlantDO in Korting_KlantDOs)
            {
                Korting_Klants.Add(ConvertFromDO(korting_KlantDO));
            }
            return Korting_Klants;
        }

        public void UpdateKlantKorting()
        {
            Korting_KlantDO korting_KlantDO = DataAccess.UpdateKlantKorting(ConvertToDO(this));
        }
        #endregion
    }
}
