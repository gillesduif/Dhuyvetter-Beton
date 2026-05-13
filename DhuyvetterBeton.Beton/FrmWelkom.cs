using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton
{
    public partial class FrmWelkom : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public string ReturnValue1 { get; set; }
       
        public FrmWelkom()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void FrmWelkom_Load(object sender, EventArgs e)
        {

            string fileName = @"C:\Temp\USER.txt";
            FileInfo fi = new FileInfo(fileName);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (fi.Exists)
                {
                    string USERNAME = File.ReadAllText(fileName);
                    if (USERNAME == "Jan")
                    {
                        pictureEditLoes.Enabled = false;
                        pictureEditCindy.Enabled = false;
                        
                        pictureEditYara.Enabled = false;
                        pictureEditPedro.Enabled = false;
                        
                        pictureEditGilles.Enabled = false;
                    }
                    else if (USERNAME == "Cindy")
                    {
                        pictureEditLoes.Enabled = false;
                        pictureEditJan.Enabled = false;
                        
                        pictureEditYara.Enabled = false;
                        pictureEditPedro.Enabled = false;
                        
                        pictureEditGilles.Enabled = false;
                    }
                    else if (USERNAME == "Yara")
                    {
             
                        pictureEditLoes.Enabled = false;
                        pictureEditCindy.Enabled = false;
                        
                        pictureEditJan.Enabled = false;
                        pictureEditPedro.Enabled = false;
                        
                        pictureEditGilles.Enabled = false;
                    }
                    else if (USERNAME == "Didier")
                    {
                        pictureEditJan.Enabled = false;
                        pictureEditCindy.Enabled = false;
                        
                        pictureEditYara.Enabled = false;
                        pictureEditPedro.Enabled = false;
                        
                        pictureEditGilles.Enabled = false;
                    }
                    else if (USERNAME == "Tania")
                    {
                        pictureEditLoes.Enabled = false;
                        pictureEditCindy.Enabled = false;
                        pictureEditJan.Enabled = false;
                        pictureEditYara.Enabled = false;
                        pictureEditPedro.Enabled = false;
                        
                        pictureEditGilles.Enabled = false;
                    }
                    else if (USERNAME == "Pedro")
                    {
                        pictureEditLoes.Enabled = false;
                        pictureEditCindy.Enabled = false;
                        pictureEditJan.Enabled = false;
                        pictureEditYara.Enabled = false;
                        
                        pictureEditGilles.Enabled = false;
                    }
                }
            }
            catch
            {

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmHoofdVenster frm = new FrmHoofdVenster("Cindy");
            frm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            if (checkBoxOnthouden.Checked == true)
            {
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes("Jan");
                        fs.Write(txt, 0, txt.Length);

                    }
                }
                catch
                {

                }

            }
            this.ReturnValue1 = "Jan";
            this.Close();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (checkBoxOnthouden.Checked == true)
            {
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes("Yara");
                        fs.Write(txt, 0, txt.Length);

                    }
                }
                catch
                {

                }

            }
            if (pictureEditYara.Enabled == true)
            {
                FrmHoofdVenster frm = new FrmHoofdVenster("Yara");
                frm.Show();
                this.Hide();
            }

        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            if (checkBoxOnthouden.Checked == true)
            {
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes("Cindy");
                        fs.Write(txt, 0, txt.Length);

                    }
                }
                catch
                {

                }

            }
            if (pictureEditCindy.Enabled == true)
            {
                FrmHoofdVenster frm = new FrmHoofdVenster("Cindy");
                frm.Show();
                this.Hide();
            }
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            if (checkBoxOnthouden.Checked == true)
            {
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes("Loes");
                        fs.Write(txt, 0, txt.Length);

                    }
                }
                catch
                {

                }

            }
            if (pictureEditLoes.Enabled == true)
            {
                FrmHoofdVenster frm = new FrmHoofdVenster( "Didier");
                frm.Show();
                this.Hide();
            }
        }

        private void pictureEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            if (checkBoxOnthouden.Checked == true)
            {
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes("Tania");
                        fs.Write(txt, 0, txt.Length);

                    }
                }
                catch
                {

                }

            }
          
        }

        private void pictureEditPedro_Click(object sender, EventArgs e)
        {
            if (checkBoxOnthouden.Checked == true)
            {
                string fileName = @"C:\Temp\USER.txt";
                FileInfo fi = new FileInfo(fileName);

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }

                    // Create a new file     
                    using (FileStream fs = fi.Create())
                    {
                        Byte[] txt = new UTF8Encoding(true).GetBytes("Pedro");
                        fs.Write(txt, 0, txt.Length);

                    }
                }
                catch
                {

                }
            }
            if (pictureEditPedro.Enabled == true)
            {
                this.ReturnValue1 = "Pedro";
                this.Close();
            }
        }

        private void checkBoxOnthouden_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureEditFabien_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureEdit1_Click_1(object sender, EventArgs e)
        {
            this.ReturnValue1 = "Gilles";
            this.Close();
        }

        private void pictureEditLoes_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEditJenny_Click(object sender, EventArgs e)
        {
            if (pictureEditLoes.Enabled == true)
            {
                FrmHoofdVenster frm = new FrmHoofdVenster("Jenny");
                frm.Show();
                this.Hide();
            }
        }

        private void pictureEditGilles_EditValueChanged(object sender, EventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ReturnValue1 = "Jan";
            this.Close();
            timer1.Stop();
        
        }
    }
}
