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
namespace DhuyvetterBeton.Beton.Werven
{
    public partial class ucWerven : DevExpress.XtraEditors.XtraUserControl
    {
        string user;
        FrmHoofdVenster frmhoofd;
        string versie;
        Klant klant;
        Werf werf;
        List<Klant> klantenZoeken = new List<Klant>();
        List<Klant> klantenList;
        List<Werf> wervenVanKlant = new List<Werf>();
        public ucWerven(string User, FrmHoofdVenster frmhoofd1,string versie1)
        {
            user = User;
            frmhoofd = frmhoofd1;
            versie = versie1;
            InitializeComponent();
            timer1.Start();
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            bunifuCustomDataGrid2.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
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
            timer1.Stop();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < bunifuCustomDataGrid1.Rows.Count)
            {
                bunifuCustomDataGrid1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void bunifuCustomDataGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = bunifuCustomDataGrid1.FirstDisplayedScrollingRowIndex;
        }

        private void bunifuCustomDataGrid2_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar2.Value = bunifuCustomDataGrid2.FirstDisplayedScrollingRowIndex;
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < bunifuCustomDataGrid2.Rows.Count)
            {
                bunifuCustomDataGrid2.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.Rows.Clear();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
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
                wervenVanKlant.Clear();
                wervenVanKlant = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
                foreach (Werf werf in wervenVanKlant)
                {
                    bunifuCustomDataGrid2.Rows.Add(
                        new object[]
                        {
                        werf.ID,
                        werf.Klant,
                        werf.Adres,
                        werf.Gemeente,
                        werf.Postcode,
                        werf.Telefoon
                     

                        }

                        );
                }
                if(wervenVanKlant.Count >= 20)
                {
   vScrollBar2.Minimum = 0;
                int max = bunifuCustomDataGrid2.RowCount;
                vScrollBar2.Maximum = max;
                }
                else
                {
                    vScrollBar2.Enabled = false;
                }
             
            }
            catch { }
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void bunifuCustomDataGrid2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGrid2.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid2.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGrid2.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid2.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
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
                    if (klant.Naam.Contains(txtNaamZoeken.Text) || klant.Naam.Contains(txtNaamZoeken.Text.ToUpper()))
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
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Zoeken();
        }

        private void bunifuCustomDataGrid2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid2.SelectedCells;
                werf = new Werf();
                werf.ID = Convert.ToInt32(DGV[0].Value);
                werf.Adres = DGV[2].Value.ToString();
                werf.Gemeente = DGV[3].Value.ToString();
                werf.Postcode = DGV[4].Value.ToString();
                werf.Telefoon = DGV[5].Value.ToString();
                txtAdresWijzigen.Text = werf.Adres;
                txtGemeenteWijzigen.Text = werf.Gemeente;
                txtPostcodeWijzigen.Text = werf.Postcode;
                txtTelefoonWijzigen.Text = werf.Telefoon;
            }
            catch
            {
                txtAdresWijzigen.Text = string.Empty;
                txtGemeenteWijzigen.Text = string.Empty;
                txtPostcodeWijzigen.Text = string.Empty;
                txtTelefoonWijzigen.Text = string.Empty;
            }
        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void LeegMaken()
        {

            if (txtNummerZoeken.Text == string.Empty && txtNaamZoeken.Text == string.Empty && txtAdresZoeken.Text == string.Empty && cboPostcodeZoeken.Text == string.Empty && CboGemeenteZoeken.Text == string.Empty && txtGsmZoeken.Text == string.Empty && txtTelefoonZoeken.Text == string.Empty && txtEmailZoeken.Text == string.Empty && txtBTWZoeken.Text == string.Empty)
            {
                Cursor.Current = Cursors.WaitCursor;
                bunifuCustomDataGrid1.Rows.Clear();
                klantenZoeken.Clear();
                List<Klant> klantenList1 = Klant.KrijgAlleKlanten();
                foreach (Klant klant in klantenList1)
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
                vScrollBar1.Enabled = true;
            }

        }

        private void txtNummerZoeken_TextChanged(object sender, EventArgs e)
        {
            LeegMaken();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (klant != null)
            {
                txtAdresToevoegen.Text = klant.Adres;
                txtPostcodeToevoegen.Text = klant.Postcode;
                txtGemeenteToevoegen.Text = klant.Gemeente;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Werf werf = new Werf(klant, txtAdresToevoegen.Text, txtGemeenteToevoegen.Text, txtPostcodeToevoegen.Text, txtTelefoonToevoegen.Text);
            werf.maakNieuweWerf();
            Logboek logboek = new Logboek(DateTime.Now, "WERVEN", "[NIEUWE WERF TOEGEVOEGD] Klant: " + werf.Klant.Naam + " Adres: " + werf.Adres + " Gemeente: " + werf.Gemeente + " Postcode: " + werf.Postcode, user);
            logboek.MaakNieuwLogBoekPunt();
            bunifuCustomDataGrid2.Rows.Clear();
            wervenVanKlant.Add(werf);

            foreach (Werf werf1 in wervenVanKlant)
            {
                bunifuCustomDataGrid2.Rows.Add(
                    new object[]
                    {
                        werf1.ID,
                        werf1.Klant,
                        werf1.Adres,
                        werf1.Gemeente,
                        werf1.Postcode,
                        werf1.Telefoon
                    }

                    );
            }
            if (wervenVanKlant.Count >= 20)
            {
                vScrollBar2.Minimum = 0;
                int max = bunifuCustomDataGrid2.RowCount;
                vScrollBar2.Maximum = max;
            }
            else
            {
                vScrollBar2.Enabled = false;
            }
            txtAdresToevoegen.Text = string.Empty;
            txtPostcodeToevoegen.Text = string.Empty;
            txtGemeenteToevoegen.Text = string.Empty;
            txtTelefoonToevoegen.Text = string.Empty;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            Werf werf2 = new Werf(werf.ID, klant, txtAdresWijzigen.Text, txtGemeenteWijzigen.Text, txtPostcodeWijzigen.Text, txtTelefoonWijzigen.Text);
            werf2.UpdateWerftGegevens();
            Logboek logboek = new Logboek(DateTime.Now, "WERVEN", "[NIEUWE WERF TOEGEVOEGD] Klant: " + werf2.Klant.Naam + " Adres: " + werf2.Adres + " Gemeente: " + werf2.Gemeente + " Postcode: " + werf2.Postcode, user);
            logboek.MaakNieuwLogBoekPunt();
            bunifuCustomDataGrid2.Rows.Clear();
            wervenVanKlant.Clear();
            Cursor.Current = Cursors.WaitCursor;
            wervenVanKlant = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
            foreach (Werf werf1 in wervenVanKlant)
            {
                bunifuCustomDataGrid2.Rows.Add(
                    new object[]
                    {
                        werf1.ID,
                        werf1.Klant,
                        werf1.Adres,
                        werf1.Gemeente,
                        werf1.Postcode,
                        werf1.Telefoon
                    }

                    );
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucHoofdvenster ucHoofdvenster = new ucHoofdvenster(user, versie, null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }
    }
}
