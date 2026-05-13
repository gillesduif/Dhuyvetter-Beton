using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BL;

namespace DhuyvetterBeton.Beton.Producten
{
    public partial class ucProductenBeheer : DevExpress.XtraEditors.XtraUserControl
    {
        Formule formule;
        OmschrijvingProduct omschrijving;
        string USER;
        FrmHoofdVenster frmhoofd;
        List<Formule> FormuleList = new List<Formule>();
        string versie;
        List<BenorCategorie> BenorCategories = BL.BenorCategorie.KrijgAlleCategories();

        public ucProductenBeheer(string user, FrmHoofdVenster frmHoofd1, string versie1)
        {
            frmhoofd = frmHoofd1;
            versie = versie1;
            USER = user;
            InitializeComponent();
            cboBenorCategorieToevoegen.Properties.Items.AddRange(BenorCategories.ToArray());
            cboBenorCategorieWijzigen.Properties.Items.AddRange(BenorCategories.ToArray());
            timer1.Start();
            dataGridViewFormule.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridViewFormule.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtProductOmschrijvingToevoegen.Text != string.Empty)
            {
                bool bestaat = false;
                foreach (Formule formuleControle in FormuleList)
                {
                    if (formuleControle.Naam == txtNaamToevoegen.Text)
                    {
                        bestaat = true;
                    }

                }
               if (bestaat != true)
                {
                    Formule formule = new Formule(txtNaamToevoegen.Text, txtSterkteKlasseToevoegen.Text, txtCemmentTypeToevoegen.Text, txtOmgevingsKlasseToevoegen.Text, txtVloeibaarheidToevoegen.Text, txtSamenstellingToevoegen.Text, txtGranuleDiameterToevoegen.Text, Convert.ToBoolean(checkBenorToevoegen.EditValue),((BenorCategorie)cboBenorCategorieToevoegen.SelectedItem),cboMaatEenheidToevoegen.Text, txtProductOmschrijvingToevoegen.Text);
                    formule.maakNieuweFormule();
                    OmschrijvingProduct omschrijvingProduct = new OmschrijvingProduct(txtNaamToevoegen.Text, txtProductOmschrijvingToevoegen.Text);
                    omschrijvingProduct.maakNieuweOmschrijving();
                    Logboek logboek = new Logboek(DateTime.Now, "PRODUCTEN", "[NIEUWE PRODUCT TOEGEVOEGD] Formule: " + formule.Naam + " Product: " + formule.Omschrijving, USER);
                    logboek.MaakNieuwLogBoekPunt();
                    BL.PrijsLijst prijs = new BL.PrijsLijst();
                    prijs.Formule = txtNaamToevoegen.Text;
                    prijs.Aannemer = Convert.ToDouble(txtAannemerPrijsNieuw.Text);
                    prijs.Particulier = Convert.ToDouble(txtParticulierPrijsNieuw.Text);
                    prijs.Toevoegen();
                    txtNaamToevoegen.Text = string.Empty;
                    txtSterkteKlasseToevoegen.Text = string.Empty;
                    txtCemmentTypeToevoegen.Text = string.Empty;
                    txtOmgevingsKlasseToevoegen.Text = string.Empty;
                    txtVloeibaarheidToevoegen.Text = string.Empty;
                    txtSamenstellingToevoegen.Text = string.Empty;
                    txtGranuleDiameterToevoegen.Text = string.Empty;
                    txtProductOmschrijvingToevoegen.Text = string.Empty;
                    txtAannemerPrijsNieuw.Text = string.Empty;
                    txtParticulierPrijsNieuw.Text = string.Empty;
                }
               else
                {
                    XtraMessageBox.Show("Product bestaat al.", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else { XtraMessageBox.Show("Product omschrijving vergeten.","",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if(txtNaamWijzigen.Text.Contains("aanvoer")|| txtNaamWijzigen.Text.Contains("afvoer"))
            {
                BenorCategorie benorCategorie = new BenorCategorie(1, " ");
                Formule formule1 = new Formule(formule.ID, txtNaamWijzigen.Text, txtSterkteKlasseWijzigen.Text, txtCemmentTypeWijzigen.Text, txtOmgevingsKlasseWijzigen.Text, txtVloeibaarheidWijzigen.Text, txtSamenstellingWijzigen.Text, txtGranuleDiameterWijzigen.Text,Convert.ToBoolean(checkBenorWijzigen.EditValue), benorCategorie, cboMaatEenheidWijzigen.Text, txtProductOmschrijvingWijzigen.Text);
                formule1.updateFormuleAA();

                BL.PrijsLijst prijs = new BL.PrijsLijst();
                prijs.ID = Convert.ToInt32(labelPrijsID.Text);
                prijs.Formule = txtNaamWijzigen.Text;
                prijs.Aannemer = Convert.ToDouble(txtAannemerPrijsWijzigen.Text);
                prijs.Particulier = Convert.ToDouble(txtParticulierPrijsWijzigen.Text);
                if (prijs.ID == 0)
                {
                    prijs.Toevoegen();
                }
                else
                {
                    prijs.Aanpassen();
                }
            }
            else
            {
                Formule formule1 = new Formule(formule.ID, txtNaamWijzigen.Text, txtSterkteKlasseWijzigen.Text, txtCemmentTypeWijzigen.Text, txtOmgevingsKlasseWijzigen.Text, txtVloeibaarheidWijzigen.Text, txtSamenstellingWijzigen.Text, txtGranuleDiameterWijzigen.Text, Convert.ToBoolean(checkBenorWijzigen.EditValue),((BenorCategorie)cboBenorCategorieWijzigen.SelectedItem),cboMaatEenheidWijzigen.Text, txtProductOmschrijvingWijzigen.Text);
                OmschrijvingProduct omschrijvingProduct = new OmschrijvingProduct(omschrijving.ID,txtNaamWijzigen.Text, txtProductOmschrijvingWijzigen.Text);
                BL.PrijsLijst prijs = new BL.PrijsLijst();
                prijs.ID = Convert.ToInt32(labelPrijsID.Text);
                prijs.Formule = txtNaamWijzigen.Text;
                prijs.Aannemer = Convert.ToDouble(txtAannemerPrijsWijzigen.Text);
                prijs.Particulier = Convert.ToDouble(txtParticulierPrijsWijzigen.Text);
                if (prijs.ID == 0)
                {
                    prijs.Toevoegen();
                }else
                {
                    prijs.Aanpassen();
                }
                
                formule1.updateFormule();
                omschrijvingProduct.Wijzigen();
                XtraMessageBox.Show("Het product is succesvol aangepast.", "Product wijzigen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormuleList = Formule.KrijgAlleFormulesBA();
    
            FormuleList.Sort((X, Y) => X.Naam.CompareTo(Y.Naam));
            foreach (Formule Formule in FormuleList)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,
                        Formule.OmgevingsKlasse,
                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType,
                         Formule.IsBenor,
                         Formule.BenorCategorie,
                         Formule.MaatEenheid
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount;
            vScrollBar1.Maximum = max;
            //listboxResults.Items.AddRange(FormuleList.ToArray());
            timer1.Stop();
        }

        private void dataGridViewFormule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewFormule.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewFormule.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewFormule.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewFormule.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }
        private void Vulgegevens()
        {
            txtNaamWijzigen.Text = formule.Naam; 
             omschrijving = OmschrijvingProduct.KrijgOmschrijvingenViaFormule(formule.Naam);
            txtOmgevingsKlasseWijzigen.Text = formule.OmgevingsKlasse;
            txtSamenstellingWijzigen.Text = formule.Samenstelling;
            txtVloeibaarheidWijzigen.Text = formule.Vloeibaarheid;
            txtSterkteKlasseWijzigen.Text = formule.SterkteKlasse;
            txtGranuleDiameterWijzigen.Text = formule.GranuleDiameter;
            txtCemmentTypeWijzigen.Text = formule.CemmentType;
            txtProductOmschrijvingWijzigen.Text = formule.Omschrijving;
            checkBenorWijzigen.EditValue = formule.IsBenor;
            BL.PrijsLijst prijs = BL.PrijsLijst.KrijgPrijsDoorFormuleNaam(formule.Naam);
            labelPrijsID.Text = prijs.ID.ToString();
            txtParticulierPrijsWijzigen.Text = prijs.Particulier.ToString();
            txtAannemerPrijsWijzigen.Text = prijs.Aannemer.ToString();
            cboMaatEenheidWijzigen.Text = formule.MaatEenheid;
            int index = 0;
            try
            {
                foreach (BenorCategorie BenorCategorie in cboBenorCategorieWijzigen.Properties.Items)
                {
                    if (BenorCategorie.ToString() == formule.BenorCategorie.ToString())
                    {
                        cboBenorCategorieWijzigen.SelectedIndex = index;
                        break;
                    }
                    index++;

                }
            }
          catch { }
        }
        private void dataGridViewFormule_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void listboxResults_Click(object sender, EventArgs e)
        {
       
        }

        private void cboCementtype_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void cboDruksterkte_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cboDmax_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cboMilieuKlasse_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void cboConsistentie_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue > -1 && e.NewValue < dataGridViewFormule.Rows.Count)
            {
                dataGridViewFormule.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
        }

        private void dataGridViewFormule_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = dataGridViewFormule.FirstDisplayedScrollingRowIndex;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucHoofdvenster ucHoofdvenster = new ucHoofdvenster(USER, versie, null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Formule AAformule = new Formule(txtAanvoerAfvoer.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,false,null,string.Empty, txtOmschrijvingAanvoerAfvoer.Text);
            AAformule.maakNieuweAAFormule();
            txtAanvoerAfvoer.Text = string.Empty;
            txtOmschrijvingAanvoerAfvoer.Text = string.Empty;
            XtraMessageBox.Show("Aanvoer/Afvoer formule is correct toegevoegd.", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            foreach (Formule Formule in FormuleList)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach(Formule formule in FormuleList)
            {
                try
                {
                    char f = formule.Naam[0];
                    if (f == 'G')
                    {
                        FormuleFilter.Add(formule);
                    }
                }
                catch { }
               
                //selectie 0/2 
                //String G2 + txtboxcement.text = 100
                ///G2100
                //m3 10 
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount /2;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach (Formule formule in FormuleList)
            {
                try
                {
                    char f = formule.Naam[0];
                    if (f == 'D')
                    {
                        FormuleFilter.Add(formule);
                    }
                }
                catch { }
              
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount / 2;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach (Formule formule in FormuleList)
            {
                try
                {
                    char f1 = formule.Naam[0];
                    char f2 = formule.Naam[1];
                    char f3 = formule.Naam[2];
                    if (f1 == 'B' && f2 == 'R' && f3 == 'Z')
                    {
                        FormuleFilter.Add(formule);
                    }
                }catch { }
              
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount / 2;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach (Formule formule in FormuleList)
            {
               
                if (formule.Naam.Length == 7  && formule.GranuleDiameter.Contains("min"))
                {
                    FormuleFilter.Add(formule);
                }
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,
                        Formule.OmgevingsKlasse,
                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                        Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount / 2;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach (Formule formule in FormuleList)
            {
               
                if (formule.Naam.Contains("aanvoer"))
                {
                    FormuleFilter.Add(formule);
                }
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount / 2;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach (Formule formule in FormuleList)
            {

                if (formule.Naam.Contains("afvoer"))
                {
                    FormuleFilter.Add(formule);
                }
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount / 2;
            vScrollBar1.Maximum = max;
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            dataGridViewFormule.Rows.Clear();
            List<Formule> FormuleFilter = new List<Formule>();
            foreach (Formule formule in FormuleList)
            {
                try
                {
                    char f = formule.Naam[0];
                    if (f == 'P')
                    {
                        FormuleFilter.Add(formule);
                    }
                }
                catch
                {

                }
           
            }
            foreach (Formule Formule in FormuleFilter)
            {
                dataGridViewFormule.Rows.Add(
                    new object[]
                    {
                        Formule.ID,
                        Formule.Naam,
                        Formule.SterkteKlasse,

                        Formule.OmgevingsKlasse,

                        Formule.Vloeibaarheid,
                        Formule.Samenstelling,
                        Formule.GranuleDiameter,
                         Formule.CemmentType
                    }

                    );
            }
            vScrollBar1.Minimum = 0;
            int max = dataGridViewFormule.RowCount / 2;
            vScrollBar1.Maximum = max;
        }

        private void ucProductenBeheer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewFormule_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.AppStarting;
                DataGridViewSelectedCellCollection DGV = this.dataGridViewFormule.SelectedCells;
                formule = new Formule();
                if (DGV[1].Value.ToString().Contains("aanvoer") || DGV[1].Value.ToString().Contains("afvoer"))
                {
                    formule = Formule.KrijgFormuleAADoorID(Convert.ToInt32(DGV[0].Value));
                }
                else
                {
                    formule = Formule.KrijgFormuleDoorID(Convert.ToInt32(DGV[0].Value));
                }
                
                Vulgegevens();
            }
       
            catch 
            {
         
            }
        }

        private void groupControl7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
