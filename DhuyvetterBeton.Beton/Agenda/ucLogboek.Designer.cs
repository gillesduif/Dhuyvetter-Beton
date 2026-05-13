namespace DhuyvetterBeton.Beton.Agenda
{
    partial class ucLogboek
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLogboek));
            this.dataGridView1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.DTP1 = new DevExpress.XtraEditors.DateEdit();
            this.cboGebruiker = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFunctie = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ButtonZoek = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTP1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTP1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGebruiker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFunctie.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
           // this.dataGridView1.DoubleBuffered = true;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.HeaderBgColor = System.Drawing.Color.IndianRed;
            this.dataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(166, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DividerHeight = 1;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1230, 918);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Datum en tijd";
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Functie";
            this.Column2.Name = "Column2";
            this.Column2.Width = 134;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Taak";
            this.Column3.Name = "Column3";
            this.Column3.Width = 810;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Gebruiker";
            this.Column4.Name = "Column4";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.DTP1);
            this.groupControl1.Controls.Add(this.cboGebruiker);
            this.groupControl1.Controls.Add(this.cboFunctie);
            this.groupControl1.Controls.Add(this.ButtonZoek);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(384, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(748, 69);
            this.groupControl1.TabIndex = 14;
            // 
            // DTP1
            // 
            this.DTP1.EditValue = null;
            this.DTP1.Location = new System.Drawing.Point(56, 28);
            this.DTP1.Name = "DTP1";
            this.DTP1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DTP1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DTP1.Size = new System.Drawing.Size(194, 20);
            this.DTP1.TabIndex = 14;
            // 
            // cboGebruiker
            // 
            this.cboGebruiker.Location = new System.Drawing.Point(549, 30);
            this.cboGebruiker.Name = "cboGebruiker";
            this.cboGebruiker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGebruiker.Properties.Items.AddRange(new object[] {
            "Cindy",
            "Fabien",
            "Gilles",
            "Jan",
            "Loes",
            "Pedro",
            "Tania",
            "Yara"});
            this.cboGebruiker.Size = new System.Drawing.Size(143, 20);
            this.cboGebruiker.TabIndex = 70;
            // 
            // cboFunctie
            // 
            this.cboFunctie.Location = new System.Drawing.Point(316, 29);
            this.cboFunctie.Name = "cboFunctie";
            this.cboFunctie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFunctie.Properties.Items.AddRange(new object[] {
            "BESTELLINGEN",
            "OFFERTES",
            "KLANTEN",
            "WERVEN",
            "PRODUCTEN",
            "POMPEN",
            "FACTUREN",
            "PRIJZEN",
            "AGENDA",
            "CENTRALE"});
            this.cboFunctie.Size = new System.Drawing.Size(157, 20);
            this.cboFunctie.TabIndex = 69;
            // 
            // ButtonZoek
            // 
            this.ButtonZoek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonZoek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ButtonZoek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonZoek.ImageOptions.Image")));
            this.ButtonZoek.Location = new System.Drawing.Point(699, 25);
            this.ButtonZoek.Name = "ButtonZoek";
            this.ButtonZoek.Size = new System.Drawing.Size(35, 27);
            this.ButtonZoek.TabIndex = 68;
            this.ButtonZoek.Click += new System.EventHandler(this.ButtonZoek_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(489, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Gebruiker:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(269, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Functie:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Datum:";
            // 
            // simpleButton6
            // 
            this.simpleButton6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton6.ImageOptions.SvgImage")));
            this.simpleButton6.Location = new System.Drawing.Point(25, 33);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(117, 23);
            this.simpleButton6.TabIndex = 946;
            this.simpleButton6.Text = "Beginscherm";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // ucLogboek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucLogboek";
            this.Size = new System.Drawing.Size(1656, 1008);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTP1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTP1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGebruiker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFunctie.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit DTP1;
        private DevExpress.XtraEditors.ComboBoxEdit cboGebruiker;
        private DevExpress.XtraEditors.ComboBoxEdit cboFunctie;
        private DevExpress.XtraEditors.SimpleButton ButtonZoek;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
    }
}
