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

namespace DhuyvetterBeton.Beton
{
    public partial class FrmPrijsSetting : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmPrijsSetting()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PrijsSetting prijsSetting = new PrijsSetting();
            prijsSetting.Klant = ((Klant)CboKlanten.SelectedItem);
            if (checkBoxAannemer.Checked == true)
            {
                prijsSetting.Soort = 0;
            }
            else if (checkBoxParticulier.Checked == true)
            {
                prijsSetting.Soort = 1;
            }
            prijsSetting.MaakNieuwePrijsSetting();
            CboKlanten.SelectedItem = null;
            CboKlanten.Text = string.Empty;
            checkBoxAannemer.Checked = false;
            checkBoxParticulier.Checked = false;
        }

        private void FrmPrijsSetting_Load(object sender, EventArgs e)
        {
            List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
            klantenLijst.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            CboKlanten.Items.AddRange(klantenLijst.ToArray());
        }
    }
}
