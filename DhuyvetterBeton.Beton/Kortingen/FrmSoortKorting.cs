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
    public partial class FrmSoortKorting : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        List<OmschrijvingProduct> productOmschrijvingen = new List<OmschrijvingProduct>();
        List<Formule> formulelijst = new List<Formule>();

        public FrmSoortKorting()
        {
            InitializeComponent();
        }

        private void FrmSoortKorting_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Data ophalen
            formulelijst = Formule.KrijgAlleFormules();
            List<Klant> KlantenLijst = Klant.KrijgAlleKlanten();
            productOmschrijvingen = OmschrijvingProduct.KrijgAlleOmschrijvingen();
            //Sorteren
            KlantenLijst.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            productOmschrijvingen.Sort((X, Y) => X.Omschrijving.CompareTo(Y.Omschrijving));
            //invullen
            cboKlanten.Properties.Items.AddRange(KlantenLijst.ToArray());
            cboProductWijzigen.Properties.Items.AddRange(productOmschrijvingen.ToArray());
            cboProductOmschrijving.Properties.Items.AddRange(productOmschrijvingen.ToArray());
            cboformules.Items.AddRange(formulelijst.ToArray());
            cboFormulesWijzigen.Items.AddRange(formulelijst.ToArray());
            timer1.Stop();
        }

        private void cboSoortenKorting_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void listBoxKortingProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKortingProductWerf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKortingWerf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKortingProduct_Click(object sender, EventArgs e)
        {
          
        }
        private void listBoxKortingProductWerf_Click(object sender, EventArgs e)
        {
        
        }
        private void listBoxKortingWerf_Click(object sender, EventArgs e)
        {
         
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            switch (cboSoortenKorting.SelectedIndex)
            {
                case 0:
                    Korting_Product korting_Product = new Korting_Product(((Klant)cboKlanten.SelectedItem), ((Formule)cboformules.SelectedItem), Convert.ToDouble(txtNieuwBedrag.Text));
                    korting_Product.maakNieuweKorting();
                    listBoxKortingProduct.Items.Clear();
                    List<Korting_Product> korting_Products = Korting_Product.KrijgKortingProductDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxKortingProduct.Items.AddRange(korting_Products.ToArray());
                    cboProductOmschrijving.SelectedItem = null;
                    txtNieuwBedrag.Text = string.Empty;
                    cboProductOmschrijving.Enabled = false;
                    txtNieuwBedrag.Enabled = false;
                    cboSoortenKorting.SelectedItem = null;
                    listBoxKortingProduct.Items.Clear();
                    List<Korting_Product> ProductKortingen = Korting_Product.KrijgKortingProductDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxKortingProduct.Items.AddRange(ProductKortingen.ToArray());
                    break;
                case 1:
                    Korting_Product_Werf korting_Product_Werf = new Korting_Product_Werf(((Klant)cboKlanten.SelectedItem), ((Werf)cboWerven.SelectedItem), ((Formule)cboformules.SelectedItem), Convert.ToDouble(txtNieuwBedrag.Text));
                    korting_Product_Werf.maakNieuweKorting();
                    cboWerven.SelectedItem = null;
                    cboProductOmschrijving.SelectedItem = null;
                    txtNieuwBedrag.Text = string.Empty;
                    cboWerven.Enabled = false;
                    cboProductOmschrijving.Enabled = false;
                    txtNieuwBedrag.Enabled = false;
                    cboSoortenKorting.SelectedItem = null;
                    listBoxKortingProductWerf.Items.Clear();
                    List<Korting_Product_Werf> ProductwerfKortingen = Korting_Product_Werf.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxKortingProductWerf.Items.AddRange(ProductwerfKortingen.ToArray());
                    break;
                case 2:
                    Korting_Werf korting_Werf = new Korting_Werf(((Klant)cboKlanten.SelectedItem), ((Werf)cboWerven.SelectedItem), Convert.ToDouble(txtNieuwBedrag.Text));
                    korting_Werf.maakNieuweKortingWerf();
                    cboWerven.SelectedItem = null;
                    cboProductOmschrijving.SelectedItem = null;
                    txtNieuwBedrag.Text = string.Empty;
                    cboWerven.Enabled = false;
                    cboProductOmschrijving.Enabled = false;
                    txtNieuwBedrag.Enabled = false;
                    cboSoortenKorting.SelectedItem = null;
                    listBoxKortingWerf.Items.Clear();
                    List<Korting_Werf> werfKortingen = Korting_Werf.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxKortingWerf.Items.AddRange(werfKortingen.ToArray());
                    break;
                case 3:
                    Korting_Klant korting_Klant = new Korting_Klant(((Klant)cboKlanten.SelectedItem), Convert.ToDouble(txtNieuwBedrag.Text));
                    korting_Klant.maakNieuweKortingKlant();
                    cboWerven.SelectedItem = null;
                    cboProductOmschrijving.SelectedItem = null;
                    txtNieuwBedrag.Text = string.Empty;
                    cboWerven.Enabled = false;
                    cboProductOmschrijving.Enabled = false;
                    txtNieuwBedrag.Enabled = false;
                    cboSoortenKorting.SelectedItem = null;
                    listBoxKortingKlant.Items.Clear();
                    List<Korting_Klant> klantKortingen = Korting_Klant.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                    listBoxKortingKlant.Items.AddRange(klantKortingen.ToArray());
                    break;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (listBoxKortingProduct.SelectedItem != null)
            {
                Korting_Product korting_Product = new Korting_Product(((Korting_Product)listBoxKortingProduct.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), ((Formule)cboFormulesWijzigen.SelectedItem), Convert.ToDouble(txtBedragWijzigen.Text));
                korting_Product.WijzigKortingProduct();
                listBoxKortingProduct.Items.Clear();
                List<Korting_Product> ProductKortingen = Korting_Product.KrijgKortingProductDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                listBoxKortingProduct.Items.AddRange(ProductKortingen.ToArray());
                cboProductWijzigen.SelectedItem = null;
                txtBedragWijzigen.Text = string.Empty;
            }
            else if (listBoxKortingProductWerf.SelectedItem != null)
            {
                Korting_Product_Werf korting_Product_Werf = new Korting_Product_Werf(((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), ((Werf)cboWerfWijzigen.SelectedItem), ((Formule)cboFormulesWijzigen.SelectedItem), Convert.ToDouble(txtBedragWijzigen.Text));
                korting_Product_Werf.WijzigKortingWerfProduct();
                listBoxKortingProductWerf.Items.Clear();
                cboProductWijzigen.SelectedItem = null;
                cboWerfWijzigen.SelectedItem = null;
                txtBedragWijzigen.Text = string.Empty;
                List<Korting_Product_Werf> ProductwerfKortingen = Korting_Product_Werf.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                listBoxKortingProductWerf.Items.AddRange(ProductwerfKortingen.ToArray());

            }
            else if (listBoxKortingWerf.SelectedItem != null)
            {
                Korting_Werf korting_Werf = new Korting_Werf(((Korting_Werf)listBoxKortingWerf.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), ((Werf)cboWerfWijzigen.SelectedItem), Convert.ToDouble(txtBedragWijzigen.Text));
                korting_Werf.UpdateKortingWerf();
                listBoxKortingWerf.Items.Clear();
                List<Korting_Werf> werfKortingen = Korting_Werf.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                listBoxKortingWerf.Items.AddRange(werfKortingen.ToArray());
                cboWerfWijzigen.SelectedItem = null;
                txtBedragWijzigen.Text = string.Empty;
            }
            else if (listBoxKortingKlant.SelectedItem != null)
            {
                Korting_Klant korting_Klant = new Korting_Klant(((Korting_Klant)listBoxKortingKlant.SelectedItem).ID, ((Klant)cboKlanten.SelectedItem), Convert.ToDouble(txtBedragWijzigen.Text));
                korting_Klant.UpdateKlantKorting();
                listBoxKortingKlant.Items.Clear();
                List<Korting_Klant> klantKortingen = Korting_Klant.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                listBoxKortingKlant.Items.AddRange(klantKortingen.ToArray());
                txtBedragWijzigen.Text = string.Empty;
            }
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void cboProductOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Formule formule in formulelijst)
            {
                if (cboProductOmschrijving.SelectedItem != null)
                {
                    if (((OmschrijvingProduct)cboProductOmschrijving.SelectedItem).Formule == formule.Naam)
                    {
                        cboformules.SelectedIndex = cboformules.FindString(formule.ToString());
                    }
                    else { }
                }
            }
        }

        private void cboProductWijzigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboFormulesWijzigen.SelectedIndex = cboFormulesWijzigen.FindString(((OmschrijvingProduct)cboProductWijzigen.SelectedItem).Formule);
            }
            catch { }
        }

        private void listBoxKortingKlant_Click(object sender, EventArgs e)
        {
          
        }

        private void listBoxKortingWerf_Click_1(object sender, EventArgs e)
        {
         
        }

        private void listBoxKortingProductWerf_Click_1(object sender, EventArgs e)
        {
           
        }

        private void listBoxKortingProduct_Click_1(object sender, EventArgs e)
        {
           
        }

        private void cboKlanten_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            listBoxKortingKlant.Items.Clear();
            listBoxKortingProduct.Items.Clear();
            listBoxKortingProductWerf.Items.Clear();
            listBoxKortingWerf.Items.Clear();
            List<Werf> WervenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            cboWerven.Properties.Items.AddRange(WervenLijst.ToArray());
            cboWerfWijzigen.Properties.Items.AddRange(WervenLijst.ToArray());
            List<Korting_Product> ProductKortingen = Korting_Product.KrijgKortingProductDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            listBoxKortingProduct.Items.AddRange(ProductKortingen.ToArray());
            List<Korting_Werf> werfKortingen = Korting_Werf.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            listBoxKortingWerf.Items.AddRange(werfKortingen.ToArray());
            List<Korting_Product_Werf> ProductwerfKortingen = Korting_Product_Werf.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            listBoxKortingProductWerf.Items.AddRange(ProductwerfKortingen.ToArray());
            List<Korting_Klant> klantKortingen = Korting_Klant.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            listBoxKortingKlant.Items.AddRange(klantKortingen.ToArray());
        }

        private void listBoxKortingProductWerf_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBoxKortingProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxKortingProduct.SelectedItem != null)
            {
                labelWerfProductNaam.Text = "";
                labelProductWerfKortingNaam.Text = "";
                labelProductWerfKortingBedrag.Text = "";
                string productOmschrijving = "";
                foreach (OmschrijvingProduct omschrijvingProduct in productOmschrijvingen)
                {
                    if (omschrijvingProduct.Formule == ((Korting_Product)listBoxKortingProduct.SelectedItem).Formule.Naam)
                    {
                        productOmschrijving = omschrijvingProduct.Omschrijving;
                    }
                }

                labelOmschrijving.Text = "Product Korting : " + productOmschrijving + " €" + ((Korting_Product)listBoxKortingProduct.SelectedItem).Bedrag.ToString();
                labelProductKortingNaam.Text = productOmschrijving;
                labelProductKortingBedrag.Text = "€" + ((Korting_Product)listBoxKortingProduct.SelectedItem).Bedrag.ToString();
                listBoxKortingKlant.SelectedItem = null;
                listBoxKortingWerf.SelectedItem = null;
                listBoxKortingProductWerf.SelectedItem = null;

                if (listBoxKortingProduct.SelectedItem != null)
                {
                    cboProductWijzigen.Enabled = true;
                    txtBedragWijzigen.Enabled = true;
                    simpleButton2.Enabled = true;
                    foreach (OmschrijvingProduct omschrijvingProduct in productOmschrijvingen)
                    {
                        if (omschrijvingProduct.Formule == ((Korting_Product)listBoxKortingProduct.SelectedItem).Formule.Naam)
                        {
                            cboWerfWijzigen.SelectedItem = null;
                            cboWerfWijzigen.Enabled = false;
                            cboWerfWijzigen.Text = string.Empty;
                            productOmschrijving = omschrijvingProduct.Omschrijving;
                            int index = 0;
                            foreach (OmschrijvingProduct omschrijvingProduct1 in cboProductWijzigen.Properties.Items)
                            {
                                if (omschrijvingProduct1.Omschrijving == productOmschrijving)
                                {
                                    cboProductWijzigen.SelectedIndex = index;
                                    break;
                                }
                                index++;
                            }

                            txtBedragWijzigen.Text = ((Korting_Product)listBoxKortingProduct.SelectedItem).Bedrag.ToString();
                        }
                    }

                }
            }
        }

        private void listBoxKortingWerf_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBoxKortingProductWerf_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (listBoxKortingProductWerf.SelectedItem != null)
            {
                labelProductKortingNaam.Text = "";
                labelProductKortingBedrag.Text = "";
                string productOmschrijving = "";
                string omschrijvingFormule = "";
                foreach (OmschrijvingProduct omschrijvingProduct in productOmschrijvingen)
                {
                    if (omschrijvingProduct.Formule == ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Formule.Naam)
                    {
                        productOmschrijving = omschrijvingProduct.Omschrijving;
                        omschrijvingFormule = omschrijvingProduct.Formule;
                        int index = 0;
                        foreach (OmschrijvingProduct omschrijvingProduct1 in cboProductWijzigen.Properties.Items)
                        {
                            if (omschrijvingProduct1.Omschrijving == productOmschrijving)
                            {
                                cboProductWijzigen.SelectedIndex = index;
                                break;
                            }
                            index++;
                        }
                        txtBedragWijzigen.Text = ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Bedrag.ToString();


                        int index1 = 0;
                        foreach (Werf werf in cboWerfWijzigen.Properties.Items)
                        {
                            if (werf.ToString() == ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Werf.ToString())
                            {
                                cboWerfWijzigen.SelectedIndex = index1;
                                break;
                            }
                            index1++;
                        }
                        cboWerfWijzigen.Enabled = true;
                        cboProductWijzigen.Enabled = true;
                        txtBedragWijzigen.Enabled = true;
                    }
                }
                int counter = 0;
                foreach (Formule formule in cboFormulesWijzigen.Items)
                {
                    if (formule.Naam == omschrijvingFormule)
                    {
                        cboFormulesWijzigen.SelectedIndex = counter;
                    }
                    else
                    {
                        counter++;
                    }
                }
                labelOmschrijving.Text = "Product Korting : " + productOmschrijving + " €" + ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Bedrag.ToString();
                labelWerfProductNaam.Text = ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Werf.Adres + " " + ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Werf.Gemeente;
                labelProductWerfKortingNaam.Text = productOmschrijving;
                labelProductWerfKortingBedrag.Text = "€" + ((Korting_Product_Werf)listBoxKortingProductWerf.SelectedItem).Bedrag.ToString();
                listBoxKortingKlant.SelectedItem = null;
                listBoxKortingWerf.SelectedItem = null;
                listBoxKortingProduct.SelectedItem = null;
                simpleButton2.Enabled = true;
            }
        }

        private void listBoxKortingWerf_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            labelWerfProductNaam.Text = "";
            labelProductWerfKortingNaam.Text = "";
            labelProductWerfKortingBedrag.Text = "";
            if (listBoxKortingWerf.SelectedItem != null)
            {
                labelOmschrijving.Text = "Werf Korting : " + ((Korting_Werf)listBoxKortingWerf.SelectedItem).Werf.ToString() + " €" + ((Korting_Werf)listBoxKortingWerf.SelectedItem).Bedrag.ToString();
                listBoxKortingKlant.SelectedItem = null;
                listBoxKortingProductWerf.SelectedItem = null;
                listBoxKortingProduct.SelectedItem = null;
                cboProductWijzigen.Enabled = false;
                cboWerfWijzigen.Enabled = true;
                cboProductWijzigen.SelectedItem = null;

                int index = 0;
                foreach (Werf werf in cboWerfWijzigen.Properties.Items)
                {
                    if (werf.ToString() == ((Korting_Werf)listBoxKortingWerf.SelectedItem).Werf.ToString())
                    {
                        cboWerfWijzigen.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
                txtBedragWijzigen.Text = ((Korting_Werf)listBoxKortingWerf.SelectedItem).Bedrag.ToString();
                labelWerfKortingBedrag.Text = ((Korting_Werf)listBoxKortingWerf.SelectedItem).Bedrag.ToString();
                txtBedragWijzigen.Enabled = true;
                simpleButton2.Enabled = true;
            }
        }

        private void listBoxKortingKlant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxKortingKlant_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            labelWerfProductNaam.Text = "";
            labelProductWerfKortingNaam.Text = "";
            labelProductWerfKortingBedrag.Text = "";
            if (listBoxKortingKlant.SelectedItem != null)
            {
                listBoxKortingWerf.SelectedItem = null;
                listBoxKortingProductWerf.SelectedItem = null;
                listBoxKortingProduct.SelectedItem = null;
                txtBedragWijzigen.Enabled = true;
                simpleButton2.Enabled = true;
                txtBedragWijzigen.Text = ((Korting_Klant)listBoxKortingKlant.SelectedItem).Bedrag.ToString();
            }
        }

        private void cboProductWijzigen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                OmschrijvingProduct omschrijvingProduct = ((OmschrijvingProduct)cboProductWijzigen.SelectedItem);
                int counter = 0;
                foreach (Formule formule in cboFormulesWijzigen.Items)
                {
                    if (formule.Naam == omschrijvingProduct.Formule)
                    {
                        cboFormulesWijzigen.SelectedIndex = counter;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            catch { }
        }

        private void cboProductOmschrijving_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                OmschrijvingProduct omschrijvingProduct = ((OmschrijvingProduct)cboProductOmschrijving.SelectedItem);
                int counter = 0;
                foreach (Formule formule in cboformules.Items)
                {
                    if (formule.Naam == omschrijvingProduct.Formule)
                    {
                        cboformules.SelectedIndex = counter;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            catch { }
        }

        private void cboSoortenKorting_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBoxKortingKlant.SelectedItem = null;
            listBoxKortingWerf.SelectedItem = null;
            listBoxKortingProductWerf.SelectedItem = null;
            listBoxKortingProduct.SelectedItem = null;
            if (cboKlanten.SelectedItem != null)
            {
                switch (cboSoortenKorting.SelectedIndex)
                {
                    case 0:
                        cboProductOmschrijving.Enabled = true;
                        cboWerven.Enabled = false;
                        txtNieuwBedrag.Enabled = true;
                        simpleButton1.Enabled = true;
                        //MessageBox.Show("Korting op product");
                        break;
                    case 1:
                        cboProductOmschrijving.Enabled = true;
                        cboWerven.Enabled = true;
                        txtNieuwBedrag.Enabled = true;
                        simpleButton1.Enabled = true;
                        //MessageBox.Show("Korting op werf en product");
                        break;
                    case 2:
                        cboProductOmschrijving.Enabled = false;
                        cboWerven.Enabled = true;
                        txtNieuwBedrag.Enabled = true;
                        simpleButton1.Enabled = true;
                        //MessageBox.Show("Korting op werf ");
                        break;
                    case 3:
                        cboProductOmschrijving.Enabled = false;
                        cboWerven.Enabled = false;
                        txtNieuwBedrag.Enabled = true;
                        simpleButton1.Enabled = true;
                        //MessageBox.Show("Korting op Klant");
                        break;
                }
            }
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
