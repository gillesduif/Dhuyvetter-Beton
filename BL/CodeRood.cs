using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CodeRood
    {
        #region variables
        private int id;
        private int bestelID;
        private int klantID;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int BestelID
        {
            get { return bestelID; }
            set { bestelID = value; }
        }

        public int KlantID
        {
            get { return klantID; }
            set { klantID = value; }
        }

        #endregion


        #region constructors

        public CodeRood()
        {

        }

        public CodeRood(int bestelID, int klantID)
        {
            BestelID = bestelID;
            KlantID = klantID;
        }
        public CodeRood(int id,int bestelID, int klantID)
            :this(bestelID,klantID)
        {
            ID = id;
        }
        #endregion


        #region methods
        public static CodeRood ConvertFromDO(CodeRoodDO codeRoodDO)
        {
            CodeRood codeRood = new CodeRood(codeRoodDO.ID, codeRoodDO.BestelID, codeRoodDO.KlantID);
            return codeRood;
        }

        public CodeRoodDO ConvertToDO(CodeRood codeRood)
        {
            CodeRoodDO codeRoodDO = new CodeRoodDO(ID, bestelID, klantID);
            return codeRoodDO;
        }

        public void MaakNieuweCode()
        {
            CodeRoodDO codeRoodDO = DataAccess.MaakNieuwCodeRood(ConvertToDO(this));
        }

        public static CodeRood KrijgCodeRoodDoorBestelID(int bestelID)
        {
            CodeRoodDO codeRoodDO = DataAccess.krijgCodeRoodDoorBestellingID(bestelID);
            return ConvertFromDO(codeRoodDO);
        }

        public void Verwijdercodebestelling(int ID)
        {
            CodeRoodDO codeRoodDO = DataAccess.VerwijderCodeRooddoorBestelID(ID);
        }

        #endregion
    }
}
