namespace FTE_counter
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.DiscardConfig = new System.Windows.Forms.Button();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.FileView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonCSV = new System.Windows.Forms.RadioButton();
            this.radioButtonSAP = new System.Windows.Forms.RadioButton();
            this.buttonCSVSM = new System.Windows.Forms.Button();
            this.buttonExcelSM = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DiscardConfig
            // 
            this.DiscardConfig.Location = new System.Drawing.Point(222, 116);
            this.DiscardConfig.Name = "DiscardConfig";
            this.DiscardConfig.Size = new System.Drawing.Size(75, 23);
            this.DiscardConfig.TabIndex = 9;
            this.DiscardConfig.Text = "Отмена";
            this.DiscardConfig.UseVisualStyleBackColor = true;
            this.DiscardConfig.Click += new System.EventHandler(this.DiscardConfig_Click);
            // 
            // SaveConfig
            // 
            this.SaveConfig.Location = new System.Drawing.Point(141, 116);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(75, 23);
            this.SaveConfig.TabIndex = 8;
            this.SaveConfig.Text = "Сохранить";
            this.SaveConfig.UseVisualStyleBackColor = true;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // FileView
            // 
            this.FileView.Location = new System.Drawing.Point(373, 83);
            this.FileView.Name = "FileView";
            this.FileView.Size = new System.Drawing.Size(99, 23);
            this.FileView.TabIndex = 7;
            this.FileView.Text = "Обзор";
            this.FileView.UseVisualStyleBackColor = true;
            this.FileView.Click += new System.EventHandler(this.FileView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Путь к файлу БД:";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(112, 86);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(255, 20);
            this.PathTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Источник выгрузки из SM:";
            // 
            // radioButtonCSV
            // 
            this.radioButtonCSV.AutoSize = true;
            this.radioButtonCSV.Location = new System.Drawing.Point(161, 5);
            this.radioButtonCSV.Name = "radioButtonCSV";
            this.radioButtonCSV.Size = new System.Drawing.Size(109, 17);
            this.radioButtonCSV.TabIndex = 11;
            this.radioButtonCSV.Text = "CSV файл из SM";
            this.radioButtonCSV.UseVisualStyleBackColor = true;
            this.radioButtonCSV.CheckedChanged += new System.EventHandler(this.radioButtonCSV_CheckedChanged);
            // 
            // radioButtonSAP
            // 
            this.radioButtonSAP.AutoSize = true;
            this.radioButtonSAP.Location = new System.Drawing.Point(276, 5);
            this.radioButtonSAP.Name = "radioButtonSAP";
            this.radioButtonSAP.Size = new System.Drawing.Size(203, 17);
            this.radioButtonSAP.TabIndex = 12;
            this.radioButtonSAP.Text = "EXCEL файл из SAP business object";
            this.radioButtonSAP.UseVisualStyleBackColor = true;
            this.radioButtonSAP.CheckedChanged += new System.EventHandler(this.radioButtonSAP_CheckedChanged);
            // 
            // buttonCSVSM
            // 
            this.buttonCSVSM.Enabled = false;
            this.buttonCSVSM.Location = new System.Drawing.Point(161, 28);
            this.buttonCSVSM.Name = "buttonCSVSM";
            this.buttonCSVSM.Size = new System.Drawing.Size(109, 23);
            this.buttonCSVSM.TabIndex = 13;
            this.buttonCSVSM.Text = "CSV настройки";
            this.buttonCSVSM.UseVisualStyleBackColor = true;
            // 
            // buttonExcelSM
            // 
            this.buttonExcelSM.Location = new System.Drawing.Point(276, 28);
            this.buttonExcelSM.Name = "buttonExcelSM";
            this.buttonExcelSM.Size = new System.Drawing.Size(196, 23);
            this.buttonExcelSM.TabIndex = 14;
            this.buttonExcelSM.Text = "EXCEL настройки";
            this.buttonExcelSM.UseVisualStyleBackColor = true;
            this.buttonExcelSM.Click += new System.EventHandler(this.buttonExcelSM_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Как основной источник информации о сотрудниках использовать:";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Выгрузка из SM",
            "Выгрузка из SD",
            "Спец.выгрузка из SAP"});
            this.comboBox1.Location = new System.Drawing.Point(354, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 155);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonExcelSM);
            this.Controls.Add(this.buttonCSVSM);
            this.Controls.Add(this.radioButtonSAP);
            this.Controls.Add(this.radioButtonCSV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DiscardConfig);
            this.Controls.Add(this.SaveConfig);
            this.Controls.Add(this.FileView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.ShowIcon = false;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DiscardConfig;
        private System.Windows.Forms.Button SaveConfig;
        private System.Windows.Forms.Button FileView;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonCSV;
        private System.Windows.Forms.RadioButton radioButtonSAP;
        private System.Windows.Forms.Button buttonCSVSM;
        private System.Windows.Forms.Button buttonExcelSM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}