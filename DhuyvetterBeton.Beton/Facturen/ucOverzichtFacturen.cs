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

namespace DhuyvetterBeton.Beton.Facturen
{
    public partial class ucOverzichtFacturen : DevExpress.XtraEditors.XtraUserControl
    {
        List<Factuur> facturenLijst;
        public ucOverzichtFacturen(string user, FrmHoofdVenster frmHoofd1, string versie1, bool controleJan)
        {
            InitializeComponent();
            dtpDatum.EditValue = DateTime.Today;
            Factuur laatsteFactuur = Factuur.KrijgLaatsteFactuur();
            List<Klant> Klanten = BL.Klant.KrijgAlleKlanten();
            cboKlanten.Properties.Items.AddRange(Klanten.ToArray());
           
            if (controleJan != true)
            {
                facturenLijst = Factuur.KrijgAlleFacturenVanDatum(laatsteFactuur.Datum);
                foreach (Factuur factuur in facturenLijst)
                {
                    string totaalVerlegd = "€" + factuur.TotaalVerlegd.ToString();
                    string totaalIncl6BTW = "€" + factuur.TotaalIncl6Btw.ToString();
                    string totaalIncl21BTW = "€" + factuur.TotaalIncl21Btw.ToString();
                    if (factuur.TotaalVerlegd == 0)
                    {
                        totaalVerlegd = "";
                    }
                    if (factuur.TotaalIncl6Btw == 0)
                    {
                        totaalIncl6BTW = "";
                    }
                    if (factuur.TotaalIncl21Btw == 0)
                    {
                        totaalIncl21BTW = "";
                    }
                    dataGridViewFacturen.Rows.Add(
                             new object[]
                             {
                           factuur.ID,
                           factuur.FactuurNummer,
                           factuur.Klant,
                           factuur.Datum.ToShortDateString(),
                           totaalVerlegd,
                           totaalIncl6BTW,
                           totaalIncl21BTW,
                       //    factuur.TotaalExclBtw,
                           "€" + factuur.Totaal
                             }
                    );


                }
            }
            else
            {
                facturenLijst = Factuur.KrijgTeControlerenFacturen();
                foreach (Factuur factuur in facturenLijst)
                {
                    string totaalVerlegd = "€" + factuur.TotaalVerlegd.ToString();
                    string totaalIncl6BTW = "€" + factuur.TotaalIncl6Btw.ToString();
                    string totaalIncl21BTW = "€" + factuur.TotaalIncl21Btw.ToString();
                    if (factuur.TotaalVerlegd == 0)
                    {
                        totaalVerlegd = "";
                    }
                    if (factuur.TotaalIncl6Btw == 0)
                    {
                        totaalIncl6BTW = "";
                    }
                    if (factuur.TotaalIncl21Btw == 0)
                    {
                        totaalIncl21BTW = "";
                    }
                    dataGridViewFacturen.Rows.Add(
                             new object[]
                             {
                           factuur.ID,
                           factuur.FactuurNummer,
                           factuur.Klant,
                           factuur.Datum.ToShortDateString(),
                           totaalVerlegd,
                           totaalIncl6BTW,
                           totaalIncl21BTW,
                       //    factuur.TotaalExclBtw,
                           "€" + factuur.Totaal
                             }
                    );


                }
            }
           
            FactuurItemsInladen();
            if(controleJan == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                int counter = 0;
                foreach (BL.Factuur factuur in facturenLijst)
                {
                    if (factuur.Controle == 1)
                    {
                        dataGridViewFacturen.Rows[counter].DefaultCellStyle.BackColor = Color.DarkGreen;
                        counter++;
                    }
                    else if (factuur.Controle == 2)
                    {
                        dataGridViewFacturen.Rows[counter].DefaultCellStyle.BackColor = Color.DarkOrange;
                        counter++;
                    }
                    else if (factuur.Controle == 3)
                    {
                        dataGridViewFacturen.Rows[counter].DefaultCellStyle.BackColor = Color.DarkRed;
                        counter++;
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridViewFacturen.Rows.Clear();
            if (txtNummerZoeken.Text != "BL")
            {
                Factuur factuur = Factuur.KrijgFactuurViaFactuurNummer(txtNummerZoeken.Text);
                
                string totaalVerlegd = "€" + factuur.TotaalVerlegd.ToString();
                string totaalIncl6BTW = "€" + factuur.TotaalIncl6Btw.ToString();
                string totaalIncl21BTW = "€" + factuur.TotaalIncl21Btw.ToString();
                if (factuur.TotaalVerlegd == 0)
                {
                    totaalVerlegd = "";
                }
                if (factuur.TotaalIncl6Btw == 0)
                {
                    totaalIncl6BTW = "";
                }
                if (factuur.TotaalIncl21Btw == 0)
                {
                    totaalIncl21BTW = "";
                }
                dataGridViewFacturen.Rows.Add(
                       new object[]
                       {
                           factuur.ID,
                           factuur.FactuurNummer,
                           factuur.Klant,
                           factuur.Datum.ToShortDateString(),
                           totaalVerlegd,
                           totaalIncl6BTW,
                           totaalIncl21BTW,
                       //    factuur.TotaalExclBtw,
                           "€" + factuur.Totaal
                       }
              );
            }
            else if (cboKlanten.Text != string.Empty)
            {
                Klant klant = ((Klant)cboKlanten.SelectedItem);
                List<Factuur> facturenVanKlant = Factuur.KrijgAlleFacturenVanKlant(klant.ID);
                foreach(Factuur factuur in facturenVanKlant)
                {
                    string totaalVerlegd = "€" + factuur.TotaalVerlegd.ToString();
                    string totaalIncl6BTW = "€" + factuur.TotaalIncl6Btw.ToString();
                    string totaalIncl21BTW = "€" + factuur.TotaalIncl21Btw.ToString();
                    if (factuur.TotaalVerlegd == 0)
                    {
                        totaalVerlegd = "";
                    }
                    if (factuur.TotaalIncl6Btw == 0)
                    {
                        totaalIncl6BTW = "";
                    }
                    if (factuur.TotaalIncl21Btw == 0)
                    {
                        totaalIncl21BTW = "";
                    }
                    dataGridViewFacturen.Rows.Add(
                           new object[]
                           {
                           factuur.ID,
                           factuur.FactuurNummer,
                           factuur.Klant,
                           factuur.Datum.ToShortDateString(),
                           totaalVerlegd,
                           totaalIncl6BTW,
                           totaalIncl21BTW,
                       //    factuur.TotaalExclBtw,
                           "€" + factuur.Totaal
                           }
                  );
                }
            }   
            else if(dtpDatum.Enabled == true)
            {
                List<Factuur> FacturenPerPeriode = Factuur.KrijgAlleFacturenVanDatum(dtpDatum.DateTime.Date);
                foreach (Factuur factuur in FacturenPerPeriode)
                {
                    string totaalVerlegd = "€" + factuur.TotaalVerlegd.ToString();
                    string totaalIncl6BTW = "€" + factuur.TotaalIncl6Btw.ToString();
                    string totaalIncl21BTW = "€" + factuur.TotaalIncl21Btw.ToString();
                    if (factuur.TotaalVerlegd == 0)
                    {
                        totaalVerlegd = "";
                    }
                    if (factuur.TotaalIncl6Btw == 0)
                    {
                        totaalIncl6BTW = "";
                    }
                    if (factuur.TotaalIncl21Btw == 0)
                    {
                        totaalIncl21BTW = "";
                    }
                    dataGridViewFacturen.Rows.Add(
                           new object[]
                           {
                           factuur.ID,
                           factuur.FactuurNummer,
                           factuur.Klant,
                           factuur.Datum.ToShortDateString(),
                           totaalVerlegd,
                           totaalIncl6BTW,
                           totaalIncl21BTW,
                       //    factuur.TotaalExclBtw,
                           "€" + factuur.Totaal
                           }
                  );
                }
            }
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (dtpDatum.Enabled == false)
            {
                dtpDatum.Enabled = true;
            }
            else
            {
                dtpDatum.Enabled = false;
            }
           
        }

        private void dataGridViewFacturen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewFacturen.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewFacturen.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewFacturen.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewFacturen.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            if (e.ColumnIndex == 0)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.White;

            }
            if (e.ColumnIndex == 7)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

            }
        }

