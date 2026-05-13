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
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office;
using System.IO;
using System.Drawing.Printing;
using static DhuyvetterBeton.Beton.Facturen.FrmMailFacturen;

namespace DhuyvetterBeton.Beton.Offertes
{
    public partial class FrmNieuweOfferte : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmNieuweOfferte()
        {
            InitializeComponent();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            labelTitel.Text = "Nieuwe offerte voor werf";
            cboWerf.Enabled = true;
            cboProduct.Enabled = false;
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            labelTitel.Text = "Nieuwe offerte voor product";
            cboWerf.Enabled = false;
            cboProduct.Enabled = true;
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            labelTitel.Text = "Nieuwe offerte voor product en werf";
            cboWerf.Enabled = true;
            cboProduct.Enabled = true;
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            labelTitel.Text = "Nieuwe offerte voor klant";
            cboWerf.Enabled = false;
            cboProduct.Enabled = false;
        }
        public static bool sendEmailViaOutlook(string sFromAddress, string sToAddress, string sCc, string sSubject, string sBody, BodyType bodyType, List<string> arrAttachments = null, string sBcc = null)
        {
            //Send email via Office Outlook 2010
            //'sFromAddress' = email address sending from (ex: "me@somewhere.com") -- this account must exist in Outlook. Only one email address is allowed!
            //'sToAddress' = email address sending to. Can be multiple. In that case separate with semicolons or commas. (ex: "recipient@gmail.com", or "recipient1@gmail.com; recipient2@gmail.com")
            //'sCc' = email address sending to as Carbon Copy option. Can be multiple. In that case separate with semicolons or commas. (ex: "recipient@gmail.com", or "recipient1@gmail.com; recipient2@gmail.com")
            //'sSubject' = email subject as plain text
            //'sBody' = email body. Type of data depends on 'bodyType'
            //'bodyType' = type of text in 'sBody': plain text, HTML or RTF
            //'arrAttachments' = if not null, must be a list of absolute file paths to attach to the email
            //'sBcc' = single email address to use as a Blind Carbon Copy, or null not to use
            //RETURN:
            //      = true if success
            bool bRes = false;

            try
            {
                //Get Outlook COM objects
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem newMail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);

                //Parse 'sToAddress'
                if (!string.IsNullOrWhiteSpace(sToAddress))
                {
                    string[] arrAddTos = sToAddress.Split(new char[] { ';', ',' });
                    foreach (string strAddr in arrAddTos)
                    {
                        if (!string.IsNullOrWhiteSpace(strAddr) &&
                            strAddr.IndexOf('@') != -1)
                        {
                            newMail.Recipients.Add(strAddr.Trim());
                        }
                        else
                            throw new Exception("Bad to-address: " + sToAddress);
                    }
                }
                else
                    throw new Exception("Must specify to-address");

                //Parse 'sCc'
                if (!string.IsNullOrWhiteSpace(sCc))
                {
                    string[] arrAddTos = sCc.Split(new char[] { ';', ',' });
                    foreach (string strAddr in arrAddTos)
                    {
                        if (!string.IsNullOrWhiteSpace(strAddr) &&
                            strAddr.IndexOf('@') != -1)
                        {
                            newMail.Recipients.Add(strAddr.Trim());
                        }
                        else
                            throw new Exception("Bad CC-address: " + sCc);
                    }
                }

                //Is BCC empty?
                if (!string.IsNullOrWhiteSpace(sBcc))
                {
                    newMail.BCC = sBcc.Trim();
                }

                //Resolve all recepients
                if (!newMail.Recipients.ResolveAll())
                {
                    throw new Exception("Failed to resolve all recipients: " + sToAddress + ";" + sCc);
                }


                //Set type of message
                switch (bodyType)
                {
                    case BodyType.HTML:
                        newMail.HTMLBody = sBody;
                        break;
                    case BodyType.RTF:
                        newMail.RTFBody = sBody;
                        break;
                    case BodyType.PlainText:
                        newMail.Body = sBody;
                        break;
                    default:
                        throw new Exception("Bad email body type: " + bodyType);
                }


                if (arrAttachments != null)
                {
                    //Add attachments
                    foreach (string strPath in arrAttachments)
                    {
                        if (File.Exists(strPath))
                        {
                            newMail.Attachments.Add(strPath);
                        }
                        else
                            throw new Exception("Attachment file is not found: \"" + strPath + "\"");
                    }
                }

                //Add subject
                if (!string.IsNullOrWhiteSpace(sSubject))
                    newMail.Subject = sSubject;

                Outlook.Accounts accounts = app.Session.Accounts;
                Outlook.Account acc = null;

                //Look for our account in the Outlook
                foreach (Microsoft.Office.Interop.Outlook.Account account in accounts)
                {
                    if (account.SmtpAddress.Equals(sFromAddress, StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Use it
                        acc = account;
                        break;
                    }
                }

                //Did we get the account
                if (acc != null)
                {
                    //Use this account to send the e-mail. 
                    newMail.SendUsingAccount = acc;

                    //And send it
                    ((Microsoft.Office.Interop.Outlook._MailItem)newMail).Send();

                    //Done
                    bRes = true;
                }
                else
                {
                    throw new Exception("Account Bestaat niet: " + sFromAddress);
                }
                MessageBox.Show("Factuur verzonden!", "Money time", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Mail versturen mislukt: " + ex.Message);
            }

            return bRes;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            double transport = 0;
            double onvolledigelading = 0;
            double bedrag = 0;
            if (txtTransport.Text != string.Empty)
            {
                transport = Convert.ToDouble(txtTransport.Text);
            }
            if (txtOnvolledigelading.Text != string.Empty)
            {
                onvolledigelading = Convert.ToDouble(txtOnvolledigelading.Text);
            }
            if (txtPrijs.Text != string.Empty)
            {
                bedrag = Convert.ToDouble(txtPrijs.Text);
            }

            if (labelTitel.Text == "Nieuwe offerte voor klant")
            {
              
                OfferteKlant offerteKlant = new OfferteKlant(((Klant)cboKlanten.SelectedItem), transport, onvolledigelading, bedrag,txtOpmerking.Text);
                offerteKlant.MaakNieuweOfferte();
                if (checkBoxMail.Checked == true)
                {

                }
            }
            else if (labelTitel.Text == "Nieuwe offerte voor werf")
            {
                OfferteWerf offerteWerf = new OfferteWerf(((Klant)cboKlanten.SelectedItem), ((Werf)cboWerf.SelectedItem) ,transport, onvolledigelading, bedrag, txtOpmerking.Text);
                offerteWerf.MaakNieuweOfferte();
            }
            else if (labelTitel.Text == "Nieuwe offerte voor product")
            {
               OfferteProduct offerteProduct= new OfferteProduct(((Klant)cboKlanten.SelectedItem), ((OmschrijvingProduct)cboProduct.SelectedItem), transport, onvolledigelading, bedrag, txtOpmerking.Text);
                offerteProduct.MaakNieuweOfferte();
            }
            else if (labelTitel.Text == "Nieuwe offerte voor product en werf")
            {
                OfferteWerfProduct offerteWerfProduct = new OfferteWerfProduct(((Klant)cboKlanten.SelectedItem), ((Werf)cboWerf.SelectedItem), ((OmschrijvingProduct)cboProduct.SelectedItem), transport, onvolledigelading, bedrag, txtOpmerking.Text);
                offerteWerfProduct.MaakNieuweOfferte();
            }
         
           
        }

        private void FrmNieuweOfferte_Load(object sender, EventArgs e)
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

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void cboWerf_KeyDown(object sender, KeyEventArgs e)
        {
            cboWerf.DroppedDown = true;
        }

        private void cboProduct_KeyDown(object sender, KeyEventArgs e)
        {
            cboProduct.DroppedDown = true;
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            OmschrijvingProduct omschrijvingProduct = ((OmschrijvingProduct)cboProduct.SelectedItem);
            cboFormules.SelectedIndex = cboFormules.FindString(omschrijvingProduct.Formule);
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Werf> wervenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(((Klant)cboKlanten.SelectedItem).ID);
            wervenLijst.Sort((x, y) => x.Adres.CompareTo(y.Adres));
            cboWerf.Items.AddRange(wervenLijst.ToArray());
        }

        private void txtTransport_Click(object sender, EventArgs e)
        {
            txtTransport.Text = string.Empty;
        }

        private void txtOnvolledigelading_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOnvolledigelading_Click(object sender, EventArgs e)
        {
            txtOnvolledigelading.Text = string.Empty;
        }

        private void txtPrijs_Click(object sender, EventArgs e)
        {
            txtPrijs.Text = string.Empty;
        }
    }
}
