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
    public partial class FrmWerfWijzigen : DevExpress.XtraEditors.XtraForm
    {
        FirestoreDb db;
        BL.Bestelling bestelling;
        BL.Werf werf;
        List<Werf> wervenLijst;
        public FrmWerfWijzigen(Werf werf1, BL.Bestelling bestelling1) 
        {
            InitializeComponent();
            werf = werf1;
            bestelling = bestelling1;
            wervenLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(werf.Klant.ID);
            cboWerven.Properties.Items.AddRange(wervenLijst.ToArray());

            int index1 = 0;
            foreach (Werf werf in cboWerven.Properties.Items)
            {
                if (werf.ToString() == bestelling.Werf.ToString())
                {
                    cboWerven.SelectedIndex = index1;
                    txtAdresWerf.Text = werf.Adres;
                    txtTelefoonWerf.Text = werf.Telefoon;
                    cboGemeenteWerf.Text = werf.Gemeente;
                    cboPostcodeWerf.Text = werf.Postcode;
                    break;
                }
                index1++;

            }
            cbonieuwewerfklant.Properties.Items.Add(bestelling.Klant);
            cbonieuwewerfklant.SelectedIndex = 0; 
            cbonieuwewerfklant.Enabled = false;
        }

        private void btnKlantAdres_Click(object sender, EventArgs e)
        {
            if (cbonieuwewerfklant.SelectedItem != null)
            {
                try
                {
                    txtAdresWerfNieuw.Text = bestelling.Klant.Adres;
                    cboPostcodeWerfNieuw.Text = bestelling.Klant.Postcode;
                    cboGemeenteWerfNieuw.Text = bestelling.Klant.Gemeente;
                    txtTelefoonWerfNieuw.Text = bestelling.Klant.Gsm;
                }
                catch
                {
                    XtraMessageBox.Show("Gelieve klant aan te klikken", "Klant niet gevonden");
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTelefoonWerf.Text == string.Empty)
            {
                txtTelefoonWerf.Text = bestelling.Klant.Gsm;
            }
            Werf werf = new Werf(bestelling.Klant, txtAdresWerfNieuw.Text, cboGemeenteWerfNieuw.Text, cboPostcodeWerfNieuw.Text, txtTelefoonWerfNieuw.Text);
            werf.maakNieuweWerf();
            txtAdresWerfNieuw.Text = string.Empty;
            cboGemeenteWerfNieuw.Text = string.Empty;
            cboPostcodeWerfNieuw.Text = string.Empty;
            txtTelefoonWerfNieuw.Text = string.Empty;
           
            Logboek logboek = new Logboek(DateTime.Now, "WERVEN", "[NIEUWE WERF TOEGEVOEGD VIA BESTELLING] Klant: " + werf.Klant.Naam + " Adres: " + werf.Adres + " Gemeente: " + werf.Gemeente + " Postcode: " + werf.Postcode, "");
            logboek.MaakNieuwLogBoekPunt();
            List<Werf> wervenVanKlantLijst = Werf.KrijgAlleWervenVanKlantDoorKlantID(bestelling.Klant.ID);
            cboWerven.Properties.Items.Clear();
            cboWerven.Properties.Items.AddRange(wervenVanKlantLijst.ToArray());
            //    cboWerven.SelectedIndex = cboWerven.FindString(werf.ToString());

            int index1 = 0;
            foreach (Werf werf1 in cboWerven.Properties.Items)
            {
                if (werf.ToString() == werf1.ToString())
                {
                    cboWerven.SelectedIndex = index1;
                    bestelling.Werf = werf1;
                    bestelling.UpdateBestelling();
                    break;
                }
                index1++;

            }
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Werf werfAanpassenSelectie = new Werf();
            werfAanpassenSelectie.ID = ((Werf)cboWerven.SelectedItem).ID;
            werfAanpassenSelectie.Klant = bestelling.Klant;
            werfAanpassenSelectie.Adres = txtAdresWerf.Text;
            werfAanpassenSelectie.Gemeente = cboGemeenteWerf.Text;
            werfAanpassenSelectie.Postcode = cboPostcodeWerf.Text;
            werfAanpassenSelectie.Telefoon = txtTelefoonWerf.Text;
            werfAanpassenSelectie.UpdateWerftGegevens();
            bestelling.Werf = werfAanpassenSelectie;
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
        private void cboWerven_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAdresWerf.Text = ((Werf)cboWerven.SelectedItem).Adres;
            cboGemeenteWerf.Text = ((Werf)cboWerven.SelectedItem).Gemeente;
            cboPostcodeWerf.Text = ((Werf)cboWerven.SelectedItem).Postcode;
            txtTelefoonWerf.Text = ((Werf)cboWerven.SelectedItem).Telefoon;
        }
    }
}