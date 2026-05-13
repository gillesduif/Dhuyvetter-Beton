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
    public partial class FrmProductWijzigen : DevExpress.XtraEditors.XtraForm
    {
        FirestoreDb db;
        BL.Bestelling bestelling;
        Formule formule;
        List<OmschrijvingProduct> omschrijvingProducts = OmschrijvingProduct.KrijgAlleOmschrijvingen();
        List<Formule> formules = Formule.KrijgAlleFormules();
        string user;
        public FrmProductWijzigen(BL.Bestelling bestelling1, string User1)
        {
            InitializeComponent();
            user = User1;
            formule = bestelling1.Formule;
            bestelling = bestelling1;
            if (user == "Pedro")
            {
                cboProductOmschrijving.Visible = false;
            }
            cboProductOmschrijving.Properties.Items.AddRange(omschrijvingProducts.ToArray());
            cboFormules.Items.AddRange(formules.ToArray());
            cboFormules.SelectedIndex = cboFormules.FindString(bestelling.Formule.Naam);
            int index69 = 0;
            foreach (OmschrijvingProduct omschrijvingProduct in cboProductOmschrijving.Properties.Items)
            {
                if (omschrijvingProduct.Formule == bestelling.Formule.Naam)
                {
                    cboProductOmschrijving.SelectedIndex = index69;
                    break;
                }
                index69++;

            }
            txtM3.Text = bestelling.M3.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bestelling.M3 = Convert.ToDouble(txtM3.Text);
            bestelling.Formule = ((Formule)cboFormules.SelectedItem);
            bestelling.UpdateBestelling();
            #region firebase
            string path = AppDomain.CurrentDomain.BaseDirectory + @"dbintern-56185-firebase-adminsdk-50c46-700d8feb2f.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("dbintern-56185");
            Replace_A_Document(bestelling);
            #endregion
            this.Close();
        }

        private void cboProductOmschrijving_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFormules.SelectedIndex = cboFormules.FindString(((OmschrijvingProduct)cboProductOmschrijving.SelectedItem).Formule);
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
    }
}