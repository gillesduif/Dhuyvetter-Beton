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
using System.IO;
using Twilio.Rest.Api.V2010.Account;
using BL;
using Twilio;
using System.Drawing.Printing;
using DhuyvetterBeton.Beton.Klanten;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using DhuyvetterBeton.Beton.Agenda;
using System.Runtime.InteropServices;
using DhuyvetterBeton.Beton.Bestelling.Tools;
using System.Net;

namespace DhuyvetterBeton.Beton.Bestelling
{
    public partial class ucNieuweBestelling : DevExpress.XtraEditors.XtraUserControl
    {
        //  private static ucNieuweBestelling _instantie;
        string versie;
        string USER;
        bool geenSMS = false;
        FrmHoofdVenster frmhoofd;
        //string USER = string.Empty;
        List<Hulpstof> HulpstoffenList = new List<Hulpstof>();
        Klant klant = new Klant();
        Werf geselecteerdeWerf = new Werf();
        int bestellingID;
        DateTime datumstartformulier;
        List<string> productomschrijvingLijst = new List<string>();
        List<Formule> FormuleList = new List<Formule>();
        List<Pomp> pompenList = new List<Pomp>();
        List<Klant> klantenList = new List<Klant>();
        List<Werf> wervenList = new List<Werf>();
        FrmWerfWijzigen frmWerf;
        FrmProductWijzigen frmProduct;
        FrmPompWijzigen frmPompWijzigen;
        FrmInformatieAanpassen frmInfoWijzigen;
        List<PostcodeGemeente> gemeentelijst = new List<PostcodeGemeente>();
        List<BL.PrijsLijst> prijsLijst = new List<BL.PrijsLijst>();
        int klantenNummer;
        DateTime maandag = new DateTime();
        DateTime dinsdag = new DateTime();
        DateTime woensdag = new DateTime();
        DateTime donderdag = new DateTime();
        DateTime vrijdag = new DateTime();
        DateTime zaterdag = new DateTime();

