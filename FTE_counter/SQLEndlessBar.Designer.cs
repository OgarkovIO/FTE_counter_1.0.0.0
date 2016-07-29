namespace FTE_counter
{
    partial class SQLProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLProgress));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AllSQLQueryBar = new System.Windows.Forms.ProgressBar();
            this.SingleSQLQueryBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущая процедура.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Общий ход выполнения.";
            // 
            // AllSQLQueryBar
            // 
            this.AllSQLQueryBar.Location = new System.Drawing.Point(15, 25);
            this.AllSQLQueryBar.Name = "AllSQLQueryBar";
            this.AllSQLQueryBar.Size = new System.Drawing.Size(308, 10);
            this.AllSQLQueryBar.TabIndex = 2;
            // 
            // SingleSQLQueryBar
            // 
            this.SingleSQLQueryBar.Location = new System.Drawing.Point(15, 52);
            this.SingleSQLQueryBar.Name = "SingleSQLQueryBar";
            this.SingleSQLQueryBar.Size = new System.Drawing.Size(308, 10);
            this.SingleSQLQueryBar.TabIndex = 3;
            // 
            // SQLProgress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(334, 70);
            this.ControlBox = false;
            this.Controls.Add(this.SingleSQLQueryBar);
            this.Controls.Add(this.AllSQLQueryBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLProgress";
            this.ShowInTaskbar = false;
            this.Text = "Выполнение операций с БД";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar AllSQLQueryBar;
        private System.Windows.Forms.ProgressBar SingleSQLQueryBar;
    }
}