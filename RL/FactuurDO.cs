using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
   public class FactuurDO
    {
        #region Variables

        private int id;
        private KlantDO klantDO;
        private string factuurNummer;
        private DateTime datum;
        private double totaalExclBtw;
        private double totaalVerlegd;
        private double totaalIncl6Btw;
        private double totaalIncl21Btw;
        private double totaal;
        private byte controle;
        #endregion

        #region Properties
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
        public string FactuurNummer
        {
            get { return factuurNummer; }
            set { factuurNummer = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public double TotaalExclBtw
        {
            get { return totaalExclBtw; }
            set { totaalExclBtw = value; }
        }
        public double TotaalVerlegd
        {
            get { return totaalVerlegd; }
            set { totaalVerlegd = value; }
        }
        public double TotaalIncl6Btw
        {
            get { return totaalIncl6Btw; }
            set { totaalIncl6Btw = value; }
        }
        public double TotaalIncl21Btw
        {
            get { return totaalIncl21Btw; }
            set { totaalIncl21Btw = value; }
        }
        public double Totaal
        {
            get { return totaal; }
            set { totaal = value; }
        }
        public byte Controle
        {
            get { return controle; }
            set { controle = value; }
        }
        #endregion

        #region Contructors
        public FactuurDO()
        {

        }
        public FactuurDO(KlantDO klantDO, string factuurNummer, DateTime datum, double totaalExclBtw,double totaalVerlegd, double totaalIncl6Btw, double totaalIncl21Btw,double totaal,byte controle)
        {
            KlantDO = klantDO;
            FactuurNummer = factuurNummer;
            Datum = datum;
            TotaalExclBtw = totaalExclBtw;
            TotaalVerlegd = totaalVerlegd;
            TotaalIncl6Btw = totaalIncl6Btw;
            TotaalIncl21Btw = totaalIncl21Btw;
            Totaal = totaal;
            Controle = controle;
        }
        public FactuurDO(int id, KlantDO klantDO, string factuurNummer, DateTime datum, double totaalExclBtw,double totaalVerlegd, double totaalIncl6Btw, double totaalIncl21Btw, double totaal, byte controle)
            : this(klantDO, factuurNummer, datum, totaalExclBtw, totaalVerlegd, totaalIncl6Btw, totaalIncl21Btw, totaal,controle)
        {
            ID = id;
        }
        #endregion
    }
}
