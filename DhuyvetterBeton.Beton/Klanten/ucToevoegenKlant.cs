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
using DhuyvetterBeton.Beton.Agenda;
using DhuyvetterBeton.Beton.Klanten.Tools;

namespace DhuyvetterBeton.Beton.Klanten
{
    public partial class ucToevoegenKlant : DevExpress.XtraEditors.XtraUserControl
    {
        string versie;
        List<PostcodeGemeente> gemeentelijst;
        List<Klant> klantenList;
        FrmHoofdVenster frmhoofd;
        List<Klant> klantenZoeken = new List<Klant>();
        int klantenNummer;
        string USER;
        public ucToevoegenKlant(string user,FrmHoofdVenster frmhoofd1, string versie1, List<Klant> klantenListimport)
        {
        
            versie = versie1;
            USER = user;
            frmhoofd = frmhoofd1;
            gemeentelijst = PostcodeGemeente.KrijgAllePostcodeGemeentes();
        
            InitializeComponent();


            Cursor.Current = Cursors.WaitCursor;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            if (klantenListimport.Count > 0)
            {
                klantenList = klantenListimport;
             
                foreach (Klant klant in klantenList)
                {
                    bunifuCustomDataGrid1.Rows.Add(
                        new object[]
                        {
                        klant.ID,
                        klant.Nummer,
                        klant.Naam,
                        klant.Adres,
                        klant.Gemeente,
                        klant.Postcode,
                        klant.Gsm,
                        klant.Telefoon,
                        klant.Email,
                        klant.Fax,
                        klant.Btw,
                        klant.BuitenlandseBtw

                        }

                        );

                    Cursor.Current = Cursors.AppStarting;
                   


                }

                foreach (PostcodeGemeente postcodeGemeente in gemeentelijst)
                {
                    CboGemeenteZoeken.Properties.Items.Add(postcodeGemeente);
                    CboGemeenteNieuw.Properties.Items.Add(postcodeGemeente);
                }

                foreach (PostcodeGemeente posstcodeLijst in gemeentelijst)
                {
                    cboPostcodeZoeken.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
                    cboPostcodeNieuw.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
                }
                vScrollBar1.Minimum = 0;
                int max = bunifuCustomDataGrid1.RowCount;
                vScrollBar1.Maximum = max;
                Cursor.Current = Cursors.AppStarting;
                Klant klantenNummer = Klant.krijgLaatsteKlant();
                txtNummerNieuw.Text = (klantenNummer.Nummer + 1).ToString();

                Cursor.Current = Cursors.WaitCursor; ;
            }
            else
            {
                timer1.Start();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Zoeken();
        }

        private void Zoeken()
        {
            bunifuCustomDataGrid1.Rows.Clear();
            klantenZoeken.Clear();

            if (txtNummerZoeken.Text != string.Empty)
            {
                foreach (Klant klant in klantenList)
                {
                    if (klant.Nummer == Convert.ToInt32(txtNummerZoeken.Text))
                    {
                        klantenZoeken.Add(klant);
                        foreach (Klant klant1 in klantenZoeken)
                        {
                            bunifuCustomDataGrid1.Rows.Add(
                                new object[]
                                {
                        klant1.ID,
                        klant1.Nummer,
                        klant1.Naam,
                        klant1.Adres,
                        klant1.Gemeente,
                        klant1.Postcode,
                        klant1.Gsm,
                        klant1.Telefoon,
                        klant1.Email,
                        klant1.Fax,
                        klant1.Btw,
                        klant1.BuitenlandseBtw

                                }

                                );
                        }
                    }
                }
            }
            if (txtNaamZoeken.Text != string.Empty)
            {
                foreach (Klant klant in klantenList)
                {
                    if (klant.Naam.ToLower().Contains(txtNaamZoeken.Text.ToLower()) || klant.Naam.Contains(txtNaamZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }
            if (txtAdresZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenAdres = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Adres.Contains(txtAdresZoeken.Text) || klant.Adres.Contains(txtAdresZoeken.Text.ToUpper()))
                    {
                        klantenzoekenAdres.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenAdres.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenList)
                {
                    if (klant.Adres.Contains(txtAdresZoeken.Text) || klant.Adres.Contains(txtAdresZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }

            if (cboPostcodeZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenPostcode = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Postcode.Contains(cboPostcodeZoeken.Text) || klant.Postcode.Contains(cboPostcodeZoeken.Text.ToUpper()))
                    {
                        klantenzoekenPostcode.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenPostcode.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Postcode.Contains(cboPostcodeZoeken.Text) || klant.Postcode.Contains(cboPostcodeZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }

            if (CboGemeenteZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenFilter = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Gemeente.Contains(CboGemeenteZoeken.Text) || klant.Gemeente.Contains(CboGemeenteZoeken.Text.ToUpper()))
                    {
                        klantenzoekenFilter.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenFilter.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Gemeente.Contains(CboGemeenteZoeken.Text) || klant.Gemeente.Contains(CboGemeenteZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }

            if (txtGsmZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenFilter = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Gsm.Contains(txtGsmZoeken.Text) || klant.Gsm.Contains(txtGsmZoeken.Text.ToUpper()))
                    {
                        klantenzoekenFilter.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenFilter.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Gsm.Contains(txtGsmZoeken.Text) || klant.Gsm.Contains(txtGsmZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }

            if (txtTelefoonZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenFilter = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Telefoon.Contains(txtTelefoonZoeken.Text) || klant.Telefoon.Contains(txtTelefoonZoeken.Text.ToUpper()))
                    {
                        klantenzoekenFilter.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenFilter.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Telefoon.Contains(txtTelefoonZoeken.Text) || klant.Telefoon.Contains(txtTelefoonZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }
            if (txtEmailZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenFilter = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Email.Contains(txtEmailZoeken.Text) || klant.Email.Contains(txtEmailZoeken.Text.ToUpper()))
                    {
                        klantenzoekenFilter.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenFilter.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Email.Contains(txtEmailZoeken.Text) || klant.Email.Contains(txtEmailZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }
            if (txtBTWZoeken.Text != string.Empty && klantenZoeken.Count > 0)
            {
                List<Klant> klantenzoekenFilter = new List<Klant>();
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Btw.Contains(txtBTWZoeken.Text) || klant.Btw.Contains(txtBTWZoeken.Text.ToUpper()))
                    {
                        klantenzoekenFilter.Add(klant);
                    }
                }
                klantenZoeken.Clear();
                klantenZoeken.AddRange(klantenzoekenFilter.ToArray());
            }
            else if (klantenZoeken.Count == 0)
            {
                foreach (Klant klant in klantenZoeken)
                {
                    if (klant.Btw.Contains(txtBTWZoeken.Text) || klant.Btw.Contains(txtBTWZoeken.Text.ToUpper()))
                    {
                        klantenZoeken.Add(klant);
                    }
                }
            }
            bunifuCustomDataGrid1.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            foreach (Klant klant in klantenZoeken)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        klant.ID,
                        klant.Nummer,
                        klant.Naam,
                        klant.Adres,
                        klant.Gemeente,
                        klant.Postcode,
                        klant.Gsm,
                        klant.Telefoon,
                        klant.Email,
                        klant.Fax,
                        klant.Btw,
                        klant.BuitenlandseBtw

                    }

                    );
            }
            vScrollBar1.Enabled = false;
        }

        private void ucToevoegenKlant_Load(object sender, EventArgs e)
        {
            
            //       dataGridViewKlantenlijst.Columns["ID"].Visible = false;

         
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            if (e.ColumnIndex == 0)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.White;

            }
        
        }

        private void bunifuCustomDataGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = bunifuCustomDataGrid1.FirstDisplayedScrollingRowIndex;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < bunifuCustomDataGrid1.Rows.Count)
            {
                bunifuCustomDataGrid1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            gemeentelijst = PostcodeGemeente.KrijgAllePostcodeGemeentes();
         klantenList = Klant.KrijgAlleKlanten();
            foreach (Klant klant in klantenList)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        klant.ID,
                        klant.Nummer,
                        klant.Naam,
                        klant.Adres,
                        klant.Gemeente,
                        klant.Postcode,
                        klant.Gsm,
                        klant.Telefoon,
                        klant.Email,
                        klant.Fax,
                        klant.Btw,
                        klant.BuitenlandseBtw

                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = bunifuCustomDataGrid1.RowCount;
            vScrollBar1.Maximum = max;
            Cursor.Current = Cursors.AppStarting;
            Klant klantenNummer = Klant.krijgLaatsteKlant();
            txtNummerNieuw.Text = (klantenNummer.Nummer + 1).ToString();

            Cursor.Current = Cursors.WaitCursor; ;


            foreach (PostcodeGemeente postcodeGemeente in gemeentelijst)
            {
                CboGemeenteZoeken.Properties.Items.Add(postcodeGemeente);
                CboGemeenteNieuw.Properties.Items.Add(postcodeGemeente);
            }

            foreach (PostcodeGemeente posstcodeLijst in gemeentelijst)
            {
                cboPostcodeZoeken.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
                cboPostcodeNieuw.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
            }
    
            timer1.Stop();
        }

        private void txtNaamZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void txtAdresZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void cboPostcodeZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void CboGemeenteZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void txtGsmZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void txtTelefoonZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void txtEmailZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void txtBTWZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void txtNummerZoeken_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Zoeken();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string textbtw = "";
            if (txtBtwNieuw.Text != string.Empty)
            {
                textbtw = cboBtwLand.Text + txtBtwNieuw.Text;
            }
            Klant klant = new Klant(txtNaamNieuw.Text, Convert.ToInt32(txtNummerNieuw.Text), txtAdresNieuw.Text, cboPostcodeNieuw.Text, CboGemeenteNieuw.Text, txtTelefoonNieuw.Text, txtFaxNieuw.Text, txtGSMNieuw.Text, txtEmailNieuw.Text, textbtw, "","Groen");
            klant.maakNieuweKlant();
            klantenNummer = Convert.ToInt32(txtNummerNieuw.Text);
            klantenNummer++;
            //Klant.updateNieuwKlantenNummer(klantenNummer++);
            this.Name = klant.Naam;
            Logboek logboek = new Logboek(DateTime.Now, "KLANTEN", "[NIEUWE KLANT TOEGEVOEGD] Klant: " + klant.Naam + " Adres: " + klant.Adres + " Gemeente: " + klant.Gemeente + " Postcode: " + klant.Postcode, USER);
            logboek.MaakNieuwLogBoekPunt();
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER,versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }

        }

        private void bunifuCustomDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);

            }
        }

