using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class LogboekDO
    {
        #region variables
        private int id;
        private DateTime datumEnTijd;
        private string functie;
        private string taak;
        private string gebruiker;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime DatumEnTijd
        {
            get { return datumEnTijd; }
            set { datumEnTijd = value; }
        }
        public string Functie
        {
            get { return functie; }
            set { functie = value; }
        }
        public string Taak
        {
            get { return taak; }
            set { taak = value; }
        }
        public string Gebruiker
        {
            get { return gebruiker; }
            set { gebruiker = value; }
        }
        #endregion
        #region constructors

        public LogboekDO()
        {

        }

        public LogboekDO(DateTime datumEnTijd, string functie, string taak, string gebruiker)
        {
            DatumEnTijd = datumEnTijd;
            Functie = functie;
            Taak = taak;
            Gebruiker = gebruiker;
        }
        public LogboekDO(int id, DateTime datumEnTijd, string functie, string taak, string gebruiker)
            : this(datumEnTijd, functie, taak, gebruiker)
        {
            ID = id;
        }
        #endregion
    }
}
