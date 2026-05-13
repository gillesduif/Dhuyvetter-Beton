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

namespace DhuyvetterBeton.Beton.Agenda
{
    public partial class FrmVerlofAgenda : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmVerlofAgenda()
        {
            InitializeComponent();
         
         
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            paneelOverzicht.Visible = true;
            paneelAanvraag.Visible = false;
            paneelAanpassen.Visible = false;
            //    dateTimePicker3.CustomFormat = "MMMM /MM/yyyy";
        }

        private void FrmVerlofAgenda_Load(object sender, EventArgs e)
        {
            List<BL.Personeel> personeelLijst = BL.Personeel.KrijgAllePersoneelLeden();
            personeelLijst.Sort((x, y) => x.Naam.CompareTo(y.Naam));
            cboPersoneel.Items.AddRange(personeelLijst.ToArray());
            cboPersoneelAanpassen.Items.AddRange(personeelLijst.ToArray());
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dtpAanpassenMaand.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MMMM yyyy";
            dtpAanpassenMaand.CustomFormat = "MMMM yyyy";
            dateTimePicker3.ShowUpDown = true;
            
            dtpAanpassenMaand.ShowUpDown = true;
            List<Verlof> verlofLijst = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(dateTimePicker3.Value);
            verlofLijst.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            dataGridView1.DataSource = verlofLijst;
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            paneelOverzicht.Visible = false;
            paneelAanvraag.Visible = true;
            paneelAanpassen.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Verlof verlof = new Verlof(((BL.Personeel)cboPersoneel.SelectedItem),DateStart.Value,DateEinde.Value);
            verlof.Nieuw();
            cboPersoneel.Text = string.Empty;
            DateStart.Value = DateTime.Today;
            DateEinde.Value = DateTime.Today;
            List<Verlof> verlofLijstRefresh = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(dateTimePicker3.Value);
            verlofLijstRefresh.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = verlofLijstRefresh;
        }

        private void cboPersoneel_DropDown(object sender, EventArgs e)
        {

        }

        private void cboPersoneel_KeyDown(object sender, KeyEventArgs e)
        {
            cboPersoneel.DroppedDown = true;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            List<Verlof> verlofLijst = Verlof.KrijgAlleVerlofDagenDoorDatumMaand(dateTimePicker3.Value);
            verlofLijst.Sort((X, Y) => X.Startdatum.CompareTo(Y.Startdatum));
            dataGridView1.DataSource = verlofLijst;
        }

        private void dtpAanpassenMaand_ValueChanged(object sender, EventArgs e)
        {
            if (cboPersoneelAanpassen.SelectedItem == null)
            {
                MessageBox.Show("Gelieve Personeels lid aan te duiden", "Geen persoon gevonden.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBoxAanpassen.Items.Clear();
                List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(dtpAanpassenMaand.Value, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
                listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());
            }
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            paneelOverzicht.Visible = false;
            paneelAanvraag.Visible = false;
            paneelAanpassen.Visible = true;
        }

        private void listBoxAanpassen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxAanpassen.SelectedItem != null)
            {
                dtpStartDatumWijzigen.Value = ((Verlof)listBoxAanpassen.SelectedItem).Startdatum;
                dtpEindDatumWijzigen.Value = ((Verlof)listBoxAanpassen.SelectedItem).Einddatum;
            }
        }

        private void simpleButtonWijzigen_Click(object sender, EventArgs e)
        {
            Verlof verlof = new Verlof(((Verlof)listBoxAanpassen.SelectedItem).ID, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem), dtpStartDatumWijzigen.Value, dtpEindDatumWijzigen.Value);
            verlof.Wijzigen();
            listBoxAanpassen.Items.Clear();
            List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(dtpAanpassenMaand.Value, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
            listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Verlof verlof = ((Verlof)listBoxAanpassen.SelectedItem);
            verlof.Verwijderen();
            listBoxAanpassen.Items.Clear();
            List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(dtpAanpassenMaand.Value, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
            listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());
        }

        private void cboPersoneelAanpassen_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAanpassen.Items.Clear();
            List<Verlof> verlofdagenVanPersoneel = Verlof.KrijgAlleVerlofDagenDoorDatumEnPersoneelID(dtpAanpassenMaand.Value, ((BL.Personeel)cboPersoneelAanpassen.SelectedItem).ID);
            listBoxAanpassen.Items.AddRange(verlofdagenVanPersoneel.ToArray());
        }
    }
}
