namespace DhuyvetterBeton.Beton.Kortingen
{
    partial class FrmNieuweKortingProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNieuweKortingProduct));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtBedrag = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboProductOmschrijving = new System.Windows.Forms.ComboBox();
            this.cboformules = new System.Windows.Forms.ComboBox();
            this.lblFormule = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKlanten = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBedrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl3);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl2);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl1);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(336, 241);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtBedrag);
            this.groupControl3.Controls.Add(this.label3);
            this.groupControl3.Location = new System.Drawing.Point(12, 133);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(314, 61);
            this.groupControl3.TabIndex = 69;
            this.groupControl3.Text = "Gegevens";
            // 
            // txtBedrag
            // 
            this.txtBedrag.Location = new System.Drawing.Point(93, 27);
            this.txtBedrag.Name = "txtBedrag";
            this.txtBedrag.Size = new System.Drawing.Size(202, 20);
            this.txtBedrag.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bedrag:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboProductOmschrijving);
            this.groupControl2.Controls.Add(this.cboformules);
            this.groupControl2.Controls.Add(this.lblFormule);
            this.groupControl2.Location = new System.Drawing.Point(12, 70);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(314, 57);
            this.groupControl2.TabIndex = 68;
            this.groupControl2.Text = "Selecteer product";
            // 
            // cboProductOmschrijving
            // 
            this.cboProductOmschrijving.FormattingEnabled = true;
            this.cboProductOmschrijving.Location = new System.Drawing.Point(93, 24);
            this.cboProductOmschrijving.Name = "cboProductOmschrijving";
            this.cboProductOmschrijving.Size = new System.Drawing.Size(202, 21);
            this.cboProductOmschrijving.TabIndex = 65;
            this.cboProductOmschrijving.SelectedIndexChanged += new System.EventHandler(this.cboProductOmschrijving_SelectedIndexChanged);
            this.cboProductOmschrijving.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProductOmschrijving_KeyDown);
            // 
            // cboformules
            // 
            this.cboformules.FormattingEnabled = true;
            this.cboformules.Location = new System.Drawing.Point(93, 24);
            this.cboformules.Name = "cboformules";
            this.cboformules.Size = new System.Drawing.Size(202, 21);
            this.cboformules.TabIndex = 66;
            // 
            // lblFormule
            // 
            this.lblFormule.AutoSize = true;
            this.lblFormule.Location = new System.Drawing.Point(21, 27);
            this.lblFormule.Name = "lblFormule";
            this.lblFormule.Size = new System.Drawing.Size(48, 13);
            this.lblFormule.TabIndex = 64;
            this.lblFormule.Text = "Product:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cboKlanten);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(314, 58);
            this.groupControl1.TabIndex = 67;
            this.groupControl1.Text = "Selecteer klant";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Klant:";
            // 
            // cboKlanten
            // 
            this.cboKlanten.FormattingEnabled = true;
            this.cboKlanten.Location = new System.Drawing.Point(93, 28);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Size = new System.Drawing.Size(202, 21);
            this.cboKlanten.TabIndex = 16;
            this.cboKlanten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKlanten_KeyDown);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(251, 203);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "Toevoegen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(336, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // FrmNieuweKortingProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 272);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNieuweKortingProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Korting Toevoegen - Product";
            this.Load += new System.EventHandler(this.FrmNieuweKortingProduct_Load);
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBedrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private System.Windows.Forms.ComboBox cboKlanten;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtBedrag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProductOmschrijving;
        protected System.Windows.Forms.Label lblFormule;
        private System.Windows.Forms.ComboBox cboformules;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}