namespace DhuyvetterBeton.Beton.Klanten
{
    partial class FrmKlantNotitie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKlantNotitie));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.lbxKlantNotities = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtBestaandeNotitie = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnWijzigen = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboKlanten = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNieuweNotitie = new DevExpress.XtraEditors.MemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToevoegen = new DevExpress.XtraEditors.SimpleButton();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxKlantNotities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBestaandeNotitie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKlanten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNieuweNotitie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.lbxKlantNotities);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl2);
            this.fluentDesignFormContainer1.Controls.Add(this.groupControl1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 40);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(480, 303);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // lbxKlantNotities
            // 
            this.lbxKlantNotities.Location = new System.Drawing.Point(0, 0);
            this.lbxKlantNotities.Name = "lbxKlantNotities";
            this.lbxKlantNotities.Size = new System.Drawing.Size(142, 303);
            this.lbxKlantNotities.TabIndex = 5;
            this.lbxKlantNotities.SelectedIndexChanged += new System.EventHandler(this.lbxKlantNotities_SelectedIndexChanged_1);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtBestaandeNotitie);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.btnWijzigen);
            this.groupControl2.Location = new System.Drawing.Point(148, 163);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(317, 133);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Bestaande klant notitie";
            // 
            // txtBestaandeNotitie
            // 
            this.txtBestaandeNotitie.Location = new System.Drawing.Point(80, 32);
            this.txtBestaandeNotitie.Name = "txtBestaandeNotitie";
            this.txtBestaandeNotitie.Size = new System.Drawing.Size(221, 60);
            this.txtBestaandeNotitie.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Opmerking:";
            // 
            // btnWijzigen
            // 
            this.btnWijzigen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWijzigen.ImageOptions.Image")));
            this.btnWijzigen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnWijzigen.ImageOptions.SvgImage")));
            this.btnWijzigen.Location = new System.Drawing.Point(206, 98);
            this.btnWijzigen.Name = "btnWijzigen";
            this.btnWijzigen.Size = new System.Drawing.Size(106, 28);
            this.btnWijzigen.TabIndex = 5;
            this.btnWijzigen.Text = "Wijzigen";
            this.btnWijzigen.Click += new System.EventHandler(this.btnWijzigen_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboKlanten);
            this.groupControl1.Controls.Add(this.txtNieuweNotitie);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btnToevoegen);
            this.groupControl1.Location = new System.Drawing.Point(148, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(317, 151);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Nieuwe klant notitie";
            // 
            // cboKlanten
            // 
            this.cboKlanten.Location = new System.Drawing.Point(80, 25);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKlanten.Size = new System.Drawing.Size(221, 20);
            this.cboKlanten.TabIndex = 8;
            // 
            // txtNieuweNotitie
            // 
            this.txtNieuweNotitie.Location = new System.Drawing.Point(80, 52);
            this.txtNieuweNotitie.Name = "txtNieuweNotitie";
            this.txtNieuweNotitie.Size = new System.Drawing.Size(221, 60);
            this.txtNieuweNotitie.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opmerking:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Klant:";
            // 
            // btnToevoegen
            // 
            this.btnToevoegen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnToevoegen.ImageOptions.Image")));
            this.btnToevoegen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnToevoegen.ImageOptions.SvgImage")));
            this.btnToevoegen.Location = new System.Drawing.Point(206, 118);
            this.btnToevoegen.Name = "btnToevoegen";
            this.btnToevoegen.Size = new System.Drawing.Size(106, 28);
            this.btnToevoegen.TabIndex = 2;
            this.btnToevoegen.Text = "Toevoegen";
            this.btnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(480, 40);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // FrmKlantNotitie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 343);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKlantNotitie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Klant Notitie";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmKlantNotitie_Load);
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxKlantNotities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBestaandeNotitie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboKlanten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNieuweNotitie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnWijzigen;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnToevoegen;
        private DevExpress.XtraEditors.ListBoxControl lbxKlantNotities;
        private DevExpress.XtraEditors.MemoEdit txtBestaandeNotitie;
        private DevExpress.XtraEditors.ComboBoxEdit cboKlanten;
        private DevExpress.XtraEditors.MemoEdit txtNieuweNotitie;
    }
}