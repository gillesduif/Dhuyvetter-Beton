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

namespace DhuyvetterBeton.Beton.Agenda
{
    public partial class ucAgendaPrefab : DevExpress.XtraEditors.XtraUserControl
    {
        string user;
        FrmHoofdVenster frmhoofd;
        string versie;
        public ucAgendaPrefab(string user1,FrmHoofdVenster frmhoofd1, string versie1)
        {
            InitializeComponent();
            versie = versie1;
            frmhoofd = frmhoofd1;
            user = user1;

            bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);

            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");

            dtpDatum.EditValue = DateTime.Today;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);

            List<BestellingPrefab> prefabBestellingen = BestellingPrefab.KrijgAlleBestellingenDoorDatum(dtpDatum.SelectionStart.Date, dtpDatum.SelectionStart.Date.AddDays(+1));
            prefabBestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));

            bunifuCustomDataGrid1.DataSource = null;
            bunifuCustomDataGrid1.Rows.Clear();
            foreach (BestellingPrefab prefabBestelling in prefabBestellingen)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        prefabBestelling.ID,
                        prefabBestelling.KlantPrefab,
                        prefabBestelling.WerfPrefab,
                        prefabBestelling.Datum,
                        prefabBestelling.Levering,
                        prefabBestelling.Opmerking
                    }

                    );
            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            List<BestellingPrefab> prefabBestellingen = BestellingPrefab.KrijgAlleBestellingenDoorDatum(Convert.ToDateTime(dtpDatum.EditValue).Date, Convert.ToDateTime(dtpDatum.EditValue).Date.AddDays(+1));
            prefabBestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
           
            bunifuCustomDataGrid1.DataSource = null;
            bunifuCustomDataGrid1.Rows.Clear();
            foreach (BestellingPrefab prefabBestelling in prefabBestellingen)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        prefabBestelling.ID,
                        prefabBestelling.KlantPrefab,
                        prefabBestelling.WerfPrefab,
                        prefabBestelling.Datum,
                        prefabBestelling.Levering,
                        prefabBestelling.Opmerking
                    }

                    );
            }

        }

        private void dtpDatum_SelectionChanged(object sender, EventArgs e)
        {
            List<BestellingPrefab> prefabBestellingen = BestellingPrefab.KrijgAlleBestellingenDoorDatum(dtpDatum.SelectionStart.Date, dtpDatum.SelectionStart.Date.AddDays(+1));
            prefabBestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));

            bunifuCustomDataGrid1.DataSource = null;
            bunifuCustomDataGrid1.Rows.Clear();
            foreach (BestellingPrefab prefabBestelling in prefabBestellingen)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        prefabBestelling.ID,
                        prefabBestelling.KlantPrefab,
                        prefabBestelling.WerfPrefab,
                        prefabBestelling.Datum,
                        prefabBestelling.Levering,
                        prefabBestelling.Opmerking
                    }

                    );
            }

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

        private void dtpDatum_Click(object sender, EventArgs e)
        {

        }
    }
}
