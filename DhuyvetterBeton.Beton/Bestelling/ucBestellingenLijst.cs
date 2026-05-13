using BL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Bestelling
{
    public partial class ucBestellingenLijst : DevExpress.XtraEditors.XtraUserControl
    {
        Klant klant = new Klant();
        List<Klant> klanten = Klant.KrijgAlleKlanten();
        public ucBestellingenLijst()
        {
            InitializeComponent();
            listBoxControl1.Items.AddRange(klanten.ToArray());
            dtp1.DateTime = DateTime.Now.AddDays(-31);
            dtp2.DateTime = DateTime.Now;
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            if (textEdit1.Text != string.Empty)
            {
                listBoxControl1.Visible = true;
            }
            else { listBoxControl1.Visible = false; }
        }

        private void dateNavigator1_DateTimeChanged(object sender, EventArgs e)
        {
            if(listBoxControl1.SelectedItem != null)
            {

            }else 
            {
              XtraMessageBox.Show("Klant niet gevonden", "Gelieve een klant te selecteren.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text.Count() > 1)
            {
                List<Klant> klantenfilter = new List<Klant>();
                string zoekKlant = textEdit1.Text.ToLower().Replace(" ", "");
                foreach (Klant klant in klanten)
                {
                    string klantNaam = klant.Naam.ToLower().Replace(" ", "");
                    if (klantNaam.Contains(zoekKlant))
                    {
                        klantenfilter.Add(klant);
                    }
                }
                klantenfilter.Sort((x, y) => x.Naam.CompareTo(y.Naam));
                listBoxControl1.Items.Clear();
                listBoxControl1.Items.AddRange(klantenfilter.ToArray());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatumEnKlant(klant.ID, dtp1.DateTime , dtp2.DateTime);
            int counter = 0;
            foreach (BL.Bestelling bestelling in bestellingen)
            {
                bunifuCustomDataGridBeton.Rows.Add(
                   new object[]
                   {
                        bestelling.ID,
                        bestelling.Datum.ToShortDateString(),
                        bestelling.Klant,
                        bestelling.Werf,
                        bestelling.Formule,
                        bestelling.Pomp,
                        bestelling.Giek,
                        bestelling.M3,
                        bestelling.Besteldatum,
                        bestelling.Levering,
                        bestelling.LeveringWijze,
                        bestelling.Loswijze,
                        bestelling.Comment
                   }

                   );
                bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                counter++;
            }
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(listBoxControl1.SelectedItem != null)
                {
                    klant = ((Klant)listBoxControl1.SelectedItem);
                    textEdit1.Text = klant.Naam;
                    listBoxControl1.Visible = false;
                }
             
            }
            catch
            {
                listBoxControl1.Visible = false;
            }
        }

        private void bunifuCustomDataGridBeton_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGridBeton.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
       
            bunifuCustomDataGridBeton.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGridBeton.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void bunifuCustomDataGridBeton_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Clear();
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;

            Klant klant1 = (((Klant)DGV[2].Value));
            Werf werf1 = ((Werf)DGV[3].Value);
            Formule formule1 = ((Formule)DGV[4].Value);
            DateTime datum = Convert.ToDateTime(DGV[1].Value);


            List<NormaleLeveringBon> normaleLeveringBons = NormaleLeveringBon.KrijgBestellingenDoorDatumEnKlantEnProductEnWerf(datum, datum.Date.AddDays(+1), klant1.ID, formule1.ID, werf1.ID);


            foreach(NormaleLeveringBon normaleLeveringBon in normaleLeveringBons)
            {
                bunifuCustomDataGrid1.Rows.Add(
                 new object[]
                 {
                        normaleLeveringBon.ID,
                        normaleLeveringBon.Klant,
                        normaleLeveringBon.Werf,
                        normaleLeveringBon.Voertuig,
                        normaleLeveringBon.Chauffeur,
                        normaleLeveringBon.Formule,
                        normaleLeveringBon.Pomp,
                        normaleLeveringBon.Giek,
                        normaleLeveringBon.M3,
                        normaleLeveringBon.Datum.ToShortDateString() + " " + normaleLeveringBon.Datum.ToShortTimeString(),
                        normaleLeveringBon.Levering,
                        normaleLeveringBon.Leveringwijze,
                        normaleLeveringBon.Loswijze,
                        normaleLeveringBon.Opmerking
                 }

                 );
            }
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
