using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class ProductPrefabDO
    {
        #region Variables
        private int id;
        private string lot;
        private string aantalstuks;
        private string langsteElement;
        private string m3;
        private int prefabBestellingID;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Lot
        {
            get { return lot; }
            set { lot = value; }
        }
        public string Aantalstuks
        {
            get { return aantalstuks; }
            set { aantalstuks = value; }
        }

        public string LangsteElement
        {
            get { return langsteElement; }
            set { langsteElement = value; }
        }

        public string M3
        {
            get { return m3; }
            set { m3 = value; }
        }
        public int PrefabBestellingID
        {
            get { return prefabBestellingID; }
            set { prefabBestellingID = value; }
        }

        #endregion

        #region Contructors
        public ProductPrefabDO()
        {

        }
        public ProductPrefabDO(string lot,string aantalstuks, string langsteElement, string m3)
        {
            Lot = lot;
            Aantalstuks = aantalstuks;
            LangsteElement = langsteElement;
            M3 = m3;
        }
        public ProductPrefabDO(string lot,string aantalstuks, string langsteElement, string m3, int prefabBestellingID)
        : this(lot,aantalstuks, langsteElement, m3)
        {
            PrefabBestellingID = prefabBestellingID;
        }
        public ProductPrefabDO(int id, string lot, string aantalstuks, string langsteElement, string m3)
            : this(lot,aantalstuks, langsteElement, m3)
        {
            ID = id;
        }
        public ProductPrefabDO(int id, string lot, string aantalstuks, string langsteElement, string m3, int prefabBestellingID)
     : this(id,lot, aantalstuks, langsteElement, m3)
        {
            PrefabBestellingID = prefabBestellingID;
        }


        #endregion

    }
}
