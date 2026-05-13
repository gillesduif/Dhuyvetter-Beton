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
using System.IO;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DhuyvetterBeton.Beton.Agenda;
using System.Diagnostics;


namespace DhuyvetterBeton.Beton.Bestelling
{
    public partial class ucWijzigBestelling : DevExpress.XtraEditors.XtraUserControl
    {
      
        bool firstrun = true;
        string USER = string.Empty;
        DateTime olddatum;
        FrmHoofdVenster frmhoofd;
        string oldnaam;
        string versie;
        bool bestellingmee = false;
        List<Formule> FormuleList = Formule.KrijgAlleFormules();
        List<BL.Bestelling> wachtruimte = new List<BL.Bestelling>();
        List<BL.Bestelling> bestellingenFilter = new List<BL.Bestelling>();
        public ucWijzigBestelling(BL.Bestelling bestelling, string user, FrmHoofdVenster frmHoofd1, string versie1)
        {
            USER = user;
            InitializeComponent();
            versie = versie1;
            frmhoofd = frmHoofd1;


            if (user == "Pedro")
            {
                cboProductOmschrijving.Visible = false;
                cboFormules.Visible = true;
            }

            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            dtpDatum.EditValue = DateTime.Today;
            if (bestelling != null)
            {
                bestellingmee = true;
                List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(bestelling.Datum);
                dtpDatum.EditValue = bestelling.Datum;
                bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));

              
                //   dataGridViewBestellingen.DataSource = bestellingen;

                foreach (DataGridViewRow row in dataGridViewBestellingen.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == bestelling.ID)
                        row.Selected = true;
                }
               
