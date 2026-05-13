using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class WerfPrefab
    {
        #region Variables
        private int id;
        private KlantPrefab klantPrefab;
        private string adres;
        private string gemeente;
        private string postcode;
        private ContactPersoonPrefab contactPersoonPrefab;

        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public KlantPrefab KlantPrefab
        {
            get { return klantPrefab; }
            set { klantPrefab = value; }
        }
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public ContactPersoonPrefab ContactPersoonPrefab
        {
            get { return contactPersoonPrefab; }
            set { contactPersoonPrefab = value; }
        }
        #endregion

        #region Contructors
        public WerfPrefab()
        {

        }
        public WerfPrefab(KlantPrefab klantPrefab, string adres, string gemeente, string postcode, ContactPersoonPrefab contactPersoonPrefab)
        {
            KlantPrefab = klantPrefab;
            Adres = adres;
            Gemeente = gemeente;
            Postcode = postcode;
            ContactPersoonPrefab = contactPersoonPrefab;
        }
        public WerfPrefab(int id, KlantPrefab klantPrefab, string adres, string gemeente, string postcode, ContactPersoonPrefab contactPersoonPrefab)
            : this(klantPrefab, adres, gemeente, postcode, contactPersoonPrefab)
        {
            ID = id;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Adres + " " + Gemeente + " " + Postcode;
        }
        public static WerfPrefab ConvertFromDO(WerfPrefabDO werfPrefabDO)
        {
            return new WerfPrefab(werfPrefabDO.ID, KlantPrefab.ConvertFromDO(werfPrefabDO.KlantPrefabDO), werfPrefabDO.Adres, werfPrefabDO.Gemeente, werfPrefabDO.Postcode, ContactPersoonPrefab.ConvertFromDO(werfPrefabDO.ContactPersoonPrefabDO));
        }

        public WerfPrefabDO ConvertToDO(WerfPrefab werfPrefab)
        {
            return new WerfPrefabDO(werfPrefab.ID, KlantPrefab.ConvertToDO(werfPrefab.KlantPrefab), werfPrefab.Adres, werfPrefab.Gemeente, werfPrefab.Postcode,ContactPersoonPrefab.ConvertToDO(werfPrefab.ContactPersoonPrefab));
        }
        public void MaakNieuweWerf()
        {
            WerfPrefabDO werfPrefabDO = DataAccess.MaakNieuweWerfPrefab(ConvertToDO(this));
        }

        public static List<WerfPrefab> KrijgAlleWervenVanPrefab(int ID)
        {
            List<WerfPrefabDO> WerfPrefabDOs = DataAccess.KrijgAlleWervenPrefabDoorKlantID(ID);
            List<WerfPrefab> WerfPrefabs = new List<WerfPrefab>();
            foreach (WerfPrefabDO werfPrefabDO in WerfPrefabDOs)
            {
                WerfPrefabs.Add(ConvertFromDO(werfPrefabDO));
            }
            return WerfPrefabs;
        }
        #endregion
    }
}
