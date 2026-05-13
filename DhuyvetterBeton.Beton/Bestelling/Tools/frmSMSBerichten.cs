using BL;
using DevExpress.XtraEditors;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    public partial class frmSMSBerichten : DevExpress.XtraEditors.XtraForm
    {
        FirestoreDb db = FirestoreDb.Create("dbintern-56185");
        public frmSMSBerichten()
        {
            InitializeComponent();
        }

        private void frmSMSBerichten_Load(object sender, EventArgs e)
        {
            Get_Multiple_Documents_From_A_Collection();
        }

        async void Get_Multiple_Documents_From_A_Collection()
        {
            listSMSen.Items.Clear();
            Query Qref = db.Collection("SMSen");
            // .WhereEqualTo("Province","Sindh")
            // .Limit(1)
            // .OrderBy("Population");
            QuerySnapshot snap = await Qref.GetSnapshotAsync();
            List<SMS> smsen = new List<SMS>();
            foreach (DocumentSnapshot docsnap in snap)
            {
                SMS sms = docsnap.ConvertTo<SMS>();
              
                if (docsnap.Exists)
                {
                    sms.id = docsnap.Id.ToString();
                    smsen.Add(sms);
                }
            }
            listSMSen.Items.AddRange(smsen.ToArray());
        }

        private void listSMSen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listSMSen.SelectedItem != null)
            {
                richEditControl1.Text = ((SMS)listSMSen.SelectedItem).bericht;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listSMSen.SelectedItem != null)
            {
                Delete_An_Entire_Document(((SMS)listSMSen.SelectedItem).id);
            }
           
        }

        void Delete_An_Entire_Document(string id)
        {
            DocumentReference docref = db.Collection("SMSen").Document(id);
            docref.DeleteAsync();
            this.Close();
        }
    }
}