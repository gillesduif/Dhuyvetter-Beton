using BL;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.PrijsLijst
{
    public partial class FrmPompPrijzen : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmPompPrijzen()
        {
            InitializeComponent();
        }

        private void FrmPompPrijzen_Load(object sender, EventArgs e)
        {
            List<PompPrijs> pompprijzen = PompPrijs.KrijgAllePompPrijzen();
            dataGridView1.DataSource = pompprijzen;
            dataGridView1.SelectAll();
        }
    }
}
