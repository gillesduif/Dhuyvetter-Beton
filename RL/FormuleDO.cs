using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class FormuleDO
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
        private BenorCategorieDO benorCategorieDO;
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
        public BenorCategorieDO BenorCategorieDO
        {
            get { return benorCategorieDO; }
            set { benorCategorieDO = value; }
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
        public FormuleDO()
        {

        }

        public FormuleDO(string naam, string sterkteKlasse, string cemmentType, string omgevingsKlasse, string vloeibaarheid, string samenstelling, string granuleDiameter, bool isBenor ,BenorCategorieDO benorCategorieDO, string maatEenheid, string omschrijving)
        {
            Naam = naam;
            SterkteKlasse = sterkteKlasse;
            CemmentType = cemmentType;
            OmgevingsKlasse = omgevingsKlasse;
            Vloeibaarheid = vloeibaarheid;
            Samenstelling = samenstelling;
            GranuleDiameter = granuleDiameter;
            IsBenor = isBenor;
            BenorCategorieDO = benorCategorieDO;
            MaatEenheid = maatEenheid;
            Omschrijving = omschrijving;
        }

        public FormuleDO(int id, string naam, string sterkteKlasse, string cemmentType, string omgevingsKlasse, string vloeibaarheid, string samenstelling, string granuleDiameter, bool isBenor, BenorCategorieDO benorCategorieDO, string maatEenheid, string omschrijving)
            : this(naam, sterkteKlasse, cemmentType, omgevingsKlasse, vloeibaarheid, samenstelling, granuleDiameter,isBenor,benorCategorieDO,maatEenheid, omschrijving)
        {
            ID = id;
        }
        #endregion
    }
}