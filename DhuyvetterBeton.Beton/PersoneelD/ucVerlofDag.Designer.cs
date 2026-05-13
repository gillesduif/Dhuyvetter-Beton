namespace DhuyvetterBeton.Beton.PersoneelD
{
    partial class ucVerlofDag
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVerlofDag));
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.paneelAanpassen = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEindDatumWijzigen = new DevExpress.XtraEditors.DateEdit();
            this.dtpStartDatumWijzigen = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonWijzigen = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.paneelAanvraag = new DevExpress.XtraEditors.GroupControl();
            this.DateEinde = new DevExpress.XtraEditors.DateEdit();
            this.DateStart = new DevExpress.XtraEditors.DateEdit();
            this.cboPersoneel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paneelAanpassen)).BeginInit();
            this.paneelAanpassen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEindDatumWijzigen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEindDatumWijzigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDatumWijzigen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDatumWijzigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paneelAanvraag)).BeginInit();
            this.paneelAanvraag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateEinde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersoneel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.BackColor = System.Drawing.Color.Black;
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.DragDropMode = DevExpress.XtraScheduler.DragDropMode.Manual;
            this.schedulerControl1.Location = new System.Drawing.Point(7, 23);
            this.schedulerControl1.LookAndFeel.SkinName = "Office 2016 Black";
            this.schedulerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsDragDrop.DragDropMode = DevExpress.XtraScheduler.DragDropMode.Manual;
            this.schedulerControl1.OptionsView.ResourceCategories.ShowAddButton = false;
            this.schedulerControl1.OptionsView.ResourceCategories.ShowCloseButton = false;
            this.schedulerControl1.Size = new System.Drawing.Size(1959, 1028);
            this.schedulerControl1.Start = new System.DateTime(2021, 9, 20, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.Enabled = true;
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.Views.YearView.UseOptimizedScrolling = false;
            this.schedulerControl1.Click += new System.EventHandler(this.schedulerControl1_Click);
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.SystemColors.Window, "None", "&None"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))), "Important", "&Important"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))), "Business", "&Business"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))), "Personal", "&Personal"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))), "Vacation", "&Vacation"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))), "Must Attend", "Must &Attend"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))), "Travel Required", "&Travel Required"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))), "Needs Preparation", "&Needs Preparation"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))), "Birthday", "&Birthday"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))), "Anniversary", "&Anniversary"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))), "Phone Call", "Phone &Call"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.SystemColors.Window, "None", "&None"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(190))))), "Important", "&Important"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(255))))), "Business", "&Business"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(244)))), ((int)(((byte)(156))))), "Personal", "&Personal"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(228)))), ((int)(((byte)(199))))), "Vacation", "&Vacation"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(206)))), ((int)(((byte)(147))))), "Must Attend", "Must &Attend"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(244)))), ((int)(((byte)(255))))), "Travel Required", "&Travel Required"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(219)))), ((int)(((byte)(152))))), "Needs Preparation", "&Needs Preparation"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(207)))), ((int)(((byte)(233))))), "Birthday", "&Birthday"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(233)))), ((int)(((byte)(223))))), "Anniversary", "&Anniversary"));
            this.schedulerDataStorage1.Appointments.Labels.Add(new DevExpress.XtraScheduler.AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(165))))), "Phone Call", "Phone &Call"));
            // 
            // paneelAanpassen
            // 
            this.paneelAanpassen.Controls.Add(this.label1);
            this.paneelAanpassen.Controls.Add(this.dtpEindDatumWijzigen);
            this.paneelAanpassen.Controls.Add(this.dtpStartDatumWijzigen);
            this.paneelAanpassen.Controls.Add(this.simpleButton2);
            this.paneelAanpassen.Controls.Add(this.simpleButtonWijzigen);
            this.paneelAanpassen.Controls.Add(this.labelControl5);
            this.paneelAanpassen.Controls.Add(this.labelControl6);
            this.paneelAanpassen.Location = new System.Drawing.Point(1170, 1075);
            this.paneelAanpassen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.paneelAanpassen.Name = "paneelAanpassen";
            this.paneelAanpassen.Size = new System.Drawing.Size(669, 182);
            this.paneelAanpassen.TabIndex = 12;
            this.paneelAanpassen.Text = "Verlof aanpassen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 38);
            this.label1.TabIndex = 99;
            this.label1.Text = "Personeel lid";
            // 
            // dtpEindDatumWijzigen
            // 
            this.dtpEindDatumWijzigen.EditValue = null;
            this.dtpEindDatumWijzigen.Location = new System.Drawing.Point(125, 136);
            this.dtpEindDatumWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEindDatumWijzigen.Name = "dtpEindDatumWijzigen";
            this.dtpEindDatumWijzigen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEindDatumWijzigen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEindDatumWijzigen.Properties.EditFormat.FormatString = "g";
            this.dtpEindDatumWijzigen.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpEindDatumWijzigen.Properties.Mask.EditMask = "g";
            this.dtpEindDatumWijzigen.Size = new System.Drawing.Size(233, 24);
            this.dtpEindDatumWijzigen.TabIndex = 98;
            // 
            // dtpStartDatumWijzigen
            // 
            this.dtpStartDatumWijzigen.EditValue = null;
            this.dtpStartDatumWijzigen.Location = new System.Drawing.Point(125, 93);
            this.dtpStartDatumWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpStartDatumWijzigen.Name = "dtpStartDatumWijzigen";
            this.dtpStartDatumWijzigen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStartDatumWijzigen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStartDatumWijzigen.Properties.EditFormat.FormatString = "g";
            this.dtpStartDatumWijzigen.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpStartDatumWijzigen.Properties.Mask.EditMask = "g";
            this.dtpStartDatumWijzigen.Size = new System.Drawing.Size(233, 24);
            this.dtpStartDatumWijzigen.TabIndex = 97;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(470, 29);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(173, 30);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "Verwijderen";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButtonWijzigen
            // 
            this.simpleButtonWijzigen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonWijzigen.ImageOptions.Image")));
            this.simpleButtonWijzigen.Location = new System.Drawing.Point(470, 132);
            this.simpleButtonWijzigen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonWijzigen.Name = "simpleButtonWijzigen";
            this.simpleButtonWijzigen.Size = new System.Drawing.Size(173, 30);
            this.simpleButtonWijzigen.TabIndex = 6;
            this.simpleButtonWijzigen.Text = "Wijzigen";
            this.simpleButtonWijzigen.Click += new System.EventHandler(this.simpleButtonWijzigen_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(41, 141);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(69, 17);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Eind datum:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(41, 97);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(71, 17);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Start datum:";
            // 
            // paneelAanvraag
            // 
            this.paneelAanvraag.Controls.Add(this.DateEinde);
            this.paneelAanvraag.Controls.Add(this.DateStart);
            this.paneelAanvraag.Controls.Add(this.cboPersoneel);
            this.paneelAanvraag.Controls.Add(this.simpleButton1);
            this.paneelAanvraag.Controls.Add(this.labelControl3);
            this.paneelAanvraag.Controls.Add(this.labelControl2);
            this.paneelAanvraag.Controls.Add(this.labelControl1);
            this.paneelAanvraag.Location = new System.Drawing.Point(96, 1075);
            this.paneelAanvraag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.paneelAanvraag.Name = "paneelAanvraag";
            this.paneelAanvraag.Size = new System.Drawing.Size(623, 182);
            this.paneelAanvraag.TabIndex = 14;
            this.paneelAanvraag.Text = "Verlof toevoegen";
            // 
            // DateEinde
            // 
            this.DateEinde.EditValue = null;
            this.DateEinde.Location = new System.Drawing.Point(118, 128);
            this.DateEinde.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateEinde.Name = "DateEinde";
            this.DateEinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEinde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEinde.Properties.EditFormat.FormatString = "g";
            this.DateEinde.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateEinde.Properties.Mask.EditMask = "g";
            this.DateEinde.Size = new System.Drawing.Size(233, 24);
            this.DateEinde.TabIndex = 96;
            // 
            // DateStart
            // 
            this.DateStart.EditValue = null;
            this.DateStart.Location = new System.Drawing.Point(118, 84);
            this.DateStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DateStart.Name = "DateStart";
            this.DateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateStart.Properties.EditFormat.FormatString = "g";
            this.DateStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateStart.Properties.Mask.EditMask = "g";
            this.DateStart.Size = new System.Drawing.Size(233, 24);
            this.DateStart.TabIndex = 95;
            // 
            // cboPersoneel
            // 
            this.cboPersoneel.Location = new System.Drawing.Point(118, 38);
            this.cboPersoneel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPersoneel.Name = "cboPersoneel";
            this.cboPersoneel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPersoneel.Size = new System.Drawing.Size(380, 24);
            this.cboPersoneel.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(425, 119);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(173, 30);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Toevoegen";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 132);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 17);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Eind datum:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(34, 88);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Start datum:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 42);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Persoon:";
            // 
            // ucVerlofDag
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paneelAanvraag);
            this.Controls.Add(this.paneelAanpassen);
            this.Controls.Add(this.schedulerControl1);
            this.Name = "ucVerlofDag";
            this.Size = new System.Drawing.Size(1932, 1318);
            this.Load += new System.EventHandler(this.ucVerlofDag_Load);
            this.Click += new System.EventHandler(this.ucVerlofDag_Click);
            this.DoubleClick += new System.EventHandler(this.ucVerlofDag_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paneelAanpassen)).EndInit();
            this.paneelAanpassen.ResumeLayout(false);
            this.paneelAanpassen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEindDatumWijzigen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEindDatumWijzigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDatumWijzigen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDatumWijzigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paneelAanvraag)).EndInit();
            this.paneelAanvraag.ResumeLayout(false);
            this.paneelAanvraag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateEinde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersoneel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraEditors.GroupControl paneelAanpassen;
        private DevExpress.XtraEditors.DateEdit dtpEindDatumWijzigen;
        private DevExpress.XtraEditors.DateEdit dtpStartDatumWijzigen;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonWijzigen;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl paneelAanvraag;
        private DevExpress.XtraEditors.DateEdit DateEinde;
        private DevExpress.XtraEditors.DateEdit DateStart;
        private DevExpress.XtraEditors.ComboBoxEdit cboPersoneel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
