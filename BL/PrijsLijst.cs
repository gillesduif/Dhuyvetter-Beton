using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PrijsLijst
    {
        #region variables
        private int id;
        private string formule;
        private double aannemer;
        private double particulier;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Formule
        {
            get { return formule; }
            set { formule = value; }
        }

        public double Aannemer
        {
            get { return aannemer; }
            set { aannemer = value; }
        }
        public double Particulier
        {
            get { return particulier; }
            set { particulier = value; }
        }
        #endregion

        #region constructors
        public PrijsLijst()
        {

        }
        public PrijsLijst(string formule, double aannemer, double particulier)
        {
            Formule = formule;
            Aannemer = aannemer;
            Particulier = particulier;
        }

        public PrijsLijst(int id, string formule, double aannemer, double particulier)
            : this(formule, aannemer, particulier)
        {
            ID = id;
        }
        #endregion

        #region methods

        public static PrijsLijst ConvertFromDO(PrijsLijstDO prijsLijstDO)
        {
            PrijsLijst prijsLijst = new PrijsLijst(prijsLijstDO.ID, prijsLijstDO.Formule, prijsLijstDO.Aannemer, prijsLijstDO.Particulier);

            return prijsLijst;
        }

        public PrijsLijstDO ConvertToDO(PrijsLijst prijsLijst)
        {
            PrijsLijstDO prijsLijstDO = new PrijsLijstDO(ID, Formule, Aannemer,Particulier);

            return prijsLijstDO;
        }

        public override string ToString()
        {
            return Formule;
        }

        public static List<PrijsLijst> KrijgAlleOmschrijvingen()
        {
            List<PrijsLijstDO> PrijsLijstDOs = DataAccess.KrijgAllePrijzen();
            List<PrijsLijst> PrijsLijsts = new List<PrijsLijst>();
            foreach (PrijsLijstDO prijsLijstDO in PrijsLijstDOs)
            {
                PrijsLijsts.Add(ConvertFromDO(prijsLijstDO));
            }
            return PrijsLijsts;
        }

        public void Aanpassen()
        {
            PrijsLijstDO prijsLijstDO = DataAccess.UpdatePrijsLijst(ConvertToDO(this));
        }

        public void Toevoegen()
        {
            PrijsLijstDO prijsLijstDO = DataAccess.ToevoegenPrijsLijst(ConvertToDO(this));
        }

        public static PrijsLijst KrijgPrijsDoorFormuleNaam(string naam)
        {
            PrijsLijstDO prijsLijstDO = DataAccess.krijgPrijsDoorFormuleNaam(naam);
            return ConvertFromDO(prijsLijstDO);
        }

        public static PrijsLijst GeneerExcelLijst(List<PrijsLijst> prijsLijst)
        {
            Dictionary<string, object> cellenDictionary = new Dictionary<string, object>();
            List<BL.Formule> formules = BL.Formule.KrijgAlleFormules();
            int index = 2;
            foreach (PrijsLijst prijs in prijsLijst)
            {
                index++;
             //   cellenDictionary.Add("A" + index, prijs.id);
                foreach(Formule formule in formules)
                {
                    if (formule.Naam == prijs.Formule)
                    {
                        try { cellenDictionary.Add("A" + index, formule.Omschrijving); } catch { }
                      
                    }
                }
                cellenDictionary.Add("B" + index, prijs.aannemer);
                cellenDictionary.Add("C" + index, prijs.particulier);
            }

            string[,] cellenArray = new string[700, 3];

            foreach (KeyValuePair<string, object> pair in cellenDictionary)
            {
                int kollom = Convert.ToChar(pair.Key.Substring(0, 1)) - 65;
                int rij = Convert.ToInt32(pair.Key.Substring(1)) - 1;
                cellenArray[rij, kollom] = pair.Value.ToString();
            }

            string bestandsNaam = "PrijsLijst";
            string strFullpath = @"C:\Leveringen\";
            if (!Directory.Exists(strFullpath))
            {
                string folderName = @"C:\Leveringen\";
                string pathString = System.IO.Path.Combine(folderName);
                System.IO.Directory.CreateDirectory(pathString);
                ExcelLijstPrijs.CreateDocument(@"C:\Leveringen\Prijzen.xlsx", bestandsNaam, cellenArray);
            }
            else
            {
                ExcelLijstPrijs.CreateDocument(@"C:\Leveringen\Prijzen.xlsx", bestandsNaam, cellenArray);
            }


            return null;
        }



        #endregion
    }
}
