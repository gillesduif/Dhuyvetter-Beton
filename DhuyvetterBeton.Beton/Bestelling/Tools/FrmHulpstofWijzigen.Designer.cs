
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    partial class FrmHulpstofWijzigen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHulpstofWijzigen));
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.cboHulpstof = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtHoeveelheidHulpstof = new DevExpress.XtraEditors.TextEdit();
            this.Listboxhulpstoffen = new DevExpress.XtraEditors.ListBoxControl();
            this.lblLevering = new System.Windows.Forms.Label();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.chkbLevering = new System.Windows.Forms.CheckBox();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHulpstof.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoeveelheidHulpstof.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Listboxhulpstoffen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.cboHulpstof);
            this.groupControl6.Controls.Add(this.txtHoeveelheidHulpstof);
            this.groupControl6.Controls.Add(this.Listboxhulpstoffen);
            this.groupControl6.Controls.Add(this.lblLevering);
            this.groupControl6.Controls.Add(this.simpleButton7);
            this.groupControl6.Controls.Add(this.chkbLevering);
            this.groupControl6.Controls.Add(this.simpleButton4);
            this.groupControl6.Controls.Add(this.label4);
            this.groupControl6.Controls.Add(this.label5);
            this.groupControl6.Location = new System.Drawing.Point(12, 12);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(378, 119);
            this.groupControl6.TabIndex = 143;
            this.groupControl6.Text = "Hulpstoffen";
            // 
            // cboHulpstof
            // 
            this.cboHulpstof.Location = new System.Drawing.Point(95, 33);
            this.cboHulpstof.Name = "cboHulpstof";
            this.cboHulpstof.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboHulpstof.Properties.Items.AddRange(new object[] {
            ""});
            this.cboHulpstof.Size = new System.Drawing.Size(103, 20);
            this.cboHulpstof.TabIndex = 126;
            // 
            // txtHoeveelheidHulpstof
            // 
            this.txtHoeveelheidHulpstof.Location = new System.Drawing.Point(95, 60);
            this.txtHoeveelheidHulpstof.Name = "txtHoeveelheidHulpstof";
            this.txtHoeveelheidHulpstof.Size = new System.Drawing.Size(103, 20);
            this.txtHoeveelheidHulpstof.TabIndex = 928;
            // 
            // Listboxhulpstoffen
            // 
            this.Listboxhulpstoffen.Location = new System.Drawing.Point(213, 24);
            this.Listboxhulpstoffen.Name = "Listboxhulpstoffen";
            this.Listboxhulpstoffen.Size = new System.Drawing.Size(146, 56);
            this.Listboxhulpstoffen.TabIndex = 927;
            this.Listboxhulpstoffen.SelectedIndexChanged += new System.EventHandler(this.Listboxhulpstoffen_SelectedIndexChanged);
            // 
            // lblLevering
            // 
            this.lblLevering.AutoSize = true;
            this.lblLevering.Location = new System.Drawing.Point(219, 39);
            this.lblLevering.Name = "lblLevering";
            this.lblLevering.Size = new System.Drawing.Size(53, 13);
            this.lblLevering.TabIndex = 116;
            this.lblLevering.Text = "Levering:";
            this.lblLevering.Visible = false;
            // 
            // simpleButton7
            // 
            this.simpleButton7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton7.ImageOptions.Image")));
            this.simpleButton7.Location = new System.Drawing.Point(210, 86);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(149, 23);
            this.simpleButton7.TabIndex = 127;
            this.simpleButton7.Text = "Hulpstof Verwijderen";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // chkbLevering
            // 
            this.chkbLevering.AutoSize = true;
            this.chkbLevering.Checked = true;
            this.chkbLevering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbLevering.Location = new System.Drawing.Point(292, 39);
            this.chkbLevering.Name = "chkbLevering";
            this.chkbLevering.Size = new System.Drawing.Size(15, 14);
            this.chkbLevering.TabIndex = 115;
            this.chkbLevering.UseVisualStyleBackColor = true;
            this.chkbLevering.Visible = false;
            // 
            // simpleButton4
            // 
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(25, 86);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(173, 23);
            this.simpleButton4.TabIndex = 126;
            this.simpleButton4.Text = "Hulpstof Toevoegen";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "Eigenschap:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "Hulpstof:";
            // 
            // FrmHulpstofWijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 131);
            this.Controls.Add(this.groupControl6);
            this.IconOptions.Image = global::DhuyvetterBeton.Beton.Properties.Resources.DBLogo;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmHulpstofWijzigen.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.Name = "FrmHulpstofWijzigen";
            this.Text = "Hulpstof aanpassen";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHulpstof.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoeveelheidHulpstof.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Listboxhulpstoffen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cboHulpstof;
        private DevExpress.XtraEditors.TextEdit txtHoeveelheidHulpstof;
        private DevExpress.XtraEditors.ListBoxControl Listboxhulpstoffen;
        protected System.Windows.Forms.Label lblLevering;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        protected System.Windows.Forms.CheckBox chkbLevering;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}