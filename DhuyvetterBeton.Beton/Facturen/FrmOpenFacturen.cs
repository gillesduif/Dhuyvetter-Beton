using BL;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Facturen
{
    public partial class FrmOpenFacturen : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
       
        public FrmOpenFacturen()
        {
        
            InitializeComponent();
        }
        private void releaseObject(object obj)

        {

            try

            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;

            }

            catch (Exception ex)

            {

                obj = null;

                MessageBox.Show("Unable to release the Object " + ex.ToString());

            }

            finally

            {

                GC.Collect();

            }
            
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            if (lbxFacturen.SelectedItem != null)
            {
                Cursor.Current = Cursors.AppStarting;
                string locatie = ((Factuur)lbxFacturen.SelectedItem).FactuurNummer + " " + ((Factuur)lbxFacturen.SelectedItem).Klant.Naam;
                string bestandsnaam = @"Z:\\Facturatie\" + (((Factuur)lbxFacturen.SelectedItem).Datum.ToString("dd MMMM yyyy") + @"\" + locatie + ".xlsx");
         
                //documentViewer1.DocumentSource = bestandsnaam;
                try
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbooks books = excelApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook sheets = books.Open(bestandsnaam);
                }
                catch
                {
                    MessageBox.Show("Bestand niet gevonden.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmOverzichtFacturen_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
            klantenLijst.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            cboKlanten.Properties.Items.AddRange(klantenLijst.ToArray());
          
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Factuur factuur = Factuur.KrijgFactuurViaFactuurNummer(txtAfdeling.Text + txtFactuurnummer.Text);
                lbxFacturen.Items.Add(factuur);
                cboKlanten.Text = factuur.Klant.Naam;
            }
           catch
            {
                MessageBox.Show("Geen factuur gevonden.", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void cboKlanten_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            lbxFacturen.Items.Clear();
            int klantID = ((Klant)cboKlanten.SelectedItem).ID;
            List<Factuur> FacturenVanKlant = Factuur.KrijgAlleFacturenVanKlant(klantID);
            lbxFacturen.Items.AddRange(FacturenVanKlant.ToArray());
        }
    }
}
