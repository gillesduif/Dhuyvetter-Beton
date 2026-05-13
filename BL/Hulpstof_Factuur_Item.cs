using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Hulpstof_Factuur_Item
    {
        #region variables
        private int id;
        private Factuur_Item factuur_Item;
        private string hulpstof;
        private double eenheidsPrijsHulpstof;
        private double totaalPrijsHulpstof;

        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    
        public Factuur_Item Factuur_Item
        {
            get { return factuur_Item; }
            set { factuur_Item = value; }
        }
        public string Hulpstof
        {
            get { return hulpstof; }
            set { hulpstof = value; }
        }
        public double EenheidsPrijsHulpstof
        {
            get { return eenheidsPrijsHulpstof; }
            set { eenheidsPrijsHulpstof = value; }
        }
        public double TotaalPrijsHulpstof
        {
            get { return totaalPrijsHulpstof; }
            set { totaalPrijsHulpstof = value; }
        }
        #endregion

        #region constructors
        public Hulpstof_Factuur_Item(Factuur_Item factuur_Item,string hulpstof, double eenheidsPrijsHulpstof , double totaalPrijsHulpstof)
        {
            Factuur_Item = factuur_Item;
            Hulpstof = hulpstof;
            EenheidsPrijsHulpstof = eenheidsPrijsHulpstof;
            TotaalPrijsHulpstof = totaalPrijsHulpstof;
        }

        public Hulpstof_Factuur_Item(int id, Factuur_Item factuur_Item, string hulpstof, double eenheidsPrijsHulpstof, double totaalPrijsHulpstof)
          : this(factuur_Item, hulpstof, eenheidsPrijsHulpstof,totaalPrijsHulpstof)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static Hulpstof_Factuur_Item ConvertFromDO(Hulpstof_Factuur_ItemDO hulpstof_Factuur_ItemDO)
        {
            Hulpstof_Factuur_Item hulpstof_Factuur_Item = new Hulpstof_Factuur_Item(hulpstof_Factuur_ItemDO.ID, Factuur_Item.ConvertFromDO(hulpstof_Factuur_ItemDO.Factuur_ItemDO), hulpstof_Factuur_ItemDO.Hulpstof, hulpstof_Factuur_ItemDO.EenheidsPrijsHulpstof,hulpstof_Factuur_ItemDO.TotaalPrijsHulpstof );
            return hulpstof_Factuur_Item;
        }

        public Hulpstof_Factuur_ItemDO ConvertToDO(Hulpstof_Factuur_Item hulpstof_Factuur_Item)
        {
            Hulpstof_Factuur_ItemDO hulpstof_Factuur_ItemDO = new Hulpstof_Factuur_ItemDO(hulpstof_Factuur_Item.ID, Factuur_Item.ConvertToDO(hulpstof_Factuur_Item.Factuur_Item), hulpstof_Factuur_Item.Hulpstof,hulpstof_Factuur_Item.EenheidsPrijsHulpstof,hulpstof_Factuur_Item.TotaalPrijsHulpstof);
            return hulpstof_Factuur_ItemDO;
        }

        public void maakNieuweHulpstofFactuurItem()
        {
            Hulpstof_Factuur_ItemDO hulpstof_Factuur_ItemDO = DataAccess.MaakNieuweHulpstofFactuurItem(ConvertToDO(this));
        }

        public static List<Hulpstof_Factuur_Item> krijgAlleHulpstoffenPerFactuurItem(int ID)
        {
            List<Hulpstof_Factuur_ItemDO> Hulpstof_Factuur_ItemDOs = DataAccess.KrijgAlleHulpstofFactuurItemsDoorFactuurID(ID);
            List<Hulpstof_Factuur_Item> Hulpstof_Factuur_Items = new List<Hulpstof_Factuur_Item>();
            foreach (Hulpstof_Factuur_ItemDO hulpstof_Factuur_ItemDO in Hulpstof_Factuur_ItemDOs)
            {
                Hulpstof_Factuur_Items.Add(ConvertFromDO(hulpstof_Factuur_ItemDO));
            }
            return Hulpstof_Factuur_Items;
        }

       

        #endregion
    }
}
