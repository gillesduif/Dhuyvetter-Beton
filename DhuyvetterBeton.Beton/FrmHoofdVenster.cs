using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DhuyvetterBeton.Beton.Bestelling;
using DhuyvetterBeton.Beton.Klanten;
using DhuyvetterBeton.Beton.Werven;
using DhuyvetterBeton.Beton.Producten;
using DhuyvetterBeton.Beton.Pompen;
using DhuyvetterBeton.Beton.PrijsLijst;
using DhuyvetterBeton.Beton.Kortingen;
using DhuyvetterBeton.Beton.Facturen;
using BL;
using Tulpep.NotificationWindow;
using DhuyvetterBeton.Beton.Agenda;
using DhuyvetterBeton.Beton.Properties;
using System.Net;
using System.Diagnostics;
using System.IO;
using DhuyvetterBeton.Beton.Offertes;
using DhuyvetterBeton.Beton.Personeel;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Shell;
using DhuyvetterBeton.Beton.Website;
using DevExpress.XtraEditors;
using Google.Cloud.Firestore;
using DhuyvetterBeton.Beton.PersoneelD;
using DhuyvetterBeton.Beton.Bestelling.Tools;

namespace DhuyvetterBeton.Beton
{
    public partial class FrmHoofdVenster : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
       public bool facturatieOpen = false;
        bool controleFacturatie = false;
        #region Bedrijfcijfers
        ucNieuweBestelling ucNieuweBestelling;
        FrmHoofdVenster frmhoofd;
   //     Klant klant;
        int aantalklanten = Klant.KrijgAantalKlanten();
        int aantalWerven = Werf.KrijgAantalWerven();
        int aantalProducten = Formule.KrijgAantalFormules();
        int aantalBestellingen = BL.Bestelling.krijgAantalBestellingen();
        int aantalLeveringBonnen = NormaleLeveringBon.KrijgAantalBonnen();
        int aantalFacturen = BL.Bestelling.KrijgAantalFacturen();
        List<BL.Bestelling> bestellingen = new List<BL.Bestelling>();

