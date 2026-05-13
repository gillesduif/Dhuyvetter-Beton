using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Logboek
    {
        #region variables
        private int id;
        private DateTime datumEnTijd;
        private string functie;
        private string taak;
        private string gebruiker;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime DatumEnTijd
        {
            get { return datumEnTijd; }
            set { datumEnTijd = value; }
        }
        public string Functie
        {
            get { return functie; }
            set { functie = value; }
        }
        public string Taak
        {
            get { return taak; }
            set { taak = value; }
        }
        public string Gebruiker
        {
            get { return gebruiker; }
            set { gebruiker = value; }
        }
        #endregion
        #region constructors

        public Logboek()
        {

        }
        public Logboek(DateTime datumEnTijd, string functie, string taak,string gebruiker)
        {
            DatumEnTijd = datumEnTijd;
            Taak = taak;
            Functie= functie;
            Gebruiker = gebruiker;
        }

        

        public Logboek(int id, DateTime datumEnTijd, string functie, string taak, string gebruiker)
            : this(datumEnTijd, functie, taak, gebruiker)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static Logboek ConvertFromDO(LogboekDO logboekDO)
        {
            Logboek logboek = new Logboek(logboekDO.ID,logboekDO.DatumEnTijd, logboekDO.Functie, logboekDO.Taak, logboekDO.Gebruiker);
            return logboek;
        }

        public LogboekDO ConvertToDO(Logboek logboek)
        {
            LogboekDO logboekDO = new LogboekDO(ID, DatumEnTijd, Functie, Taak, Gebruiker);
            return logboekDO;
        }
        public Logboek MaakNieuwLogBoekPunt()
        {
            LogboekDO logboekDO = DataAccess.MaakNieuwLogboekPunt(ConvertToDO(this));
            return ConvertFromDO(logboekDO);
        }
        public static List<Logboek> KrijgAlleLogboekenDoorDatum(DateTime date)
        {
            List<LogboekDO> LogboekDOs = DataAccess.SelecteerLogboekPuntenVoorEenDatum(date);
            List<Logboek> Logboeks = new List<Logboek>();
            foreach (LogboekDO logboekDO in LogboekDOs)
            {
                Logboeks.Add(ConvertFromDO(logboekDO));
            }
            return Logboeks;
        }

        public static List<Logboek> KrijgAlleLogboekenDoorDatumEnFunctie(DateTime date, string Functie)
        {
            List<LogboekDO> LogboekDOs = DataAccess.SelecteerLogboekPuntenVoorEenDatumEnFunctie(date,Functie);
            List<Logboek> Logboeks = new List<Logboek>();
            foreach (LogboekDO logboekDO in LogboekDOs)
            {
                Logboeks.Add(ConvertFromDO(logboekDO));
            }
            return Logboeks;
        }

        public static List<Logboek> KrijgAlleLogboekenDoorDatumEnFunctieEnGebruiker(DateTime date, string Functie, string Gebruiker)
        {
            List<LogboekDO> LogboekDOs = DataAccess.SelecteerLogboekPuntenVoorEenDatumEnFunctieEnGebruiker(date, Functie,Gebruiker);
            List<Logboek> Logboeks = new List<Logboek>();
            foreach (LogboekDO logboekDO in LogboekDOs)
            {
                Logboeks.Add(ConvertFromDO(logboekDO));
            }
            return Logboeks;
        }

        public static List<Logboek> KrijgAlleLogboekenDoorDatumEnGebruiker(DateTime date, string gebruiker)
        {
            List<LogboekDO> LogboekDOs = DataAccess.SelecteerLogboekPuntenVoorEenDatumEnGebruiker(date,gebruiker);
            List<Logboek> Logboeks = new List<Logboek>();
            foreach (LogboekDO logboekDO in LogboekDOs)
            {
                Logboeks.Add(ConvertFromDO(logboekDO));
            }
            return Logboeks;
        }
        #endregion
    }
}
