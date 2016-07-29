namespace FTE_counter
{
    partial class SQLProgressIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLProgressIndex));
            this.EndlessSQLQueryBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // EndlessSQLQueryBar
            // 
            this.EndlessSQLQueryBar.Location = new System.Drawing.Point(14, 12);
            this.EndlessSQLQueryBar.Name = "EndlessSQLQueryBar";
            this.EndlessSQLQueryBar.Size = new System.Drawing.Size(308, 10);
            this.EndlessSQLQueryBar.TabIndex = 2;
            // 
            // SQLProgressIndex
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(330, 31);
            this.ControlBox = false;
            this.Controls.Add(this.EndlessSQLQueryBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLProgressIndex";
            this.ShowInTaskbar = false;
            this.Text = "Выполняются операции с БД";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar EndlessSQLQueryBar;
    }
}