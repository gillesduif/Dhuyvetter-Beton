
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    partial class FrmWerfWijzigen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWerfWijzigen));
            this.paneelBestaandeWerf = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cboWerven = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboPostcodeWerf = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboGemeenteWerf = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtTelefoonWerf = new DevExpress.XtraEditors.TextEdit();
            this.txtAdresWerf = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblWerf = new System.Windows.Forms.Label();
            this.paneelNieuweWerf = new DevExpress.XtraEditors.GroupControl();
            this.cbonieuwewerfklant = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboPostcodeWerfNieuw = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboGemeenteWerfNieuw = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtTelefoonWerfNieuw = new DevExpress.XtraEditors.TextEdit();
            this.txtAdresWerfNieuw = new DevExpress.XtraEditors.TextEdit();
            this.btnKlantAdres = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paneelBestaandeWerf)).BeginInit();
            this.paneelBestaandeWerf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWerven.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostcodeWerf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGemeenteWerf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefoonWerf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdresWerf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paneelNieuweWerf)).BeginInit();
            this.paneelNieuweWerf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbonieuwewerfklant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostcodeWerfNieuw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGemeenteWerfNieuw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefoonWerfNieuw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdresWerfNieuw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // paneelBestaandeWerf
            // 
            this.paneelBestaandeWerf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.paneelBestaandeWerf.Controls.Add(this.simpleButton2);
            this.paneelBestaandeWerf.Controls.Add(this.cboWerven);
            this.paneelBestaandeWerf.Controls.Add(this.groupControl2);
            this.paneelBestaandeWerf.Controls.Add(this.lblWerf);
            this.paneelBestaandeWerf.Location = new System.Drawing.Point(12, 11);
            this.paneelBestaandeWerf.Name = "paneelBestaandeWerf";
            this.paneelBestaandeWerf.Size = new System.Drawing.Size(390, 247);
            this.paneelBestaandeWerf.TabIndex = 918;
            this.paneelBestaandeWerf.Text = "Bestaande werf";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(246, 219);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(138, 23);
            this.simpleButton2.TabIndex = 735;
            this.simpleButton2.Text = "Aanpassen";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // cboWerven
            // 
            this.cboWerven.Location = new System.Drawing.Point(99, 35);
            this.cboWerven.Name = "cboWerven";
            this.cboWerven.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboWerven.Size = new System.Drawing.Size(274, 20);
            this.cboWerven.TabIndex = 735;
            this.cboWerven.SelectedIndexChanged += new System.EventHandler(this.cboWerven_SelectedIndexChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboPostcodeWerf);
            this.groupControl2.Controls.Add(this.cboGemeenteWerf);
            this.groupControl2.Controls.Add(this.txtTelefoonWerf);
            this.groupControl2.Controls.Add(this.txtAdresWerf);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Location = new System.Drawing.Point(22, 67);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(351, 139);
            this.groupControl2.TabIndex = 67;
            this.groupControl2.Text = "Gegevens";
            // 
            // cboPostcodeWerf
            // 
            this.cboPostcodeWerf.Location = new System.Drawing.Point(94, 83);
            this.cboPostcodeWerf.Name = "cboPostcodeWerf";
            this.cboPostcodeWerf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPostcodeWerf.Size = new System.Drawing.Size(136, 20);
            this.cboPostcodeWerf.TabIndex = 740;
            // 
            // cboGemeenteWerf
            // 
            this.cboGemeenteWerf.Location = new System.Drawing.Point(94, 55);
            this.cboGemeenteWerf.Name = "cboGemeenteWerf";
            this.cboGemeenteWerf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGemeenteWerf.Size = new System.Drawing.Size(136, 20);
            this.cboGemeenteWerf.TabIndex = 738;
            // 
            // txtTelefoonWerf
            // 
            this.txtTelefoonWerf.Location = new System.Drawing.Point(94, 111);
            this.txtTelefoonWerf.Name = "txtTelefoonWerf";
            this.txtTelefoonWerf.Size = new System.Drawing.Size(252, 20);
            this.txtTelefoonWerf.TabIndex = 741;
            // 
            // txtAdresWerf
            // 
            this.txtAdresWerf.Location = new System.Drawing.Point(94, 30);
            this.txtAdresWerf.Name = "txtAdresWerf";
            this.txtAdresWerf.Size = new System.Drawing.Size(252, 20);
            this.txtAdresWerf.TabIndex = 739;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 737;
            this.label1.Text = "Postcode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 736;
            this.label2.Text = "Gemeente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 735;
            this.label3.Text = "Adres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 734;
            this.label4.Text = "Gsm:";
            // 
            // lblWerf
            // 
            this.lblWerf.AutoSize = true;
            this.lblWerf.Location = new System.Drawing.Point(26, 37);
            this.lblWerf.Name = "lblWerf";
            this.lblWerf.Size = new System.Drawing.Size(35, 13);
            this.lblWerf.TabIndex = 53;
            this.lblWerf.Text = "Werf:";
            // 
            // paneelNieuweWerf
            // 
            this.paneelNieuweWerf.Controls.Add(this.cbonieuwewerfklant);
            this.paneelNieuweWerf.Controls.Add(this.cboPostcodeWerfNieuw);
            this.paneelNieuweWerf.Controls.Add(this.cboGemeenteWerfNieuw);
            this.paneelNieuweWerf.Controls.Add(this.txtTelefoonWerfNieuw);
            this.paneelNieuweWerf.Controls.Add(this.txtAdresWerfNieuw);
            this.paneelNieuweWerf.Controls.Add(this.btnKlantAdres);
            this.paneelNieuweWerf.Controls.Add(this.simpleButton1);
            this.paneelNieuweWerf.Controls.Add(this.label14);
            this.paneelNieuweWerf.Controls.Add(this.label15);
            this.paneelNieuweWerf.Controls.Add(this.label16);
            this.paneelNieuweWerf.Controls.Add(this.label17);
            this.paneelNieuweWerf.Controls.Add(this.label18);
            this.paneelNieuweWerf.Location = new System.Drawing.Point(13, 264);
            this.paneelNieuweWerf.Name = "paneelNieuweWerf";
            this.paneelNieuweWerf.Size = new System.Drawing.Size(390, 201);
            this.paneelNieuweWerf.TabIndex = 917;
            this.paneelNieuweWerf.Text = "Nieuwe Werf";
            // 
            // cbonieuwewerfklant
            // 
            this.cbonieuwewerfklant.Location = new System.Drawing.Point(81, 32);
            this.cbonieuwewerfklant.Name = "cbonieuwewerfklant";
            this.cbonieuwewerfklant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbonieuwewerfklant.Size = new System.Drawing.Size(170, 20);
            this.cbonieuwewerfklant.TabIndex = 734;
            // 
            // cboPostcodeWerfNieuw
            // 
            this.cboPostcodeWerfNieuw.Location = new System.Drawing.Point(81, 113);
            this.cboPostcodeWerfNieuw.Name = "cboPostcodeWerfNieuw";
            this.cboPostcodeWerfNieuw.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPostcodeWerfNieuw.Size = new System.Drawing.Size(170, 20);
            this.cboPostcodeWerfNieuw.TabIndex = 733;
            // 
            // cboGemeenteWerfNieuw
            // 
            this.cboGemeenteWerfNieuw.Location = new System.Drawing.Point(81, 85);
            this.cboGemeenteWerfNieuw.Name = "cboGemeenteWerfNieuw";
            this.cboGemeenteWerfNieuw.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGemeenteWerfNieuw.Size = new System.Drawing.Size(170, 20);
            this.cboGemeenteWerfNieuw.TabIndex = 732;
            // 
            // txtTelefoonWerfNieuw
            // 
            this.txtTelefoonWerfNieuw.Location = new System.Drawing.Point(81, 141);
            this.txtTelefoonWerfNieuw.Name = "txtTelefoonWerfNieuw";
            this.txtTelefoonWerfNieuw.Size = new System.Drawing.Size(170, 20);
            this.txtTelefoonWerfNieuw.TabIndex = 733;
            // 
            // txtAdresWerfNieuw
            // 
            this.txtAdresWerfNieuw.Location = new System.Drawing.Point(81, 60);
            this.txtAdresWerfNieuw.Name = "txtAdresWerfNieuw";
            this.txtAdresWerfNieuw.Size = new System.Drawing.Size(170, 20);
            this.txtAdresWerfNieuw.TabIndex = 732;
            // 
            // btnKlantAdres
            // 
            this.btnKlantAdres.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKlantAdres.ImageOptions.Image")));
            this.btnKlantAdres.Location = new System.Drawing.Point(266, 32);
            this.btnKlantAdres.Name = "btnKlantAdres";
            this.btnKlantAdres.Size = new System.Drawing.Size(101, 23);
            this.btnKlantAdres.TabIndex = 713;
            this.btnKlantAdres.Text = "Klant adres";
            this.btnKlantAdres.Click += new System.EventHandler(this.btnKlantAdres_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(245, 173);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(138, 23);
            this.simpleButton1.TabIndex = 712;
            this.simpleButton1.Text = "Toevoegen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 711;
            this.label14.Text = "Postcode:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 710;
            this.label15.Text = "Gemeente:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 708;
            this.label16.Text = "Adres:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 143);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 706;
            this.label17.Text = "Gsm:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 704;
            this.label18.Text = "Klant:";
            // 
            // FrmWerfWijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 470);
            this.Controls.Add(this.paneelBestaandeWerf);
            this.Controls.Add(this.paneelNieuweWerf);
            this.IconOptions.Image = global::DhuyvetterBeton.Beton.Properties.Resources.DBLogo;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmWerfWijzigen.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.Name = "FrmWerfWijzigen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Werf aanpassen";
            ((System.ComponentModel.ISupportInitialize)(this.paneelBestaandeWerf)).EndInit();
            this.paneelBestaandeWerf.ResumeLayout(false);
            this.paneelBestaandeWerf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWerven.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostcodeWerf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGemeenteWerf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefoonWerf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdresWerf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paneelNieuweWerf)).EndInit();
            this.paneelNieuweWerf.ResumeLayout(false);
            this.paneelNieuweWerf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbonieuwewerfklant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostcodeWerfNieuw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGemeenteWerfNieuw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefoonWerfNieuw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdresWerfNieuw.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl paneelBestaandeWerf;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.ComboBoxEdit cboWerven;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        protected System.Windows.Forms.Label lblWerf;
        private DevExpress.XtraEditors.GroupControl paneelNieuweWerf;
        private DevExpress.XtraEditors.ComboBoxEdit cbonieuwewerfklant;
        private DevExpress.XtraEditors.ComboBoxEdit cboPostcodeWerfNieuw;
        private DevExpress.XtraEditors.ComboBoxEdit cboGemeenteWerfNieuw;
        private DevExpress.XtraEditors.TextEdit txtTelefoonWerfNieuw;
        private DevExpress.XtraEditors.TextEdit txtAdresWerfNieuw;
        private DevExpress.XtraEditors.SimpleButton btnKlantAdres;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        protected System.Windows.Forms.Label label14;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Label label17;
        protected System.Windows.Forms.Label label18;
        private DevExpress.XtraEditors.ComboBoxEdit cboPostcodeWerf;
        private DevExpress.XtraEditors.ComboBoxEdit cboGemeenteWerf;
        private DevExpress.XtraEditors.TextEdit txtTelefoonWerf;
        private DevExpress.XtraEditors.TextEdit txtAdresWerf;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label4;
    }
}