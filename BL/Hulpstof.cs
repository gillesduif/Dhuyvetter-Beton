using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class Hulpstof
    {
        #region variables
        private int id;
        private string naam;
        private NormaleLeveringBon normaleLeveringBon;
        private Bestelling bestelling;
        private string hoeveelheid;
        #endregion
      
        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        public NormaleLeveringBon NormaleLeveringBon
        {
            get { return normaleLeveringBon; }
            set { normaleLeveringBon = value; }
        }
        public Bestelling Bestelling
        {
            get { return bestelling; }
            set { bestelling = value; }
        }

        public string Hoeveelheid
        {
            get { return hoeveelheid; }
            set { hoeveelheid = value; }
        }


        #endregion

        #region constructors
        public Hulpstof()
        {
        }
        public Hulpstof(string naam)
        {
            Naam = naam;
        }

        public Hulpstof(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        public Hulpstof(int id, string naam,string hoeveelheid)
: this(id, naam)
        {
   
            Hoeveelheid = hoeveelheid;
        }
        public Hulpstof(int id, string naam, string hoeveelheid, Bestelling bestelling)
    : this(id,naam,hoeveelheid)
        {
            Bestelling = bestelling;
        
        }

        public Hulpstof(int id, string naam, string hoeveelheid, NormaleLeveringBon normaleLeveringbon)
: this(id, naam, hoeveelheid)
        {
            NormaleLeveringBon = normaleLeveringbon;

        }
        #endregion

        #region methods
        public static Hulpstof ConvertFromDO(HulpstofDO hulpstofDO)
        {
              return new Hulpstof(hulpstofDO.ID, hulpstofDO.Naam,hulpstofDO.Hoeveelheid,Bestelling.ConvertFromDO(hulpstofDO.BestellingDO));
           
        }

        public HulpstofDO ConvertToDO(Hulpstof hulpstof)
        {
            return new HulpstofDO(hulpstof.ID, hulpstof.Naam,hulpstof.Hoeveelheid,Bestelling.ConvertToDO(hulpstof.bestelling));
        }



        public static Hulpstof ConvertFromDONormaleLeveringbon(HulpstofDO hulpstofDO)
        {
            Hulpstof hulpstof = new Hulpstof(hulpstofDO.ID, hulpstofDO.Naam, hulpstofDO.Hoeveelheid, NormaleLeveringBon.ConvertFromDO(hulpstofDO.NormaleLeveringBonDO));
            return hulpstof;
        }

        public HulpstofDO ConvertToDONormaleLeveringbon(Hulpstof hulpstof)
        {
            HulpstofDO hulpstofDO = new HulpstofDO(hulpstof.ID, hulpstof.Naam, hulpstof.Hoeveelheid, NormaleLeveringBon.ConvertToDO(hulpstof.normaleLeveringBon));
            return hulpstofDO;
        }

        public override string ToString()
        {
            return Naam + " " + hoeveelheid;
        }
        public void Voeghulpstoftoe()
        {
            HulpstofDO hulpstofDO = DataAccess.VoegHulpstofToeAanBestelling(ConvertToDO(this));
        }

        public static List<Hulpstof> KrijgAlleHulpstoffenDoorBestellingID(int bestellingID)
        {
            List<HulpstofDO> HulpstofDOs = DataAccess.KrijgAlleHulpstoffen(bestellingID);
            List<Hulpstof> hulpstofs = new List<Hulpstof>();
            foreach (HulpstofDO hulpstofDO in HulpstofDOs)
            {
                hulpstofs.Add(ConvertFromDO(hulpstofDO));
            }
            return hulpstofs;
        }

        public void verwijderHulpstof()
        {
            HulpstofDO hulpstofDO = DataAccess.VerwijderHulpstof(ConvertToDO(this));
        }

        public static List<Hulpstof> KrijgAlleHulpstoffenDoorLeveringID(int leveringID)
        {
            List<HulpstofDO> HulpstofDOs = DataAccess.KrijgAlleHulpstoffenVoorlevering(leveringID);
            List<Hulpstof> hulpstofs = new List<Hulpstof>();
            foreach (HulpstofDO hulpstofDO in HulpstofDOs)
            {
                hulpstofs.Add(ConvertFromDONormaleLeveringbon(hulpstofDO));
            }
            return hulpstofs;
        }
        #endregion
    }
}
