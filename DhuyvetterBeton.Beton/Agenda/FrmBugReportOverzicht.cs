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
    public partial class FrmBugReportOverzicht : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmBugReportOverzicht()
        {
            InitializeComponent();
        }

        private void FrmBugReportOverzicht_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");


            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            List<BugReport> bugreports = BugReport.KrijgAlleBugReports();

            foreach (BL.BugReport bugReport in bugreports)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        bugReport.ID,
                        bugReport.Type,
                        bugReport.Prioriteit,
                        bugReport.Sectie,
                        bugReport.Omschrijving,
                        bugReport.Afbeelding,
                        bugReport.Gebruiker
                    }

                    );
            }
            bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
     
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
            int ID = (Convert.ToInt32(DGV[0].Value));
        
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedCells.Count == 7)
            {
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
                comboBoxType.Text = DGV[1].Value.ToString();
                comboBoxPrioriteit.Text = DGV[2].Value.ToString();
                comboBoxSectie.Text = DGV[3].Value.ToString();
                txtOmschrijving.Text = DGV[4].Value.ToString();
                byte[] afbeelding = ((byte[])DGV[5].Value);
                MemoryStream memoryStream = new MemoryStream(afbeelding);
                pictureEdit1.Image = Image.FromStream(memoryStream);
            }
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
