using BL;
using DevExpress.XtraBars;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.PrijsLijst
{
    public partial class FrmPrijsBeheer : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmPrijsBeheer()
        {
            InitializeComponent();
        }
        List<OmschrijvingProduct> omschrijvingLijst = OmschrijvingProduct.KrijgAlleOmschrijvingen();
        List<BL.PrijsLijst> prijslijsten = BL.PrijsLijst.KrijgAlleOmschrijvingen();

        private void FrmNieuwePrijs_Load(object sender, EventArgs e)
        {
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");

            prijslijsten.Sort((X, Y) => X.Formule.CompareTo(Y.Formule));
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            //    dataGridView1.DataSource = prijslijsten;
            foreach (BL.PrijsLijst bestelling1 in prijslijsten)
            {
                dataGridViewBestellingen.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Formule,
                        bestelling1.Aannemer,
                        bestelling1.Particulier
                    }

                    );
            }
            dataGridViewBestellingen.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");

            int counter = 0;
            foreach (BL.PrijsLijst prijslijstitem in prijslijsten)
            {
                if(prijslijstitem.Particulier == 0 && prijslijstitem.Aannemer == 0)
                {
                    dataGridViewBestellingen.Rows[counter].DefaultCellStyle.BackColor = Color.Coral;
                    counter++;
                }
                else
                {
                    counter++;
                }
            }
        }

        private void listBoxProductenPrijs_Click(object sender, EventArgs e)
        {

        }

        private void listBoxProductenPrijs_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           // prijslijsten.Clear();

            if (txtAannemer.Text.Contains("."))
            {
                string m3value = txtAannemer.Text;
                string m3updated = m3value.Replace(".", ",");
                txtAannemer.Text = m3updated;
            }
            if (txtParticulier.Text.Contains("."))
            {
                string m3value1 = txtParticulier.Text;
                string m3updated1 = m3value1.Replace(".", ",");
                txtParticulier.Text = m3updated1;
            }
            double particulierprijs = Convert.ToDouble(txtAannemer.Text) + 4;
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
          
            BL.PrijsLijst prijslijst = new BL.PrijsLijst();
            prijslijst.ID = Convert.ToInt32(DGV[0].Value);
            prijslijst.Formule = txtPrNaam.Text;
            prijslijst.Aannemer = Convert.ToDouble(txtAannemer.Text);
            prijslijst.Particulier = particulierprijs;
            prijslijst.Aanpassen();
            prijslijsten = BL.PrijsLijst.KrijgAlleOmschrijvingen();
            dataGridViewBestellingen.Rows.Clear();
            foreach (BL.PrijsLijst bestelling1 in prijslijsten)
            {
                dataGridViewBestellingen.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Formule,
                        bestelling1.Aannemer,
                        bestelling1.Particulier
                    }

                    );
            }
            txtAannemer.Text = string.Empty;
            txtParticulier.Text = string.Empty;
            txtPrNaam.Text = string.Empty;
        }

        private void txtParticulier_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        //    if (listBoxProductenPrijs.SelectedItem != null)
        //    {
        //        foreach (OmschrijvingProduct omschrijvingProduct in omschrijvingLijst)
        //        {
        //            if (omschrijvingProduct.Formule == ((BL.PrijsLijst)listBoxProductenPrijs.SelectedItem).Formule)
        //            {
        //                txtPrNaam.Text = omschrijvingProduct.Omschrijving;
        //            }
        //        }

        //        txtAannemer.Text = ((BL.PrijsLijst)listBoxProductenPrijs.SelectedItem).Aannemer.ToString();
        //        txtParticulier.Text = ((BL.PrijsLijst)listBoxProductenPrijs.SelectedItem).Particulier.ToString();
        //    }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridViewBestellingen_SelectionChanged(object sender, EventArgs e)
        {
            int count = dataGridViewBestellingen.SelectedCells.Count;
            if (count == 4)
            {
                DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
                BL.PrijsLijst prijsLijst = new BL.PrijsLijst(Convert.ToInt32(DGV[0].Value), DGV[1].Value.ToString(), Convert.ToDouble(DGV[2].Value), Convert.ToDouble(DGV[3].Value));
                foreach (OmschrijvingProduct omschrijvingProduct in omschrijvingLijst)
                {
                    if (omschrijvingProduct.Formule == prijsLijst.Formule)
                    {
                        txtPrNaam.Text = omschrijvingProduct.Omschrijving;
                        txtAannemer.Text = prijsLijst.Aannemer.ToString();
                        txtParticulier.Text = prijsLijst.Particulier.ToString();
                    }
                }

            }
        }

        private void dataGridViewBestellingen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewBestellingen.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewBestellingen.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
