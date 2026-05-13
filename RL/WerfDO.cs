namespace RL
{
    public class WerfDO
    {
        #region Variables
        private int id;
        private KlantDO klantDO;
        private string adres;
        private string gemeente;
        private string postcode;
        private string telefoon;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public KlantDO KlantDO
        {
            get { return klantDO; }
            set { klantDO = value; }
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Telefoon
        {
            get { return telefoon; }
            set { telefoon = value; }
        }

        #endregion

        #region Contructors

        public WerfDO()
        {
        }
        public WerfDO(KlantDO klantDO, string adres, string gemeente, string postcode,string telefoonnummer)
        {
            KlantDO = klantDO;
            Adres = adres;
            Postcode = postcode;
            Gemeente = gemeente;
            Telefoon = telefoonnummer;

        }

        public WerfDO(int id, KlantDO klantDO, string adres,  string gemeente,string postcode, string telefoonnummer)
            : this(klantDO, adres, gemeente, postcode, telefoonnummer)
        {
            ID = id;
        }
        #endregion
    }
}