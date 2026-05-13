using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class WerfPrefabDO
    {
        #region Variables
        private int id;
        private KlantPrefabDO klantPrefabDO;
        private string adres;
        private string gemeente;
        private string postcode;
        private ContactPersoonPrefabDO contactPersoonPrefabDO;

        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public KlantPrefabDO KlantPrefabDO
        {
            get { return klantPrefabDO; }
            set { klantPrefabDO = value; }
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

        public ContactPersoonPrefabDO ContactPersoonPrefabDO
        {
            get { return contactPersoonPrefabDO; }
            set { contactPersoonPrefabDO = value; }
        }

        #endregion

        #region Contructors
        public WerfPrefabDO()
        {

        }
        public WerfPrefabDO(KlantPrefabDO klantPrefabDO, string adres, string gemeente, string postcode, ContactPersoonPrefabDO contactPersoonPrefabDO)
        {
            KlantPrefabDO = klantPrefabDO;
            Adres = adres;
            Gemeente = gemeente;
            Postcode = postcode;
            ContactPersoonPrefabDO = contactPersoonPrefabDO;
        }

        public WerfPrefabDO(int id, KlantPrefabDO klantPrefabDO, string adres, string gemeente, string postcode, ContactPersoonPrefabDO contactPersoonPrefabDO)
            : this(klantPrefabDO, adres, gemeente, postcode, contactPersoonPrefabDO)
        {
            ID = id;
        }
        #endregion
    }
}
