using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class HulpstofDO
    {
        #region variables
        private int id;
        private string naam;
        private NormaleLeveringBonDO normaleLeveringBonDO;
        private BestellingDO bestellingDO;
        private string hoeveelheid;
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
        public NormaleLeveringBonDO NormaleLeveringBonDO
        {
            get { return normaleLeveringBonDO; }
            set { normaleLeveringBonDO = value; }
        }
        public BestellingDO BestellingDO
                {
                    get { return bestellingDO; }
                    set { bestellingDO = value; }
                }
        public string Hoeveelheid
        {
            get { return hoeveelheid; }
            set { hoeveelheid = value; }
        }
        #endregion

        #region constructors
        public HulpstofDO()
                {

                }
        public HulpstofDO(string naam)
        {
            Naam = naam;

        }

        public HulpstofDO(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        public HulpstofDO(int id, string naam, string hoeveelheid)
    : this(id, naam)
        {
            Hoeveelheid = hoeveelheid;
        }
        public HulpstofDO(int id, string naam, string hoeveelheid, BestellingDO bestellingDO)
: this(id, naam, hoeveelheid)
        {
            BestellingDO = bestellingDO;
        }
        public HulpstofDO(int id, string naam, string hoeveelheid, NormaleLeveringBonDO normaleLeveringBonDO)
: this(id, naam, hoeveelheid)
        {
            NormaleLeveringBonDO = normaleLeveringBonDO;

        }
        #endregion
    }
}