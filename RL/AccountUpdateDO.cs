using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class AccountUpdateDO
    {
        #region variables
        int id;
        KlantDO klantDO;
        string naam;
        string adres;
        string gemeente;
        string postcode;
        string email;
        string gsm;
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
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
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
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Gsm
        {
            get { return gsm; }
            set { gsm = value; }
        }
        #endregion

        #region constructors
        public AccountUpdateDO()
        {

        }

        public AccountUpdateDO(KlantDO klantDO, string naam, string adres, string gemeente, string postcode, string email, string gsm)
        {
            KlantDO = klantDO;
            Naam = naam;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Email = email;
            Gsm = gsm;
        }
        public AccountUpdateDO(int id, KlantDO klantDO, string naam, string adres, string gemeente, string postcode, string email, string gsm)
            : this(klantDO, naam, adres, gemeente, postcode, email, gsm)
        {
            ID = id;
        }
        #endregion
    }
}
