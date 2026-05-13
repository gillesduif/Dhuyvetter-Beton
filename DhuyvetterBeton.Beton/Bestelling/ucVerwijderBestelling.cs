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
using DhuyvetterBeton.Beton.Agenda;

namespace DhuyvetterBeton.Beton.Bestelling
{
    public partial class ucVerwijderBestelling : DevExpress.XtraEditors.XtraUserControl
    {
  
        string versie;
        string USER;
        FrmHoofdVenster frmhoofd;
        public ucVerwijderBestelling(string User, FrmHoofdVenster frmHoofd1,string versie1)
        {
            versie = versie1;
            USER = User;
            frmhoofd = frmHoofd1;
            InitializeComponent();
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");
            dataGridViewBestellingen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            calendarControl1.DateTime = DateTime.Today;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (dataGridViewBestellingen.SelectedCells.Count == 13)
            {
                var message = "Bent u zeker dat u deze bestelling wilt verwijderen?";
                var title = "Keuze - verwijderen bestelling";
                var result = XtraMessageBox.Show(
                    message,                  // the message to show
                    title,                    // the title for the dialog box
                    MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                    MessageBoxIcon.Question); // show a question mark icon

                // the following can be handled as if/else statements as well
                switch (result)
                {
                    case DialogResult.Yes:

                        DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
                        BL.Bestelling bestelling = new BL.Bestelling();
                        bestelling.ID = Convert.ToInt32(DGV[0].Value);
                        bestelling.Klant = (Klant)DGV[1].Value;
                        bestelling.Werf = (Werf)DGV[2].Value;
                        bestelling.Formule = ((Formule)DGV[3].Value);
                        bestelling.Pomp = ((Pomp)DGV[4].Value);
                        bestelling.Giek = DGV[5].Value.ToString();
                        bestelling.M3 = Convert.ToDouble(DGV[6].Value);
                        bestelling.Besteldatum = Convert.ToDateTime(DGV[7].Value);
                        bestelling.Datum = Convert.ToDateTime(DGV[8].Value);
                        bestelling.Levering = Convert.ToInt32(DGV[9].Value);
                        bestelling.LeveringWijze = DGV[10].Value.ToString();
                        bestelling.Loswijze = DGV[11].Value.ToString();
                        bestelling.Comment = DGV[12].Value.ToString();
                     
                        int bestellingID = bestelling.ID;
                        try
                        {
                            AgendaLeveringen agendapunt = AgendaLeveringen.KrijgAgendapuntDoorBestellingID(bestellingID);
                            
                            if (agendapunt != null && DateTime.Today.Date == agendapunt.Datum.Date)
                            {
                                XtraMessageBox.Show("Gelieve eerst het agendapunt in de centrale te verwijderen.", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                //Hulpstof hulpstof = (((Hulpstof)DGV[10].Value));
                                //string hulpstofHoeveelheid = Convert.ToString(DGV[11].Value);
                            }
                            else
                            {
                                bestelling.VerwijderBestelling();
                                var message1 = "Wilt u nog een bestelling verwijderen?";
                                var title1 = "Keuze - opnieuw verwijderen bestelling";
                                var result1 = XtraMessageBox.Show(
                                    message1,                  // the message to show
                                    title1,                    // the title for the dialog box
                                    MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                                    MessageBoxIcon.Question); // show a question mark icon

                                // the following can be handled as if/else statements as well
                                switch (result1)
                                {
                                    case DialogResult.Yes:
                                        Int32 selectedRowCount = dataGridViewBestellingen.Rows.GetRowCount(DataGridViewElementStates.Selected);
                                        if (selectedRowCount > 0)
                                        {
                                            for (int i = 0; i < selectedRowCount; i++)
                                            {
                                                dataGridViewBestellingen.Rows.RemoveAt(dataGridViewBestellingen.SelectedRows[0].Index);
                                            }
                                        }


                                        break;
                                    case DialogResult.No:    // No button pressed
                                        frmhoofd.container.Controls.Clear();
                                        ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER, versie,null);

                                        if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
                                        {

                                            frmhoofd.container.Controls.Add(ucHoofdvenster);

                                        }

                                        break;
                                }
                            }
                        }
                        catch
                        {
                            bestelling.VerwijderBestelling();
                            var message1 = "Wilt u nog een bestelling verwijderen?";
                            var title1 = "Keuze - opnieuw verwijderen bestelling";
                            var result1 = XtraMessageBox.Show(
                                message1,                  // the message to show
                                title1,                    // the title for the dialog box
                                MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                                MessageBoxIcon.Question); // show a question mark icon

                            // the following can be handled as if/else statements as well
                            switch (result1)
                            {
                                case DialogResult.Yes:
                                    Int32 selectedRowCount = dataGridViewBestellingen.Rows.GetRowCount(DataGridViewElementStates.Selected);
                                    if (selectedRowCount > 0)
                                    {
                                        for (int i = 0; i < selectedRowCount; i++)
                                        {
                                            dataGridViewBestellingen.Rows.RemoveAt(dataGridViewBestellingen.SelectedRows[0].Index);
                                        }
                                    }


                                    break;
                                case DialogResult.No:    // No button pressed
                                    frmhoofd.container.Controls.Clear();
                                    ucHoofdvenster ucHoofdvenster = new ucHoofdvenster(USER, versie,null);

                                    if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
                                    {

                                        frmhoofd.container.Controls.Add(ucHoofdvenster);

                                    }

                                    break;
                            }
                        }
                      
                        
                    
                        break;
                    case DialogResult.No:    // No button pressed

                        break;
                }
            }
        }

