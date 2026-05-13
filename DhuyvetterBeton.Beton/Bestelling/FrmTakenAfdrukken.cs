using BL;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DhuyvetterBeton.Beton.Bestelling
{
    public partial class FrmTakenAfdrukken : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        List<AfdrukWachtRij> afdrukLijst = AfdrukWachtRij.KrijgAlleOpdrachten();
        public FrmTakenAfdrukken()
        {
            InitializeComponent();
            listBoxAfdrukken.Items.Clear();

           
            listBoxAfdrukken.Items.AddRange(afdrukLijst.ToArray());
            timer1.Start();
        }

        private void listBoxAfdrukken_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAfdrukken_Click(object sender, EventArgs e)
        {
         
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBoxAfdrukken.Items.Clear();
            afdrukLijst = AfdrukWachtRij.KrijgAlleOpdrachten();
            listBoxAfdrukken.Items.AddRange(afdrukLijst.ToArray());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AfdrukWachtRij afdrukitemerror = new AfdrukWachtRij();
            try
            {
                foreach (AfdrukWachtRij afdrukitem in afdrukLijst)
                {
                    int bestelID = afdrukitem.BestelID;
                    afdrukitemerror = afdrukitem;
                    BL.Bestelling bestelling = BL.Bestelling.KrijgBestellingenDoorID(bestelID);
                    bestelling.GeneerExcellRec(false, "", "Pedro");


                    string bestandsNaam = bestelling.Klant.Naam + " " + bestelling.Datum.Hour.ToString() + "u" + bestelling.Datum.Minute.ToString();

                    new FileInfo(@"Z:\Bestellingen\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();
                    if (bestelling.Pomp.PompLeverancier == "D'huyvetter beton")
                    {

                        bestelling.GeneerPompExcell(true);
                        new FileInfo(@"Z:\PompFiches\" + bestelling.Datum.ToString("dd MMMM yyyy") + @"\" + bestandsNaam + ".xlsx").Print();
                    }
                    afdrukitem.verwijder();
                }
               
                
             

            }
            catch
            {
                var message = "Afdruk item verwijderen mislukt wilt u deze verwijderen?";
                var title = "Keuze - Afdrukken";
                var result = MessageBox.Show(
                    message,                  // the message to show
                    title,                    // the title for the dialog box
                    MessageBoxButtons.YesNo,  // show two buttons: Yes and No
                    MessageBoxIcon.Question); // show a question mark icon

                // the following can be handled as if/else statements as well
                switch (result)
                {
                    case DialogResult.Yes:   // Yes button pressed
                        afdrukitemerror.verwijder();
                        break;
                      
                    case DialogResult.No:    // No button pressed
                        this.Close();
                        break;
                    default:                 // Neither Yes nor No pressed (just in case)
                        this.Close();
                        break;
                }
              
            }
            listBoxAfdrukken.Items.Clear();
            afdrukLijst.Clear();
            afdrukLijst = AfdrukWachtRij.KrijgAlleOpdrachten();
        }
    }
}
