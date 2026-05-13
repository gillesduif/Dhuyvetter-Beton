using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Verlof
    {
        #region Variables
        private int id;
        private Personeel personeelsLid;
        private DateTime startdatum;
        private DateTime einddatum;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Personeel PersoneelsLid
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
        public Verlof()
        {
        }
        public Verlof(Personeel personeelsLid, DateTime startdatum, DateTime einddatum)
        {
            PersoneelsLid = personeelsLid;
            Startdatum = startdatum;
            Einddatum = einddatum;
        }

        public Verlof(int id, Personeel personeelsLid, DateTime startdatum, DateTime einddatum)
            : this(personeelsLid, startdatum, einddatum)
        {
            ID = id;
        }

     
        #endregion
        #region methods
        public static Verlof ConvertFromDO(VerlofDO verlofDO)
        {
            Verlof verlof = new Verlof(verlofDO.ID, Personeel.ConvertFromDO(verlofDO.PersoneelsLid), verlofDO.Startdatum, verlofDO.Einddatum);

            return verlof;
        }

        public VerlofDO ConvertToDO(Verlof verlof)
        {
            VerlofDO verlofDO = new VerlofDO(ID, PersoneelsLid.ConvertToDO(personeelsLid), Startdatum, Einddatum);

            return verlofDO;
        }

        public override string ToString()
        {
            return PersoneelsLid.Naam + " - " + Startdatum.ToLongDateString() + " - " + Einddatum.ToLongDateString();
        }

        public static List<Verlof> KrijgAlleVerlofDagenDoorDatumMaand(DateTime month)
        {
            List<VerlofDO> VerlofDOs = DataAccess.KrijgAlleVerlofDagenvoorMaand(month);
            List<Verlof> Verlofs = new List<Verlof>();
            foreach (VerlofDO verlofDO in VerlofDOs)
            {
                Verlofs.Add(ConvertFromDO(verlofDO));
            }
            return Verlofs;
        }

        public static List<Verlof> KrijgAlleVerlofDagenDoorDatum(DateTime dateTime)
        {
            List<VerlofDO> VerlofDOs = DataAccess.KrijgAlleVerlofDagenvoordag(dateTime);
            List<Verlof> Verlofs = new List<Verlof>();
            foreach (VerlofDO verlofDO in VerlofDOs)
            {
                Verlofs.Add(ConvertFromDO(verlofDO));
            }
            return Verlofs;
        }
        public static List<Verlof> KrijgAlleVerlofDagenDoorJaar(DateTime dateTime)
        {
            List<VerlofDO> VerlofDOs = DataAccess.KrijgAlleVerlofDagenvoorJaar(dateTime);
            List<Verlof> Verlofs = new List<Verlof>();
            foreach (VerlofDO verlofDO in VerlofDOs)
            {
                Verlofs.Add(ConvertFromDO(verlofDO));
            }
            return Verlofs;
        }

        public static Verlof KrijgVerlofDoorID(int iD)
        {
            VerlofDO verlofDO = DataAccess.krijgVerlofDoorID(iD);
            return ConvertFromDO(verlofDO);
        }

        public static List<Verlof> KrijgAlleVerlofDagenDoorDatumEnPersoneelID(DateTime datum, int iD)
        {
            List<VerlofDO> VerlofDOs = DataAccess.KrijgAlleVerlofDagenDatumEnPersoneel(datum,iD);
            List<Verlof> Verlofs = new List<Verlof>();
            foreach (VerlofDO verlofDO in VerlofDOs)
            {
                Verlofs.Add(ConvertFromDO(verlofDO));
            }
            return Verlofs;
        }

        public void Wijzigen()
        {
            VerlofDO verlofDO = DataAccess.WijzigVerlofPunt(ConvertToDO(this));
        }

        public void Nieuw()
        {
            VerlofDO verlofDO = DataAccess.MaakNieuwVerlofPunt(ConvertToDO(this));
        }

        public void Verwijderen()
        {
            VerlofDO verlofDO = DataAccess.VerwijderVerlofPunt(ConvertToDO(this));
        }
        #endregion
    }
}