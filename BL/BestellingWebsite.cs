using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BestellingWebsite
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
        private Formule formule;
        private Pomp pomp;
        private string giek;
        private double m3;
 
        private DateTime datum;
   
        private string leveringWijze;
        private string loswijze;
        private string comment;
  
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
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

        public Formule Formule
        {
            get { return formule; }
            set { formule = value; }
        }

  

        public Pomp Pomp
        {
            get { return pomp; }
            set { pomp = value; }
        }

        public string Giek
        {
            get { return giek; }
            set { giek = value; }
        }

        public double M3
        {
            get { return m3; }
            set { m3 = value; }
        }


        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }


        public string LeveringWijze
        {
            get { return leveringWijze; }
            set { leveringWijze = value; }
        }
        public string Loswijze
        {
            get { return loswijze; }
            set { loswijze = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        #endregion

        #region constructors

        public BestellingWebsite()
        {

        }

        public BestellingWebsite(Klant klant, Werf werf, Formule formule, Pomp pomp, string giek, double m3, DateTime datum,string leveringWijze, string loswijze, string comment)
        {
            Klant = klant;
            Werf = werf;
            Formule = formule;
            Pomp = pomp;
            Giek = giek;
            M3 = m3;
            Datum = datum;
            LeveringWijze = leveringWijze;
            Loswijze = loswijze;
            Comment = comment;
        }

        public BestellingWebsite(int id, Klant klant, Werf werf, Formule formule, Pomp pomp, string giek, double m3, DateTime datum, string LeveringWijze, string Loswijze, string Comment)
            : this(klant, werf, formule, pomp, giek, m3, datum, LeveringWijze, Loswijze, Comment)
        {
            ID = id;
        }

        public void VerwwijderWebsiteBestelling()
        {
            BestellingWebsiteDO bestellingWebsiteDO = DataAccess.VerwijderBestellingWebsite(ConvertToDO(this));
        }
        #endregion

        #region methods

        public static BestellingWebsite ConvertFromDO(BestellingWebsiteDO bestellingWebsiteDO)
        {
            BestellingWebsite bestellingWebsite = new BestellingWebsite(bestellingWebsiteDO.ID, Klant.ConvertFromDO(bestellingWebsiteDO.KlantDO), Werf.ConvertFromDO(bestellingWebsiteDO.WerfDO), Formule.ConvertFromDO(bestellingWebsiteDO.FormuleDO), Pomp.ConvertFromDO(bestellingWebsiteDO.PompDO), bestellingWebsiteDO.Giek, bestellingWebsiteDO.M3, bestellingWebsiteDO.Datum, bestellingWebsiteDO.LeveringWijze, bestellingWebsiteDO.Loswijze, bestellingWebsiteDO.Comment);
            return bestellingWebsite;
        }

        public BestellingWebsiteDO ConvertToDO(BestellingWebsite bestellingWebsite)
        {
            BestellingWebsiteDO bestellingWebsiteDO = new BestellingWebsiteDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf), Formule.ConvertToDO(formule), Pomp.ConvertToDO(pomp), Giek, M3,  Datum,  LeveringWijze, Loswijze, Comment);
            return bestellingWebsiteDO;
        }

      

        public static List<BestellingWebsite> KrijgAlleWebsiteBestellingen()
        {
            List<BestellingWebsiteDO> BestellingWebsiteDOs = DataAccess.krijgAlleWebsiteBestellingen();
            List<BestellingWebsite> bestellingWebsites = new List<BestellingWebsite>();
            foreach (BestellingWebsiteDO bestellingWebsiteDO in BestellingWebsiteDOs)
            {
                bestellingWebsites.Add(ConvertFromDO(bestellingWebsiteDO));
            }
            return bestellingWebsites;
        }
        #endregion
    }
}