                //listBoxBestellingen.Items.AddRange(bestellingen.ToArray());
                //if (listBoxBestellingen.Items != null)
                //{
                //    listBoxBestellingen.SelectedItem = listBoxBestellingen.SelectedIndex = 0;
                //}
            }
            else if (bestelling == null)
            {
                timer1.Start();
            }
            if (USER == "Pedro")
            {
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
            }
            dataGridViewBestellingen.Rows.Clear();
        }

        private void ucWijzigBestelling_Load(object sender, EventArgs e)
        {
            dtpBestellingenLaden.EditValue = DateTime.Today;
        }

        private void dtpBestellingenLaden_EditValueChanged(object sender, EventArgs e)
        {
    
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool saldo = false;
            if (checkBoxSaldo.Checked == true)
            {
                saldo = true;
            }
            int leveringchkb;
            Cursor.Current = Cursors.AppStarting;
            if (cboHulpstof.Text != string.Empty || txtHoeveelheidHulpstof.Text != string.Empty)
            {
                XtraMessageBox.Show("Gelieve hulpstof aan bestellingsbon toevoegen.");
            }
            else if (cboFormules.SelectedItem != null && cboKlanten.SelectedItem != null && cboWerven.SelectedItem != null && txtM3.Text != string.Empty)
            {
                Pomp pomp = new Pomp();
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
                Klant klant = ((Klant)cboKlanten.SelectedItem);
                Werf werf = ((Werf)cboWerven.SelectedItem);
                if (USER != "Pedro")
                {
                    if (txtM3.Text.Contains("."))
                    {
                        string m3value = txtM3.Text;
                        string m3updated = m3value.Replace(".", ",");
                        txtM3.Text = m3updated;
                    }
                }

                BL.Bestelling bestelling = new BL.Bestelling();
                bestelling.ID = Convert.ToInt32(labelID.Text);
                bestelling.Klant = klant;
                bestelling.Werf = werf;
                bestelling.Formule = formule;
                bestelling.Pomp = pomp;
                bestelling.Giek = cboGiek.Text;
                bestelling.M3 = Convert.ToDouble(txtM3.Text);
                bestelling.Datum = Convert.ToDateTime(dtpDatum.EditValue);
                bestelling.Levering = leveringchkb;

                bestelling.LeveringWijze = txtLeveringWijze.Text;
                bestelling.Loswijze = cboLoswijze.Text;
                bestelling.Comment = txtComment.Text;

                bestelling.UpdateBestelling();

           



                CodeRood coderood = CodeRood.KrijgCodeRoodDoorBestelID(bestelling.ID);
                coderood.Verwijdercodebestelling(coderood.ID);


               #region centraleagenda
               int bestellingID = Convert.ToInt32(labelID.Text);
               try
               {
                   AgendaLeveringen agendapunt = AgendaLeveringen.KrijgAgendapuntDoorBestellingID(bestellingID);
                   if (agendapunt != null)
                   {
                       agendapunt.Verwijder(bestellingID);
                   }
               }
               catch
               {
         
               }
              

         
              #endregion




                if (USER != "Pedro")
                {
                    #region maakExcell
              

             

                    string leveringwijze = " ";
                    if (txtLeveringWijze.Text == "")
                    {
                        leveringwijze = " ";
                    }
                    else
                    {
                        leveringwijze = txtLeveringWijze.Text;
                    }
                    BL.Bestelling bestelling1 = new BL.Bestelling(Convert.ToInt32(labelID.Text), ((Klant)cboKlanten.SelectedItem), ((Werf)cboWerven.SelectedItem), ((Formule)cboFormules.SelectedItem), ((Pomp)cboPompen.SelectedItem), cboGiek.Text, Convert.ToDouble(txtM3.Text), DateTime.Now, Convert.ToDateTime(dtpDatum.EditValue), leveringchkb, leveringwijze, cboLoswijze.Text, txtComment.Text);

                    string bestandsNaam = oldnaam + " " + olddatum.Hour.ToString() + "u" + olddatum.Minute.ToString();
                    if (File.Exists(@"Z:\Bestellingen\" + olddatum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                    {
                        File.Delete(@"Z:\Bestellingen\" + olddatum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                    }
                    bestelling1.GeneerExcellRec(saldo, "", USER);

                    Logboek logboek = new Logboek(DateTime.Now, "BESTELLINGEN", "[WIJZIGEN BESTELLING] Klant: " + bestelling1.Klant.Naam + " Product: " + cboProductOmschrijving.Text + " M3: " + bestelling1.M3.ToString() + " Datum: " + bestelling1.Datum, USER);
                    logboek.MaakNieuwLogBoekPunt();
                    #endregion





                    var message1 = "Wilt u dit document afdrukken?";
                    var title1 = "Keuze - Afdrukken";
                    var result1 = XtraMessageBox.Show(
                        message1,                  // the message to show
                        title1,                    // the title for the dialog box
                        MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                        MessageBoxIcon.Question); // show a question mark icon

                    // the following can be handled as if/else statements as well
                    switch (result1)
                    {
                        case DialogResult.Yes:
                            string BestandsNaam = klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();
                            // Print the file to the printer.
                            // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                            new FileInfo(@"Z:\Bestellingen\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + BestandsNaam + ".xlsx").Print();
                            //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();

                            break;
                        case DialogResult.No:    // No button pressed
                          
                            break;
                    }

     
                    Cursor.Current = Cursors.Default;

                }
                else
                {
                    AfdrukWachtRij afdrukwachterijControle = AfdrukWachtRij.KrijgOpdrachtViABestelID(Convert.ToInt32(labelID.Text));
                    if (afdrukwachterijControle.ID == 0)
                    {
                        AfdrukWachtRij afdrukwachterij = new AfdrukWachtRij(Convert.ToInt32(labelID.Text));
                        afdrukwachterij.MaakNieuwAfdrukTaak();
                    }

                }
                dataGridViewBestellingen.Rows.Clear();
                List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(Convert.ToDateTime(dtpBestellingenLaden.EditValue).Date);
                bestellingenFilter.Clear();
                wachtruimte.Clear();
                bestellingenFilter = new List<BL.Bestelling>();
                bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
                foreach (BL.Bestelling bestelling2 in bestellingen)
                {
                    if (bestelling2.Datum.Hour == 0 && bestelling2.Datum.Minute == 0)
                    {
                        wachtruimte.Add(bestelling2);
                        //   bestellingen.Remove(bestelling);
                    }
                    else
                    {
                        bestellingenFilter.Add(bestelling2);
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
            else
            {
                XtraMessageBox.Show("Er is iets fout gegaan. Gelieve alle velden in te vullen.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridViewBestellingen.Rows.Clear();
           
            List<string> productOmschrijveningen = new List<string>();
            List<Klant> klantenList = Klant.KrijgAlleKlanten();
            List<Pomp> pompenList = Pomp.KrijgAllePompen();
            pompenList.Sort((X, Y) => X.PompLeverancier.CompareTo(Y.PompLeverancier));
            FormuleList.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            cboKlanten.Properties.Items.AddRange(klantenList.ToArray());
            cboFormules.Items.AddRange(FormuleList.ToArray());
            cboPompen.Properties.Items.AddRange(pompenList.ToArray());
            List<SoortenHulpstof> hulpstofList = SoortenHulpstof.KrijgAlleSoortenHulpstof();
            cboHulpstof.Properties.Items.AddRange(hulpstofList.ToArray());
            //    listBoxBestellingen.Items.Clear();
           
            if (bestellingmee == false)
            {
                List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);
                bestellingenFilter.Clear();
                bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
                int counterbestellingen = bestellingen.Count;
              
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
                foreach (Formule formule in FormuleList)
                {
                    productOmschrijveningen.Add(formule.Omschrijving);
                }
                cboProductOmschrijving.Properties.Items.AddRange(productOmschrijveningen.ToArray());


                dataGridViewBestellingen.Rows.Clear();
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
            timer1.Stop();
        }
    
        private void dtpBestellingenLaden_Click(object sender, EventArgs e)
        {
   
        
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            dataGridViewBestellingen.Rows.Clear();
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

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            dataGridViewBestellingen.Rows.Clear();
            foreach (BL.Bestelling bestelling1 in wachtruimte)
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

        private void dtpBestellingenLaden_SelectionChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridViewBestellingen_SelectionChanged(object sender, EventArgs e)
        {
            if (firstrun == true)
            {
                firstrun = false;
            }
            else
            {
                if (dataGridViewBestellingen.SelectedCells.Count == 13)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
                    BL.Bestelling bestelling = new BL.Bestelling();
                    bestelling.ID = Convert.ToInt32(DGV[0].Value);
                    labelID.Text = bestelling.ID.ToString();
                    bestelling.Klant = (Klant)DGV[1].Value;
                    bestelling.Werf = (Werf)DGV[2].Value;
                    bestelling.Formule = ((Formule)DGV[3].Value);
                    bestelling.Pomp = ((Pomp)DGV[4].Value);
                    bestelling.Giek = DGV[5].Value.ToString();
                    bestelling.M3 = Convert.ToDouble(DGV[6].Value);
                    bestelling.Besteldatum = Convert.ToDateTime(DGV[7].Value);
                    bestelling.Datum = Convert.ToDateTime(DGV[8].Value);
                    bestelling.Levering = Convert.ToInt32(DGV[9].Value);
                    bestelling.LeveringWijze = DGV[10].Value.ToString();
                    bestelling.Loswijze = DGV[11].Value.ToString();
                    bestelling.Comment = DGV[12].Value.ToString();
                    txtM3.Text = bestelling.M3.ToString();
                    txtLeveringWijze.Text = bestelling.LeveringWijze;
                    cboGiek.Text = bestelling.Giek;
                    int index = 0;
                    foreach (Klant klant in cboKlanten.Properties.Items)
                    {
                        if (klant.ToString() == bestelling.Klant.ToString())
                        {
                            cboKlanten.SelectedIndex = index;
                            break;
                        }
                        index++;

                    }
                    cboFormules.SelectedIndex = cboFormules.FindString(bestelling.Formule.Naam);
                    List<Werf> wervenVanKlantLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(bestelling.Klant.ID);
                    wervenVanKlantLijst.Sort((x, y) => x.Adres.CompareTo(y.Adres));
                    cboWerven.Properties.Items.Clear();
                    olddatum = bestelling.Datum;
                    oldnaam = bestelling.Klant.Naam;
                    cboWerven.Properties.Items.AddRange(wervenVanKlantLijst.ToArray());
                    labelNaam.Text = bestelling.Klant.Naam;
                    labelAdres.Text = bestelling.Klant.Adres + " " +  bestelling.Klant.Gemeente;
                    labelTelefoon.Text = bestelling.Klant.Telefoon;
                    labelGSM.Text  = bestelling.Klant.Gsm;
                    labelBTW.Text = bestelling.Klant.Btw;
                    label11.Text = bestelling.Werf.Adres + " " + bestelling.Werf.Gemeente + " " + bestelling.Werf.Postcode;
                    int index5 = 0;
                    foreach (Pomp pomp in cboPompen.Properties.Items)
                    {
                        if (pomp.ToString() == bestelling.Pomp.ToString())
                        {
                            cboPompen.SelectedIndex = index5;
                            break;
                        }
                        index5++;

                    }

                    cboGiek.Text = bestelling.Giek;
                    dtpDatum.EditValue = bestelling.Datum;
                    Listboxhulpstoffen.Items.Clear();
                    List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(bestelling.ID);
                    Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
                    txtComment.Text = bestelling.Comment;
                    cboLoswijze.Text = bestelling.Loswijze;
                    if (txtComment.Text.Contains("saldo"))
                    {
                        checkBoxSaldo.Checked = true;
                    }

                    txtM3.Text = bestelling.M3.ToString();
                    txtLeveringWijze.Text = bestelling.LeveringWijze;
                    cboGiek.Text = bestelling.Giek;



              
                  
                   
                    cboFormules.SelectedIndex = cboFormules.FindString(bestelling.Formule.Naam);
                    int index69 = 0;
                    foreach (string omschrijvingProduct in cboProductOmschrijving.Properties.Items)
                    {
                        if (omschrijvingProduct == bestelling.Formule.Omschrijving)
                        {
                            cboProductOmschrijving.SelectedIndex = index69;
                            break;
                        }
                        index69++;

                    }




                    cboWerven.Properties.Items.Clear();
                    olddatum = bestelling.Datum;
                    oldnaam = bestelling.Klant.Naam;
                    cboWerven.Properties.Items.AddRange(wervenVanKlantLijst.ToArray());


                    int index1 = 0;
                    foreach (Werf werf in cboWerven.Properties.Items)
                    {
                        if (werf.ToString() == bestelling.Werf.ToString())
                        {
                            cboWerven.SelectedIndex = index1;
                            break;
                        }
                        index1++;

                    }


                    cboGiek.Text = bestelling.Giek;
                    dtpDatum.EditValue = bestelling.Datum;
                    Listboxhulpstoffen.Items.Clear();

                    Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
                    txtComment.Text = bestelling.Comment;
                    cboLoswijze.Text = bestelling.Loswijze;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            Formule formule = ((Formule)cboFormules.SelectedItem);
            Klant klant = ((Klant)cboKlanten.SelectedItem);
            Werf werf = ((Werf)cboWerven.SelectedItem);
            Pomp pomp;
            int leveringchkb;
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

            if(USER == "Pedro" && bestelling.Pomp.PompLeverancier == "D'huyvetter beton")
            {
                bestelling.GeneerPompExcell(false);
                PrintDocument pdoc = new PrintDocument();

                pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                string bestandsNaam = klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();
                Print(pdoc.PrinterSettings.PrinterName, @"Z:\PompFiches\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
            }
            else if (bestelling.Pomp.PompLeverancier == "D'huyvetter beton")
            {
                bestelling.GeneerPompExcell(false);
                
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                pd.PrinterSettings.Copies = 1;
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    string bestandsNaam = klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();
                    // Print the file to the printer.
                    // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                    new FileInfo(@"Z:\PompFiches\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();
                    //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();
                }

            }
        }
        private void Print(string printerName, string fileName)
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
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            bool saldo = false;
            if (checkBoxSaldo.Checked == true)
            {
                saldo = true;
            }
            Pomp pomp;
            int leveringchkb;
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
            Klant klant = ((Klant)cboKlanten.SelectedItem);
            Werf werf = ((Werf)cboWerven.SelectedItem);


            BL.Bestelling bestelling = new BL.Bestelling();
            bestelling.ID = Convert.ToInt32(labelID.Text);
            bestelling.Klant = klant;
            bestelling.Werf = werf;
            bestelling.Formule = formule;
            bestelling.Pomp = pomp;
            bestelling.Giek = cboGiek.Text;
            bestelling.M3 = Convert.ToDouble(txtM3.Text);
            bestelling.Datum = Convert.ToDateTime(dtpDatum.EditValue);
            bestelling.Levering = leveringchkb;

            bestelling.LeveringWijze = txtLeveringWijze.Text;
            bestelling.Loswijze = cboLoswijze.Text;
            bestelling.Comment = txtComment.Text;
            BL.Bestelling bestelling1 = new BL.Bestelling(Convert.ToInt32(labelID.Text), ((Klant)cboKlanten.SelectedItem), ((Werf)cboWerven.SelectedItem), ((Formule)cboFormules.SelectedItem), ((Pomp)cboPompen.SelectedItem), cboGiek.Text, Convert.ToDouble(txtM3.Text), DateTime.Now, Convert.ToDateTime(dtpDatum.EditValue), leveringchkb, txtLeveringWijze.Text, cboLoswijze.Text, txtComment.Text);

            string bestandsNaam = oldnaam + " " + olddatum.Hour.ToString() + "u" + olddatum.Minute.ToString();
            if (File.Exists(@"Z:\Bestellingen\" + olddatum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
            {
                File.Delete(@"Z:\Bestellingen\" + olddatum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
            }
            bestelling1.GeneerExcellRec(saldo, "", USER);
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            pd.PrinterSettings.Copies = 1;
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                string BestandsNaam = klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();
                // Print the file to the printer.
                // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                new FileInfo(@"Z:\Bestellingen\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + BestandsNaam + ".xlsx").Print();
                //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
         
        }

        private void dtpBestellingenLaden_EditValueChanged_1(object sender, EventArgs e)
        {
            dataGridViewBestellingen.Rows.Clear();

            Cursor.Current = Cursors.AppStarting;
            List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(dtpBestellingenLaden.SelectionStart.Date);
            bestellingenFilter.Clear();
            wachtruimte.Clear();
            bestellingenFilter = new List<BL.Bestelling>();
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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            BL.Bestelling bestelling = new BL.Bestelling();
            bestelling.ID = Convert.ToInt32(DGV[0].Value);
            labelID.Text = bestelling.ID.ToString();
            bestelling.Klant = (Klant)DGV[1].Value;
            bestelling.Werf = (Werf)DGV[2].Value;
            bestelling.Formule = ((Formule)DGV[3].Value);
            bestelling.Pomp = ((Pomp)DGV[4].Value);
            bestelling.Giek = DGV[5].Value.ToString();
            bestelling.M3 = Convert.ToDouble(DGV[6].Value);
            bestelling.Besteldatum = Convert.ToDateTime(DGV[7].Value);
            bestelling.Datum = Convert.ToDateTime(DGV[8].Value);
            bestelling.Levering = Convert.ToInt32(DGV[9].Value);
            bestelling.LeveringWijze = DGV[10].Value.ToString();
            bestelling.Loswijze = DGV[11].Value.ToString();
            bestelling.Comment = DGV[12].Value.ToString();
            //BL.Bestelling bestelling = ((BL.Bestelling)listBoxBestellingen.SelectedItem);
            Hulpstof hulpstof = new Hulpstof();
            hulpstof.Naam = cboHulpstof.Text;
            if (txtHoeveelheidHulpstof.Text != string.Empty)
            {
                hulpstof.Hoeveelheid = txtHoeveelheidHulpstof.Text;
            }
            else
            {
                hulpstof.Hoeveelheid = " ";
            }

            hulpstof.Bestelling = bestelling;
            hulpstof.Voeghulpstoftoe();
            cboHulpstof.Text = string.Empty;
            txtHoeveelheidHulpstof.Text = string.Empty;
            Listboxhulpstoffen.Items.Clear();
            List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(bestelling.ID);
            Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
            Cursor.Current = Cursors.Default;
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

        private void simpleButton8_Click_1(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }

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

          //  cboFormules.SelectedIndex = cboFormules.FindString((cboProductOmschrijving.SelectedItem).ToString());
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            int index = Listboxhulpstoffen.SelectedIndex;
            Hulpstof hulpstof = ((Hulpstof)Listboxhulpstoffen.SelectedItem);
            hulpstof.verwijderHulpstof();
            Listboxhulpstoffen.Items.RemoveAt(index);
        }

        private void lblFormule_DoubleClick(object sender, EventArgs e)
        {
            if (cboProductOmschrijving.Visible == true) { cboProductOmschrijving.Visible = false; cboFormules.Visible
                     = true;
            }
            else { cboProductOmschrijving.Visible = true; cboFormules.Visible
                     = false;
            }
            
        }
    }
}
