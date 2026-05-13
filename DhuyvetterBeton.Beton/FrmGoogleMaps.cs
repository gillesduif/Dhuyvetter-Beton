using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace DhuyvetterBeton.Beton
{
    public partial class FrmGoogleMaps : DevExpress.XtraEditors.XtraForm
    {
        string zoekURL = string.Empty;
        
        public FrmGoogleMaps(string zoekURLimport)
        {
            zoekURL = zoekURLimport;
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (webView21 != null && webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate(zoekURL);
            }
          
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
        }
    }
}