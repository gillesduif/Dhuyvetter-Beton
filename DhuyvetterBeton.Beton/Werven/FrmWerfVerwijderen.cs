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

namespace DhuyvetterBeton.Beton.Werven
{
    public partial class FrmWerfVerwijderen : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
        
        public FrmWerfVerwijderen()
        {
            InitializeComponent();
            klantenLijst.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            cboKlanten.Items.AddRange(klantenLijst.ToArray());
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
         
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Werf> WervenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            WervenLijst.Sort((X, Y) => X.Adres.CompareTo(Y.Adres));
            listBoxWervenVanKlant.Items.AddRange(WervenLijst.ToArray());
        }

        private void listBoxWervenVanKlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAdres.Text = ((Werf)listBoxWervenVanKlant.SelectedItem).Adres;
            txtGemeente.Text = ((Werf)listBoxWervenVanKlant.SelectedItem).Gemeente;
            txtPostcode.Text = ((Werf)listBoxWervenVanKlant.SelectedItem).Postcode;
            txtTelefoon.Text = ((Werf)listBoxWervenVanKlant.SelectedItem).Telefoon;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Werf werf = ((Werf)(listBoxWervenVanKlant.SelectedItem));
            listBoxWervenVanKlant.Items.Clear();

            werf.VerwijderWerf();

            List<Werf> wervenVanKlantenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            listBoxWervenVanKlant.Items.AddRange(wervenVanKlantenLijst.ToArray());

            txtAdres.Text = String.Empty;
            txtGemeente.Text = String.Empty;
            txtPostcode.Text = String.Empty;
            txtTelefoon.Text = String.Empty;
        }
    }
}
