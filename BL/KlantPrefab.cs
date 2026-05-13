using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class KlantPrefab
    {
        #region variables
        private int id;
        private string naam;
        private string straat;
        private string postcode;
        private string gemeente;
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



        public string Straat
        {
            get { return straat; }
            set { straat = value; }
        }

     

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }
  
        #endregion

        #region constructors
        public KlantPrefab()
        {

        }

        public KlantPrefab(string naam, string straat, string postcode, string gemeente)
        {
            Naam = naam;
            Straat = straat;
            Postcode = postcode;
            Gemeente = gemeente;
        }

        public KlantPrefab(int id, string naam, string straat, string postcode, string gemeente)
            : this(naam, straat, postcode, gemeente)
        {
            ID = id;
        }
        #endregion

        #region Methods

        public static KlantPrefab ConvertFromDO(KlantPrefabDO klantPrefabDO)
        {
            return new KlantPrefab(klantPrefabDO.ID, klantPrefabDO.Naam,  klantPrefabDO.Straat, klantPrefabDO.Postcode, klantPrefabDO.Gemeente);
        }

        public KlantPrefabDO ConvertToDO(KlantPrefab klantPrefab)
        {
            return new KlantPrefabDO(klantPrefab.ID, klantPrefab.naam, klantPrefab.straat, klantPrefab.postcode, klantPrefab.gemeente);
        }

        public override string ToString()
        {
            return naam ;
        }

        public static List<KlantPrefab> KrijgAllePrefabKlanten()
        {
            List<KlantPrefabDO> KlantPrefabDOs = DataAccess.KrijgAllePrefabKlanten();
            List<KlantPrefab> KlantPrefabs = new List<KlantPrefab>();
            foreach (KlantPrefabDO klantPrefabDO in KlantPrefabDOs)
            {
                KlantPrefabs.Add(ConvertFromDO(klantPrefabDO));
            }
            return KlantPrefabs;
        }

        public void MaakNieuweKlant()
        {
            KlantPrefabDO klantPrefabDO = DataAccess.MaakNieuwePrefabKlant(ConvertToDO(this));
        }
        #endregion
    }
}
