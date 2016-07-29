namespace FTE_counter
{
    partial class ManageForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.DBOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.подключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Options = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Save = new System.Windows.Forms.Button();
            this.LoadDataFromFile = new System.Windows.Forms.Button();
            this.EditEmployeeTable = new System.Windows.Forms.Button();
            this.FindAllUsers = new System.Windows.Forms.Button();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Prepare = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ViewCangetTabels = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVCount_DB = new System.Windows.Forms.DataGridView();
            this.emploer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number_of_jobs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.dBDataLoaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.smznoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sdznoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCount_DB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataLoaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smznoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sdznoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadData,
            this.DBOptions,
            this.Options});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // LoadData
            // 
            this.LoadData.Name = "LoadData";
            this.LoadData.Size = new System.Drawing.Size(165, 22);
            this.LoadData.Text = "Загрузка данных";
            // 
            // DBOptions
            // 
            this.DBOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьToolStripMenuItem,
            this.отключитьToolStripMenuItem});
            this.DBOptions.Name = "DBOptions";
            this.DBOptions.Size = new System.Drawing.Size(165, 22);
            this.DBOptions.Text = "Действия с БД";
            // 
            // подключитьToolStripMenuItem
            // 
            this.подключитьToolStripMenuItem.Name = "подключитьToolStripMenuItem";
            this.подключитьToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.подключитьToolStripMenuItem.Text = "Подключить";
            // 
            // отключитьToolStripMenuItem
            // 
            this.отключитьToolStripMenuItem.Name = "отключитьToolStripMenuItem";
            this.отключитьToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.отключитьToolStripMenuItem.Text = "Отключить";
            // 
            // Options
            // 
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(165, 22);
            this.Options.Text = "Настройки";
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 284);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Save);
            this.tabPage1.Controls.Add(this.LoadDataFromFile);
            this.tabPage1.Controls.Add(this.EditEmployeeTable);
            this.tabPage1.Controls.Add(this.FindAllUsers);
            this.tabPage1.Controls.Add(this.dataGridViewEmployees);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные о сотрудниках в выгрузке";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(333, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // LoadDataFromFile
            // 
            this.LoadDataFromFile.Location = new System.Drawing.Point(204, 3);
            this.LoadDataFromFile.Name = "LoadDataFromFile";
            this.LoadDataFromFile.Size = new System.Drawing.Size(123, 23);
            this.LoadDataFromFile.TabIndex = 3;
            this.LoadDataFromFile.Text = "Загрузить из файла";
            this.LoadDataFromFile.UseVisualStyleBackColor = true;
            this.LoadDataFromFile.Click += new System.EventHandler(this.LoadDataFromFile_Click);
            // 
            // EditEmployeeTable
            // 
            this.EditEmployeeTable.Location = new System.Drawing.Point(90, 3);
            this.EditEmployeeTable.Name = "EditEmployeeTable";
            this.EditEmployeeTable.Size = new System.Drawing.Size(108, 23);
            this.EditEmployeeTable.TabIndex = 2;
            this.EditEmployeeTable.Text = "Редактировать";
            this.EditEmployeeTable.UseVisualStyleBackColor = true;
            // 
            // FindAllUsers
            // 
            this.FindAllUsers.Location = new System.Drawing.Point(3, 3);
            this.FindAllUsers.Name = "FindAllUsers";
            this.FindAllUsers.Size = new System.Drawing.Size(81, 23);
            this.FindAllUsers.TabIndex = 1;
            this.FindAllUsers.Text = "Обновить";
            this.FindAllUsers.UseVisualStyleBackColor = true;
            this.FindAllUsers.Click += new System.EventHandler(this.FindAllUsers_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 32);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(677, 220);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Prepare);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(683, 258);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Объединённая таблица по выполненным задачам.";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Prepare
            // 
            this.Prepare.Location = new System.Drawing.Point(497, 3);
            this.Prepare.Name = "Prepare";
            this.Prepare.Size = new System.Drawing.Size(183, 23);
            this.Prepare.TabIndex = 1;
            this.Prepare.Text = "Рассчитать по сотрудникам";
            this.Prepare.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 32);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(677, 226);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ViewCangetTabels);
            this.tabPage4.Controls.Add(this.comboBox2);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.DGVCount_DB);
            this.tabPage4.Controls.Add(this.comboBoxTables);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(683, 258);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Обзор выгрузки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ViewCangetTabels
            // 
            this.ViewCangetTabels.Enabled = false;
            this.ViewCangetTabels.Location = new System.Drawing.Point(557, 4);
            this.ViewCangetTabels.Name = "ViewCangetTabels";
            this.ViewCangetTabels.Size = new System.Drawing.Size(107, 23);
            this.ViewCangetTabels.TabIndex = 5;
            this.ViewCangetTabels.Text = "Отобразить";
            this.ViewCangetTabels.UseVisualStyleBackColor = true;
            this.ViewCangetTabels.Click += new System.EventHandler(this.ViewCangetTabels_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(368, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(183, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "За период:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выгрузка:";
            // 
            // DGVCount_DB
            // 
            this.DGVCount_DB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCount_DB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCount_DB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emploer,
            this.number_of_jobs});
            this.DGVCount_DB.Location = new System.Drawing.Point(3, 33);
            this.DGVCount_DB.Name = "DGVCount_DB";
            this.DGVCount_DB.Size = new System.Drawing.Size(677, 219);
            this.DGVCount_DB.TabIndex = 1;
            // 
            // emploer
            // 
            this.emploer.HeaderText = "Работник";
            this.emploer.Name = "emploer";
            this.emploer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.emploer.Width = 300;
            // 
            // number_of_jobs
            // 
            this.number_of_jobs.HeaderText = "Колличество выполненых заданий";
            this.number_of_jobs.Name = "number_of_jobs";
            this.number_of_jobs.Width = 250;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Items.AddRange(new object[] {
            "SM Инциденты",
            "SM Запросы На Обслуживание",
            "SD Запросы На Обслуживание",
            "SD Заявки На Работы"});
            this.comboBoxTables.Location = new System.Drawing.Point(73, 6);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(221, 21);
            this.comboBoxTables.TabIndex = 0;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // dBDataLoaderBindingSource
            // 
            this.dBDataLoaderBindingSource.DataSource = typeof(DataBaseConnector.DBDataLoader);
            // 
            // smznoBindingSource
            // 
            this.smznoBindingSource.DataSource = typeof(DataBaseConnector.Sm_zno);
            // 
            // sdznoBindingSource
            // 
            this.sdznoBindingSource.DataSource = typeof(DataBaseConnector.Sd_zno);
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 313);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManageForm";
            this.ShowIcon = false;
            this.Text = "FTE counter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCount_DB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBDataLoaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smznoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sdznoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadData;
        private System.Windows.Forms.ToolStripMenuItem DBOptions;
        private System.Windows.Forms.ToolStripMenuItem Options;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem подключитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button ViewCangetTabels;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVCount_DB;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.BindingSource dBDataLoaderBindingSource;
        private System.Windows.Forms.BindingSource smznoBindingSource;
        private System.Windows.Forms.BindingSource sdznoBindingSource;
        private System.Windows.Forms.Button Prepare;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button FindAllUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn number_of_jobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn emploer;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button LoadDataFromFile;
        private System.Windows.Forms.Button EditEmployeeTable;
    }
}

