using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using BL;

namespace DhuyvetterBeton.Beton.PersoneelD
{
    public partial class FrmCalendarView : DevExpress.XtraEditors.XtraForm
    {
        List<Verlof> VerlofImport = new List<Verlof>();
        public FrmCalendarView(List<Verlof> VerlofImport1)
        {
            VerlofImport = VerlofImport1;
            InitializeComponent();
        }

        private void FrmCalendarView_Load(object sender, EventArgs e)
        {
            foreach (BL.Verlof verlof1 in VerlofImport)
            {
                string Subject = verlof1.PersoneelsLid.Naam;
                DateTime start = verlof1.Startdatum;
                DateTime einde = DateTime.Now;
                if (verlof1.Einddatum.Hour == 0 && verlof1.Einddatum.Minute == 0)
                {
                     einde = verlof1.Einddatum.AddDays(+1);
                }
                else
                {
                     einde = verlof1.Einddatum;
                }
               
                Appointment apt = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);

                // Set the appointment's time interval to the selected time interval.  
                apt.Start = start;
                apt.End = einde;
                apt.Subject = Subject;
                // TODO: This line of code loads data into the 'dhuyvetbestellingDataSet.Verlof' table. You can move, or remove it, as needed.
                schedulerControl1.DataStorage.Appointments.Add(apt);
            }
            // Create a new appointment.  
          

        }
    }
}