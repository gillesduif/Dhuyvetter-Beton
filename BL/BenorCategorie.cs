using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BenorCategorie
    {
        #region Variables

        private int id;
        private string naam;

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

        #endregion



        #region Constructors
        public BenorCategorie()
        {
        }


        public BenorCategorie(string naam)
        {
            Naam = naam;
        }

        public BenorCategorie(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static BenorCategorie ConvertFromDO(BenorCategorieDO benorCategorieDO)
        {
            BenorCategorie benorCategorie = new BenorCategorie(benorCategorieDO.ID, benorCategorieDO.Naam);

            return benorCategorie;
        }

        public BenorCategorieDO ConvertToDO(BenorCategorie benorCategorie)
        {
            BenorCategorieDO BenorCategorieDO = new BenorCategorieDO(ID, Naam);

            return BenorCategorieDO;
        }

        public override string ToString()
        {
            return Naam;
        }

        public static List<BenorCategorie> KrijgAlleCategories()
        {
            List<BenorCategorieDO> categorieDOs = DataAccess.KrijgAlleBenorCategories();
            List<BenorCategorie> categories = new List<BenorCategorie>();
            foreach (BenorCategorieDO benorCategorieDO in categorieDOs)
            {
                categories.Add(ConvertFromDO(benorCategorieDO));
            }
            return categories;
        }

        public void MaakNieuweCategorie()
        {
            BenorCategorieDO benorCategorieDO = DataAccess.MaakNieuweBenorCategorie(ConvertToDO(this));
        }

        #endregion
    }
}
