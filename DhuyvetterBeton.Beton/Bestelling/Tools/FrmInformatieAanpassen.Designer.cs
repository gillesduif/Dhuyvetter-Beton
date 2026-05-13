
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    partial class FrmInformatieAanpassen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformatieAanpassen));
            this.txtLeveringWijze = new DevExpress.XtraEditors.TextEdit();
            this.cboLoswijze = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtComment = new DevExpress.XtraEditors.MemoEdit();
            this.labelOpmerkingSave = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbLevering = new System.Windows.Forms.CheckBox();
            this.lblLevering = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelUUR = new System.Windows.Forms.Label();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.label24 = new System.Windows.Forms.Label();
            this.dtpDatum = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeveringWijze.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoswijze.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLeveringWijze
            // 
            this.txtLeveringWijze.Location = new System.Drawing.Point(96, 45);
            this.txtLeveringWijze.Name = "txtLeveringWijze";
            this.txtLeveringWijze.Size = new System.Drawing.Size(244, 20);
            this.txtLeveringWijze.TabIndex = 114;
            // 
            // cboLoswijze
            // 
            this.cboLoswijze.Location = new System.Drawing.Point(96, 72);
            this.cboLoswijze.Name = "cboLoswijze";
            this.cboLoswijze.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoswijze.Properties.Items.AddRange(new object[] {
            "Pomp",
            "Rechtstreeks",
            "Losbuis",
            "Kubel",
            "Kruiwagen",
            "Andere"});
            this.cboLoswijze.Size = new System.Drawing.Size(244, 20);
            this.cboLoswijze.TabIndex = 113;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(96, 97);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(244, 111);
            this.txtComment.TabIndex = 111;
            // 
            // labelOpmerkingSave
            // 
            this.labelOpmerkingSave.AutoSize = true;
            this.labelOpmerkingSave.Location = new System.Drawing.Point(165, 165);
            this.labelOpmerkingSave.Name = "labelOpmerkingSave";
            this.labelOpmerkingSave.Size = new System.Drawing.Size(44, 13);
            this.labelOpmerkingSave.TabIndex = 100;
            this.labelOpmerkingSave.Text = "label22";
            this.labelOpmerkingSave.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Opmerking:";
            // 
            // chkbLevering
            // 
            this.chkbLevering.AutoSize = true;
            this.chkbLevering.BackColor = System.Drawing.Color.Transparent;
            this.chkbLevering.Checked = true;
            this.chkbLevering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbLevering.Location = new System.Drawing.Point(199, 152);
            this.chkbLevering.Name = "chkbLevering";
            this.chkbLevering.Size = new System.Drawing.Size(15, 14);
            this.chkbLevering.TabIndex = 91;
            this.chkbLevering.UseVisualStyleBackColor = false;
            this.chkbLevering.Visible = false;
            // 
            // lblLevering
            // 
            this.lblLevering.AutoSize = true;
            this.lblLevering.Location = new System.Drawing.Point(141, 152);
            this.lblLevering.Name = "lblLevering";
            this.lblLevering.Size = new System.Drawing.Size(53, 13);
            this.lblLevering.TabIndex = 92;
            this.lblLevering.Text = "Levering:";
            this.lblLevering.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Levering wijze:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "Los wijze:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(222, 235);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(123, 23);
            this.simpleButton1.TabIndex = 920;
            this.simpleButton1.Text = "Aanpassen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelUUR
            // 
            this.labelUUR.AutoSize = true;
            this.labelUUR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUUR.Location = new System.Drawing.Point(325, 22);
            this.labelUUR.Name = "labelUUR";
            this.labelUUR.Size = new System.Drawing.Size(12, 13);
            this.labelUUR.TabIndex = 924;
            this.labelUUR.Text = "?";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(296, 22);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(22, 13);
            this.labelControl5.TabIndex = 923;
            this.labelControl5.Text = "Tijd:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 22);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(75, 13);
            this.label24.TabIndex = 922;
            this.label24.Text = "Datum + tijd:";
            // 
            // dtpDatum
            // 
            this.dtpDatum.EditValue = null;
            this.dtpDatum.Location = new System.Drawing.Point(96, 19);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDatum.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDatum.Properties.EditFormat.FormatString = "g";
            this.dtpDatum.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDatum.Properties.MaskSettings.Set("mask", "g");
            this.dtpDatum.Size = new System.Drawing.Size(190, 20);
            this.dtpDatum.TabIndex = 921;
            this.dtpDatum.EditValueChanged += new System.EventHandler(this.dtpDatum_EditValueChanged);
            // 
            // FrmInformatieAanpassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 262);
            this.Controls.Add(this.labelUUR);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtLeveringWijze);
            this.Controls.Add(this.cboLoswijze);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelOpmerkingSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLevering);
            this.Controls.Add(this.chkbLevering);
            this.IconOptions.Image = global::DhuyvetterBeton.Beton.Properties.Resources.DBLogo;
            this.MaximizeBox = false;
            this.Name = "FrmInformatieAanpassen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informatie aanpassen";
            ((System.ComponentModel.ISupportInitialize)(this.txtLeveringWijze.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoswijze.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDatum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtLeveringWijze;
        private DevExpress.XtraEditors.ComboBoxEdit cboLoswijze;
        private DevExpress.XtraEditors.MemoEdit txtComment;
        private System.Windows.Forms.Label labelOpmerkingSave;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.CheckBox chkbLevering;
        protected System.Windows.Forms.Label lblLevering;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label labelUUR;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label label24;
        private DevExpress.XtraEditors.DateEdit dtpDatum;
    }
}