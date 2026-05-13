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
using System.Net;
using System.IO;
using System.Diagnostics;

namespace DhuyvetterBeton.Beton
{
    public partial class ucHoofdvenster : DevExpress.XtraEditors.XtraUserControl
    {
        string User;
        string versie;
        string picURL = "http://www.dhuyvetterbeton.website/img/restaurant/chefs/";
        public List<BL.Bestelling> bestellingPublic;
        #region Bedrijfcijfers

        int aantalklanten = BL.Klant.KrijgAantalKlanten();
        int aantalWerven = BL.Werf.KrijgAantalWerven();
        int aantalProducten = BL.Formule.KrijgAantalFormules();
        int aantalBestellingen = BL.Bestelling.krijgAantalBestellingen();
        int aantalLeveringBonnen = NormaleLeveringBon.KrijgAantalBonnen();
        int aantalFacturen = BL.Bestelling.KrijgAantalFacturen();

        #endregion
        public ucHoofdvenster(string user, string versie1,List<BL.Bestelling> bestellings)
        {
            List<BL.Bestelling> bestellingen;
            if (bestellings!= null)
            {
              bestellingen = bestellings;

            }
            else
            {
                bestellingen = bestellingPublic;
            }
          
            versie = versie1;
            InitializeComponent();
            User = user;
            try
            {
                if (User == "")
                {

                }
                else
                {
                    #region agendaBeton
                    bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                    bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
                    bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
                    foreach (BL.Bestelling bestelling1 in bestellingen)
                    {
                        bunifuCustomDataGrid1.Rows.Add(
                            new object[]
                            {
                        bestelling1.Datum.ToShortTimeString(),
                        bestelling1.ID,
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
                    bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
                    bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
                    bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                    bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
                    bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                    bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
                    #endregion

                    #region agendaPrefab
                    List<BestellingPrefab> prefabBestellingen = BestellingPrefab.KrijgAlleBestellingenDoorDatum(DateTime.Today.Date, DateTime.Today.Date.AddDays(+1));
                    prefabBestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));

                    bunifuCustomDataGrid2.DataSource = null;
                    bunifuCustomDataGrid2.Rows.Clear();
                    foreach (BestellingPrefab prefabBestelling in prefabBestellingen)
                    {
                        bunifuCustomDataGrid2.Rows.Add(
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

                    bunifuCustomDataGrid2.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
                    bunifuCustomDataGrid2.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
                    bunifuCustomDataGrid2.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
                    bunifuCustomDataGrid2.RowsDefaultCellStyle.ForeColor = Color.White;
                    bunifuCustomDataGrid2.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                    bunifuCustomDataGrid2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
                    #endregion
                }
            }
            catch
            {

                bunifuCustomDataGrid1.Visible = false;
                bunifuCustomLabel1.Visible = false;
                bunifuCustomDataGrid2.Visible = false;
                bunifuCustomLabel2.Visible = false;

            }
          
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
            timer7.Start();
            if (User == "Cindy")
            {
                picURL = picURL + User + ".png";

            }
            else if (User == "Yara")
            {
                picURL = picURL + User + ".png";

            }
            else if (User == "Didier")
            {
                picURL = picURL + User + ".png";

            }
            else if (User == "Jan")
            {
                picURL = picURL + User + ".png";

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

            int uur = DateTime.Now.Hour;
            if (uur < 4)
            {
                labelWelkom.Text = "Goedeavond " + User;

            }
            else if (uur < 11)
            {
                if (User == "Loes")
                {
                    labelWelkom.Text = "Goedemorgen Didier";
                }
                labelWelkom.Text = "Goedemorgen " + User;
            }
            else if (uur < 17)
            {
                if (User == "Loes")
                {
                    labelWelkom.Text = "Goedemiddag Didier";
                }
                labelWelkom.Text = "Goedemiddag " + User;
            }
            else if (uur < 23)
            {
                if (User == "Loes")
                {
                    labelWelkom.Text = "Goedeavond Didier";
                }
                labelWelkom.Text = "Goedeavond " + User;
            }
        }
  
      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + User + "\\Desktop\\UPDATE\\UpdateProgrammaDH.exe");
            System.Environment.Exit(1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Klant> klantenlijst = Klant.KrijgAlleKlanten();


            foreach (Klant klant in klantenlijst)
            {
                try
                {
                    string klantNaamOld = klant.Naam;
                    string klantNaamNieuw = char.ToUpper(klantNaamOld[0]).ToString() + klantNaamOld.Substring(1);


                   
                    int index = klantNaamNieuw.IndexOf(" ");

                    index = index +1;
                    char[] ch = klantNaamNieuw.ToCharArray();
                    char kleineletter = ch[index];

                    ch[index] = char.ToUpper(kleineletter);

                    string correct = new string(ch);
                  

            
                    klant.Naam = correct;
                    klant.UpdateKlantGegevens();
                }
               
                catch
                {

                }
            }
        }
    }
}