        #endregion
        int aantalBestelling = 0;
        string User = string.Empty;
        FrmWelkom frmWelkom;
        string picURL = "http://www.dhuyvetterbeton.website/img/restaurant/chefs/";
        //Form someForm;
        List<Klant> klantenLijst;
        int laatsteKlantID = 0;
        public List<BL.Bestelling>Bestellings { get; set; }
        public FrmHoofdVenster(string User1)
        {
            klantenLijst   = Klant.KrijgAlleKlanten();
            bestellingen   = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);
            Bestellings    = bestellingen;
            laatsteKlantID = Klant.krijgLaatsteKlantID();
            klantenLijst.Sort((x, y) => x.ID.CompareTo(y.ID));
           // klant = klantenLijst.Last();
            klantenLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));

            foreach (Klant klant in klantenLijst)
            {
                if (klant.Naam.Contains("W8"))
                {
                    klant.BetaalCode = "Rood";
                    klant.UpdateKlantGegevens();
                }
            }
            InitializeComponent();


            try
            {
                frmhoofd = this;
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);
                string USERNAME = File.ReadAllText(fileName);
                if (USERNAME != "Pedro")
                {
                    User1 = USERNAME;
                   
                }
                

            }
            catch
            {

            }

            if (File.Exists("C:\\Users\\jan\\Desktop\\UPDATE\\UpdateProgrammaDH.exe"))
            {
                User1 = "Jan";
            }
            if (File.Exists("C:\\Users\\tania\\Desktop\\UPDATE\\UpdateProgrammaDH.exe"))
            {
                User1 = "Tania";
            }
            if (User1 == null)
            {
                frmWelkom = new FrmWelkom();

                frmWelkom.Show();
                container.Controls.Clear();
                closingfrmWelkom();

            }
            else
            {
                User = User1;

                if (User == "Cindy" || User == "Jenny")
                {
                    picURL = picURL + User + ".png";
                    accordionControlElement6.Expanded = false;
                    accordionControlElement7.Expanded = false;
                    accordionControlElement8.Expanded = false;
                    accordionControlElement12.Expanded = false;
                    accordionControlElement5.Expanded = true;
                }
                else if (User == "Yara")
                {
                    accordionControlElement5.Expanded = false;
                    accordionControlElement7.Expanded = false;
                    accordionControlElement12.Expanded = false;
                    picURL = picURL + User + ".png";

                }
             
                else if (User == "Jan")
                {
                   
                    accordionControlElement7.Expanded = false;
                    accordionControlElement8.Expanded = false;
                    accordionControlElement12.Expanded = false;
                    picURL = picURL + User + ".png";
                    accordionControlElement5.Expanded = true;
                    List<Verlof> verlofPersoneelmin3dagen = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+3));
                    List<Verlof> verlofPersoneelmin2dagen = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+2));
                    List<Verlof> verlofPersoneelmin1dag = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+1));
                    List<Verlof> verlofPersoneelvandaag = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today);
                    if (verlofPersoneelmin3dagen.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelmin3dagen)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 3 dagen.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (verlofPersoneelmin2dagen.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelmin2dagen)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 2 dagen.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (verlofPersoneelmin1dag.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelmin1dag)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 1 dag.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (verlofPersoneelvandaag.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelvandaag)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " heeft congé.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (User == "Tania")
                {
                    picURL = picURL + User + ".png";

                }
                else if (User == "Pedro")
                {
                    picURL = picURL + User + ".png";
                }
                else if (User == "Fabien")
                {
                    picURL = picURL + User + ".png";
                }
                else if (User == "Gilles")
                {
                    picURL = picURL + User + ".png";
                }

            }
            container.Controls.Clear();
            ucAgendaBeton ucAgendaBeton = new ucAgendaBeton(User, label1.Text, bestellingen);
            if (!container.Controls.Contains(ucAgendaBeton))
            {
                container.Controls.Add(ucAgendaBeton);
            }



        }

        private void closingfrmWelkom()
        {
         
            frmWelkom.FormClosing += (sender, eventArgs) =>
            {
                User = frmWelkom.ReturnValue1;
                timer2.Start();
                //VERSIE CHECKUP
                if (User != "Pedro" && User != "Fabien" && User != "Gilles")
                {
                    try
                    {
                        string text = File.ReadAllText("Z:\\Bestelling programma\\Versie\\V.txt");

                        if (label1.Text != text)
                        {
                            btnUpdate.Visible = true;
                            //buttonUpdate.Visible = true;
                            labelUpdate.Visible = true;
                            DialogResult dr = XtraMessageBox.Show("Er is een update beschikbaar. Wilt u deze nu installeren?",
                                  "Update beschikbaar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            switch (dr)
                            {
                                case DialogResult.Yes:
                                    Process.Start(@"C:\Users\" + User + "\\Desktop\\UPDATE\\UpdateProgrammaDH.exe");
                                    this.Close();
                                    break;
                                case DialogResult.No:
                                    break;
                            }

                        }
                    }
                    catch { }

                }
                else if (User == "Pedro")
                {
                    accordionControlElement5.Visible = false;
                    accordionControlElement5.Expanded = true;
                    accordionControlElement4.Visible = false;
                    accordionControlElement5.Visible = true;
                    accordionControlElement6.Visible = false;
                    accordionControlElement8.Visible = false;
                    accordionControlElement9.Visible = false;
                    accordionControlElement30.Visible = false;
                    accordionControlElement7.Expanded = true;
                    //ribbonPageGroup14.Visible = true;
                    //FrmAgenda frm = new FrmAgenda(User,true);
                    //frm.MdiParent = this;
                    //frm.Show();
                }
                else if (User == "Fabien")
                {
                    accordionControlElement5.Visible = true;
                    accordionControlElement5.Expanded = true;
                    accordionControlElement4.Visible = false;
                    accordionControlElement5.Visible = true;
                    accordionControlElement6.Visible = false;
                    accordionControlElement8.Visible = false;
                    accordionControlElement9.Visible = false;
                    accordionControlElement30.Visible = false;
                    accordionControlElement7.Expanded = true;
                    //FrmAgenda frm = new FrmAgenda(User,true);
                    //frm.MdiParent = this;
                    //frm.Show();
                }
                else if (User == "Gilles")
                {
                    ribbonPageWebsite.Visible = true;


                }
                if (User == "Pedro" || User == "Fabien")
                {
                    List<Verlof> verlofPersoneelmin3dagen = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+3));
                    List<Verlof> verlofPersoneelmin2dagen = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+2));
                    List<Verlof> verlofPersoneelmin1dag = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+1));
                    List<Verlof> verlofPersoneelvandaag = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today);
                    if (verlofPersoneelmin3dagen.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelmin3dagen)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 3 dagen.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (verlofPersoneelmin2dagen.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelmin2dagen)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 2 dagen.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (verlofPersoneelmin1dag.Count > 0)
                    {
                        foreach (Verlof verlof in verlofPersoneelmin1dag)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 1 dag.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (verlofPersoneelvandaag.Count > 0)
                    { 
                        foreach (Verlof verlof in verlofPersoneelvandaag)
                        {
                            XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " heeft congé.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }


                if (User == "Yara" || User == "Jan")
                {
                 
                    accordionControlElement5.Expanded = true;
                    container.Controls.Clear();
                    ucHoofdvenster ucHoofdvenster1 = new ucHoofdvenster(User, label1.Text, bestellingen);
                    if (!container.Controls.Contains(ucHoofdvenster1))
                    {
                        container.Controls.Add(ucHoofdvenster1);
                    }
                   // List<Factuur> FactuurLijst = Factuur.KrijgTeControlerenFacturen();
                  
                }
                //END
                if (User == "Cindy" || User == "Jenny") 
                {
                    accordionControlElement6.Expanded = false;
                    accordionControlElement7.Expanded = false;
                    accordionControlElement8.Expanded = false;
                    picURL = picURL + User + ".png";
                }
                else if (User == "Yara") 
                {
                    accordionControlElement5.Expanded = false;
                    accordionControlElement7.Expanded = false;
                    accordionControlElement12.Expanded = false;
                    picURL = picURL + User + ".png"; ; 
                }
                else if (User == "Loes") { picURL = picURL + User + ".png"; }
                else if (User == "Jan")
                {
                   
                   
                    picURL = picURL + User + ".png";
                    ribbonPageBestelling.Visible = true;
                    ribbonPageKlanten.Visible = true;
                    ribbonPageWerven.Visible = true;
                    ribbonPageFacturen.Visible = true;
                    ribbonPageGroup6.Visible = true;
                    ribbonPageGroup14.Visible = true;
                    ribbonPageGroupCentraleAfdrukken.Visible = true;
                    ribbonPageGroup1.Visible = false;
                    ribbonPageOffertes.Visible = true;
                    ribbonPageProduct.Visible = true;
                    ribbonPagePrijzen.Visible = true;
                    ribbonPagePomp.Visible = true;
                    ribbonPageAgenda.Visible = true;
                    ribbonPageRapport.Visible = true;
                }
                else if (User == "Tania")
                {
                    picURL = picURL + User + ".png";
                    ribbonPageBestelling.Visible = true;
                    ribbonPageKlanten.Visible = true;
                    ribbonPageWerven.Visible = true;
                    ribbonPageFacturen.Visible = true;
                    ribbonPageGroup6.Visible = true;
                    ribbonPageGroupCentraleAfdrukken.Visible = true;
                    ribbonPageGroup1.Visible = false;
                    ribbonPageOffertes.Visible = true;
                    ribbonPageProduct.Visible = true;
                    ribbonPagePrijzen.Visible = true;
                    ribbonPagePomp.Visible = true;
                    ribbonPageAgenda.Visible = true;
                    ribbonPageRapport.Visible = true;
                }
                else if (User == "Pedro")
                {
                    picURL = picURL + User + ".png";
                    ribbonPageBestelling.Visible = true;
                    ribbonPageAgenda.Visible = true;
                    ribbonPageRapport.Visible = true;
                    ribbonPageGroup1.Visible = true;
                    ribbonPageGroup14.Visible = true;
                    ribbonPageGroup6.Visible = false;

                }
                else if (User == "Fabien")
                {
                    picURL = picURL + User + ".png";
                    ribbonPageAgenda.Visible = true;
                    ribbonPageRapport.Visible = true;
                    //FrmAgenda frm = new FrmAgenda(User,true);
                    //frm.MdiParent = this;
                    //frm.Show();
                }
                else if (User == "Gilles")
                {
                    picURL = picURL + User + ".png";
                    ribbonPageBestelling.Visible = true;
                    ribbonPageKlanten.Visible = true;
                    ribbonPageWerven.Visible = true;
                    ribbonPageFacturen.Visible = true;
                    ribbonPageGroup6.Visible = true;
                    ribbonPageGroupCentraleAfdrukken.Visible = true;
                    ribbonPageGroup1.Visible = true;
                    ribbonPageOffertes.Visible = true;
                    ribbonPageProduct.Visible = true;
                    ribbonPagePrijzen.Visible = true;
                    ribbonPagePomp.Visible = true;
                    ribbonPageAgenda.Visible = true;
                    ribbonPageRapport.Visible = true;
                }

                int uur = DateTime.Now.Hour;
                if (uur < 4)
                {
                    labelWelkom.Text = "Goedeavond " + User;

                }
                else if (uur < 11)
                {
                    labelWelkom.Text = "Goedemorgen " + User;
                }
                else if (uur < 17)
                {
                    labelWelkom.Text = "Goedemiddag " + User;
                }
                else if (uur < 23)
                {
                    labelWelkom.Text = "Goedeavond " + User;
                }
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var request = WebRequest.Create(picURL);

                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {

                        pictureEdit1.Image = Bitmap.FromStream(stream);
                    }
                }

                catch { }
                if (User == "Jan" || User == "Cindy" || User == "Jenny")
                {
                    accordionPrefab.Visible = true;
                    if (User == "Jan")
                    {
                       
                        accordionPrefab.Expanded = false;
                    }
                }
                container.Controls.Clear();
                if (User == "Fabien" || User == "Pedro")
                {
                    container.Controls.Clear();

                    ucAgendaBeton ucAgendaBeton = new ucAgendaBeton(User, label1.Text, bestellingen);
                    if (!container.Controls.Contains(ucAgendaBeton))
                    {
                        container.Controls.Add(ucAgendaBeton);
                    }
                }
                else
                {
                    if(controleFacturatie != true)
                    {
                        ucAgendaBeton ucAgendaBeton = new ucAgendaBeton(User, label1.Text, bestellingen);
                        if (!container.Controls.Contains(ucAgendaBeton))
                        {
                            container.Controls.Add(ucAgendaBeton);
                        }
                    }
                    else
                    {
                        ucOverzichtFacturen ucoverzichtFacturen = new ucOverzichtFacturen(User, this, label1.Text,true);
                        if (!container.Controls.Contains(ucoverzichtFacturen))
                        {
                            container.Controls.Add(ucoverzichtFacturen);
                        }
                    }
                }

            };

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
     
            Cursor.Current = Cursors.WaitCursor;
            if (User == "Cindy")
            {
                FrmMessage frm = new FrmMessage("Voor welke afdeling moet er een bestelling geplaatst worden?", "Beton", "Prefab", User);
                frm.MdiParent = this;
                frm.Show();
            }
            else if (User == "Jan")
            {
                FrmMessage frm = new FrmMessage("Voor welke afdeling moet er een bestelling geplaatst worden?", "Beton", "Prefab", User);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {

               
            }

         
        }

        private void Welkom()
        {
           
        }

        private void FrmTestWelkom_Load(object sender, EventArgs e)
        {


            timer2.Start();



            //frmPersoneelFirst.MdiParent = this;

            //VERSIE CHECKUP
            if (User != "Pedro" && User != "Fabien" && User != "Gilles")
            {
                try
                {
                    string text = File.ReadAllText("Z:\\Bestelling programma\\Versie\\V.txt");

                    if (label1.Text != text)
                    {
                        btnUpdate.Visible = true;
                        DialogResult dr = XtraMessageBox.Show("Nieuwe versie beschikbaar. Wenst u deze update nu te installeren?",
                              "Update beschikbaar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                Process.Start(@"C:\Users\" + User + "\\Desktop\\UPDATE\\UpdateProgrammaDH.exe");
                                Application.Exit();
                                break;
                            case DialogResult.No:
                                break;
                        }

                    }
                }
                catch { }

            }
            
            else if (User == "Gilles")
            {
                ribbonPageWebsite.Visible = true;
                ribbonPageOffertes.Visible = true;
            }
            if (User == "Pedro" || User == "Fabien")
            {
                //deleted test
                List<Verlof> verlofPersoneelmin3dagen = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+3));
                List<Verlof> verlofPersoneelmin2dagen = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+2));
                List<Verlof> verlofPersoneelmin1dag = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today.AddDays(+1));
                List<Verlof> verlofPersoneelvandaag = Verlof.KrijgAlleVerlofDagenDoorDatum(DateTime.Today);
                if (verlofPersoneelmin3dagen.Count > 0)
                {
                    foreach (Verlof verlof in verlofPersoneelmin3dagen)
                    {
                        XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 3 dagen.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (verlofPersoneelmin2dagen.Count > 0)
                {
                    foreach (Verlof verlof in verlofPersoneelmin2dagen)
                    {
                        XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 2 dagen.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (verlofPersoneelmin1dag.Count > 0)
                {
                    foreach (Verlof verlof in verlofPersoneelmin1dag)
                    {
                        XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " zijn/haar verlof start binnen 1 dag.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (verlofPersoneelvandaag.Count > 0)
                {
                    foreach (Verlof verlof in verlofPersoneelvandaag)
                    {
                        XtraMessageBox.Show(verlof.PersoneelsLid.Naam + " heeft congé.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


            if (User == "Yara" || User == "Jan" || User == "Cindy")
            {
             

                container.Controls.Clear();
                ucAgendaBeton ucAgendaBeton = new ucAgendaBeton(User, label1.Text, bestellingen);
                if (!container.Controls.Contains(ucAgendaBeton))
                {
                    container.Controls.Add(ucAgendaBeton);
                }
            }
            //END
            if (User == "Cindy" || User == "Jan" || User == "Jenny")
            {
                accordionPrefab.Visible = true;
            }
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var request = WebRequest.Create(picURL);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {

                    pictureEdit1.Image = Bitmap.FromStream(stream);
                }
            }
            catch { }


            List<BL.Bestelling> BestellingenOphalen = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);
            aantalBestelling = BestellingenOphalen.Count;

            //FrmAgenda frm = new FrmAgenda();
            //frm.MdiParent = this;
            //frm.Show();
            //Welkom();

            // someForm.Hide();
            int uur = DateTime.Now.Hour;
            if (uur < 4)
            {
                labelWelkom.Text = "Goedeavond " + User;

            }
            else if (uur < 11)
            {
                labelWelkom.Text = "Goedemorgen " + User;
            }
            else if (uur < 17)
            {
                labelWelkom.Text = "Goedemiddag " + User;
            }
            else if (uur < 23)
            {
                labelWelkom.Text = "Goedeavond " + User;
            }
            timer3.Start(); timer4.Start(); timer5.Start(); timer6.Start(); timer7.Start(); timer8.Start();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (User != "Cindy")
            {
                Cursor.Current = Cursors.AppStarting;
               

            }
            else
            {
                FrmMessage frm = new FrmMessage("Voor welke afdeling moet er een klant aangemaakt worden?", "Beton", "Prefab", User);
                frm.MdiParent = this;
                frm.Show();
            }


        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (User != "Cindy")
            {
                Cursor.Current = Cursors.AppStarting;
          
                FrmNieuweWerf frm = new FrmNieuweWerf(null, User);
                frm.MdiParent = this;
                frm.Show();
              

            }
            else
            {
                FrmMessage frm = new FrmMessage("Voor welke afdeling moet er een werf aangemaakt worden?", "Beton", "Prefab", User);
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            FrmWijzigenWerf frm = new FrmWijzigenWerf(null, null, User);
            frm.MdiParent = this;
            frm.Show();
      
        }



        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("nog te coderen.");
        }



        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
         
            Cursor.Current = Cursors.WaitCursor;


            if (User == "Cindy")
            {

                FrmMessage frm = new FrmMessage("Voor welke afdeling moet er een bestelling aangepast worden?", "Beton", "Prefab", User);
                frm.MdiParent = this;
                frm.Show();
            }
            else if (User == "Jan")
            {
                FrmMessage frm = new FrmMessage("Voor welke afdeling moet er een bestelling aangepast worden?", "Beton", "Prefab", User);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {

              
            }
            

        }

        private void barHeaderItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //splashScreenManager4.ShowWaitForm();
            //FrmAgenda frm = new FrmAgenda(User);
            //frm.MdiParent = this;
            //frm.Show();
            //splashScreenManager4.CloseWaitForm();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }


        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWerfVerwijderen frm = new FrmWerfVerwijderen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWerfVerwijderen frm = new FrmWerfVerwijderen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            FrmNieuweKortingWerf frm = new FrmNieuweKortingWerf();
            frm.MdiParent = this;
            frm.Show();

        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
        
            Cursor.Current = Cursors.WaitCursor;
            FrmPrijsBeheer frm = new FrmPrijsBeheer();
            frm.MdiParent = this;
            frm.Show();
        
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
     
            Cursor.Current = Cursors.WaitCursor;
            FrmNieuweKortingProduct frm = new FrmNieuweKortingProduct();
            frm.MdiParent = this;
            frm.Show();
           
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
      
            Cursor.Current = Cursors.WaitCursor;
            FrmNieuweKortingProductWerf frm = new FrmNieuweKortingProductWerf();
            frm.MdiParent = this;
            frm.Show();
           
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.WaitCursor;
            FrmNieuweFactuur frm = new FrmNieuweFactuur(User,this);
         //   frm.MdiParent = this;
            frm.Show();

        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
      
            Cursor.Current = Cursors.WaitCursor;
            FrmPompPrijzen frm = new FrmPompPrijzen();
            frm.MdiParent = this;
            frm.Show();
       
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            Cursor.Current = Cursors.WaitCursor;
            FrmHulpstofPrijzen frm = new FrmHulpstofPrijzen();
            frm.MdiParent = this;
            frm.Show();
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<BL.Bestelling> BestellingenOphalenTimere = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);
            if (aantalBestelling != BestellingenOphalenTimere.Count)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Nieuwe bestelling!";
                popup.ContentText = "Nieuwe bestelling gevonden herstart het programma.";
                popup.Popup();

                aantalBestelling = BestellingenOphalenTimere.Count;
            }
            else
            {
                timer1.Stop();
                timer1.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
        
        }



        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }


        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmPrijsSetting frm = new FrmPrijsSetting();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmKlantNotitie frm = new FrmKlantNotitie(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem45_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmPrijsSetting frm = new FrmPrijsSetting();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmOpenFacturen frm = new FrmOpenFacturen();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmMailFacturen frm = new FrmMailFacturen(User);
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmSoortKorting frm = new FrmSoortKorting();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmWijzigFactuur frm = new FrmWijzigFactuur();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Users\" + User + "\\Desktop\\Bureel\\Dhuyvetter Beton - Bureele.exe");
                this.Close();
            }
            catch { }
            this.Close();

        }

        private void FrmHoofdVenster_FormClosed(object sender, FormClosedEventArgs e)
        {
          //  System.Windows.Forms.Application.Exit();
        }

        private void barButtonItem51_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmBugReport frm = new FrmBugReport(User);
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem52_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmBugReportOverzicht frm = new FrmBugReportOverzicht();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
      
        }

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmNieuweOfferte frm = new FrmNieuweOfferte();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FrmWijzigOfferte frm = new FrmWijzigOfferte();
            frm.MdiParent = this;
            frm.Show();

        }

        private void barButtonItem60_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem59_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmVerlofAgenda frm = new FrmVerlofAgenda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                string text = File.ReadAllText("Z:\\Bestelling programma\\Versie\\V.txt");

                if (label1.Text != text)
                {
                    btnUpdate.Visible = true;
                    labelUpdate.Visible = true;

                }
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + User + "\\Desktop\\UPDATE\\UpdateProgrammaDH.exe");
            this.Close();
        }

        private void ribbon_DockChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLogboek frm = new FrmLogboek(User);
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem64_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmVerlofAgenda frm = new FrmVerlofAgenda();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPersoneelToevoegen frm = new FrmPersoneelToevoegen();
            frm.MdiParent = this;
            frm.Show();
        }

     
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement14_Click(object sender, EventArgs e)
        {
            if (User != " ")
            {
                if(facturatieOpen != true)
                {
                    FrmHoofdVenster frmhoofd = this;
                    container.Controls.Clear();
                    ucNieuweBestelling = new ucNieuweBestelling(User, frmhoofd, label1.Text, bestellingen);

                    if (!container.Controls.Contains(ucNieuweBestelling))
                    {

                        container.Controls.Add(ucNieuweBestelling);

                    }
                }
                else
                {

                }
               
            }
            else
            {
             
            }

        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {


            container.Controls.Clear();

            ucWijzigBestelling ucWijzigBestelling = new ucWijzigBestelling(null, User, frmhoofd, label1.Text);
            if (!container.Controls.Contains(ucWijzigBestelling))
            {
                container.Controls.Add(ucWijzigBestelling);
            }
        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {

            container.Controls.Clear();
            ucVerwijderBestelling ucVerwijderBestelling = new ucVerwijderBestelling(User, frmhoofd, label1.Text);
            if (!container.Controls.Contains(ucVerwijderBestelling))
            {
                container.Controls.Add(ucVerwijderBestelling);
            }
        }

     

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void accordionControl1_MouseMove(object sender, MouseEventArgs e)
        {
            accordionControl1.ContextButtonsOptions.ItemCursor = Cursors.Hand;

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucAgendaBeton ucAgendaBeton = new ucAgendaBeton(User, label1.Text, bestellingen);
            if (!container.Controls.Contains(ucAgendaBeton))
            {
                container.Controls.Add(ucAgendaBeton);
            }
        }

        private void accordionControlElement19_Click(object sender, EventArgs e)
        {

       
            try
            {
                laatsteKlantID = Klant.krijgLaatsteKlantID();
            }
            catch
            {

            }
          
                klantenLijst = Klant.KrijgAlleKlanten();
                klantenLijst.Sort((x, y) => x.ID.CompareTo(y.ID));
               // klant = klantenLijst.Last();
                klantenLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            


            container.Controls.Clear();
            ucToevoegenKlant ucToevoegenKlant = new ucToevoegenKlant(User, frmhoofd, label1.Text, klantenLijst);
            if (!container.Controls.Contains(ucToevoegenKlant))
            {
                container.Controls.Add(ucToevoegenKlant);
            }
        }

        private void accordionControlElement20_Click(object sender, EventArgs e)
        {
          

        
                klantenLijst = Klant.KrijgAlleKlanten();
                klantenLijst.Sort((x, y) => x.ID.CompareTo(y.ID));
              //  klant = klantenLijst.Last();
               klantenLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            

            container.Controls.Clear();
            ucWijzigenKlant ucWijzigenKlant = new ucWijzigenKlant(User, frmhoofd, label1.Text, klantenLijst);
            if (!container.Controls.Contains(ucWijzigenKlant))
            {
                container.Controls.Add(ucWijzigenKlant);
            }
        }

        private void accordionControlElement34_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucAgendaBeton ucAgendaBeton = new ucAgendaBeton(User, label1.Text, bestellingen);
            if (!container.Controls.Contains(ucAgendaBeton))
            {
                container.Controls.Add(ucAgendaBeton);
            }
        }

        private void accordionControlElement35_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucBestellingenLijst ucBestellingenLijst = new ucBestellingenLijst();
            if (!container.Controls.Contains(ucBestellingenLijst))
            {
                container.Controls.Add(ucBestellingenLijst);
            }
        }

        private void accordionControlElement39_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucPersoneel ucPersoneel = new ucPersoneel(User, frmhoofd, label1.Text);
            if (!container.Controls.Contains(ucPersoneel))
            {
                container.Controls.Add(ucPersoneel);
            }
        }

        private void accordionControlElement36_Click(object sender, EventArgs e)
        {
            FrmBugReport frm = new FrmBugReport(User);
            frm.Show();
        }

        private void accordionControlElement37_Click(object sender, EventArgs e)
        {
            FrmBugReportOverzicht frm = new FrmBugReportOverzicht();
            frm.Show();
        }

        private void accordionControlElement38_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucLogboek ucLogboek = new ucLogboek(User, this, label1.Text);
            if (!container.Controls.Contains(ucLogboek))
            {
                container.Controls.Add(ucLogboek);
            }
        }

        private void accordionControlElement42_Click(object sender, EventArgs e)
        {
            FrmOpenFacturen frm = new FrmOpenFacturen();
            frm.Show();
        }

        private void accordionControlElement41_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucMailFacturen ucMailFacturen = new ucMailFacturen(this, User, label1.Text);
            if (!container.Controls.Contains(ucMailFacturen))
            {
                container.Controls.Add(ucMailFacturen);
            }
        }

        private void accordionControlElement40_Click(object sender, EventArgs e)
        {
            facturatieOpen = true;
          
            container.Controls.Clear();
            FrmNieuweFactuur FrmnieuweFactuur = new FrmNieuweFactuur(User,this);
            if (!container.Controls.Contains(FrmnieuweFactuur))
            {
                container.Controls.Add(FrmnieuweFactuur);
            }
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement46_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucPompen ucPompen = new ucPompen(User, this, label1.Text);
            if (!container.Controls.Contains(ucPompen))
            {
                container.Controls.Add(ucPompen);
            }
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement31_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucProductenBeheer ucProductenBeheer = new ucProductenBeheer(User, this, label1.Text);
            if (!container.Controls.Contains(ucProductenBeheer))
            {
                container.Controls.Add(ucProductenBeheer);
            }
        }

        private void accordionControlElement24_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucWerven ucWerven = new ucWerven(User, this, label1.Text);
            if (!container.Controls.Contains(ucWerven))
            {
                container.Controls.Add(ucWerven);
            }
        }

        private void accordionControlElement44_Click(object sender, EventArgs e)
        {
            FrmSoortKorting frm = new FrmSoortKorting();
            frm.Show();
        }

        private void accordionControlElement45_Click(object sender, EventArgs e)
        {
            FrmPrijsBeheer frm = new FrmPrijsBeheer();
            frm.Show();
        }

        private void accordionControlElement22_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucNieuweBestellingPrefab ucNieuweBestellingPrefab = new ucNieuweBestellingPrefab(frmhoofd, User, label1.Text);
            if (!container.Controls.Contains(ucNieuweBestellingPrefab))
            {
                container.Controls.Add(ucNieuweBestellingPrefab);
            }
        }

        private void accordionControlElement23_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucWijzigPrefabBestelling ucWijzigPrefabBestelling = new ucWijzigPrefabBestelling(frmhoofd, User, label1.Text);
            if (!container.Controls.Contains(ucWijzigPrefabBestelling))
            {
                container.Controls.Add(ucWijzigPrefabBestelling);
            }
        }

        private void FrmHoofdVenster_Shown(object sender, EventArgs e)
        {

        }

        private void accordionControlElement29_Click(object sender, EventArgs e)
        {
            FrmKlantNotitie frm = new FrmKlantNotitie(null);
            frm.Show();
        }

        private void accordionControlElement32_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucProductToevoegen ucProductToevoegen = new ucProductToevoegen(frmhoofd, User, label1.Text);
            if (!container.Controls.Contains(ucProductToevoegen))
            {
                container.Controls.Add(ucProductToevoegen);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + User + "\\Desktop\\UPDATE\\UpdateProgrammaDH.exe");
            this.Close();
        }

        private void container_ControlRemoved(object sender, ControlEventArgs e)
        {

            //if (opstart != true && indexopstart == 12)
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;
            //        bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today.Date);
            //        ucHoofdvenster.bestellingPublic = bestellingen;
            //    }

            //    catch
            //    {

            //    }
            //}
            //else
            //{
            //    indexopstart++;
            //    opstart = false;
            //}



        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void labelWelkom_Click(object sender, EventArgs e)
        {
            List<Klant> klantenlijst = Klant.KrijgAlleKlanten();


            foreach (Klant klant in klantenlijst)
            {
                string klantNaamOld = klant.Naam;
                string klantNaamNieuw = char.ToUpper(klantNaamOld[0]).ToString() + klantNaamOld.Substring(1);
                Debug.WriteLine(klantNaamNieuw);
            }
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement43_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            FrmPompPrijzen frm = new FrmPompPrijzen();
            frm.Show();
        }
        FirestoreDb db;
        private void accordionControlElement25_Click(object sender, EventArgs e)
        {
            frmSMSBerichten frm = new frmSMSBerichten();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Left = 1090;
            frm.Top = 450;
            frm.Show();
            
            // string path = AppDomain.CurrentDomain.BaseDirectory + @"dbintern-56185-firebase-adminsdk-50c46-700d8feb2f.json";
           // Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
           // db = FirestoreDb.Create("dbintern-56185");
           // MessageBox.Show("succesvol");
           // //Get_Multiple_Documents_From_A_Collection();
           // List<BL.Bestelling> bestellings = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today.AddDays(1));
           // foreach(BL.Bestelling bestelling in bestellings)
           // { 
           //     Add_Documents(bestelling);
           // }
            
        }
        void Add_Documents(BL.Bestelling bestelling)
        {
            DateTime datum = bestelling.Datum.AddHours(-1);
            int unixTimestamp = (int)datum.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            DocumentReference DOC = db.Collection("Bestellingen").Document(bestelling.ID.ToString());
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"klant", bestelling.Klant.Naam},
                {"werf",bestelling.Werf.ToString()},
                {"datum",unixTimestamp },
                {"aantal",bestelling.M3.ToString()},
                {"product",bestelling.Formule.Naam},
                {"pomp",bestelling.Pomp.PompLeverancier},
                {"leveringMethode",bestelling.LeveringWijze },
                {"losMethode",bestelling.Loswijze},
                {"opmerking",bestelling.Comment }
            };
            DOC.SetAsync(data1);
        }

        async void Get_Multiple_Documents_From_A_Collection()
        {
            Query Qref = db.Collection("Bestellingen");
            // .WhereEqualTo("Province","Sindh")
            // .Limit(1)
            // .OrderBy("Population");
            QuerySnapshot snap = await Qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                OrderApp orderApp = docsnap.ConvertTo<OrderApp>();

                if (docsnap.Exists)
                {
                    MessageBox.Show("Klant: " + orderApp.klant + System.Environment.NewLine + "Product:" + orderApp.product + System.Environment.NewLine + "Hoeveelheid: " + orderApp.aantal);
                }
            }
        }

        private void accordionControlElement27_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            container.Controls.Clear();
            ucOverzichtFacturen ucoverzichtFacturen = new ucOverzichtFacturen(User, this, label1.Text,false);
            if (!container.Controls.Contains(ucoverzichtFacturen))
            {
                container.Controls.Add(ucoverzichtFacturen);
            }
        }

        private void accordionControlElement26_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            container.Controls.Clear();
            ucFactuurWijzigen ucFactuurWijzigen = new ucFactuurWijzigen();
            if (!container.Controls.Contains(ucFactuurWijzigen))
            {
                container.Controls.Add(ucFactuurWijzigen);
            }
        }

        private void accordionControlElement43_Click_1(object sender, EventArgs e)
        {
            container.Controls.Clear();
            ucVerlofDag ucVerlofdagen = new ucVerlofDag();
            if (!container.Controls.Contains(ucVerlofdagen))
            {
                container.Controls.Add(ucVerlofdagen);
            }
        }
    }
}