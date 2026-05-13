using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace DhuyvetterBeton.Beton.Klanten
{
    public partial class FrmKlantNotitie : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        List<KlantNotitie> klantNotitieLijst;
        public FrmKlantNotitie(List<KlantNotitie> lijst)
        {
            klantNotitieLijst = lijst;
            InitializeComponent();
        }

        private void FrmKlantNotitie_Load(object sender, EventArgs e)
        {
            if (klantNotitieLijst == null)
            {
                List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
                klantenLijst.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
                cboKlanten.Properties.Items.AddRange(klantenLijst.ToArray());
                List<KlantNotitie> klantNotities = KlantNotitie.KrijgAlleNotities();
                klantNotities.Sort((X, Y) => X.Klant.Naam.CompareTo(Y.Klant.Naam));
                lbxKlantNotities.Items.AddRange(klantNotities.ToArray());

            }
            else
            {
               // klantNotitieLijst.Sort((X, Y) => X.Klant.Naam.CompareTo(Y.Klant.Naam));
                lbxKlantNotities.Items.AddRange(klantNotitieLijst.ToArray());
            }
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            if(cboKlanten.SelectedItem != null)
            {
                KlantNotitie klantNotitie = new KlantNotitie(((Klant)cboKlanten.SelectedItem), txtNieuweNotitie.Text);
                klantNotitie.MaakNieuweNotitie();
            }
            txtNieuweNotitie.Text = string.Empty;
            cboKlanten.Text = string.Empty;
        }

        private void lbxKlantNotities_SelectedIndexChanged(object sender, EventArgs e)
        {
            KlantNotitie klantNotitie = ((KlantNotitie)lbxKlantNotities.SelectedItem);

            txtBestaandeNotitie.Text = klantNotitie.Notitie;
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void lbxKlantNotities_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                KlantNotitie klantNotitie = ((KlantNotitie)lbxKlantNotities.SelectedItem);

                txtBestaandeNotitie.Text = klantNotitie.Notitie;
            }
           catch { }
        }

        private void btnWijzigen_Click(object sender, EventArgs e)
        {
//TODO
        }
    }
}
