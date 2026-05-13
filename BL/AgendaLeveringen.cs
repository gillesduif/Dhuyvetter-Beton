using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AgendaLeveringen
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
        private string leveringWijze;
        private string loswijze;
        private string comment;
        private Bestelling bestelling;
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
        public Bestelling Bestelling
        {
            get { return bestelling; }
            set { bestelling = value; }
        }
        #endregion

        #region constructors
        public AgendaLeveringen(Klant klant, Werf werf, Voertuig voertuig, Chauffeur chauffeur, Formule formule, double m3, DateTime datum)
        {
            Klant = klant;
            Werf = werf;
            Voertuig = voertuig;
            Chauffeur = chauffeur;
            Formule = formule;
            M3 = m3;
            Datum = datum;
        }

        public AgendaLeveringen(Klant klant, Werf werf, Voertuig voertuig, Chauffeur chauffeur, Formule formule, double m3, DateTime datum, Pomp pomp, string giek, int levering, string leveringWijze, string loswijze, string comment, Bestelling bestelling)
            : this(klant, werf, voertuig, chauffeur, formule, m3, datum)
        {
            Pomp = pomp;
            Giek = giek;
            Levering = levering;
            LeveringWijze = leveringWijze;
            Loswijze = loswijze;
            Comment = comment;
            Bestelling = bestelling;
        }

        public AgendaLeveringen(int id, Klant klant, Werf werf, Voertuig voertuig, Chauffeur chauffeur, Formule formule, double m3, DateTime datum, Pomp pomp, string giek, int levering, string leveringWijze, string loswijze, string comment, Bestelling bestelling)
            : this(klant, werf, voertuig, chauffeur, formule, m3, datum, pomp, giek, levering, leveringWijze,loswijze,comment,bestelling)
        {
            ID = id;
        }
        #endregion

        public static AgendaLeveringen ConvertFromDO(AgendaLeveringenDO agendaLeveringenDO)
        {
            AgendaLeveringen agendaLeveringen = new AgendaLeveringen(agendaLeveringenDO.ID, Klant.ConvertFromDO(agendaLeveringenDO.KlantDO), Werf.ConvertFromDO(agendaLeveringenDO.WerfDO), Voertuig.ConvertFromDO(agendaLeveringenDO.VoertuigDO), Chauffeur.ConvertFromDO(agendaLeveringenDO.ChauffeurDO), Formule.ConvertFromDO(agendaLeveringenDO.FormuleDO), agendaLeveringenDO.M3, agendaLeveringenDO.Datum, Pomp.ConvertFromDO(agendaLeveringenDO.PompDO), agendaLeveringenDO.Giek, agendaLeveringenDO.Levering, agendaLeveringenDO.LeveringWijze, agendaLeveringenDO.Loswijze,agendaLeveringenDO.Comment,Bestelling.ConvertFromDO(agendaLeveringenDO.BestellingDO));
            return agendaLeveringen;
        }

        public AgendaLeveringenDO ConvertToDO(AgendaLeveringen agendaLeveringen)
        {
            AgendaLeveringenDO agendaLeveringenDO = new AgendaLeveringenDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf), Voertuig.ConvertToDO(voertuig), Chauffeur.ConvertToDO(chauffeur), Formule.ConvertToDO(formule), M3, Datum, Pomp.ConvertToDO(pomp), giek, levering, leveringWijze, loswijze,comment,bestelling.ConvertToDO(bestelling));
            return agendaLeveringenDO;
        }

        public static AgendaLeveringen KrijgAgendapuntDoorBestellingID(int ID)
        {
            AgendaLeveringenDO agendaLeveringenDO = DataAccess.krijgAgendaPuntDoorBestellingID(ID);
            return ConvertFromDO(agendaLeveringenDO);
        }

        public void MaakNieuwAgendaPunt()
        {
            AgendaLeveringenDO agendaLeveringenDO = DataAccess.MaakNieuwAgendaPunt(ConvertToDO(this));
        }
        public void Verwijder(int bestelID)
        {
            AgendaLeveringenDO agendaLeveringenDO = DataAccess.VerwijderAgendapuntDoorBestellingID(bestelID);
        }
        public static List<AgendaLeveringen> KrijgBestellingenDoorDatum(DateTime datum1, DateTime datum2)
        {
            List<AgendaLeveringenDO> AgendaLeveringensDOs = DataAccess.SelecteerAgendaPuntenTussenTweeDatums(datum1, datum2);
            List<AgendaLeveringen> AgendaLeveringens = new List<AgendaLeveringen>();
            foreach (AgendaLeveringenDO agendaLeveringenDO in AgendaLeveringensDOs)
            {
                AgendaLeveringens.Add(ConvertFromDO(agendaLeveringenDO));
            }
            return AgendaLeveringens;
        }

        public static bool BestaatAgendaPunt(int ID)
        {
            bool value = DataAccess.ControleBestaanAgendaPunt(ID);
            return value;
        }
    }
}
