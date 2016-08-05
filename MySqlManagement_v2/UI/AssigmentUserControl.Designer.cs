namespace MySqlManagement_v2.UI
{
    partial class AssigmentUserControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAssigned = new System.Windows.Forms.Panel();
            this.grpMain.SuspendLayout();
            this.tblLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tblLayoutMain);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Margin = new System.Windows.Forms.Padding(1);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(420, 99);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.ColumnCount = 2;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.84058F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.15942F));
            this.tblLayoutMain.Controls.Add(this.pnlAssigned, 1, 0);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Location = new System.Drawing.Point(3, 16);
            this.tblLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 1;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutMain.Size = new System.Drawing.Size(414, 80);
            this.tblLayoutMain.TabIndex = 0;
            // 
            // pnlAssigned
            // 
            this.pnlAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAssigned.Location = new System.Drawing.Point(78, 0);
            this.pnlAssigned.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAssigned.Name = "pnlAssigned";
            this.pnlAssigned.Size = new System.Drawing.Size(336, 80);
            this.pnlAssigned.TabIndex = 0;
            this.pnlAssigned.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlAssigned_DragDrop);
            this.pnlAssigned.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlAssigned_DragEnter);
            this.pnlAssigned.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAssigned_Paint);
            // 
            // AssigmentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Name = "AssigmentUserControl";
            this.Size = new System.Drawing.Size(420, 99);
            this.grpMain.ResumeLayout(false);
            this.tblLayoutMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Panel pnlAssigned;
    }
}
