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
using System.Diagnostics;
using DhuyvetterBeton.Beton.Klanten.Tools;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using DhuyvetterBeton.Beton.alacarteservice;
using System.Globalization;

namespace DhuyvetterBeton.Beton.Klanten
{
    public partial class ucWijzigenKlant : DevExpress.XtraEditors.XtraUserControl
    {
        int klantIDSelection = 0;
        List<Klant> klantenList;
        List<Klant> klantenZoeken = new List<Klant>();
        List<PostcodeGemeente> postcodeGemeentes;
        Klant klant;
        string USER = string.Empty;
        string versie;
        FrmHoofdVenster frmhoofd;
        string afbeeldingZonderPNG;
        public ucWijzigenKlant(string user, FrmHoofdVenster frmhoofd1, string versie1, List<Klant> klantenLijst)
        {
            USER = user;
            versie = versie1;
            frmhoofd = frmhoofd1;
            postcodeGemeentes = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            InitializeComponent();
            if (klantenLijst.Count > 0)
            {
                klantenList = klantenLijst;
                int counter = 0;
                foreach (Klant klant in klantenList)
                {
                    KlantenDataGrid.Rows.Add(
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
                    if (klant.BetaalCode == "Rood")
                    {
                        KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else if (klant.BetaalCode == "Oranje")
                    {
                        KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = Color.DarkOrange;
                    }
                    else if (klant.BetaalCode == "Geel")
                    {
                        KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3BF00");
                    }
                    counter++;
                }
                vScrollBar1.Minimum = 0;
                int max = KlantenDataGrid.RowCount;
                vScrollBar1.Maximum = max;
                foreach (PostcodeGemeente postcodeGemeente in postcodeGemeentes)
                {
                    CboGemeenteZoeken.Properties.Items.Add(postcodeGemeente);
                    cboPostcodeZoeken.Properties.Items.Add(postcodeGemeente.Postcode);
                }
            }
            else
            {
                timer1.Start();
            }
          
            KlantenDataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            KlantenDataGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
      
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            KlantenDataGrid.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            KlantenDataGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            KlantenDataGrid.RowsDefaultCellStyle.ForeColor = Color.White;
            KlantenDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            if (e.ColumnIndex == 0)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.White;

            }

        }

        private void ucWijzigenKlant_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            klantenList = Klant.KrijgAlleKlanten();
             
            foreach (Klant klant in klantenList)
            {
                KlantenDataGrid.Rows.Add(
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

            foreach (PostcodeGemeente postcodeGemeente in postcodeGemeentes)
            {
                CboGemeenteZoeken.Properties.Items.Add(postcodeGemeente);
                cboPostcodeZoeken.Properties.Items.Add(postcodeGemeente.Postcode);
            }
            //  CboGemeenten.Items.AddRange(gemeentelijst.)

            vScrollBar1.Minimum = 0;
            int max = KlantenDataGrid.RowCount;
            vScrollBar1.Maximum = max;
            timer1.Stop();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < KlantenDataGrid.Rows.Count)
            {
                KlantenDataGrid.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void bunifuCustomDataGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = KlantenDataGrid.FirstDisplayedScrollingRowIndex;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Zoeken();
        }

        private void Zoeken()
        {
       
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
                            KlantenDataGrid.Rows.Add(
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
           
            Cursor.Current = Cursors.WaitCursor;
            if(klantenZoeken.Count == KlantenDataGrid.Rows.Count)
            {
                XtraMessageBox.Show("De zoekopdracht heeft geen resultaten.", "Zoeken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            KlantenDataGrid.Rows.Clear();
            int counter = 0;
            foreach (Klant klant in klantenZoeken)
            {
                KlantenDataGrid.Rows.Add(
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
                if (klant.BetaalCode == "Rood")
                {
                    KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else if (klant.BetaalCode == "Oranje")
                {
                    KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = Color.DarkOrange;
                }
                else if (klant.BetaalCode == "Geel")
                {
                    KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3BF00");
                }
                counter++;
            }
            vScrollBar1.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            klantIDSelection = KlantenDataGrid.CurrentCell.RowIndex;
        
            Klant klant2 = new Klant(klant.ID, txtNaamWijzigen.Text, klant.Nummer, txtAdresWijzigen.Text, txtPostcodeWijzigen.Text, txtGemeenteWijzigen.Text, txtTelefoonWijzigen.Text, txtFaxWijzigen.Text, txtGsmWijzigen.Text, txtEmailWijzigen.Text, txtBtwWijzigen.Text, "",cboBetaalCode.Text);
            klant2.UpdateKlantGegevens();
            txtAdresWijzigen.Text = string.Empty;
            txtBtwWijzigen.Text = string.Empty;
            txtBuitenlandseBtw.Text = string.Empty;
            txtGemeenteWijzigen.Text = string.Empty;
            txtFaxWijzigen.Text = string.Empty;
            txtGsmWijzigen.Text = string.Empty;
            txtNaamWijzigen.Text = string.Empty;
          
            txtTelefoonWijzigen.Text = string.Empty;
            txtEmailWijzigen.Text = string.Empty;
            txtPostcodeWijzigen.Text = string.Empty;
            KlantenDataGrid.Rows.Clear();
            //BINNENKORT
            //Int32 selectedRowCount = KlantenDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //if (selectedRowCount > 0)
            //{
            //    for (int i = 0; i < selectedRowCount; i++)
            //    {
            //        KlantenDataGrid.Rows.RemoveAt(KlantenDataGrid.SelectedRows[0].Index);
            //    }
            //}

            List<Klant> klantenList1 = Klant.KrijgAlleKlanten();
            klantenList = klantenList1;
            klantenList.Sort((x, y) => x.Naam.CompareTo(y.Naam));

            foreach (Klant klant in klantenList)
            {
                KlantenDataGrid.Rows.Add(
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
            int max = KlantenDataGrid.RowCount;
            vScrollBar1.Maximum = max;
            Logboek logboek = new Logboek(DateTime.Now, "KLANTEN", "[KLANT GEWIJZIGD] Klant: " + klant2.Naam + " Adres: " + klant2.Adres + " Gemeente: " + klant2.Gemeente + " Postcode: " + klant2.Postcode, USER);
            logboek.MaakNieuwLogBoekPunt();
            KlantenDataGrid.Rows[klantIDSelection].Selected = true;

            klantIDSelection = klantIDSelection - 15;
            for (int i = 0; i <= klantIDSelection; i++)
            {
                KlantenDataGrid.FirstDisplayedScrollingRowIndex = KlantenDataGrid.FirstDisplayedScrollingRowIndex + 1;
            }
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedCellCollection DGV = this.KlantenDataGrid.SelectedCells;
                klant = new Klant();
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

                txtAdresWijzigen.Text = klant.Adres;
                txtBtwWijzigen.Text = klant.Btw;
                txtBuitenlandseBtw.Text = klant.BuitenlandseBtw;
                txtGemeenteWijzigen.Text = klant.Gemeente;
                txtFaxWijzigen.Text = klant.Fax;
                txtGsmWijzigen.Text = klant.Gsm;
                txtNaamWijzigen.Text = klant.Naam;

                txtTelefoonWijzigen.Text = klant.Telefoon;
                txtEmailWijzigen.Text = klant.Email;
                txtPostcodeWijzigen.Text = klant.Postcode;
            }
            catch { }
            KlantenDataGrid.Rows[klantIDSelection].Selected = true;
        }
        private void LeegMaken()
        {
           
            if (txtNummer.Text == string.Empty && txtNaamZoeken.Text == string.Empty && txtAdresZoeken.Text == string.Empty && cboPostcodeZoeken.Text == string.Empty && CboGemeenteZoeken.Text == string.Empty && txtGsmZoeken.Text == string.Empty && txtTelefoonZoeken.Text == string.Empty && txtEmailZoeken.Text == string.Empty && txtBTWZoeken.Text == string.Empty)
            {
                    Cursor.Current = Cursors.WaitCursor;
                    KlantenDataGrid.Rows.Clear();
                    klantenZoeken.Clear();
                    List<Klant> klantenList1 = Klant.KrijgAlleKlanten();
                    foreach (Klant klant in klantenList1)
                    {
                        KlantenDataGrid.Rows.Add(
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
                vScrollBar1.Enabled = true;
            }

        }
        private void txtNaamWijzigen_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtNaamZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void txtAdresZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void cboPostcodeZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void CboGemeenteZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void txtGsmZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void txtTelefoonZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void txtEmailZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
        }

        private void txtBTWZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.KlantenDataGrid.SelectedCells;
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
                    KlantenDataGrid.Rows.Clear();

                    List<Klant> klantenList1 = Klant.KrijgAlleKlanten();
                    foreach (Klant klant1 in klantenList1)
                    {
                        KlantenDataGrid.Rows.Add(
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

        private void bunifuCustomDataGrid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.KlantenDataGrid.ClearSelection();
                    this.KlantenDataGrid.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void bunifuCustomDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);

            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER, versie, null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Lucas gij zijt een kloot ", "Pottie", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cboPostcodeZoeken_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void KlantenDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            KlantenDataGrid.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            KlantenDataGrid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            KlantenDataGrid.RowsDefaultCellStyle.ForeColor = Color.White;
            KlantenDataGrid.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            if (e.ColumnIndex == 0)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.White;

            }
            try
            {
             //   KlantenDataGrid.Rows[klantIDSelection].Selected = true;
            }
            catch
            {

            }
        }

        private void KlantenDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            labelKredietLimiet.Text = "";
            simpleButton3.Visible = true;
            pictureboxGezondheidsBaroMeter.Image = Properties.Resources.blanco;
            try
            {
                DataGridViewSelectedCellCollection DGV = this.KlantenDataGrid.SelectedCells;
                klant = Klant.KrijgKlantViaKlantenNummer(Convert.ToInt32(DGV[1].Value));
                txtAdresWijzigen.Text = klant.Adres;
                txtBtwWijzigen.Text = klant.Btw;
                txtBuitenlandseBtw.Text = klant.BuitenlandseBtw;
                txtGemeenteWijzigen.Text = klant.Gemeente;
                txtFaxWijzigen.Text = klant.Fax;
                txtGsmWijzigen.Text = klant.Gsm;
                txtNaamWijzigen.Text = klant.Naam;
                txtTelefoonWijzigen.Text = klant.Telefoon;
                txtEmailWijzigen.Text = klant.Email;
                txtPostcodeWijzigen.Text = klant.Postcode;
                cboBetaalCode.Text = klant.BetaalCode;
            }
            catch { }
            if (klant.Btw != string.Empty)
            {
                try
                {
                    krijgFinanciëleDataViaKlantBTW();
                }catch
                {

                }
            }
            else
            {
                labelMaatschappelijkeZetel.Text = string.Empty;
                labelJuridischeSituatie.Text = string.Empty;
                labelJuridischeVorm.Text = string.Empty;
                labelStartDatum.Text = string.Empty;
                labelBstatus.Text = string.Empty;
                labelBalansjaar.Text = string.Empty;
            }
        }
        private void krijgFinanciëleDataViaKlantBTW()
        {
            string btwZonderBE = klant.Btw.Replace("BE", "");
            Debug.WriteLine(btwZonderBE);

            var charsToRemove = new string[] { " ", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                btwZonderBE = btwZonderBE.Replace(c, string.Empty);
            }
            if (btwZonderBE[0] != '0')
            {
                btwZonderBE = "0" + btwZonderBE;
            }
            string btwnrOld = btwZonderBE;
            string btwnrNew = btwnrOld.Insert(4, ".");
            string btwnrNew1 = btwnrNew.Insert(8, ".");

            var url = "https://robofin.be/fiche/api.enterprise.php?a=EnterpriseData&VAT=" + btwnrNew1;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var bedrijfsData = JsonConvert.DeserializeObject<BedrijfsData>(result);


                //info 
          /*      labelMaatschappelijkeZetel.Text = bedrijfsData.Enterprise.Address.StreetNl + " " + bedrijfsData.Enterprise.Address.HouseNumber + " " + bedrijfsData.Enterprise.Address.MunicipalityNl + " " + bedrijfsData.Enterprise.Address.Zipcode.ToString();
                labelJuridischeSituatie.Text = bedrijfsData.Enterprise.JuridicalSituation;
                labelJuridischeVorm.Text = bedrijfsData.Enterprise.JuridicalForm;
                labelStartDatum.Text = bedrijfsData.Enterprise.StartDate.ToString();
                labelBstatus.Text = bedrijfsData.Enterprise.Status;
                labelBalansjaar.Text = bedrijfsData.Enterprise.FiscalYearEnd.Substring(0, 4);
                if (labelJuridischeSituatie.Text.Contains("faillissement")) { labelStatus.ForeColor = Color.Red; }
                else
                {
                    labelStatus.ForeColor = Color.LimeGreen;
                }
              */

            }
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kleurcode = "";
            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    kleurcode = "Groen";
                    break;
                case 1:
                    kleurcode = "Geel";
                    break;
                case 2:
                    kleurcode = "Oranje";
                    break;
                case 3:
                    kleurcode = "Rood";
                    break;
                default:

                    break;
            }
            Cursor.Current = Cursors.WaitCursor;
            List<Klant> klantKleurCode = Klant.krijgKlantenViaKleurCode(kleurcode);
            KlantenDataGrid.Rows.Clear();
            int counter = 0;
            foreach (Klant klant1 in klantKleurCode)
            {
                KlantenDataGrid.Rows.Add(
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
                if (klant.BetaalCode == "Rood")
                {
                    KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                }
                else if (klant.BetaalCode == "Oranje")
                {
                    KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = Color.DarkOrange;
                }
                else if (klant.BetaalCode == "Geel")
                {
                    KlantenDataGrid.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3BF00");
                }
                counter++;
            }

        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
         

        }

        private void KlantenDataGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedCellCollection DGV = this.KlantenDataGrid.SelectedCells;
                klant = Klant.KrijgKlantViaKlantenNummer(Convert.ToInt32(DGV[1].Value));

            }
            catch { }

            FrmDetailBedrijf frmDetailBedrijf = new FrmDetailBedrijf(klant);
            frmDetailBedrijf.Show();
        }

        private void KlantenDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);

            }
        }

        private void KlantenDataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.KlantenDataGrid.ClearSelection();
                    this.KlantenDataGrid.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.KlantenDataGrid.SelectedCells;
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            timerAnimatie.Start();
            Cursor.Current = Cursors.AppStarting;
            pictureboxGezondheidsBaroMeter.Image = Properties.Resources.zero;
            simpleButton3.Visible = false;
            string login = "dhuyvetterTEST";
            string password = "G6N8K5";
            string integratorSecret = "c0b65824-634e-4f8a-8d80-1fea19b1a8f5";
            var client = new AlacarteServiceV1_3Client();
            var response = client.GetCompanyByVat(
             new RequestCompanyByVat
             {
                 // Login of the customer
                 CompanyWebLogin = "dhuyvetterTEST",
                 // Password of the customer
                 CompanyWebPassword = "G6N8K5",
                 // Shorthand code of the integrator. This is provided by Companyweb.
                 ServiceIntegrator = "dhuyvetterbeton",
                 Language = "NL",
                 VatNumber = klant.Btw,

                 // A calculated hash. See CreateHash below for the implementation.
                 LoginHash = CreateHash(login, password, integratorSecret),

                 // Other parameters...
             }
         );
            Debug.WriteLine(response.StatusCode + " bericht: " + response.StatusMessage);
            Debug.WriteLine("Gezondheidsbarometer score: " + response.CompanyResponse.Score.Value.ScoreAsDecimal);
            string afbeelding = response.CompanyResponse.Score.Value.ScoreImage;
            string afbeeldingCorrect = afbeelding.Replace("-", "_");
            afbeeldingZonderPNG = afbeeldingCorrect.Replace(".png", "");
            pictureboxGezondheidsBaroMeter.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(afbeeldingZonderPNG);
            labelKredietLimiet.Text = response.CompanyResponse.CreditLimit.Value.Limit.ToString("C", CultureInfo.CurrentCulture);
        }
        string CreateHash(string login, string password, string integratorSecret)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                var clearText = (
                        DateTime.Today.Year.ToString() +
                        DateTime.Today.Month.ToString("00") +
                        DateTime.Today.Day.ToString("00") +
                        login +
                        password +
                        integratorSecret
                    ).ToLower();

                byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(clearText));
                var hash = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    hash.Append(data[i].ToString("x2"));
                }
                Debug.WriteLine(hash.ToString());
                return hash.ToString();
            }
        }
        int counter = 1;
        private void timerAnimatie_Tick(object sender, EventArgs e)
        {
            
           string getal = afbeeldingZonderPNG.Substring(afbeeldingZonderPNG.Length - 2);
            if (counter < 10)
            {
                if (getal == "0" + counter.ToString()) ;
            }
            
        }
    }
}
