namespace DhuyvetterBeton.Beton.Werven
{
    partial class FrmWerfVerwijderen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWerfVerwijderen));
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.labelKl = new System.Windows.Forms.Label();
            this.cboKlanten = new System.Windows.Forms.ComboBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.txtGemeente = new System.Windows.Forms.TextBox();
            this.lblGemeente = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtTelefoon = new System.Windows.Forms.TextBox();
            this.lblTelefoon = new System.Windows.Forms.Label();
            this.listBoxWervenVanKlant = new System.Windows.Forms.ListBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(503, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // labelKl
            // 
            this.labelKl.AutoSize = true;
            this.labelKl.Location = new System.Drawing.Point(15, 27);
            this.labelKl.Name = "labelKl";
            this.labelKl.Size = new System.Drawing.Size(35, 13);
            this.labelKl.TabIndex = 1010;
            this.labelKl.Text = "Klant:";
            // 
            // cboKlanten
            // 
            this.cboKlanten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboKlanten.FormattingEnabled = true;
            this.cboKlanten.Location = new System.Drawing.Point(80, 24);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Size = new System.Drawing.Size(252, 21);
            this.cboKlanten.Sorted = true;
            this.cboKlanten.TabIndex = 1002;
            this.cboKlanten.SelectedIndexChanged += new System.EventHandler(this.cboKlanten_SelectedIndexChanged);
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(80, 51);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(261, 21);
            this.txtPostcode.TabIndex = 1004;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(16, 54);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(55, 13);
            this.lblPostcode.TabIndex = 1009;
            this.lblPostcode.Text = "Postcode:";
            // 
            // txtGemeente
            // 
            this.txtGemeente.Location = new System.Drawing.Point(80, 77);
            this.txtGemeente.Name = "txtGemeente";
            this.txtGemeente.Size = new System.Drawing.Size(261, 21);
            this.txtGemeente.TabIndex = 1005;
            // 
            // lblGemeente
            // 
            this.lblGemeente.AutoSize = true;
            this.lblGemeente.Location = new System.Drawing.Point(16, 80);
            this.lblGemeente.Name = "lblGemeente";
            this.lblGemeente.Size = new System.Drawing.Size(60, 13);
            this.lblGemeente.TabIndex = 1008;
            this.lblGemeente.Text = "Gemeente:";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(80, 25);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(261, 21);
            this.txtAdres.TabIndex = 1003;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(16, 28);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(39, 13);
            this.lblAdres.TabIndex = 1006;
            this.lblAdres.Text = "Adres:";
            // 
            // txtTelefoon
            // 
            this.txtTelefoon.Location = new System.Drawing.Point(80, 103);
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(261, 21);
            this.txtTelefoon.TabIndex = 1007;
            // 
            // lblTelefoon
            // 
            this.lblTelefoon.AutoSize = true;
            this.lblTelefoon.Location = new System.Drawing.Point(16, 106);
            this.lblTelefoon.Name = "lblTelefoon";
            this.lblTelefoon.Size = new System.Drawing.Size(53, 13);
            this.lblTelefoon.TabIndex = 1001;
            this.lblTelefoon.Text = "Telefoon:";
            // 
            // listBoxWervenVanKlant
            // 
            this.listBoxWervenVanKlant.FormattingEnabled = true;
            this.listBoxWervenVanKlant.Location = new System.Drawing.Point(0, 40);
            this.listBoxWervenVanKlant.Name = "listBoxWervenVanKlant";
            this.listBoxWervenVanKlant.Size = new System.Drawing.Size(120, 238);
            this.listBoxWervenVanKlant.TabIndex = 1012;
            this.listBoxWervenVanKlant.SelectedIndexChanged += new System.EventHandler(this.listBoxWervenVanKlant_SelectedIndexChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(378, 243);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(108, 23);
            this.simpleButton1.TabIndex = 1013;
            this.simpleButton1.Text = "Verwijderen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtTelefoon);
            this.groupControl1.Controls.Add(this.lblTelefoon);
            this.groupControl1.Controls.Add(this.lblAdres);
            this.groupControl1.Controls.Add(this.txtAdres);
            this.groupControl1.Controls.Add(this.txtPostcode);
            this.groupControl1.Controls.Add(this.lblGemeente);
            this.groupControl1.Controls.Add(this.lblPostcode);
            this.groupControl1.Controls.Add(this.txtGemeente);
            this.groupControl1.Location = new System.Drawing.Point(138, 103);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(348, 135);
            this.groupControl1.TabIndex = 1014;
            this.groupControl1.Text = "Werf gegevens";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboKlanten);
            this.groupControl2.Controls.Add(this.labelKl);
            this.groupControl2.Location = new System.Drawing.Point(138, 42);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(348, 54);
            this.groupControl2.TabIndex = 1015;
            this.groupControl2.Text = "Selecteer klant";
            // 
            // FrmWerfVerwijderen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 278);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.listBoxWervenVanKlant);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWerfVerwijderen";
            this.Text = "Werf verwijderen";
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        protected System.Windows.Forms.Label labelKl;
        protected System.Windows.Forms.ComboBox cboKlanten;
        protected System.Windows.Forms.TextBox txtPostcode;
        protected System.Windows.Forms.Label lblPostcode;
        protected System.Windows.Forms.TextBox txtGemeente;
        protected System.Windows.Forms.Label lblGemeente;
        protected System.Windows.Forms.TextBox txtAdres;
        protected System.Windows.Forms.Label lblAdres;
        protected System.Windows.Forms.TextBox txtTelefoon;
        protected System.Windows.Forms.Label lblTelefoon;
        private System.Windows.Forms.ListBox listBoxWervenVanKlant;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}