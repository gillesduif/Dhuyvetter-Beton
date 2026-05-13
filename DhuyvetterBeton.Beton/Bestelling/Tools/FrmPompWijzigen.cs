using BL;
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
    public partial class FrmPompWijzigen : DevExpress.XtraEditors.XtraForm
    {
        FirestoreDb db;
        BL.Bestelling bestelling;
        List<Pomp> pompen = Pomp.KrijgAllePompen();
        public FrmPompWijzigen(BL.Bestelling bestelling1)
        {
            InitializeComponent();
            bestelling = bestelling1;
            cboPompen.Properties.Items.AddRange(pompen.ToArray());

            int index5 = 0;
            foreach (Pomp pomp in cboPompen.Properties.Items)
            {
                if (pomp.ToString() == bestelling.Pomp.ToString())
                {
                    cboPompen.SelectedIndex = index5;
                    break;
                }
                index5++;

            }
            cboGiek.Text = bestelling.Giek;
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bestelling.Pomp = ((Pomp)cboPompen.SelectedItem);
            bestelling.Giek = cboGiek.Text;
            bestelling.UpdateBestelling();
            #region firebase
            string path = AppDomain.CurrentDomain.BaseDirectory + @"dbintern-56185-firebase-adminsdk-50c46-700d8feb2f.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("dbintern-56185");
            Replace_A_Document(bestelling);
            #endregion
            this.Close();
        }
    }
}