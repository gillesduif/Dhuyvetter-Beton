using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Chauffeur
    {
        #region Variables

        private int id;
        private string naam;

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
        #endregion

        #region constructors
        public Chauffeur()
        {
         
        }
        public Chauffeur(string naam)
        {
            Naam = naam;
        }

        public Chauffeur(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        #endregion

        #region methods

        public static Chauffeur ConvertFromDO(ChauffeurDO chauffeurDO)
        {
            if (chauffeurDO!= null)
            {
                Chauffeur chauffeur = new Chauffeur(chauffeurDO.ID, chauffeurDO.Naam);

                return chauffeur;
            }
            else
            {
                return new Chauffeur(0, "");
            }
            
        }

        public ChauffeurDO ConvertToDO(Chauffeur chauffeur)
        {
            ChauffeurDO chauffeurDO = new ChauffeurDO(ID, Naam);

            return chauffeurDO;
        }

        public override string ToString()
        {
            return Naam;
        }

        public static List<Chauffeur> KrijgAlleChauffeurs()
        {
            List<ChauffeurDO> chauffeurDOs = DataAccess.KrijgAlleChauffeurs();
            List<Chauffeur> chauffeurs = new List<Chauffeur>();
            foreach (ChauffeurDO chauffeurDO in chauffeurDOs)
            {
                chauffeurs.Add(ConvertFromDO(chauffeurDO));
            }
            return chauffeurs;
        }
        #endregion
    }
}
