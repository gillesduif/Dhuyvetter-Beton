using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class NormaleLeveringBon
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
        private Voertuig voertuig;
        private Chauffeur chauffeur;
        private Formule formule;
        private Pomp pomp;
        private string giek;
        private double m3;
        private DateTime datum;
        private int levering;
        private string leveringwijze;
        private string loswijze;
        private string opmerking;
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
        public string ToStringDatum()
        {
            return Datum.ToLongDateString();
        }
        public string ToStringProduct()
        {
            return Klant.Naam;
        }
        public override string ToString()
        {
            return Klant.Naam;
        }
        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
        }
        public Voertuig Voertuig
        {
            get { return voertuig; }
            set { voertuig = value; }
        }
        public Chauffeur Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
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

        public int Levering
        {
            get { return levering; }
            set { levering = value; }
        }
        public string Leveringwijze
        {
            get { return leveringwijze; }
            set { leveringwijze = value; }
        }

        public string Loswijze
        {
            get { return loswijze; }
            set { loswijze = value; }
        }
        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }

        public static List<NormaleLeveringBon> KrijgBestellingenDoorKlantWerfDatum(int klantID, int werfID, DateTime datum1, DateTime datum2)
        {
            List<NormaleLeveringBonDO> NormaleLeveringBonDOs = DataAccess.SelecteerLeveringenKlantWervenTussenTweeDatums(klantID,werfID,datum1, datum2);
            List<NormaleLeveringBon> NormaleLeveringBonnen = new List<NormaleLeveringBon>();
            foreach (NormaleLeveringBonDO normaleLeveringBonDO in NormaleLeveringBonDOs)
            {
                NormaleLeveringBonnen.Add(ConvertFromDO(normaleLeveringBonDO));
            }
            return NormaleLeveringBonnen;
        }

        #endregion

        #region constructors
        public NormaleLeveringBon()
        {

        }
        public NormaleLeveringBon(int id,Klant klant)
        {
            ID = id;
            Klant = klant;
        }
        public NormaleLeveringBon(Klant klant, Werf werf, Voertuig voertuig, Chauffeur chauffeur, Formule formule, double m3, DateTime datum)
        {
            Klant = klant;
            Werf = werf;
            Voertuig = voertuig;
            Chauffeur = chauffeur;
            Formule = formule;
            M3 = m3;
            Datum = datum;
        }

     

        public NormaleLeveringBon(Klant klant, Werf werf, Voertuig voertuig, Chauffeur chauffeur, Formule formule, double m3, DateTime datum, Pomp pomp, string giek, int levering, string leveringWijze, string loswijze, string opmerking)
            : this(klant, werf, voertuig, chauffeur, formule, m3, datum)
        {
            Pomp = pomp;
            Giek = giek;

            Levering = levering;
            Leveringwijze = leveringWijze;
            Loswijze = loswijze;
            Opmerking = opmerking;
        }

        public NormaleLeveringBon(int id, Klant klant, Werf werf, Voertuig voertuig, Chauffeur chauffeur, Formule formule, double m3, DateTime datum, Pomp pomp, string giek, int levering, string leveringWijze, string loswijze, string opmerking)
            : this(klant, werf, voertuig, chauffeur, formule, m3, datum, pomp, giek, levering, leveringWijze, loswijze, opmerking)
        {
            ID = id;
        }

   
        #endregion

        #region methods
        public static NormaleLeveringBon ConvertFromDO(NormaleLeveringBonDO normaleLeveringBonDO)
        {
            NormaleLeveringBon normaleLeveringBon = new NormaleLeveringBon(normaleLeveringBonDO.ID, Klant.ConvertFromDO(normaleLeveringBonDO.KlantDO), Werf.ConvertFromDO(normaleLeveringBonDO.WerfDO), Voertuig.ConvertFromDO(normaleLeveringBonDO.VoertuigDO), Chauffeur.ConvertFromDO(normaleLeveringBonDO.ChauffeurDO), Formule.ConvertFromDO(normaleLeveringBonDO.FormuleDO), normaleLeveringBonDO.M3, normaleLeveringBonDO.Datum, Pomp.ConvertFromDO(normaleLeveringBonDO.PompDO), normaleLeveringBonDO.Giek, normaleLeveringBonDO.Levering, normaleLeveringBonDO.Leveringwijze, normaleLeveringBonDO.Loswijze, normaleLeveringBonDO.Opmerking);
            return normaleLeveringBon;
        }

        public NormaleLeveringBonDO ConvertToDO(NormaleLeveringBon normaleLeveringBon)
        {
            NormaleLeveringBonDO normaleLeveringBonDO = new NormaleLeveringBonDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf), Voertuig.ConvertToDO(voertuig), Chauffeur.ConvertToDO(chauffeur), Formule.ConvertToDO(formule), M3, Datum, Pomp.ConvertToDO(pomp), giek, levering, leveringwijze, loswijze, opmerking);
            return normaleLeveringBonDO;
        }

        public static NormaleLeveringBon ConvertFromDOFacturatie(NormaleLeveringBonDO normaleLeveringBonDO)
        {
            NormaleLeveringBon normaleLeveringBon = new NormaleLeveringBon(normaleLeveringBonDO.ID, Klant.ConvertFromDO(normaleLeveringBonDO.KlantDO));
            return normaleLeveringBon;
        }

        public static List<NormaleLeveringBon> KrijgBestellingenDoorDatumEnKlant(DateTime datum1, DateTime datum2, int klantID)
        {
            List<NormaleLeveringBonDO> NormaleLeveringBonDOs = DataAccess.SelecteerLeveringenTussenTweeDatumsVanKlant(datum1, datum2, klantID);
            List<NormaleLeveringBon> NormaleLeveringBonnen = new List<NormaleLeveringBon>();
            foreach (NormaleLeveringBonDO normaleLeveringBonDO in NormaleLeveringBonDOs)
            {
                NormaleLeveringBonnen.Add(ConvertFromDO(normaleLeveringBonDO));
            }
            return NormaleLeveringBonnen;
        }

        public static List<NormaleLeveringBon> KrijgBestellingenDoorDatum(DateTime datum1, DateTime datum2)
        {
            List<NormaleLeveringBonDO> NormaleLeveringBonDOs = DataAccess.SelecteerLeveringenTussenTweeDatums(datum1, datum2);
            List<NormaleLeveringBon> NormaleLeveringBonnen = new List<NormaleLeveringBon>();
            foreach (NormaleLeveringBonDO normaleLeveringBonDO in NormaleLeveringBonDOs)
            {
                NormaleLeveringBonnen.Add(ConvertFromDOFacturatie(normaleLeveringBonDO));
            }
            return NormaleLeveringBonnen;
        }

        public static List<NormaleLeveringBon> KrijgBestellingenDoorDatumEnKlantEnProduct(DateTime datum1, DateTime datum2, int klantID, int formuleID)
        {
            List<NormaleLeveringBonDO> NormaleLeveringBonDOs = DataAccess.SelecteerLeveringenTussenTweeDatumsVanKlantEnProduct(datum1, datum2, klantID, formuleID);
            List<NormaleLeveringBon> NormaleLeveringBonnen = new List<NormaleLeveringBon>();
            foreach (NormaleLeveringBonDO normaleLeveringBonDO in NormaleLeveringBonDOs)
            {
                NormaleLeveringBonnen.Add(ConvertFromDO(normaleLeveringBonDO));
            }
            return NormaleLeveringBonnen;
        }
        public static List<NormaleLeveringBon> KrijgBestellingenDoorDatumEnKlantEnProductEnWerf(DateTime datum1, DateTime datum2, int klantID, int formuleID, int werfID)
        {
            List<NormaleLeveringBonDO> NormaleLeveringBonDOs = DataAccess.SelecteerLeveringenTussenTweeDatumsVanKlantEnProductEnWerf(datum1, datum2, klantID, formuleID,werfID);
            List<NormaleLeveringBon> NormaleLeveringBonnen = new List<NormaleLeveringBon>();
            foreach (NormaleLeveringBonDO normaleLeveringBonDO in NormaleLeveringBonDOs)
            {
                NormaleLeveringBonnen.Add(ConvertFromDO(normaleLeveringBonDO));
            }
            return NormaleLeveringBonnen;
        }

        public static NormaleLeveringBon krijgleveringBonDoorID(int ID)
        {
            NormaleLeveringBonDO normaleLeveringBonDO = DataAccess.KrijgLeveringbonDoorID(ID);
            return ConvertFromDO(normaleLeveringBonDO);
        }
        public static int KrijgAantalBonnen()
        {
            int aantalBonnen = DataAccess.TelBonnen();
            return aantalBonnen;
        }
        #endregion
    }
}
