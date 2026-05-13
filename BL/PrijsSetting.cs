using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PrijsSetting
    {
        #region variables
        private int id;
        private byte soort;
        private Klant klant;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public byte Soort
        {
            get { return soort; }
            set { soort = value; }
        }
        public Klant Klant
        {
            get { return klant; }
            set { klant = value; }
        }
        #endregion

        #region constructors
        public PrijsSetting()
        {

        }
        public PrijsSetting(byte soort, Klant klant)
        {
            Soort = soort;
            Klant = klant;
        }
        public PrijsSetting(int id,byte soort,Klant klant)
            :this(soort,klant)
        {
            ID = id;
        }
        #endregion

        #region methods
        public static PrijsSetting ConvertFromDO(PrijsSettingDO prijsSettingDO)
        {
            PrijsSetting prijsSetting = new PrijsSetting(prijsSettingDO.ID, prijsSettingDO.Soort,Klant.ConvertFromDO(prijsSettingDO.KlantDO));
            return prijsSetting;
        }

        public PrijsSettingDO ConvertToDO(PrijsSetting prijsSetting)
        {
            PrijsSettingDO prijsSettingDO = new PrijsSettingDO(ID, Soort,Klant.ConvertToDO(klant));
            return prijsSettingDO;
        }

        public void MaakNieuwePrijsSetting()
        {
            PrijsSettingDO prijsSettingDO = DataAccess.MaakNieuwePrijsSetting(ConvertToDO(this));
        }

        public static PrijsSetting krijgPrijsSettingKlant(Klant klant)
        {
            try
            {
                PrijsSettingDO prijsSettingDO = DataAccess.KrijgPrijsSettingViaKlantID(klant.ID);
                PrijsSetting prijsSetting = ConvertFromDO(prijsSettingDO);
                return prijsSetting;
            }
              catch { return null; }
           
        }
        #endregion
    }
}
