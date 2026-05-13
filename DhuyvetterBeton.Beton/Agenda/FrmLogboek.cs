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
    public partial class FrmLogboek : DevExpress.XtraEditors.XtraForm
    {
        string user; 
        public FrmLogboek(string user1)
        {
            user = user1;
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#262626");

            DTP1.Text = DateTime.Today.ToShortDateString();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.1F, FontStyle.Bold);
            if (user != "Jan" && user != "Gilles")
            {
                cboGebruiker.Properties.Items.Clear();
                cboGebruiker.Properties.Items.Add(user);
                int index = 0;
                foreach (string gebruiker in cboGebruiker.Properties.Items)
                {
                    if (user == gebruiker)
                    {
                        cboGebruiker.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
         
            }
        }

        private void ButtonZoek_Click(object sender, EventArgs e)
        {
            if (cboGebruiker.Text == string.Empty && cboGebruiker.Text == string.Empty)
            {
                if (user == "Jan" )
                {
                    List<Logboek> logboekpunten = Logboek.KrijgAlleLogboekenDoorDatum(Convert.ToDateTime(DTP1.EditValue).Date);
                    logboekpunten.Sort((X, Y) => X.DatumEnTijd.CompareTo(Y.DatumEnTijd));
                    dataGridView1.Rows.Clear();
                    foreach (BL.Logboek Logboek in logboekpunten)
                    {
                        dataGridView1.Rows.Add(
                            new object[]
                            {
                            Logboek.ID,
                            Logboek.DatumEnTijd,
                            Logboek.Functie,
                            Logboek.Taak,
                            Logboek.Gebruiker
                     
                            }

                            );
                    }
                  

                

                }
                else if ( user == "Gilles")
                {
                    List<Logboek> logboekpunten = Logboek.KrijgAlleLogboekenDoorDatum(Convert.ToDateTime(DTP1.EditValue).Date);
                    logboekpunten.Sort((X, Y) => X.DatumEnTijd.CompareTo(Y.DatumEnTijd));
                    dataGridView1.Rows.Clear();
                    foreach (BL.Logboek Logboek in logboekpunten)
                    {
                        dataGridView1.Rows.Add(
                            new object[]
                            {
                            Logboek.ID,
                            Logboek.DatumEnTijd,
                            Logboek.Functie,
                            Logboek.Taak,
                            Logboek.Gebruiker

                            }

                            );
                    }

                }
                else
                {
                  MessageBox.Show("Toegang geweigerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else if(cboGebruiker.Text != string.Empty && cboGebruiker.Text == string.Empty)
            {
                if (user == "Jan")
                {
                    List<Logboek> logboekpunten = Logboek.KrijgAlleLogboekenDoorDatumEnFunctie(Convert.ToDateTime(DTP1.EditValue).Date, cboGebruiker.Text);
                    logboekpunten.Sort((X, Y) => X.DatumEnTijd.CompareTo(Y.DatumEnTijd));
                    dataGridView1.Rows.Clear();
                    foreach (BL.Logboek Logboek in logboekpunten)
                    {
                        dataGridView1.Rows.Add(
                            new object[]
                            {
                            Logboek.ID,
                            Logboek.DatumEnTijd,
                            Logboek.Functie,
                            Logboek.Taak,
                            Logboek.Gebruiker

                            }

                            );
                    }

                }
                else if ( user == "Gilles")
                {
                    List<Logboek> logboekpunten = Logboek.KrijgAlleLogboekenDoorDatumEnFunctie(Convert.ToDateTime(DTP1.EditValue).Date, cboGebruiker.Text);
                    logboekpunten.Sort((X, Y) => X.DatumEnTijd.CompareTo(Y.DatumEnTijd));
                    dataGridView1.Rows.Clear();
                    foreach (BL.Logboek Logboek in logboekpunten)
                    {
                        dataGridView1.Rows.Add(
                            new object[]
                            {
                            Logboek.ID,
                            Logboek.DatumEnTijd,
                            Logboek.Functie,
                            Logboek.Taak,
                            Logboek.Gebruiker

                            }

                            );
                    }

                }
                else
                {
                    MessageBox.Show("Toegang geweigerd.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else if (cboGebruiker.Text != string.Empty && cboGebruiker.Text != string.Empty)
            {
                List<Logboek> logboekpunten = Logboek.KrijgAlleLogboekenDoorDatumEnFunctieEnGebruiker(Convert.ToDateTime(DTP1.EditValue).Date, cboGebruiker.Text,cboGebruiker.Text);
                logboekpunten.Sort((X, Y) => X.DatumEnTijd.CompareTo(Y.DatumEnTijd));
                dataGridView1.Rows.Clear();
                foreach (BL.Logboek Logboek in logboekpunten)
                {
                    dataGridView1.Rows.Add(
                        new object[]
                        {
                            Logboek.ID,
                            Logboek.DatumEnTijd,
                            Logboek.Functie,
                            Logboek.Taak,
                            Logboek.Gebruiker

                        }

                        );
                }

     
            }
            else if (cboGebruiker.Text == string.Empty && cboGebruiker.Text != string.Empty)
            {
                List<Logboek> logboekpunten = Logboek.KrijgAlleLogboekenDoorDatumEnGebruiker(Convert.ToDateTime(DTP1.EditValue).Date,  cboGebruiker.Text);
                logboekpunten.Sort((X, Y) => X.DatumEnTijd.CompareTo(Y.DatumEnTijd));
                dataGridView1.Rows.Clear();
                foreach (BL.Logboek Logboek in logboekpunten)
                {
                    dataGridView1.Rows.Add(
                        new object[]
                        {
                            Logboek.ID,
                            Logboek.DatumEnTijd,
                            Logboek.Functie,
                            Logboek.Taak,
                            Logboek.Gebruiker

                        }

                        );
                }

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)

            {

                e.CellStyle.Font = new Font(this.Font, FontStyle.Bold);

            }
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#383838");
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
