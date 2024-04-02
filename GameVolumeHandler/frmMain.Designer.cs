namespace GameVolumeHandler
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExeSelect = new System.Windows.Forms.Button();
            this.lblSelectExe = new System.Windows.Forms.Label();
            this.lblOr = new System.Windows.Forms.Label();
            this.txtExeName = new System.Windows.Forms.TextBox();
            this.lblExeDescription = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlSettings);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnAddToList);
            this.panel1.Controls.Add(this.dgvMain);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 476);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExeSelect);
            this.panel2.Controls.Add(this.lblSelectExe);
            this.panel2.Controls.Add(this.lblOr);
            this.panel2.Controls.Add(this.txtExeName);
            this.panel2.Controls.Add(this.lblExeDescription);
            this.panel2.Location = new System.Drawing.Point(3, 338);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 106);
            this.panel2.TabIndex = 5;
            // 
            // btnExeSelect
            // 
            this.btnExeSelect.Location = new System.Drawing.Point(101, 63);
            this.btnExeSelect.Name = "btnExeSelect";
            this.btnExeSelect.Size = new System.Drawing.Size(297, 23);
            this.btnExeSelect.TabIndex = 6;
            this.btnExeSelect.Text = "Browse...";
            this.btnExeSelect.UseVisualStyleBackColor = true;
            this.btnExeSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // lblSelectExe
            // 
            this.lblSelectExe.AutoSize = true;
            this.lblSelectExe.Location = new System.Drawing.Point(3, 68);
            this.lblSelectExe.Name = "lblSelectExe";
            this.lblSelectExe.Size = new System.Drawing.Size(92, 13);
            this.lblSelectExe.TabIndex = 5;
            this.lblSelectExe.Text = "Select Game.EXE";
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(13, 46);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(27, 13);
            this.lblOr.TabIndex = 4;
            this.lblOr.Text = "Or...";
            // 
            // txtExeName
            // 
            this.txtExeName.Location = new System.Drawing.Point(247, 16);
            this.txtExeName.Name = "txtExeName";
            this.txtExeName.Size = new System.Drawing.Size(151, 20);
            this.txtExeName.TabIndex = 2;
            // 
            // lblExeDescription
            // 
            this.lblExeDescription.AutoSize = true;
            this.lblExeDescription.Location = new System.Drawing.Point(3, 19);
            this.lblExeDescription.Name = "lblExeDescription";
            this.lblExeDescription.Size = new System.Drawing.Size(238, 13);
            this.lblExeDescription.TabIndex = 3;
            this.lblExeDescription.Text = "Type EXE name (must be visible in TaskMgr.exe)";
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(3, 450);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 1;
            this.btnAddToList.Text = "Add to list";
            this.btnAddToList.UseVisualStyleBackColor = true;
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(3, 3);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(773, 333);
            this.dgvMain.TabIndex = 0;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Location = new System.Drawing.Point(418, 338);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(355, 106);
            this.pnlSettings.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "Game Volume Handler";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.TextBox txtExeName;
        private System.Windows.Forms.Label lblExeDescription;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblSelectExe;
        private System.Windows.Forms.Button btnExeSelect;
        private System.Windows.Forms.Panel pnlSettings;
    }
}

