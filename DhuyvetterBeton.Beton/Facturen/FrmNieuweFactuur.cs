using BL;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DhuyvetterBeton.Beton.Klanten;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Facturen
{
    public partial class FrmNieuweFactuur : DevExpress.XtraEditors.XtraUserControl
    {
        FrmKlantNotitie frmKlantNotitie;
        //List<Klant> klantenlijst = Klant.KrijgAlleKlanten();
        List<string> Hulpstof_FactuurItemsList = new List<string>();
        List<double> Hulpstof_FactuurItemsListEenheidsPrijs = new List<double>();
        List<double> Hulpstof_FactuurItemsListTotaalPrijs = new List<double>();
        int counterFacturen = 0;
        int counterFactuuritems = 0;
        double factuur0Totaal = 0;
        double factuurVerlegdTotaal = 0;
        double factuur6Totaal = 0;
        double factuur21Totaal = 0;
        double factuurTotaal = 0;
        bool isOpen = false;
        #region factuuritemPercentages
        double factuuritem0 = 0;
        double factuuritemVerlegd = 0;
        double factuuritem6 = 0;
        double factuuritem21 = 0;
        double factuuritemTotaal = 0;
        #endregion
        Factuur factuur = new Factuur();
        Factuur factuur1 = new Factuur();
        PompPrijs pompPrijs = new PompPrijs();
        FrmHoofdVenster frmhoofd;
        List<Klant> klantenlijstFilter;
        #region listingen
        List<NormaleLeveringBon> normaleLeveringBonList = new List<NormaleLeveringBon>();
        List<BL.PrijsLijst> prijslijsten = BL.PrijsLijst.KrijgAlleOmschrijvingen();
        List<PompPrijs> pompPrijzen = PompPrijs.KrijgAllePompPrijzen();
        List<OmschrijvingProduct> productOmschrijvingen = OmschrijvingProduct.KrijgAlleOmschrijvingen();
        OmschrijvingProduct omschrijvingProduct = new OmschrijvingProduct();
        #endregion

        #region factuurItemPrijzen
        #region pomp
            double totaalgepomptm3 = 0;
            string soortpomp = string.Empty;
            #endregion

            #region hulpstof
        double prijsHulpstof = 0;
        double prijsProduct = 0;
        #endregion

        #region factuuritem
        double totaalm3 = 0;

        #endregion
        #endregion
        string user;
        public FrmNieuweFactuur(string USER, FrmHoofdVenster frm)
        {

            InitializeComponent();
            user = USER;
            frmhoofd = frm;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        
        }

        private void FrmNieuweFactuur_Load(object sender, EventArgs e)
        {
     
        }

        private void listBoxDatums_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox0percent.Checked = false;
            checkBox6Percent.Checked = false;
            checkBoxVerlegd.Checked = false;
            checkBox21Percent.Checked = false;
            checkBoxAannemer.Checked = false;
            checkBoxParticulier.Checked = false;
            checkBoxBeton.Checked = false;
            checkBoxStabiel.Checked = false;
            soortpomp = string.Empty;
            checkBoxBerekenen.Checked = false;
            labelSoortPomp.Text = "0";
            labelTotaalGepompt.Text = "0";
            labelPompZelfPrijs.Text = "0";
            textBoxKubiekHulpstof.Text = "0";
            labelEenheidsprijs.Text = "0";
            if (listBoxDatums.SelectedItem != null) { 
            Cursor.Current = Cursors.AppStarting;
            listBoxProducten.Items.Clear();
            listBoxLeveringBonnen.Items.Clear();
            listBoxWerven.Items.Clear();
            List<NormaleLeveringBon> leveringBonsDatums = NormaleLeveringBon.KrijgBestellingenDoorDatumEnKlant(Convert.ToDateTime(listBoxDatums.SelectedItem), Convert.ToDateTime(listBoxDatums.SelectedItem).AddDays(+1), ((Klant)cboKlanten.SelectedItem).ID);
            List<Formule> formuleList = Formule.KrijgAlleFormules();
            foreach(NormaleLeveringBon normaleLeveringBon in leveringBonsDatums)
            {
                foreach(Formule formule in formuleList)
                {
                        if (normaleLeveringBon.Formule.Naam == formule.Naam)
                        {
                            if (listBoxProducten.Items.Contains(formule)) { }
                            else
                            {
                                listBoxProducten.Items.Add(formule);
                            }
                        }
                    }
                }
            }
            if (listBoxProducten.Items.Count == 1)
            {
                listBoxProducten.SelectedIndex = 0;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.AppStarting;
                if (cboKlanten.SelectedItem != null)
                {
                    listBoxDatums.Items.Clear();
                    List<NormaleLeveringBon> leveringBonsDatums = NormaleLeveringBon.KrijgBestellingenDoorDatumEnKlant(Convert.ToDateTime(monthCalendar2.SelectionRange.Start), Convert.ToDateTime(monthCalendar2.SelectionRange.End).AddDays(+1), ((Klant)cboKlanten.SelectedItem).ID);
                    leveringBonsDatums.Sort((x, y) => x.Datum.CompareTo(y.Datum));
                    int counter = 0;
                    foreach (NormaleLeveringBon leveringbon in leveringBonsDatums)
                    {
                        if (listBoxDatums.Items.Contains(leveringbon.ToStringDatum()))
                        {

                        }
                        else
                        {
                            listBoxDatums.Items.Add(leveringbon);
                            listBoxDatums.Items[counter] = leveringbon.Datum.ToLongDateString();
                            counter++;
                        }
                    }
                }
          
                factuur = new Factuur();
                factuur.FactuurNummer = txtAfdeling.Text + txtFactuurNummer.Text;
                factuur.Datum = dateTimePicker1.Value;
                factuur.Klant = ((Klant)cboKlanten.SelectedItem);
                factuur.TotaalExclBtw = 0;
                factuur.TotaalVerlegd = 0;
                factuur.TotaalIncl6Btw = 0;
                factuur.TotaalIncl21Btw = 0;
                factuur.MaakNieuweFactuur();
                simpleButton1.Enabled = false;
                cboKlanten.Enabled = false;
                txtAfdeling.Enabled = false;
                txtFactuurNummer.Enabled = false;
                factuur1 = Factuur.KrijgFactuurViaFactuurNummer(txtAfdeling.Text + txtFactuurNummer.Text);

            }
            catch
            {
                MessageBox.Show("Klant niet gevonden.");
            }


            try
            {
                List<KlantNotitie> klantNotitieLijst = KlantNotitie.KrijgAlleNotitiesVanKlant(((Klant)cboKlanten.SelectedItem).ID);
                if (klantNotitieLijst.Count != 0)
                {
                    isOpen = true;
                    frmKlantNotitie = new FrmKlantNotitie(klantNotitieLijst);
                    frmKlantNotitie.Show();
                }
                else if (isOpen == true)
                {
                    isOpen = false;
                    frmKlantNotitie.Close();
                }
             
            }
            catch
            {
          
            }
        }

        private void listBoxProducten_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxAannemer.Checked = false;
            checkBoxParticulier.Checked = false;
            checkBoxBeton.Checked = false;
            checkBoxStabiel.Checked = false;
            soortpomp = string.Empty;
            checkBoxBerekenen.Checked = false;
            labelSoortPomp.Text = "0";
            labelTotaalGepompt.Text = "0";
            labelPompZelfPrijs.Text = "0";
            textBoxKubiekHulpstof.Text = "0";
            labelEenheidsprijs.Text = "0";
            if (listBoxProducten.SelectedItem != null)
            {
            
                Cursor.Current = Cursors.AppStarting;
                listBoxWerven.Items.Clear();
                listBoxLeveringBonnen.Items.Clear();
                List<NormaleLeveringBon> normaleLeveringBonList = NormaleLeveringBon.KrijgBestellingenDoorDatumEnKlantEnProduct(Convert.ToDateTime(listBoxDatums.SelectedItem), Convert.ToDateTime(listBoxDatums.SelectedItem).AddDays(+1), ((Klant)cboKlanten.SelectedItem).ID, ((Formule)listBoxProducten.SelectedItem).ID);
                List<Werf> WervenLijstKlant = BL.Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                List<Werf> filterWerfList = new List<Werf>();
                foreach (NormaleLeveringBon normaleLeveringBon in normaleLeveringBonList)
                {
                    foreach (Werf werf in WervenLijstKlant)
                    {
                        if (normaleLeveringBon.Werf.Adres == werf.Adres)
                        {
                            if (filterWerfList.Contains(werf)) { } else { filterWerfList.Add(werf); }
                        }
                    }
                }
                listBoxWerven.Items.AddRange(filterWerfList.ToArray());
            }
            if (listBoxWerven.Items.Count == 1)
            {
                listBoxWerven.SelectedIndex = 0;
            }
        }

        private void listBoxLeveringBonnen_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tofix
            //try
            //{
            //    PrijsSetting prijsSetting = PrijsSetting.krijgPrijsSettingKlant(((Klant)cboKlanten.SelectedItem));
            //    if (prijsSetting.Soort == 0)
            //    {
            //        checkBoxAannemer.Checked = true;
            //    }
            //    else if (prijsSetting.Soort == 1)
            //    {
            //        checkBoxParticulier.Checked = true;
            //    }
            //}
            //catch
            //{
            //    if (labelBTW.Text != string.Empty)
            //    {
            //        checkBoxAannemer.Checked = true;
            //        checkBoxParticulier.Checked = false;
            //    }
            //    else
            //    {
            //        checkBoxAannemer.Checked = false;
            //        checkBoxParticulier.Checked = true;
            //    }
            //}
            Werf werf = ((BL.Werf)listBoxWerven.SelectedItem);
            if(werf.Adres == "afhaling")
            {
                checkBox21Percent.Checked = true;
            }
            txtHoeveelm3.Text = "0";
           
            txtTotaalGepompt.Text = string.Empty;
            #region leveringbonInfo
            if (listBoxLeveringBonnen.SelectedItem != null)
            {
                foreach (OmschrijvingProduct omschrijvingProduct1 in productOmschrijvingen)
                {
                    if (omschrijvingProduct1.Formule == ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam)
                    {
                        omschrijvingProduct = omschrijvingProduct1;
                        labelProductOmschrijving.Text = omschrijvingProduct.Omschrijving;
                    }
                }
                labelKlantDetail.Text = ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Klant.Naam;
                labelWerf.Text = ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Werf.Adres + " " + ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Werf.Gemeente;
                labelM3LeveringBon.Text = totaalm3.ToString();
                #endregion
                listBoxKlantKortingen.Items.Clear();
                listBoxProductKorting.Items.Clear();
                listBoxWerfKorting.Items.Clear();
                listBoxWerfEnProductKorting.Items.Clear();
                // MessageBox.Show(totaalm3.ToString());
                List<Korting_Werf> korting_WervenLijst = Korting_Werf.KrijgKortingDoorWerfID(((Werf)listBoxWerven.SelectedItem).ID);
                List<Korting_Product> korting_ProductenLijst = Korting_Product.KrijgKortingDoorProductID(((Klant)cboKlanten.SelectedItem).ID, ((Formule)listBoxProducten.SelectedItem).ID);
                List<Korting_Product_Werf> korting_ProductenWerfLijst = Korting_Product_Werf.KrijgKortingDoorProductIDenWerfID(((Formule)listBoxProducten.SelectedItem).ID, ((Werf)listBoxWerven.SelectedItem).ID);
                List<Korting_Klant> korting_KlantLijst = Korting_Klant.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
                listBoxProductKorting.Items.AddRange(korting_ProductenLijst.ToArray());
                listBoxWerfKorting.Items.AddRange(korting_WervenLijst.ToArray());
                listBoxWerfEnProductKorting.Items.AddRange(korting_ProductenWerfLijst.ToArray());
                listBoxKlantKortingen.Items.AddRange(korting_KlantLijst.ToArray());
                //  if(((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Levering == 0) { txtLaadEnLostijden.Enabled = false; } else { txtLaadEnLostijden.Enabled = true; }

                // MessageBox.Show(((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).ID.ToString());
                labelSoortPomp.Text = soortpomp;
                labelTotaalGepompt.Text = totaalgepomptm3.ToString();
                foreach (PompPrijs pompprijs1 in pompPrijzen)
                {
                    if (pompprijs1.Giek == labelSoortPomp.Text)
                    {
                        labelPompZelfPrijs.Text = pompprijs1.Bedrag.ToString();
                        pompPrijs = pompprijs1;
                    }
                }

                Klant klantSelected = ((Klant)cboKlanten.SelectedItem);
                if(klantSelected.Btw == string.Empty)
                {
                    checkBoxParticulier.Checked = true;
                }
                else
                {
                    checkBoxAannemer.Checked = true;
                }
                foreach (BL.PrijsLijst prijs in prijslijsten)
                {
                    if (listBoxLeveringBonnen.SelectedItem != null)
                    {
                        if (prijs.Formule == ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam)
                        {
                            if (((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "10 Teelaar" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "13 Spuitza" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "14 Bakstee" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "3 Breekza" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "4 0/2 Zand" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "5 0/5 Zand" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "G 0/7 Zand" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "Gravier 2/6" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "8 6/14 Gr" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "9 3/10" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "betonzand" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "zeezand" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "2" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "Poussier" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "Gravier 6/20" || ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam == "betonblokken")
                            {
                                prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);
                                break;
                            }
                            else if (checkBoxAannemer.Checked == true)
                            {
                                prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);
                                if (((Werf)listBoxWerven.SelectedItem).Adres == "afhaling")
                                {
                                    double PrijsAfhaling = ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).M3 * 10;
                                    prijsProduct = prijsProduct - PrijsAfhaling;


                                }
                            }
                            else if (checkBoxParticulier.Checked == true)
                            {
                                prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text); 
                                if (((Werf)listBoxWerven.SelectedItem).Adres == "afhaling")
                                {
                                    double PrijsAfhaling = ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).M3 * 10;
                                    prijsProduct = prijsProduct - PrijsAfhaling;
                                }
                            }
                        }
                    }
                }
            }
            if (labelSoortPomp.Text == string.Empty)
            {
                labelSoortPomp.Text = "0";
            }
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }
        private void listBoxWerven_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxAannemer.Checked = false;
            checkBoxParticulier.Checked = false;
            checkBoxBeton.Checked = false;
            checkBoxStabiel.Checked = false;
            checkBoxBerekenen.Checked = false;
            soortpomp = string.Empty;
            labelSoortPomp.Text = "0";
            labelPompZelfPrijs.Text = "0";
            labelTotaalGepompt.Text = "0";
            labelEenheidsprijs.Text = "0";
            if (listBoxWerven.SelectedItem != null)
            {
             

                Cursor.Current = Cursors.AppStarting;
                listBoxLeveringBonnen.Items.Clear();
                bool inListbox = false;
                normaleLeveringBonList = NormaleLeveringBon.KrijgBestellingenDoorDatumEnKlantEnProductEnWerf(Convert.ToDateTime(listBoxDatums.SelectedItem), Convert.ToDateTime(listBoxDatums.SelectedItem).AddDays(+1), ((Klant)cboKlanten.SelectedItem).ID, ((Formule)listBoxProducten.SelectedItem).ID, ((Werf)listBoxWerven.SelectedItem).ID);

                foreach (NormaleLeveringBon normaleLeveringBon in normaleLeveringBonList)
                {
                    List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorLeveringID(normaleLeveringBon.ID);
                    
                    listBoxHulpstoffen.Items.AddRange(hulpstoffenList.ToArray());

                    if (inListbox == false)
                    {
                        listBoxLeveringBonnen.Items.Add(normaleLeveringBon);
                        inListbox = true;
                        totaalm3 = normaleLeveringBon.M3;
                        if (normaleLeveringBon.Formule.Naam.Contains("G") || normaleLeveringBon.Formule.Naam.Contains("BRZ"))
                        {
                            checkBoxStabiel.Checked = true;
                            checkBoxBeton.Checked = false;
                        }
                        else
                        {
                            checkBoxStabiel.Checked = false;
                            checkBoxBeton.Checked = true;
                        }
                    }
                    else
                    {
                        totaalm3 = totaalm3 + normaleLeveringBon.M3;
                    }
                }
                foreach (NormaleLeveringBon normaleLeveringBon in normaleLeveringBonList)
                {
                    if (normaleLeveringBon.Pomp.ID == 1 || normaleLeveringBon.Pomp.ID == 7)
                    {

                    }
                    else
                    {
                        soortpomp = "0";
                        totaalgepomptm3 = totaalgepomptm3 + normaleLeveringBon.M3;
                        soortpomp = normaleLeveringBon.Giek;
                    }
                }
            }
            if (listBoxLeveringBonnen.Items.Count != 0)
            {
                listBoxLeveringBonnen.SelectedIndex = 0;
            }
        }

        private void listBoxWerfKorting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl3_Click(object sender, EventArgs e)
        {
            listBoxWerfKorting.ClearSelected();
            listBoxProductKorting.ClearSelected();
            listBoxWerfEnProductKorting.ClearSelected();
        }

        private void groupControl2_Click(object sender, EventArgs e)
        {
            listBoxWerfKorting.ClearSelected();
            listBoxProductKorting.ClearSelected();
            listBoxWerfEnProductKorting.ClearSelected();
        }

        private void FrmNieuweFactuur_Click(object sender, EventArgs e)
        {
            listBoxWerfKorting.ClearSelected();
            listBoxProductKorting.ClearSelected();
            listBoxWerfEnProductKorting.ClearSelected();
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void checkBoxOnvolledigeLading_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxOnvolledigeLading.CheckState == CheckState.Checked)
            {
                labelPrijsTotaalOnvolledigeLading.Text = txtOnvolledigeladingPrijs.Text;
                txtOnvolledigeladingPrijs.Enabled = true;
            }
            else 
            {
                txtOnvolledigeladingPrijs.Enabled = false; 
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
          
        }

        private void txtLaadEnLostijden_TextChanged(object sender, EventArgs e)
        {
            double laadenlostijden = 0;
            if (txtLaadEnLostijden.Text == string.Empty)
            {
                laadenlostijden = 0;
                labelLaadEnLostijden.Text = laadenlostijden.ToString();

            }
            else
            {
                laadenlostijden = Convert.ToDouble(txtLaadEnLostijden.Text) * 1.20;
                labelLaadEnLostijden.Text = laadenlostijden.ToString();
            }
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            prijsHulpstof = 0;
            if (listBoxHulpstoffen.SelectedItem != null)
            {
                Hulpstof_FactuurItemsList.Add(((Hulpstof)listBoxHulpstoffen.SelectedItem).Naam);
                Hulpstof_FactuurItemsListEenheidsPrijs.Add(Convert.ToDouble(txtPrijsHulpstof.Text));
                Hulpstof_FactuurItemsListTotaalPrijs.Add((Convert.ToDouble(txtPrijsHulpstof.Text) * Convert.ToDouble(textBoxKubiekHulpstof.Text)));
                string removelistitem = listBoxHulpstoffen.SelectedItem.ToString();
                prijsHulpstof = prijsHulpstof + (Convert.ToDouble(txtPrijsHulpstof.Text) * Convert.ToDouble(textBoxKubiekHulpstof.Text));

                int ItemCount = listBoxHulpstoffen.SelectedItems.Count;

                for (int i = 0; i < ItemCount; i++)
                {
                    listBoxHulpstoffen.Items.Remove(listBoxHulpstoffen.SelectedItem);
                }




              
                labelTotaalPrijsHulpstof.Text = prijsHulpstof.ToString();
                txtPrijsHulpstof.Text = string.Empty;
                textBoxKubiekHulpstof.Text = "0";

                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {

                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
            }
            else
            {
                MessageBox.Show("Hulpstof niet correct aangeduid. Probeer het opnieuw. ","Hulpstof",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnFactuurItemToevoegen_Click(object sender, EventArgs e)
        {
            if (checkBox0percent.Checked == false && checkBoxVerlegd.Checked == false && checkBox6Percent.Checked == false && checkBox21Percent.Checked == false)
            {
                MessageBox.Show("Gelieve Percentage BTW aan te duiden.", "BTW waarde incorrect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                counterFactuuritems++;
                if (counterFactuuritems == 5)
                {
                    label9.Text = "12";
                }
                labelAantalFactuursItems.Text = counterFactuuritems.ToString();
                if (labelProductPrijsTotaal.Text == "0")
                {
                    MessageBox.Show("Product Prijs totaal is 0 aanmaken niet mogelijk.");
                }
                else
                {

                    prijsHulpstof = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                    double suplimentPomp = 0;
                    if (txtSupplimentPomp.Text != string.Empty) { suplimentPomp = Convert.ToDouble(txtSupplimentPomp.Text); }
                    //if (checkBoxBerekenen.Checked == false)
                    //{
                    //    MessageBox.Show("Gelieve eerst te berekenen.", "Foutieve input", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //}
                    //else
                    
                        if (omschrijvingProduct.Omschrijving.Contains("vertrager"))
                        {
                            prijsProduct = prijsProduct + prijsHulpstof;
                        }
                        double hoeveelheidonvolledigelading = Convert.ToDouble(txtHoeveelm3.Text);
                        double PompFactuurItem = Convert.ToDouble(labelPompZelfPrijs.Text) + Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelWachttijdPomp.Text);
                        Factuur_Item factuur_Item = new Factuur_Item(((Werf)listBoxWerven.SelectedItem), factuur1, omschrijvingProduct, pompPrijs, Convert.ToDateTime((listBoxDatums.SelectedItem)), Convert.ToDouble(labelTransportPrijsTotaal.Text), suplimentPomp, Convert.ToDouble(labelPompTotaal.Text), Convert.ToDouble(labelWachttijdPomp.Text), Convert.ToDouble(labelTotaalGepompt.Text), Convert.ToDouble(labelLaadEnLostijden.Text), Convert.ToDouble(txtHoeveelm3.Text), Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text), totaalm3, Convert.ToDouble(labelProductPrijsTotaal.Text), Convert.ToDouble(labelEenheidsprijs.Text), Convert.ToDouble(labelTotaalFactuurItem.Text));
                        factuur_Item.MaakNieuweFactuurItem();
                        Factuur_Item factuur_Item1 = factuur_Item.krijgFactuurItemDoorGegevens();
                        int counter = 0;
                        if (Hulpstof_FactuurItemsList.Count > 0)
                        {
                            foreach (string hulpstofitem in Hulpstof_FactuurItemsList)
                            {

                                Hulpstof_Factuur_Item hulpstof_Factuur_Item = new Hulpstof_Factuur_Item(factuur_Item1, hulpstofitem, Hulpstof_FactuurItemsListEenheidsPrijs[counter], Hulpstof_FactuurItemsListTotaalPrijs[counter]);
                                hulpstof_Factuur_Item.maakNieuweHulpstofFactuurItem();
                                counter++;
                            }
                        }
                        //      Factuur_Item factuur_Item1 = factuur_Item.krijgAlleFactuurItemsDoorGegevens();
                        pompPrijs = null;
                        factuur0Totaal = factuur0Totaal + Convert.ToDouble(label0FactuurItem.Text);
                        factuurVerlegdTotaal = factuurVerlegdTotaal + +Convert.ToDouble(labelVerlegdFactuurItem.Text);
                        factuur6Totaal = factuur6Totaal + Convert.ToDouble(label6FactuurItem.Text);
                        factuur21Totaal = factuur21Totaal + Convert.ToDouble(label21FactuurItem.Text);
                        factuurTotaal = factuurTotaal + Convert.ToDouble(labelTotaalFactuurItem.Text);

                        label0Totaal.Text = factuur0Totaal.ToString();
                        labelVerlegdTotaal.Text = factuurVerlegdTotaal.ToString();
                        label6Totaal.Text = factuur6Totaal.ToString();
                        label21Totaal.Text = factuur21Totaal.ToString();
                        labelTotaalFactuur.Text = factuurTotaal.ToString();
                        txtHoeveelm3.Text = string.Empty;
                        txtTotaalGepompt.Text = string.Empty;
                        checkBoxOnvolledigeLading.Checked = false;
                        txtPrijsTransport.Text = "0";
                        txtWachttijdPomp.Text = string.Empty;
                        listBoxKlantKortingen.ClearSelected();
                        listBoxWerfKorting.ClearSelected();
                        listBoxProductKorting.ClearSelected();
                        listBoxWerfEnProductKorting.ClearSelected();
                        checkBoxBerekenen.Checked = false;
                        checkBox0percent.Checked = false;
                        checkBox6Percent.Checked = false;
                        checkBox21Percent.Checked = false;
                        checkBoxVerlegd.Checked = false;
                        labelSoortPomp.Text = "Soort";
                        label0FactuurItem.Text = "0";
                        labelVerlegdFactuurItem.Text = "0";
                        label6FactuurItem.Text = "0";
                    txtAddPrijs.Text = string.Empty;
                        label21FactuurItem.Text = "0";
                        labelTotaalGepompt.Text = "0";
                        labelTotaalFactuurItem.Text = "0";
                        labelTransportPrijsTotaal.Text = "0";
                        labelTotaalGepompt.Text = "0";
                        labelPrijsTotaalOnvolledigeLading.Text = "0";
                        labelTotaalPrijsHulpstof.Text = "0";
                        labelTotaalKorting.Text = "0";
                        labelProductPrijsTotaal.Text = "0";
                        labelLaadEnLostijden.Text = "0";
                        labelPompZelfPrijs.Text = "0";
                        labelWerf.Text = "Gegevens";
                        txtLaadEnLostijden.Text = "0";
                        labelEenheidsprijs.Text = "0";
                        labelPompTotaal.Text = "0";
                        labelProductOmschrijving.Text = "Gegevens";
                        labelM3LeveringBon.Text = "Gegevens";
                        string removelistitem1 = listBoxLeveringBonnen.SelectedItem.ToString();
                        string removelistitem2 = listBoxWerven.SelectedItem.ToString();
                        for (int n = listBoxLeveringBonnen.Items.Count - 1; n >= 0; --n)
                        {

                            if (listBoxLeveringBonnen.Items[n].ToString().Contains(removelistitem1))
                            {
                                listBoxLeveringBonnen.Items.RemoveAt(n);
                            }
                        }
                        for (int n = listBoxWerven.Items.Count - 1; n >= 0; --n)
                        {

                            if (listBoxWerven.Items[n].ToString().Contains(removelistitem2))
                            {
                                listBoxWerven.Items.RemoveAt(n);
                            }
                        }
                        if (listBoxWerven.Items.Count > 0)
                        {
                            // er zijn nog werven
                        }
                        else
                        {
                            string removelistitem3 = listBoxProducten.SelectedItem.ToString();
                            for (int n = listBoxProducten.Items.Count - 1; n >= 0; --n)
                            {

                                if (listBoxProducten.Items[n].ToString().Contains(removelistitem3))
                                {
                                    listBoxProducten.Items.RemoveAt(n);
                                }
                            }
                        }
                        if (listBoxProducten.Items.Count > 0)
                        {

                        }
                        else
                        {
                            string removelistitem4 = listBoxDatums.SelectedItem.ToString();
                            for (int n = listBoxDatums.Items.Count - 1; n >= 0; --n)
                            {

                                if (listBoxDatums.Items[n].ToString().Contains(removelistitem4))
                                {
                                    listBoxDatums.Items.RemoveAt(n);
                                }
                            }
                        }
                        soortpomp = "0";
                        pompPrijs = new PompPrijs();

                        listBoxHulpstoffen.Items.Clear();
                        listBoxProductKorting.Items.Clear();
                        listBoxWerfKorting.Items.Clear();
                        listBoxWerfEnProductKorting.Items.Clear();
                        checkBoxBeton.Checked = false;
                        checkBoxStabiel.Checked = false;
                        checkBoxParticulier.Checked = false;
                        checkBoxAannemer.Checked = false;
                    
                    if (Hulpstof_FactuurItemsList.Count != 0)
                    {

                    }

                    Hulpstof_FactuurItemsList = new List<string>();
                    Hulpstof_FactuurItemsListEenheidsPrijs = new List<double>();
                    Hulpstof_FactuurItemsListTotaalPrijs = new List<double>();

                }
                factuuritem0 = 0;
                factuuritemVerlegd = 0;
                factuuritem6 = 0;
                factuuritem21 = 0;
                factuuritemTotaal = 0;
                List<Factuur_Item> factuur_Items = Factuur_Item.krijgAlleFactuurItemsDoorFactuurID(factuur1.ID);

                foreach (BL.Factuur_Item factuur_Item in factuur_Items)
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
                dataGridViewFactuurItems.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
                dataGridViewFactuurItems.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");


                dataGridView1.DataSource = factuur_Items;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Factuur"].Visible = false;
                dataGridView1.Columns["Werf"].Width = 180;
                dataGridView1.Columns["OmschrijvingProduct"].Width = 180;
                dataGridView1.Columns["OmschrijvingProduct"].HeaderText = "Omschrijving";
                dataGridView1.Columns["BestelDatum"].DisplayIndex = 3;
                dataGridView1.Columns["BestelDatum"].HeaderText = "Datum";
                dataGridView1.Columns["PompPrijs"].HeaderText = "Pomp Prijs";
                dataGridView1.Columns["pompSuplimentEenheidsPrijs"].HeaderText = "Pomp eenheidprijs";
                dataGridView1.Columns["pompTotaalSuplimentPrijs"].HeaderText = "Pomp Totaal";
                dataGridView1.Columns["pompWachtTijd"].HeaderText = "Pomp WachtTijd";
                dataGridView1.Columns["gepompteM3"].HeaderText = "Gepompte M3";
                dataGridView1.Columns["transportTotaal"].HeaderText = "Transport";
                dataGridView1.Columns["laadEnLosTijdenTotaal"].HeaderText = "Laad En LosTijden";
                dataGridView1.Columns["onvolledige_Lading_Hoeveelheid"].HeaderText = "Onvolledige Lading Hoeveelheid";
                dataGridView1.Columns["onvolledige_Lading_Prijs"].HeaderText = "Onvolledige Lading Prijs";
                dataGridView1.Columns["productPrijs"].HeaderText = "Product Prijs";
                dataGridView1.Columns["eenheidsPrijs"].HeaderText = "EenheidsPrijs";
                dataGridView1.Columns["hoeveelheidProduct"].HeaderText = "Hoeveelheid Product";

            }
        }
        private void listBoxHulpstoffen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // int leveringbonID = ((Hulpstof)listBoxHulpstoffen.SelectedItem).NormaleLeveringBon.ID;
            //MessageBox.Show("dit is de bon met het product: " + leveringbonID.ToString());
            if (listBoxHulpstoffen.SelectedItem != null)
            {
                NormaleLeveringBon normaleLeveringBon = NormaleLeveringBon.krijgleveringBonDoorID(((Hulpstof)listBoxHulpstoffen.SelectedItem).NormaleLeveringBon.ID);
                //MessageBox.Show(normaleLeveringBon.Klant.Naam);
                textBoxKubiekHulpstof.Text = normaleLeveringBon.M3.ToString();
            }
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            //splashScreenManager2.ShowWaitForm();
            cboKlanten.Items.Clear();
            dateTimePicker1.Value = monthCalendar2.SelectionRange.End;
       
            Cursor.Current = Cursors.WaitCursor;
        
            List<NormaleLeveringBon> leveringbonlijst = NormaleLeveringBon.KrijgBestellingenDoorDatum(Convert.ToDateTime(monthCalendar2.SelectionRange.Start).Date, Convert.ToDateTime(monthCalendar2.SelectionRange.End).AddDays(+1));
            klantenlijstFilter = new List<Klant>();
            foreach (NormaleLeveringBon normaleLeveringBon in leveringbonlijst)
            {
                //int klantNummer = normaleLeveringBon.Klant.Nummer;
                //Klant klant = Klant.KrijgKlantViaKlantenNummer(klantNummer);
                //if (klantenlijstFilter.Exists(X=> X.Naam == normaleLeveringBon.Klant.Naam))
                //{

                //}
                //else
                //{
                    klantenlijstFilter.Add(normaleLeveringBon.Klant);
                //}
            }
            //foreach (Klant klant in klantenlijst)
            //{
            //    foreach (NormaleLeveringBon normaleLeveringBon in leveringbonlijst)
            //    {
            //        if (klant.Naam == normaleLeveringBon.Klant.Naam)
            //        {
            //            if(klantenlijstFilter.Contains(klant)!= true) { klantenlijstFilter.Add(klant); }
            //                //foreach (Klant klant1 in klantenlijstFilter)
            //                //{
            //                //    if (klant1.Naam == klant.Naam) { } else { ; klantenlijstFilter.Add(klant); }
            //                //}

            //        }   
            //    }
            //}
            klantenlijstFilter.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            cboKlanten.Items.AddRange(klantenlijstFilter.ToArray());
          //  splashScreenManager2.CloseWaitForm();
            int aantalKlanten = cboKlanten.Items.Count;
            labelAantalKlanten.Text = aantalKlanten.ToString();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKlanten.SelectedItem != null)
            {
                labelNaam.Text = ((Klant)cboKlanten.SelectedItem).Naam;
                labelAdres.Text = ((Klant)cboKlanten.SelectedItem).Adres + " " + ((Klant)cboKlanten.SelectedItem).Gemeente;
                labelBTW.Text = ((Klant)cboKlanten.SelectedItem).Btw.ToString();
                labelEmail.Text = ((Klant)cboKlanten.SelectedItem).Email;
            }
            else
            {
                labelNaam.Text = "";
                labelAdres.Text = "";
                labelBTW.Text = "";
                labelEmail.Text = "";
            }
        }

        private void txtTotaalGepompt_TextChanged(object sender, EventArgs e)
        {
            if (txtTotaalGepompt.Text != string.Empty)
            {
                labelTotaalGepompt.Text = txtTotaalGepompt.Text;
                if (labelSoortPomp.Text == "28m")
                {
                    txtSupplimentPomp.Text = "4,50";
                }
                else if (labelSoortPomp.Text == "32m")
                {
                    txtSupplimentPomp.Text = "5,00";
                }
                else if (labelSoortPomp.Text == "36m")
                {
                    txtSupplimentPomp.Text = "5,00";
                }
                else if (labelSoortPomp.Text == "44m")
                {
                    txtSupplimentPomp.Text = "5,50";
                }
                else if (labelSoortPomp.Text == "52m")
                {
                    txtSupplimentPomp.Text = "6,00";
                }
                else if(labelSoortPomp.Text == "0")
                {
                    txtSupplimentPomp.Text = "0,00";
                }
                else if (labelSoortPomp.Text == "28")
                {
                    txtSupplimentPomp.Text = "4,50";
                }
                else if (labelSoortPomp.Text == "32")
                {
                    txtSupplimentPomp.Text = "5,00";
                }
                else if (labelSoortPomp.Text == "36")
                {
                    txtSupplimentPomp.Text = "5,00";
                }
                else if (labelSoortPomp.Text == "44")
                {
                    txtSupplimentPomp.Text = "5,50";
                }
                else if (labelSoortPomp.Text == "52")
                {
                    txtSupplimentPomp.Text = "6,00";
                }
                else if (labelSoortPomp.Text == "0")
                {
                    txtSupplimentPomp.Text = "0,00";
                }
                if (txtSupplimentPomp.Text != string.Empty || txtTotaalGepompt.Text != string.Empty)
                {
                    double parsedValue;
                    if (!double.TryParse(txtTotaalGepompt.Text, out parsedValue))
                    {
                        MessageBox.Show("This is a number only field");
                        return;
                    }
                    else
                    {
                        double suplimentEnAantalPompPrijs = Convert.ToDouble(txtTotaalGepompt.Text) * Convert.ToDouble(txtSupplimentPomp.Text);
                        //labelPompZelfPrijs.Text = "0";
                        // double totaalPompenEnSupliment = Convert.ToDouble(labelTotaalGepompt.Text);
                        labelPompTotaal.Text = suplimentEnAantalPompPrijs.ToString();
                        double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                        double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                        double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                        double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                        double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                        double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                        double korting = Convert.ToDouble(labelTotaalKorting.Text);
                        double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                        label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                        if (checkBox0percent.Checked == true)
                        {

                            factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                            label0FactuurItem.Text = factuuritem0.ToString("F2");
                            factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                            labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                            // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                        }
                        if (checkBoxVerlegd.Checked == true)
                        {
                            factuuritemVerlegd = 0;
                            factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                            labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                            factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                            labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                        }
                        if (checkBox6Percent.Checked == true)
                        {
                            factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                            label6FactuurItem.Text = factuuritem6.ToString("F2");
                            factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                            labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                        }
                        if (checkBox21Percent.Checked == true)
                        {
                            factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                            label21FactuurItem.Text = factuuritem21.ToString("F2");
                            factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                            labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                        }
                    }
                }
            }
            else
            {
                txtSupplimentPomp.Text = string.Empty;
            }
        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            double kortingtotaal = Convert.ToDouble(labelTotaalKorting.Text);
            if(listBoxWerfKorting.SelectedItem!= null)
            {
                double werfKorting = ((Korting_Werf)listBoxWerfKorting.SelectedItem).Bedrag;
                double eenheidsproductPrijs = Convert.ToDouble(labelEenheidsprijs.Text);
                kortingtotaal = kortingtotaal + ((Korting_Werf)listBoxWerfKorting.SelectedItem).Bedrag;
                labelEenheidsprijs.Text = (eenheidsproductPrijs - werfKorting).ToString();
                double prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);
                labelProductPrijsTotaal.Text = prijsProduct.ToString("F2");
            }
            if(listBoxProductKorting.SelectedItem != null)
            {
                double productkorting = ((Korting_Product)listBoxProductKorting.SelectedItem).Bedrag;
                double eenheidsproductPrijs = Convert.ToDouble(labelEenheidsprijs.Text);
                labelEenheidsprijs.Text = (eenheidsproductPrijs - productkorting).ToString();
                labelKortingSoort.Text = "P";
                double prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);
                labelProductPrijsTotaal.Text = prijsProduct.ToString("F2");
            }
            if(listBoxWerfEnProductKorting.SelectedItem != null)
            {
                double productkorting = ((Korting_Product_Werf)listBoxWerfEnProductKorting.SelectedItem).Bedrag;
                double eenheidsproductPrijs = Convert.ToDouble(labelEenheidsprijs.Text);
                labelEenheidsprijs.Text = (eenheidsproductPrijs - productkorting).ToString();
                labelKortingSoort.Text = "WP";
                double prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);
                labelProductPrijsTotaal.Text = prijsProduct.ToString("F2");
            }
            if(listBoxKlantKortingen.SelectedItem != null)
            {
                double productkorting = ((Korting_Klant)listBoxKlantKortingen.SelectedItem).Bedrag;
                double eenheidsproductPrijs = Convert.ToDouble(labelEenheidsprijs.Text);
                labelEenheidsprijs.Text = (eenheidsproductPrijs - productkorting).ToString();
                labelKortingSoort.Text = "K";
                double prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);
                labelProductPrijsTotaal.Text = prijsProduct.ToString("F2");
            }
            labelTotaalKorting.Text = kortingtotaal.ToString();
            listBoxWerfKorting.ClearSelected();
            listBoxProductKorting.ClearSelected();
            listBoxWerfEnProductKorting.ClearSelected();
            //if(labelKortingSoort.Text == "P")
            //{
            //    double productPrijs = (Convert.ToDouble(labelProductPrijsTotaal.Text)-kortingtotaal);
            //    labelProductPrijsTotaal.Text = productPrijs.ToString();
            //}

            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtWachttijdPomp_TextChanged(object sender, EventArgs e)
        {
            double WachttijdPomp = 0;
            if (txtWachttijdPomp.Text == string.Empty)
            {
                WachttijdPomp = 0;
                labelWachttijdPrijs.Text = WachttijdPomp.ToString();
            }
            else
            {
                WachttijdPomp = Convert.ToDouble(txtWachttijdPomp.Text) * 1.35;
                WachttijdPomp  = System.Math.Round(WachttijdPomp, 2);
                labelWachttijdPrijs.Text = WachttijdPomp.ToString();
            }
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void txtHoeveelm3_TextChanged(object sender, EventArgs e)
        {
            double onvolledigeLadingPrijs = 0;
            if (txtHoeveelm3.Text == string.Empty)
            {
                onvolledigeLadingPrijs = 0;
                labelPrijsTotaalOnvolledigeLading.Text = onvolledigeLadingPrijs.ToString();
            }
            else
            {
                try
                {
                      onvolledigeLadingPrijs = Convert.ToDouble(txtHoeveelm3.Text) * Convert.ToDouble(txtOnvolledigeladingPrijs.Text);
                      labelPrijsTotaalOnvolledigeLading.Text = onvolledigeLadingPrijs.ToString();
                    double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                    double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                    double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                    double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                    double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                    double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                    double korting = Convert.ToDouble(labelTotaalKorting.Text);
                    double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                    label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                    if (checkBox0percent.Checked == true)
                    {

                        factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                        label0FactuurItem.Text = factuuritem0.ToString("F2");
                        factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                        // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    }
                    if (checkBoxVerlegd.Checked == true)
                    {
                        factuuritemVerlegd = 0;
                        factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                        labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                        factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    }
                    if (checkBox6Percent.Checked == true)
                    {
                        factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                        label6FactuurItem.Text = factuuritem6.ToString("F2");
                        factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    }
                    if (checkBox21Percent.Checked == true)
                    {
                        factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                        label21FactuurItem.Text = factuuritem21.ToString("F2");
                        factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    }
                }
                catch
                {

                }
          
            }
        }

        private void txtPrijsTransport_TextChanged(object sender, EventArgs e)
        {
            try
            {
                labelTransportPrijsTotaal.Text = txtPrijsTransport.Text;
                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {

                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
            }
           catch { }
        }

        private void txtSupplimentPomp_TextChanged(object sender, EventArgs e)
        {
            if (txtSupplimentPomp.Text != string.Empty)
            {
                double parsedValue;
                if (!double.TryParse(txtTotaalGepompt.Text, out parsedValue))
                {
                    //MessageBox.Show("This is a number only field");
                    return;
                }
                else
                {
                    double suplimentEnAantalPompPrijs = Convert.ToDouble(txtTotaalGepompt.Text) * Convert.ToDouble(txtSupplimentPomp.Text);
                    double totaalPompenEnSupliment = Convert.ToDouble(labelTotaalGepompt.Text) + suplimentEnAantalPompPrijs;
                    labelPompTotaal.Text = totaalPompenEnSupliment.ToString();
                    double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                    double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                    double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                    double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                    double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                    double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                    double korting = Convert.ToDouble(labelTotaalKorting.Text);
                    double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                    label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                    if (checkBox0percent.Checked == true)
                    {

                        factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                        label0FactuurItem.Text = factuuritem0.ToString("F2");
                        factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                        // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    }
                    if (checkBoxVerlegd.Checked == true)
                    {
                        factuuritemVerlegd = 0;
                        factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                        labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                        factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    }
                    if (checkBox6Percent.Checked == true)
                    {
                        factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                        label6FactuurItem.Text = factuuritem6.ToString("F2");
                        factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    }
                    if (checkBox21Percent.Checked == true)
                    {
                        factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                        label21FactuurItem.Text = factuuritem21.ToString("F2");
                        factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                        labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    }
                }
            }
        }

        private void labelWachttijdPrijs_Click(object sender, EventArgs e)
        {
            
        }

        private void labelWachttijdPrijs_TextChanged(object sender, EventArgs e)
        {
           labelWachttijdPomp.Text = labelWachttijdPrijs.Text;
            //labelPompTotaal.Text = wachttijdprijsentotaalpompen.ToString();
        }

        private void checkBoxParticulier_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAannemer.Checked == true && checkBoxParticulier.Checked == true)
            {
                checkBoxAannemer.Checked = false;
            }
            if (listBoxLeveringBonnen.SelectedItem != null) { 
            labelProductPrijsTotaal.Text = "0";
            prijsProduct = 0;
            if(checkBoxParticulier.Checked == true) {
                    foreach (BL.PrijsLijst prijs in prijslijsten)
                    {
                        if (prijs.Formule == ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam)
                        {
                            if (checkBoxParticulier.Checked == true)
                            {
                          
                                if (((Werf)listBoxWerven.SelectedItem).Adres == "afhaling")
                                {
                                    if (prijs.Formule == "10 Teelaar" || prijs.Formule == "11 Poussier" || prijs.Formule == "13 Spuitza" || prijs.Formule == "14 Bakstee" || prijs.Formule == "3 Breekza" || prijs.Formule == "4 0/2 Zand" || prijs.Formule == "5 0/5 Zand" || prijs.Formule == "6 0/7 Zand" || prijs.Formule == "7 2/6 Gr" || prijs.Formule == "8 6/14 Gr" || prijs.Formule == "9 3/10" || prijs.Formule == "betonzand" || prijs.Formule == "Mortel" || prijs.Formule == "9 6/20" || prijs.Formule == "2 0/40" || prijs.Formule == "betonblokken")
                                    {
                                        prijsProduct = totaalm3 * (prijs.Particulier);
                                        labelEenheidsprijs.Text = (prijs.Particulier).ToString();
                                    }
                                    else
                                    {
                                        labelEenheidsprijs.Text = (prijs.Particulier - 10).ToString();
                                        prijsProduct = totaalm3 * (prijs.Particulier - 10);
                                    }
                                  

                                }
                                else
                                {
                                    labelEenheidsprijs.Text = prijs.Particulier.ToString();
                                    prijsProduct = totaalm3 * prijs.Particulier;
                                    
                                }
                             
                            }
                        }
                    }
                    if (((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem != null))
                    {
                        if (((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Datum.DayOfWeek == DayOfWeek.Saturday && ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam.Contains("G") != true)
                        {
                            if (((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Werf.Adres == "afhaling")
                            {

                            }
                            else if (((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam.Contains("Mortel")) 
                            {
                              
                            }
                            else if (((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam.Contains("BRZ") != true)
                            {
                                double prijsEenheid = Convert.ToDouble(labelEenheidsprijs.Text) + 5;
                                labelEenheidsprijs.Text = prijsEenheid.ToString();
                                prijsProduct = totaalm3 * Convert.ToDouble(labelEenheidsprijs.Text);

                            }
                        }
                    }
                    labelProductPrijsTotaal.Text = prijsProduct.ToString("F2");
                }
            }
            else
            {
             //   MessageBox.Show("Gelieve een leveringbon aan te duiden.");
            }
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void checkBoxAannemer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxParticulier.Checked == true && checkBoxAannemer.Checked == true)
            {
                checkBoxParticulier.Checked = false;
            }
            if (listBoxLeveringBonnen.SelectedItem != null)
            {
                labelProductPrijsTotaal.Text = "0";
                prijsProduct = 0;
                if (checkBoxAannemer.Checked == true)
                {
                    foreach (BL.PrijsLijst prijs in prijslijsten)
                    {
                        if (prijs.Formule == ((NormaleLeveringBon)listBoxLeveringBonnen.SelectedItem).Formule.Naam)
                        {

                            if (((Werf)listBoxWerven.SelectedItem).Adres == "afhaling")
                            {
                                if (prijs.Formule == "10 Teelaar" || prijs.Formule == "11 Poussier" || prijs.Formule == "13 Spuitza" || prijs.Formule == "14 Bakstee" || prijs.Formule == "3 Breekza" || prijs.Formule == "4 0/2 Zand" || prijs.Formule == "5 0/5 Zand" || prijs.Formule == "6 0/7 Zand" || prijs.Formule == "7 2/6 Gr" || prijs.Formule == "8 6/14 Gr" || prijs.Formule == "9 3/10" || prijs.Formule == "betonzand" || prijs.Formule == "Mortel" || prijs.Formule == "9 6/20" || prijs.Formule == "2 0/40" || prijs.Formule == "betonblokken")
                                {
                                    prijsProduct = totaalm3 * (prijs.Aannemer);
                                    labelEenheidsprijs.Text = (prijs.Aannemer).ToString();
                                }
                                else
                                {
                                    prijsProduct = totaalm3 * (prijs.Aannemer - 10);
                                    labelEenheidsprijs.Text = (prijs.Aannemer - 10).ToString();
                                }
                            }
                            else
                            {
                                prijsProduct = totaalm3 * prijs.Aannemer;
                                  labelEenheidsprijs.Text = prijs.Aannemer.ToString();
                            }
                         
                            
                                
                            
                                
                                labelProductPrijsTotaal.Text = prijsProduct.ToString("F2");
                            
                        }
                    }
                }
            }
            else
            {
           //     MessageBox.Show("Gelieve een leveringbon aan te duiden.");
            }
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void checkBoxStabiel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBeton.Checked == true && checkBoxStabiel.Checked == true)
            {
                checkBoxBeton.Checked = false;
            }
            checkBox21Percent.Checked = true;
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void checkBoxBerekenen_CheckedChanged(object sender, EventArgs e)
        {
     

          
            if(checkBoxBerekenen.Checked == true)
            {
                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {
                   
                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if(checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if(checkBox6Percent.Checked == true)
                {
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if(checkBox21Percent.Checked == true)
                {
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
      
            }
            else
            {
                label0FactuurItem.Text = "0";
                labelVerlegdFactuurItem.Text = "0";
                label6FactuurItem.Text = "0";
                label21FactuurItem.Text = "0";
                labelTotaalFactuurItem.Text = "0";
            }
        }

        private void txtOnvolledigeladingPrijs_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void labelSoortPomp_Click(object sender, EventArgs e)
        {
            labelSoortPomp.Text = "0";
            List<PompPrijs> pompprijsLijst = PompPrijs.KrijgAllePompPrijzen();
            foreach (PompPrijs pompprijs in pompprijsLijst)
            {
                if (pompprijs.ID == 6)
                {
                    pompPrijs = pompprijs;
                }
            }
            
            labelPompZelfPrijs.Text = "0";
        }

        private void labelSoortPomp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNieuweFactuur_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = null;
            counterFacturen++;
            counterFactuuritems = 0;
            labelAantalFactuursItems.Text = counterFactuuritems.ToString();
            simpleButton1.Enabled = true;
            int factuurID = factuur1.ID;
            int indexnummercbo = cboKlanten.SelectedIndex;
            Factuur factuur2 = new Factuur(factuurID,((Klant)cboKlanten.SelectedItem), txtAfdeling.Text + txtFactuurNummer.Text, factuur1.Datum, Convert.ToDouble(label0Totaal.Text), Convert.ToDouble(labelVerlegdTotaal.Text), Convert.ToDouble(label6Totaal.Text), Convert.ToDouble(label21Totaal.Text), Convert.ToDouble(labelTotaalFactuur.Text),2);
            factuur2.update();
            try
            {
                factuur2.GeneerFactuurExcell(factuurID);
            }
            catch
            {
                XtraMessageBox.Show("Excel generen mislukt");
            }
        
            Logboek logboek = new Logboek(DateTime.Now, "FACTUREN", "[NIEUWE FACTUUR AANGEMAAKT] Factuur nummer: "+ factuur2.FactuurNummer  + " Klant: " + factuur2.Klant.Naam, user);
            logboek.MaakNieuwLogBoekPunt();
            //klantenlijstFilter.RemoveAt(indexnummercbo);
            //cboKlanten.Items.Clear();
            cboKlanten.Items.AddRange(klantenlijstFilter.ToArray());
            cboKlanten.Enabled = true;
            cboKlanten.SelectedItem = null;
            cboKlanten.Text = "";
            listBoxDatums.Items.Clear();
            txtAfdeling.Enabled = true;
            int factuurnummer = Convert.ToInt32(txtFactuurNummer.Text);
            factuurnummer++;
            labelLaadEnLostijden.Text = "0";
            txtLaadEnLostijden.Text = "0";
            txtFactuurNummer.Text = factuurnummer.ToString();
            txtFactuurNummer.Enabled = true;
            try
            {
                string bestandsNaam = factuur2.FactuurNummer + " " + factuur2.Klant.Naam;
                //if (File.Exists(@"Z:\Facturatie\" + factuur1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                //{
                //    File.Delete(@"Z:\Facturatie\" + factuur1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                //}

                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                pd.PrinterSettings.Copies = 1;
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    string BestandsNaam = factuur2.FactuurNummer + " " + factuur2.Klant.Naam;
                    // Print the file to the printer.
                    // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                    new FileInfo(@"Z:\Facturatie\" + factuur1.Datum.ToString("dd MMMM yyyy") + @"\" + BestandsNaam + ".xlsx").Print();
                    //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();
                }
            }
            catch
            {

            }
     
            labelAantalAangemaakteFacturen.Text = counterFacturen.ToString();
            factuur1 = new Factuur();
            factuur = new Factuur();
            factuur0Totaal = 0;
            factuurVerlegdTotaal = 0;
            factuur6Totaal = 0;
            factuur21Totaal = 0;
            factuurTotaal = 0;
            label0Totaal.Text = "0";
            label6Totaal.Text = "0";
            label21Totaal.Text = "0";
            labelVerlegdTotaal.Text = "0";
            labelTotaalFactuur.Text = "0";
            labelLaadEnLostijden.Text = "0";
            txtLaadEnLostijden.Text = "0";
            factuur2 = new Factuur();
            totaalgepomptm3 = 0;
            listBoxKlantKortingen.Items.Clear();
            listBoxProductKorting.Items.Clear();
            listBoxWerfKorting.Items.Clear();
            listBoxWerfEnProductKorting.Items.Clear();
            labelAantalFactuursItems.Text = "0";

            labelSoortPomp.Text = "0";
            List<PompPrijs> pompprijsLijst = PompPrijs.KrijgAllePompPrijzen();
            foreach (PompPrijs pompprijs in pompprijsLijst)
            {
                if (pompprijs.ID == 6)
                {
                    pompPrijs = pompprijs;
                }
            }
        
            labelPompZelfPrijs.Text = "0";
            if (isOpen == true)
            {
                isOpen = false;
                frmKlantNotitie.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (isOpen == true)
            {
                isOpen = false;
                frmKlantNotitie.Close();
            }
            try
            {
                Factuur factuur = Factuur.KrijgFactuurViaFactuurNummer(txtAfdeling.Text + txtFactuurNummer.Text);
                factuur.VerwijderFactuur();
            }
            catch { }
            txtFactuurNummer.Enabled = true;
            prijsHulpstof = 0;
            simpleButton1.Enabled = true;
            txtAfdeling.Enabled = true;
            cboKlanten.Enabled = true;
            factuur1 = new Factuur();
            factuur = new Factuur();
            factuur0Totaal = 0;
            factuurVerlegdTotaal = 0;
            labelEenheidsprijs.Text = "0";
            factuur6Totaal = 0;
            factuur21Totaal = 0;
            factuurTotaal = 0;
            label0Totaal.Text = "0";
            label6Totaal.Text = "0";
            label21Totaal.Text = "0";
            labelVerlegdTotaal.Text = "0";
            labelTotaalFactuur.Text = "0";
            label0FactuurItem.Text = "0";
            labelVerlegdFactuurItem.Text = "0";
            label6FactuurItem.Text = "0";
            label21FactuurItem.Text = "0";
            labelTotaalFactuurItem.Text = "0";
            listBoxHulpstoffen.Items.Clear();
            listBoxProducten.Items.Clear();
            listBoxProductKorting.Items.Clear();
            listBoxWerfKorting.Items.Clear();
            listBoxWerfEnProductKorting.Items.Clear();
            checkBoxBeton.Checked = false;
            checkBoxStabiel.Checked = false;
            checkBoxParticulier.Checked = false;
            checkBoxAannemer.Checked = false;
            txtHoeveelm3.Text = string.Empty;
            txtTotaalGepompt.Text = string.Empty;
            checkBoxOnvolledigeLading.Checked = false;
            txtPrijsTransport.Text = string.Empty;
            txtWachttijdPomp.Text = string.Empty;
            listBoxWerfKorting.ClearSelected();
            listBoxProductKorting.ClearSelected();
            listBoxWerfEnProductKorting.ClearSelected();
            checkBoxBerekenen.Checked = false;
            checkBox0percent.Checked = false;
            checkBox6Percent.Checked = false;
            checkBox21Percent.Checked = false;
            checkBoxVerlegd.Checked = false;
            labelSoortPomp.Text = "Soort";
            label0FactuurItem.Text = "0";
            labelVerlegdFactuurItem.Text = "0";
            label6FactuurItem.Text = "0";
            label21FactuurItem.Text = "0";
            labelTotaalFactuurItem.Text = "0";
            labelTransportPrijsTotaal.Text = "0";
            labelTotaalGepompt.Text = "0";
            labelPrijsTotaalOnvolledigeLading.Text = "0";
            labelTotaalPrijsHulpstof.Text = "0";
            labelTotaalKorting.Text = "0";
            labelProductPrijsTotaal.Text = "0";
            labelLaadEnLostijden.Text = "0";
            labelPompZelfPrijs.Text = "0";
            labelWerf.Text = "Gegevens";
            labelPompTotaal.Text = "0";
            labelProductOmschrijving.Text = "Gegevens";
            labelM3LeveringBon.Text = "Gegevens";
            listBoxDatums.Items.Clear();
            listBoxProducten.Items.Clear();
            listBoxWerven.Items.Clear();
            totaalgepomptm3 = 0;
            soortpomp = string.Empty;
            listBoxLeveringBonnen.Items.Clear();
            dataGridView1.DataSource = null;
        }

        private void checkBox6Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6Percent.Checked == true)
            {
                factuuritem21 = 0;
                    factuuritem6 = 0;
                    factuuritem0 = 0;
                factuuritemVerlegd = 0;
                labelVerlegdFactuurItem.Text = "0";
                label0FactuurItem.Text = "0";
                label21FactuurItem.Text = "0";
                labelTotaalFactuurItem.Text = "0";
                checkBoxVerlegd.Checked = false;
                checkBox0percent.Checked = false;
                checkBox21Percent.Checked = false;
                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {

                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }

            }
        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            listBoxKlantKortingen.Items.Clear();
            listBoxProductKorting.Items.Clear();
            listBoxWerfKorting.Items.Clear();
            listBoxWerfEnProductKorting.Items.Clear();
            // MessageBox.Show(totaalm3.ToString());
            List<Korting_Werf> korting_WervenLijst = Korting_Werf.KrijgKortingDoorWerfID(((Werf)listBoxWerven.SelectedItem).ID);
            List<Korting_Product> korting_ProductenLijst = Korting_Product.KrijgKortingDoorProductID(((Klant)cboKlanten.SelectedItem).ID, ((Formule)listBoxProducten.SelectedItem).ID);
            List<Korting_Product_Werf> korting_ProductenWerfLijst = Korting_Product_Werf.KrijgKortingDoorProductIDenWerfID(((Formule)listBoxProducten.SelectedItem).ID, ((Werf)listBoxWerven.SelectedItem).ID);
            List<Korting_Klant> korting_KlantLijst = Korting_Klant.KrijgKortingDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            listBoxProductKorting.Items.AddRange(korting_ProductenLijst.ToArray());
            listBoxWerfKorting.Items.AddRange(korting_WervenLijst.ToArray());
            listBoxWerfEnProductKorting.Items.AddRange(korting_ProductenWerfLijst.ToArray());
            listBoxKlantKortingen.Items.AddRange(korting_KlantLijst.ToArray());
        }

        private void checkBox0percent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox0percent.Checked == true)
            {
                factuuritem21 = 0;
                factuuritem6 = 0;
                factuuritem0 = 0;
                factuuritemVerlegd = 0;
                labelVerlegdFactuurItem.Text = "0";
                label6FactuurItem.Text = "0";
                label21FactuurItem.Text = "0";
                labelTotaalFactuurItem.Text = "0";
                checkBox6Percent.Checked = false;
                checkBoxVerlegd.Checked = false;
                checkBox21Percent.Checked = false;
                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {
                    factuuritem0 = 0;
                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = 0;
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem21 = 0;
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
            }
        }

        private void checkBoxVerlegd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritem21 = 0;
                factuuritem6 = 0;
                factuuritem0 = 0;
                factuuritemVerlegd = 0;
                label0FactuurItem.Text = "0";
                label6FactuurItem.Text = "0";
                label21FactuurItem.Text = "0";
                labelTotaalFactuurItem.Text = "0";
                checkBox6Percent.Checked = false;
                checkBox0percent.Checked = false;
                checkBox21Percent.Checked = false;
                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {
                    factuuritem0 = 0;
                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = 0;
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem21 = 0;
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
            }
        }

        private void checkBox21Percent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = 0;
                factuuritem6 = 0;
                factuuritem0 = 0;
                factuuritemVerlegd = 0;
                labelVerlegdFactuurItem.Text = "0";
                label6FactuurItem.Text = "0";
                label0FactuurItem.Text = "0";
                labelTotaalFactuurItem.Text = "0";
                checkBoxVerlegd.Checked = false;
                checkBox0percent.Checked = false;
                checkBox6Percent.Checked = false;
                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {
                    factuuritem0 = 0;
                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = 0;
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem0 = 0;
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }

            }
        }

        private void checkBoxBeton_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void labelAantalFactuursItems_TextChanged(object sender, EventArgs e)
        {
            if (labelAantalFactuursItems.Text == "12")
            {
                MessageBox.Show("Maximum aantal factuur items bereikt.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxBeton_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxBeton.Checked == true && checkBoxStabiel.Checked == true)
            {
                checkBoxStabiel.Checked = false;
            }
            double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
            double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
            double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
            double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
            double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
            double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
            double korting = Convert.ToDouble(labelTotaalKorting.Text);
            double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

            label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
            if (checkBox0percent.Checked == true)
            {

                factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                label0FactuurItem.Text = factuuritem0.ToString("F2");
                factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
            }
            if (checkBoxVerlegd.Checked == true)
            {
                factuuritemVerlegd = 0;
                factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox6Percent.Checked == true)
            {
                factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                label6FactuurItem.Text = factuuritem6.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
            if (checkBox21Percent.Checked == true)
            {
                factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                label21FactuurItem.Text = factuuritem21.ToString("F2");
                factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
            }
        }

        private void txtAddPrijs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double NieuwePrijs = Convert.ToDouble(labelEenheidsprijs.Text) + Convert.ToDouble(txtAddPrijs.Text);
                labelEenheidsprijs.Text = NieuwePrijs.ToString();

                double transportTotaal = Convert.ToDouble(labelTransportPrijsTotaal.Text);
                double pompTotaal = Convert.ToDouble(labelPompTotaal.Text) + Convert.ToDouble(labelPompZelfPrijs.Text);
                double pompWachttijd = Convert.ToDouble(labelWachttijdPrijs.Text);
                double laadenLostijden = Convert.ToDouble(labelLaadEnLostijden.Text);
                double onvolledigelading = Convert.ToDouble(labelPrijsTotaalOnvolledigeLading.Text);
                double hulpstofTotaal = Convert.ToDouble(labelTotaalPrijsHulpstof.Text);
                double korting = Convert.ToDouble(labelTotaalKorting.Text);
                double productPrijs = Convert.ToDouble(labelProductPrijsTotaal.Text);

                label0FactuurItem.Text = (pompWachttijd + laadenLostijden).ToString("F2");
                if (checkBox0percent.Checked == true)
                {

                    factuuritem0 = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                    label0FactuurItem.Text = factuuritem0.ToString("F2");
                    factuuritemTotaal = Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                    // factuuritemTotaal = transportTotaal + pompTotaal + pompWachttijd + laadenLostijden + onvolledigelading + hulpstofTotaal + productPrijs;
                }
                if (checkBoxVerlegd.Checked == true)
                {
                    factuuritemVerlegd = 0;
                    factuuritemVerlegd = transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs;
                    labelVerlegdFactuurItem.Text = factuuritemVerlegd.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox6Percent.Checked == true)
                {
                    factuuritem6 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.06;
                    label6FactuurItem.Text = factuuritem6.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21) + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
                if (checkBox21Percent.Checked == true)
                {
                    factuuritem21 = (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs) * 0.21;
                    label21FactuurItem.Text = factuuritem21.ToString("F2");
                    factuuritemTotaal = (Convert.ToDouble(label0FactuurItem.Text) + factuuritemVerlegd + factuuritem6 + factuuritem21 + (transportTotaal + pompTotaal + onvolledigelading + hulpstofTotaal + productPrijs)) - korting;
                    labelTotaalFactuurItem.Text = factuuritemTotaal.ToString("F2");
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void labelEenheidsprijs_Click(object sender, EventArgs e)
        {
            List<BL.PrijsLijst> prijslijst = BL.PrijsLijst.KrijgAlleOmschrijvingen();
            string formulenaam = ((Formule)listBoxProducten.SelectedItem).Naam;
            foreach(BL.PrijsLijst prijs in prijslijst)
            {
                if(prijs.Formule == formulenaam && checkBoxAannemer.Checked == true)
                {
                    labelEenheidsprijs.Text = prijs.Aannemer.ToString();          
                }
                else if (prijs.Formule == formulenaam && checkBoxAannemer.Checked == true)
                {
                    labelEenheidsprijs.Text = prijs.Aannemer.ToString();
                }
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmhoofd.facturatieOpen = false;
            frmhoofd.container.Controls.Clear();

            ucHoofdvenster ucHoofdvenster = new ucHoofdvenster(user, "Versie 3.2", null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }
    }
    public static class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
        public static void Print(this FileInfo value)
        {
            if (!value.Exists)
                throw new FileNotFoundException("File doesn't exist");
            Process p = new Process();
            p.StartInfo.FileName = value.FullName;
            p.StartInfo.Verb = "Print";
            p.Start();
        }
    }
}
