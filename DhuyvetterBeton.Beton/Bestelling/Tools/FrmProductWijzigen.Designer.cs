
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    partial class FrmProductWijzigen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductWijzigen));
            this.paneelProduct = new DevExpress.XtraEditors.GroupControl();
            this.checkBox1 = new DevExpress.XtraEditors.CheckEdit();
            this.cboProductOmschrijving = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtM3 = new DevExpress.XtraEditors.TextEdit();
            this.lblFormule = new System.Windows.Forms.Label();
            this.cboFormules = new System.Windows.Forms.ComboBox();
            this.lblHoeveelHeidIndicatie = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.paneelProduct)).BeginInit();
            this.paneelProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductOmschrijving.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtM3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // paneelProduct
            // 
            this.paneelProduct.Controls.Add(this.checkBox1);
            this.paneelProduct.Controls.Add(this.cboProductOmschrijving);
            this.paneelProduct.Controls.Add(this.txtM3);
            this.paneelProduct.Controls.Add(this.lblFormule);
            this.paneelProduct.Controls.Add(this.cboFormules);
            this.paneelProduct.Controls.Add(this.lblHoeveelHeidIndicatie);
            this.paneelProduct.Location = new System.Drawing.Point(7, 12);
            this.paneelProduct.Name = "paneelProduct";
            this.paneelProduct.Size = new System.Drawing.Size(390, 106);
            this.paneelProduct.TabIndex = 918;
            this.paneelProduct.Text = "Product";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(310, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Properties.Caption = "Saldo";
            this.checkBox1.Size = new System.Drawing.Size(50, 19);
            this.checkBox1.TabIndex = 927;
            this.checkBox1.Visible = false;
            // 
            // cboProductOmschrijving
            // 
            this.cboProductOmschrijving.Location = new System.Drawing.Point(103, 36);
            this.cboProductOmschrijving.Name = "cboProductOmschrijving";
            this.cboProductOmschrijving.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProductOmschrijving.Size = new System.Drawing.Size(256, 20);
            this.cboProductOmschrijving.TabIndex = 736;
            this.cboProductOmschrijving.SelectedIndexChanged += new System.EventHandler(this.cboProductOmschrijving_SelectedIndexChanged);
            // 
            // txtM3
            // 
            this.txtM3.Location = new System.Drawing.Point(104, 73);
            this.txtM3.Name = "txtM3";
            this.txtM3.Size = new System.Drawing.Size(190, 20);
            this.txtM3.TabIndex = 686;
            // 
            // lblFormule
            // 
            this.lblFormule.AutoSize = true;
            this.lblFormule.Location = new System.Drawing.Point(22, 36);
            this.lblFormule.Name = "lblFormule";
            this.lblFormule.Size = new System.Drawing.Size(50, 13);
            this.lblFormule.TabIndex = 59;
            this.lblFormule.Text = "Product:";
            // 
            // cboFormules
            // 
            this.cboFormules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.cboFormules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFormules.ForeColor = System.Drawing.SystemColors.Window;
            this.cboFormules.FormattingEnabled = true;
            this.cboFormules.Location = new System.Drawing.Point(104, 36);
            this.cboFormules.Name = "cboFormules";
            this.cboFormules.Size = new System.Drawing.Size(254, 21);
            this.cboFormules.TabIndex = 60;
            // 
            // lblHoeveelHeidIndicatie
            // 
            this.lblHoeveelHeidIndicatie.AutoSize = true;
            this.lblHoeveelHeidIndicatie.Location = new System.Drawing.Point(22, 75);
            this.lblHoeveelHeidIndicatie.Name = "lblHoeveelHeidIndicatie";
            this.lblHoeveelHeidIndicatie.Size = new System.Drawing.Size(24, 13);
            this.lblHoeveelHeidIndicatie.TabIndex = 61;
            this.lblHoeveelHeidIndicatie.Text = "M³:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(280, 132);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(123, 23);
            this.simpleButton1.TabIndex = 919;
            this.simpleButton1.Text = "Aanpassen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmProductWijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 158);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.paneelProduct);
            this.IconOptions.Image = global::DhuyvetterBeton.Beton.Properties.Resources.DBLogo;
            this.MaximizeBox = false;
            this.Name = "FrmProductWijzigen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product aanpassen";
            ((System.ComponentModel.ISupportInitialize)(this.paneelProduct)).EndInit();
            this.paneelProduct.ResumeLayout(false);
            this.paneelProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductOmschrijving.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtM3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl paneelProduct;
        private DevExpress.XtraEditors.CheckEdit checkBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cboProductOmschrijving;
        private DevExpress.XtraEditors.TextEdit txtM3;
        protected System.Windows.Forms.Label lblFormule;
        protected System.Windows.Forms.ComboBox cboFormules;
        protected System.Windows.Forms.Label lblHoeveelHeidIndicatie;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}