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

namespace DhuyvetterBeton.Beton.Offertes
{
    public partial class FrmWijzigOfferte : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmWijzigOfferte()
        {
            InitializeComponent();
        }

        private void GroupOfferteKlant_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmWijzigOfferte_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
            klantenLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            cboKlanten.Items.AddRange(klantenLijst.ToArray());
            List<OmschrijvingProduct> productOmschrijvingen = OmschrijvingProduct.KrijgAlleOmschrijvingen();
            List<Formule> FormuleLijst = Formule.KrijgAlleFormules();
            cboFormules.Items.AddRange(FormuleLijst.ToArray());
            productOmschrijvingen.Sort((x, y) => x.Omschrijving.CompareTo(y.Omschrijving));
            cboProduct.Items.AddRange(productOmschrijvingen.ToArray());
            splashScreenManager1.CloseWaitForm();
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            cboKlanten.SelectedItem = null;
            labelTitel.Text = "Wijzig offerte van klant";
            cboWerf.Text = string.Empty;
            cboProduct.Text = string.Empty;
            cboWerf.Enabled = false;
            cboProduct.Enabled = false;
            txtOnvolledigelading.Text = string.Empty;
            txtTransport.Text = string.Empty;
            txtPrijs.Text = string.Empty;
            txtOpmerking.Text = string.Empty;
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {
            cboKlanten.SelectedItem = null;
            cboWerf.Text = string.Empty;
            cboProduct.Text = string.Empty;
            labelTitel.Text = "Wijzig offerte voor werf";
            cboWerf.Enabled = true;
            cboProduct.Enabled = false;
            txtOnvolledigelading.Text = string.Empty;
            txtTransport.Text = string.Empty;
            txtPrijs.Text = string.Empty;
            txtOpmerking.Text = string.Empty;
        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {
            cboKlanten.SelectedItem = null;
            labelTitel.Text = "Wijzig offerte voor product";
            cboWerf.Text = string.Empty;
            cboProduct.Text = string.Empty;
            cboProduct.Enabled = true;
            txtOnvolledigelading.Text = string.Empty;
            txtTransport.Text = string.Empty;
            txtPrijs.Text = string.Empty;
            txtOpmerking.Text = string.Empty;
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
            cboKlanten.SelectedItem = null;
            labelTitel.Text = "Wijzig offerte voor product en werf";
            cboWerf.Text = string.Empty;
            cboProduct.Text = string.Empty;
            cboWerf.Enabled = true;
            cboProduct.Enabled = true;
            txtOnvolledigelading.Text = string.Empty;
            txtTransport.Text = string.Empty;
            txtPrijs.Text = string.Empty;
            txtOpmerking.Text = string.Empty;
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxOffertes.Items.Clear();
            try
            {
                List<Werf> wervenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                wervenLijst.Sort((x, y) => x.Adres.CompareTo(y.Adres));
                cboWerf.Items.AddRange(wervenLijst.ToArray());
            }
            catch
            {

            }
            
            if (labelTitel.Text == "Wijzig offerte van klant")
            {
                try
                {
                    List<OfferteKlant> offerteVanKlantLijst = OfferteKlant.KrijgAlleOffertesDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxOffertes.Items.AddRange(offerteVanKlantLijst.ToArray());
                }
               catch
                {

                }
            }
            else if (labelTitel.Text == "Wijzig offerte voor werf")
            {
                try
                {
                    List<OfferteWerf> offerteVanWervenKlantLijst = OfferteWerf.KrijgAlleOffertesDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxOffertes.Items.AddRange(offerteVanWervenKlantLijst.ToArray());
                }
                catch
                {

                } 
            }
            else if (labelTitel.Text == "Wijzig offerte voor product")
            {
                try
                {
                    List<OfferteProduct> OfferteProductLijst = OfferteProduct.KrijgAlleOffertesDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxOffertes.Items.AddRange(OfferteProductLijst.ToArray());
                }
                catch
                {

                }
            }
            else if (labelTitel.Text == "Wijzig offerte voor product en werf")
            {
                try
                {
                    List<OfferteWerfProduct> offerteVanWervenKlantLijst = OfferteWerfProduct.KrijgAlleOffertesDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxOffertes.Items.AddRange(offerteVanWervenKlantLijst.ToArray());
                }
                catch
                {

                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (labelTitel.Text == "Wijzig offerte van klant")
            {
                OfferteKlant offerteKlant = new OfferteKlant(((OfferteKlant)listBoxOffertes.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), Convert.ToDouble(txtTransport.Text), Convert.ToDouble(txtOnvolledigelading.Text), Convert.ToDouble(txtPrijs.Text), txtOpmerking.Text);
                offerteKlant.WijzigOfferte();
            }
            else if (labelTitel.Text == "Wijzig offerte voor werf")
            {
                OfferteWerf offerteWerf = new OfferteWerf(((OfferteWerf)listBoxOffertes.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), ((Werf)cboWerf.SelectedItem), Convert.ToDouble(txtTransport.Text), Convert.ToDouble(txtOnvolledigelading.Text), Convert.ToDouble(txtPrijs.Text), txtOpmerking.Text);
                offerteWerf.WijzigOfferte();
            }
            else if (labelTitel.Text == "Wijzig offerte voor product")
            {
                OfferteProduct offerteProduct = new OfferteProduct(((OfferteProduct)listBoxOffertes.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), ((OmschrijvingProduct)cboProduct.SelectedItem), Convert.ToDouble(txtTransport.Text), Convert.ToDouble(txtOnvolledigelading.Text), Convert.ToDouble(txtPrijs.Text), txtOpmerking.Text);
                offerteProduct.WijzigOfferte();
            }
            else if (labelTitel.Text == "Wijzig offerte voor product en werf")
            {
                OfferteWerfProduct offerteWerfProduct = new OfferteWerfProduct(((OfferteWerfProduct)listBoxOffertes.SelectedItem).ID,((Klant)cboKlanten.SelectedItem), ((Werf)cboWerf.SelectedItem), ((OmschrijvingProduct)cboProduct.SelectedItem), Convert.ToDouble(txtTransport.Text), Convert.ToDouble(txtOnvolledigelading.Text), Convert.ToDouble(txtPrijs.Text), txtOpmerking.Text);
                offerteWerfProduct.WijzigOfferte();
            }
            this.Close();
        }

        private void listBoxOffertes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOffertes.SelectedItem != null)
            {
                if (labelTitel.Text == "Wijzig offerte van klant")
                {
                    txtOnvolledigelading.Text = ((OfferteKlant)listBoxOffertes.SelectedItem).OnvolledigeLading.ToString();
                    txtTransport.Text = ((OfferteKlant)listBoxOffertes.SelectedItem).Transport.ToString();
                    txtPrijs.Text = ((OfferteKlant)listBoxOffertes.SelectedItem).Bedrag.ToString();
                    txtOpmerking.Text = ((OfferteKlant)listBoxOffertes.SelectedItem).Opmerking;
                }
                else if(labelTitel.Text == "Wijzig offerte voor werf")
                {
                    txtOnvolledigelading.Text = ((OfferteWerf)listBoxOffertes.SelectedItem).OnvolledigeLading.ToString();
                    cboWerf.SelectedIndex = cboWerf.FindString(((OfferteWerf)listBoxOffertes.SelectedItem).Werf.ToString());
                    txtTransport.Text = ((OfferteWerf)listBoxOffertes.SelectedItem).Transport.ToString();
                    txtPrijs.Text = ((OfferteWerf)listBoxOffertes.SelectedItem).Bedrag.ToString();
                    txtOpmerking.Text = ((OfferteWerf)listBoxOffertes.SelectedItem).Opmerking;
                }
                else if (labelTitel.Text == "Wijzig offerte voor product")
                {
                    txtOnvolledigelading.Text = ((OfferteProduct)listBoxOffertes.SelectedItem).OnvolledigeLading.ToString();
                    cboProduct.SelectedIndex = cboProduct.FindString(((OfferteProduct)listBoxOffertes.SelectedItem).Product.ToString());
                    txtTransport.Text = ((OfferteProduct)listBoxOffertes.SelectedItem).Transport.ToString();
                    txtPrijs.Text = ((OfferteProduct)listBoxOffertes.SelectedItem).Bedrag.ToString();
                    txtOpmerking.Text = ((OfferteProduct)listBoxOffertes.SelectedItem).Opmerking;
                }
                else if (labelTitel.Text == "Wijzig offerte voor product en werf")
                {
                    txtOnvolledigelading.Text = ((OfferteWerfProduct)listBoxOffertes.SelectedItem).OnvolledigeLading.ToString();
                    cboProduct.SelectedIndex = cboProduct.FindString(((OfferteWerfProduct)listBoxOffertes.SelectedItem).Product.ToString());
                    cboWerf.SelectedIndex = cboWerf.FindString(((OfferteWerfProduct)listBoxOffertes.SelectedItem).Werf.ToString());
                    txtTransport.Text = ((OfferteWerfProduct)listBoxOffertes.SelectedItem).Transport.ToString();
                    txtPrijs.Text = ((OfferteWerfProduct)listBoxOffertes.SelectedItem).Bedrag.ToString();
                    txtOpmerking.Text = ((OfferteWerfProduct)listBoxOffertes.SelectedItem).Opmerking;
                }
            }
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }
    }
}
