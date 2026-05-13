namespace AfvoerOfInvoer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cboKlanten = new System.Windows.Forms.ComboBox();
            this.cboInvoer = new System.Windows.Forms.ComboBox();
            this.cboFormule = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.dtp3 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTarra = new System.Windows.Forms.TextBox();
            this.txtBruto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNummerplaat = new System.Windows.Forms.TextBox();
            this.txtChauffeur = new System.Windows.Forms.TextBox();
            this.txtNetto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductiebatchnr = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboKlanten
            // 
            this.cboKlanten.FormattingEnabled = true;
            this.cboKlanten.Location = new System.Drawing.Point(118, 19);
            this.cboKlanten.Name = "cboKlanten";
            this.cboKlanten.Size = new System.Drawing.Size(330, 21);
            this.cboKlanten.TabIndex = 0;
            this.cboKlanten.SelectedIndexChanged += new System.EventHandler(this.cboKlanten_SelectedIndexChanged);
            // 
            // cboInvoer
            // 
            this.cboInvoer.FormattingEnabled = true;
            this.cboInvoer.Items.AddRange(new object[] {
            "Aanvoer",
            "Afvoer"});
            this.cboInvoer.Location = new System.Drawing.Point(118, 55);
            this.cboInvoer.Name = "cboInvoer";
            this.cboInvoer.Size = new System.Drawing.Size(330, 21);
            this.cboInvoer.TabIndex = 1;
            this.cboInvoer.SelectedIndexChanged += new System.EventHandler(this.cboInvoer_SelectedIndexChanged);
            // 
            // cboFormule
            // 
            this.cboFormule.FormattingEnabled = true;
            this.cboFormule.Location = new System.Drawing.Point(103, 289);
            this.cboFormule.Name = "cboFormule";
            this.cboFormule.Size = new System.Drawing.Size(244, 21);
            this.cboFormule.TabIndex = 2;
            this.cboFormule.SelectedIndexChanged += new System.EventHandler(this.cboFormule_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Klant:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aanvoer/Afvoer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Formule:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(579, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Toevoegen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(688, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1189, 499);
            this.dataGridView1.TabIndex = 9;
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(440, 325);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(195, 20);
            this.dtp1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ton:";
            // 
            // txtTon
            // 
            this.txtTon.Location = new System.Drawing.Point(103, 325);
            this.txtTon.Name = "txtTon";
            this.txtTon.Size = new System.Drawing.Size(183, 20);
            this.txtTon.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Datum:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtProductiebatchnr);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNetto);
            this.groupBox1.Controls.Add(this.txtChauffeur);
            this.groupBox1.Controls.Add(this.txtNummerplaat);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtBruto);
            this.groupBox1.Controls.Add(this.txtTarra);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboKlanten);
            this.groupBox1.Controls.Add(this.txtTon);
            this.groupBox1.Controls.Add(this.cboInvoer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboFormule);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 394);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(83, 28);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(195, 20);
            this.dtp2.TabIndex = 14;
            // 
            // dtp3
            // 
            this.dtp3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp3.Location = new System.Drawing.Point(360, 28);
            this.dtp3.Name = "dtp3";
            this.dtp3.Size = new System.Drawing.Size(195, 20);
            this.dtp3.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Begin datum:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Eind datum:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(561, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Zoeken";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.dtp2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtp3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 71);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Chauffeur:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Nummerplaat:";
            // 
            // txtTarra
            // 
            this.txtTarra.Location = new System.Drawing.Point(164, 218);
            this.txtTarra.Name = "txtTarra";
            this.txtTarra.Size = new System.Drawing.Size(183, 20);
            this.txtTarra.TabIndex = 20;
            // 
            // txtBruto
            // 
            this.txtBruto.Location = new System.Drawing.Point(164, 182);
            this.txtBruto.Name = "txtBruto";
            this.txtBruto.Size = new System.Drawing.Size(183, 20);
            this.txtBruto.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "1ste weging + uur (bruto): ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "2de weging + uur (tarra): ";
            // 
            // txtNummerplaat
            // 
            this.txtNummerplaat.Location = new System.Drawing.Point(103, 119);
            this.txtNummerplaat.Name = "txtNummerplaat";
            this.txtNummerplaat.Size = new System.Drawing.Size(145, 20);
            this.txtNummerplaat.TabIndex = 24;
            // 
            // txtChauffeur
            // 
            this.txtChauffeur.Location = new System.Drawing.Point(103, 146);
            this.txtChauffeur.Name = "txtChauffeur";
            this.txtChauffeur.Size = new System.Drawing.Size(145, 20);
            this.txtChauffeur.TabIndex = 25;
            // 
            // txtNetto
            // 
            this.txtNetto.Location = new System.Drawing.Point(103, 253);
            this.txtNetto.Name = "txtNetto";
            this.txtNetto.Size = new System.Drawing.Size(244, 20);
            this.txtNetto.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Netto:";
            // 
            // txtProductiebatchnr
            // 
            this.txtProductiebatchnr.Location = new System.Drawing.Point(118, 93);
            this.txtProductiebatchnr.Name = "txtProductiebatchnr";
            this.txtProductiebatchnr.Size = new System.Drawing.Size(130, 20);
            this.txtProductiebatchnr.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Productiebatchnr:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Afdrukken";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1876, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D\'huyvetter beton  - Invoer of Afvoer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKlanten;
        private System.Windows.Forms.ComboBox cboInvoer;
        private System.Windows.Forms.ComboBox cboFormule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProductiebatchnr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNetto;
        private System.Windows.Forms.TextBox txtChauffeur;
        private System.Windows.Forms.TextBox txtNummerplaat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBruto;
        private System.Windows.Forms.TextBox txtTarra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

