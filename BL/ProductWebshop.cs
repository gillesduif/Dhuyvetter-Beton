using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductWebshop
    {
        #region Variables
        private int id;
        private Categorie categorie;
        private OmschrijvingProduct omschrijvingProduct;
        private Formule formule;
        private string afbeeldingLocatie;
        private string thumbLocatie;
        #endregion
        #region Properties 
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public Categorie Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        public OmschrijvingProduct OmschrijvingProduct
        {
            get { return omschrijvingProduct; }
            set { omschrijvingProduct = value; }
        }
        public Formule Formule
        {
            get { return formule; }
            set { formule = value; }
        }
        public string AfbeeldingLocatie
        {
            get { return afbeeldingLocatie; }
            set { afbeeldingLocatie = value; }
        }
        public string ThumbLocatie
        {
            get { return thumbLocatie; }
            set { thumbLocatie = value; }
        }
        #endregion

        #region Constructors 
        public ProductWebshop()
        {
        }
        public ProductWebshop(Categorie categorie, OmschrijvingProduct omschrijvingProduct, Formule formule, string afbeeldingLocatie, string thumbLocatie)
        {
            Categorie = categorie;
            OmschrijvingProduct = omschrijvingProduct;
            Formule = formule;
            AfbeeldingLocatie = afbeeldingLocatie;
            ThumbLocatie = thumbLocatie;
        }
        public ProductWebshop(int id,Categorie categorie, OmschrijvingProduct omschrijvingProduct, Formule formule, string afbeeldingLocatie, string thumbLocatie)
            :this(categorie,omschrijvingProduct,formule,afbeeldingLocatie, thumbLocatie)
        {
            ID = id;
        }


        #endregion

        #region methods
        public static ProductWebshop ConvertFromDO(ProductWebshopDO productWebshopDO)
        {
            ProductWebshop productWebshop = new ProductWebshop(productWebshopDO.ID, Categorie.ConvertFromDO(productWebshopDO.CategorieDO),OmschrijvingProduct.ConvertFromDO(productWebshopDO.OmschrijvingProductDO),Formule.ConvertFromDO(productWebshopDO.FormuleDO),productWebshopDO.AfbeeldingLocatie, productWebshopDO.ThumbLocatie);

            return productWebshop;
        }

        public ProductWebshopDO ConvertToDO(ProductWebshop productWebshop)
        {
            ProductWebshopDO productWebshopDO = new ProductWebshopDO(ID, Categorie.ConvertToDO(categorie),OmschrijvingProduct.ConvertToDO(omschrijvingProduct), Formule.ConvertToDO(formule), AfbeeldingLocatie,ThumbLocatie);

            return productWebshopDO;
        }

        public void MaakNieuwProductWebshop()
        {
            ProductWebshopDO productWebshopDO = DataAccess.MaakNieuweProductWebshop(ConvertToDO(this));
        }
        #endregion
    }
}
