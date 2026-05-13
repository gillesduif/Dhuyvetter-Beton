using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AfvoerInvoer
    {
        #region variables 
        private int id;
        private Klant klant;
        private Werf werf;
        private DateTime datumTijd;
        private string afvoer_Invoer;
        private string chauffeur;
        private string nummerplaat;
        private Formule formule;
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
        public DateTime DatumTijd
        {
            get { return datumTijd; }
            set { datumTijd = value; }
        }
        public Klant Klant
        {
            get { return klant; }
            set { klant = value; }
        }
        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
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
        public Formule Formule
        {
            get { return formule; }
            set { formule = value; }
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
        public AfvoerInvoer()
        {

        }


        public AfvoerInvoer(Klant klant, Werf werf, DateTime datumTijd, string afvoer_invoer, string chauffeur, string nummerplaat, Formule formule, double ton, string productiebatchnr, string bruto, string tarra, string netto, string dopnummer, string opmerking)
        {
            Klant = klant;
            Werf = werf;
            DatumTijd = datumTijd;
            Afvoer_Invoer = afvoer_invoer;
            Chauffeur = chauffeur;
            Nummerplaat = nummerplaat;
            Formule = formule;
            Ton = ton;
            Productiebatchnr = productiebatchnr;
            Bruto = bruto;
            Tarra = tarra;
            Netto = netto;
            Dopnummer = dopnummer;
            Opmerking = opmerking;
        }
        public AfvoerInvoer(int id, Klant klant, Werf werf, DateTime datumTijd, string afvoer_invoer, string chauffeur, string nummerplaat, Formule formule, double ton, string productiebatchnr, string bruto, string tarra, string netto, string dopnummer, string opmerking)
            : this(klant, werf, datumTijd, afvoer_invoer, chauffeur, nummerplaat, formule, ton, productiebatchnr, bruto, tarra, netto, dopnummer, opmerking)
        {
            ID = id;
        }
        #endregion

        #region methods

        public static AfvoerInvoer ConvertFromDO(AfvoerInvoerDO afvoerInvoerDO)
        {
            AfvoerInvoer afvoerInvoer = new AfvoerInvoer(afvoerInvoerDO.ID, Klant.ConvertFromDO(afvoerInvoerDO.KlantDO), Werf.ConvertFromDO(afvoerInvoerDO.WerfDO), afvoerInvoerDO.DatumTijd, afvoerInvoerDO.Afvoer_Invoer, afvoerInvoerDO.Chauffeur, afvoerInvoerDO.Nummerplaat, Formule.ConvertFromDO(afvoerInvoerDO.FormuleDO), afvoerInvoerDO.Ton, afvoerInvoerDO.Productiebatchnr, afvoerInvoerDO.Bruto, afvoerInvoerDO.Tarra, afvoerInvoerDO.Netto, afvoerInvoerDO.Dopnummer, afvoerInvoerDO.Opmerking); ;
            return afvoerInvoer;
        }
        public AfvoerInvoerDO ConvertToDO(AfvoerInvoer afvoerInvoer)
        {
            AfvoerInvoerDO afvoerInvoerDO = new AfvoerInvoerDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf), DatumTijd, Afvoer_Invoer, Chauffeur, Nummerplaat, Formule.ConvertToDO(formule), Ton, Productiebatchnr, Bruto, Tarra, Netto, Dopnummer, Opmerking);
            return afvoerInvoerDO;
        }



        public static List<AfvoerInvoer> KrijgAlleAfVoerInvoerItemsVoorDatums(DateTime datum1, DateTime datum2)
        {
            List<AfvoerInvoerDO> AfvoerInvoerDOs = DataAccess.SelecteerAfVoerInvoerItemsVoorDatums(datum1, datum2);
            List<AfvoerInvoer> AfvoerInvoers = new List<AfvoerInvoer>();
            foreach (AfvoerInvoerDO afvoerInvoerDO in AfvoerInvoerDOs)
            {
                AfvoerInvoers.Add(ConvertFromDO(afvoerInvoerDO));
            }
            return AfvoerInvoers;
        }

        public void Nieuw()
        {
            AfvoerInvoerDO afvoerInvoerDO = DataAccess.MaakNieuwAfvoerInvoer(ConvertToDO(this));
        }


        
        #endregion
    }
}
