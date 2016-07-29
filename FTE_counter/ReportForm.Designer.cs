namespace FTE_counter
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.StatANDRep = new System.Windows.Forms.TabControl();
            this.ReportByMonth = new System.Windows.Forms.TabPage();
            this.CountByUser = new System.Windows.Forms.Button();
            this.LoadToExcel = new System.Windows.Forms.Button();
            this.dataGridViewConRep = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.work_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emploer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hours_worked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InTeleph_Average_talk_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InTeleph_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InTeleph_FTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_inc_frst_ln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_inc_accesses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_inc_disp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_inc_fte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_zno_frst_ln = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_zno_dost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_zno_disp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_zno_fte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_znr_FRST_LN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_znr_Accesses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_znr_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_znr_FTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_zno_FRST_LN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_zno_Accesses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_zno_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sd_zno_FTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_routes_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sm_routes_FTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonalStatistics = new System.Windows.Forms.TabPage();
            this.UniversalReport = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.UniCountAndView = new System.Windows.Forms.Button();
            this.UNIdataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatANDRep.SuspendLayout();
            this.ReportByMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConRep)).BeginInit();
            this.UniversalReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UNIdataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatANDRep
            // 
            this.StatANDRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatANDRep.Controls.Add(this.ReportByMonth);
            this.StatANDRep.Controls.Add(this.PersonalStatistics);
            this.StatANDRep.Controls.Add(this.UniversalReport);
            this.StatANDRep.Location = new System.Drawing.Point(2, 24);
            this.StatANDRep.Name = "StatANDRep";
            this.StatANDRep.SelectedIndex = 0;
            this.StatANDRep.Size = new System.Drawing.Size(729, 360);
            this.StatANDRep.TabIndex = 0;
            // 
            // ReportByMonth
            // 
            this.ReportByMonth.Controls.Add(this.CountByUser);
            this.ReportByMonth.Controls.Add(this.LoadToExcel);
            this.ReportByMonth.Controls.Add(this.dataGridViewConRep);
            this.ReportByMonth.Location = new System.Drawing.Point(4, 22);
            this.ReportByMonth.Name = "ReportByMonth";
            this.ReportByMonth.Padding = new System.Windows.Forms.Padding(3);
            this.ReportByMonth.Size = new System.Drawing.Size(721, 334);
            this.ReportByMonth.TabIndex = 0;
            this.ReportByMonth.Text = "Отчёт за месяц.";
            this.ReportByMonth.UseVisualStyleBackColor = true;
            // 
            // CountByUser
            // 
            this.CountByUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CountByUser.Location = new System.Drawing.Point(383, 3);
            this.CountByUser.Name = "CountByUser";
            this.CountByUser.Size = new System.Drawing.Size(184, 23);
            this.CountByUser.TabIndex = 2;
            this.CountByUser.Text = "Рассчитать по сотрудникам";
            this.CountByUser.UseVisualStyleBackColor = true;
            this.CountByUser.Click += new System.EventHandler(this.CountByUser_Click);
            // 
            // LoadToExcel
            // 
            this.LoadToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadToExcel.Location = new System.Drawing.Point(573, 3);
            this.LoadToExcel.Name = "LoadToExcel";
            this.LoadToExcel.Size = new System.Drawing.Size(145, 23);
            this.LoadToExcel.TabIndex = 1;
            this.LoadToExcel.Text = "Загрузить в Excel";
            this.LoadToExcel.UseVisualStyleBackColor = true;
            this.LoadToExcel.Click += new System.EventHandler(this.LoadToExcel_Click);
            // 
            // dataGridViewConRep
            // 
            this.dataGridViewConRep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewConRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.work_group,
            this.emploer,
            this.hours_worked,
            this.InTeleph_Average_talk_time,
            this.InTeleph_count,
            this.InTeleph_FTE,
            this.sm_inc_frst_ln,
            this.sm_inc_accesses,
            this.sm_inc_disp,
            this.sm_inc_fte,
            this.sm_zno_frst_ln,
            this.sm_zno_dost,
            this.sm_zno_disp,
            this.sm_zno_fte,
            this.sd_znr_FRST_LN,
            this.sd_znr_Accesses,
            this.sd_znr_DISP,
            this.sd_znr_FTE,
            this.sd_zno_FRST_LN,
            this.sd_zno_Accesses,
            this.sd_zno_DISP,
            this.sd_zno_FTE,
            this.sm_routes_count,
            this.sm_routes_FTE});
            this.dataGridViewConRep.Location = new System.Drawing.Point(3, 29);
            this.dataGridViewConRep.Name = "dataGridViewConRep";
            this.dataGridViewConRep.Size = new System.Drawing.Size(715, 302);
            this.dataGridViewConRep.TabIndex = 0;
            this.dataGridViewConRep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewConRep_CellContentClick);
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            this.Number.Width = 43;
            // 
            // work_group
            // 
            this.work_group.HeaderText = "Группа";
            this.work_group.Name = "work_group";
            // 
            // emploer
            // 
            this.emploer.HeaderText = "ФИО";
            this.emploer.Name = "emploer";
            // 
            // hours_worked
            // 
            this.hours_worked.HeaderText = "Факт часов отработано за период";
            this.hours_worked.Name = "hours_worked";
            // 
            // InTeleph_Average_talk_time
            // 
            this.InTeleph_Average_talk_time.HeaderText = "Среднее время разговора";
            this.InTeleph_Average_talk_time.Name = "InTeleph_Average_talk_time";
            // 
            // InTeleph_count
            // 
            this.InTeleph_count.HeaderText = "Кол-во принятых исходящих звонков ";
            this.InTeleph_count.Name = "InTeleph_count";
            // 
            // InTeleph_FTE
            // 
            this.InTeleph_FTE.HeaderText = "ПШЕ телефон";
            this.InTeleph_FTE.Name = "InTeleph_FTE";
            // 
            // sm_inc_frst_ln
            // 
            this.sm_inc_frst_ln.HeaderText = "Выполнено инцидентов в SM - СЗБ 1 лини";
            this.sm_inc_frst_ln.Name = "sm_inc_frst_ln";
            // 
            // sm_inc_accesses
            // 
            this.sm_inc_accesses.HeaderText = "Выполнено инцидентов в SM - СЗБ доступы";
            this.sm_inc_accesses.Name = "sm_inc_accesses";
            // 
            // sm_inc_disp
            // 
            this.sm_inc_disp.HeaderText = "Выполнено инцидентов в SM - СЗБ Диспетчерская ИТ";
            this.sm_inc_disp.Name = "sm_inc_disp";
            // 
            // sm_inc_fte
            // 
            this.sm_inc_fte.HeaderText = "SM инциденты ПШЕ";
            this.sm_inc_fte.Name = "sm_inc_fte";
            // 
            // sm_zno_frst_ln
            // 
            this.sm_zno_frst_ln.HeaderText = "Выполнено ЗНО в SM - СЗБ 1 лини";
            this.sm_zno_frst_ln.Name = "sm_zno_frst_ln";
            // 
            // sm_zno_dost
            // 
            this.sm_zno_dost.HeaderText = "Выполнено ЗНО в SM - СЗБ доступы";
            this.sm_zno_dost.Name = "sm_zno_dost";
            // 
            // sm_zno_disp
            // 
            this.sm_zno_disp.HeaderText = "Выполнено ЗНО в SM - СЗБ Диспетчерская ИТ";
            this.sm_zno_disp.Name = "sm_zno_disp";
            // 
            // sm_zno_fte
            // 
            this.sm_zno_fte.HeaderText = "SM ЗНО ПШЕ";
            this.sm_zno_fte.Name = "sm_zno_fte";
            // 
            // sd_znr_FRST_LN
            // 
            this.sd_znr_FRST_LN.HeaderText = "Выполнено ЗНР в SD - СЗБ 1 линия (sd)";
            this.sd_znr_FRST_LN.Name = "sd_znr_FRST_LN";
            // 
            // sd_znr_Accesses
            // 
            this.sd_znr_Accesses.HeaderText = "Выполнено ЗНР в SD - СЗБ доступы (sd)";
            this.sd_znr_Accesses.Name = "sd_znr_Accesses";
            // 
            // sd_znr_DISP
            // 
            this.sd_znr_DISP.HeaderText = "Выполнено ЗНР в SD - СЗБ Диспетчерская ИТ (sd)";
            this.sd_znr_DISP.Name = "sd_znr_DISP";
            // 
            // sd_znr_FTE
            // 
            this.sd_znr_FTE.HeaderText = "SD ЗНР - ПШЕ";
            this.sd_znr_FTE.Name = "sd_znr_FTE";
            // 
            // sd_zno_FRST_LN
            // 
            this.sd_zno_FRST_LN.HeaderText = "Выполнено ЗНО в SD - СЗБ 1 линия (sd)";
            this.sd_zno_FRST_LN.Name = "sd_zno_FRST_LN";
            // 
            // sd_zno_Accesses
            // 
            this.sd_zno_Accesses.HeaderText = "Выполнено ЗНО в SD - СЗБ доступы (sd)";
            this.sd_zno_Accesses.Name = "sd_zno_Accesses";
            // 
            // sd_zno_DISP
            // 
            this.sd_zno_DISP.HeaderText = "Выполнено ЗНО в SD - СЗБ Диспетчерская ИТ (sd)";
            this.sd_zno_DISP.Name = "sd_zno_DISP";
            // 
            // sd_zno_FTE
            // 
            this.sd_zno_FTE.HeaderText = "SD ЗНО - ПШЕ";
            this.sd_zno_FTE.Name = "sd_zno_FTE";
            // 
            // sm_routes_count
            // 
            this.sm_routes_count.HeaderText = "SM Маршрутизация запросов - Кол-во";
            this.sm_routes_count.Name = "sm_routes_count";
            // 
            // sm_routes_FTE
            // 
            this.sm_routes_FTE.HeaderText = "SM Маршрутизация запросов  - ПШЕ";
            this.sm_routes_FTE.Name = "sm_routes_FTE";
            // 
            // PersonalStatistics
            // 
            this.PersonalStatistics.Location = new System.Drawing.Point(4, 22);
            this.PersonalStatistics.Name = "PersonalStatistics";
            this.PersonalStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.PersonalStatistics.Size = new System.Drawing.Size(721, 334);
            this.PersonalStatistics.TabIndex = 1;
            this.PersonalStatistics.Text = "Индивидуальный отчёт.";
            this.PersonalStatistics.UseVisualStyleBackColor = true;
            // 
            // UniversalReport
            // 
            this.UniversalReport.Controls.Add(this.button2);
            this.UniversalReport.Controls.Add(this.UniCountAndView);
            this.UniversalReport.Controls.Add(this.UNIdataGrid);
            this.UniversalReport.Location = new System.Drawing.Point(4, 22);
            this.UniversalReport.Name = "UniversalReport";
            this.UniversalReport.Padding = new System.Windows.Forms.Padding(3);
            this.UniversalReport.Size = new System.Drawing.Size(721, 334);
            this.UniversalReport.TabIndex = 2;
            this.UniversalReport.Text = "Универсальный отчёт на основе загруженных данных";
            this.UniversalReport.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(571, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выгрузить в Excel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // UniCountAndView
            // 
            this.UniCountAndView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UniCountAndView.Location = new System.Drawing.Point(310, 3);
            this.UniCountAndView.Name = "UniCountAndView";
            this.UniCountAndView.Size = new System.Drawing.Size(255, 23);
            this.UniCountAndView.TabIndex = 1;
            this.UniCountAndView.Text = "Рассчитать на основе загруженных данных";
            this.UniCountAndView.UseVisualStyleBackColor = true;
            this.UniCountAndView.Click += new System.EventHandler(this.UniCountAndView_Click);
            // 
            // UNIdataGrid
            // 
            this.UNIdataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UNIdataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UNIdataGrid.Location = new System.Drawing.Point(3, 32);
            this.UNIdataGrid.Name = "UNIdataGrid";
            this.UNIdataGrid.Size = new System.Drawing.Size(715, 299);
            this.UNIdataGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 386);
            this.Controls.Add(this.StatANDRep);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReportForm";
            this.ShowIcon = false;
            this.Text = "FTE Counter";
            this.StatANDRep.ResumeLayout(false);
            this.ReportByMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConRep)).EndInit();
            this.UniversalReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UNIdataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl StatANDRep;
        private System.Windows.Forms.TabPage ReportByMonth;
        private System.Windows.Forms.TabPage PersonalStatistics;
        private System.Windows.Forms.DataGridView dataGridViewConRep;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.Button LoadToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn work_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn emploer;
        private System.Windows.Forms.DataGridViewTextBoxColumn hours_worked;
        private System.Windows.Forms.DataGridViewTextBoxColumn InTeleph_Average_talk_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn InTeleph_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn InTeleph_FTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_inc_frst_ln;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_inc_accesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_inc_disp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_inc_fte;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_zno_frst_ln;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_zno_dost;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_zno_disp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_zno_fte;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_znr_FRST_LN;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_znr_Accesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_znr_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_znr_FTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_zno_FRST_LN;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_zno_Accesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_zno_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn sd_zno_FTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_routes_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn sm_routes_FTE;
        private System.Windows.Forms.Button CountByUser;
        private System.Windows.Forms.TabPage UniversalReport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button UniCountAndView;
        private System.Windows.Forms.DataGridView UNIdataGrid;
    }
}