        private void dataGridViewBestellingen_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewBestellingen_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBestellingen.SelectedCells.Count == 13)
            {
                int index = dataGridViewBestellingen.SelectedRows[0].Index;
                if (dataGridViewBestellingen.Rows[index].DefaultCellStyle.BackColor == Color.GreenYellow)
                {
                    simpleButton1.Enabled = false;
                }
                else
                {
                    simpleButton1.Enabled = true;
                }
                DataGridViewSelectedCellCollection DGV = this.dataGridViewBestellingen.SelectedCells;
            
          
                Klant klant = ((Klant)DGV[1].Value);
                labelKlant.Text = klant.Naam;
                labelGSM.Text = klant.Gsm;
                labelTelefoon.Text = klant.Telefoon;
                labelWerf.Text = DGV[2].Value.ToString();
                labelFormule.Text = DGV[3].Value.ToString();
                if (labelFormule.Text == "10 Teelaar" || labelFormule.Text == "13 Spuitza" || labelFormule.Text == "14 Bakstee" || labelFormule.Text == "3 Breekza" || labelFormule.Text == "4 0/2 Zand" || labelFormule.Text == "5 0/5 Zand" || labelFormule.Text == "6 0/7 Zand" || labelFormule.Text == "7 2/6 Gr" || labelFormule.Text == "8 6/14 Gr" || labelFormule.Text == "9 3/10" || labelFormule.Text == "betonzand" || labelFormule.Text == "zeezand" || labelFormule.Text == "2" || labelFormule.Text == "pousse")
                {
                    lblHoeveelHeidIndicatie.Text = "Ton:";
                }
                else if (labelFormule.Text == "Mortel")
                {
                    lblHoeveelHeidIndicatie.Text = "Liter:";

                }
                else if (labelFormule.Text == "betonblokken")
                {
                    lblHoeveelHeidIndicatie.Text = "Stuks:";
                }
                else
                {
                    lblHoeveelHeidIndicatie.Text = "M³:";
                }
                labelPomp.Text = DGV[4].Value.ToString();
                labelGiek.Text = DGV[5].Value.ToString();
                labelM3.Text = DGV[6].Value.ToString();
                DateTime datumTijd = Convert.ToDateTime(DGV[8].Value);
                labelDatumTijd.Text = datumTijd.ToShortDateString() + " - " + datumTijd.ToShortTimeString();
                labelLeveringWijze.Text = Convert.ToString(DGV[10].Value);
                labelLoswijze.Text = Convert.ToString(DGV[11].Value);
                labelOpmerking.Text = Convert.ToString(DGV[12].Value);
                Listboxhulpstoffen.Items.Clear();

                List<Hulpstof> hulpstoffenList = Hulpstof.KrijgAlleHulpstoffenDoorBestellingID(Convert.ToInt32(DGV[0].Value));
                Listboxhulpstoffen.Items.AddRange(hulpstoffenList.ToArray());
                if (Listboxhulpstoffen.Items.Count > 0)
                {
                    panel1.Visible = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }
        }

