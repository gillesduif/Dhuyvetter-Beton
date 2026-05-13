
using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OmschrijvingProduct
    {
        #region variables
        private int id;
        private string formule;
        private string omschrijving;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Formule
        {
            get { return formule; }
            set { formule = value; }
        }

        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        #endregion

        #region constructors
        public OmschrijvingProduct()
        {
           
        }
        public OmschrijvingProduct(string formule, string omschrijving)
        {
            Formule = formule;
            Omschrijving = omschrijving;
        }

        public OmschrijvingProduct(int id, string formule, string omschrijving)
            : this(formule, omschrijving)
        {
            ID = id;
        }

       
        #endregion

        #region methods

        public static OmschrijvingProduct ConvertFromDO(OmschrijvingProductDO omschrijvingProductDO)
        {
            OmschrijvingProduct omschrijvingProduct = new OmschrijvingProduct(omschrijvingProductDO.ID, omschrijvingProductDO.Formule, omschrijvingProductDO.Omschrijving);

            return omschrijvingProduct;
        }

        public OmschrijvingProductDO ConvertToDO(OmschrijvingProduct omschrijvingProduct)
        {
            OmschrijvingProductDO omschrijvingProductDO = new OmschrijvingProductDO(ID, Formule, Omschrijving);

            return omschrijvingProductDO;
        }

        public override string ToString()
        {
            return Omschrijving;
        }

        public static List<OmschrijvingProduct> KrijgAlleOmschrijvingen()
        {
            List<OmschrijvingProductDO> omschrijvingProductDOs = DataAccess.KrijgAlleProductOmschrijving();
            List<OmschrijvingProduct> omschrijvingProducts = new List<OmschrijvingProduct>();
            foreach (OmschrijvingProductDO omschrijvingProductDO in omschrijvingProductDOs)
            {
                omschrijvingProducts.Add(ConvertFromDO(omschrijvingProductDO));
            }
            omschrijvingProducts.Sort((X, Y) => X.Omschrijving.CompareTo(Y.Omschrijving));
            return omschrijvingProducts;
        }
    

        public static OmschrijvingProduct KrijgOmschrijvingenViaFormule(string naam)
        {
            OmschrijvingProductDO omschrijvingProductDO = DataAccess.KrijgProductOmschrijvingviaFormule(naam);
            return ConvertFromDO(omschrijvingProductDO);
        }
        public void maakNieuweOmschrijving()
        {
            OmschrijvingProductDO omschrijvingProductDO = DataAccess.MaakNieuweProductOmschrijving(ConvertToDO(this));
        }

        public void Wijzigen()
        {
            OmschrijvingProductDO omschrijvingProductDO = DataAccess.WijzigProductOmschrijving(ConvertToDO(this));
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
