
namespace Nonogram.Views
{
    partial class ShellFormView
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
            this.mainStrip = new System.Windows.Forms.MenuStrip();
            this.newGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPuzzleSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridWrapper = new System.Windows.Forms.Panel();
            this.mainStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStrip
            // 
            this.mainStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameMenuItem,
            this.createMenuItem});
            this.mainStrip.Location = new System.Drawing.Point(0, 0);
            this.mainStrip.Name = "mainStrip";
            this.mainStrip.Size = new System.Drawing.Size(982, 28);
            this.mainStrip.TabIndex = 0;
            this.mainStrip.Text = "New Game";
            // 
            // newGameMenuItem
            // 
            this.newGameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomSubMenuItem,
            this.chooseSubMenuItem,
            this.loadSubMenuItem});
            this.newGameMenuItem.Name = "newGameMenuItem";
            this.newGameMenuItem.Size = new System.Drawing.Size(96, 24);
            this.newGameMenuItem.Text = "New Game";
            // 
            // randomSubMenuItem
            // 
            this.randomSubMenuItem.Enabled = true;
            this.randomSubMenuItem.Name = "randomSubMenuItem";
            this.randomSubMenuItem.Size = new System.Drawing.Size(188, 26);
            this.randomSubMenuItem.Text = "Random";
            // 
            // chooseSubMenuItem
            // 
            this.chooseSubMenuItem.Enabled = true;
            this.chooseSubMenuItem.Name = "chooseSubMenuItem";
            this.chooseSubMenuItem.Size = new System.Drawing.Size(188, 26);
            this.chooseSubMenuItem.Text = "Choose puzzle";
            // 
            // loadSubMenuItem
            // 
            this.loadSubMenuItem.Enabled = true;
            this.loadSubMenuItem.Name = "loadSubMenuItem";
            this.loadSubMenuItem.Size = new System.Drawing.Size(188, 26);
            this.loadSubMenuItem.Text = "Load puzzle";
            // 
            // createMenuItem
            // 
            this.createMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPuzzleSubMenuItem});
            this.createMenuItem.Name = "createMenuItem";
            this.createMenuItem.Size = new System.Drawing.Size(75, 24);
            this.createMenuItem.Text = "Create...";
            // 
            // createPuzzleSubMenuItem
            // 
            this.createPuzzleSubMenuItem.Enabled = true;
            this.createPuzzleSubMenuItem.Name = "createPuzzleSubMenuItem";
            this.createPuzzleSubMenuItem.Size = new System.Drawing.Size(191, 26);
            this.createPuzzleSubMenuItem.Text = "Create puzzle...";
            // 
            // gridWrapper
            // 
            this.gridWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWrapper.Location = new System.Drawing.Point(0, 28);
            this.gridWrapper.Name = "gridWrapper";
            this.gridWrapper.Size = new System.Drawing.Size(982, 725);
            this.gridWrapper.TabIndex = 1;
            // 
            // ShellFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.gridWrapper);
            this.Controls.Add(this.mainStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainStrip;
            this.MaximizeBox = false;
            this.Name = "ShellFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nonogram";
            this.mainStrip.ResumeLayout(false);
            this.mainStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainStrip;
        private System.Windows.Forms.ToolStripMenuItem newGameMenuItem;
        public  System.Windows.Forms.ToolStripMenuItem NewGameMenuItem { get => newGameMenuItem; }
        private System.Windows.Forms.ToolStripMenuItem createMenuItem;
        public System.Windows.Forms.ToolStripMenuItem CreateMenuItem { get => createMenuItem; }
        private System.Windows.Forms.ToolStripMenuItem randomSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPuzzleSubMenuItem;
        public System.Windows.Forms.ToolStripMenuItem CreatePuzzleSubMenuItem { get => createPuzzleSubMenuItem;  }
        private System.Windows.Forms.Panel gridWrapper;
        public System.Windows.Forms.Panel GridWrapper { get => gridWrapper; }
    }
}