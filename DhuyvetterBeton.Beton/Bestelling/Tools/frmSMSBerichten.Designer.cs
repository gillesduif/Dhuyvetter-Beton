
namespace DhuyvetterBeton.Beton.Bestelling.Tools
{
    partial class frmSMSBerichten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSBerichten));
            this.listSMSen = new DevExpress.XtraEditors.ListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.listSMSen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listSMSen
            // 
            this.listSMSen.Dock = System.Windows.Forms.DockStyle.Top;
            this.listSMSen.Location = new System.Drawing.Point(0, 0);
            this.listSMSen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listSMSen.Name = "listSMSen";
            this.listSMSen.Size = new System.Drawing.Size(801, 47);
            this.listSMSen.TabIndex = 1;
            this.listSMSen.SelectedIndexChanged += new System.EventHandler(this.listSMSen_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 472);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(801, 35);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(287, 23);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(231, 38);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "SMS item verwijderen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // richEditControl1
            // 
            this.richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.richEditControl1.Location = new System.Drawing.Point(0, 47);
            this.richEditControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(801, 425);
            this.richEditControl1.TabIndex = 3;
            // 
            // frmSMSBerichten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 507);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.listSMSen);
            this.IconOptions.Image = global::DhuyvetterBeton.Beton.Properties.Resources.DBLogo;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmSMSBerichten.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmSMSBerichten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SMS berichten";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSMSBerichten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listSMSen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listSMSen;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}