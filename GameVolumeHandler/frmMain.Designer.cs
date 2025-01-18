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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.topHeaderPanel = new System.Windows.Forms.Panel();
            this.btnMute = new System.Windows.Forms.Button();
            this.lowerHeaderPanel = new System.Windows.Forms.Panel();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.btnExeSelect = new System.Windows.Forms.Button();
            this.lblSelectExe = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblOr = new System.Windows.Forms.Label();
            this.txtExeName = new System.Windows.Forms.TextBox();
            this.lblExeDescription = new System.Windows.Forms.Label();
            this.FoundExe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToggleHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.topHeaderPanel.SuspendLayout();
            this.lowerHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.inputPanel);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(650, 379);
            this.mainPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.topHeaderPanel);
            this.headerPanel.Controls.Add(this.lowerHeaderPanel);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(648, 244);
            this.headerPanel.TabIndex = 6;
            // 
            // topHeaderPanel
            // 
            this.topHeaderPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.topHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topHeaderPanel.Controls.Add(this.btnMute);
            this.topHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.topHeaderPanel.Name = "topHeaderPanel";
            this.topHeaderPanel.Size = new System.Drawing.Size(646, 45);
            this.topHeaderPanel.TabIndex = 7;
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.Lime;
            this.btnMute.ForeColor = System.Drawing.Color.Black;
            this.btnMute.Location = new System.Drawing.Point(0, 0);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(75, 23);
            this.btnMute.TabIndex = 7;
            this.btnMute.Text = "MUTE";
            this.btnMute.UseVisualStyleBackColor = false;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // lowerHeaderPanel
            // 
            this.lowerHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lowerHeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lowerHeaderPanel.Controls.Add(this.dgvMain);
            this.lowerHeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.lowerHeaderPanel.Location = new System.Drawing.Point(0, 51);
            this.lowerHeaderPanel.Name = "lowerHeaderPanel";
            this.lowerHeaderPanel.Size = new System.Drawing.Size(643, 188);
            this.lowerHeaderPanel.TabIndex = 8;
            // 
            // dgvMain
            // 
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.WindowText;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoundExe,
            this.ExeName,
            this.IsActive,
            this.ToggleHotkey,
            this.AppHotkey,
            this.Delete});
            this.dgvMain.GridColor = System.Drawing.Color.Black;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.Size = new System.Drawing.Size(644, 238);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // inputPanel
            // 
            this.inputPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPanel.Controls.Add(this.btnExeSelect);
            this.inputPanel.Controls.Add(this.lblSelectExe);
            this.inputPanel.Controls.Add(this.btnAddToList);
            this.inputPanel.Controls.Add(this.lblOr);
            this.inputPanel.Controls.Add(this.txtExeName);
            this.inputPanel.Controls.Add(this.lblExeDescription);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputPanel.Location = new System.Drawing.Point(0, 250);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(648, 127);
            this.inputPanel.TabIndex = 5;
            // 
            // btnExeSelect
            // 
            this.btnExeSelect.ForeColor = System.Drawing.Color.Navy;
            this.btnExeSelect.Location = new System.Drawing.Point(106, 63);
            this.btnExeSelect.Name = "btnExeSelect";
            this.btnExeSelect.Size = new System.Drawing.Size(346, 23);
            this.btnExeSelect.TabIndex = 6;
            this.btnExeSelect.Text = "Browse...";
            this.btnExeSelect.UseVisualStyleBackColor = true;
            this.btnExeSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // lblSelectExe
            // 
            this.lblSelectExe.AutoSize = true;
            this.lblSelectExe.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblSelectExe.Location = new System.Drawing.Point(3, 68);
            this.lblSelectExe.Name = "lblSelectExe";
            this.lblSelectExe.Size = new System.Drawing.Size(92, 13);
            this.lblSelectExe.TabIndex = 5;
            this.lblSelectExe.Text = "Select Game.EXE";
            // 
            // btnAddToList
            // 
            this.btnAddToList.ForeColor = System.Drawing.Color.Navy;
            this.btnAddToList.Location = new System.Drawing.Point(379, 14);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 25);
            this.btnAddToList.TabIndex = 1;
            this.btnAddToList.Text = "Add to list";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblOr.Location = new System.Drawing.Point(13, 44);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(27, 13);
            this.lblOr.TabIndex = 4;
            this.lblOr.Text = "Or...";
            // 
            // txtExeName
            // 
            this.txtExeName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtExeName.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtExeName.Location = new System.Drawing.Point(247, 16);
            this.txtExeName.MinimumSize = new System.Drawing.Size(4, 23);
            this.txtExeName.Name = "txtExeName";
            this.txtExeName.Size = new System.Drawing.Size(130, 20);
            this.txtExeName.TabIndex = 2;
            this.txtExeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExeName_KeyPress);
            // 
            // lblExeDescription
            // 
            this.lblExeDescription.AutoSize = true;
            this.lblExeDescription.ForeColor = System.Drawing.Color.GhostWhite;
            this.lblExeDescription.Location = new System.Drawing.Point(3, 19);
            this.lblExeDescription.Name = "lblExeDescription";
            this.lblExeDescription.Size = new System.Drawing.Size(238, 13);
            this.lblExeDescription.TabIndex = 3;
            this.lblExeDescription.Text = "Type EXE name (must be visible in TaskMgr.exe)";
            // 
            // FoundExe
            // 
            this.FoundExe.Frozen = true;
            this.FoundExe.HeaderText = "Running";
            this.FoundExe.Name = "FoundExe";
            // 
            // ExeName
            // 
            this.ExeName.Frozen = true;
            this.ExeName.HeaderText = "Exe name";
            this.ExeName.Name = "ExeName";
            this.ExeName.ReadOnly = true;
            // 
            // IsActive
            // 
            this.IsActive.Frozen = true;
            this.IsActive.HeaderText = "Active";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // ToggleHotkey
            // 
            this.ToggleHotkey.Frozen = true;
            this.ToggleHotkey.HeaderText = "Toggle Hotkey";
            this.ToggleHotkey.Name = "ToggleHotkey";
            this.ToggleHotkey.ToolTipText = "Assign a hotkey to toggle exe\'s active state.";
            // 
            // AppHotkey
            // 
            this.AppHotkey.Frozen = true;
            this.AppHotkey.HeaderText = "App Hotkey";
            this.AppHotkey.Name = "AppHotkey";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(650, 379);
            this.Controls.Add(this.mainPanel);
            this.ForeColor = System.Drawing.Color.GhostWhite;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 418);
            this.Name = "frmMain";
            this.Text = "Game Volume Handler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mainPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.topHeaderPanel.ResumeLayout(false);
            this.lowerHeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.TextBox txtExeName;
        private System.Windows.Forms.Label lblExeDescription;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblSelectExe;
        private System.Windows.Forms.Button btnExeSelect;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel topHeaderPanel;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Panel lowerHeaderPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoundExe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToggleHotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppHotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delete;
    }
}

