using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ContactPersoonPrefab
    {
        #region Variables
        private int id;
        private string naam;
        private string voornaam;
        private string telefoon;
        private string gsm;
        private KlantPrefab klantPrefab;
        #endregion

        #region Properties
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

        public string Voornaam
        {
            get { return voornaam; }
            set { voornaam = value; }
        }

        public string Telefoon
        {
            get { return telefoon; }
            set { telefoon = value; }
        }

        public string GSM
        {
            get { return gsm; }
            set { gsm = value; }
        }

        public KlantPrefab KlantPrefab
        {
            get { return klantPrefab; }
            set { klantPrefab = value; }
        }

     

        #endregion

        #region Contructors
        public ContactPersoonPrefab()
        {

        }
        public ContactPersoonPrefab(string naam, string voornaam, string telefoon, string gsm, KlantPrefab klantPrefab)
        {
            Naam = naam;
            Voornaam = voornaam;
            Telefoon = telefoon;
            GSM = gsm;
            KlantPrefab = klantPrefab;
        }

        public ContactPersoonPrefab(int id, string naam, string voornaam, string telefoon, string gsm, KlantPrefab klantPrefab)
            : this(naam, voornaam, telefoon, gsm, klantPrefab)
        {
            ID = id;
        }
        #endregion

        #region Methods

        public static ContactPersoonPrefab ConvertFromDO(ContactPersoonPrefabDO contactPersoonPrefabDO)
        {
            return new ContactPersoonPrefab(contactPersoonPrefabDO.ID, contactPersoonPrefabDO.Naam, contactPersoonPrefabDO.Voornaam, contactPersoonPrefabDO.Telefoon, contactPersoonPrefabDO.GSM, KlantPrefab.ConvertFromDO(contactPersoonPrefabDO.KlantPrefabDO));
        }

        public ContactPersoonPrefabDO ConvertToDO(ContactPersoonPrefab contactPersoonPrefab)
        {
            return new ContactPersoonPrefabDO(contactPersoonPrefab.ID, contactPersoonPrefab.Naam, contactPersoonPrefab.Voornaam, contactPersoonPrefab.Telefoon, contactPersoonPrefab.GSM ,KlantPrefab.ConvertToDO(contactPersoonPrefab.klantPrefab));
        }

        public override string ToString()
        {
            return voornaam + " " + naam;
        }

        public static List<ContactPersoonPrefab> KrijgAlleContactpersonenVanPrefabKlantViaID(int PrefabKlantID)
        {
            List<ContactPersoonPrefabDO> ContactPersoonPrefabDOs = DataAccess.KrijgAlleContactpersonenDoorKlantID(PrefabKlantID);
            List<ContactPersoonPrefab> ContactPersoonPrefabs = new List<ContactPersoonPrefab>();
            foreach (ContactPersoonPrefabDO contactPersoonPrefabDO in ContactPersoonPrefabDOs)
            {
                ContactPersoonPrefabs.Add(ConvertFromDO(contactPersoonPrefabDO));
            }
            return ContactPersoonPrefabs;
        }

        public void MaakNieuwContactPersoon()
        {
            ContactPersoonPrefabDO contactPersoonPrefabDO = DataAccess.MaakNieuweContactpersoonPrefab(ConvertToDO(this));
        }
        #endregion
    }
}
