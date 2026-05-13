using BL;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfvoerOfInvoer
{
    public partial class Form1 : Form
    {
        List<Klant> KlantenLijst = Klant.KrijgAlleKlanten();
        List<Formule> FormuleLijst = Formule.KrijgAlleFormules();
       
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Afvoer_Invoer;
            if (cboInvoer.SelectedIndex == 0)
            {
                Afvoer_Invoer = "Aanvoer";
            }
            else
            {
                Afvoer_Invoer = "Afvoer";
            }
            Klant klant = ((Klant)cboKlanten.SelectedItem);
            double ton = 0;
            try
            {
                 ton = Convert.ToDouble(txtTon.Text);
            }
            catch
            {
                
            }
       
            DateTime datumTijd = dtp1.Value;
            Formule formule = ((Formule)cboFormule.SelectedItem);
            string productiebatchnr = txtProductiebatchnr.Text;
            string bruto = txtBruto.Text;
            string tarra = txtTarra.Text;
            string netto = txtNetto.Text;
            string chauffeur = txtChauffeur.Text;
            string nummerplaat = txtNummerplaat.Text;
            AfvoerInvoer afvoerInvoer = new AfvoerInvoer(klant, datumTijd, Afvoer_Invoer,chauffeur,nummerplaat, formule, ton, productiebatchnr, bruto,tarra,netto);
            afvoerInvoer.Nieuw();
            cboFormule.Text = string.Empty;
            cboKlanten.Text = string.Empty;
            txtTon.Text = string.Empty;
            txtProductiebatchnr.Text = string.Empty;
            cboInvoer.Text = string.Empty;
            txtBruto.Text = string.Empty;
            txtTarra.Text = string.Empty;
            txtNetto.Text = string.Empty;

            if (afvoerInvoer.Ton != 0)
            {
                afvoerInvoer.GeneerAfvoerExcell();
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                pd.PrinterSettings.Copies = 1;
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    string bestandsNaam = afvoerInvoer.Klant.Naam + " " + afvoerInvoer.DatumTijd.Hour.ToString() + "u" + afvoerInvoer.DatumTijd.Minute.ToString(); ;

                    new FileInfo(@"C:\\AanvoerAfvoer\" + afvoerInvoer.DatumTijd.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();

                }
            }
            else
            {
                afvoerInvoer.GeneerAanvoerExcell();
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                pd.PrinterSettings.Copies = 1;
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    string bestandsNaam = afvoerInvoer.Klant.Naam + " " + afvoerInvoer.DatumTijd.Hour.ToString() + "u" + afvoerInvoer.DatumTijd.Minute.ToString(); ;

                    new FileInfo(@"C:\\AanvoerAfvoer\" + afvoerInvoer.DatumTijd.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();

                }
            }


            dtp1.Value = DateTime.Now;
            timer1.Start();
            dataGridView1.DataSource = null;
            List<AfvoerInvoer> afvoerInvoers = AfvoerInvoer.KrijgAlleAfVoerInvoerItemsVoorDatums(DateTime.Today, DateTime.Today.AddDays(+1));
            dataGridView1.DataSource = afvoerInvoers;
            dataGridView1.Columns[0].HeaderText = "Bon nummer";
            dataGridView1.Columns[1].HeaderText = "Datum";
            dataGridView1.Columns[3].HeaderText = "Aanvoer/Afvoer";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dtp1.CustomFormat = "MM/dd/yyyy HH:mm";
            dtp2.Value = DateTime.Today;
            dtp3.Value = DateTime.Today.AddDays(+1);
            cboKlanten.Items.AddRange(KlantenLijst.ToArray());
            cboFormule.Items.AddRange(FormuleLijst.ToArray());
            List<AfvoerInvoer> afvoerInvoers = AfvoerInvoer.KrijgAlleAfVoerInvoerItemsVoorDatums(DateTime.Today, DateTime.Today.AddDays(+1));
            dataGridView1.DataSource = afvoerInvoers;
            dataGridView1.Columns[0].HeaderText = "Bon nummer";
            dataGridView1.Columns[1].HeaderText = "Datum";
            dataGridView1.Columns[3].HeaderText = "Aanvoer/Afvoer";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
            }
            catch
            {
                timer1.Start();
            }
        }

        private void cboInvoer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
            }
            catch
            {
                timer1.Start();
            }

            try
            {
                 if (cboInvoer.SelectedIndex == 0)
                 {
                    txtNetto.Enabled = true;
                    txtBruto.Enabled = true;
                    txtTarra.Enabled = true;
                    txtTon.Enabled = false;
                }   
                 else if (cboInvoer.SelectedIndex == 1)
                 {
                    txtNetto.Enabled = false;
                    txtBruto.Enabled = false;
                    txtTarra.Enabled = false;
                    txtTon.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void cboFormule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
            }
            catch
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            dataGridView1.DataSource = null;
            List<AfvoerInvoer> afvoerInvoers = AfvoerInvoer.KrijgAlleAfVoerInvoerItemsVoorDatums(dtp2.Value, dtp3.Value);
            dataGridView1.DataSource = afvoerInvoers;
            dataGridView1.Columns[0].HeaderText = "Bon nummer";
            dataGridView1.Columns[1].HeaderText = "Datum";
            dataGridView1.Columns[3].HeaderText = "Aanvoer/Afvoer";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 12)
            {
                DataGridViewSelectedCellCollection DGV = this.dataGridView1.SelectedCells;

                AfvoerInvoer afvoerInvoer = new AfvoerInvoer();
                afvoerInvoer.ID = Convert.ToInt32(DGV[0].Value);
                afvoerInvoer.DatumTijd = Convert.ToDateTime(DGV[1].Value);
                afvoerInvoer.Klant = (Klant)DGV[2].Value;
                afvoerInvoer.Afvoer_Invoer = DGV[3].Value.ToString();
                afvoerInvoer.Chauffeur = DGV[4].Value.ToString();
                afvoerInvoer.Nummerplaat = DGV[5].Value.ToString();
                afvoerInvoer.Formule = ((Formule)DGV[6].Value);
                afvoerInvoer.Ton = Convert.ToDouble(DGV[7].Value);
                afvoerInvoer.Productiebatchnr = DGV[8].Value.ToString();
                afvoerInvoer.Bruto = DGV[9].Value.ToString();
                afvoerInvoer.Tarra = DGV[10].Value.ToString();
                afvoerInvoer.Netto = DGV[11].Value.ToString();
                if (afvoerInvoer.Ton != 0)
                {
                    afvoerInvoer.GeneerAfvoerExcell();
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();
                    pd.PrinterSettings.Copies = 1;
                    if (DialogResult.OK == pd.ShowDialog(this))
                    {
                        string bestandsNaam = afvoerInvoer.Klant.Naam + " " + afvoerInvoer.DatumTijd.Hour.ToString() + "u" + afvoerInvoer.DatumTijd.Minute.ToString(); ;

                        new FileInfo(@"C:\\AanvoerAfvoer\" + afvoerInvoer.DatumTijd.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();

                    }
                }
                else
                {
                    afvoerInvoer.GeneerAanvoerExcell();
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();
                    pd.PrinterSettings.Copies = 1;
                    if (DialogResult.OK == pd.ShowDialog(this))
                    {
                        string bestandsNaam = afvoerInvoer.Klant.Naam + " " + afvoerInvoer.DatumTijd.Hour.ToString() + "u" + afvoerInvoer.DatumTijd.Minute.ToString(); ;

                        new FileInfo(@"C:\\AanvoerAfvoer\" + afvoerInvoer.DatumTijd.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();

                    }
                }
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
