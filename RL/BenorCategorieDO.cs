using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL
{
    public class BenorCategorieDO
    {
        #region Variables

        private int id;
        private string naam;

        #endregion

        #region Properties

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

        #endregion



        #region Constructors
        public BenorCategorieDO()
        {
        }


        public BenorCategorieDO(string naam)
        {
            Naam = naam;
        }

        public BenorCategorieDO(int id, string naam)
            : this(naam)
        {
            ID = id;
        }
        #endregion

    }
}
