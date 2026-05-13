namespace DhuyvetterBeton.Beton.Kortingen
{
    partial class FrmNieuweKortingProductWerf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNieuweKortingProductWerf));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.cboWerven = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProductOmschrijving = new System.Windows.Forms.ComboBox();
            this.lblFormule = new System.Windows.Forms.Label();
            this.cboKlanten = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtBedrag = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboformules = new System.Windows.Forms.ComboBox();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBedrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl4);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl3);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl2);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl1);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 40);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(357, 309);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // cboWerven
            // 
            this.cboWerven.FormattingEnabled = true;
            this.cboWerven.Location = new System.Drawing.Point(65, 29);
            this.cboWerven.Name = "cboWerven";
            this.cboWerven.Size = new System.Drawing.Size(272, 21);
            this.cboWerven.TabIndex = 76;
            this.cboWerven.SelectedIndexChanged += new System.EventHandler(this.cboWerven_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Werf:";
            // 
            // cboProductOmschrijving
            // 
            this.cboProductOmschrijving.FormattingEnabled = true;
            this.cboProductOmschrijving.Location = new System.Drawing.Point(65, 29);
            this.cboProductOmschrijving.Name = "cboProductOmschrijving";
            this.cboProductOmschrijving.Size = new System.Drawing.Size(271, 21);
            this.cboProductOmschrijving.TabIndex = 73;
            this.cboProductOmschrijving.SelectedIndexChanged += new System.EventHandler(this.cboProductOmschrijving_SelectedIndexChanged);
            // 
            // lblFormule
            // 
            this.lblFormule.AutoSize = true;
            this.lblFormule.Location = new System.Drawing.Point(12, 32);
            this.lblFormule.Name = "lblFormule";
            this.lblFormule.Size = new System.Drawing.Size(48, 13);
            this.lblFormule.TabIndex = 72;
            this.lblFormule.Text = "Product:";
            // 
            // cboKlanten
            // 
            this.cboKlanten.FormattingEnabled = true;
            this.cboKlanten.Location = new System.Drawing.Point(65, 27);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Size = new System.Drawing.Size(272, 21);
            this.cboKlanten.TabIndex = 71;
            this.cboKlanten.SelectedIndexChanged += new System.EventHandler(this.cboKlanten_SelectedIndexChanged);
            this.cboKlanten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKlanten_KeyDown);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(277, 279);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 70;
            this.simpleButton1.Text = "Toevoegen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtBedrag
            // 
            this.txtBedrag.Location = new System.Drawing.Point(65, 27);
            this.txtBedrag.Name = "txtBedrag";
            this.txtBedrag.Size = new System.Drawing.Size(272, 20);
            this.txtBedrag.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Bedrag:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Klant:";
            // 
            // cboformules
            // 
            this.cboformules.FormattingEnabled = true;
            this.cboformules.Location = new System.Drawing.Point(65, 29);
            this.cboformules.Name = "cboformules";
            this.cboformules.Size = new System.Drawing.Size(271, 21);
            this.cboformules.TabIndex = 74;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(357, 40);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboKlanten);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(349, 61);
            this.groupControl1.TabIndex = 77;
            this.groupControl1.Text = "Selecteer klant";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboWerven);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Location = new System.Drawing.Point(3, 71);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(349, 67);
            this.groupControl2.TabIndex = 78;
            this.groupControl2.Text = "Selecteer Werf";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cboProductOmschrijving);
            this.groupControl3.Controls.Add(this.cboformules);
            this.groupControl3.Controls.Add(this.lblFormule);
            this.groupControl3.Location = new System.Drawing.Point(3, 143);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(349, 64);
            this.groupControl3.TabIndex = 79;
            this.groupControl3.Text = "Selecteer Product";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.txtBedrag);
            this.groupControl4.Controls.Add(this.label3);
            this.groupControl4.Location = new System.Drawing.Point(3, 212);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(349, 61);
            this.groupControl4.TabIndex = 80;
            this.groupControl4.Text = "Gegevens";
            // 
            // FrmNieuweKortingProductWerf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 349);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNieuweKortingProductWerf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Korting toevoegen - speciefieke werf & product";
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBedrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private System.Windows.Forms.ComboBox cboProductOmschrijving;
        protected System.Windows.Forms.Label lblFormule;
        private System.Windows.Forms.ComboBox cboKlanten;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtBedrag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboformules;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private System.Windows.Forms.ComboBox cboWerven;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}