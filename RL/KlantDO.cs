namespace RL
{
    public class KlantDO
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
            get
            {
                return nummer;
            }
            set
            {
                nummer = value;
            }
        }

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
            }
        }

        public string Adres
        {
            get
            {
                return adres;
            }
            set
            {
                adres = value;
            }
        }
        public string Gemeente
        {
            get
            {
                return gemeente;
            }
            set
            {
                gemeente = value;
            }
        }
        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                postcode = value;
            }
        }
        public string Gsm
        {
            get
            {
                return gsm;
            }
            set
            {
                gsm = value;
            }
        }
        public string Telefoon
        {
            get
            {
                return telefoon;
            }
            set
            {
                telefoon = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string BuitenlandseBtw
        {
            get
            {
                return buitenlandseBtw;
            }
            set
            {
                buitenlandseBtw = value;
            }
        }
        public string Btw
        {
            get
            {
                return btw;
            }
            set
            {
                btw = value;
            }
        }
        public string BetaalCode
        {
            get
            {
                return betaalCode;
            }
            set
            {
                betaalCode = value;
            }
        }
        #endregion

        #region constructors
        public KlantDO()
        {
        }
        public KlantDO(string naam, int nummer, string adres, string postcode, string gemeente, string telefoon, string fax, string gsm, string email, string btw, string buitenlandseBtw, string betaalCode)
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

        public KlantDO(int id, string naam, int nummer, string adres, string postcode, string gemeente, string telefoon, string fax, string gsm, string email, string btw, string buitenlandseBtw, string betaalCode)
            : this(naam, nummer, adres, postcode, gemeente, telefoon, fax, gsm, email, btw, buitenlandseBtw, betaalCode)
        {
            ID = id;
        }
        #endregion
    }
}