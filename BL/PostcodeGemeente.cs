using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PostcodeGemeente
    {
        #region variables
        private int id;
        private string postcode;
        private string gemeente;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string Gemeente
        {
            get { return gemeente; }
            set { gemeente = value; }
        }
        #endregion

        #region constructors
        public PostcodeGemeente(int id, string postcode, string gemeente)
        {
            ID = id;
            Postcode = postcode;
            Gemeente = gemeente;
        }
        #endregion

        #region Methods

        public static PostcodeGemeente ConvertFromDO(PostcodeGemeenteDO postcodeGemeenteDO)
        {
            return new PostcodeGemeente(postcodeGemeenteDO.ID, postcodeGemeenteDO.Postcode, postcodeGemeenteDO.Gemeente);
        }

        public PostcodeGemeenteDO ConvertToDO(PostcodeGemeente postcodeGemeente)
        {
            return new PostcodeGemeenteDO(ID, Postcode, Gemeente);
        }

        public static List<PostcodeGemeente> KrijgAllePostcodeGemeentes()
        {
            List<PostcodeGemeenteDO> postcodeGemeenteDOs = DataAccess.KrijgAllePostcodeGemeentes();
            List<PostcodeGemeente> postcodeGemeentes = new List<PostcodeGemeente>();
            foreach (PostcodeGemeenteDO postcodeGemeenteDO in postcodeGemeenteDOs)
            {
                postcodeGemeentes.Add(ConvertFromDO(postcodeGemeenteDO));
            }
            return postcodeGemeentes;
        }
        public static List<PostcodeGemeente> KrijgAllePostcodeGemeentesWebsite()
        {
            List<PostcodeGemeenteDO> postcodeGemeenteDOs = DataAccess.KrijgAllePostcodeGemeentesWebsite();
            List<PostcodeGemeente> postcodeGemeentes = new List<PostcodeGemeente>();
            foreach (PostcodeGemeenteDO postcodeGemeenteDO in postcodeGemeenteDOs)
            {
                postcodeGemeentes.Add(ConvertFromDO(postcodeGemeenteDO));
            }
            return postcodeGemeentes;
        }
        public override string ToString()
        {
            return Gemeente;
        }
        public string ToStringGemeente()
        {
            return Gemeente;
        }
        public string ToStringPostcode()
        {
            return Postcode;
        }



        #endregion
    }
}
