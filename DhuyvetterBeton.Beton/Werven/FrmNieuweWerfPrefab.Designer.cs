namespace DhuyvetterBeton.Beton.Werven
{
    partial class FrmNieuweWerfPrefab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNieuweWerfPrefab));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblTelefoon = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.lblGemeente = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblKlant = new System.Windows.Forms.Label();
            this.cboKlanten = new System.Windows.Forms.ComboBox();
            this.cboPostcode = new System.Windows.Forms.ComboBox();
            this.CboGemeente = new System.Windows.Forms.ComboBox();
            this.cboContactPersoon = new System.Windows.Forms.ComboBox();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblNaam = new System.Windows.Forms.Label();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVoornaam = new System.Windows.Forms.TextBox();
            this.txtGSM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtTelefoon = new System.Windows.Forms.TextBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl3);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton1);
            this.fluentDesignFormContainer1.Controls.Add(this.simpleButton2);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl2);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(822, 271);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(822, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.simpleButton1.ImageOptions.ImageToTextIndent = 0;
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 229);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(132, 23);
            this.simpleButton1.TabIndex = 65;
            this.simpleButton1.Text = "Adres van Klant";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(303, 229);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(97, 23);
            this.simpleButton2.TabIndex = 66;
            this.simpleButton2.Text = "Toevoegen";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboContactPersoon);
            this.groupControl2.Controls.Add(this.cboPostcode);
            this.groupControl2.Controls.Add(this.CboGemeente);
            this.groupControl2.Controls.Add(this.lblAdres);
            this.groupControl2.Controls.Add(this.lblTelefoon);
            this.groupControl2.Controls.Add(this.txtAdres);
            this.groupControl2.Controls.Add(this.lblPostcode);
            this.groupControl2.Controls.Add(this.lblGemeente);
            this.groupControl2.Location = new System.Drawing.Point(12, 74);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(388, 149);
            this.groupControl2.TabIndex = 64;
            this.groupControl2.Text = "Gegevens";
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(21, 31);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(39, 13);
            this.lblAdres.TabIndex = 49;
            this.lblAdres.Text = "Adres:";
            // 
            // lblTelefoon
            // 
            this.lblTelefoon.AutoSize = true;
            this.lblTelefoon.Location = new System.Drawing.Point(21, 117);
            this.lblTelefoon.Name = "lblTelefoon";
            this.lblTelefoon.Size = new System.Drawing.Size(91, 13);
            this.lblTelefoon.TabIndex = 35;
            this.lblTelefoon.Text = "Contact persoon:";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(125, 28);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(232, 21);
            this.txtAdres.TabIndex = 46;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(21, 87);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(55, 13);
            this.lblPostcode.TabIndex = 51;
            this.lblPostcode.Text = "Postcode:";
            // 
            // lblGemeente
            // 
            this.lblGemeente.AutoSize = true;
            this.lblGemeente.Location = new System.Drawing.Point(21, 59);
            this.lblGemeente.Name = "lblGemeente";
            this.lblGemeente.Size = new System.Drawing.Size(60, 13);
            this.lblGemeente.TabIndex = 50;
            this.lblGemeente.Text = "Gemeente:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblKlant);
            this.groupControl1.Controls.Add(this.cboKlanten);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(388, 62);
            this.groupControl1.TabIndex = 63;
            this.groupControl1.Text = "Selecteer klant";
            // 
            // lblKlant
            // 
            this.lblKlant.AutoSize = true;
            this.lblKlant.Location = new System.Drawing.Point(24, 31);
            this.lblKlant.Name = "lblKlant";
            this.lblKlant.Size = new System.Drawing.Size(69, 13);
            this.lblKlant.TabIndex = 33;
            this.lblKlant.Text = "Prefab klant:";
            // 
            // cboKlanten
            // 
            this.cboKlanten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboKlanten.FormattingEnabled = true;
            this.cboKlanten.Location = new System.Drawing.Point(125, 28);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Size = new System.Drawing.Size(232, 21);
            this.cboKlanten.TabIndex = 34;
            this.cboKlanten.SelectedIndexChanged += new System.EventHandler(this.cboKlanten_SelectedIndexChanged);
            this.cboKlanten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboKlanten_KeyDown);
            // 
            // cboPostcode
            // 
            this.cboPostcode.FormattingEnabled = true;
            this.cboPostcode.Location = new System.Drawing.Point(125, 83);
            this.cboPostcode.Name = "cboPostcode";
            this.cboPostcode.Size = new System.Drawing.Size(232, 21);
            this.cboPostcode.TabIndex = 700;
            this.cboPostcode.SelectedIndexChanged += new System.EventHandler(this.cboPostcode_SelectedIndexChanged);
            this.cboPostcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboPostcode_KeyDown);
            // 
            // CboGemeente
            // 
            this.CboGemeente.FormattingEnabled = true;
            this.CboGemeente.Location = new System.Drawing.Point(125, 56);
            this.CboGemeente.Name = "CboGemeente";
            this.CboGemeente.Size = new System.Drawing.Size(232, 21);
            this.CboGemeente.TabIndex = 699;
            this.CboGemeente.SelectedIndexChanged += new System.EventHandler(this.CboGemeente_SelectedIndexChanged);
            this.CboGemeente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboGemeente_KeyDown);
            // 
            // cboContactPersoon
            // 
            this.cboContactPersoon.FormattingEnabled = true;
            this.cboContactPersoon.Location = new System.Drawing.Point(125, 114);
            this.cboContactPersoon.Name = "cboContactPersoon";
            this.cboContactPersoon.Size = new System.Drawing.Size(232, 21);
            this.cboContactPersoon.TabIndex = 701;
            this.cboContactPersoon.SelectedIndexChanged += new System.EventHandler(this.cboContactPersoon_SelectedIndexChanged);
            this.cboContactPersoon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboContactPersoon_KeyDown);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.simpleButton3);
            this.groupControl3.Controls.Add(this.lblNaam);
            this.groupControl3.Controls.Add(this.txtNaam);
            this.groupControl3.Controls.Add(this.label1);
            this.groupControl3.Controls.Add(this.txtVoornaam);
            this.groupControl3.Controls.Add(this.txtGSM);
            this.groupControl3.Controls.Add(this.label3);
            this.groupControl3.Controls.Add(this.lblEmail);
            this.groupControl3.Controls.Add(this.txtTelefoon);
            this.groupControl3.Location = new System.Drawing.Point(445, 37);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(348, 172);
            this.groupControl3.TabIndex = 67;
            this.groupControl3.Text = "Nieuwe contactpersoon ";
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(49, 32);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(38, 13);
            this.lblNaam.TabIndex = 702;
            this.lblNaam.Text = "Naam:";
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(110, 29);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(181, 21);
            this.txtNaam.TabIndex = 698;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 703;
            this.label1.Text = "Voornaam:";
            // 
            // txtVoornaam
            // 
            this.txtVoornaam.Location = new System.Drawing.Point(110, 57);
            this.txtVoornaam.Name = "txtVoornaam";
            this.txtVoornaam.Size = new System.Drawing.Size(181, 21);
            this.txtVoornaam.TabIndex = 699;
            // 
            // txtGSM
            // 
            this.txtGSM.Location = new System.Drawing.Point(110, 112);
            this.txtGSM.Name = "txtGSM";
            this.txtGSM.Size = new System.Drawing.Size(181, 21);
            this.txtGSM.TabIndex = 701;
            this.txtGSM.Text = "+32 (0)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 705;
            this.label3.Text = "Telefoon:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(49, 115);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 706;
            this.lblEmail.Text = "GSM:";
            // 
            // txtTelefoon
            // 
            this.txtTelefoon.Location = new System.Drawing.Point(110, 85);
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(181, 21);
            this.txtTelefoon.TabIndex = 700;
            this.txtTelefoon.Text = "+32 (0)";
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(224, 144);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(119, 23);
            this.simpleButton3.TabIndex = 707;
            this.simpleButton3.Text = "Toevoegen";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // FrmNieuweWerfPrefab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 302);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNieuweWerfPrefab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nieuwe werf prefab";
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        protected System.Windows.Forms.Label lblAdres;
        protected System.Windows.Forms.Label lblTelefoon;
        protected System.Windows.Forms.TextBox txtAdres;
        protected System.Windows.Forms.Label lblPostcode;
        protected System.Windows.Forms.Label lblGemeente;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        protected System.Windows.Forms.Label lblKlant;
        protected System.Windows.Forms.ComboBox cboKlanten;
        private System.Windows.Forms.ComboBox cboContactPersoon;
        private System.Windows.Forms.ComboBox cboPostcode;
        private System.Windows.Forms.ComboBox CboGemeente;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        protected System.Windows.Forms.Label lblNaam;
        protected System.Windows.Forms.TextBox txtNaam;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtVoornaam;
        protected System.Windows.Forms.TextBox txtGSM;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label lblEmail;
        protected System.Windows.Forms.TextBox txtTelefoon;
    }
}