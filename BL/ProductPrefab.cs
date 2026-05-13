using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductPrefab
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
        public ProductPrefab()
        {

        }
        public ProductPrefab(string lot,string aantalstuks, string langsteElement, string m3)
        {
            Lot = lot;
            Aantalstuks = aantalstuks;
            LangsteElement = langsteElement;
            M3 = m3;
        }
        public ProductPrefab(string lot,string aantalstuks, string langsteElement, string m3, int prefabBestellingID)
        : this(lot,aantalstuks, langsteElement, m3)
        {
            PrefabBestellingID = prefabBestellingID;
        }
        public ProductPrefab(int id, string lot,string aantalstuks, string langsteElement, string m3)
            :this(lot,aantalstuks, langsteElement, m3)
        {
            ID = id;
        }
        public ProductPrefab(int id, string lot,string aantalstuks, string langsteElement, string m3, int prefabBestellingID)
         : this(id,lot,aantalstuks, langsteElement, m3)
        {
   
            PrefabBestellingID = prefabBestellingID;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Lot: " + Lot + " Aantal stuks: " + Aantalstuks + " Langste element: " + LangsteElement + " M3: " + M3.ToString();
        }
        public static ProductPrefab ConvertFromDO(ProductPrefabDO productPrefabDO)
        {
            return new ProductPrefab(productPrefabDO.ID, productPrefabDO.Lot, productPrefabDO.Aantalstuks, productPrefabDO.LangsteElement, productPrefabDO.M3, productPrefabDO.PrefabBestellingID);
        }

        public static ProductPrefabDO ConvertToDO(ProductPrefab productPrefab)
        {
            return new ProductPrefabDO(productPrefab.ID, productPrefab.Lot, productPrefab.Aantalstuks, productPrefab.LangsteElement, productPrefab.M3, productPrefab.PrefabBestellingID);
        }

        public void Wijzigen()
        {
            ProductPrefabDO productPrefabDO = DataAccess.WijzigProductPrefab(ConvertToDO(this));
        }

        public static List<ProductPrefab> KrijgProductenVoorBestelling(int ID)
        {
            List<ProductPrefabDO> ProductPrefabDOs = DataAccess.KrijgAlleProductenViaID(ID);
            List<ProductPrefab> ProductPrefabs = new List<ProductPrefab>();
            foreach (ProductPrefabDO productPrefabDO in ProductPrefabDOs)
            {
                ProductPrefabs.Add(ConvertFromDO(productPrefabDO));
            }
            return ProductPrefabs;
        }

        #endregion
    }
}

