using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Korting_Product
    {
        #region variables
        private int id;
        private Klant klant;
        private Formule formule;
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

        public Formule Formule
        {
            get { return formule; }
            set { formule = value; }
        }

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_Product()
        {

        }
        public Korting_Product(Klant klant, Formule formule, double bedrag)
        {
            Klant = klant;
            Formule = formule;
            Bedrag = bedrag;
        }
        public Korting_Product(int id, Klant klant, Formule formule, double bedrag)
            : this(klant, formule, bedrag)
        {
            ID = id;
        }


        #endregion
        #region methods
        public static Korting_Product ConvertFromDO(Korting_ProductDO korting_ProductDO)
        {
            Korting_Product korting_Product = new Korting_Product(korting_ProductDO.ID, Klant.ConvertFromDO(korting_ProductDO.KlantDO), Formule.ConvertFromDO(korting_ProductDO.FormuleDO), korting_ProductDO.Bedrag);
            return korting_Product;
        }
        public Korting_ProductDO ConvertToDO(Korting_Product korting_Product)
        {
            Korting_ProductDO korting_ProductDO = new Korting_ProductDO(ID, Klant.ConvertToDO(klant), Formule.ConvertToDO(formule), Bedrag);
            return korting_ProductDO;
        }
        public void maakNieuweKorting()
        {
            Korting_ProductDO korting_ProductDO = DataAccess.MaakNieuweKortingProduct(ConvertToDO(this));
        }
        public override string ToString()
        {
            return "€" + Bedrag;
        }

        public static List<Korting_Product> KrijgKortingDoorProductID(int klantID, int productID)
        {
            List<Korting_ProductDO> korting_ProductDOs = DataAccess.KrijgAlleKortingenDoorProductID(klantID,productID);
            List<Korting_Product> korting_Products = new List<Korting_Product>();
            foreach (Korting_ProductDO korting_ProductDO in korting_ProductDOs)
            {
                korting_Products.Add(ConvertFromDO(korting_ProductDO));
            }
            return korting_Products;
        }

        public static List<Korting_Product> KrijgKortingProductDoorKlantID(int klantID)
        {
            List<Korting_ProductDO> korting_ProductDOs = DataAccess.KrijgAlleKortingenProductDoorKlantID(klantID);
            List<Korting_Product> korting_Products = new List<Korting_Product>();
            foreach (Korting_ProductDO korting_ProductDO in korting_ProductDOs)
            {
                korting_Products.Add(ConvertFromDO(korting_ProductDO));
            }
            return korting_Products;
        }

        public void WijzigKortingProduct()
        {
            Korting_ProductDO korting_ProductDO = DataAccess.UpdateKorting_ProductDO(ConvertToDO(this));
        }
        #endregion
    }
}
