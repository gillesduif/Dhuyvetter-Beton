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
    public partial class FrmNieuweKortingProductWerf : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmNieuweKortingProductWerf()
        {
            InitializeComponent();
            List<Klant> klantenlist = Klant.KrijgAlleKlanten();

            cboKlanten.Items.AddRange(klantenlist.ToArray());
            List<OmschrijvingProduct> omschrijvingProductenList = OmschrijvingProduct.KrijgAlleOmschrijvingen();
            List<Formule> formuleList = Formule.KrijgAlleFormules();
        
            cboProductOmschrijving.Items.AddRange(omschrijvingProductenList.ToArray());
            cboformules.Items.AddRange(formuleList.ToArray());
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void cboProductOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboformules.SelectedIndex = cboformules.FindStringExact(((OmschrijvingProduct)cboProductOmschrijving.SelectedItem).Formule);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Korting_Product_Werf korting_Product_Werf = new Korting_Product_Werf(((Klant)cboKlanten.SelectedItem),((Werf)cboWerven.SelectedItem), ((Formule)cboformules.SelectedItem), Convert.ToDouble(txtBedrag.Text));
            korting_Product_Werf.maakNieuweKorting();
            this.Close();
        }

        private void cboWerven_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Werf> wervenlist = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            cboWerven.Items.AddRange(wervenlist.ToArray());
        }
    }
}
