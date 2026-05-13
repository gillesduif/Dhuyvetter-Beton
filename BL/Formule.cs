using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Formule
    {
        #region variables
        private int id;
        private string naam;
        private string sterkteKlasse;
        private string omgevingsKlasse;
        private string vloeibaarheid;
        private string samenstelling;
        private string granuleDiameter;
        private string cemmentType;
        private bool isBenor;
        private BenorCategorie benorCategorie;
        private string maatEenheid;
        private string omschrijving;
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

        public string SterkteKlasse
        {
            get { return sterkteKlasse; }
            set { sterkteKlasse = value; }
        }

        public string CemmentType
        {
            get { return cemmentType; }
            set { cemmentType = value; }
        }

        public string OmgevingsKlasse
        {
            get { return omgevingsKlasse; }
            set { omgevingsKlasse = value; }
        }

        public string Vloeibaarheid
        {
            get { return vloeibaarheid; }
            set { vloeibaarheid = value; }
        }

        public string Samenstelling
        {
            get { return samenstelling; }
            set { samenstelling = value; }
        }


        public string GranuleDiameter
        {
            get { return granuleDiameter; }
            set { granuleDiameter = value; }
        }
        public bool IsBenor 
        {
            get { return isBenor; } 
            set { isBenor = value; } 
        }
        public BenorCategorie BenorCategorie
        {
            get { return benorCategorie; }
            set { benorCategorie = value; }
        }
        public string MaatEenheid
        {
            get { return maatEenheid; }
            set { maatEenheid = value; }
        }

        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        #endregion

        #region constructors
        public Formule()
        {

        }
        public Formule(string naam, string sterkteKlasse, string cemmentType, string omgevingsKlasse, string vloeibaarheid, string samenstelling, string granuleDiameter,bool isBenor, BenorCategorie benorCategorie, string maatEenheid, string omschrijving)
        {
            Naam = naam;
            SterkteKlasse = sterkteKlasse;
            CemmentType = cemmentType;
            OmgevingsKlasse = omgevingsKlasse;
            Vloeibaarheid = vloeibaarheid;
            Samenstelling = samenstelling;
            GranuleDiameter = granuleDiameter;
            IsBenor = isBenor;
            BenorCategorie = benorCategorie;
            MaatEenheid = maatEenheid;
            Omschrijving = omschrijving;
        }

        public Formule(int id, string naam, string sterkteKlasse, string cemmentType, string omgevingsKlasse, string vloeibaarheid, string samenstelling, string granuleDiameter, bool isBenor, BenorCategorie benorCategorie, string maatEenheid, string omschrijving)
            : this(naam, sterkteKlasse, cemmentType, omgevingsKlasse, vloeibaarheid, samenstelling, granuleDiameter,isBenor,benorCategorie,maatEenheid, omschrijving)
        {
            ID = id;
        }
        #endregion

        #region methods

        public static Formule ConvertFromDO(FormuleDO formuleDO)
        {
            if(formuleDO != null)
            {
                Formule formule = new Formule(formuleDO.ID, formuleDO.Naam, formuleDO.SterkteKlasse, formuleDO.CemmentType, formuleDO.OmgevingsKlasse, formuleDO.Vloeibaarheid, formuleDO.Samenstelling, formuleDO.GranuleDiameter, formuleDO.IsBenor, BenorCategorie.ConvertFromDO(formuleDO.BenorCategorieDO), formuleDO.MaatEenheid, formuleDO.Omschrijving); 

                return formule;
            }
            else
            {
                BenorCategorie benorCategorie = new BenorCategorie(1, " ");
                return new Formule(0, "", "", "", "", "", "", "", false,benorCategorie,"","");
            }
          
        }

        public FormuleDO ConvertToDO(Formule formule)
        {
                FormuleDO formuleDO = new FormuleDO(ID, Naam, SterkteKlasse, CemmentType, OmgevingsKlasse, Vloeibaarheid, Samenstelling, GranuleDiameter, isBenor, BenorCategorie.ConvertToDO(BenorCategorie), MaatEenheid, Omschrijving);

                return formuleDO;
        }

        public override string ToString()
        {
            return Naam;
        }

        public static List<Formule> KrijgAlleFormules()
        {
            List<FormuleDO> formuleDOs = DataAccess.KrijgAlleFormules();
            List<Formule> formules = new List<Formule>();
            foreach (FormuleDO formuleDO in formuleDOs)
            {
                formules.Add(ConvertFromDO(formuleDO));
            }
            return formules;
        }



        public void maakNieuweFormule()
        {
            FormuleDO formuleDO = DataAccess.MaakNieuweFormule(ConvertToDO(this));
        }

        public void updateFormule()
        {
            FormuleDO formuleDO = DataAccess.UpdateFormule(ConvertToDO(this));
        }
        public void updateFormuleAA()
        {
            FormuleDO formuleDO = DataAccess.UpdateFormuleAA(ConvertToDO(this));
        }

        public static int KrijgAantalFormules()
        {
            int AantalWerven = DataAccess.TelFormules();
            return AantalWerven;
        }

        public void maakNieuweAAFormule()
        {
            FormuleDO formuleDO = DataAccess.MaakNieuweAAFormule(ConvertToDO(this));
        }

        public static List<Formule> KrijgAlleFormulesBA()
        {
            List<FormuleDO> formuleDOs = DataAccess.KrijgAlleFormulesBA();
            List<Formule> formules = new List<Formule>();
            foreach (FormuleDO formuleDO in formuleDOs)
            {
                formules.Add(ConvertFromDO(formuleDO));
            }
            return formules;
        }

        public static Formule KrijgFormuleDoorID(int ID)
        {
            FormuleDO formuleDO = DataAccess.GetFormuleByID(ID);
            return ConvertFromDO(formuleDO);
        }

        public static Formule KrijgFormuleAADoorID(int ID)
        {
            FormuleDO formuleDO = DataAccess.GetFormuleAAByID(ID);
            return ConvertFromDO(formuleDO);
        }
        #endregion
    }
}