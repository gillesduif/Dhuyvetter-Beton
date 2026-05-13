using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class PersoneelDO
    {
        #region Variables

        private int id;
        private string naam;
        private string gsm;
        private string email;

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
        public string Gsm
        {
            get { return gsm; }
            set { gsm = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion
        #region constructors
        public PersoneelDO()
        {
        }
        public PersoneelDO(string naam, string gsm, string email)
        {
            Naam = naam;
            Gsm = gsm;
            Email = email;
        }

        public PersoneelDO(int id, string naam, string gsm, string email)
            : this(naam, gsm, email)
        {
            ID = id;
        }
        #endregion
    }
}
