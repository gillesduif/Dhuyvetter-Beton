using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class ContactPersoonPrefabDO
    {
        #region Variables
        private int id;
        private string naam;
        private string voornaam;
        private string telefoon;
        private string gsm;
        private KlantPrefabDO klantPrefabDO;
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

        public KlantPrefabDO KlantPrefabDO
        {
            get { return klantPrefabDO; }
            set { klantPrefabDO = value; }
        }


        #endregion

        #region Contructors
        public ContactPersoonPrefabDO()
        {

        }
        public ContactPersoonPrefabDO(string naam, string voornaam, string telefoon, string gsm, KlantPrefabDO klantPrefabDO)
        {
            Naam = naam;
            Voornaam = voornaam;
            Telefoon = telefoon;
            GSM = gsm;
            KlantPrefabDO = klantPrefabDO;
        }

        public ContactPersoonPrefabDO(int id, string naam, string voornaam, string telefoon, string gsm, KlantPrefabDO klantPrefabDO)
            : this(naam, voornaam, telefoon, gsm, klantPrefabDO)
        {
            ID = id;
        }
        #endregion
    }
}
