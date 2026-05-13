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
    public partial class ucWijzigPrefabBestelling : DevExpress.XtraEditors.XtraUserControl
    {
        string user;
        string versie;
        FrmHoofdVenster frmhoofd;
        BestellingPrefab bestellingPrefab = new BestellingPrefab();
        public ucWijzigPrefabBestelling(FrmHoofdVenster frmhoofd1, string User, string versie1)
        {
            frmhoofd = frmhoofd1;
            InitializeComponent();
            dateTimePicker1.EditValue = DateTime.Today;
            user = User;
            versie = versie1;
            timer1.Start();
            bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
        }

        private void dateTimePicker1_DateTimeChanged(object sender, EventArgs e)
        {
        
            
           
        }

        private void dateTimePicker1_SelectionChanged(object sender, EventArgs e)
        {
            cboPrefabKlant.Text = string.Empty;
            cboWerfPrefab.Text = string.Empty;
            cboLeveringWijze.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtLangsteElement.Text = string.Empty;
            txtLot.Text = string.Empty;
            txtM3.Text = string.Empty;
            txtAantalStuks.Text = string.Empty;
            bunifuCustomDataGrid1.Rows.Clear();
            List<BestellingPrefab> bestellingPrefabs = BestellingPrefab.KrijgAlleBestellingenDoorDatum(dateTimePicker1.SelectionStart.Date, dateTimePicker1.SelectionStart.Date.AddDays(+1));
            foreach (BestellingPrefab prefabBestelling in bestellingPrefabs)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        prefabBestelling.ID,
                        prefabBestelling.KlantPrefab,
                        prefabBestelling.WerfPrefab,
                        prefabBestelling.Datum,
                        prefabBestelling.Levering,
                        prefabBestelling.Opmerking
                    }

                    );
            }

          
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cboWerfPrefab.Properties.Items.Clear();
                listBoxProducten.Items.Clear();
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;

                bestellingPrefab = new BestellingPrefab(Convert.ToInt32((DGV[0].Value)), ((KlantPrefab)DGV[1].Value), ((WerfPrefab)DGV[2].Value), null, ((DateTime)DGV[3].Value), DGV[4].Value.ToString(), DGV[5].Value.ToString());
                List<WerfPrefab> WervenPrefab = WerfPrefab.KrijgAlleWervenVanPrefab(bestellingPrefab.KlantPrefab.ID);

                txtLangsteElement.Text = string.Empty;
                txtLot.Text = string.Empty;
                txtM3.Text = string.Empty;
                txtAantalStuks.Text = string.Empty;

                int index = 0;
                foreach (KlantPrefab klantPrefab in cboPrefabKlant.Properties.Items)
                {
                    if (klantPrefab.Naam == bestellingPrefab.KlantPrefab.Naam)
                    {
                        cboPrefabKlant.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
                List<ProductPrefab> producten = ProductPrefab.KrijgProductenVoorBestelling(bestellingPrefab.ID);
                listBoxProducten.Items.AddRange(producten.ToArray());
                cboWerfPrefab.Properties.Items.AddRange(WervenPrefab.ToArray());

                Cursor.Current = Cursors.AppStarting;

                int index1 = 0;
                foreach (WerfPrefab WerfPrefab in cboWerfPrefab.Properties.Items)
                {
                    if (WerfPrefab.ToString() == bestellingPrefab.WerfPrefab.ToString())
                    {
                        cboWerfPrefab.SelectedIndex = index1;
                        break;
                    }
                    index1++;
                }
                
                cboLeveringWijze.Text = bestellingPrefab.Levering;
                txtComment.Text = bestellingPrefab.Opmerking;
                dtpDatum.EditValue = bestellingPrefab.Datum;
            }
            catch
            {

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<KlantPrefab> klantenLijst = KlantPrefab.KrijgAllePrefabKlanten();
            cboPrefabKlant.Properties.Items.AddRange(klantenLijst.ToArray());
            timer1.Stop();
        }

        private void listBoxProducten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProducten.SelectedItem != null)
            {
                ProductPrefab productPrefab = ((ProductPrefab)listBoxProducten.SelectedItem);
                txtLangsteElement.Text = productPrefab.LangsteElement;
                txtLot.Text = productPrefab.Lot;
                txtM3.Text = productPrefab.M3;
                txtAantalStuks.Text = productPrefab.Aantalstuks;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ProductPrefab product = new ProductPrefab(((ProductPrefab)listBoxProducten.SelectedItem).ID, txtLot.Text, txtAantalStuks.Text, txtLangsteElement.Text, txtM3.Text, ((ProductPrefab)listBoxProducten.SelectedItem).PrefabBestellingID);
            product.Wijzigen();
            listBoxProducten.Items.Clear();
            List<ProductPrefab> producten = ProductPrefab.KrijgProductenVoorBestelling(bestellingPrefab.ID);
            listBoxProducten.Items.AddRange(producten.ToArray());

            txtLot.Text = string.Empty; txtAantalStuks.Text = string.Empty; txtLangsteElement.Text = string.Empty; txtM3.Text = string.Empty;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<ProductPrefab> producten = new List<ProductPrefab>();
            foreach (ProductPrefab productPrefab in listBoxProducten.Items)
            {
                producten.Add(productPrefab);
            }

            BestellingPrefab bestellingPrefab1 = new BestellingPrefab(bestellingPrefab.ID, ((KlantPrefab)cboPrefabKlant.SelectedItem), ((WerfPrefab)cboWerfPrefab.SelectedItem), producten, Convert.ToDateTime(dtpDatum.EditValue), cboLeveringWijze.Text, txtComment.Text);
            bestellingPrefab1.WijzigBestelling();
            bestellingPrefab1.GeneerExcellRec(user);

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
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(user, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(user, versie, null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }
    }
}
