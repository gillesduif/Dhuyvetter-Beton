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

namespace DhuyvetterBeton.Beton.Kortingen
{
    public partial class FrmNieuweKortingProduct : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmNieuweKortingProduct()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmNieuweKortingProduct_Load(object sender, EventArgs e)
        {
            List<Klant> klantenlist = Klant.KrijgAlleKlanten();
            List<OmschrijvingProduct> omschrijvingProductenList = OmschrijvingProduct.KrijgAlleOmschrijvingen();
            List<Formule> formuleList = Formule.KrijgAlleFormules();
            klantenlist.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            cboKlanten.Items.AddRange(klantenlist.ToArray());
            cboProductOmschrijving.Items.AddRange(omschrijvingProductenList.ToArray());
            cboformules.Items.AddRange(formuleList.ToArray());
        }

        private void cboProductOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboformules.SelectedIndex = cboformules.FindString(((OmschrijvingProduct)cboProductOmschrijving.SelectedItem).Formule);
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void cboProductOmschrijving_KeyDown(object sender, KeyEventArgs e)
        {
            cboProductOmschrijving.DroppedDown = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Korting_Product korting_Product = new Korting_Product(((Klant)cboKlanten.SelectedItem), ((Formule)cboformules.SelectedItem), Convert.ToDouble(txtBedrag.Text));
            korting_Product.maakNieuweKorting();
            this.Close();
        }
    }
}
