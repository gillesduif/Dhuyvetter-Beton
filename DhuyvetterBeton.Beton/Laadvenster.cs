using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace DhuyvetterBeton.Beton
{
    public partial class Laadvenster : SplashScreen
    {
        public Laadvenster()
        {
            InitializeComponent();
            Ping ping = new Ping();
            PingReply pingReply = ping.Send("Google.com");

            if (pingReply.Status == IPStatus.Success)
            {
                pictureBoxOnline.Visible = true;
                //pictureboxO
            }
            else
            {
                pictureBoxOnline.Visible = false;
            }
            timer1.Start();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Laadvenster_Load(object sender, EventArgs e)
        {
       
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LabelInfo.Text = "Klanten laden...";
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LabelInfo.Text = "Programma opstarten...";
            timer2.Stop();
        }
    }
}