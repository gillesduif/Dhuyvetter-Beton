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
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using DhuyvetterBeton.Beton.Bestelling;
using DhuyvetterBeton.Beton.Bestelling.Tools;
using DevExpress.XtraBars;
using Google.Cloud.Firestore;
using DhuyvetterBeton.Beton.Properties;

namespace DhuyvetterBeton.Beton.Agenda
{
    public partial class ucAgendaBeton : DevExpress.XtraEditors.XtraUserControl
    {
        FirestoreDb database;

        FirestoreDb db;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);



        string versie;

        FrmWerfWijzigen frmWerf;
        FrmProductWijzigen frmProduct;
        FrmPompWijzigen frmPompWijzigen;
        FrmInformatieAanpassen frmInfoWijzigen;
        FrmHulpstofWijzigen frmHulpstofWijzigen;

        List<Voertuig> voertuigenList = Voertuig.KrijgAlleVoertuigen();
        List<Chauffeur> chauffeursList = Chauffeur.KrijgAlleChauffeurs();
        List<BL.Bestelling> BestellingenOphalen;
      
        BL.Bestelling bestelling;
        Klant klant;
        Werf werf;
        Formule formule;
        Pomp pomp;
        string giek;
        double m3;
        DateTime datumTijd;
        int levering;
        string leveringWijze;
        string loswijze;
        string comment;
        string user;
       // bool kleurcode = false;
        DateTime maandag = new DateTime();
        DateTime dinsdag = new DateTime();
        DateTime woensdag = new DateTime();
        DateTime donderdag = new DateTime();
        DateTime vrijdag = new DateTime();
        DateTime zaterdag = new DateTime();
        private void KrijgBestellingenOpDag(DateTime date)
        {
            timer1.Stop();
            timer1.Start();
            List<BestellingPrefab> prefabBestellingen = BestellingPrefab.KrijgAlleBestellingenDoorDatum(date, date.AddDays(+1));
            prefabBestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));

            bunifuCustomDataGridPrefab.DataSource = null;
            bunifuCustomDataGridPrefab.Rows.Clear();
            foreach (BestellingPrefab prefabBestelling in prefabBestellingen)
            {
                bunifuCustomDataGridPrefab.Rows.Add(
                    new object[]
                    {
                        prefabBestelling.ID,
                        prefabBestelling.KlantPrefab,
                        prefabBestelling.WerfPrefab,
                        prefabBestelling.Datum,
                        prefabBestelling.Levering,
                        prefabBestelling.Opmerking
                    }

                    );
            }
            bunifuCustomDataGridBeton.Rows.Clear();
            bunifuCustomDataGridBeton.Rows.Clear();
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
                bunifuCustomDataGridBeton.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Datum.ToShortTimeString(),
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                    }

                    );
            }
            dtpDatum.EditValue = date;
            List<AfvoerInvoer> afvoerInvoerBonnen = AfvoerInvoer.KrijgAlleAfVoerInvoerItemsVoorDatums(date, date.AddDays(+1));
            if (DateTime.Today.Date.AddDays(+1) > Convert.ToDateTime(dtpDatum.EditValue).Date)
            {
                int counter = 0;

                foreach (BL.Bestelling bestelling in bestellingenFilter)
                {
                    CodeRood coderood = CodeRood.KrijgCodeRoodDoorBestelID(bestelling.ID);

                    try
                    {
                        AgendaLeveringen agendapunt = AgendaLeveringen.KrijgAgendapuntDoorBestellingID(bestelling.ID);

                        if (agendapunt.ID != 0)
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#029B46"); ;
                            counter++;
                        }
                        else if (coderood.BestelID != 0)
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                            counter++;
                        }
                        else
                        {
                            bool isAfvoerbon = false;
                            foreach (AfvoerInvoer aanvoerAfvoerBon in afvoerInvoerBonnen)
                            {
                                if (aanvoerAfvoerBon.Klant.ToString() == bestelling.Klant.ToString() && aanvoerAfvoerBon.Formule.Naam == bestelling.Formule.Naam)
                                {
                                    bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3BF00");
                                    counter++;
                                    isAfvoerbon = true;
                                }
                            }
                            if (isAfvoerbon == false)
                            {
                                bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                                counter++;
                            }
                        }
                    }
                    catch
                    {
                        if (coderood.BestelID != 0)
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                            counter++;
                        }
                        else
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                            counter++;
                        }

                    }
                }
              
            }
            else
            {
                try
                {
                    splashScreenManager1.CloseWaitForm();
                }
               catch { }
            }
        }
        public ucAgendaBeton(string USER, string versie1, List<BL.Bestelling> BestellingenOpstart)
        {
            BestellingenOphalen = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);
            InitializeComponent();
            user = USER;
            versie = versie1;
            dtpDatum.EditValue = DateTime.Today;
            timer1.Start();
        }

        private void ucAgenda_Load(object sender, EventArgs e)
        {
            object O = Resources.ResourceManager.GetObject("neg_01");

            //pictureBox2.Image = (Image)O;
            string path = AppDomain.CurrentDomain.BaseDirectory + @"dbintern-56185-firebase-adminsdk-50c46-700d8feb2f.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("cloudfire-afca3");



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
            listViewBonnen.View = View.Details;
            listViewBonnen.GridLines = true;
            listViewBonnen.FullRowSelect = true;
            bunifuCustomDataGridBeton.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGridPrefab.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");

            bunifuCustomDataGridBeton.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);

            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            if (screenHeight == "2160" && screenWidth == "3840")
            {
                this.Width = 3566;
            }
          
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            bunifuCustomDataGridBeton.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGridBeton.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            int bestellingID = Convert.ToInt32(DGV[0].Value);
            datumTijd = Convert.ToDateTime(DGV[1].Value);
            klant = (((Klant)DGV[2].Value));
            werf = ((Werf)DGV[3].Value);
            formule = ((Formule)DGV[4].Value);
            pomp = ((Pomp)DGV[5].Value);
            giek = DGV[6].Value.ToString();
            m3 = Convert.ToDouble(DGV[7].Value.ToString());
     
            levering = Convert.ToInt32(DGV[9].Value);
            leveringWijze = Convert.ToString(DGV[10].Value);
            loswijze = Convert.ToString(DGV[11].Value);
            comment = Convert.ToString(DGV[12].Value);
            bestelling = new BL.Bestelling(bestellingID, klant, werf, formule, pomp, giek, m3, DateTime.Today, datumTijd, levering, leveringWijze, loswijze, comment);
            List<Chauffeur> chauffeurs = Chauffeur.KrijgAlleChauffeurs();
            List<Voertuig> voertuigen = Voertuig.KrijgAlleVoertuigen();
            Chauffeur chauffeur1 = new Chauffeur();
            Voertuig voertuig1 = new Voertuig();
            foreach (Chauffeur chauffeur in chauffeurs)
            {
                if (chauffeur.Naam == "GEEN")
                {
                    chauffeur1 = chauffeur;
                }
            }
            foreach (Voertuig voertuig in voertuigen)
            {
                if (voertuig.Nummerplaat == "GEEN")
                {
                    voertuig1 = voertuig;
                }
            }
            //Hulpstof hulpstof = (((Hulpstof)DGV[10].Value));
            //string hulpstofHoeveelheid = Convert.ToString(DGV[11].Value);
            AgendaLeveringen agendalevering = new AgendaLeveringen(klant, werf, voertuig1, chauffeur1, formule, m3, datumTijd, pomp, giek, levering, leveringWijze, loswijze, comment, bestelling);
            agendalevering.MaakNieuwAgendaPunt();
            int index = bunifuCustomDataGridBeton.SelectedRows[0].Index;
            bunifuCustomDataGridBeton.Rows[index].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#029B46");
            XtraMessageBox.Show("De bestelling is verzonden naar de centrale.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            simpleButton1.Enabled = false;
            //dataGridViewDoorsturenNaarCentrale.Rows[0].Selected = true;
            //zoeken();
            Logboek logboek = new Logboek(DateTime.Now, "AGENDA", "[AGENDA PUNT VERSTUURD NAAR CENTRALE] Klant: " + klant.Naam + " Werf: " + werf.Adres + " " + werf.Gemeente + " " + formule + " " + m3.ToString(), user);
            logboek.MaakNieuwLogBoekPunt();
        }
        void Add_Document(BL.Bestelling bestelling)
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (simpleButton2.Text == "Verwijder annulatie")
            {
                int index = bunifuCustomDataGridBeton.SelectedRows[0].Index;
                bunifuCustomDataGridBeton.Rows[index].DefaultCellStyle.BackColor = Color.White;
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
                int bestelID = Convert.ToInt32(DGV[0].Value);
                Klant klant1 = (((Klant)DGV[2].Value));
                Werf werf1 = ((Werf)DGV[3].Value);
                CodeRood coderood2 = CodeRood.KrijgCodeRoodDoorBestelID(bestelID);
                coderood2.Verwijdercodebestelling(coderood2.ID);
                BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(bestelID);
                Add_Document(bestelling);
                simpleButton2.Text = "Annuleren";
                simpleButton1.Enabled = true;
                Logboek logboek = new Logboek(DateTime.Now, "AGENDA", "[AGENDA PUNT GAAT TERUG DOOR] Klant: " + klant1.Naam + " Werf: " + werf1.Adres + " " + werf1.Gemeente, user);
                logboek.MaakNieuwLogBoekPunt();

            }
            else
            {
                int index = bunifuCustomDataGridBeton.SelectedRows[0].Index;
                bunifuCustomDataGridBeton.Rows[index].DefaultCellStyle.BackColor = Color.IndianRed;
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
                int bestelID = Convert.ToInt32(DGV[0].Value);
                Klant klant1 = (((Klant)DGV[2].Value));
                Werf werf1 = ((Werf)DGV[3].Value);
                CodeRood codeRood = new CodeRood();
                codeRood.BestelID = bestelID;
                codeRood.KlantID = 0;
                codeRood.MaakNieuweCode();
                db = FirestoreDb.Create("dbintern-56185");
                Delete_An_Entire_Document(bestelID.ToString());
                simpleButton2.Text = "Verwijder annulatie";
                simpleButton1.Enabled = false;
                Logboek logboek = new Logboek(DateTime.Now, "AGENDA", "[AGENDA PUNT GEANNULEERD] Klant: " + klant1.Naam + " Werf: " + werf1.Adres + " " + werf1.Gemeente, user);
                logboek.MaakNieuwLogBoekPunt();
            }
        }

        void Delete_An_Entire_Document(string id)
        {
            DocumentReference docref = db.Collection("Bestellingen").Document(id);
            docref.DeleteAsync();
        }
        public void zoeken()
        {
            DateTime datumSelectie = (DateTime)dtpDatum.EditValue;
            labelBetonAgenda.Text = "Beton Agenda - " + datumSelectie.Date.ToShortDateString();
            labelAgendaPrefab.Text = "Prefab Agenda - " + datumSelectie.Date.ToShortDateString();
            List<BestellingPrefab> prefabBestellingen = BestellingPrefab.KrijgAlleBestellingenDoorDatum(dtpDatum.SelectionStart.Date, dtpDatum.SelectionStart.Date.AddDays(+1));
            prefabBestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));

            bunifuCustomDataGridPrefab.DataSource = null;
            bunifuCustomDataGridPrefab.Rows.Clear();
            foreach (BestellingPrefab prefabBestelling in prefabBestellingen)
            {
                bunifuCustomDataGridPrefab.Rows.Add(
                    new object[]
                    {
                        prefabBestelling.ID,
                        prefabBestelling.KlantPrefab,
                        prefabBestelling.WerfPrefab,
                        prefabBestelling.Datum,
                        prefabBestelling.Levering,
                        prefabBestelling.Opmerking
                    }

                    );
            }
            bunifuCustomDataGridBeton.Rows.Clear();
            splashScreenManager1.ShowWaitForm();
            double totaalTon = 0;
            double totaalM3 = 0;
       
            Cursor.Current = Cursors.WaitCursor;
            if(BestellingenOphalen.Count != 0) { }
            else
            {
                BestellingenOphalen = BL.Bestelling.KrijgBestellingenDoorDatum(dtpDatum.SelectionStart.Date);

                BestellingenOphalen.Sort((x, y) => x.Datum.CompareTo(y.Datum));
            }
            BestellingenOphalen = BL.Bestelling.KrijgBestellingenDoorDatum(dtpDatum.SelectionStart.Date);

            BestellingenOphalen.Sort((x, y) => x.Datum.CompareTo(y.Datum));

            foreach (BL.Bestelling bestelling in BestellingenOphalen)
            {
                if (bestelling.Formule.Naam == "10 Teelaar" || bestelling.Formule.Naam == "13 Spuitza" || bestelling.Formule.Naam == "14 Bakstee" || bestelling.Formule.Naam == "3 Breekza" || bestelling.Formule.Naam == "4 0/2 Zand" || bestelling.Formule.Naam == "5 0/5 Zand" || bestelling.Formule.Naam == "6 0/7 Zand" || bestelling.Formule.Naam == "7 2/6 Gr" || bestelling.Formule.Naam == "8 6/14 Gr" || bestelling.Formule.Naam == "9 3/10" || bestelling.Formule.Naam == "betonzand" || bestelling.Formule.Naam == "zeezand" || bestelling.Formule.Naam == "2" || bestelling.Formule.Naam == "pousse")
                {
                    totaalTon = totaalTon + bestelling.M3;
                }

                else
                {
                    totaalM3 = totaalM3 + bestelling.M3;
                }
            }

            labelTotaalM3.Text = totaalM3.ToString();
            labelTotaalTon.Text = totaalTon.ToString();
            foreach (BL.Bestelling bestelling1 in BestellingenOphalen)
            {
                
                bunifuCustomDataGridBeton.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Datum.ToShortTimeString(),
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                    }

                    );
            }
            bunifuCustomDataGridBeton.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGridBeton.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");


            List<AfvoerInvoer> afvoerInvoerBonnen = AfvoerInvoer.KrijgAlleAfVoerInvoerItemsVoorDatums(DateTime.Today, DateTime.Today.AddDays(+1));
            int counter = 0;
            if (DateTime.Today.Date.AddDays(+1) > Convert.ToDateTime(dtpDatum.EditValue).Date)
            {


                foreach (BL.Bestelling bestelling in BestellingenOphalen)
                {
                    CodeRood coderood = CodeRood.KrijgCodeRoodDoorBestelID(bestelling.ID);

                    try
                    {
                        AgendaLeveringen agendapunt = AgendaLeveringen.KrijgAgendapuntDoorBestellingID(bestelling.ID);

                        if (agendapunt.ID != 0)
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#029B46"); ;
                            counter++;
                        }
                        else if (coderood.BestelID != 0)
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                            counter++;
                        }
                        
                        else
                        {
                            bool isAfvoerbon = false;
                            foreach(AfvoerInvoer aanvoerAfvoerBon in afvoerInvoerBonnen)
                            {
                                if(aanvoerAfvoerBon.Klant.ToString() == bestelling.Klant.ToString() && aanvoerAfvoerBon.Formule.Naam == bestelling.Formule.Naam)
                                {
                                    bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F3BF00");
                                    counter++;
                                    isAfvoerbon = true;
                                }
                            }
                            if(isAfvoerbon == false)
                            {
                                bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                                counter++;
                            }
                            
                        }
                    }
                    catch
                    {
                        if (coderood.BestelID != 0)
                        {
                            bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = Color.IndianRed;
                            counter++;
                        }
                        else
                        {
                            try
                            {
                                bunifuCustomDataGridBeton.Rows[counter].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                            }
                            catch { }
                          
                            counter++;
                        }

                    }
                }
                try
                {
                    int index = bunifuCustomDataGridBeton.SelectedRows[0].Index; 
                    if (bunifuCustomDataGridBeton.Rows[index].DefaultCellStyle.BackColor == ColorTranslator.FromHtml("#029B46"))
                    {
                        simpleButton1.Enabled = false;
                    }
                    else
                    {
                        simpleButton1.Enabled = true;
                    }
                    splashScreenManager1.CloseWaitForm();

                    Cursor.Current = Cursors.Default;
                }
                catch { splashScreenManager1.CloseWaitForm(); }
            }
            else
            {
                splashScreenManager1.CloseWaitForm();
            }
            BestellingenOphalen.Clear();

        }
        private void dtpDatum_Click(object sender, EventArgs e)
        {
            zoeken();
            DateTime datumSelectie = (DateTime)dtpDatum.EditValue;
            labelBetonAgenda.Text = "Beton Agenda - " + datumSelectie.Date.ToShortDateString();
            labelAgendaPrefab.Text = "Prefab Agenda - " + datumSelectie.Date.ToShortDateString();
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            if (bunifuCustomDataGridBeton.SelectedCells.Count == 13)
            {
                int index = bunifuCustomDataGridBeton.SelectedRows[0].Index;
                if (bunifuCustomDataGridBeton.Rows[index].DefaultCellStyle.BackColor == Color.GreenYellow)
                {
                    simpleButton1.Enabled = false;
                }
                else
                {
                    simpleButton1.Enabled = true;
                }
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
                CodeRood coderood = CodeRood.KrijgCodeRoodDoorBestelID(Convert.ToInt32(DGV[0].Value));
                if (coderood.ID != 0)
                {
                    simpleButton2.Text = "Verwijder annulatie";
                    simpleButton1.Enabled = false;
                }
                else
                {
                    simpleButton2.Text = "Annuleren";
                    try
                    {
                        bool agendapuntBestaat = AgendaLeveringen.BestaatAgendaPunt(Convert.ToInt32(DGV[0].Value));
                        if (agendapuntBestaat == true)
                        {

                            simpleButton1.Enabled = false;
                        }
                        else
                        {
                            simpleButton1.Enabled = true;
                        }
                    }
                    catch { }
                }
               

                DateTime datum = dtpDatum.DateTime.Date;
                Debug.WriteLine(datum.ToString());
                DateTime Tijd = Convert.ToDateTime(DGV[1].Value);
                DateTime datumTijd = new DateTime(datum.Year, datum.Month, datum.Day, Tijd.Hour, Tijd.Minute,Tijd.Second);
                labelDatumTijd.Text = datumTijd.ToShortDateString() + " - " + datumTijd.ToShortTimeString();
                Klant klant = ((Klant)DGV[2].Value);
                labelKlant.Text = klant.Naam;
                labelGSM.Text = klant.Gsm;
                labelTelefoon.Text = klant.Telefoon;
                labelWerf.Text = DGV[3].Value.ToString();
                labelFormule.Text = DGV[4].Value.ToString();
                if (labelFormule.Text == "10 Teelaar" || labelFormule.Text == "13 Spuitza" || labelFormule.Text == "14 Bakstee" || labelFormule.Text == "3 Breekza" || labelFormule.Text == "4 0/2 Zand" || labelFormule.Text == "5 0/5 Zand" || labelFormule.Text == "6 0/7 Zand" || labelFormule.Text == "7 2/6 Gr" || labelFormule.Text == "8 6/14 Gr" || labelFormule.Text == "9 3/10" || labelFormule.Text == "betonzand" || labelFormule.Text == "zeezand" || labelFormule.Text == "2" || labelFormule.Text == "pousse")
                {
                    lblHoeveelHeidIndicatie.Text = "Ton:";
                }
                else if (labelFormule.Text == "Mortel")
                {
                    lblHoeveelHeidIndicatie.Text = "Liter:";

                }
                else if (labelFormule.Text == "betonblokken")
                {
                    lblHoeveelHeidIndicatie.Text = "Stuks:";
                }
                else
                {
                    lblHoeveelHeidIndicatie.Text = "M³:";
                }
                labelPomp.Text = DGV[5].Value.ToString();
                labelGiek.Text = DGV[6].Value.ToString();
                labelM3.Text = DGV[7].Value.ToString();
           
           


                labelLeveringWijze.Text = Convert.ToString(DGV[10].Value);
                labelLoswijze.Text = Convert.ToString(DGV[11].Value);
                labelOpmerking.Text = Convert.ToString(DGV[12].Value);
                Listboxhulpstoffen.Items.Clear();

                List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(Convert.ToInt32(DGV[0].Value));
                Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
                if (Listboxhulpstoffen.Items.Count > 0)
                {
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }
        }

        private void dtpDatum_SelectionChanged(object sender, EventArgs e)
        {
            zoeken();
        }

        private void dtpDatum_SizeChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
        
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpDatum_SelectionChanged_1(object sender, EventArgs e)
        {
            zoeken();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
           
        }

        private void timerLaden_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGridPrefab_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                listBoxPrefabLoten.Items.Clear();
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridPrefab.SelectedCells;

                BestellingPrefab bestellingPrefab = new BestellingPrefab(Convert.ToInt32((DGV[0].Value)), ((KlantPrefab)DGV[1].Value), ((WerfPrefab)DGV[2].Value), null, ((DateTime)DGV[3].Value), DGV[4].Value.ToString(), DGV[5].Value.ToString());
                List<ProductPrefab> producten = ProductPrefab.KrijgProductenVoorBestelling(bestellingPrefab.ID);
                listBoxPrefabLoten.Items.AddRange(producten.ToArray());
            }
            catch
            {

            }
        }

        private void bunifuCustomDataGridPrefab_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGridPrefab.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGridPrefab.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGridPrefab.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGridPrefab.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void bunifuCustomDataGridPrefab_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void bunifuCustomDataGridPrefab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var message = "Bent u zeker dat u het geselecteerde prefab bestelling wilt verwijderen?";
                var title = "Keuze - verwijderen bon";
                var result = XtraMessageBox.Show(
                    message,                  // the message to show
                    title,                    // the title for the dialog box
                    MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                    MessageBoxIcon.Question); // show a question mark icon

                // the following can be handled as if/else statements as well
                switch (result)
                {
                    case DialogResult.Yes:   // Yes button pressed
                        DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridPrefab.SelectedCells;
                        BestellingPrefab prefabBestelling = new BestellingPrefab();
                        prefabBestelling.ID = Convert.ToInt32(DGV[0].Value);
                        List<ProductPrefab> producten = ProductPrefab.KrijgProductenVoorBestelling(prefabBestelling.ID);
                        prefabBestelling.ProductPrefab = producten;
                        prefabBestelling.Verwijderen(Convert.ToInt32(DGV[0].Value));

                        zoeken();
                        break;
                    case DialogResult.No:    // No button pressed

                        break;
                    default:                 // Neither Yes nor No pressed (just in case)

                        break;
                }
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            KrijgBestellingenOpDag(maandag);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            KrijgBestellingenOpDag(dinsdag);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            KrijgBestellingenOpDag(woensdag);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            KrijgBestellingenOpDag(donderdag);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            KrijgBestellingenOpDag(vrijdag);
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            KrijgBestellingenOpDag(zaterdag);
        }

        private void dtpDatum_DateTimeChanged(object sender, EventArgs e)
        {
            DateTime datumSelectie = (DateTime)dtpDatum.EditValue;
            labelBetonAgenda.Text = "Beton Agenda - " + datumSelectie.Date.ToShortDateString();
            labelAgendaPrefab.Text = "Prefab Agenda - " + datumSelectie.Date.ToShortDateString();
        }

        private void bunifuCustomDataGridBeton_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void bunifuCustomDataGridBeton_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void bunifuCustomDataGridBeton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
                
            }
            else
            {
                Point cp = PointToClient(Cursor.Position);
                Cursor.Current = Cursors.AppStarting;
                listViewBonnen.Items.Clear();
                balancePanel.Visible = true;
               this.balancePanel.Location = new Point(
               cp.X + 20,
                cp.Y + 20);

                if (bunifuCustomDataGridBeton.SelectedCells.Count == 13)
                {
                    DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;

                    Klant klant1 = (((Klant)DGV[2].Value));
                    Werf werf1 = ((Werf)DGV[3].Value);
                    Formule formule1 = ((Formule)DGV[4].Value);
                    DateTime datum = dtpDatum.DateTime.Date;

                    List<NormaleLeveringBon> leveringbonnen = NormaleLeveringBon.KrijgBestellingenDoorDatumEnKlantEnProductEnWerf(datum, datum.Date.AddDays(+1), klant1.ID, formule1.ID, werf1.ID);
                    leveringbonnen.Sort((X, Y) => X.ID.CompareTo(Y.ID));
                    double aantalM3 = 0;
                    string maatEenheid = string.Empty;
                    foreach (NormaleLeveringBon bon in leveringbonnen)
                    {
                        maatEenheid = bon.Formule.MaatEenheid;
                        string[] arr = new string[4];
                        ListViewItem itm;
                        //add items to ListView
                        arr[0] = bon.ID.ToString();
                        arr[1] = bon.Datum.ToShortTimeString();
                        arr[2] = bon.M3.ToString();
                        itm = new ListViewItem(arr);
                        listViewBonnen.Items.Add(itm);
                        aantalM3 = aantalM3 + bon.M3;
                    }

                    if(leveringbonnen.Count < 3)
                    {
                        balancePanel.Height = 200;
                        balancePanel.Visible = true;
                    }
                    else if (leveringbonnen.Count > 9)
                    {
                        balancePanel.Height = 300;
                        balancePanel.Visible = true;
                    }
                    else if (leveringbonnen.Count == 0)
                    {
                        balancePanel.Visible = false;
                    }
                    label11.Text = "Geleverd: "+ aantalM3.ToString() + "/" + DGV[7].Value.ToString() + " " + maatEenheid;
                }
            }
           
        }

        private void bunifuCustomDataGridBeton_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.bunifuCustomDataGridBeton.ClearSelection();
                    this.bunifuCustomDataGridBeton.Rows[rowSelected].Selected = true;
                }
             
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            timer1.Stop();
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmWerf = new FrmWerfWijzigen(bestelling.Werf, bestelling);
            frmWerf.Show();

            frmWerfClosing();
        }

        private void frmWerfClosing()
        {
            frmWerf.FormClosing += (sender, eventArgs) =>
            {
                AfdrukkenNaWijziging();
                bunifuCustomDataGridBeton.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void AfdrukkenNaWijziging()
        {
            var message = "Wilt u een nieuw rood briefje laten afdrukken?";
            var title = "Keuze - aanpassing afdrukken";
            var result = XtraMessageBox.Show(
                message,                  // the message to show
                title,                    // the title for the dialog box
                MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                MessageBoxIcon.Question); // show a question mark icon

            // the following can be handled as if/else statements as well
            switch (result)
            {
                case DialogResult.Yes:
                    DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
                    BL.Bestelling bestellingPrint = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
                    if (user != "Pedro")
                    {
                       
                        string bestandsNaam = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                        if (File.Exists(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                        {
                            File.Delete(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                        }
                        bestellingPrint.GeneerExcellRec(false, "", user);

                            string BestandsNaam = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                            // Print the file to the printer.
                            // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                            new FileInfo(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + BestandsNaam + ".xlsx").Print();
                        //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();
                        if (bestellingPrint.Pomp.PompLeverancier == "D'huyvetter beton")
                        {
                            bestellingPrint.GeneerPompExcell(false);

                          
                                string bestandsNaamPomp = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                                // Print the file to the printer.
                                // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                                new FileInfo(@"Z:\PompFiches\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaamPomp + ".xlsx").Print();
                                //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();
                            
                        }
                    }
                    else
                    {
                        string bestandsNaam = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                        if (File.Exists(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                        {
                            File.Delete(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                        }
                        bestellingPrint.GeneerExcellRec(false, "", user);
                        PrintDocument pdoc = new PrintDocument();

                        pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                        PrintCentrale(pdoc.PrinterSettings.PrinterName, @"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");

                        if(bestellingPrint.Pomp.PompLeverancier == "D'huyvetter beton")
                        {
                            bestellingPrint.GeneerPompExcell(false);
                            PrintDocument pdocPomp = new PrintDocument();

                            pdocPomp.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                            string bestandsNaamPompPedro = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                            PrintCentrale(pdocPomp.PrinterSettings.PrinterName, @"Z:\PompFiches\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaamPompPedro + ".xlsx");
                        }
                    }
                    break;
                case DialogResult.No:

                    break;
                default:                 // Neither Yes nor No pressed (just in case)

                    break;
            }
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
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestellingPrint = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            string bestandsNaam = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
            if (user != "Pedro")
            {
                   
                 
                    if (File.Exists(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                    {
                        File.Delete(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                    }
                    bestellingPrint.GeneerExcellRec(false, "", user);

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
            else
            {

              
                if (File.Exists(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                {
                    File.Delete(@"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                }
                bestellingPrint.GeneerExcellRec(false, "", user);
                PrintDocument pdoc = new PrintDocument();

                pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                PrintCentrale(pdoc.PrinterSettings.PrinterName, @"Z:\Bestellingen\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");

                if (bestellingPrint.Pomp.PompLeverancier == "D'huyvetter beton")
                {
                    bestellingPrint.GeneerPompExcell(false);
                    PrintDocument pdocPomp = new PrintDocument();

                    pdocPomp.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                    string bestandsNaamPompPedro = bestellingPrint.Klant.Naam + " " + bestellingPrint.Datum.Hour.ToString() + "u" + bestellingPrint.Datum.Minute.ToString();
                    PrintCentrale(pdocPomp.PrinterSettings.PrinterName, @"Z:\PompFiches\" + bestellingPrint.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaamPompPedro + ".xlsx");
                }
            }
           
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            timer1.Stop();
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmProduct = new FrmProductWijzigen(bestelling,user);
            frmProduct.Show();

            frmProductClosing();
        }

        private void frmProductClosing()
        {
            frmProduct.FormClosing += (sender, eventArgs) =>
            {
                AfdrukkenNaWijziging();
                bunifuCustomDataGridBeton.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            timer1.Stop();
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmPompWijzigen = new FrmPompWijzigen(bestelling);
            frmPompWijzigen.Show();

            frmPompWijzigenClosing();
        }
        private void frmPompWijzigenClosing()
        {
            frmPompWijzigen.FormClosing += (sender, eventArgs) =>
            {
                AfdrukkenNaWijziging();
                bunifuCustomDataGridBeton.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            timer1.Stop();
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmInfoWijzigen = new FrmInformatieAanpassen(bestelling);
            frmInfoWijzigen.Show();

            frmInfoWijzigenClosing();
        }

        private void frmInfoWijzigenClosing()
        {
            frmInfoWijzigen.FormClosing += (sender, eventArgs) =>
            {
                AfdrukkenNaWijziging();
                bunifuCustomDataGridBeton.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);
            };
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
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            if (bestelling.Pomp.PompLeverancier != "D'huyvetter beton")
            {
                XtraMessageBox.Show("Pomp leverancier is niet D'huyvetter Beton");
            }
            else
            {
                bestelling.GeneerPompExcell(false);
                if (user == "Pedro")
                {
                    PrintDocument pdoc = new PrintDocument();

                    pdoc.DefaultPageSettings.PrinterSettings.PrinterName = "KONICA MINOLTA C287SeriesXPS";
                    string bestandsNaam = bestelling.Klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();
                    Print(pdoc.PrinterSettings.PrinterName, @"Z:\PompFiches\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                }
                else
                {

                }
            }
        }

        private void bunifuCustomDataGridBeton_MouseHover(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            balancePanel.Visible = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                balancePanel.Visible = false;
                Point cp = PointToClient(Cursor.Position);
                balancePanel.Location = new Point(cp.X + e.X, cp.Y + e.Y);
                balancePanel.Visible = true;
            }
        }

        private void label11_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                balancePanel.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpDatum.EditValue).Date == DateTime.Today.Date)
            {
                zoeken();
            }
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGridBeton.SelectedCells;
            BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(Convert.ToInt32(DGV[0].Value));
            frmHulpstofWijzigen = new FrmHulpstofWijzigen(bestelling);
            frmHulpstofWijzigen.Show();
            frmHulpstoffenWijzigenClosing();
        }

        private void frmHulpstoffenWijzigenClosing()
        {
            frmHulpstofWijzigen.FormClosing += (sender, eventArgs) =>
            {
                AfdrukkenNaWijziging();
                bunifuCustomDataGridBeton.Rows.Clear();
                KrijgBestellingenOpDag((DateTime)dtpDatum.EditValue);

            };
        }

      
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(DateTime.Today);
            foreach (BL.Bestelling bestelling in bestellingen)
            {
                 Add_Document_with_AutoID(bestelling);
              
                
             
            }
        }


        void Add_Document_with_AutoID(BL.Bestelling bestelling)
        {

            int unixTimestamp = (int)bestelling.Datum.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            CollectionReference coll = database.Collection("Bestelling");
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                {"klant",bestelling.Klant.Naam },
                {"werf",bestelling.Werf.ToString()},
                {"datum",unixTimestamp },
                {"aantal",bestelling.M3 },
                  {"product",bestelling.Formule },
                  {"pomp",bestelling.Pomp},
                  {"leveringMethode",bestelling.LeveringWijze },
                    {"losMethode",bestelling.Loswijze},
                      {"opmerking",bestelling.Comment }
            };
            coll.AddAsync(data1);
            MessageBox.Show("data added sucessfully");
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click_2(object sender, EventArgs e)
        {  //
           // db = FirestoreDb.Create("dbintern-56185");
           // List<Klant> klanten = Klant.KrijgAlleKlanten();
           // foreach (Klant klant in klanten)
           // {
           //     Add_Document(klant);
           // }
        }

        private void simpleButton3_Click_3(object sender, EventArgs e)
        {
            List<BL.PrijsLijst> prijsLijst = BL.PrijsLijst.KrijgAlleOmschrijvingen();
            BL.PrijsLijst prijs = BL.PrijsLijst.GeneerExcelLijst(prijsLijst);
           
        }
    }
}
