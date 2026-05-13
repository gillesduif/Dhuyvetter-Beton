namespace DhuyvetterBeton.Beton.Werven
{
    partial class FrmWijzigenWerf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWijzigenWerf));
            this.listBoxWervenVanKlant = new System.Windows.Forms.ListBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.txtGemeente = new System.Windows.Forms.TextBox();
            this.lblGemeente = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtTelefoon = new System.Windows.Forms.TextBox();
            this.lblTelefoon = new System.Windows.Forms.Label();
            this.labelKl = new System.Windows.Forms.Label();
            this.cboKlanten = new System.Windows.Forms.ComboBox();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxWervenVanKlant
            // 
            this.listBoxWervenVanKlant.FormattingEnabled = true;
            this.listBoxWervenVanKlant.Location = new System.Drawing.Point(0, 0);
            this.listBoxWervenVanKlant.Name = "listBoxWervenVanKlant";
            this.listBoxWervenVanKlant.Size = new System.Drawing.Size(244, 212);
            this.listBoxWervenVanKlant.TabIndex = 1000;
            this.listBoxWervenVanKlant.Click += new System.EventHandler(this.listBoxWervenVanKlant_Click);
            this.listBoxWervenVanKlant.SelectedIndexChanged += new System.EventHandler(this.listBoxWervenVanKlant_SelectedIndexChanged);
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(117, 52);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(215, 22);
            this.txtPostcode.TabIndex = 57;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(22, 55);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(57, 13);
            this.lblPostcode.TabIndex = 61;
            this.lblPostcode.Text = "Postcode:";
            // 
            // txtGemeente
            // 
            this.txtGemeente.Location = new System.Drawing.Point(117, 78);
            this.txtGemeente.Name = "txtGemeente";
            this.txtGemeente.Size = new System.Drawing.Size(215, 22);
            this.txtGemeente.TabIndex = 58;
            // 
            // lblGemeente
            // 
            this.lblGemeente.AutoSize = true;
            this.lblGemeente.Location = new System.Drawing.Point(22, 81);
            this.lblGemeente.Name = "lblGemeente";
            this.lblGemeente.Size = new System.Drawing.Size(62, 13);
            this.lblGemeente.TabIndex = 60;
            this.lblGemeente.Text = "Gemeente:";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(117, 26);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(215, 22);
            this.txtAdres.TabIndex = 56;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(22, 29);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(39, 13);
            this.lblAdres.TabIndex = 59;
            this.lblAdres.Text = "Adres:";
            // 
            // txtTelefoon
            // 
            this.txtTelefoon.Location = new System.Drawing.Point(117, 104);
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(215, 22);
            this.txtTelefoon.TabIndex = 59;
            // 
            // lblTelefoon
            // 
            this.lblTelefoon.AutoSize = true;
            this.lblTelefoon.Location = new System.Drawing.Point(22, 107);
            this.lblTelefoon.Name = "lblTelefoon";
            this.lblTelefoon.Size = new System.Drawing.Size(55, 13);
            this.lblTelefoon.TabIndex = 53;
            this.lblTelefoon.Text = "Telefoon:";
            // 
            // labelKl
            // 
            this.labelKl.AutoSize = true;
            this.labelKl.Location = new System.Drawing.Point(22, 32);
            this.labelKl.Name = "labelKl";
            this.labelKl.Size = new System.Drawing.Size(36, 13);
            this.labelKl.TabIndex = 73;
            this.labelKl.Text = "Klant:";
            this.labelKl.Visible = false;
            // 
            // cboKlanten
            // 
            this.cboKlanten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboKlanten.FormattingEnabled = true;
            this.cboKlanten.Location = new System.Drawing.Point(65, 29);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Size = new System.Drawing.Size(267, 21);
            this.cboKlanten.Sorted = true;
            this.cboKlanten.TabIndex = 55;
            this.cboKlanten.Visible = false;
            this.cboKlanten.SelectedIndexChanged += new System.EventHandler(this.cboKlanten_SelectedIndexChanged);
            this.cboKlanten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKlanten_KeyDown);
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton2);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton1);
            this.fluentDesignFormContainer1.Controls.Add(this.listBoxWervenVanKlant);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl2);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 40);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(629, 254);
            this.fluentDesignFormContainer1.TabIndex = 1001;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(3, 220);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(99, 23);
            this.simpleButton2.TabIndex = 1002;
            this.simpleButton2.Text = "Verwijderen";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(526, 220);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 23);
            this.simpleButton1.TabIndex = 1001;
            this.simpleButton1.Text = "Wijzigen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtPostcode);
            this.groupControl2.Controls.Add(this.lblTelefoon);
            this.groupControl2.Controls.Add(this.lblPostcode);
            this.groupControl2.Controls.Add(this.txtTelefoon);
            this.groupControl2.Controls.Add(this.txtGemeente);
            this.groupControl2.Controls.Add(this.lblAdres);
            this.groupControl2.Controls.Add(this.lblGemeente);
            this.groupControl2.Controls.Add(this.txtAdres);
            this.groupControl2.Location = new System.Drawing.Point(250, 70);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(367, 142);
            this.groupControl2.TabIndex = 76;
            this.groupControl2.Text = "Gegevens";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelKl);
            this.groupControl1.Controls.Add(this.cboKlanten);
            this.groupControl1.Location = new System.Drawing.Point(250, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(367, 58);
            this.groupControl1.TabIndex = 75;
            this.groupControl1.Text = "Selecteer klant";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(629, 40);
            this.fluentDesignFormControl1.TabIndex = 1003;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            // 
            // FrmWijzigenWerf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 294);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWijzigenWerf";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Werf wijzigen";
            this.Load += new System.EventHandler(this.FrmWijzigenWerf_Load);
            this.fluentDesignFormContainer1.ResumeLayout(false);
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

        private System.Windows.Forms.ListBox listBoxWervenVanKlant;
        protected System.Windows.Forms.TextBox txtPostcode;
        protected System.Windows.Forms.Label lblPostcode;
        protected System.Windows.Forms.TextBox txtGemeente;
        protected System.Windows.Forms.Label lblGemeente;
        protected System.Windows.Forms.TextBox txtAdres;
        protected System.Windows.Forms.Label lblAdres;
        protected System.Windows.Forms.TextBox txtTelefoon;
        protected System.Windows.Forms.Label lblTelefoon;
        protected System.Windows.Forms.Label labelKl;
        protected System.Windows.Forms.ComboBox cboKlanten;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}