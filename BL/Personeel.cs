using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Personeel
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
        public Personeel()
        {
        }
        public Personeel(string naam, string gsm, string email)
        {
            Naam = naam;
            Gsm = gsm;
            Email = email;
        }

        public Personeel(int id, string naam, string gsm, string email)
            : this(naam,gsm,email)
        {
            ID = id;
        }
        #endregion
        #region methods

        public static Personeel ConvertFromDO(PersoneelDO personeelDO)
        {
            Personeel personeel = new Personeel(personeelDO.ID,personeelDO.Naam,personeelDO.Gsm,personeelDO.Email);

            return personeel;
        }

        public PersoneelDO ConvertToDO(Personeel personeel)
        {
            PersoneelDO personeelDO = new PersoneelDO(ID, Naam,Gsm,Email);

            return personeelDO;
        }

        public override string ToString()
        {
            return Naam;
        }

        public static List<Personeel> KrijgAllePersoneelLeden()
        {
            List<PersoneelDO> personeelDOs = DataAccess.KrijgAllePersoneelLeden();
            List<Personeel> personeels = new List<Personeel>();
            foreach (PersoneelDO personeelDO in personeelDOs)
            {
                personeels.Add(ConvertFromDO(personeelDO));
            }
            return personeels;
        }

        public void Verwijderen()
        {
            PersoneelDO personeelDO = DataAccess.VerwijderPersoneelsLid(ConvertToDO(this));

        }

        public void MaakNieuw()
        {
            PersoneelDO personeelDO = DataAccess.NieuwPersoneelsLid(ConvertToDO(this));
        }
        #endregion
    }
}
