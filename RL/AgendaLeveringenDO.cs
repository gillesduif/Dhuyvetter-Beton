using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class AgendaLeveringenDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
        private WerfDO werfDO;
        private VoertuigDO voertuigDO;
        private ChauffeurDO chauffeurDO;
        private FormuleDO formuleDO;
        private PompDO pompDO;
        private string giek;
        private double m3;
        private DateTime datum;
        private int levering;
        private string leveringWijze;
        private string loswijze;
        private string comment;
        private BestellingDO bestellingDO;
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
        public VoertuigDO VoertuigDO
        {
            get { return voertuigDO; }
            set { voertuigDO = value; }
        }
        public ChauffeurDO ChauffeurDO
        {
            get { return chauffeurDO; }
            set { chauffeurDO = value; }
        }
        public FormuleDO FormuleDO
        {
            get { return formuleDO; }
            set { formuleDO = value; }
        }
        public PompDO PompDO
        {
            get { return pompDO; }
            set { pompDO = value; }
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
        public BestellingDO BestellingDO
        {
            get { return bestellingDO; }
            set { bestellingDO = value; }
        }
        #endregion

        #region constructors

        public AgendaLeveringenDO()
        {

        }
        public AgendaLeveringenDO(KlantDO klantDO, WerfDO werfDO, VoertuigDO voertuigDO, ChauffeurDO chauffeurDO, FormuleDO formuleDO, double m3, DateTime datum)
        {
            KlantDO = klantDO;
            WerfDO = werfDO;
            VoertuigDO = voertuigDO;
            ChauffeurDO = chauffeurDO;
            FormuleDO = formuleDO;
            M3 = m3;
            Datum = datum;
        }

        public AgendaLeveringenDO(KlantDO klantDO, WerfDO werfDO, VoertuigDO voertuigDO, ChauffeurDO chauffeurDO, FormuleDO formuleDO, double m3, DateTime datum, PompDO pompDO, string giek, int levering, string leveringWijze, string loswijze, string comment,BestellingDO bestellingDO)
            : this(klantDO, werfDO, voertuigDO, chauffeurDO, formuleDO, m3, datum)
        {
            PompDO = pompDO;
            Giek = giek;
            Levering = levering;
            LeveringWijze = leveringWijze;
            Loswijze = loswijze;
            Comment = comment;
            BestellingDO = bestellingDO;
        }

        public AgendaLeveringenDO(int id, KlantDO klantDO, WerfDO werfDO, VoertuigDO voertuigDO, ChauffeurDO chauffeurDO, FormuleDO formuleDO, double m3, DateTime datum, PompDO pompDO, string giek, int levering, string leveringWijze, string loswijze, string comment, BestellingDO bestellingDO)
            : this(klantDO, werfDO, voertuigDO, chauffeurDO, formuleDO, m3, datum, pompDO, giek, levering, leveringWijze, loswijze, comment,bestellingDO)
        {
            ID = id;
        }
        #endregion
    }
}
