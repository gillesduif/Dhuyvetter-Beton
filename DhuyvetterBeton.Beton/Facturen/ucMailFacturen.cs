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
using System.Runtime.InteropServices;

namespace DhuyvetterBeton.Beton.Facturen
{
    public partial class ucMailFacturen : DevExpress.XtraEditors.XtraUserControl
    {
        string versie;
        string pdfLocatieMail = "";
        List<Klant> klantenLijst = new List<Klant>();
        List<Klant> KlantenZondermail;
        FrmHoofdVenster frmhoofd;
        string USER;
        public ucMailFacturen(FrmHoofdVenster frmhoofd1,string user1, string versie1)
        {
            frmhoofd = frmhoofd1;
            versie = versie1;
            USER = user1;
            InitializeComponent();
             calendarControl1.EditValue = DateTime.Today;
        }

        private void calendarControl1_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CboKlanten.Properties.Items.Clear();
            List<Factuur> facturenLijst = Factuur.KrijgAlleFacturenVanDatum(calendarControl1.SelectionStart.Date);
            List<Klant> klantenLijst = new List<Klant>();
            KlantenZondermail = new List<Klant>();
            foreach (Factuur factuur in facturenLijst)
            {
                int ID = Klant.KrijgBlokeerMailFunctie(factuur.Klant.ID);
                //int klantNummer = factuur.Klant.Nummer;
                //Klant klant = Klant.KrijgKlantViaKlantenNummer(klantNummer);
                if (klantenLijst.Exists(x => x.Naam == factuur.Klant.Naam))
                {

                }
                else if (factuur.Klant.Email == "" && KlantenZondermail.Exists(x => x.Naam == factuur.Klant.Naam))
                {

                }
                else if (ID != 0)
                {
                    KlantenZondermail.Add(factuur.Klant);
                }
                else if (factuur.Klant.Email == "")
                {
                    KlantenZondermail.Add(factuur.Klant);
                }
                else
                {
                    klantenLijst.Add(factuur.Klant);
                }

            }
            KlantenZondermail.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            klantenLijst.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            CboKlanten.Properties.Items.AddRange(klantenLijst.ToArray());
            CboKlantenZonderMail.Properties.Items.AddRange(KlantenZondermail.ToArray());
            dataGridView1.DataSource = KlantenZondermail;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Klant klant = new Klant();
            klant = ((Klant)cboBlokKlant.SelectedItem);
            klant.BlokeerMail();
            cboBlokKlant.Text = string.Empty;
            MessageBox.Show("Klant mail geblokeerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxFacturen.Items.Clear();
            int klantID = ((Klant)CboKlanten.SelectedItem).ID;
            List<Factuur> FacturenVanKlant = Factuur.KrijgAlleFacturenVanKlant(klantID);
            FacturenVanKlant.Sort((Y, X) => X.FactuurNummer.CompareTo(Y.FactuurNummer));
            lbxFacturen.Items.AddRange(FacturenVanKlant.ToArray());
            lbxFacturen.SelectedIndex = 0;
        }
        public bool ExportWorkbookToPdf(string workbookPath, string outputPath)
        {
            // If either required string is null or empty, stop and bail out
            if (string.IsNullOrEmpty(workbookPath) || string.IsNullOrEmpty(outputPath))
            {
                return false;
            }

            // Create COM Objects
            Microsoft.Office.Interop.Excel.Application excelApplication;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook;

            // Create new instance of Excel
            excelApplication = new Microsoft.Office.Interop.Excel.Application();

            // Make the process invisible to the user
            excelApplication.ScreenUpdating = false;

            // Make the process silent
            excelApplication.DisplayAlerts = false;
            excelWorkbook = null;
            // Open the workbook that you wish to export to PDF
            try
            {
                excelWorkbook = excelApplication.Workbooks.Open(workbookPath);
            }
            catch
            {
                MessageBox.Show("Kan Bestand niet vinden.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // If the workbook failed to open, stop, clean up, and bail out
            if (excelWorkbook == null)
            {
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;

                return false;
            }

            var exportSuccessful = true;
            try
            {
                // Call Excel's native export function (valid in Office 2007 and Office 2010, AFAIK)
                excelWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputPath);
            }
            catch 
            {
                // Mark the export as failed for the return value...
                exportSuccessful = false;

                // Do something with any exceptions here, if you wish...
                // MessageBox.Show...        
            }
            finally
            {
                // Close the workbook, quit the Excel, and clean up regardless of the results...
                excelWorkbook.Close();
                excelApplication.Quit();

                excelApplication = null;
                excelWorkbook = null;
            }

            // You can use the following method to automatically open the PDF after export if you wish
            // Make sure that the file actually exists first...
            if (System.IO.File.Exists(outputPath))
            {
                System.Diagnostics.Process.Start(outputPath);
            }

            return exportSuccessful;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string locatie = ((Factuur)lbxFacturen.SelectedItem).FactuurNummer + " " + ((Factuur)lbxFacturen.SelectedItem).Klant.Naam;
            string bestandsnaam = @"Z:\\Facturatie\" + (((Factuur)lbxFacturen.SelectedItem).Datum.ToString("dd MMMM yyyy") + @"\" + locatie + ".xlsx");
            string pdfLocatie = @"Z:\\Facturatie\" + (((Factuur)lbxFacturen.SelectedItem).Datum.ToString("dd MMMM yyyy") + @"\" + locatie);
            ExportWorkbookToPdf(bestandsnaam, pdfLocatie);
            pdfLocatieMail = pdfLocatie + ".pdf";
            try { pdfViewer1.LoadDocument(pdfLocatie + ".pdf"); } catch { }

            labelMail.Text = ((Klant)CboKlanten.SelectedItem).Email;
            if (labelMail.Text == "")
            {
                labelMail.Text = "Geen Mail adres gevonden!";
                simpleButton2.Enabled = false;
                int indexnummercbo = CboKlanten.SelectedIndex;
                klantenLijst.RemoveAt(indexnummercbo);
                CboKlanten.Properties.Items.Clear();
                CboKlanten.Properties.Items.AddRange(klantenLijst.ToArray());
            }
            else
            {
                txtOnderwerp.Text = "Er is een nieuwe factuur beschikbaar (" + ((Factuur)lbxFacturen.SelectedItem).FactuurNummer + ")";
                txtBericht.Text = "Geachte " + ((Klant)CboKlanten.SelectedItem).Naam + "," + System.Environment.NewLine + System.Environment.NewLine + "In bijlage uw factuur en bijbehorende documenten bijgevoegd." + System.Environment.NewLine + "Wij danken u voor uw vertrouwen." + System.Environment.NewLine + System.Environment.NewLine + "D'huyvetter Beton" + System.Environment.NewLine + "Nijverheidslaan 16" + System.Environment.NewLine + "Avelgem 8580";
                simpleButton2.Enabled = true;
            }
        }
        public enum BodyType
        {
            PlainText,
            RTF,
            HTML
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
                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem newMail = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

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

                Microsoft.Office.Interop.Outlook.Accounts accounts = app.Session.Accounts;
                Microsoft.Office.Interop.Outlook.Account acc = null;

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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Factuur> facturenLijst = Factuur.KrijgAlleFacturenVanDatum(calendarControl1.SelectionStart.Date);
            foreach (Klant klant in KlantenZondermail)
            {
                foreach (Factuur factuur in facturenLijst)
                {
                    if (factuur.Klant.ToString() == klant.ToString())
                    {
                        string bestandsNaam = factuur.FactuurNummer + " " + factuur.Klant.Naam;
                        //if (File.Exists(@"Z:\Facturatie\" + factuur1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx"))
                        //{
                        //    File.Delete(@"Z:\Facturatie\" + factuur1.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx");
                        //}


                        string BestandsNaam = factuur.FactuurNummer + " " + factuur.Klant.Naam;
                        // Print the file to the printer.
                        RawPrinterHelper.SendFileToPrinter("KONICA MINOLTA C308 Facturatiepapier op dhurd01", @"E:\Leveringen\" + bestandsNaam + ".xlsx");
                        new FileInfo(@"Z:\Facturatie\" + factuur.Datum.ToString("dd MMMM yyyy") + @"\" + BestandsNaam + ".xlsx").Print();
                        //  new FileInfo(@"E:\Leveringen\" + bestandsNaam + ".xlsx").Print();

                    }
                }
            }
        }
        static bool TryToDelete(string f)
        {
            try
            {
                // A.
                // Try to delete the file.
                File.Delete(f);

                return true;
            }
            catch (IOException)
            {
                // B.
                // We could not delete the file.
                return false;
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<string> Items = new List<string>();
            Items.Add(pdfLocatieMail);
            sendEmailViaOutlook(USER + "@dhuyvetterbeton.be", ((Klant)CboKlanten.SelectedItem).Email, "", txtOnderwerp.Text, txtBericht.Text, BodyType.PlainText, Items, null);
            txtOnderwerp.Text = "";
            txtBericht.Text = "";
            Items.Clear();
            lbxFacturen.Items.Clear();
            simpleButton2.Enabled = false;
        }

        private void calendarControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucHoofdvenster ucHoofdvenster = new ucHoofdvenster(USER, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }

        }
        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
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

                di.pDocName = "RAW Document";
                // Win7
                di.pDataType = "RAW";

                // Win8+
                // di.pDataType = "XPS_PASS";

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
                fs.Close();
                fs.Dispose();
                fs = null;
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
        }
    }
}
