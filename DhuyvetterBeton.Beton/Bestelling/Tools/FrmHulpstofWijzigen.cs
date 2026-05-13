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
using BL;
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    public partial class FrmHulpstofWijzigen : DevExpress.XtraEditors.XtraForm
    {
        BL.Bestelling bestelling;
        public FrmHulpstofWijzigen(BL.Bestelling bestelling1)
        {
            bestelling = bestelling1;
            InitializeComponent();
            List<SoortenHulpstof> soortenHulpstofs = SoortenHulpstof.KrijgAlleSoortenHulpstof();
            cboHulpstof.Properties.Items.AddRange(soortenHulpstofs.ToArray());
            List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(bestelling.ID);
            Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
        }

        private void Listboxhulpstoffen_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            int index = Listboxhulpstoffen.SelectedIndex;
            Hulpstof hulpstof = ((Hulpstof)Listboxhulpstoffen.SelectedItem);
            hulpstof.verwijderHulpstof();
            Listboxhulpstoffen.Items.RemoveAt(index); 
            XtraMessageBox.Show("De hulpstof is verwijderd.", "Aanpassing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Hulpstof hulpstof = new Hulpstof();
            hulpstof.Naam = cboHulpstof.Text;
            if (txtHoeveelheidHulpstof.Text != string.Empty)
            {
                hulpstof.Hoeveelheid = txtHoeveelheidHulpstof.Text;
            }
            else
            {
                hulpstof.Hoeveelheid = " ";
            }

            hulpstof.Bestelling = bestelling;
            hulpstof.Voeghulpstoftoe();
            cboHulpstof.Text = string.Empty;
            txtHoeveelheidHulpstof.Text = string.Empty;
            Listboxhulpstoffen.Items.Clear();
            List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(bestelling.ID);
            Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
            Cursor.Current = Cursors.Default;
            XtraMessageBox.Show("De hulpstof is toegevoegd.", "Aanpassing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}