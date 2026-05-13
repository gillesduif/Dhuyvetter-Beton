using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AfdrukWachtRij
    {
        #region variables 
        private int id;
        private int bestelID;
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

        
        #endregion

        #region constructors

        public AfdrukWachtRij()
        {

        }
        public AfdrukWachtRij(int bestelID)
        {
            BestelID = bestelID;
        }
        public AfdrukWachtRij(int id,int bestelID)
            :this(bestelID)
        {
            ID = id;
        }

        #endregion

        #region methods

        public static AfdrukWachtRij ConvertFromDO(AfdrukWachtRijDO afdrukWachtRijDO)
        {
            AfdrukWachtRij afdrukWachtRij = new AfdrukWachtRij(afdrukWachtRijDO.ID, afdrukWachtRijDO.BestelID);
            return afdrukWachtRij;
        }

        public AfdrukWachtRijDO ConvertToDO(AfdrukWachtRij afdrukWachtRij)
        {
            AfdrukWachtRijDO afdrukWachtRijDO = new AfdrukWachtRijDO(ID, bestelID);
            return afdrukWachtRijDO;
        }

        public override string ToString()
        {
            return "Bestelling nummer: " + bestelID.ToString();
        }

        public static List<AfdrukWachtRij> KrijgAlleOpdrachten()
        {
            List<AfdrukWachtRijDO> AfdrukWachtRijDOs = DataAccess.SelecteerAfdrukOpdrachten();
            List<AfdrukWachtRij> AfdrukWachtRijen = new List<AfdrukWachtRij>();
            foreach (AfdrukWachtRijDO afdrukWachtRijDO in AfdrukWachtRijDOs)
            {
                AfdrukWachtRijen.Add(ConvertFromDO(afdrukWachtRijDO));
            }
            return AfdrukWachtRijen;
        }

        public void verwijder()
        {
            AfdrukWachtRijDO afdrukWachtRijDO = DataAccess.VerwijderAfdrukItem(ConvertToDO(this));
        }

        public void MaakNieuwAfdrukTaak()
        {
            AfdrukWachtRijDO afdrukWachtRijDO = DataAccess.MaakNieuweAfdrukTaak(ConvertToDO(this));
          
        }

        public static AfdrukWachtRij KrijgOpdrachtViABestelID(int bestelID)
        {
            AfdrukWachtRijDO afdrukWachtRijDO = DataAccess.KrijgAfdrukTaak(bestelID);
            AfdrukWachtRij afdrukWachtRij = ConvertFromDO(afdrukWachtRijDO);
            return afdrukWachtRij;
        }
        #endregion
    }
}
