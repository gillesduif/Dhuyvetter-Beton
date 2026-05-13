using BL;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Kortingen
{
    public partial class FrmNieuweKortingWerf : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmNieuweKortingWerf()
        {
            InitializeComponent();
        }

        private void FrmNieuweKortingKlant_Load(object sender, EventArgs e)
        {
            List<Klant> klantenlist = Klant.KrijgAlleKlanten();
          
            cboKlanten.Items.AddRange(klantenlist.ToArray());
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            Klant klant = ((Klant)cboKlanten.SelectedItem);
            List<Werf> wervenlist = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
            cboWerven.Items.AddRange(wervenlist.ToArray());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Korting_Werf korting_Werf = new Korting_Werf(((Klant)cboKlanten.SelectedItem), ((Werf)cboWerven.SelectedItem), Convert.ToDouble(txtbedrag.Text));
            korting_Werf.maakNieuweKortingWerf();
        }
    }
}