        private void txtNummerZoeken_TextChanged(object sender, EventArgs e)
        {
            if(txtNummerZoeken.Text == string.Empty)
            {
                txtNummerZoeken.Text = "BL";
            }
        }

        private void dataGridViewFacturen_DoubleClick(object sender, EventArgs e)
        {

        }
        private void FactuurItemsInladen()
        {
            Cursor.Current = Cursors.AppStarting;
            dataGridViewFactuurItems.Rows.Clear();
            DataGridViewSelectedCellCollection DGV = this.dataGridViewFacturen.SelectedCells;

            int factuurID = Convert.ToInt32(DGV[0].Value);
            List<Factuur_Item> factuur_Items = Factuur_Item.krijgAlleFactuurItemsDoorFactuurID(factuurID);
            foreach (Factuur_Item factuur_Item in factuur_Items)
            {
                dataGridViewFactuurItems.Rows.Add(
                     new object[]
                     {

                        factuur_Item.Werf,
                        factuur_Item.BestelDatum.ToShortDateString(),
                        factuur_Item.OmschrijvingProduct,
                        factuur_Item.PompPrijs,
                        factuur_Item.PompSuplimentEenheidsPrijs,
                        factuur_Item.PompTotaalSuplimentPrijs,
                        factuur_Item.PompWachtTijd,
                        factuur_Item.GepompteM3,
                        factuur_Item.Onvolledige_Lading_Hoeveelheid,
                        factuur_Item.Onvolledige_Lading_Prijs,
                        factuur_Item.TransportTotaal,
                        factuur_Item.LaadEnLosTijdenTotaal,
                        factuur_Item.EenheidsPrijs,
                        factuur_Item.HoeveelheidProduct,
                        factuur_Item.ProductPrijs,
                        factuur_Item.Subtotaal
                     }

                     );
            }
        }
        private void dataGridViewFacturen_Click(object sender, EventArgs e)
        {
            FactuurItemsInladen();
        }

        private void dataGridViewFactuurItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewFactuurItems.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewFactuurItems.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewFactuurItems.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewFactuurItems.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void ucOverzichtFacturen_Load(object sender, EventArgs e)
        {

        }
    }
}