        private void KrijgBestellingenOpDag(DateTime date)
        {
            dataGridViewBestellingen.Rows.Clear();
            List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(date);
            List<BL.Bestelling> wachtruimte = new List<BL.Bestelling>();
            List<BL.Bestelling> bestellingenFilter = new List<BL.Bestelling>();
            bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
            foreach (BL.Bestelling bestelling in bestellingen)
            {

                if (bestelling.Datum.Hour == 0 && bestelling.Datum.Minute == 0)
                {
                    wachtruimte.Add(bestelling);
                    //   bestellingen.Remove(bestelling);
                }
                else
                {
                    bestellingenFilter.Add(bestelling);
                }
            }


            foreach (BL.Bestelling bestelling1 in bestellingenFilter)
            {
                dataGridViewBestellingen.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Datum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                    }

                    );
            }
        }



        public ucNieuweBestelling(string uservalue,FrmHoofdVenster frmhoofd1,string versie1,List<BL.Bestelling>Bestellings)
        {
            InitializeComponent();
          
            #region DatumSwitcherKnopFunctie
            DateTime datum = DateTime.Today;
            if (datum.DayOfWeek == DayOfWeek.Monday)
            {
                maandag = datum;
                dinsdag = datum.AddDays(+1);
                woensdag = datum.AddDays(+2);
                donderdag = datum.AddDays(+3);
                vrijdag = datum.AddDays(+4);
                zaterdag = datum.AddDays(+5);

              

              
            }
            else if (datum.DayOfWeek == DayOfWeek.Tuesday)
            {
                maandag = datum.AddDays(+6);
                dinsdag = datum;
                woensdag = datum.AddDays(+1);
                donderdag = datum.AddDays(+2);
                vrijdag = datum.AddDays(+3);
                zaterdag = datum.AddDays(+4);

            }
            else if (datum.DayOfWeek == DayOfWeek.Wednesday)
            {
                maandag = datum.AddDays(+5);
                dinsdag = datum.AddDays(+6);
                woensdag = datum;
                donderdag = datum.AddDays(+1);
                vrijdag = datum.AddDays(+2);
                zaterdag = datum.AddDays(+3);

            }
            else if (datum.DayOfWeek == DayOfWeek.Thursday)
            {
                maandag = datum.AddDays(+4);
                dinsdag = datum.AddDays(+5);
                woensdag = datum.AddDays(+6);
                donderdag = datum;
                vrijdag = datum.AddDays(+1);
                zaterdag = datum.AddDays(+2);
            }
            else if (datum.DayOfWeek == DayOfWeek.Friday)
            {
                maandag = datum.AddDays(+3);
                dinsdag = datum.AddDays(+4);
                woensdag = datum.AddDays(+5);
                donderdag = datum.AddDays(+6);
                vrijdag = datum;
                zaterdag = datum.AddDays(+1);

             
            }
            else if (datum.DayOfWeek == DayOfWeek.Saturday)
            {
                maandag = datum.AddDays(+2);
                dinsdag = datum.AddDays(+3);
                woensdag = datum.AddDays(+4);
                donderdag = datum.AddDays(+5);
                vrijdag = datum.AddDays(+6);
                zaterdag = datum;
            }
            lblMaandag.Text = maandag.ToShortDateString();
            lblDinsdag.Text = dinsdag.ToShortDateString();
            lblWoensdag.Text = woensdag.ToShortDateString();
            lblDonderdag.Text = donderdag.ToShortDateString();
            lblVrijdag.Text = vrijdag.ToShortDateString();
            lblZaterdag.Text = zaterdag.ToShortDateString();
            if (maandag == DateTime.Today)
            {
                lblMaandag.Text = "Vandaag";
                lblMaandag.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblDinsdag.Text = "Morgen";
            }
            else if (dinsdag == DateTime.Today)
            {
                lblDinsdag.Text = "Vandaag";
                lblDinsdag.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblWoensdag.Text = "Morgen";
            }
            else if (woensdag == DateTime.Today)
            {
                lblWoensdag.Text = "Vandaag";
                lblWoensdag.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblDonderdag.Text = "Morgen";
            }
            else if (donderdag == DateTime.Today)
            {
                lblDonderdag.Text = "Vandaag";
                lblDonderdag.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblVrijdag.Text = "Morgen";
            }
            else if (vrijdag == DateTime.Today)
            {
                lblVrijdag.Text = "Vandaag";
                lblVrijdag.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblZaterdag.Text = "Morgen";
            }
            else if (zaterdag == DateTime.Today)
            {
                lblZaterdag.Text = "Vandaag";
                lblZaterdag.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            }

            #endregion
         
            Cursor.Current = Cursors.AppStarting;
            List<SoortenHulpstof> SoortenHulpstofList = SoortenHulpstof.KrijgAlleSoortenHulpstof();
            cboHulpstof.Properties.Items.AddRange(SoortenHulpstofList.ToArray());
            Cursor.Current = Cursors.WaitCursor;
            FormuleList = Formule.KrijgAlleFormules();
            FormuleList.Sort((X, Y) => X.Omschrijving.CompareTo(Y.Omschrijving));
            foreach (Formule formule in FormuleList)
            {
                productomschrijvingLijst.Add(formule.Omschrijving);
            }
            FormuleList.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            Cursor.Current = Cursors.AppStarting;
         
            pompenList = Pomp.KrijgAllePompen();
            Cursor.Current = Cursors.AppStarting;
            klantenList = Klant.KrijgAlleKlanten();
            Cursor.Current = Cursors.AppStarting;
            gemeentelijst = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            prijsLijst = BL.PrijsLijst.KrijgAlleOmschrijvingen();
        //    klantenList.Sort((x, y) => x.Naam.CompareTo(y.Naam));

            //roductomschrijvingLijst.Sort((x, y) => x.Omschrijving.CompareTo(y.Omschrijving));
            Cursor.Current = Cursors.WaitCursor;
            Klant klantenNummer = Klant.krijgLaatsteKlant();
            txtNummer.Text = (klantenNummer.Nummer + 1).ToString();
            Cursor.Current = Cursors.WaitCursor;

            datumstartformulier = Convert.ToDateTime(dtpDatum.EditValue);
            //dtpDatum.CustomFormat = "dddd dd/MM/yyyy - HH : mm";

            cboProductOmschrijving.Properties.Items.AddRange(productomschrijvingLijst.ToArray());
            cboFormules.Items.AddRange(FormuleList.ToArray());

            listBoxControl1.Items.AddRange(klantenList.ToArray());
            cbonieuwewerfklant.Properties.Items.AddRange(klantenList.ToArray());


            //   List<Hulpstof> hulpstofList = Hulpstof.KrijgAlleHulpstoffen();

            foreach (PostcodeGemeente postcodeGemeente in gemeentelijst)
            {
                CboGemeente.Properties.Items.Add(postcodeGemeente);
                cboGemeenteWerf.Properties.Items.Add(postcodeGemeente);
            }
            //  CboGemeenten.Items.AddRange(gemeentelijst.)
            pompenList.Sort((X, Y) => X.PompLeverancier.CompareTo(Y.PompLeverancier));
            cboPompen.Properties.Items.AddRange(pompenList.ToArray());

            Cursor.Current = Cursors.AppStarting;

            int index = 0;
            foreach (Pomp pomp in cboPompen.Properties.Items)
            {
                if (pomp.PompLeverancier == "GEEN")
                {
                    cboPompen.SelectedIndex = index;
                    break;
                }
                index++;

            }

            Cursor.Current = Cursors.Default;

            foreach (PostcodeGemeente posstcodeLijst in gemeentelijst)
            {
                cboPostcode.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
                cboPostcodeWerf.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
            }
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            versie = versie1;
            if (Bestellings.Count != 0)
            {
                List<BL.Bestelling> bestellingen = Bestellings;
                int LaatsteBestelID = BL.Bestelling.KrijgLaatsteBestelIDdoorDatum(DateTime.Today.Date);
                int grootstegetal = 0;
                foreach (BL.Bestelling bestelling1 in bestellingen)
                {
                    if (grootstegetal < bestelling1.ID)
                    {
                        grootstegetal = bestelling1.ID;
                    }


                }
                if (grootstegetal != LaatsteBestelID)
                {
                    timer1.Start();
            
                }
                else
                {
                    timer3.Start();
                    List<BL.Bestelling> wachtruimte = new List<BL.Bestelling>();
                    List<BL.Bestelling> bestellingenFilter = new List<BL.Bestelling>();
                    bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
                    foreach (BL.Bestelling bestelling in bestellingen)
                    {

                        if (bestelling.Datum.Hour == 0 && bestelling.Datum.Minute == 0)
                        {
                            wachtruimte.Add(bestelling);
                            //   bestellingen.Remove(bestelling);
                        }
                        else
                        {
                            bestellingenFilter.Add(bestelling);
                        }
                    }


                    foreach (BL.Bestelling bestelling1 in bestellingenFilter)
                    {
                        dataGridViewBestellingen.Rows.Add(
                            new object[]
                            {
                        bestelling1.ID,
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Datum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                            }

                            );
                    }
                }
              
            }
            else
            {
                timer1.Start();
            }
          
            USER = uservalue;
            frmhoofd = frmhoofd1;
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            dtpDatum.EditValue = DateTime.Today;
            if (USER == "Pedro")
            {
                paneelNieuweKlant.Visible = false;
                cboProductOmschrijving.Visible = false;
            }

        }

        private void dataGridViewBestellingen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewBestellingen.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewBestellingen.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<BL.Bestelling> wachtruimte = new List<BL.Bestelling>();
            List<BL.Bestelling> bestellingenFilter = new List<BL.Bestelling>();
            List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);

            bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
            foreach (BL.Bestelling bestelling in bestellingen)
            {
                if (bestelling.Datum.Hour == 0 && bestelling.Datum.Minute == 0)
                {
                    wachtruimte.Add(bestelling);
                    //   bestellingen.Remove(bestelling);
                }
                else
                {
                    bestellingenFilter.Add(bestelling);
                }
            }


            foreach (BL.Bestelling bestelling1 in bestellingenFilter)
            {
                dataGridViewBestellingen.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Datum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                    }

                    );
            }
            Cursor.Current = Cursors.AppStarting;
            List<SoortenHulpstof> SoortenHulpstofList = SoortenHulpstof.KrijgAlleSoortenHulpstof();
            cboHulpstof.Properties.Items.AddRange(SoortenHulpstofList.ToArray());
            //productomschrijvingLijst = OmschrijvingProduct.KrijgAlleOmschrijvingen();
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.AppStarting;
            FormuleList = Formule.KrijgAlleFormules();
            pompenList = Pomp.KrijgAllePompen();
            Cursor.Current = Cursors.AppStarting;
            klantenList = Klant.KrijgAlleKlanten();
            Cursor.Current = Cursors.AppStarting;
            gemeentelijst = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            prijsLijst = BL.PrijsLijst.KrijgAlleOmschrijvingen();
            klantenList.Sort((x, y) => x.Naam.CompareTo(y.Naam));

           // productomschrijvingLijst.Sort((x, y) => x..CompareTo(y.Omschrijving));
            Cursor.Current = Cursors.WaitCursor;
            Klant klantenNummer = Klant.krijgLaatsteKlant();
            txtNummer.Text = (klantenNummer.Nummer + 1).ToString();
            Cursor.Current = Cursors.WaitCursor;

            datumstartformulier = Convert.ToDateTime(dtpDatum.EditValue);
            //dtpDatum.CustomFormat = "dddd dd/MM/yyyy - HH : mm";

            cboProductOmschrijving.Properties.Items.AddRange(productomschrijvingLijst.ToArray());
            cboFormules.Items.AddRange(FormuleList.ToArray());

            listBoxControl1.Items.AddRange(klantenList.ToArray());
            cbonieuwewerfklant.Properties.Items.AddRange(klantenList.ToArray());


            //   List<Hulpstof> hulpstofList = Hulpstof.KrijgAlleHulpstoffen();

            foreach (PostcodeGemeente postcodeGemeente in gemeentelijst)
            {
                CboGemeente.Properties.Items.Add(postcodeGemeente);
                cboGemeenteWerf.Properties.Items.Add(postcodeGemeente);
            }
            //  CboGemeenten.Items.AddRange(gemeentelijst.)

            cboPompen.Properties.Items.AddRange(pompenList.ToArray());

            Cursor.Current = Cursors.AppStarting;

            int index = 0;
            foreach (Pomp pomp in cboPompen.Properties.Items)
            {
                if (pomp.PompLeverancier == "GEEN")
                {
                    cboPompen.SelectedIndex = index;
                    break;
                }
                index++;

            }

            Cursor.Current = Cursors.Default;

            foreach (PostcodeGemeente posstcodeLijst in gemeentelijst)
            {
                cboPostcode.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
                cboPostcodeWerf.Properties.Items.Add(posstcodeLijst.ToStringPostcode());
            }

            timer1.Stop();
        }

        private void ucNieuweBestelling_Load(object sender, EventArgs e)
        {
            if (USER == "Pedro")
            {
                cboProductOmschrijving.Visible = false;
            }
        }

        private void dtpDatum_DisableCalendarDate(object sender, DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs e)
        {
        

        }

        private void dtpDatum_DrawItem(object sender, DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs e)
        {
            if (e.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Style.ForeColor = Color.Black;
            }
            else if (e.Date.DayOfWeek == DayOfWeek.Saturday)
            {
                e.Style.ForeColor = Color.Red;
            }

        }

        private void dtpDatum_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToDateTime(e.NewValue, System.Globalization.CultureInfo.InvariantCulture).DayOfWeek == DayOfWeek.Sunday)
                e.Cancel = true;
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            if (textEdit1.Text != string.Empty)
            {
                listBoxControl1.Visible = true;
            }
            else { listBoxControl1.Visible = false; }
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            if (textEdit1.Text != string.Empty)
            {
                string s = textEdit1.Text.Substring(0, 1);
                if (s != s.ToUpper())
                {
                    int curSelStart = textEdit1.SelectionStart;
                    int curSelLength = textEdit1.SelectionLength;
                    textEdit1.SelectionStart = 0;
                    textEdit1.SelectionLength = 1;
                    textEdit1.SelectedText = s.ToUpper();
                    textEdit1.SelectionStart = curSelStart;
                    textEdit1.SelectionLength = curSelLength;
                }
                listBoxControl1.Visible = true;
            }
            else { listBoxControl1.Visible = false; }
        }

       


        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + @"dbintern-56185-firebase-adminsdk-50c46-700d8feb2f.json";
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        
            bool pedroBestelComp = false;
            if (File.Exists(@"C:\DBBEST.txt"))
            {
                pedroBestelComp = true;
            }
            else
            {
                Debug.WriteLine("File does not exist in the C directory!");
            }

            bool saldo = false;
            string CAW = "";
            if (checkBox1.Checked == true)
            {
                saldo = true;
            }

            Cursor.Current = Cursors.AppStarting;

            int leveringchkb;
            if (datumstartformulier == Convert.ToDateTime(dtpDatum.EditValue))
            {
                XtraMessageBox.Show("Gelieve een tijdstip of datum te kiezen.");
            }
            else if (klant == null)
            {
                XtraMessageBox.Show("Gelieve een klant te selecteren.");
            }
            else if (geselecteerdeWerf == null)
            {
                XtraMessageBox.Show("Gelieve een Werf te selecteren.");
            }
            else if (txtM3.Text == string.Empty)
            {
                XtraMessageBox.Show("Gelieve de hoeveelheid M3 in te vullen.");
            }
            else if (cboHulpstof.Text != string.Empty)
            {
                XtraMessageBox.Show("Gelieve hulpstof toevoegen.");
            }
            else if (cboFormules.SelectedItem == null && cboFormules.Text != string.Empty && klant != null && geselecteerdeWerf != null && txtM3.Text != string.Empty)
            {

                cboFormules.SelectedIndex = cboFormules.FindString(cboFormules.Text);
                if (cboFormules.SelectedItem == null)
                {
                    XtraMessageBox.Show("Product niet correct aangeduid");

                }
                else
                {
                    Pomp pomp;
                    if (cboPompen.SelectedItem != null)
                    {
                        pomp = ((Pomp)cboPompen.SelectedItem);
                    }
                    else
                    {
                        pomp = null;
                    }

                    if (chkbLevering.Checked == true)
                    {
                        leveringchkb = 1;
                    }
                    else
                    {
                        leveringchkb = 0;
                    }

                    Formule formule = ((Formule)cboFormules.SelectedItem);
                    Klant klant = ((Klant)listBoxControl1.SelectedItem);
                    Werf werf = geselecteerdeWerf;


                    BL.Bestelling bestelling = new BL.Bestelling();
                    bestelling.Klant = klant;
                    bestelling.Werf = werf;
                    bestelling.Formule = formule;
                    bestelling.Pomp = pomp;
                    bestelling.Giek = cboGiek.Text;
                    if (txtM3.Text.Contains("."))
                    {
                        string m3value = txtM3.Text;
                        string m3updated = m3value.Replace(".", ",");
                        txtM3.Text = m3updated;
                    }
                    string puntkomma = txtM3.Text;
                    if (txtM3.Text.Contains(",") && USER == "Pedro" && pedroBestelComp == false)
                    {
                        string correct = puntkomma.Replace(",", ".");
                        txtM3.Text = correct;
                    }
                    bestelling.M3 = Convert.ToDouble(txtM3.Text);
                    bestelling.Besteldatum = DateTime.Now;
                    bestelling.Datum = Convert.ToDateTime(dtpDatum.EditValue);
                    bestelling.Levering = leveringchkb;
                    if (cboLoswijze.Text != string.Empty)
                    {
                        bestelling.Loswijze = cboLoswijze.Text;
                    }
                    else
                    {
                        bestelling.Loswijze = " ";
                    }
                    bestelling.LeveringWijze = txtLeveringWijze.Text;
                    bestelling.Loswijze = cboLoswijze.Text;
                    bestelling.Comment = txtComment.Text;


                    bestelling.GeneerExcellRec(saldo, "", USER);

                    if (bestelling.Pomp.Pompdetails == "D'huyvetter beton")
                    {

                        bestelling.GeneerPompExcell(chbOpmerkingPomp.Checked);
                    }

                    //label7.Text = "Succesvol, goed gedaan!";
                    BL.Bestelling bestelling1 = BL.Bestelling.KrijgBestellingDoor(bestelling.Klant, bestelling.Werf, bestelling.Datum);
                    bestellingID = bestelling1.ID;
              
                    if (listBoxHulpstoffen.Items.Count > 0)
                    {
                        foreach (Hulpstof hulpstof in HulpstoffenList)
                        {
                            hulpstof.Bestelling = bestelling1;
                            hulpstof.Voeghulpstoftoe();
                        }
                    }
                    bestelling1.GeneerExcellRec(saldo, CAW, USER);
                    if(USER == "Pedro")
                    {
                       // OpenFileDialog ofd = new OpenFileDialog();
                       
                            PrintDocument pdoc = new PrintDocument();

                            pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                            string bestandsNaam = klant.Naam + " " + bestelling1.Datum.Hour.ToString() + "u" + bestelling1.Datum.Minute.ToString();
                            PrintCentrale(pdoc.PrinterSettings.PrinterName, @"Z:\Bestellingen\" + bestelling1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                        
                    }
                    else
                    {
                        try
                        {
                            PrintDialog pd = new PrintDialog();
                            pd.PrinterSettings = new PrinterSettings();
                            pd.PrinterSettings.Copies = 1;
                            if (DialogResult.OK == pd.ShowDialog(this))
                            {
                                if (klant.Naam != string.Empty)
                                {
                                    string bestandsNaam = klant.Naam + " " + bestelling1.Datum.Hour.ToString() + "u" + bestelling1.Datum.Minute.ToString();

                                    new FileInfo(@"Z:\Bestellingen\" + bestelling1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();
                                }


                            }
                        }
                        catch
                        {
                            XtraMessageBox.Show("Probleem met printer of server.", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                
                  
                    try
                    {
                        if (bestelling1.Klant.Gsm != string.Empty && CheckboxGeenSMS.Checked == true)
                        {
                            int uur = bestelling1.Datum.Hour;
                            int minuten = bestelling1.Datum.Minute;
                            string tijdstipBestelling = "";
                            if (minuten == 0)
                            {
                                tijdstipBestelling = uur.ToString() + "Uur";
                            }
                            else
                            {
                                tijdstipBestelling = uur.ToString() + ":" + minuten.ToString();
                            }
                            if(geenSMS != true)
                            {
                                const string accountSid = "YOUR_TWILIO_ACCOUNT_SID";
                                const string authToken = "YOUR_TWILIO_AUTH_TOKEN";
                                string pompenString = "";
                                if (bestelling1.Pomp.PompLeverancier != "GEEN")
                                {
                                    pompenString = "Pomp " + bestelling1.Pomp.Pompdetails + " ";
                                }
                                TwilioClient.Init(accountSid, authToken);
                                string maatEenheid = ((Formule)cboFormules.SelectedItem).MaatEenheid;

                                var message = MessageResource.Create(
                                            body: "D'huyvetter beton:  " + bestelling1.Klant.Naam + " uw bestelling " + "Werf: " + bestelling1.Werf.Adres + " " + bestelling1.Werf.Gemeente + " Product: " + bestelling1.M3.ToString() + maatEenheid + " " + bestelling1.Formule.Omschrijving + " voor " + bestelling1.Datum.Date.ToShortDateString() + " " + tijdstipBestelling + " " + pompenString + "staat ingepland.",
                                            from: new Twilio.Types.PhoneNumber("32460208150"),
                                            to: new Twilio.Types.PhoneNumber(bestelling1.Klant.Gsm)
                                        );
                            }
                        }
                    }
                    catch { }
                   // this.Close();
                   
                }
            }
            else if (cboFormules.SelectedItem != null && klant != null && geselecteerdeWerf != null && txtM3.Text != string.Empty)
            {
                Pomp pomp;
                if (cboPompen.SelectedItem != null)
                {
                    pomp = ((Pomp)cboPompen.SelectedItem);
                }
                else
                {
                    pomp = null;
                }

                if (chkbLevering.Checked == true)
                {
                    leveringchkb = 1;
                }
                else
                {
                    leveringchkb = 0;
                }

                Formule formule = ((Formule)cboFormules.SelectedItem);
                Werf werf = geselecteerdeWerf;

                BL.Bestelling bestelling = new BL.Bestelling();
                bestelling.Klant = klant;
                bestelling.Werf = werf;
                bestelling.Formule = formule;
                bestelling.Pomp = pomp;
                bestelling.Giek = cboGiek.Text;
                if (txtM3.Text.Contains("."))
                {
                    string m3value = txtM3.Text;
                    string m3updated = m3value.Replace(".", ",");
                    txtM3.Text = m3updated;
                }
                string puntkomma = txtM3.Text;
                if (txtM3.Text.Contains(",") && USER == "Pedro" && pedroBestelComp == false)
                {
                    string correct = puntkomma.Replace(",", ".");
                    txtM3.Text = correct;
                }
                bestelling.M3 = Convert.ToDouble(txtM3.Text);
                bestelling.Besteldatum = DateTime.Now;
                bestelling.Datum = Convert.ToDateTime(dtpDatum.EditValue);
                bestelling.Levering = leveringchkb;
                if (cboLoswijze.Text != string.Empty)
                {
                    bestelling.Loswijze = cboLoswijze.Text;
                }
                else
                {
                    bestelling.Loswijze = " ";
                }
                bestelling.LeveringWijze = txtLeveringWijze.Text;
                bestelling.Loswijze = cboLoswijze.Text;
                bestelling.Comment = txtComment.Text;


                bestelling.MaakNieuweBestelling();
                bestellingID = bestelling.ID;
                BL.Bestelling bestelling1 = BL.Bestelling.KrijgBestellingDoor(bestelling.Klant, bestelling.Werf, bestelling.Datum);

                if (listBoxHulpstoffen.Items.Count > 0)
                {
                    foreach (Hulpstof hulpstof in HulpstoffenList)
                    {
                        hulpstof.Bestelling = bestelling1;
                        hulpstof.Voeghulpstoftoe();
                    }
                }

                bestelling1.GeneerExcellRec(saldo, "", USER);
                Logboek logboek = new Logboek(DateTime.Now, "BESTELLINGEN", "[NIEUWE BESTELLING] Klant: " + bestelling1.Klant.Naam + " Product: " + cboProductOmschrijving.Text + " M3: " + bestelling1.M3.ToString() + " Datum: " + bestelling1.Datum, USER);
                logboek.MaakNieuwLogBoekPunt();

                if(USER == "Pedro" && bestelling.Pomp.PompLeverancier == "D'huyvetter beton")
                {
                  
                    PrintDocument pdoc = new PrintDocument();

                    pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                    string bestandsNaam = klant.Naam + " " + bestelling1.Datum.Hour.ToString() + "u" + bestelling1.Datum.Minute.ToString();
                    PrintCentrale(pdoc.PrinterSettings.PrinterName, @"Z:\Bestellingen\" + bestelling1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");


                    bestelling.GeneerPompExcell(chbOpmerkingPomp.Checked);
                    PrintDocument pdoc1 = new PrintDocument();

                            pdoc1.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                        string bestandsNaam1 = klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();
                        PrintCentrale(pdoc1.PrinterSettings.PrinterName, @"Z:\PompFiches\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam1 + ".xlsx"); 
                }
                else if (bestelling.Pomp.PompLeverancier == "D'huyvetter beton")
                {
                    bestelling.GeneerPompExcell(chbOpmerkingPomp.Checked);
                    PrintDialog pd1 = new PrintDialog();
                    pd1.PrinterSettings = new PrinterSettings();
                    pd1.PrinterSettings.Copies = 1;


                    string bestandsNaam1 = klant.Naam + " " + bestelling1.Datum.Hour.ToString() + "u" + bestelling1.Datum.Minute.ToString();

                    new FileInfo(@"Z:\Bestellingen\" + bestelling1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam1 + ".xlsx").Print();
                    string bestandsNaam = klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();

                    new FileInfo(@"Z:\PompFiches\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();



                }
                else if (USER == "Pedro")
                {
                        PrintDocument pdoc = new PrintDocument();

                        pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                        string bestandsNaam = klant.Naam + " " + bestelling1.Datum.Hour.ToString() + "u" + bestelling1.Datum.Minute.ToString();
                        PrintCentrale(pdoc.PrinterSettings.PrinterName, @"Z:\Bestellingen\" + bestelling1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                }
                else
                {
                    try
                    {
                     PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();
                    pd.PrinterSettings.Copies = 1;

                    string bestandsNaam = klant.Naam + " " + bestelling1.Datum.Hour.ToString() + "u" + bestelling1.Datum.Minute.ToString();

                    new FileInfo(@"Z:\Bestellingen\" + bestelling1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Probleem met printer of server.", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }




                }

                //label7.Text = "Succesvol, goed gedaan!";

                try
                {
                    if (bestelling1.Klant.Gsm != string.Empty && CheckboxGeenSMS.Checked == true)
                    {
                        int uur = bestelling1.Datum.Hour;
                        int minuten = bestelling1.Datum.Minute;
                        string tijdstipBestelling = "";
                        if (minuten == 0)
                        {
                            tijdstipBestelling = uur.ToString() + "UUR";
                        }
                        else
                        {
                            tijdstipBestelling = uur.ToString() + ":" + minuten.ToString();
                        }
                        string hulpstoffen = "";
                        List<Hulpstof> hulpstoffenBestellingLijst = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(bestelling1.ID);
                        foreach (Hulpstof hulpstof in hulpstoffenBestellingLijst)
                        {
                            hulpstoffen = hulpstoffen + " + " + hulpstof.Naam;
                        }
                        const string accountSid = "YOUR_TWILIO_ACCOUNT_SID";
                        const string authToken = "YOUR_TWILIO_AUTH_TOKEN";
                        string pompenString = "";
                        if (bestelling1.Pomp.PompLeverancier != "GEEN")
                        {
                            pompenString = "Pomp " + bestelling1.Pomp.Pompdetails + " ";
                        }
                        TwilioClient.Init(accountSid, authToken);
                        string maatEenheid = ((Formule)cboFormules.SelectedItem).MaatEenheid;

                        var message = MessageResource.Create(
                            body: "D'huyvetter beton:  " + bestelling1.Klant.Naam + " uw bestelling " + "Werf: " + bestelling1.Werf.Adres + " " + bestelling1.Werf.Gemeente + " Product: " + bestelling1.M3.ToString() + " " +  maatEenheid + " " +  bestelling1.Formule.Omschrijving + " " + hulpstoffen + " voor " + bestelling1.Datum.Date.ToShortDateString() + " " + tijdstipBestelling + " " + pompenString + "staat ingepland.",
                            from: new Twilio.Types.PhoneNumber("32460208150"),
                            to: new Twilio.Types.PhoneNumber(bestelling1.Klant.Gsm)
                        );
                    }
                }
                catch { }
                //this.Close();

                frmhoofd.container.Controls.Clear();
                ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER,versie,null);

                if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
                {

                    frmhoofd.container.Controls.Add(ucHoofdvenster);

                }
             
            }
            else
            {
                XtraMessageBox.Show("Vergeet je niet iets?");
            }
            Cursor.Current = Cursors.Default;
            //ClearTextBoxes(this.Controls);
        }
        private void PrintCentrale(string printerName, string fileName)
        {
            try
            {
                ProcessStartInfo gsProcessInfo;
                Process gsProcess;

                gsProcessInfo = new ProcessStartInfo();
                gsProcessInfo.Verb = "PrintTo";
                gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
                gsProcessInfo.FileName = fileName;
                gsProcessInfo.Arguments = "\"" + printerName + "\"";
                gsProcess = Process.Start(gsProcessInfo);
                if (gsProcess.HasExited == false)
                {
                    gsProcess.Kill();
                }
                gsProcess.EnableRaisingEvents = true;

                gsProcess.Close();
            }
            catch (Exception)
            {
            }
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
         
            if (textEdit1.Text.Count() > 1)
            {
                List<Klant> klantenfilter = new List<Klant>();
                string zoekKlant = textEdit1.Text.ToLower().Replace(" ","");
                foreach (Klant klant in klantenList)
                {
                    string klantNaam = klant.Naam.ToLower().Replace(" ", "");
                    if (klantNaam.Contains(zoekKlant))
                    {
                        klantenfilter.Add(klant);
                    }
                }
                klantenfilter.Sort((x, y) => x.Naam.CompareTo(y.Naam));
                listBoxControl1.Items.Clear();
                listBoxControl1.Items.AddRange(klantenfilter.ToArray());
            }
         
        }

        private void textEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
           

        }

        private void listBoxControl1_MouseClick(object sender, MouseEventArgs e)
        {
          

        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (listBoxControl1.SelectedItem != null)
            {
                if(((Klant)listBoxControl1.SelectedItem).BetaalCode == "Rood")
                {
                    XtraMessageBox.Show("DEZE KLANT MOET DRINGEND BETALEN!","Code ROOD",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    textEdit1.BackColor = Color.Red;
                }
                else if(((Klant)listBoxControl1.SelectedItem).BetaalCode == "Oranje")
                {
                    XtraMessageBox.Show("Opgepast gevaarlijke betaler", "Code Oranje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit1.BackColor = Color.DarkOrange;
                }
                else if (((Klant)listBoxControl1.SelectedItem).BetaalCode == "Geel")
                {
                    textEdit1.BackColor = ColorTranslator.FromHtml("#F3BF00");
                }
                
                List<Werf> wervenVanKlantLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)listBoxControl1.SelectedItem).ID);

                wervenVanKlantLijst.Sort((x, y) => x.Adres.CompareTo(y.Adres));
                int index1 = 0;
                foreach (Klant klant1 in cbonieuwewerfklant.Properties.Items)
                {
                    if (((Klant)listBoxControl1.SelectedItem).ToString() == klant1.ToString())
                    {
                        cbonieuwewerfklant.SelectedIndex = index1;
                        break;
                    }
                    index1++;
                }
                bool werfAfhaling = false;
                foreach (Werf werf in wervenVanKlantLijst)
                {
                    if (werf.Adres == "afhaling") { werfAfhaling = true; }
                }

                if (werfAfhaling == false)
                {
                    Werf werf = new Werf(((Klant)listBoxControl1.SelectedItem), "afhaling", "", "", "");
                    werf.maakNieuweWerf();
                }
                klant = ((Klant)listBoxControl1.SelectedItem);
                List<Werf> wervenVanKlantLijst1 = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)listBoxControl1.SelectedItem).ID);
                wervenVanKlantLijst1.Sort((x, y) => x.Adres.CompareTo(y.Adres));
              //  cboWerven.Properties.Items.Clear();
                wervenList = wervenVanKlantLijst1;
                listBoxWerven.Items.AddRange(wervenList.ToArray());
              //  cboWerven.Properties.Items.AddRange(wervenVanKlantLijst1.ToArray());
                labelBtw.Text = klant.Btw;
                label11.Text = klant.Adres;
                labelGemeente.Text = klant.Gemeente;
                label13.Text = klant.Telefoon;
                label12.Text = klant.Gsm;
                labelEmail.Text = klant.Email;
                
                txtAdres.Enabled = true;
                CboGemeente.Enabled = true;
                cboPostcode.Enabled = true;
                txtTelefoon.Enabled = true;
                txtAdres.Text = "";
                CboGemeente.Text = "";
                cboPostcode.Text = "";
                txtTelefoon.Text = "";

              //  cboWerven.Text = "Selecteer een werf.";
                LabelOverzichtKlant.Text = klant.Naam;

            }
            //cboWerven.DroppedDown = true;
            try
            {
                textEdit1.Text = ((Klant)listBoxControl1.SelectedItem).Naam;
                listBoxControl1.Visible = false;
            }
            catch
            {
                listBoxControl1.Visible = false;
            }
        }

        private void btnKlantAdres_Click(object sender, EventArgs e)
        {
            if (cbonieuwewerfklant.SelectedItem != null)
            {
                try
                {
                    txtAdresWerf.Text = klant.Adres;
                    cboPostcodeWerf.Text = klant.Postcode;
                    cboGemeenteWerf.Text = klant.Gemeente;
                    txtTelefoonWerf.Text = klant.Gsm;
                }
                catch
                {
                    XtraMessageBox.Show("Gelieve klant aan te klikken", "Klant niet gevonden");
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
             System.Diagnostics.Process.Start("http://google.com/maps/search/" + txtAdresWerf.Text + " " + cboPostcodeWerf.Text + " " + cboGemeenteWerf.Text);
        }

        private void btnHulpstofVerwijderen_Click(object sender, EventArgs e)
        {
            listBoxHulpstoffen.Items.Clear();
            HulpstoffenList = new List<Hulpstof>();
        }

        private void btnHulpstofToevoegen_Click(object sender, EventArgs e)
        {
            string hulpstofoverzicht = string.Empty;

            Hulpstof hulpstof = new Hulpstof();
            hulpstof.Naam = cboHulpstof.Text;
            hulpstof.Hoeveelheid = txtHoeveelheidHulpstof.Text;
            HulpstoffenList.Add(hulpstof);
            listBoxHulpstoffen.Items.Clear();
            listBoxHulpstoffen.Items.AddRange(HulpstoffenList.ToArray());
            cboHulpstof.Text = string.Empty;
            txtHoeveelheidHulpstof.Text = string.Empty;
           
            foreach (Hulpstof hulpstof1 in HulpstoffenList)
            {
                hulpstofoverzicht = hulpstofoverzicht + " & " + hulpstof1.Naam;
            }
            labelHulpstoffen.Text = hulpstofoverzicht;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (txtPompLeverancier.Text == string.Empty)
            {
                XtraMessageBox.Show("Gelieve de tekst velden niet leeg te laten.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Pomp pomp = new Pomp(txtPompLeverancier.Text, txtPomp.Text);
                pomp.MaakNieuwePomp();
                cboPompen.Properties.Items.Clear();
                List<Pomp> pompenList = Pomp.KrijgAllePompen();
                pompenList.Sort((X, Y) => X.PompLeverancier.CompareTo(Y.PompLeverancier));
                cboPompen.Properties.Items.AddRange(pompenList.ToArray());

                int index5 = 0;
                foreach (Pomp pomp1 in cboPompen.Properties.Items)
                {
                    if (pomp.ToString() == pomp1.ToString())
                    {
                        cboPompen.SelectedIndex = index5;
                        break;
                    }
                    index5++;

                }
                //     cboPompen.SelectedIndex = cboPompen.FindString(pomp.PompLeverancier + " - " + pomp.Pompdetails);
                txtPompLeverancier.Text = string.Empty;
                txtPomp.Text = string.Empty;
                Logboek logboek = new Logboek(DateTime.Now, "POMPEN", "[NIEUWE POMP TOEGEVOEGD VIA BESTELLING] Pomp leverancier: " + pomp.PompLeverancier + " Giek: " + pomp.Pompdetails, USER);
                logboek.MaakNieuwLogBoekPunt();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txtTelefoonWerf.Text == string.Empty)
            {
                txtTelefoonWerf.Text = klant.Gsm;
            }
            Werf werf = new Werf(klant, txtAdresWerf.Text, cboGemeenteWerf.Text, cboPostcodeWerf.Text, txtTelefoonWerf.Text);
            werf.maakNieuweWerf();
            try { LabelOverzichtWerf.Text = werf.ToString(); }catch { }
            
            List<Werf> WervenOphalen = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
            foreach(Werf werfHalen in WervenOphalen)
            {
                if(werfHalen.Adres == werf.Adres && werfHalen.Gemeente == werf.Gemeente && werfHalen.Postcode == werf.Postcode)
                {
                    geselecteerdeWerf = werfHalen;
                }
            }
            txtAdresWerf.Text = string.Empty;
            cboGemeenteWerf.Text = string.Empty;
            cboPostcodeWerf.Text = string.Empty;
            txtTelefoonWerf.Text = string.Empty;
            LabelOverzichtWerf.Text = werf.ToString();
            Logboek logboek = new Logboek(DateTime.Now, "WERVEN", "[NIEUWE WERF TOEGEVOEGD VIA BESTELLING] Klant: " + werf.Klant.Naam + " Adres: " + werf.Adres + " Gemeente: " + werf.Gemeente + " Postcode: " + werf.Postcode, USER);
            logboek.MaakNieuwLogBoekPunt();
          
            txtBestaandeWerf.Text = werf.ToString();
            listBoxWerven.Visible = false;
        
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
                  System.Diagnostics.Process.Start("http://google.com/maps/search/" + txtAdres.Text + " " + cboPostcode.Text + " " + CboGemeente.Text);
       
          
           
        }

      

        private void BtnKlantToevoegen_Click(object sender, EventArgs e)
        {
            if (txtNaam.Text.Contains("/"))
            {
                string naamvalue = txtNaam.Text;
                string naamupdated = naamvalue.Replace("/", " ");
                txtNaam.Text = naamupdated;
            }

            string textbtw = "";
            if (txtBtw.Text != string.Empty)
            {
                textbtw = cboBtwLand.Text + txtBtw.Text;
            }
            klant = new Klant(txtNaam.Text, Convert.ToInt32(txtNummer.Text), txtAdres.Text.ToLower(), cboPostcode.Text, CboGemeente.Text.ToLower(), txtTelefoon.Text, " ", txtGsm.Text, txtEmail.Text.ToLower(), textbtw, "","Groen");
            klant.maakNieuweKlant();
            klant = null;
            klant = Klant.KrijgKlantViaKlantenNummer(Convert.ToInt32(txtNummer.Text));
            Werf werfFacturatieAdres = new Werf(klant, txtAdres.Text.ToLower(), CboGemeente.Text.ToLower(), cboPostcode.Text.ToLower(), txtTelefoon.Text);
            werfFacturatieAdres.maakNieuweWerf();
            LabelOverzichtKlant.Text = klant.Naam;
            labelKlantNummer.Text = txtNummer.Text;
            klantenNummer = Convert.ToInt32(txtNummer.Text);
            klantenNummer++;
       
            listBoxControl1.Items.Clear();
            listBoxWerven.Items.Clear();
            List<Werf> wervenLijstKlant = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
            listBoxWerven.Items.AddRange(wervenLijstKlant.ToArray());
            cbonieuwewerfklant.Properties.Items.Clear();
            txtNaam.Text = string.Empty;
            txtAdres.Text = string.Empty;
            cboPostcode.Text = string.Empty;
            CboGemeente.Text = string.Empty;
            txtTelefoon.Text =  string.Empty;
            txtGsm.Text = string.Empty;
            txtBtw.Text  = string.Empty;
            txtEmail.Text = string.Empty;
            List<Klant> KlantenlijstRef = Klant.KrijgAlleKlanten();
            listBoxControl1.Items.AddRange(KlantenlijstRef.ToArray());
            cbonieuwewerfklant.Properties.Items.AddRange(KlantenlijstRef.ToArray());
            textEdit1.Text = klant.ToString();
            cbonieuwewerfklant.Text = klant.ToString();
            labelBtw.Text = klant.Btw;
            label11.Text = klant.Adres;
            labelGemeente.Text = klant.Gemeente;
            label13.Text = klant.Telefoon;
            label12.Text = klant.Gsm;
            labelEmail.Text = klant.Email;


            Logboek logboek = new Logboek(DateTime.Now, "KLANTEN", "[NIEUWE KLANT TOEGEVOEGD VIA BESTELLING] Klant: " + klant.Naam + " Adres: " + klant.Adres + " Gemeente: " + klant.Gemeente + " Postcode: " + klant.Postcode, USER);
            logboek.MaakNieuwLogBoekPunt();
            listBoxControl1.Visible = false;
        }


        private void cboProductOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Formule formule in FormuleList)
            {
                if (formule.Omschrijving == cboProductOmschrijving.SelectedItem.ToString())
                {
                    cboFormules.SelectedIndex = cboFormules.FindString(formule.Naam);
                }
            }
        
            if (cboProductOmschrijving.Text.Contains("vertrager"))
            {
                listBoxHulpstoffen.Items.Clear();
                HulpstoffenList.Clear();
                Hulpstof hulpstof = new Hulpstof();
                hulpstof.Naam = "vertrager";
                hulpstof.Hoeveelheid = " ";
                HulpstoffenList.Add(hulpstof);
                listBoxHulpstoffen.Items.Add(hulpstof);
            }
            LabelOverzichtProduct.Text = cboProductOmschrijving.SelectedItem.ToString();
        }

        private void cboFormules_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             
                    lblHoeveelHeidIndicatie.Text = ((Formule)cboFormules.SelectedItem).MaatEenheid + ":";
                
              
            }
            catch
            {
                MessageBox.Show("Product opnieuw aanduiden aub");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void CheckboxGeenSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxGeenSMS.Checked == false)
            {
                geenSMS = true;
            }
            else
            {
                geenSMS = false;
            }
        }

        private void cboGemeenteWerf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(checkFrankrijkWerf.Checked != true)
                {
                    cboPostcodeWerf.Text = ((PostcodeGemeente)cboGemeenteWerf.SelectedItem).Postcode;
                }
             
            }
            catch
            {
                cboPostcodeWerf.Text = string.Empty;
            }
          
        }

        private void cboPompen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGiek.Text = ((Pomp)cboPompen.SelectedItem).Pompdetails;
            LabelOverzichtPomp.Text = ((Pomp)cboPompen.SelectedItem).ToString();
        }

        private void CboGemeente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if(checkFrankrijk.Checked != true) { cboPostcode.Text = ((PostcodeGemeente)CboGemeente.SelectedItem).Postcode; }
                else { CboGemeente.Properties.AutoComplete = false; }
                }
            catch { }
        }

        private void cboWerven_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Werf werfSelectie = ((Werf)listBoxWerven.SelectedItem);
                labelWerfAdres.Text = werfSelectie.Adres;
                labelWerfGemeente.Text = werfSelectie.Gemeente;
                labelWerfPostcode.Text = werfSelectie.Postcode;
                labelWerfTelefoon.Text = werfSelectie.Telefoon;
                LabelOverzichtWerf.Text = werfSelectie.ToString();
            }
            catch
            {

            }
        }

        private void txtM3_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LabelOverzichtAantal.Text = txtM3.Text + " " + ((Formule)cboFormules.SelectedItem).MaatEenheid;
            }
            catch
            {
                LabelOverzichtAantal.Text = txtM3.Text;
            }
            
        }

        private void dtpDatum_EditValueChanged(object sender, EventArgs e)
        {
            string minuten = string.Empty;
            if (Convert.ToDateTime(dtpDatum.EditValue).Hour == 0 && Convert.ToDateTime(dtpDatum.EditValue).Minute == 0)
            {
                minuten = "?";
            }
         else
            {
                if (Convert.ToDateTime(dtpDatum.EditValue).Minute.ToString() == "0")
                {
                    minuten = "00";
                }
                else
                {
                    minuten = Convert.ToDateTime(dtpDatum.EditValue).Minute.ToString();
                }
                labelUUR.Text = Convert.ToDateTime(dtpDatum.EditValue).Hour.ToString() + ":" + minuten;
            }
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
           
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void PaneelTijdStip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description;
                if (text == "Aannemer")
                {
                    double Aannemerprijs;

                    foreach (BL.PrijsLijst prijs in prijsLijst)
                    {
                        if (prijs.Formule == cboFormules.Text)
                        {
                            Aannemerprijs = prijs.Aannemer;
                            labelPrijs.Text = (Aannemerprijs * Convert.ToDouble(txtM3.Text)).ToString();
                        }
                    }


                }
                else if (text == "Particulier")
                {
                    double ParticulierPrijs;

                        foreach (BL.PrijsLijst prijs in prijsLijst)
                        {
                            if (prijs.Formule == cboFormules.Text)
                            {
                                ParticulierPrijs = prijs.Particulier;
                                labelPrijs.Text = (ParticulierPrijs * Convert.ToDouble(txtM3.Text)).ToString();
                            }
                        }
                    
                }
            }
            catch
            {

            }
         
        }

        private void radioAannemer1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
          
            timer3.Stop();
        }

        private void dataGridViewBestellingen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PaneelOverzicht_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            int lengteStringBTW = txtBtw.Text.Length;
            string btwnr = txtBtw.Text;
            var charsToRemove = new string[] { " ", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                btwnr = btwnr.Replace(c, string.Empty);
            }
            
         //   var info = EuropeanVatInformation.Get(cboBtwLand.Text + btwnr);
            string btwnrOld = btwnr;
            string btwnrNew = btwnrOld.Insert(4, ".");
            string btwnrNew1 = btwnrNew.Insert(8, ".");
            var url = "https://controleerbtwnummer.eu/api/validate/" + cboBtwLand.Text + btwnr + ".json";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var bedrijfsData = JsonConvert.DeserializeObject<BedrijfsData>(result);
             
             
                Debug.WriteLine(result);
                if(bedrijfsData.Valid)
                {
                    txtNaam.Text     = bedrijfsData.Name;
                    txtAdres.Text    = bedrijfsData.Address.Street + " " + bedrijfsData.Address.Number;
                    CboGemeente.Text = bedrijfsData.Address.City;
                    cboPostcode.Text = bedrijfsData.Address.ZipCode;  
                    txtBtw.Text      = btwnrNew1;    
                }
               
            }

        }
        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
           
        }
        //private async void TestGooglePlaces()
        //{
        //    Response results;
        //    var placeList = new List<Place>();
        //    string apiKey = "AIzaSyDJVdqr6W-gOGn9KOdsJxgDdvHgurY7om4";

           
        //        results = await Places.Api.TextSearch(txtAdres.Text, apiKey);
            
           

        //    //add the results to placeList
        //    foreach (var place in results.Places)
        //    {
        //        placeList.Add(place);
        //    }

        //    //if there are more than one 'page' of results...
        //    while (results.Next != null)
        //    {
        //        //get the next lot of results
        //        results = await Places.Api.GetNext(results.Next, apiKey);

        //        foreach (var place in results.Places)
        //        {
        //            placeList.Add(place);
        //        }
        //    }
        //    listBoxControl2.Visible = true;
        //    listBoxControl2.Items.Clear();
        //    foreach (var place in placeList)
        //    {
        //        var placeDetails = await Places.Api.GetDetails(place.PlaceId, apiKey);

        //        //do stuff with your place and placeDetails                
        //        string name = place.Name;
                
        //        string address = placeDetails.Address;
        //        //......

        //        listBoxControl2.Items.Add(address);
              
        //    }


            
        //}
        private void txtAdres_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void txtAdres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //TestGooglePlaces();
            }
            
        }

        private void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {
            string adres = listBoxControl2.SelectedItem.ToString();

            List<PostcodeGemeente> postcodesEnGemeentes = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            foreach(PostcodeGemeente item in postcodesEnGemeentes)
            {
                if (adres.Contains(item.Postcode))
                {
                    cboPostcode.Text = item.Postcode;
                    CboGemeente.Text = item.Gemeente;
                }
            }
           

            int index = adres.IndexOf(","); // Character to remove "?"
            if (index > 0)
                adres = adres.Substring(0, index); // This will remove all text after character ,
            listBoxControl2.Visible = false;
            txtAdres.Text = adres;
           // MessageBox.Show(adres);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
        
            if (labelUUR.Text == "?")
            {
                dtpDatum.EditValue = maandag;
            }
            KrijgBestellingenOpDag(maandag);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (labelUUR.Text == "?")
            {
                dtpDatum.EditValue = dinsdag;
            }
            KrijgBestellingenOpDag(dinsdag);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (labelUUR.Text == "?")
            {
                dtpDatum.EditValue = woensdag;
            }
            KrijgBestellingenOpDag(woensdag);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (labelUUR.Text == "?")
            {
                dtpDatum.EditValue = donderdag;
            }
            KrijgBestellingenOpDag(donderdag);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (labelUUR.Text == "?")
            {
                dtpDatum.EditValue = vrijdag;
            }
            KrijgBestellingenOpDag(vrijdag);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (labelUUR.Text == "?")
            {
                dtpDatum.EditValue = zaterdag;
            }
            KrijgBestellingenOpDag(zaterdag);
        }

        private void dataGridViewBestellingen_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmWerf = new FrmWerfWijzigen(bestelling.Werf,bestelling);
            frmWerf.Show();

            frmWerfClosing();
         
        }

        private void frmWerfClosing()
        {
            frmWerf.FormClosing += (sender, eventArgs) =>
            {
                dataGridViewBestellingen.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void dataGridViewBestellingen_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.dataGridViewBestellingen.ClearSelection();
                    this.dataGridViewBestellingen.Rows[rowSelected].Selected = true;
                }
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmProduct = new FrmProductWijzigen(bestelling,USER);
            frmProduct.Show();

            frmProductClosing();
        }

        private void frmProductClosing()
        {
            frmProduct.FormClosing += (sender, eventArgs) =>
            {
                dataGridViewBestellingen.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            BL.Bestelling bestellingPrint = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));

            string bestandsNaam = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
            if (File.Exists(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
            {
                File.Delete(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
            }
            bestellingPrint.GeneerExcellRec(false, "", USER);


            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            pd.PrinterSettings.Copies = 1;
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                string BestandsNaam = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                // Print the file to the printer.
                // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                new FileInfo(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + BestandsNaam + ".xlsx").Print();
                //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmPompWijzigen = new FrmPompWijzigen(bestelling);
            frmPompWijzigen.Show();

            frmPompWijzigenClosing();
        }

        private void frmPompWijzigenClosing()
        {
            frmPompWijzigen.FormClosing += (sender, eventArgs) =>
            {
                dataGridViewBestellingen.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmInfoWijzigen = new FrmInformatieAanpassen(bestelling);
            frmInfoWijzigen.Show();

            frmInfoWijzigenClosing();
        }

        private void frmInfoWijzigenClosing()
        {
            frmInfoWijzigen.FormClosing += (sender, eventArgs) =>
            {
                dataGridViewBestellingen.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void txtBestaandeWerf_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBestaandeWerf.Text.Count() > 1)
            {
                List<Werf> wervenFilter = new List<Werf>();
                string zoekWerf = txtBestaandeWerf.Text.ToLower();
                foreach (Werf werf in wervenList)
                {
                    if (werf.ToString().ToLower().Contains(zoekWerf))
                    {
                        wervenFilter.Add(werf);
                    }
                }
                wervenFilter.Sort((x, y) => x.ToString().CompareTo(y.ToString()));
                listBoxWerven.Items.Clear();
                listBoxWerven.Items.AddRange(wervenFilter.ToArray());
            }
        }

        private void txtBestaandeWerf_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            if (txtBestaandeWerf.Text != string.Empty)
            {
                listBoxWerven.Visible = true;
            }
            else { listBoxWerven.Visible = false; }
        }

        private void listBoxWerven_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBoxWerven_Click(object sender, EventArgs e)
        {
            if (listBoxWerven.SelectedItem != null)
            {
                geselecteerdeWerf = ((Werf)listBoxWerven.SelectedItem);
                labelWerfAdres.Text = geselecteerdeWerf.Adres;
                labelWerfGemeente.Text = geselecteerdeWerf.Gemeente;
                labelWerfPostcode.Text = geselecteerdeWerf.Postcode;
                labelWerfTelefoon.Text = geselecteerdeWerf.Telefoon;
                listBoxWerven.Visible = false;
                txtBestaandeWerf.Text = geselecteerdeWerf.ToString();
                LabelOverzichtWerf.Text = geselecteerdeWerf.ToString();
            }
        }

        private void txtBestaandeWerf_Click(object sender, EventArgs e)
        {
                listBoxWerven.Visible = true;
        }

        private void cboGemeenteWerf_TextChanged(object sender, EventArgs e)
        {
            if (checkFrankrijkWerf.Checked)
            {
                cboGemeenteWerf.Properties.AutoComplete = false;
            }
            else
            {
                cboGemeenteWerf.Properties.AutoComplete = true;
            }
        }

        private void checkFrankrijk_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkFrankrijkWerf.Checked)
            {
                cboGemeenteWerf.Properties.AutoComplete = false;
                cboPostcodeWerf.Properties.AutoComplete = false;
            }
            else
            {
                cboGemeenteWerf.Properties.AutoComplete = true;
                cboPostcodeWerf.Properties.AutoComplete = true;
            }
            
        }

        private void checkFrankrijk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFrankrijkWerf.Checked)
            {
                CboGemeente.Properties.AutoComplete = false;
                cboPostcode.Properties.AutoComplete = false;
            }
            else
            {
                CboGemeente.Properties.AutoComplete = true;
                cboPostcode.Properties.AutoComplete = true;
            }
        }

        private void CboGemeente_TextChanged(object sender, EventArgs e)
        {
            if (checkFrankrijk.Checked)
            {
                
                CboGemeente.Properties.AutoComplete = false;
                cboPostcode.Properties.AutoComplete = false;
                cboPostcode.Text = string.Empty;
            }
        }

        private void checkFrankrijk_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (checkFrankrijk.Checked)
            {
                CboGemeente.Properties.Items.Clear();
                CboGemeente.Properties.AutoComplete = false;
                cboPostcode.Properties.AutoComplete = false;
            }
            else
            {
                foreach(PostcodeGemeente gemeente in gemeentelijst)
                {
                    CboGemeente.Properties.Items.Add(gemeente.Gemeente);
                }
               
                CboGemeente.Properties.AutoComplete = true;
                cboPostcode.Properties.AutoComplete = true;
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            bool bestaatAl = false;
            List<Werf> werfControleList = Werf.KrijgAlleWervenVanKlantDoorKlantID(klant.ID);
            foreach (Werf werfControle in werfControleList)
            {
                 if(werfControle.Adres == klant.Adres && werfControle.Gemeente == klant.Gemeente && werfControle.Postcode == klant.Postcode)
                {
                    bestaatAl = true;
                }
            }

            if(bestaatAl == false)
            {
                txtAdresWerf.Text = klant.Adres;
                cboGemeenteWerf.Text = klant.Gemeente;
                cboPostcode.Text = klant.Postcode;
                txtTelefoonWerf.Text = klant.Gsm;
            }
            else
            {
                XtraMessageBox.Show("Er bestaat al een werf met het facturatie adres van de klant.","Foei",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         
        }

        private void groupControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LabelOverzichtKlant_TextChanged(object sender, EventArgs e)
        {
            checkKlant.Visible = true;
        }

        private void LabelOverzichtWerf_TextChanged(object sender, EventArgs e)
        {
            checkWerf.Visible = true;
        }

        private void LabelOverzichtProduct_TextChanged(object sender, EventArgs e)
        {
            checkProduct.Visible = true;
        }

        private void LabelOverzichtAantal_TextChanged(object sender, EventArgs e)
        {
            checkAantal.Visible = true;
        }

        private void labelHulpstoffen_TextChanged(object sender, EventArgs e)
        {
            checkHulpstof.Visible = true;
        }

        private void lblFormule_DoubleClick(object sender, EventArgs e)
        {
            if(cboProductOmschrijving.Visible == true) { cboProductOmschrijving.Visible = false; } else { cboProductOmschrijving.Visible = true; }

        }

        private void lblKlant_Click(object sender, EventArgs e)
        {

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
