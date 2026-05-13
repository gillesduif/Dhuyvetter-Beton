using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class BestellingPrefabDO
    {
        #region variables
        private int id;
        private KlantPrefabDO klantPrefabDO;
        private WerfPrefabDO werfPrefabDO;
        private List<ProductPrefabDO> productPrefabDO;
        private DateTime datum;
        private string levering;
        private string opmerking;
        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public KlantPrefabDO KlantPrefabDO
        {
            get { return klantPrefabDO; }
            set { klantPrefabDO = value; }
        }

        public WerfPrefabDO WerfPrefabDO
        {
            get { return werfPrefabDO; }
            set { werfPrefabDO = value; }
        }

        public List<ProductPrefabDO> ProductPrefabDO
        {
            get { return productPrefabDO; }
            set { productPrefabDO = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public string Levering
        {
            get { return levering; }
            set { levering = value; }
        }
        public string Opmerking
        {
            get { return opmerking; }
            set { opmerking = value; }
        }

        #endregion
        #region constructors

        public BestellingPrefabDO()
        {

        }

        public BestellingPrefabDO(KlantPrefabDO klantPrefabDO, WerfPrefabDO werfPrefabDO, List<ProductPrefabDO> productPrefabDO, DateTime datum, string levering, string opmerking)
        {
            KlantPrefabDO = klantPrefabDO;
            WerfPrefabDO = werfPrefabDO;
            ProductPrefabDO = productPrefabDO;
            Datum = datum;
            Levering = levering;
            Opmerking = opmerking;
        }
        public BestellingPrefabDO(int id, KlantPrefabDO klantPrefabDO, WerfPrefabDO werfPrefabDO, List<ProductPrefabDO> productPrefabDO, DateTime datum, string levering, string opmerking)
            : this(klantPrefabDO, werfPrefabDO, productPrefabDO, datum, levering, opmerking)
        {
            ID = id;
        }
        #endregion
    }
}
