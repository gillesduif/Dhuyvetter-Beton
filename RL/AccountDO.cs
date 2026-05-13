using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class AccountDO
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
        #endregion

        #region Constructors
        public AccountDO()
        {

        }
        public AccountDO(int klantnummer, string wachtwoord, string email, byte userlevel)
        {
            KlantNummer = klantnummer;
            Wachtwoord = wachtwoord;
            Email = email;
            Userlevel = userlevel;
        }
        public AccountDO(int id, int klantnummer, string wachtwoord, string email, byte userlevel)
            : this(klantnummer, wachtwoord, email, userlevel)
        {
            ID = id;
        }
        #endregion
    }
}
