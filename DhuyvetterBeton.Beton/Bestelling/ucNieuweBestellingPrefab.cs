using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BL;
using System.Drawing.Printing;
using System.IO;
using DhuyvetterBeton.Beton.Agenda;

namespace DhuyvetterBeton.Beton.Bestelling
{
    public partial class ucNieuweBestellingPrefab : DevExpress.XtraEditors.XtraUserControl
    {
        string User;
        string versie;
        FrmHoofdVenster frmhoofd;

        List<ProductPrefab> prefabProducten = new List<ProductPrefab>();
        public ucNieuweBestellingPrefab(FrmHoofdVenster frmhoofd1, string user1, string versie1)
        {
            InitializeComponent();
            timer1.Start();
            User = user1;
            frmhoofd = frmhoofd1;
            versie = versie1;
            dtpDatum.CustomFormat = "dddd dd/MM/yyyy - HH : mm";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            BestellingPrefab bestellingPrefab = new BestellingPrefab(((KlantPrefab)comboBoxKlanten.SelectedItem), ((WerfPrefab)cboWerven.SelectedItem), prefabProducten, dtpDatum.Value, cboLeveringWijze.Text, txtComment.Text);
            bestellingPrefab.MaakNieuweBestellingPrefab();
            bestellingPrefab.GeneerExcellRec(User);


         
          
                string bestandsNaam = bestellingPrefab.KlantPrefab.Naam + " " + bestellingPrefab.Datum.Hour.ToString() + "u" + bestellingPrefab.Datum.Minute.ToString();
                

                //documentViewer1.DocumentSource = bestandsnaam;
                try
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbooks books = excelApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook sheets = books.Open(@"Z:\Bestellingen\" + bestellingPrefab.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                }
                catch
                {
                    MessageBox.Show("Bestand niet gevonden.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               

            
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(User, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void BtnKlantToevoegen_Click(object sender, EventArgs e)
        {
            KlantPrefab klantPrefab = new KlantPrefab(txtNaam.Text, txtAdres.Text, cboPostcode.Text, CboGemeente.Text.ToUpper());
            klantPrefab.MaakNieuweKlant();
            List<KlantPrefab> klantprefablistrefresh = KlantPrefab.KrijgAllePrefabKlanten();
            comboBoxKlanten.Properties.Items.Clear();
            comboBoxKlanten.Properties.Items.AddRange(klantprefablistrefresh.ToArray());
            int index = 0;
            foreach (KlantPrefab klantprefab in comboBoxKlanten.Properties.Items)
            {
                if (klantprefab.Naam == txtNaam.Text)
                {
                    comboBoxKlanten.SelectedIndex = index;
                    break;
                }
                index++;
            }
            
            txtNaam.Text = string.Empty;
            txtAdres.Text = string.Empty;


            cboPostcode.Text = string.Empty;
            CboGemeente.Text = string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<KlantPrefab> prefabKlanten = KlantPrefab.KrijgAllePrefabKlanten();
            prefabKlanten.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            comboBoxKlanten.Properties.Items.AddRange(prefabKlanten.ToArray());
            comboBoxKlantContact.Properties.Items.AddRange(prefabKlanten.ToArray());
            cbonieuwewerfklant.Properties.Items.AddRange(prefabKlanten.ToArray());

            List<PostcodeGemeente> gemeentelijst = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            foreach (PostcodeGemeente postcodeGemeente in gemeentelijst)
            {
                CboGemeente.Properties.Items.Add(postcodeGemeente);
                cboGemeenteWerf.Properties.Items.Add(postcodeGemeente);
            }
            foreach (PostcodeGemeente posstcodeLijst in gemeentelijst)
            {
                cboPostcodeWerf.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
                cboPostcode.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
            }
            timer1.Stop();
        }

        private void comboBoxKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKlanten.SelectedItem != null)
            {
                
                int index = 0;
                foreach (KlantPrefab klantprefab in cbonieuwewerfklant.Properties.Items)
                {
                    if (klantprefab.Naam == comboBoxKlanten.Text)
                    {
                        cbonieuwewerfklant.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
                int index1 = 0;
                foreach (KlantPrefab klantprefab in comboBoxKlantContact.Properties.Items)
                {
                    if (klantprefab.Naam == comboBoxKlanten.Text)
                    {
                        comboBoxKlantContact.SelectedIndex = index1;
                        break;
                    }
                    index1++;
                }

             
                labelAdresKlantPrefab.Text = ((KlantPrefab)comboBoxKlanten.SelectedItem).Straat;
                labelGemeenteKlantPrefab.Text = ((KlantPrefab)comboBoxKlanten.SelectedItem).Gemeente;
                labelPostcodeKlantPrefab.Text = ((KlantPrefab)comboBoxKlanten.SelectedItem).Postcode;
                List<WerfPrefab> prefabWerven = WerfPrefab.KrijgAlleWervenVanPrefab(((KlantPrefab)comboBoxKlanten.SelectedItem).ID);
                cboWerven.Properties.Items.AddRange(prefabWerven.ToArray());
                List<ContactPersoonPrefab> contactPersoonPrefabs = ContactPersoonPrefab.KrijgAlleContactpersonenVanPrefabKlantViaID(((KlantPrefab)comboBoxKlanten.SelectedItem).ID);
                cboContactNieuweWerf.Properties.Items.AddRange(contactPersoonPrefabs.ToArray());
            }
        }

        private void cboWerven_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWerfAdres.Text = ((WerfPrefab)cboWerven.SelectedItem).Adres;
            labelWerfGemeente.Text = ((WerfPrefab)cboWerven.SelectedItem).Gemeente;
            labelWerfPostcode.Text = ((WerfPrefab)cboWerven.SelectedItem).Postcode;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cboContactNieuweWerf.SelectedItem != null)
            {
                WerfPrefab werfPrefab = new WerfPrefab(((KlantPrefab)comboBoxKlanten.SelectedItem), txtAdresWerf.Text, cboGemeenteWerf.Text, cboPostcodeWerf.Text, ((ContactPersoonPrefab)cboContactNieuweWerf.SelectedItem));
                werfPrefab.MaakNieuweWerf();
                List<WerfPrefab> WervenPrefabKlant = WerfPrefab.KrijgAlleWervenVanPrefab(((KlantPrefab)comboBoxKlanten.SelectedItem).ID);
                cboWerven.Properties.Items.AddRange(WervenPrefabKlant.ToArray());
               

                int index = 0;
                foreach (WerfPrefab WerfPrefab1 in cboWerven.Properties.Items)
                {
                    if (WerfPrefab1.ToString() == werfPrefab.ToString())
                    {
                        cboWerven.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
            }
            else
            {
                MessageBox.Show("Nieuwe contact persoon toevoegen.");
                paneelNieuweWerf.Visible = false;
                paneelNieuwContactpersoon.Visible = true;
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            ContactPersoonPrefab contactPersoonPrefab = new ContactPersoonPrefab(txtNaamContact.Text, txtVoornaamContact.Text, txtTelefoonContact.Text, txtGSMcontact.Text, ((KlantPrefab)comboBoxKlanten.SelectedItem));
            contactPersoonPrefab.MaakNieuwContactPersoon();
            ContactPersoonPrefab contactPersoonPrefabSelectie = new ContactPersoonPrefab();
            List<ContactPersoonPrefab> contactpersonenvanKlant = ContactPersoonPrefab.KrijgAlleContactpersonenVanPrefabKlantViaID(((KlantPrefab)comboBoxKlanten.SelectedItem).ID);
            foreach (ContactPersoonPrefab contactPersoonPrefab1 in contactpersonenvanKlant)
            {
                if (contactPersoonPrefab1.Naam == contactPersoonPrefab.Naam && contactPersoonPrefab1.Voornaam == contactPersoonPrefab.Voornaam && contactPersoonPrefab1.Telefoon == contactPersoonPrefab.Telefoon && contactPersoonPrefab1.GSM == contactPersoonPrefab.GSM)
                {
                    contactPersoonPrefabSelectie = contactPersoonPrefab1;
                }
            }

            WerfPrefab werfPrefab = new WerfPrefab(((KlantPrefab)comboBoxKlanten.SelectedItem), txtAdresWerf.Text, cboGemeenteWerf.Text, cboPostcodeWerf.Text, contactPersoonPrefabSelectie);
            werfPrefab.MaakNieuweWerf();
            cboWerven.Properties.Items.Clear();
            List<WerfPrefab> prefabWerven = WerfPrefab.KrijgAlleWervenVanPrefab(((KlantPrefab)comboBoxKlanten.SelectedItem).ID);
            WerfPrefab werfPrefabSelectie = new WerfPrefab();
            foreach (WerfPrefab werfPrefab1 in prefabWerven)
            {
                if (werfPrefab1.Adres == werfPrefab.Adres && werfPrefab1.Gemeente == werfPrefab.Gemeente && werfPrefab1.Postcode == werfPrefab.Postcode)
                {
                    werfPrefabSelectie = werfPrefab1;
                }
            }
            cboWerven.Properties.Items.AddRange(prefabWerven.ToArray());
          

            int index = 0;
            foreach (WerfPrefab WerfPrefab1 in cboWerven.Properties.Items)
            {
                if (WerfPrefab1.ToString() == werfPrefabSelectie.ToString())
                {
                    cboWerven.SelectedIndex = index;
                    break;
                }
                index++;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            ProductPrefab productPrefab = new ProductPrefab(txtLot.Text, txtAantalStuks.Text, txtLangsteElement.Text, txtM3.Text);
            prefabProducten.Add(productPrefab);
            listBoxProducten.Items.Clear();
            listBoxProducten.Items.AddRange(prefabProducten.ToArray());
            listBoxProductOverzicht.Items.Clear();
            listBoxProductOverzicht.Items.AddRange(prefabProducten.ToArray());
            txtAantalStuks.Text = string.Empty;
            txtLangsteElement.Text = string.Empty;
            txtM3.Text = string.Empty;
            txtLot.Text = string.Empty;
        }

        private void cboContactNieuweWerf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContactNieuweWerf.SelectedItem != null)
            {
                simpleButton1.Text = "Toevoegen";
            }
        }

        private void cboContactNieuweWerf_TextChanged(object sender, EventArgs e)
        {
            if (cboContactNieuweWerf.Text == string.Empty)
            {
                simpleButton1.Text = "Nieuw contactpersoon";
            }
        }

        private void cboGemeenteWerf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPostcodeWerf.Text = ((PostcodeGemeente)cboGemeenteWerf.SelectedItem).Postcode.ToString();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            prefabProducten.Clear();
            listBoxProducten.Items.Clear();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(User, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }

        }
    }
}
