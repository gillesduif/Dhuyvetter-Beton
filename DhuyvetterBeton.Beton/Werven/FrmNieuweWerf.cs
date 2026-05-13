using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Werven
{
    public partial class FrmNieuweWerf : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Klant klant;
        string USER;
        public FrmNieuweWerf(Klant klant1, string user1)
        {
            if (klant1 != null)
            {
                klant = klant1;
            }
            InitializeComponent();
            USER = user1;
        }

        private  void FrmNieuweWerf_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (klant != null)
            {
                List<Klant> klantenList = Klant.KrijgAlleKlanten();
                cboKlanten.Items.AddRange(klantenList.ToArray());
                cboKlanten.SelectedIndex = cboKlanten.FindString(klant.ToString());
            }
            else
            {
                List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
                cboKlanten.Items.AddRange(klantenLijst.ToArray());
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonCtrl_Click(object sender, EventArgs e)
        {
        
        }

        private void txtAdres_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         

        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (klant != null)
            {
                txtAdres.Text = klant.Adres;
                txtPostcode.Text = klant.Postcode;
                txtGemeente.Text = klant.Gemeente;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Werf werf = new Werf(((Klant)cboKlanten.SelectedItem), txtAdres.Text,  txtGemeente.Text,txtPostcode.Text, txtTelefoon.Text);
            werf.maakNieuweWerf();

            Logboek logboek = new Logboek(DateTime.Now, "WERVEN", "[NIEUWE WERF TOEGEVOEGD] Klant: " + werf.Klant.Naam + " Adres: " + werf.Adres + " Gemeente: " + werf.Gemeente + " Postcode: " + werf.Postcode, USER);
            logboek.MaakNieuwLogBoekPunt();
            this.Close();
        }
    }
}
