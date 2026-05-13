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
namespace DhuyvetterBeton.Beton.Agenda
{
    public partial class FrmPersoneelToevoegen : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmPersoneelToevoegen()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BL.Personeel personeel = new BL.Personeel(txtNaam.Text, txtGsm.Text, txtMail.Text);
            personeel.MaakNieuw();
            this.Close();
        }
    }
}
