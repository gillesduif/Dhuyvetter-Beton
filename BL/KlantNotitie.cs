using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class KlantNotitie
    {
        #region Variables
        private int id;
        private Klant klant;
        private string notitie;
        #endregion
        #region Properties
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
        public string Notitie
        {
            get { return notitie; }
            set { notitie = value; }
        }
        #endregion

        #region Contructors
        public KlantNotitie()
        {

        }
        public KlantNotitie(Klant klant, string notitie)
        {
            Klant = klant;
            Notitie = notitie;
        }
        public KlantNotitie(int id,Klant klant, string notitie)
            :this(klant,notitie)
        {
            ID = id;
        }
        #endregion

        #region Methods
        public static KlantNotitie ConvertFromDO(KlantNotitieDO klantNotitieDO)
        {
            KlantNotitie klantNotitie = new KlantNotitie(klantNotitieDO.ID, Klant.ConvertFromDO(klantNotitieDO.KlantDO), klantNotitieDO.Notitie);

            return klantNotitie;
        }

        public KlantNotitieDO ConvertToDO(KlantNotitie klantNotitie)
        {
            KlantNotitieDO klantNotitieDO = new KlantNotitieDO(ID, Klant.ConvertToDO(Klant), Notitie);

            return klantNotitieDO;
        }

        public void MaakNieuweNotitie()
        {
            KlantNotitieDO klantNotitieDO = DataAccess.MaakNieuweKlantNotitie(ConvertToDO(this));
        }
        public override string ToString()
        {
            return Klant.Naam;
        }

        public static List<KlantNotitie> KrijgAlleNotities()
        {
            List<KlantNotitieDO> KlantNotitieDOs = DataAccess.SelecteerAlleNotities();
            List<KlantNotitie> KlantNotities = new List<KlantNotitie>();
            foreach (KlantNotitieDO klantNotitieDO in KlantNotitieDOs)
            {
                KlantNotities.Add(ConvertFromDO(klantNotitieDO));
            }
            return KlantNotities;

        }

        public static List<KlantNotitie> KrijgAlleNotitiesVanKlant(int klantID)
        {
            List<KlantNotitieDO> KlantNotitieDOs = DataAccess.SelecteerAlleNotitiesVanKlant(klantID);
            List<KlantNotitie> KlantNotities = new List<KlantNotitie>();
            foreach (KlantNotitieDO klantNotitieDO in KlantNotitieDOs)
            {
                KlantNotities.Add(ConvertFromDO(klantNotitieDO));
            }
            return KlantNotities;
        }
        #endregion
    }
}