        private void bunifuCustomDataGrid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.bunifuCustomDataGrid1.ClearSelection();
                    this.bunifuCustomDataGrid1.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
            Klant klant = new Klant();
            klant.ID = Convert.ToInt32(DGV[0].Value);
            klant.Nummer = Convert.ToInt32(DGV[1].Value);
            klant.Naam = DGV[2].Value.ToString();
            klant.Adres = DGV[3].Value.ToString();
            klant.Gemeente = DGV[4].Value.ToString();
            klant.Postcode = DGV[5].Value.ToString();
            klant.Gsm = DGV[6].Value.ToString();
            klant.Telefoon = DGV[7].Value.ToString();
            klant.Email = DGV[8].Value.ToString();
            klant.Fax = DGV[9].Value.ToString();
            klant.Btw = DGV[10].Value.ToString();
            klant.BuitenlandseBtw = DGV[11].Value.ToString();
            var message = "Bent u zeker dat u deze klant wilt verwijderen?";
            var title = "Keuze - verwijderen klant";
            var result = XtraMessageBox.Show(
                message,                  // the message to show
                title,                    // the title for the dialog box
                MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                MessageBoxIcon.Question); // show a question mark icon

            // the following can be handled as if/else statements as well
            switch (result)
            {
                case DialogResult.Yes:

                    int index = klantenList.FindIndex(a => a.ID.ToString().Contains(klant.ID.ToString()));
                    klantenList.RemoveAt(index);
                    klant.VerwijderenKlant();
                    bunifuCustomDataGrid1.Rows.Clear();

                    List<Klant> klantenList1 = Klant.KrijgAlleKlanten();
                    foreach (Klant klant1 in klantenList1)
                    {
                        bunifuCustomDataGrid1.Rows.Add(
                            new object[]
                            {
                        klant1.ID,
                        klant1.Nummer,
                        klant1.Naam,
                        klant1.Adres,
                        klant1.Gemeente,
                        klant1.Postcode,
                        klant1.Gsm,
                        klant1.Telefoon,
                        klant1.Email,
                        klant1.Fax,
                        klant1.Btw,
                        klant1.BuitenlandseBtw

                            }

                            );
                    }

                    break;
                case DialogResult.No:    // No button pressed

                    break;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void bunifuCustomDataGrid1_DoubleClick(object sender, EventArgs e)
        {
            Klant klant = new Klant(); ;
            try 
            {
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
                klant = Klant.KrijgKlantViaKlantenNummer(Convert.ToInt32(DGV[1].Value));

            }
            catch { }

            FrmDetailBedrijf frmDetailBedrijf = new FrmDetailBedrijf(klant);
            frmDetailBedrijf.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int lengteStringBTW = txtBtwNieuw.Text.Length;
            string btwnr = txtBtwNieuw.Text;
            var charsToRemove = new string[] { " ", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                btwnr = btwnr.Replace(c, string.Empty);
            }

            var info = EuropeanVatInformation.Get(cboBtwLand.Text + btwnr);
            string btwnrOld = btwnr;
            string btwnrNew = btwnrOld.Insert(4, ".");
            string btwnrNew1 = btwnrNew.Insert(8, ".");
            txtNaamNieuw.Text = info.Name;
            txtAdresNieuw.Text = info.Address;
            #region straat

            string straat = info.Address;
            if (straat.Contains("("))
            {
                straat = info.Address.Remove(straat.IndexOf("("), 3);
            }

            string gemeente = string.Empty;
            string postcode = string.Empty;
            List<PostcodeGemeente> postcodeGemeentes = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            foreach (PostcodeGemeente postcodeGemeente in postcodeGemeentes)
            {
                if (info.Address.Contains(postcodeGemeente.Postcode))
                {
                    postcode = postcodeGemeente.Postcode;
                    gemeente = postcodeGemeente.Gemeente;
                }
            }
            CboGemeenteNieuw.Text = gemeente;
            cboPostcodeNieuw.Text = postcode;
            int indexstraatberekenen = straat.IndexOf(postcode);
            straat = straat.Remove(indexstraatberekenen);
            // straat = straat.Replace(postcode, string.Empty);
            txtAdresNieuw.Text = straat;
            txtBtwNieuw.Text = btwnrNew1;
            #endregion
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
            Klant klant = Klant.KrijgKlantViaKlantenNummer(Convert.ToInt32(DGV[1].Value));

            string btwZonderBE = klant.Btw.Replace("BE", "");
            var charsToRemove = new string[] { " ", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                btwZonderBE = btwZonderBE.Replace(c, string.Empty);
            }
            if (btwZonderBE[0] != '0')
            {
                btwZonderBE = "0" + btwZonderBE;
            }
            System.Diagnostics.Process.Start("https://www.companyweb.be/company/" + btwZonderBE);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
            Klant klant = Klant.KrijgKlantViaKlantenNummer(Convert.ToInt32(DGV[1].Value));
            System.Diagnostics.Process.Start("firefox.exe", "tel:" + klant.Gsm);
        }
    }
}
