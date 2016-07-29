namespace MySqlManagement_v2
{
    partial class FrmLogin
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
            this.dbLoginUserControl1 = new MySqlManagement_v2.UI.DbLoginUserControl();
            this.SuspendLayout();
            // 
            // dbLoginUserControl1
            // 
            this.dbLoginUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbLoginUserControl1.Location = new System.Drawing.Point(0, 0);
            this.dbLoginUserControl1.Name = "dbLoginUserControl1";
            this.dbLoginUserControl1.Size = new System.Drawing.Size(379, 134);
            this.dbLoginUserControl1.TabIndex = 0;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 134);
            this.Controls.Add(this.dbLoginUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.DbLoginUserControl dbLoginUserControl1;

    }
}

