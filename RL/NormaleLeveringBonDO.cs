using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class NormaleLeveringBonDO
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
        #endregion

        #region constructors
        public NormaleLeveringBonDO()
        {
        }
        public NormaleLeveringBonDO(KlantDO klantDO, WerfDO werfDO, VoertuigDO voertuigDO, ChauffeurDO chauffeurDO, FormuleDO formuleDO, double m3, DateTime datum)
        {
            KlantDO = klantDO;
            WerfDO = werfDO;
            VoertuigDO = voertuigDO;
            ChauffeurDO = chauffeurDO;
            FormuleDO = formuleDO;
            M3 = m3;
            Datum = datum;
        }
        public NormaleLeveringBonDO(KlantDO klantDO, WerfDO werfDO, VoertuigDO voertuigDO, ChauffeurDO chauffeurDO, FormuleDO formuleDO, double m3, DateTime datum, PompDO pompDO, string giek, int levering, string leveringWijze, string loswijze, string opmerking)
            : this(klantDO, werfDO, voertuigDO, chauffeurDO, formuleDO, m3, datum)
        {
            PompDO = pompDO;
            Giek = giek;

            Levering = levering;
            Leveringwijze = leveringWijze;
            Loswijze = loswijze;
            Opmerking = opmerking;
        }
        public NormaleLeveringBonDO(int id, KlantDO klantDO, WerfDO werfDO, VoertuigDO voertuigDO, ChauffeurDO chauffeurDO, FormuleDO formuleDO, double m3, DateTime datum, PompDO pompDO, string giek, int levering, string leveringWijze, string loswijze, string opmerking)
            : this(klantDO, werfDO, voertuigDO, chauffeurDO, formuleDO, m3, datum, pompDO, giek, levering, leveringWijze, loswijze, opmerking)
        {
            ID = id;
        }
        #endregion
    }
}
