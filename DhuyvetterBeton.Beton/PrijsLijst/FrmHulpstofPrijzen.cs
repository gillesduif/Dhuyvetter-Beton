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
    public partial class FrmHulpstofPrijzen : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmHulpstofPrijzen()
        {
            InitializeComponent();
        }

        private void FrmHulpstofPrijzen_Load(object sender, EventArgs e)
        {
            List<HulpstofPrijs> hulpstofPrijzen = HulpstofPrijs.KrijgAllePrijzenHulpstof();
            dataGridView1.DataSource = hulpstofPrijzen;
        }
    }
}
