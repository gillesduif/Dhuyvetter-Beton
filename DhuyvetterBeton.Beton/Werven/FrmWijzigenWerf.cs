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
    public partial class FrmWijzigenWerf : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Klant klant;
        Werf werf;
        string USER;
        public FrmWijzigenWerf(Klant klant1,Werf werf1,string User1)
        {
            InitializeComponent();
            if (klant1 != null && werf1 != null)
            {
                klant = klant1;
                werf = werf1;
            }
            else if (klant1 != null)
            {
                klant = klant1;
            }
            USER = User1;
        }

        private void FrmWijzigenWerf_Load(object sender, EventArgs e)
        {
            if (klant != null)
            {
                List<Werf> wervenVanKlantLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
                listBoxWervenVanKlant.Items.AddRange(wervenVanKlantLijst.ToArray());
            }
         
            if (werf != null)
            {
                txtAdres.Text = werf.Adres;
                txtGemeente.Text = werf.Gemeente;
                txtPostcode.Text = werf.Postcode;
                txtTelefoon.Text = werf.Telefoon;
                string werfgegevens = werf.Adres + " " + werf.Gemeente;
                int index = listBoxWervenVanKlant.FindString(werfgegevens);
                listBoxWervenVanKlant.SelectedIndex = index;
            }

            if (klant == null)
            {
                List<Klant> klantenList = Klant.KrijgAlleKlanten();
                cboKlanten.Items.AddRange(klantenList.ToArray());
                cboKlanten.Visible = true;
                labelKl.Visible = true;
            }

        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
          
        
        }

        private void listBoxWervenVanKlant_Click(object sender, EventArgs e)
        {
            if (listBoxWervenVanKlant.SelectedItem != null)
            {
                Werf werf = ((Werf)listBoxWervenVanKlant.SelectedItem);
                txtAdres.Text = werf.Adres;
                txtGemeente.Text = werf.Gemeente;
                txtPostcode.Text = werf.Postcode;
                txtTelefoon.Text = werf.Telefoon;
            }
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxWervenVanKlant.Items.Clear();
            klant = ((Klant)cboKlanten.SelectedItem);
            List<Werf> wervenVanKlantenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            wervenVanKlantenLijst.Sort((x, y) => x.Adres.CompareTo(y.Adres));
            listBoxWervenVanKlant.Items.AddRange(wervenVanKlantenLijst.ToArray());
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
          
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Werf werf2 = new Werf(((Werf)listBoxWervenVanKlant.SelectedItem).ID, klant, txtAdres.Text, txtGemeente.Text, txtPostcode.Text, txtTelefoon.Text);
            werf2.UpdateWerftGegevens();
            Logboek logboek = new Logboek(DateTime.Now, "WERVEN", "[NIEUWE WERF TOEGEVOEGD] Klant: " + werf2.Klant.Naam + " Adres: " + werf2.Adres + " Gemeente: " + werf2.Gemeente + " Postcode: " + werf2.Postcode, USER);
            logboek.MaakNieuwLogBoekPunt();
            listBoxWervenVanKlant.Items.Clear();
            List<Werf> wervenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
            listBoxWervenVanKlant.Items.AddRange(wervenLijst.ToArray());
            var message = "Nog een werf wijzigen?";
            var title = "Keuze!";
            var result = MessageBox.Show(
                message,                  // the message to show
                title,                    // the title for the dialog box
                MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                MessageBoxIcon.Question); // show a question mark icon

            // the following can be handled as if/else statements as well
            switch (result)
            {
                case DialogResult.Yes:   // Yes button pressed
                    txtAdres.Text = String.Empty;
                    txtGemeente.Text = String.Empty;
                    txtPostcode.Text = String.Empty;
                    txtTelefoon.Text = String.Empty;
                    break;
                case DialogResult.No:    // No button pressed
                    this.Close();
                    break;
                default:                 // Neither Yes nor No pressed (just in case)

                    break;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
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

        private void listBoxWervenVanKlant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
