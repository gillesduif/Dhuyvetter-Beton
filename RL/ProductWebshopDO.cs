using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class ProductWebshopDO
    {
        #region Variables
        private int id;
        private CategorieDO categorieDO;
        private OmschrijvingProductDO omschrijvingProductDO;
        private FormuleDO formuleDO;
        private string afbeeldingLocatie;
        private string thumbLocatie;
        #endregion
        #region Properties 
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public CategorieDO CategorieDO
        {
            get { return categorieDO; }
            set { categorieDO = value; }
        }
        public OmschrijvingProductDO OmschrijvingProductDO
        {
            get { return omschrijvingProductDO; }
            set { omschrijvingProductDO = value; }
        }
        public FormuleDO FormuleDO
        {
            get { return formuleDO; }
            set { formuleDO = value; }
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
        public ProductWebshopDO()
        {
        }


        public ProductWebshopDO(CategorieDO categorieDO, OmschrijvingProductDO omschrijvingProductDO, FormuleDO formuleDO, string afbeeldingLocatie, string thumbLocatie)
        {
            CategorieDO = categorieDO;
            OmschrijvingProductDO = omschrijvingProductDO;
            FormuleDO = formuleDO;
            AfbeeldingLocatie = afbeeldingLocatie;
            ThumbLocatie = thumbLocatie;
        }
        public ProductWebshopDO(int id, CategorieDO categorieDO, OmschrijvingProductDO omschrijvingProductDO, FormuleDO formuleDO, string afbeeldingLocatie, string thumbLocatie)
            : this(categorieDO, omschrijvingProductDO, formuleDO, afbeeldingLocatie, thumbLocatie)
        {
            ID = id;
        }
        #endregion
    }
}
