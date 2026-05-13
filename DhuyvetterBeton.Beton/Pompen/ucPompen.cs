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
using Microsoft.Web.WebView2.Core;
using Gecko;

namespace DhuyvetterBeton.Beton.Pompen
{
    public partial class ucPompen : DevExpress.XtraEditors.XtraUserControl
    {
        PompPrijs geselecteerdePompPrijs = new PompPrijs();
        List<Pomp> pompen;
        string user;
        string versie;
        FrmHoofdVenster frmhoofd;
        List<PompPrijs> pompPrijzen = PompPrijs.KrijgAllePompPrijzen();
        public ucPompen(string user1,FrmHoofdVenster frmhoofd1,string versie1)
        {
            InitializeComponent();
         //   Xpcom.Initialize("Firefox");
            user = user1;
            frmhoofd = frmhoofd1;
            versie = versie1;
            timer1.Start();
            this.Resize += new System.EventHandler(this.Form_Resize);
            timer4.Start();
          
            foreach(PompPrijs prijs in pompPrijzen)
            {
                ListboxPrijzenPomp.Items.Add(prijs.ToStringGiek());
            }

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pompen = Pomp.KrijgAllePompen();
            pompen.Sort((X, Y) => X.PompLeverancier.CompareTo(Y.PompLeverancier));
            foreach (Pomp pomp in pompen)
            {
                dataGridViewPompen.Rows.Add(
                    new object[]
                    {
                        pomp.ID,
                        pomp.PompLeverancier,
                        pomp.Pompdetails
                    }

                    );
            }

            vScrollBar1.Minimum = 0;
            int max = dataGridViewPompen.RowCount - 23;
            vScrollBar1.Maximum = max;

            timer1.Stop();
        }

        private void dataGridViewPompen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewPompen.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewPompen.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewPompen.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPompen.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void dataGridViewPompen_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.dataGridViewPompen.SelectedCells;
            Pomp pomp = new Pomp();
            pomp.ID = Convert.ToInt32(DGV[0].Value);
            pomp.PompLeverancier = DGV[1].Value.ToString();
            pomp.Pompdetails = DGV[2].Value.ToString();

            
            txtPompLeverancierWijzigen.Text = pomp.PompLeverancier;
            txtPompWijzigen.Text = pomp.Pompdetails;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Pomp pomp = new Pomp(txtPompLeverancierToevoegen.Text, txtPompToevoegen.Text);
            txtPompLeverancierToevoegen.Text = string.Empty;
            txtPompToevoegen.Text = string.Empty;
            pomp.MaakNieuwePomp();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            DataGridViewSelectedCellCollection DGV = this.dataGridViewPompen.SelectedCells;
       
           
            Pomp pomp2 = new Pomp(Convert.ToInt32(DGV[0].Value), txtPompLeverancierWijzigen.Text, txtPompWijzigen.Text);
            pomp2.UpdateGegevens();
            txtPompWijzigen.Text = string.Empty;
            txtPompLeverancierWijzigen.Text = string.Empty;
    
            pompen = Pomp.KrijgAllePompen();
            pompen.Sort((X, Y) => X.PompLeverancier.CompareTo(Y.PompLeverancier));
            dataGridViewPompen.Rows.Clear();
            foreach (Pomp pomp in pompen)
            {
                dataGridViewPompen.Rows.Add(
                    new object[]
                    {
                        pomp.ID,
                        pomp.PompLeverancier,
                        pomp.Pompdetails
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewPompen.RowCount - 23; 
            vScrollBar1.Maximum = max;
        }

        private void ucPompen_Load(object sender, EventArgs e)
        {
    
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < dataGridViewPompen.Rows.Count)
            {
                dataGridViewPompen.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void dataGridViewPompen_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = dataGridViewPompen.FirstDisplayedScrollingRowIndex;
        }

        private void dataGridViewPompen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucHoofdvenster ucHoofdvenster = new ucHoofdvenster(user, versie, null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void ucPompen_LocationChanged(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
          
        }

        private void ListboxPrijzenPomp_DoubleClick(object sender, EventArgs e)
        {

           
        }

        private void ListboxPrijzenPomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               geselecteerdePompPrijs = new PompPrijs();
               foreach (PompPrijs prijs in pompPrijzen)
               {
                   if (prijs.Giek == ListboxPrijzenPomp.SelectedItem.ToString())
                   {
                        geselecteerdePompPrijs = prijs;
                   }

               }

               txtBedrag.Text = geselecteerdePompPrijs.Bedrag.ToString();
               txtSuppliment.Text = geselecteerdePompPrijs.Suppliment.ToString();
            }catch
            {

            }
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PompPrijs pompPrijs = new PompPrijs(geselecteerdePompPrijs.ID, geselecteerdePompPrijs.Giek, Convert.ToDouble(txtBedrag.Text), Convert.ToDouble(txtSuppliment.Text));
            pompPrijs.Wijzigen();
            txtSuppliment.Text = string.Empty;
            txtBedrag.Text = string.Empty;
        }
    }
}
