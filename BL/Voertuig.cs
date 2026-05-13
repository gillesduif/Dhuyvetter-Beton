using DAL;
using RL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Voertuig
    {
        #region Variables

        private int id;
        private string nummerplaat;

        #endregion

        #region properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nummerplaat
        {
            get { return nummerplaat; }
            set { nummerplaat = value; }
        }
        #endregion

        #region constructors
        public Voertuig()
        {
            
        }

        public Voertuig(string nummerplaat)
        {
            Nummerplaat = nummerplaat;
        }

        public Voertuig(int id, string nummerplaat)
            : this(nummerplaat)
        {
            ID = id;
        }
        #endregion

        #region methods

        public static Voertuig ConvertFromDO(VoertuigDO voertuigDO)
        {
            if(voertuigDO != null)
            {
                Voertuig voertuig = new Voertuig(voertuigDO.ID, voertuigDO.Nummerplaat);

                return voertuig;
            }
            else
            {
                return new Voertuig(0, "");
            }
            
        }

        public VoertuigDO ConvertToDO(Voertuig voertuig)
        {
            VoertuigDO voertuigDO = new VoertuigDO(ID, Nummerplaat);

            return voertuigDO;
        }

        public override string ToString()
        {
            return Nummerplaat;
        }

        public static List<Voertuig> KrijgAlleVoertuigen()
        {
            List<VoertuigDO> voertuigenDOs = DataAccess.KrijgAlleVoertuigen();
            List<Voertuig> voertuigen = new List<Voertuig>();
            foreach (VoertuigDO voertuigDO in voertuigenDOs)
            {
                voertuigen.Add(ConvertFromDO(voertuigDO));
            }
            return voertuigen;
        }
        #endregion
    }
}
