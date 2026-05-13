using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class Account
    {
        #region variables
        private int id;
        private int klantNummer;
        private string wachtwoord;
        private string email;
        private byte userlevel;


        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int KlantNummer
        {
            get { return klantNummer; }
            set { klantNummer = value; }
        }

        public static List<Account> KrijgAlleAccounts()
        {
            List<AccountDO> AccountDOs = DataAccess.KrijgAlleAccounts();
            List<Account> Accounts = new List<Account>();
            foreach (AccountDO accountDO in AccountDOs)
            {
                Accounts.Add(convertFromDo(accountDO));
            }
            return Accounts;
        }

        public string Wachtwoord
        {
            get { return wachtwoord; }
            set { wachtwoord = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }



        public byte Userlevel
        {
            get { return userlevel; }
            set { userlevel = value; }
        }

        public void UpdateWachtwoord()
        {
            AccountDO accountDO = DataAccess.UpdateWachtwoord(ConvertToDO(this));
        }

        #endregion

        #region Constructors
        public Account()
        {
           
        }
        public Account(int klantnummer, string wachtwoord, string email,byte userlevel)
        {
            KlantNummer = klantnummer;
            Wachtwoord = wachtwoord;
            Email = email;
            Userlevel = userlevel;
        }
        public Account(int id,int klantnummer, string wachtwoord, string email, byte userlevel)
            :this(klantnummer,wachtwoord,email,userlevel)
        {
            ID = id;
        }
        #endregion
        #region methods
        public static Account convertFromDo(AccountDO accountDO)
        {
            Account account = new Account(accountDO.ID, accountDO.KlantNummer, accountDO.Wachtwoord,accountDO.Email, accountDO.Userlevel);
            return account;
        }
        public AccountDO ConvertToDO(Account account)
        {
            AccountDO accountDO = new AccountDO(id, klantNummer, wachtwoord, email, userlevel);
            return accountDO;
        }
        public void Aanmaken()
        {
            AccountDO accountDO = DataAccess.MaakNieuweAccount(ConvertToDO(this));
        }
        public void AanmakenWebsite()
        {
            AccountDO accountDO = DataAccess.MaakNieuweAccountWebsite(ConvertToDO(this));
        }

        public static Account KrijgAccountDoorKlantNummerEnWachtwoord(int klantnummer, string wachtwoord)
        {
            AccountDO accountDO = DataAccess.KrijgAccountDoorKlantNummerEnWachtwoord(klantnummer, wachtwoord);
            return convertFromDo(accountDO);
        }
        public static Account KrijgAccountDoorKlantNummerEnWachtwoordWebsite(int klantnummer, string wachtwoord)
        {
            AccountDO accountDO = DataAccess.KrijgAccountDoorKlantNummerEnWachtwoordWebsite(klantnummer, wachtwoord);
            return convertFromDo(accountDO);
        }
        public override string ToString()
        {
            return klantNummer.ToString();
        }
        #endregion
    }
}
