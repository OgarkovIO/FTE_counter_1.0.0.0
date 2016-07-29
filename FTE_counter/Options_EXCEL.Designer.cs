namespace FTE_counter
{
    partial class Options_EXCEL
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
            this.label1 = new System.Windows.Forms.Label();
            this.Applay = new System.Windows.Forms.Button();
            this.Discard = new System.Windows.Forms.Button();
            this.comboBoxEXCELParam = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Загружать в базу:";
            // 
            // Applay
            // 
            this.Applay.Location = new System.Drawing.Point(127, 42);
            this.Applay.Name = "Applay";
            this.Applay.Size = new System.Drawing.Size(75, 23);
            this.Applay.TabIndex = 1;
            this.Applay.Text = "Сохранить";
            this.Applay.UseVisualStyleBackColor = true;
            this.Applay.Click += new System.EventHandler(this.Applay_Click);
            // 
            // Discard
            // 
            this.Discard.Location = new System.Drawing.Point(208, 42);
            this.Discard.Name = "Discard";
            this.Discard.Size = new System.Drawing.Size(75, 23);
            this.Discard.TabIndex = 2;
            this.Discard.Text = "Отмена";
            this.Discard.UseVisualStyleBackColor = true;
            this.Discard.Click += new System.EventHandler(this.Discard_Click);
            // 
            // comboBoxEXCELParam
            // 
            this.comboBoxEXCELParam.FormattingEnabled = true;
            this.comboBoxEXCELParam.Items.AddRange(new object[] {
            "Только необходимые данные",
            "Полная загрузка"});
            this.comboBoxEXCELParam.Location = new System.Drawing.Point(118, 10);
            this.comboBoxEXCELParam.Name = "comboBoxEXCELParam";
            this.comboBoxEXCELParam.Size = new System.Drawing.Size(327, 21);
            this.comboBoxEXCELParam.TabIndex = 3;
            // 
            // Options_EXCEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 80);
            this.Controls.Add(this.comboBoxEXCELParam);
            this.Controls.Add(this.Discard);
            this.Controls.Add(this.Applay);
            this.Controls.Add(this.label1);
            this.Name = "Options_EXCEL";
            this.Text = "Options_EXCEL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Applay;
        private System.Windows.Forms.Button Discard;
        private System.Windows.Forms.ComboBox comboBoxEXCELParam;
    }
}