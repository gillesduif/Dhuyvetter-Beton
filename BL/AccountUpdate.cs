using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AccountUpdate
    {
        #region variables
        int id;
        Klant klant;
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
        public Klant Klant
        {
            get { return klant; }
            set { klant = value; }
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
        public AccountUpdate()
        {

        }

        public AccountUpdate(Klant klant,string naam, string adres, string gemeente, string postcode, string email, string gsm)
        {
            Klant = klant;
            Naam = naam;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Email = email;
            Gsm = gsm;
        }
        public AccountUpdate(int id, Klant klant, string naam, string adres, string gemeente, string postcode, string email,string gsm)
            : this(klant,naam,adres,gemeente,postcode,email,gsm)
        {
            ID = id;
        }


        #endregion

        #region methods
        public static AccountUpdate ConvertFromDO(AccountUpdateDO accountUpdateDO)
        {
            AccountUpdate accountUpdate = new AccountUpdate(accountUpdateDO.ID, Klant.ConvertFromDO(accountUpdateDO.KlantDO), accountUpdateDO.Naam, accountUpdateDO.Adres, accountUpdateDO.Gemeente, accountUpdateDO.Postcode, accountUpdateDO.Email, accountUpdateDO.Gsm);
            return accountUpdate;
        }
        public AccountUpdateDO ConvertToDO(AccountUpdate accountUpdate)
        {
            AccountUpdateDO accountUpdateDO = new AccountUpdateDO(id, Klant.ConvertToDO(klant), naam,adres,gemeente,postcode,email,gsm);
            return accountUpdateDO;
        }
        public override string ToString()
        {
            return Klant.Naam;
        }
        public AccountUpdate MaakNieuweAccountWijzigen()
        {
            AccountUpdateDO accountUpdateDO  = DataAccess.MaakNieuweAccountWijzigen(ConvertToDO(this));
            return ConvertFromDO(accountUpdateDO);
        }

        public static List<AccountUpdate> krijgAlleAccounts()
        {
            List<AccountUpdateDO> accountUpdateDOs = DataAccess.selecteerAlleAccountUpdates();
            List<AccountUpdate> accountUpdates = new List<AccountUpdate>();
            foreach (AccountUpdateDO accountUpdateDO in accountUpdateDOs)
            {
                accountUpdates.Add(ConvertFromDO(accountUpdateDO));
            }
            return accountUpdates;
        }

        public void VerwijderUpdate()
        {
            AccountUpdateDO accountUpdateDO = DataAccess.VerwijderAccountUpdate(ConvertToDO(this));
        }
        #endregion
    }
}
