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
    public partial class ucFactuurWijzigen : DevExpress.XtraEditors.XtraUserControl
    {
        List<Klant> klanten = BL.Klant.KrijgAlleKlanten();
        List<Factuur> afgekeurdeFacturen = Factuur.KrijgAlleAfgekeurdeFacturen();
        public ucFactuurWijzigen()
        {
            InitializeComponent();
            ListboxAfgekeurdeFacturen.Items.AddRange(afgekeurdeFacturen.ToArray());
            cboKlanten.Properties.Items.AddRange(klanten.ToArray());
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            ListboxFacturen.Items.Clear();
            List<Factuur> facturen = Factuur.KrijgAlleFacturenVanKlant(((BL.Klant)cboKlanten.SelectedItem).ID);
            ListboxFacturen.Items.AddRange(facturen.ToArray());
        }

        private void ListboxFacturen_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewFactuurItems.Rows.Clear();
            Cursor.Current = Cursors.AppStarting;
            List<Factuur_Item> factuur_Items = Factuur_Item.krijgAlleFactuurItemsDoorFactuurID(((Factuur)ListboxFacturen.SelectedItem).ID);
            foreach (Factuur_Item factuur_Item in factuur_Items)
            {
                dataGridViewFactuurItems.Rows.Add(
                   new object[]
                   {
                        factuur_Item.ID,
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

        private void dataGridViewFactuurItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewFactuurItems.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewFactuurItems.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewFactuurItems.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewFactuurItems.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void dataGridViewFactuurItems_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewHulpstoffenFactuurItems.Rows.Clear();
                DataGridViewSelectedCellCollection DGV = this.dataGridViewFactuurItems.SelectedCells;
                int factuurItemID = Convert.ToInt32(DGV[0].Value);
                Factuur_Item factuurItem = Factuur_Item.KrijgDoorItemID(factuurItemID);
                #region invullen pomp
                txtGepompteM3.Text = factuurItem.GepompteM3.ToString();
                txtEenheidPompPrijs.Text = factuurItem.PompSuplimentEenheidsPrijs.ToString();
                txtPompPrijs.Text = factuurItem.PompPrijs.ToString();
                txtWachttijd.Text = factuurItem.PompWachtTijd.ToString();
                txtPompTotaal.Text = factuurItem.PompTotaalSuplimentPrijs.ToString();
                #endregion

                #region invullen transport
                txtTransport.Text = factuurItem.TransportTotaal.ToString();
                txtLaadEnLostijden.Text = factuurItem.LaadEnLosTijdenTotaal.ToString();
                txtOnvolledigeLading.Text = factuurItem.Onvolledige_Lading_Hoeveelheid.ToString();
                #endregion

                #region invullen product
                txtHoeveelProduct.Text = factuurItem.HoeveelheidProduct.ToString();
                txtEenheidsprijsProduct.Text = factuurItem.EenheidsPrijs.ToString();
                txtProductPrijs.Text = factuurItem.ProductPrijs.ToString();
                #endregion
                List<Hulpstof_Factuur_Item> HulpstoffenInFactuurItems = Hulpstof_Factuur_Item.krijgAlleHulpstoffenPerFactuurItem(factuurItemID);
                foreach (Hulpstof_Factuur_Item hulpstof_Factuur_Item in HulpstoffenInFactuurItems)
                {
                    dataGridViewHulpstoffenFactuurItems.Rows.Add(
                        new object[]
                        {
                        hulpstof_Factuur_Item.ID,
                        hulpstof_Factuur_Item.Hulpstof,
                        hulpstof_Factuur_Item.EenheidsPrijsHulpstof,
                        hulpstof_Factuur_Item.TotaalPrijsHulpstof
                        }
                     );
                }
            }
          catch { }
        }

        private void dataGridViewHulpstoffenFactuurItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewHulpstoffenFactuurItems.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewHulpstoffenFactuurItems.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewHulpstoffenFactuurItems.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewHulpstoffenFactuurItems.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void ListboxAfgekeurdeFacturen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
