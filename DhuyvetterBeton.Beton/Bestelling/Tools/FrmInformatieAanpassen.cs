using DevExpress.XtraEditors;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    public partial class FrmInformatieAanpassen : DevExpress.XtraEditors.XtraForm
    {
        FirestoreDb db;
        BL.Bestelling bestelling;
        public FrmInformatieAanpassen(BL.Bestelling bestelling1)
        {
            InitializeComponent();
            bestelling = bestelling1;
            labelUUR.Text = bestelling.Datum.ToShortTimeString();
            dtpDatum.EditValue = bestelling.Datum;
            cboLoswijze.Text = bestelling.Loswijze;
            txtLeveringWijze.Text = bestelling.LeveringWijze;
            txtComment.Text = bestelling.Comment;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bestelling.Datum = Convert.ToDateTime(dtpDatum.EditValue);
            bestelling.Loswijze = cboLoswijze.Text;
            bestelling.LeveringWijze = txtLeveringWijze.Text;
            bestelling.Comment = txtComment.Text;
            bestelling.UpdateBestelling();

            #region firebase
            string path = AppDomain.CurrentDomain.BaseDirectory + @"dbintern-56185-firebase-adminsdk-50c46-700d8feb2f.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("dbintern-56185");
            Replace_A_Document(bestelling);
            #endregion


            this.Close();
        }
        async void Replace_A_Document(BL.Bestelling bestelling)
        {
            DateTime datum = bestelling.Datum.AddHours(-1);
            int unixTimestamp = (int)datum.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            DocumentReference docref = db.Collection("Bestellingen").Document(bestelling.ID.ToString());
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"klant", bestelling.Klant.Naam},
                {"werf",bestelling.Werf.ToString()},
                {"datum",unixTimestamp },
                {"aantal",bestelling.M3.ToString()},
                {"product",bestelling.Formule.Naam},
                {"pomp",bestelling.Pomp.PompLeverancier},
                {"leveringMethode",bestelling.LeveringWijze },
                {"losMethode",bestelling.Loswijze},
                {"opmerking",bestelling.Comment }
            };

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.SetAsync(data);
            }
        }
        private void dtpDatum_EditValueChanged(object sender, EventArgs e)
        {
            string minuten = string.Empty;
            if (Convert.ToDateTime(dtpDatum.EditValue).Hour == 0 && Convert.ToDateTime(dtpDatum.EditValue).Minute == 0)
            {
                minuten = "?";
            }
            else
            {
                if (Convert.ToDateTime(dtpDatum.EditValue).Minute.ToString() == "0")
                {
                    minuten = "00";
                }
                else
                {
                    minuten = Convert.ToDateTime(dtpDatum.EditValue).Minute.ToString();
                }
                labelUUR.Text = Convert.ToDateTime(dtpDatum.EditValue).Hour.ToString() + ":" + minuten;
            }
        }
    }
}