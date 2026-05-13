using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace DhuyvetterBeton.Beton.Facturen
{
    public partial class FrmWijzigFactuur : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmWijzigFactuur()
        {
            InitializeComponent();
        }

        private void dateTimePickerPeriodiek_ValueChanged(object sender, EventArgs e)
        {
            cboKlanten.Items.Clear();
            Cursor.Current = Cursors.WaitCursor;
            List<Factuur> factuurLijst = Factuur.KrijgAlleFacturenVanDatum(dateTimePickerPeriodiek.Value.Date);
            List<Klant> klantenLijst = new List<Klant>();
            foreach (Factuur factuur1 in factuurLijst)
            {
                if (klantenLijst.Exists(x => x.Naam == factuur1.Klant.Naam)) { }
                else{ klantenLijst.Add(factuur1.Klant); }
            }
            cboKlanten.Items.AddRange(klantenLijst.ToArray());
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKlanten.SelectedItem != null)
            {
                cboFactuur.Items.Clear();
                List<Factuur> FacturenVanKlant = Factuur.KrijgAlleFacturenVanKlantEnDatum(((Klant)cboKlanten.SelectedItem).ID, dateTimePickerPeriodiek.Value.Date);
                cboFactuur.Items.AddRange(FacturenVanKlant.ToArray());
            }
        }

        private void cboFactuur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFactuur.SelectedItem != null)
            {
                Factuur factuur = ((Factuur)cboFactuur.SelectedItem);
                txtFactuurNummer.Text = factuur.FactuurNummer;
                dateTimePickerFactuurDatum.Value = factuur.Datum;
                txtExclBTW.Text = factuur.TotaalExclBtw.ToString();
                txtVerlegdBTW.Text = factuur.TotaalVerlegd.ToString();
                txt6BTW.Text = factuur.TotaalIncl6Btw.ToString();
                txt21BTW.Text = factuur.TotaalIncl21Btw.ToString();
                txtTotaal.Text = factuur.Totaal.ToString();
                labelID.Text = factuur.ID.ToString();
                List<Factuur_Item> factuur_Items = Factuur_Item.krijgAlleFactuurItemsDoorFactuurID(factuur.ID);
                dataGridViewFactuurItems.DataSource = factuur_Items;
            }
          
        }

        private void simpleButtonWijzigenFactuurHoofd_Click(object sender, EventArgs e)
        {
            Factuur factuur = new Factuur();
            factuur.ID = Convert.ToInt32(labelID.Text);
            factuur.FactuurNummer = txtFactuurNummer.Text;
            factuur.Klant = ((Klant)cboKlanten.SelectedItem);
            factuur.Datum = dateTimePickerFactuurDatum.Value.Date;
            factuur.TotaalExclBtw = Convert.ToDouble(txtExclBTW.Text);
            factuur.TotaalVerlegd = Convert.ToDouble(txtVerlegdBTW.Text);
            factuur.TotaalIncl6Btw = Convert.ToDouble(txt6BTW.Text);
            factuur.TotaalIncl21Btw = Convert.ToDouble(txt21BTW.Text);
            factuur.Totaal = Convert.ToDouble(txtTotaal.Text);
            factuur.wijzigFactuur();

            cboFactuur.Items.Clear();
            List<Factuur> FacturenVanKlant = Factuur.KrijgAlleFacturenVanKlantEnDatum(((Klant)cboKlanten.SelectedItem).ID, dateTimePickerPeriodiek.Value.Date);
            cboFactuur.Items.AddRange(FacturenVanKlant.ToArray());

            txtFactuurNummer.Text = string.Empty;
            dateTimePickerFactuurDatum.Value = DateTime.Today;
            txtExclBTW.Text = string.Empty;
            txtVerlegdBTW.Text = string.Empty;
            txt6BTW.Text = string.Empty;
            txt21BTW.Text = string.Empty;
            txtTotaal.Text = string.Empty;
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void simpleButtonWijzigenFactuurItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nog te coderen","",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
