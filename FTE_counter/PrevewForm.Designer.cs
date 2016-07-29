namespace FTE_counter
{
    partial class PreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.Load_Data = new System.Windows.Forms.Button();
            this.Start_CenralForm = new System.Windows.Forms.Button();
            this.Statistic = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Load_Data
            // 
            this.Load_Data.Location = new System.Drawing.Point(6, 12);
            this.Load_Data.Name = "Load_Data";
            this.Load_Data.Size = new System.Drawing.Size(260, 42);
            this.Load_Data.TabIndex = 0;
            this.Load_Data.Text = "Загрузка данных в базу";
            this.Load_Data.UseVisualStyleBackColor = true;
            this.Load_Data.Click += new System.EventHandler(this.Load_Data_Click);
            // 
            // Start_CenralForm
            // 
            this.Start_CenralForm.Location = new System.Drawing.Point(6, 60);
            this.Start_CenralForm.Name = "Start_CenralForm";
            this.Start_CenralForm.Size = new System.Drawing.Size(260, 42);
            this.Start_CenralForm.TabIndex = 1;
            this.Start_CenralForm.Text = "Работа с данными в БД";
            this.Start_CenralForm.UseVisualStyleBackColor = true;
            this.Start_CenralForm.Click += new System.EventHandler(this.Start_CenralForm_Click);
            // 
            // Statistic
            // 
            this.Statistic.Location = new System.Drawing.Point(6, 108);
            this.Statistic.Name = "Statistic";
            this.Statistic.Size = new System.Drawing.Size(260, 42);
            this.Statistic.TabIndex = 2;
            this.Statistic.Text = "Работа с отчётами, статистикой, выгрузкой данных.";
            this.Statistic.UseVisualStyleBackColor = true;
            this.Statistic.Click += new System.EventHandler(this.Statistic_Click);
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(5, 156);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(260, 42);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "Настройки";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(5, 204);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(260, 42);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 254);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Statistic);
            this.Controls.Add(this.Start_CenralForm);
            this.Controls.Add(this.Load_Data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(288, 293);
            this.MinimumSize = new System.Drawing.Size(288, 293);
            this.Name = "PreviewForm";
            this.ShowIcon = false;
            this.Text = "FTE Counter";
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Load_Data;
        private System.Windows.Forms.Button Start_CenralForm;
        private System.Windows.Forms.Button Statistic;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button Exit;
    }
}