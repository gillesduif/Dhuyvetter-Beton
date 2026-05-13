using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Korting_Product_Werf
    {
        #region variables
        private int id;
        private Klant klant;
        private Werf werf;
        private Formule formule;
        private double bedrag;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Klant Klant
        {
            get { return klant; }
            set { klant = value; }
        }
        public Werf Werf
        {
            get { return werf; }
            set { werf = value; }
        }
        public Formule Formule
        {
            get { return formule; }
            set { formule = value; }
        }

        public double Bedrag
        {
            get { return bedrag; }
            set { bedrag = value; }
        }
        #endregion

        #region constructors
        public Korting_Product_Werf()
        {

        }
        public Korting_Product_Werf(Klant klant,Werf werf, Formule formule, double bedrag)
        {
            Klant = klant;
            Werf = werf;
            Formule = formule;
            Bedrag = bedrag;
        }
        public Korting_Product_Werf(int id, Klant klant, Werf werf, Formule formule, double bedrag)
            : this(klant,werf, formule, bedrag)
        {
            ID = id;
        }
        #endregion
        #region methods
        public static Korting_Product_Werf ConvertFromDO(Korting_Product_WerfDO korting_Product_WerfDO)
        {
            Korting_Product_Werf korting_Product_Werf = new Korting_Product_Werf(korting_Product_WerfDO.ID, Klant.ConvertFromDO(korting_Product_WerfDO.KlantDO),Werf.ConvertFromDO(korting_Product_WerfDO.WerfDO), Formule.ConvertFromDO(korting_Product_WerfDO.FormuleDO), korting_Product_WerfDO.Bedrag);
            return korting_Product_Werf;
        }
        public Korting_Product_WerfDO ConvertToDO(Korting_Product_Werf korting_Product_Werf)
        {
            Korting_Product_WerfDO korting_Product_WerfDO = new Korting_Product_WerfDO(ID, Klant.ConvertToDO(klant), Werf.ConvertToDO(werf), Formule.ConvertToDO(formule), Bedrag);
            return korting_Product_WerfDO;
        }
        public void maakNieuweKorting()
        {
            Korting_Product_WerfDO korting_ProductDO = DataAccess.MaakNieuweKortingProductWerf(ConvertToDO(this));
        }
        public override string ToString()
        {
            return "€" + Bedrag;
        }
        public static List<Korting_Product_Werf> KrijgKortingDoorProductIDenWerfID(int productID, int werfID)
        {
            List<Korting_Product_WerfDO> korting_Product_WerfDOs = DataAccess.KrijgAlleKortingenDoorProductIDenWerfID(productID, werfID);
            List<Korting_Product_Werf> korting_Product_Werfs = new List<Korting_Product_Werf>();
            foreach (Korting_Product_WerfDO korting_Product_WerfDO in korting_Product_WerfDOs)
            {
                korting_Product_Werfs.Add(ConvertFromDO(korting_Product_WerfDO));
            }
            return korting_Product_Werfs;
        }

        public static List<Korting_Product_Werf> KrijgKortingDoorKlantID(int klantID)
        {
            List<Korting_Product_WerfDO> korting_Product_WerfDOs = DataAccess.KrijgAlleKortingenWerfProductDoorKlantID(klantID);
            List<Korting_Product_Werf> korting_Product_Werfs = new List<Korting_Product_Werf>();
            foreach (Korting_Product_WerfDO korting_Product_WerfDO in korting_Product_WerfDOs)
            {
                korting_Product_Werfs.Add(ConvertFromDO(korting_Product_WerfDO));
            }
            return korting_Product_Werfs;
        }

        public void WijzigKortingWerfProduct()
        {
            Korting_Product_WerfDO korting_Product_WerfDO = DataAccess.UpdateKorting_WerfProductDO(ConvertToDO(this));
        }
        #endregion
    }
}
