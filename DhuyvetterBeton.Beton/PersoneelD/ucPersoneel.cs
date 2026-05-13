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
using DevExpress.Utils;
using BL;

using DevExpress.XtraScheduler;
using DhuyvetterBeton.Beton.PersoneelD;
using DhuyvetterBeton.Beton.Agenda;

namespace DhuyvetterBeton.Beton.Personeel
{
    public partial class ucPersoneel : DevExpress.XtraEditors.XtraUserControl
    {
        List<BL.Personeel> personeelLijst;
        string user;
        string versie;
        FrmHoofdVenster frmhoofd;
        List<Verlof> verlofKalenderExport = new List<Verlof>();
        public ucPersoneel(string USER, FrmHoofdVenster frmhoofd1, string versie1)
        {
            InitializeComponent();
            schedulerControl1.ActiveViewType = SchedulerViewType.Month;
            txtYear.Text = DateTime.Today.Year.ToString();
            txtYear2.Text = DateTime.Today.Year.ToString();
            dateEdit1.Text = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
            int month = DateTime.Today.Month - 1;
            comboBoxEdit1.SelectedIndex = month;
            comboBoxEditMaand.SelectedIndex = month;
            dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = false;
            dateEdit1.Properties.Mask.EditMask = "MMMM yyyy";
            user = USER;
            frmhoofd = frmhoofd1;
            versie = versie1;
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            timer1.Start();
 
            DateStart.EditValue = DateTime.Today;
            DateEinde.EditValue = DateTime.Today;
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(DateTime.Today);
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            verlofKalenderExport = verlofLijstRefresh;


            foreach (BL.Verlof verlof1 in verlofLijstRefresh)
            {
                dataGridView1.Rows.Add(
                    new object[]
                    {
                        verlof1.ID,
                        verlof1.PersoneelsLid,
                        verlof1.Startdatum.ToShortDateString() + " - " + verlof1.Startdatum.ToShortTimeString(),
                           verlof1.Einddatum.ToShortDateString() + " - " + verlof1.Einddatum.ToShortTimeString(),
                    }

                    );
            }

            vScrollBar2.Minimum = 0;
            int max = bunifuCustomDataGrid1.RowCount;
            vScrollBar2.Maximum = max;
        }
        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedCells.Count == 4)
            {
                DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
                BL.Personeel personeelsLid = new BL.Personeel(Convert.ToInt32(DGV[0].Value), DGV[1].Value.ToString(), DGV[2].Value.ToString(), DGV[3].Value.ToString());
                labelNaam.Text = personeelsLid.Naam;
                labelGSM.Text = personeelsLid.Gsm;
                labelMail.Text = personeelsLid.Email;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;

            personeelLijst = BL.Personeel.KrijgAllePersoneelLeden();
            personeelLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            foreach (BL.Personeel personeel in personeelLijst)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        personeel.ID,
                        personeel.Naam,
                        personeel.Gsm,
                        personeel.Email,
                    }

                    );
            }
            cboPersoneel.Properties.Items.AddRange(personeelLijst.ToArray());
            cboPersoneelAanpassen.Properties.Items.AddRange(personeelLijst.ToArray());
            vScrollBar1.Minimum = 0;
            int max = bunifuCustomDataGrid1.RowCount -5;
            vScrollBar1.Maximum = max;

            timer1.Stop();
           
        }

        private void bunifuCustomDataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bunifuCustomDataGrid1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            bunifuCustomDataGrid1.RowsDefaultCellStyle.ForeColor = Color.White;
            bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            cboPersoneel.Properties.Items.Clear();
            cboPersoneelAanpassen.Properties.Items.Clear();
            BL.Personeel personeel = new BL.Personeel(txtNaam.Text, txtGsm.Text, txtMail.Text);
            personeel.MaakNieuw();
            personeelLijst.Add(personeel);
            personeelLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            cboPersoneel.Properties.Items.AddRange(personeelLijst.ToArray());
            cboPersoneelAanpassen.Properties.Items.AddRange(personeelLijst.ToArray());
            bunifuCustomDataGrid1.Rows.Clear();
            foreach (BL.Personeel personeel1 in personeelLijst)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        personeel1.ID,
                        personeel1.Naam,
                        personeel1.Gsm,
                        personeel1.Email,

                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = bunifuCustomDataGrid1.RowCount;
            vScrollBar1.Maximum = max;
            txtNaam.Text = string.Empty;
            txtGsm.Text =string.Empty;
            txtMail.Text = string.Empty;
        }

        private void bunifuCustomDataGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = bunifuCustomDataGrid1.FirstDisplayedScrollingRowIndex;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < bunifuCustomDataGrid1.Rows.Count)
            {
                bunifuCustomDataGrid1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void cboPersoneelAanpassen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = 0;

            switch (comboBoxEditMaand.SelectedIndex)
            {
                case 0:
                    month = 1;
                    break;

                case 1:
                    month = 2;
                    break;
                case 2:
                    month = 3;
                    break;
                case 3:
                    month = 4;
                    break;
                case 4:
                    month = 5;
                    break;
                case 5:
                    month = 6;
                    break;
                case 6:
                    month = 7;
                    break;
                case 7:
                    month = 8;
                    break;
                case 8:
                    month = 9;
                    break;
                case 9:
                    month = 10;
                    break;

                case 10:
                    month = 11;
                    break;
                case 11:
                    month = 12;
                    break;
          

                default:
                    MessageBox.Show("error");
                    break;
            }
            DateTime date = new DateTime(Convert.ToInt32(txtYear.Text), month, 1);
            if (cboPersoneelAanpassen.SelectedItem == null)
            {
                XtraMessageBox.Show("Gelieve persoon aan te duiden.", "Geen persoon gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBoxAanpassen.Items.Clear();
                List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(date, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
                listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime daterefresh = Convert.ToDateTime(DateStart.EditValue);
            Verlof verlof = new Verlof(((BL.Personeel)cboPersoneel.SelectedItem), Convert.ToDateTime(DateStart.EditValue), Convert.ToDateTime(DateEinde.EditValue));
            verlof.Nieuw();
            cboPersoneel.Text = string.Empty;
            DateStart.EditValue = DateTime.Today;
            DateEinde.EditValue = DateTime.Today;
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(daterefresh);
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            dataGridView1.Rows.Clear();
            foreach (BL.Verlof verlof1 in verlofLijstRefresh)
            {
                dataGridView1.Rows.Add(
                    new object[]
                    {
                        verlof1.ID,
                        verlof1.PersoneelsLid,
                        verlof1.Startdatum.ToShortDateString() + " - " + verlof1.Startdatum.ToShortTimeString(),
                        verlof1.Einddatum.ToShortDateString() + " - " + verlof1.Einddatum.ToShortTimeString(),

                    }

                    );
            }
           
        }

        private void listBoxAanpassen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAanpassen.SelectedItem != null)
            {
                dtpStartDatumWijzigen.EditValue = ((Verlof)listBoxAanpassen.SelectedItem).Startdatum;
                dtpEindDatumWijzigen.EditValue = ((Verlof)listBoxAanpassen.SelectedItem).Einddatum;
            }
        }

        private void simpleButtonWijzigen_Click(object sender, EventArgs e)
        {
         

            int month = 0;

            switch (comboBoxEditMaand.SelectedIndex)
            {
                case 0:
                    month = 1;
                    break;

                case 1:
                    month = 2;
                    break;
                case 2:
                    month = 3;
                    break;
                case 3:
                    month = 4;
                    break;
                case 4:
                    month = 5;
                    break;
                case 5:
                    month = 6;
                    break;
                case 6:
                    month = 7;
                    break;
                case 7:
                    month = 8;
                    break;
                case 8:
                    month = 9;
                    break;
                case 9:
                    month = 10;
                    break;

                case 10:
                    month = 11;
                    break;
                case 11:
                    month = 12;
                    break;
               

                default:
                    MessageBox.Show("error");
                    break;
            }
            DateTime date = new DateTime(Convert.ToInt32(txtYear.Text), month, 1);
            Verlof verlof = new Verlof(((Verlof)listBoxAanpassen.SelectedItem).ID, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem), Convert.ToDateTime(dtpStartDatumWijzigen.EditValue), Convert.ToDateTime(dtpEindDatumWijzigen.EditValue));
            verlof.Wijzigen();
            listBoxAanpassen.Items.Clear();
            List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(date, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
            listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());
            dataGridView1.Rows.Clear();



            List<Verlof> verlofLijst = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(date);
            List<Verlof> VerlofJaarFilter = new List<Verlof>();
            foreach (Verlof verlof1 in verlofLijst)
            {
                if (verlof1.Einddatum.Year == date.Year)
                {
                    VerlofJaarFilter.Add(verlof1);
                }
            }
            VerlofJaarFilter.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            foreach (BL.Verlof verlof1 in VerlofJaarFilter)
            {
                dataGridView1.Rows.Add(
                    new object[]
                    {
                        verlof1.ID,
                        verlof1.PersoneelsLid,
                        verlof1.Startdatum,
                        verlof1.Einddatum,

                    }

                    );
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int month = 0;

            switch (comboBoxEditMaand.SelectedIndex)
            {
                case 0:
                    month = 1;
                    break;

                case 1:
                    month = 2;
                    break;
                case 2:
                    month = 3;
                    break;
                case 3:
                    month = 4;
                    break;
                case 4:
                    month = 5;
                    break;
                case 5:
                    month = 6;
                    break;
                case 6:
                    month = 7;
                    break;
                case 7:
                    month = 8;
                    break;
                case 8:
                    month = 9;
                    break;
                case 9:
                    month = 10;
                    break;

                case 10:
                    month = 11;
                    break;
                case 11:
                    month = 12;
                    break;
                

                default:
                    MessageBox.Show("error");
                    break;
            }
            DateTime date = new DateTime(Convert.ToInt32(txtYear2.Text), month, 1);


            Verlof verlof = ((Verlof)listBoxAanpassen.SelectedItem);
            verlof.Verwijderen();
            listBoxAanpassen.Items.Clear();
            List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(date, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
            listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar2.Value = dataGridView1.FirstDisplayedScrollingRowIndex;
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < dataGridView1.Rows.Count)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataGridViewSelectedCellCollection DGV = this.bunifuCustomDataGrid1.SelectedCells;
            BL.Personeel personeel1 = new BL.Personeel(Convert.ToInt32(DGV[0].Value), DGV[1].Value.ToString(),DGV[2].Value.ToString(), DGV[3].Value.ToString());
            personeel1.Verwijderen();
            bunifuCustomDataGrid1.Rows.Clear();
            personeelLijst = BL.Personeel.KrijgAllePersoneelLeden();
            personeelLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            foreach (BL.Personeel personeel in personeelLijst)
            {
                bunifuCustomDataGrid1.Rows.Add(
                    new object[]
                    {
                        personeel.ID,
                        personeel.Naam,
                        personeel.Gsm,
                        personeel.Email,

                    }

                    );
            }
            cboPersoneel.Properties.Items.Clear();
            cboPersoneelAanpassen.Properties.Items.Clear();
            cboPersoneel.Properties.Items.AddRange(personeelLijst.ToArray());
            cboPersoneelAanpassen.Properties.Items.AddRange(personeelLijst.ToArray());
            vScrollBar1.Minimum = 0;
            int max = bunifuCustomDataGrid1.RowCount - 5;
            vScrollBar1.Maximum = max;

        }

        private void bunifuCustomDataGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                popupMenu1.ShowPopup(Control.MousePosition);

            }
        }

        private void bunifuCustomDataGrid1_MouseDown(object sender, MouseEventArgs e)
        {
       
        }

        private void bunifuCustomDataGrid1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.bunifuCustomDataGrid1.ClearSelection();
                    this.bunifuCustomDataGrid1.Rows[rowSelected].Selected = true;
                }
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(user, versie, null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            FrmCalendarView frm = new FrmCalendarView(verlofKalenderExport);
            frm.Show();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = 0;
            
            switch (comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    month = 1;
                    break;

                case 1:
                    month = 2;
                    break;
                case 2:
                    month = 3;
                    break;
                case 3:
                    month = 4;
                    break;
                case 4:
                    month = 5;
                    break;
                case 5:
                    month = 6;
                    break;
                case 6:
                    month = 7;
                    break;
                case 7:
                    month = 8;
                    break;
                case 8:
                    month = 9;
                    break;
                case 9:
                    month = 10;
                    break;

                case 10:
                    month = 11;
                    break;
                case 11:
                    month = 12;
                    break;
             

                default:
                    month = DateTime.Today.Month;
                    break;
            }
          
                DateTime date = new DateTime(Convert.ToInt32(txtYear.Text), month, 1);
          

                dataGridView1.Rows.Clear();
                List<Verlof> verlofLijst = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(date);
                List<Verlof> VerlofJaarFilter = new List<Verlof>();
                foreach (Verlof verlof in verlofLijst)
                {
                    if (verlof.Einddatum.Year == date.Year)
                    {
                        VerlofJaarFilter.Add(verlof);
                    }
                }
                VerlofJaarFilter.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
                foreach (BL.Verlof verlof1 in VerlofJaarFilter)
                {
                    dataGridView1.Rows.Add(
                        new object[]
                        {
                        verlof1.ID,
                        verlof1.PersoneelsLid,
                        verlof1.Startdatum.ToShortDateString(),
                        verlof1.Einddatum.ToShortDateString(),

                        }

                        );
                }
            
          
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            schedulerControl1.DataStorage.Appointments.Clear();
            // Select time interval  
            schedulerControl1.ActiveView.SetSelection(new TimeInterval(DateTime.Now, new TimeSpan(2, 40, 0)), ResourceEmpty.Resource);
            // Group by resource.  
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            // Create a new appointment.  
            Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);

            // Set the appointment's time interval to the selected time interval.  
            apt.Start = new DateTime(2021, 06, 21);
            apt.End = new DateTime(2021, 06, 22);
            apt.Subject = "Test";
            // Set the appointment's resource to the resource which contains  
            // the currently selected time interval.  
            apt.ResourceId = schedulerControl1.SelectedResource.Id;

            // Add the new appointment to the appointment collection.  
            schedulerControl1.DataStorage.Appointments.Add(apt);
        }
    }
}
