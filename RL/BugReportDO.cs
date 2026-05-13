using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class BugReportDO
    {
        #region variables
        private int id;
        private string type;
        private string prioriteit;
        private string sectie;
        private string omschrijving;
        private byte[] afbeelding;
        private string gebruiker;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Prioriteit
        {
            get { return prioriteit; }
            set { prioriteit = value; }
        }
        public string Sectie
        {
            get { return sectie; }
            set { sectie = value; }
        }
        public string Omschrijving
        {
            get { return omschrijving; }
            set { omschrijving = value; }
        }
        public byte[] Afbeelding
        {
            get { return afbeelding; }
            set { afbeelding = value; }
        }
        public string Gebruiker
        {
            get { return gebruiker; }
            set { gebruiker = value; }
        }
        #endregion

        #region constructors
        public BugReportDO()
        {

        }
        public BugReportDO(string type, string prioriteit, string sectie, string omschrijving, byte[] afbeelding, string gebruiker)
        {
            Type = type;
            Prioriteit = prioriteit;
            Sectie = sectie;
            Omschrijving = omschrijving;
            Afbeelding = afbeelding;
            Gebruiker = gebruiker;
        }
        public BugReportDO(int id, string type, string prioriteit, string sectie, string omschrijving, byte[] afbeelding, string gebruiker)
            : this(type, prioriteit, sectie, omschrijving, afbeelding, gebruiker)
        {
            ID = id;
        }
        #endregion
    }
}
