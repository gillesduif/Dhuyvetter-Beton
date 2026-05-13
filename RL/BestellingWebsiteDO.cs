using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class BestellingWebsiteDO
    {
        #region variables
        private int id;
        private KlantDO klantDO;
        private WerfDO werfDO;
        private FormuleDO formuleDO;
        private PompDO pompDO;
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

        public BestellingWebsiteDO()
        {

        }

        public BestellingWebsiteDO(KlantDO klantDO, WerfDO werfDO, FormuleDO formuleDO, PompDO pompDO, string giek, double m3, DateTime datum, string leveringWijze, string loswijze, string comment)
        {
            KlantDO = klantDO;
            WerfDO = werfDO;
            FormuleDO = formuleDO;
            PompDO = pompDO;
            Giek = giek;
            M3 = m3;
            Datum = datum;
            LeveringWijze = leveringWijze;
            Loswijze = loswijze;
            Comment = comment;
        }

        public BestellingWebsiteDO(int id, KlantDO klantDO, WerfDO werfDO, FormuleDO formuleDO, PompDO pompDO, string giek, double m3, DateTime datum, string LeveringWijze, string Loswijze, string Comment)
            : this(klantDO, werfDO, formuleDO, pompDO, giek, m3, datum, LeveringWijze, Loswijze, Comment)
        {
            ID = id;
        }
        #endregion

    }
}
