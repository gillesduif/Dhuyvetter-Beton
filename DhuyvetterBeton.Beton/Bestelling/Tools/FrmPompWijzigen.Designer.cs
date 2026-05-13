
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    partial class FrmPompWijzigen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPompWijzigen));
            this.chbOpmerkingPomp = new DevExpress.XtraEditors.CheckEdit();
            this.cboPompen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboGiek = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chbOpmerkingPomp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPompen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGiek.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chbOpmerkingPomp
            // 
            this.chbOpmerkingPomp.Location = new System.Drawing.Point(266, 36);
            this.chbOpmerkingPomp.Name = "chbOpmerkingPomp";
            this.chbOpmerkingPomp.Properties.Caption = "Opmerking";
            this.chbOpmerkingPomp.Size = new System.Drawing.Size(77, 19);
            this.chbOpmerkingPomp.TabIndex = 928;
            this.chbOpmerkingPomp.Visible = false;
            // 
            // cboPompen
            // 
            this.cboPompen.Location = new System.Drawing.Point(87, 7);
            this.cboPompen.Name = "cboPompen";
            this.cboPompen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPompen.Size = new System.Drawing.Size(256, 20);
            this.cboPompen.TabIndex = 735;
            // 
            // cboGiek
            // 
            this.cboGiek.Location = new System.Drawing.Point(87, 37);
            this.cboGiek.Name = "cboGiek";
            this.cboGiek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGiek.Size = new System.Drawing.Size(170, 20);
            this.cboGiek.TabIndex = 734;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Pomp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Giek:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(241, 80);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(123, 23);
            this.simpleButton1.TabIndex = 929;
            this.simpleButton1.Text = "Aanpassen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmPompWijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 106);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.chbOpmerkingPomp);
            this.Controls.Add(this.cboPompen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGiek);
            this.Controls.Add(this.label3);
            this.IconOptions.Image = global::DhuyvetterBeton.Beton.Properties.Resources.DBLogo;
            this.Name = "FrmPompWijzigen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pomp aanpassen";
            ((System.ComponentModel.ISupportInitialize)(this.chbOpmerkingPomp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPompen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGiek.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chbOpmerkingPomp;
        private DevExpress.XtraEditors.ComboBoxEdit cboPompen;
        private DevExpress.XtraEditors.ComboBoxEdit cboGiek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}