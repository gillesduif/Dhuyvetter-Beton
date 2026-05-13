using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class VerlofDO
    {
        #region Variables
        private int id;
        private PersoneelDO personeelsLid;
        private DateTime startdatum;
        private DateTime einddatum;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public PersoneelDO PersoneelsLid
        {
            get { return personeelsLid; }
            set { personeelsLid = value; }
        }
        public DateTime Startdatum
        {
            get { return startdatum; }
            set { startdatum = value; }
        }
        public DateTime Einddatum
        {
            get { return einddatum; }
            set { einddatum = value; }
        }
        #endregion
        #region constructors
        public VerlofDO()
        {
        }
        public VerlofDO(PersoneelDO personeelsLid, DateTime startdatum, DateTime einddatum)
        {
            PersoneelsLid = personeelsLid;
            Startdatum = startdatum;
            Einddatum = einddatum;
        }

        public VerlofDO(int id, PersoneelDO personeelsLid, DateTime startdatum, DateTime einddatum)
            : this(personeelsLid, startdatum, einddatum)
        {
            ID = id;
        }
        #endregion
    }
}
