using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
namespace DhuyvetterBeton.Beton.Werven
{
    public partial class FrmNieuweWerfPrefab : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        string User;
        public FrmNieuweWerfPrefab(string user)
        {
            InitializeComponent();
            User = user;
            timer1.Start();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            WerfPrefab werfPrefab = new WerfPrefab(((KlantPrefab)cboKlanten.SelectedItem), txtAdres.Text, CboGemeente.Text, cboPostcode.Text, ((ContactPersoonPrefab)cboContactPersoon.SelectedItem));
            werfPrefab.MaakNieuweWerf();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<KlantPrefab> prefabKlanten = KlantPrefab.KrijgAllePrefabKlanten();
            cboKlanten.Items.AddRange(prefabKlanten.ToArray());
            List<PostcodeGemeente> gemeentelijst = PostcodeGemeente.KrijgAllePostcodeGemeentes();
            foreach (PostcodeGemeente postcodeGemeente in gemeentelijst)
            {
                CboGemeente.Items.Add(postcodeGemeente);
            }
            foreach (PostcodeGemeente posstcodeLijst in gemeentelijst)
            {
                cboPostcode.Items.Add(posstcodeLijst.ToStringPostcode());
            }
            timer1.Stop();
        }

        private void cboKlanten_KeyDown(object sender, KeyEventArgs e)
        {
            cboKlanten.DroppedDown = true;
        }

        private void CboGemeente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPostcode.Text = ((PostcodeGemeente)CboGemeente.SelectedItem).Postcode.ToString();
        }

        private void cboPostcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboContactPersoon_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboContactPersoon.Items.Clear();
            List<ContactPersoonPrefab> contactpersonen = ContactPersoonPrefab.KrijgAlleContactpersonenVanPrefabKlantViaID(((KlantPrefab)cboKlanten.SelectedItem).ID);
            cboContactPersoon.Items.AddRange(contactpersonen.ToArray());
        }

        private void CboGemeente_KeyDown(object sender, KeyEventArgs e)
        {
            CboGemeente.DroppedDown = true;
        }

        private void cboPostcode_KeyDown(object sender, KeyEventArgs e)
        {
            cboPostcode.DroppedDown = true;
        }

        private void cboContactPersoon_KeyDown(object sender, KeyEventArgs e)
        {
            cboContactPersoon.DroppedDown = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (cboKlanten.SelectedItem != null)
            {
                ContactPersoonPrefab contactPersoonPrefab = new ContactPersoonPrefab(txtNaam.Text, txtVoornaam.Text, txtTelefoon.Text, txtGSM.Text, ((KlantPrefab)cboKlanten.SelectedItem));
                contactPersoonPrefab.MaakNieuwContactPersoon();
                cboContactPersoon.Items.Clear();
                List<ContactPersoonPrefab> contactpersonen = ContactPersoonPrefab.KrijgAlleContactpersonenVanPrefabKlantViaID(((KlantPrefab)cboKlanten.SelectedItem).ID);
                cboContactPersoon.Items.AddRange(contactpersonen.ToArray());
            }
      else
            {
                MessageBox.Show("Selecteer Prefab klant.","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
