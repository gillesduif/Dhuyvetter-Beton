using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BugReport
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
            get { return prioriteit;  }
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
        public BugReport()
        {

        }
        public BugReport(string type, string prioriteit, string sectie,string omschrijving,byte[] afbeelding, string gebruiker)
        {
            Type = type;
            Prioriteit = prioriteit;
            Sectie = sectie;
            Omschrijving = omschrijving;
            Afbeelding = afbeelding;
            Gebruiker = gebruiker;
        }
        public BugReport(int id,string type, string prioriteit, string sectie, string omschrijving, byte[] afbeelding, string gebruiker)
            :this(type,prioriteit,sectie,omschrijving,afbeelding,gebruiker)
        {
            ID = id;
        }


        #endregion

        #region methods 
        public static BugReport ConvertFromDO(BugReportDO bugReportDO)
        {
            BugReport bugReport= new BugReport(bugReportDO.ID, bugReportDO.Type, bugReportDO.Prioriteit, bugReportDO.Sectie, bugReportDO.Omschrijving, bugReportDO.Afbeelding, bugReportDO.Gebruiker);
            return bugReport;
        }

        public BugReportDO ConvertToDO(BugReport bugReport)
        {
            BugReportDO bugReportDO = new BugReportDO(ID,Type,Prioriteit,Sectie,Omschrijving,Afbeelding,Gebruiker);
            return bugReportDO;
        }

        public BugReport MaakNieuwRapport()
        {
            BugReportDO bugReportDO = DataAccess.MaakNieuwRapport(ConvertToDO(this));
            return ConvertFromDO(bugReportDO);
        }

        public static List<BugReport> KrijgAlleBugReports()
        {
            List<BugReportDO> bugReportDOs = DataAccess.KrijgAlleBugReports();
            List<BugReport> bugReports = new List<BugReport>();
            foreach (BugReportDO bugReportDO in bugReportDOs)
            {
                bugReports.Add(ConvertFromDO(bugReportDO));
            }
            return bugReports;
        }
        #endregion
    }
}
