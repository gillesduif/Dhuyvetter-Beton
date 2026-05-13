using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class AfvoerInvoerDO
    {
        #region variables 
        private int id;
        private KlantDO klantDO;
        private WerfDO werfDO;
        private DateTime datumTijd;
        private string afvoer_Invoer;
        private string chauffeur;
        private string nummerplaat;
        private FormuleDO formuleDO;
        private double ton;
        private string productiebatchnr;
        private string bruto;
        private string tarra;
        private string netto;
        private string dopnummer;
        private string opmerking;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public KlantDO KlantDO
        {
            get { return klantDO; }
            set { klantDO = value; }
        }
        public WerfDO WerfDO
        {
            get { return werfDO; }
            set { werfDO = value; }
        }
        public DateTime DatumTijd
        {
            get { return datumTijd; }
            set { datumTijd = value; }
        }
        public string Afvoer_Invoer
        {
            get { return afvoer_Invoer; }
            set { afvoer_Invoer = value; }
        }
        public string Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
        }
        public string Nummerplaat
        {
            get { return nummerplaat; }
            set { nummerplaat = value; }
        }
        public FormuleDO FormuleDO
        {
            get { return formuleDO; }
            set { formuleDO = value; }
        }
        public double Ton
        {
            get { return ton; }
            set { ton = value; }
        }
        public string Productiebatchnr
        {
            get { return productiebatchnr; }
            set { productiebatchnr = value; }
        }
        public string Bruto
        {
            get { return bruto; }
            set { bruto = value; }
        }
        public string Tarra
        {
            get { return tarra; }
            set { tarra = value; }
        }
        public string Netto
        {
            get { return netto; }
            set { netto = value; }
        }
        public string Dopnummer
        {
            get { return dopnummer; }
            set { dopnummer = value; }
        }
        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }
        #endregion

        #region constructors

        public AfvoerInvoerDO()
        {

        }

        public AfvoerInvoerDO(KlantDO klantDO, WerfDO werfDO, DateTime datumTijd, string afvoer_invoer, string chauffeur, string nummerplaat, FormuleDO formuleDO, double ton, string productiebatchnr, string bruto, string tarra, string netto, string dopnummer, string opmerking)
        {
            KlantDO = klantDO;
            WerfDO = werfDO;
            DatumTijd = datumTijd;
            Afvoer_Invoer = afvoer_invoer;
            Chauffeur = chauffeur;
            Nummerplaat = nummerplaat;
            FormuleDO = formuleDO;
            Ton = ton;
            Productiebatchnr = productiebatchnr;
            Bruto = bruto;
            Tarra = tarra;
            Netto = netto;
            Dopnummer = dopnummer;
            Opmerking = opmerking;
        }
        public AfvoerInvoerDO(int id, KlantDO klantDO, WerfDO werfDO, DateTime datumTijd, string afvoer_invoer, string chauffeur, string nummerplaat, FormuleDO formuleDO, double ton, string productiebatchnr, string bruto, string tarra, string netto, string dopnummer, string opmerking)
            : this(klantDO, werfDO, datumTijd, afvoer_invoer, chauffeur, nummerplaat, formuleDO, ton, productiebatchnr, bruto, tarra, netto, dopnummer, opmerking)
        {
            ID = id;
        }
        #endregion
    }
}
