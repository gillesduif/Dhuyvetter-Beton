using BL;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Agenda
{
    public partial class FrmBugReport : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        string printscreen = string.Empty;
        Image File;
        string User;
        string imgLocation = string.Empty;
        public FrmBugReport(string User1)
        {
            User = User1;
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                pictureEdit1.Image = File; ;
                imgLocation = f.FileName.ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            byte[] image = null;
            if(printscreen != string.Empty)
            {
                imgLocation = printscreen;
            }
            else if (imgLocation == "")
            {
                imgLocation = "Z:\\logo jpeg\\dhlogo.jpg";
            }
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            image = brs.ReadBytes((int)stream.Length);
            BugReport bugReport = new BugReport(comboBoxType.Text, comboBoxPrioriteit.Text, comboBoxSectie.Text, txtOmschrijving.Text, image, User);
            bugReport.MaakNieuwRapport();
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                    SendKeys.Send("{PRTSC}");
                    Image img = Clipboard.GetImage();
                    pictureEdit1.Image = img;
                    Random rnd = new Random();
                    int num = rnd.Next(10000000);
              
                    img.Save("Z:\\Bestelling programma\\Printscreens\\"+ num.ToString() + ".jpg");
                    printscreen = "Z:\\Bestelling programma\\Printscreens\\" + num.ToString() + ".jpg";


            }
          catch { }
        }
    }
}
