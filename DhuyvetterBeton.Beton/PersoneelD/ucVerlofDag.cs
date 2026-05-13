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
using DevExpress.XtraScheduler;

namespace DhuyvetterBeton.Beton.PersoneelD
{
    public partial class ucVerlofDag : DevExpress.XtraEditors.XtraUserControl
    {
        BL.Personeel personeelWijzigen = new BL.Personeel();
        int IDwijzigen = 0;
        public ucVerlofDag()
        {
            InitializeComponent();
            DateStart.EditValue = DateTime.Today;
            DateEinde.EditValue = DateTime.Today;
            schedulerControl1.Start = DateTime.Today;
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorJaar(DateTime.Today.AddYears(+1));
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            foreach (Verlof verlof in verlofLijstRefresh)
            {

                // Create a new appointment.  
                Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);

                // Set the appointment's time interval to the selected time interval.  
                if (verlof.Startdatum.Hour == 0 && verlof.Einddatum.Hour == 0)
                {
                    DateTime date = new DateTime(verlof.Startdatum.Year, verlof.Startdatum.Month, verlof.Startdatum.Day);
                    apt.Start = date;
                    apt.End = verlof.Einddatum.Date;
                }
                else
                {
                    try
                    {
                        apt.Start = verlof.Startdatum;
                        apt.End = verlof.Einddatum.Date;
                    }
                    catch
                    {

                    }
                
                }
             
               
                apt.Subject = verlof.PersoneelsLid.Naam;
                apt.Description = verlof.ID.ToString();
                // Set the appointment's resource to the resource which contains  
                // the currently selected time interval.  
                apt.ResourceId = schedulerControl1.SelectedResource.Id;

                // Add the new appointment to the appointment collection.  
                schedulerControl1.DataStorage.Appointments.Add(apt);
            }

            refreshAgenda();
            Cursor.Current = Cursors.AppStarting;

            List<BL.Personeel> personeelLijst = BL.Personeel.KrijgAllePersoneelLeden();
            personeelLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
           
            cboPersoneel.Properties.Items.AddRange(personeelLijst.ToArray());
            
        }

        private void ucVerlofDag_Load(object sender, EventArgs e)
        {

        }

        private void ucVerlofDag_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void ucVerlofDag_Click(object sender, EventArgs e)
        {
           
        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < schedulerControl1.SelectedAppointments.Count; i++)
            {
                Appointment apt = schedulerControl1.SelectedAppointments[i];

                // Create new appointment using copy operation.
                Appointment newApt = apt.Copy();

                // Add one month to the new appointment's start time.
               
                IDwijzigen = Convert.ToInt32(newApt.Description);
                Verlof verlof = Verlof.KrijgVerlofDoorID(IDwijzigen);
                personeelWijzigen = verlof.PersoneelsLid;
                // Add new appointment to the appointment collection.
                dtpStartDatumWijzigen.EditValue = verlof.Startdatum;
                dtpEindDatumWijzigen.EditValue = verlof.Einddatum;
                label1.Text = verlof.PersoneelsLid.Naam;
            }
        }

        private void simpleButtonWijzigen_Click(object sender, EventArgs e)
        {
            Verlof verlof1 = new Verlof(IDwijzigen, personeelWijzigen, Convert.ToDateTime(dtpStartDatumWijzigen.EditValue), Convert.ToDateTime(dtpEindDatumWijzigen.EditValue));
            verlof1.Wijzigen();
            schedulerControl1.DataStorage.Appointments.Clear();
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorJaar(DateTime.Today);
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            foreach (Verlof verlof in verlofLijstRefresh)
            {

                // Create a new appointment.  
                Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);

                // Set the appointment's time interval to the selected time interval.  
                if (verlof.Startdatum.Hour == 0 && verlof.Einddatum.Hour == 0)
                {
                    DateTime date = new DateTime(verlof.Startdatum.Year, verlof.Startdatum.Month, verlof.Startdatum.Day);
                    apt.Start = date;
                    apt.End = verlof.Einddatum.Date;
                }
                else
                {
                    apt.Start = verlof.Startdatum;
                    apt.End = verlof.Einddatum;
                }


                apt.Subject = verlof.PersoneelsLid.Naam;
                apt.Description = verlof.ID.ToString();
                // Set the appointment's resource to the resource which contains  
                // the currently selected time interval.  
                apt.ResourceId = schedulerControl1.SelectedResource.Id;

                // Add the new appointment to the appointment collection.  
                schedulerControl1.DataStorage.Appointments.Add(apt);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Verlof verlof1 = Verlof.KrijgVerlofDoorID(IDwijzigen); 
            verlof1.Verwijderen();
            IDwijzigen = 0;
            schedulerControl1.DataStorage.Appointments.Clear();
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorJaar(DateTime.Today);
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            foreach (Verlof verlof in verlofLijstRefresh)
            {

                // Create a new appointment.  
                Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);

                // Set the appointment's time interval to the selected time interval.  
                if (verlof.Startdatum.Hour == 0 && verlof.Einddatum.Hour == 0)
                {
                    DateTime date = new DateTime(verlof.Startdatum.Year, verlof.Startdatum.Month, verlof.Startdatum.Day);
                    apt.Start = date;
                    apt.End = verlof.Einddatum.Date;
                }
                else
                {
                    apt.Start = verlof.Startdatum;
                    apt.End = verlof.Einddatum;
                }

                apt.Subject = verlof.PersoneelsLid.Naam;
                apt.Description = verlof.ID.ToString();
                // Set the appointment's resource to the resource which contains  
                // the currently selected time interval.  
                apt.ResourceId = schedulerControl1.SelectedResource.Id;

                // Add the new appointment to the appointment collection.  
                schedulerControl1.DataStorage.Appointments.Add(apt);
            }
        }
        private void refreshAgenda()
        {
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorJaar(DateTime.Today);
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            foreach (Verlof verlof in verlofLijstRefresh)
            {

                // Create a new appointment.  
                Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);

                // Set the appointment's time interval to the selected time interval.  
                if (verlof.Startdatum.Hour == 0 && verlof.Einddatum.Hour == 0)
                {
                    DateTime date = new DateTime(verlof.Startdatum.Year, verlof.Startdatum.Month, verlof.Startdatum.Day);
                    apt.Start = date;
                    apt.End = verlof.Einddatum.Date;
                }
                else
                {
                    if (verlof.Einddatum > verlof.Startdatum)
                    {
                        apt.Start = verlof.Startdatum;
                        apt.End = verlof.Einddatum;
                    }
                }

                apt.Subject = verlof.PersoneelsLid.Naam;
                apt.Description = verlof.ID.ToString();
                // Set the appointment's resource to the resource which contains  
                // the currently selected time interval.  
                apt.ResourceId = schedulerControl1.SelectedResource.Id;

                // Add the new appointment to the appointment collection.  
                schedulerControl1.DataStorage.Appointments.Add(apt);
            }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Verlof verlof1 = new Verlof(((BL.Personeel)cboPersoneel.SelectedItem), Convert.ToDateTime(DateStart.EditValue), Convert.ToDateTime(DateEinde.EditValue));
            verlof1.Nieuw();
            cboPersoneel.Text = string.Empty;
            DateStart.EditValue = DateTime.Today;
            DateEinde.EditValue = DateTime.Today;
            schedulerControl1.DataStorage.Appointments.Clear();
            refreshAgenda();
        }
    }
}
