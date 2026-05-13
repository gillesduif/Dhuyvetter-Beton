using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Werf
    {
        #region Variables
        private int id;
        private Klant klant;
        private string adres;
        private string gemeente;
        private string postcode;
        private string telefoon;

        #endregion

        #region Properties
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

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

 

        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Telefoon
        {
            get { return telefoon; }
            set { telefoon = value; }
        }


        #endregion

        #region Contructors
        public Werf()
        {
 
        }
        public Werf(Klant klant, string adres, string gemeente, string postcode, string telefoon)
        {
            Klant = klant;
            Adres = adres;
            Gemeente = gemeente;
            Postcode = postcode;
            Telefoon = telefoon;
        }

        public Werf(int id, Klant klant, string adres, string gemeente, string postcode, string telefoon)
            : this(klant, adres, gemeente, postcode, telefoon)
        {
            ID = id;
        }
        #endregion

        #region Methods

        public static Werf ConvertFromDO(WerfDO werfDO)
        {
            if (werfDO != null)
            {
                return new Werf(werfDO.ID, Klant.ConvertFromDO(werfDO.KlantDO), werfDO.Adres, werfDO.Gemeente, werfDO.Postcode, werfDO.Telefoon);
            }
            else
            {
                return new Werf(0, null, "", "", "", "");
            }
            
        }

        public WerfDO ConvertToDO(Werf werf)
        {
            return new WerfDO(werf.ID, Klant.ConvertToDO(werf.klant), werf.Adres, werf.Gemeente, werf.Postcode, werf.Telefoon);
        }

        public override string ToString()
        {
            return  adres + " " + gemeente;
        }


        public void maakNieuweWerf()
        {
            WerfDO werfDO = DataAccess.MaakNieuweWerf(ConvertToDO(this));
        }

        public static List<Werf> KrijgAlleWerven()
        {
            List<WerfDO> werfDOs = DataAccess.KrijgAlleWerven();
            List<Werf> werfs = new List<Werf>();
            foreach (WerfDO werfDO in werfDOs)
            {
                werfs.Add(ConvertFromDO(werfDO));
            }
            return werfs;
        }
        public static List<Werf> KrijgAlleWervenVanKlantDoorKlantID(int klantID)
        {
            List<WerfDO> werfDOs = DataAccess.KrijgAlleWervenDoorKlantID(klantID);
            List<Werf> werfs = new List<Werf>();
            foreach (WerfDO werfDO in werfDOs)
            {
                werfs.Add(ConvertFromDO(werfDO));
            }
            return werfs;
        }
        public static List<Werf> KrijgAlleWervenVanKlantDoorKlantIDWebsite(int klantID)
        {
            List<WerfDO> werfDOs = DataAccess.KrijgAlleWervenDoorKlantIDWebsite(klantID);
            List<Werf> werfs = new List<Werf>();
            foreach (WerfDO werfDO in werfDOs)
            {
                werfs.Add(ConvertFromDO(werfDO));
            }
            return werfs;
        }
        public void UpdateWerftGegevens()
        {
            WerfDO werfDO = DataAccess.UpdateWerf(ConvertToDO(this));
        }



        public void VerwijderWerf()
        {
            WerfDO werfDO = DataAccess.VerwijderWerf(ConvertToDO(this));
        }
        public static int KrijgAantalWerven()
        {
            int AantalWerven = DataAccess.TelWerven();
            return AantalWerven;
        }

        #endregion
    }

}