        private void ucVerwijderBestelling_Load(object sender, EventArgs e)
        {
            //timer1.Start();

        }

        private void groupControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewBestellingen_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridViewBestellingen.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridViewBestellingen.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridViewBestellingen.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            if (e.ColumnIndex == 0)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.White;

            }
            if (e.ColumnIndex == 7)

            {

                e.CellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // timer1.Stop();
            Cursor.Current = Cursors.WaitCursor;
            List<BL.Bestelling> BestellingenOphalen = BL.Bestelling.KrijgBestellingenDoorDatum(Convert.ToDateTime(calendarControl1.EditValue).Date);

            BestellingenOphalen.Sort((x, y) => x.Datum.CompareTo(y.Datum));
            List<Klant> klantenLijst = Klant.KrijgAlleKlanten();
            cboklanten.Properties.Items.AddRange(klantenLijst.ToArray());

            foreach (BL.Bestelling bestelling in BestellingenOphalen)
            {
                dataGridViewBestellingen.Rows.Add(
                    new object[]
                    {
                        bestelling.ID,
                        bestelling.Klant,
                        bestelling.Werf,
                        bestelling.Formule,
                        bestelling.Pomp,
                        bestelling.Giek,
                        bestelling.M3,
                        bestelling.Besteldatum,
                        bestelling.Datum,
                        bestelling.Levering,
                        bestelling.LeveringWijze,
                        bestelling.Loswijze,
                        bestelling.Comment
                    }

                    );
            }
          //  timer1.Stop();
        }

        private void calendarControl1_EditValueChanged(object sender, EventArgs e)
        {
            dataGridViewBestellingen.Rows.Clear();

            Cursor.Current = Cursors.AppStarting;
            List<BL.Bestelling> bestellingen = BL.Bestelling.KrijgBestellingenDoorDatum(calendarControl1.SelectionStart.Date);
            
            bestellingen.Sort((X, Y) => X.Datum.CompareTo(Y.Datum));
         
            foreach (BL.Bestelling bestelling1 in bestellingen)
            {
                dataGridViewBestellingen.Rows.Add(
                    new object[]
                    {
                        bestelling1.ID,
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Datum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                    }

                    );
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmhoofd.container.Controls.Clear();
            ucAgendaBeton ucHoofdvenster = new ucAgendaBeton(USER, versie,null);

            if (!frmhoofd.container.Controls.Contains(ucHoofdvenster))
            {

                frmhoofd.container.Controls.Add(ucHoofdvenster);

            }

        }

        private void ucVerwijderBestelling_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnInladen_Click(object sender, EventArgs e)
        {
            if (cboklanten.SelectedItem != null)
            {
                dataGridViewBestellingen.Rows.Clear();
                List<BL.Bestelling> bestellingenVanKlant = BL.Bestelling.KrijgBestellingenDoorKlantID(((Klant)cboklanten.SelectedItem).ID);
                foreach (BL.Bestelling bestelling1 in bestellingenVanKlant)
                {
                    dataGridViewBestellingen.Rows.Add(
                        new object[]
                        {
                        bestelling1.ID,
                        bestelling1.Klant,
                        bestelling1.Werf,
                        bestelling1.Formule,
                        bestelling1.Pomp,
                        bestelling1.Giek,
                        bestelling1.M3,
                        bestelling1.Besteldatum,
                        bestelling1.Datum,
                        bestelling1.Levering,
                        bestelling1.LeveringWijze,
                        bestelling1.Loswijze,
                        bestelling1.Comment
                        }

                        );
                }
            }
        }

        private void ucVerwijderBestelling_DoubleClick(object sender, EventArgs e)
        {
            cboklanten.Visible = true;
            labelKlantDelete.Visible = true;
            btnInladen.Visible = true;
        }

        private void groupControl4_DoubleClick(object sender, EventArgs e)
        {
            cboklanten.Visible = true;
            labelKlantDelete.Visible = true;
            btnInladen.Visible = true;
        }
    }
}
