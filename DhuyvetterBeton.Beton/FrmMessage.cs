using DhuyvetterBeton.Beton.Bestelling;
using DhuyvetterBeton.Beton.Klanten;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DhuyvetterBeton.Beton.Werven;
namespace DhuyvetterBeton.Beton
{
    public partial class FrmMessage : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        string user;
      
        public FrmMessage(string message, string buttonText1, string buttonText2, string User)
        {
            InitializeComponent();
            lblMessage.Text = message;
            button1.Text = buttonText1;
            button2.Text = buttonText2;
            user = User;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Beton" && lblMessage.Text == "Voor welke afdeling moet er een bestelling geplaatst worden?")
            {
            
            this.Close();
            }
            else if (button1.Text == "Beton" && lblMessage.Text == "Voor welke afdeling moet er een klant aangemaakt worden?")
            {
             
                this.Close();
            }
            else if (button1.Text == "Beton" && lblMessage.Text == "Voor welke afdeling moet er een werf aangemaakt worden?")
            {
                FrmNieuweWerf frm = new FrmNieuweWerf(null, user);
                frm.MdiParent = MdiParent;
                frm.Show();
                this.Close();
            }
            else if (button1.Text == "Beton" && lblMessage.Text == "Voor welke afdeling moet er een bestelling aangepast worden?")
            {
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Prefab" && lblMessage.Text == "Voor welke afdeling moet er een bestelling geplaatst worden?")
            {
              
            }
            else if (button2.Text == "Prefab" && lblMessage.Text == "Voor welke afdeling moet er een klant aangemaakt worden?")
            {
             
                this.Close();
            }
            else if (button2.Text == "Prefab" && lblMessage.Text == "Voor welke afdeling moet er een werf aangemaakt worden?")
            {
                FrmNieuweWerfPrefab frm = new FrmNieuweWerfPrefab(user);
                frm.MdiParent = MdiParent;
                frm.Show();
                this.Close();
            }
            else if (button2.Text == "Prefab" && lblMessage.Text == "Voor welke afdeling moet er een bestelling aangepast worden?")
            {
              
            }
        }
    }
}
