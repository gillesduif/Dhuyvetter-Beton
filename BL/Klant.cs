using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class Klant
    {
        #region variables
        private int id;
        private int nummer;
        private string naam;
        private string adres;
        private string gemeente;
        private string postcode;
        private string gsm;
        private string telefoon;
        private string email;
        private string fax;
        private string btw;
        private string buitenlandseBtw;
        private string betaalCode;
       
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int Nummer
        {
            get{  return nummer; }
            set{  nummer = value;}
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        public string Adres
        {
            get { return adres;            }           
            set { adres = value;            }
        }
        public string Gemeente
        {
            get { return gemeente;            }
            set { gemeente = value;            }
        }
        public string Postcode
        {
            get { return postcode;            }
            set { postcode = value;            }
        }
        public string Gsm
        {
            get { return gsm;            }
            set { gsm = value;            }
        }
        public string Telefoon
        {
            get { return telefoon;            }
            set { telefoon = value;            }
        }
        public string Email
        {
            get { return email;            }
            set { email = value;            }
        }
        public string Fax
        {
            get { return fax;            }
            set { fax = value;            }
        }
        public string BuitenlandseBtw
        {
            get { return buitenlandseBtw;            }      
            set { buitenlandseBtw = value;            }
        }
        public string Btw
        {
            get { return btw;            }
            set { btw = value;            }
        }

        public string BetaalCode
        {
            get { return betaalCode; }
            set { betaalCode = value; }
        }
        #endregion

        #region constructors
        public Klant()
        {
           
        }

        public Klant(string naam, int nummer, string adres, string postcode, string gemeente, string telefoon, string fax, string gsm, string email, string btw, string buitenlandseBtw, string betaalCode)
        {
            Naam = naam;
            Nummer = nummer;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Telefoon = telefoon;
            Fax = fax;
            Gsm = gsm;
            Email = email;
            Btw = btw;
            BuitenlandseBtw = buitenlandseBtw;
            BetaalCode = betaalCode;
        }

     

        public Klant(int id, string naam, int nummer, string adres, string postcode, string gemeente, string telefoon, string fax, string gsm, string email, string btw, string buitenlandseBtw, string betaalCode)
            : this(naam, nummer, adres, postcode, gemeente, telefoon, fax, gsm, email, btw, buitenlandseBtw, betaalCode)
        {
            ID = id;
        }
        #endregion

        #region Methods
        public static Klant krijgLaatsteKlant()
        {
            KlantDO klantDO = DataAccess.krijglaatsteKlant();
            return ConvertFromDO(klantDO);
        }
        public static Klant ConvertFromDO(KlantDO klantDO)
        {
            try
            {
                if (klantDO != null)
                {
                    return new Klant(klantDO.ID, klantDO.Naam, klantDO.Nummer, klantDO.Adres, klantDO.Postcode, klantDO.Gemeente, klantDO.Telefoon, klantDO.Fax, klantDO.Gsm, klantDO.Email, klantDO.Btw, klantDO.BuitenlandseBtw, klantDO.BetaalCode);
                }
                else
                {
                    return new Klant(0, "", 0, "", "", "", "", "", "", "", "", "","");
                }
                
            }
            catch
            {
                return new Klant(0, "", 0, "", "", "", "", "", "", "", "", "","");
            }
           
        }

        public KlantDO ConvertToDO(Klant klant)
        {
            return new KlantDO(klant.ID, klant.naam, klant.nummer, klant.adres, klant.postcode, klant.gemeente, klant.telefoon, klant.fax, klant.gsm, klant.email, klant.btw, klant.buitenlandseBtw, klant.betaalCode);
        }

        public override string ToString()
        {
            return naam + " - " + Nummer;
        }

        public static List<Klant> KrijgAlleKlanten()
        {
            List<KlantDO> KlantDOs = DataAccess.KrijgAlleKlanten();
            List<Klant> klants = new List<Klant>();
            foreach (KlantDO klantDO in KlantDOs)
            {
                klants.Add(ConvertFromDO(klantDO));
            }
            klants.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            return klants;
        }

        public static List<Klant> KrijgAlleKlantenWebsite()
        {
            List<KlantDO> KlantDOs = DataAccess.KrijgAlleKlantenWebsite();
            List<Klant> klants = new List<Klant>();
            foreach (KlantDO klantDO in KlantDOs)
            {
                klants.Add(ConvertFromDO(klantDO));
            }
            return klants;
        }

        public void maakNieuweKlant()
        {
            KlantDO klantDO = DataAccess.MaakNieuweKlant(ConvertToDO(this));
        }

        public void UpdateKlantGegevens()
        {
            KlantDO klantDO = DataAccess.UpdateKlant(ConvertToDO(this));
        }

        public void VerwijderenKlant()
        {
            KlantDO klantDO = DataAccess.VerwijderKlant(ConvertToDO(this));
        }

        public static Klant KrijgKlantViaKlantenNummer(int klantNummer)
        {
            KlantDO klantDO = DataAccess.krijgKlantDoorKlantNummer(klantNummer);
            return ConvertFromDO(klantDO);
        }

        public static Klant KrijgKlantViaKlantenNummerWebsite(int klantNummer)
        {
            KlantDO klantDO = DataAccess.krijgKlantDoorKlantNummerWebsite(klantNummer);
            return ConvertFromDO(klantDO);
        }

        public void BlokeerMail()
        {
            KlantDO klantDO = DataAccess.BlokeerMailKlant(ConvertToDO(this));
        }

        public static int KrijgBlokeerMailFunctie(int KlantID)
        {
            int ID = DataAccess.ControleerBlokeerMailKlant(KlantID);
            return ID;
        }
        public static int KrijgAantalKlanten()
        {
            int AantalKlanten = DataAccess.TelKlanten();
            return AantalKlanten;
        }

        public static int krijgLaatsteKlantID()
        {
            int LaatsteKlantID = DataAccess.KrijgLaatsteKlantID();
            return LaatsteKlantID;
        }

        public static List<Klant> krijgKlantenViaKleurCode(string kleurcode)
        {
            List<KlantDO> KlantDOs = DataAccess.KrijgAlleKlantenViaKleurCode(kleurcode);
            List<Klant> klants = new List<Klant>();
            foreach (KlantDO klantDO in KlantDOs)
            {
                klants.Add(ConvertFromDO(klantDO));
            }
            klants.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            return klants;
        }
        #endregion
    }
}
