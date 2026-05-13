using BL;
using CefSharp;
using DevExpress.XtraEditors;
using DhuyvetterBeton.Beton.alacarteservice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Klanten.Tools
{
    public partial class FrmDetailBedrijf : DevExpress.XtraEditors.XtraForm
    {
       
        Klant klant;

        public FrmDetailBedrijf(Klant klant1)
        {
            InitializeComponent();
        }
         /*   klant = klant1;
            this.Text = "Klant informatie - " + klant.Naam;
            string login = "dhuyvetterTEST";
            string password = "G6N8K5";
            string integratorSecret = "c0b65824-634e-4f8a-8d80-1fea19b1a8f5";
            var client = new AlacarteServiceV1_3Client();
            var response = client.GetCompanyByVat(
             new RequestCompanyByVat
             {
                // Login of the customer
                CompanyWebLogin = "dhuyvetterTEST",
                // Password of the customer
                CompanyWebPassword = "G6N8K5",
                // Shorthand code of the integrator. This is provided by Companyweb.
                ServiceIntegrator = "dhuyvetterbeton",
                Language = "NL",
                VatNumber = klant.Btw,

            // A calculated hash. See CreateHash below for the implementation.
                 LoginHash = CreateHash(login, password, integratorSecret),
        
                // Other parameters...
            }
         );
           // Debug.WriteLine(response.StatusCode + " bericht: " + response.StatusMessage);
           // Debug.WriteLine("Gezondheidsbarometer score: " + response.CompanyResponse.Score.Value.ScoreAsDecimal);
           // string afbeelding = response.CompanyResponse.Score.Value.ScoreImage;
           // string afbeeldingCorrect = afbeelding.Replace("-", "_");
           // string afbeeldingZonderPNG = afbeeldingCorrect.Replace(".png","");
        //    pictureboxGezondheidsBaroMeter.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(afbeeldingZonderPNG);
            krijgFinanciëleDataViaKlantBTW();
        }

        private void krijgFinanciëleDataViaKlantBTW()
        {
            string btwZonderBE = klant.Btw.Replace("BE", "");
            Debug.WriteLine(btwZonderBE);

            var charsToRemove = new string[] { " ", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                btwZonderBE = btwZonderBE.Replace(c, string.Empty);
            }
            if(btwZonderBE[0] != '0')
            {
                btwZonderBE = "0" + btwZonderBE;
            }
            string btwnrOld = btwZonderBE;
            string btwnrNew = btwnrOld.Insert(4, ".");
            string btwnrNew1 = btwnrNew.Insert(8, ".");

            var url = "https://robofin.be/fiche/api.enterprise.php?a=EnterpriseData&VAT=" + btwnrNew1;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var bedrijfsData = JsonConvert.DeserializeObject<BedrijfsData>(result);


                //info 
                labelMaatschappelijkeZetel.Text = bedrijfsData.Enterprise.Address.StreetNl + " " + bedrijfsData.Enterprise.Address.HouseNumber + " " + bedrijfsData.Enterprise.Address.MunicipalityNl + " " + bedrijfsData.Enterprise.Address.Zipcode.ToString();
                labelJuridischeSituatie.Text = bedrijfsData.Enterprise.JuridicalSituation;
                labelJuridischeVorm.Text = bedrijfsData.Enterprise.JuridicalForm;
                labelStartDatum.Text = bedrijfsData.Enterprise.StartDate.ToString();
                labelBstatus.Text = bedrijfsData.Enterprise.Status;
                labelBalansjaar.Text = bedrijfsData.Enterprise.FiscalYearEnd.Substring(0, 4); 
                if (labelJuridischeSituatie.Text.Contains("faillissement")) { labelStatus.ForeColor = Color.Red; }
                else
                {
                    labelStatus.ForeColor = Color.LimeGreen;
                }
                List<Kpi> kpilijst = new List<Kpi>();
                // var first = bedrijfsData.Kpis.yFirst();
                foreach(Establishment e in bedrijfsData.Establishments)
                {
                    ListboxVestigingen.Items.Add(e.Address.StreetNl + " " + e.Address.HouseNumber + " " + e.Address.MunicipalityNl + " " + e.Address.Zipcode);
                }
                foreach(Activity a in bedrijfsData.Activities)
                {
                    listBoxActiviteiten.Items.Add(a.NaceCodeLabel);
                }
                foreach (object i in bedrijfsData.Kpis)
                {
                    kpilijst.Add(((Kpi)i));
                }
                int counter = 0;
           
                    foreach (Kpi kpi in kpilijst)
                    {
                  
                        if (kpi.Label == "Turnover")
                        {
                            counter++;   
                        }
                        else
                        {
                            Debug.WriteLine(kpi.ToYearTal());
                            if (counter == 0)
                            {
                                int jaartal = kpi.ToJaarTal();
                                string derest = kpi.GetMaandEnDag2();
                                string derestCorrect = derest.Remove(0, 4);

                                string WVjaar1 = kpi.Years[jaartal.ToString() + derestCorrect].Amount;
                                if (WVjaar1.Contains("."))
                                {
                                    int index1 = WVjaar1.IndexOf('.');
                                    string zonderKomma = WVjaar1.Remove(index1);
                                    Debug.WriteLine(zonderKomma);
                                }

                                double test = Convert.ToDouble(kpi.Years[jaartal.ToString() + derestCorrect].ZonderKomma());
                                labelWVJaar1.Text = Convert.ToDouble(kpi.Years[jaartal.ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture);
                                labelProcentWV1.Text = kpi.Years[jaartal.ToString() + derestCorrect].ChangePct.ToString() + "%";
                            try
                            {
                                labelProcentWV2.Text = kpi.Years[(jaartal - 1).ToString() + derestCorrect].ChangePct.ToString() + "%";
                            }
                            catch { }
                            try
                            {
                                labelProcentWV3.Text = kpi.Years[(jaartal - 2).ToString() + derestCorrect].ChangePct.ToString() + "%";
                            }
                            catch
                            {

                            }
                              
                              

                                if (labelProcentWV1.Text.Contains("-"))
                                {
                                    labelProcentWV1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentWV1.ForeColor = System.Drawing.Color.SpringGreen;
                                }

                                if (labelProcentWV2.Text.Contains("-"))
                                {
                                    labelProcentWV2.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentWV2.ForeColor = System.Drawing.Color.SpringGreen;
                                }
                                if (labelProcentWV3.Text.Contains("-"))
                                {
                                    labelProcentWV3.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentWV3.ForeColor = System.Drawing.Color.SpringGreen;
                                }
                              




                                labelJaar1.Text = (jaartal.ToString());
                                labelJaar2.Text = (jaartal - 1).ToString();
                                labelJaar3.Text = (jaartal - 2).ToString();
                                labelJaar4.Text = (jaartal - 3).ToString();
                            try { labelWVJaar2.Text = Convert.ToDouble(kpi.Years[(jaartal - 1).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); }
                            catch { }


                            try { labelWVJaar3.Text = Convert.ToDouble(kpi.Years[(jaartal - 2).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); }
                            catch { }

                            try { labelWVJaar4.Text = Convert.ToDouble(kpi.Years[(jaartal - 3).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); }
                            catch { }

                                counter++;
                            }
                            else if (counter == 1)
                            {
                                int jaartal = kpi.ToJaarTal();
                                string derest = kpi.GetMaandEnDag2();
                                string derestCorrect = derest.Remove(0, 4);


                            try { labelEigenVermogenJaar1.Text = Convert.ToDouble(kpi.Years[jaartal.ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture);
                                labelProcentEG1.Text = kpi.Years[jaartal.ToString() + derestCorrect].ChangePct.ToString() + "%";
                            }
                            catch { }


                            try { labelEigenVermogenJaar2.Text = Convert.ToDouble(kpi.Years[(jaartal - 1).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture);
                                labelProcentEG2.Text = kpi.Years[(jaartal - 1).ToString() + derestCorrect].ChangePct.ToString() + "%";
                            }
                            catch { }


                            try { labelEigenVermogenJaar3.Text = Convert.ToDouble(kpi.Years[(jaartal - 2).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); labelProcentEG3.Text = kpi.Years[(jaartal - 2).ToString() + derestCorrect].ChangePct.ToString() + "%"; }
                            catch { }


                            try { labelEigenVermogenJaar4.Text = Convert.ToDouble(kpi.Years[(jaartal - 3).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); }
                            catch { }

                                counter++;


                                if (labelProcentEG1.Text.Contains("-"))
                                {
                                    labelProcentEG1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentEG1.ForeColor = System.Drawing.Color.SpringGreen;
                                }

                                if (labelProcentEG2.Text.Contains("-"))
                                {
                                    labelProcentEG2.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentEG2.ForeColor = System.Drawing.Color.SpringGreen;
                                }
                                if (labelProcentEG3.Text.Contains("-"))
                                {
                                    labelProcentEG3.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentEG3.ForeColor = System.Drawing.Color.SpringGreen;
                                }



                            }
                            else if (counter == 2)
                            {
                                int jaartal = kpi.ToJaarTal();
                                string derest = kpi.GetMaandEnDag2();
                                string derestCorrect = derest.Remove(0, 4);
                                labelBrutoJaar1.Text = Convert.ToDouble(kpi.Years[jaartal.ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture);
                                try
                                {
                                    labelBrutoJaar2.Text = Convert.ToDouble(kpi.Years[(jaartal - 1).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); labelProcentBruto2.Text = kpi.Years[(jaartal - 1).ToString() + derestCorrect].ChangePct.ToString() + "%";
                            }
                                catch { counter++; }
                              
                              
                                try
                                {
                                    labelBrutoJaar3.Text = Convert.ToDouble(kpi.Years[(jaartal - 2).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture); labelProcentBruto3.Text = kpi.Years[(jaartal - 2).ToString() + derestCorrect].ChangePct.ToString() + "%";
                            }
                                catch { counter++; }
                                try {
                                    labelBrutoJaar4.Text = Convert.ToDouble(kpi.Years[(jaartal - 3).ToString() + derestCorrect].ZonderKomma()).ToString("C", CultureInfo.CurrentCulture);
                                } catch { counter++; }

                            try { labelProcentBruto1.Text = kpi.Years[jaartal.ToString() + derestCorrect].ChangePct.ToString() + "%"; } catch { }
                               
                           
                            


                                if (labelProcentBruto1.Text.Contains("-"))
                                {
                                    labelProcentBruto1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentBruto1.ForeColor = System.Drawing.Color.SpringGreen;
                                }

                                if (labelProcentBruto2.Text.Contains("-"))
                                {
                                    labelProcentBruto2.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentBruto2.ForeColor = System.Drawing.Color.SpringGreen;
                                }
                                if (labelProcentBruto3.Text.Contains("-"))
                                {
                                    labelProcentBruto3.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    labelProcentBruto3.ForeColor = System.Drawing.Color.SpringGreen;
                                }



                                counter++;
                            }
                            else if (counter == 3 || counter == 5)
                            {
                                int jaartal = kpi.ToJaarTal();
                                string derest = kpi.GetMaandEnDag2();
                                string derestCorrect = derest.Remove(0, 4);
                                labelPersoneelJaar1.Text = kpi.Years[jaartal.ToString() + derestCorrect].ZonderKomma().ToString();
                                labelPersoneelJaar2.Text = kpi.Years[(jaartal - 1).ToString() + derestCorrect].ZonderKomma().ToString();
                                labelPersoneelJaar3.Text = kpi.Years[(jaartal - 2).ToString() + derestCorrect].ZonderKomma().ToString();
                                labelPersoneelJaar4.Text = kpi.Years[(jaartal - 3).ToString() + derestCorrect].ZonderKomma().ToString();
                                counter++;
                            }
                        }
                       
                    
                   
                    
                       
                    // Console.WriteLine(kpi.Years["2020-12-31"].Amount.ToString());
                     }
                
            }
        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelJaar4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string btwZonderBE = klant.Btw.Replace("BE", "");
            var charsToRemove = new string[] { " ", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                btwZonderBE = btwZonderBE.Replace(c, string.Empty);
            }
            if (btwZonderBE[0] != '0')
            {
                btwZonderBE = "0" + btwZonderBE;
            }
            System.Diagnostics.Process.Start("firefox.exe", "http://www.google.com");
            //geckoWebBrowser.Navigate();
             System.Diagnostics.Process.Start("https://www.companyweb.be/company/" + btwZonderBE);
        }

        private void Chrome_AdressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {

            }));
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("firefox.exe", "http://www.google.com");
        }


        string CreateHash(string login, string password, string integratorSecret)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                var clearText = (
                        DateTime.Today.Year.ToString() +
                        DateTime.Today.Month.ToString("00") +
                        DateTime.Today.Day.ToString("00") +
                        login +
                        password +
                        integratorSecret
                    ).ToLower();

                byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(clearText));
                var hash = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    hash.Append(data[i].ToString("x2"));
                }
                Debug.WriteLine(hash.ToString());
                return hash.ToString();
            }
        }

        private void pictureboxGezondheidsBaroMeter_Click(object sender, EventArgs e)
        {

        }*/
    }
}