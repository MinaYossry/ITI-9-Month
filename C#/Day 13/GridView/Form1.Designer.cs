namespace GridView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdTitleLst = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdTitleLst)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTitleLst
            // 
            this.grdTitleLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTitleLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTitleLst.Location = new System.Drawing.Point(0, 28);
            this.grdTitleLst.Name = "grdTitleLst";
            this.grdTitleLst.RowHeadersWidth = 51;
            this.grdTitleLst.RowTemplate.Height = 29;
            this.grdTitleLst.Size = new System.Drawing.Size(800, 422);
            this.grdTitleLst.TabIndex = 0;
            this.grdTitleLst.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTitleLst_CellContentClick);
            this.grdTitleLst.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdTitleLst_CellFormatting);
            this.grdTitleLst.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTitleLst_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.newRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newRowToolStripMenuItem
            // 
            this.newRowToolStripMenuItem.Name = "newRowToolStripMenuItem";
            this.newRowToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.newRowToolStripMenuItem.Text = "New Row";
            this.newRowToolStripMenuItem.Click += new System.EventHandler(this.newRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdTitleLst);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTitleLst)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView grdTitleLst;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem newRowToolStripMenuItem;
        private ToolStripMenuItem deleteRowToolStripMenuItem;
    }
}