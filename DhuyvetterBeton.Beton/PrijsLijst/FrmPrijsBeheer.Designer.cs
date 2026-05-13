namespace DhuyvetterBeton.Beton.PrijsLijst
{
    partial class FrmPrijsBeheer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrijsBeheer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtParticulier = new DevExpress.XtraEditors.TextEdit();
            this.txtAannemer = new DevExpress.XtraEditors.TextEdit();
            this.txtPrNaam = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewBestellingen = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtParticulier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAannemer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrNaam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBestellingen)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(571, 40);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtParticulier);
            this.groupControl1.Controls.Add(this.txtAannemer);
            this.groupControl1.Controls.Add(this.txtPrNaam);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Location = new System.Drawing.Point(29, 43);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(520, 137);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Details";
            // 
            // txtParticulier
            // 
            this.txtParticulier.Location = new System.Drawing.Point(365, 62);
            this.txtParticulier.Name = "txtParticulier";
            this.txtParticulier.Size = new System.Drawing.Size(68, 20);
            this.txtParticulier.TabIndex = 19;
            // 
            // txtAannemer
            // 
            this.txtAannemer.Location = new System.Drawing.Point(119, 62);
            this.txtAannemer.Name = "txtAannemer";
            this.txtAannemer.Size = new System.Drawing.Size(68, 20);
            this.txtAannemer.TabIndex = 18;
            // 
            // txtPrNaam
            // 
            this.txtPrNaam.Location = new System.Drawing.Point(119, 37);
            this.txtPrNaam.Name = "txtPrNaam";
            this.txtPrNaam.Size = new System.Drawing.Size(314, 20);
            this.txtPrNaam.TabIndex = 17;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(405, 99);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 23);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "Aanpassen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Particulier prijs:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Product Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Aannemer prijs:";
            // 
            // dataGridViewBestellingen
            // 
            this.dataGridViewBestellingen.AllowUserToAddRows = false;
            this.dataGridViewBestellingen.AllowUserToDeleteRows = false;
            this.dataGridViewBestellingen.AllowUserToResizeColumns = false;
            this.dataGridViewBestellingen.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewBestellingen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBestellingen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dataGridViewBestellingen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBestellingen.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewBestellingen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBestellingen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBestellingen.ColumnHeadersHeight = 30;
            this.dataGridViewBestellingen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBestellingen.DefaultCellStyle = dataGridViewCellStyle3;
         //   this.dataGridViewBestellingen.DoubleBuffered = true;
            this.dataGridViewBestellingen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewBestellingen.EnableHeadersVisualStyles = false;
            this.dataGridViewBestellingen.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.dataGridViewBestellingen.HeaderForeColor = System.Drawing.Color.White;
            this.dataGridViewBestellingen.Location = new System.Drawing.Point(29, 186);
            this.dataGridViewBestellingen.Name = "dataGridViewBestellingen";
            this.dataGridViewBestellingen.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBestellingen.RowHeadersVisible = false;
            this.dataGridViewBestellingen.RowTemplate.DividerHeight = 1;
            this.dataGridViewBestellingen.RowTemplate.Height = 30;
            this.dataGridViewBestellingen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBestellingen.Size = new System.Drawing.Size(520, 584);
            this.dataGridViewBestellingen.TabIndex = 926;
            this.dataGridViewBestellingen.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewBestellingen_CellFormatting);
            this.dataGridViewBestellingen.SelectionChanged += new System.EventHandler(this.dataGridViewBestellingen_SelectionChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Formule";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Aannemer";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Particulier";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // FrmPrijsBeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 774);
            this.Controls.Add(this.dataGridViewBestellingen);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrijsBeheer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijs beheer";
            this.Load += new System.EventHandler(this.FrmNieuwePrijs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtParticulier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAannemer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrNaam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBestellingen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtParticulier;
        private DevExpress.XtraEditors.TextEdit txtAannemer;
        private DevExpress.XtraEditors.TextEdit txtPrNaam;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGridViewBestellingen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}