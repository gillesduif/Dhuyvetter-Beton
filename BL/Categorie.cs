using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categorie
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
        public Categorie()
        {
        }


        public Categorie(string naam)
        {
            Naam = naam;
        }

        public Categorie(int id, string naam)
            : this(naam)
        {
           ID = id;
        }


        #endregion

        #region methods
        public static Categorie ConvertFromDO(CategorieDO categorieDO)
        {
            Categorie categorie = new Categorie(categorieDO.ID, categorieDO.Naam);

            return categorie;
        }

        public CategorieDO ConvertToDO(Categorie categorie)
        {
            CategorieDO categorieDO = new CategorieDO(ID, Naam);

            return categorieDO;
        }

        public override string ToString()
        {
            return Naam;
        }

        public static List<Categorie> KrijgAlleCategories()
        {
            List<CategorieDO> categorieDOs = DataAccess.KrijgAlleCategories();
            List<Categorie> categories = new List<Categorie>();
            foreach (CategorieDO categorieDO in categorieDOs)
            {
                categories.Add(ConvertFromDO(categorieDO));
            }
            return categories;
        }

        public void MaakNieuweCategorie()
        {
            CategorieDO categorieDO = DataAccess.MaakNieuweCategorie(ConvertToDO(this));
        }

        #endregion
    }
}
