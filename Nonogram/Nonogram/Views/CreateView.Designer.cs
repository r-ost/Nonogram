
namespace Nonogram.Views
{
    partial class CreateView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridPanel = new System.Windows.Forms.Panel();
            this.difficultyBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.diffTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.difficultyBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPanel
            // 
            this.gridPanel.Location = new System.Drawing.Point(402, 277);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(421, 263);
            this.gridPanel.TabIndex = 0;
            // 
            // difficultyBox
            // 
            this.difficultyBox.Controls.Add(this.saveButton);
            this.difficultyBox.Controls.Add(this.label2);
            this.difficultyBox.Controls.Add(this.label1);
            this.difficultyBox.Controls.Add(this.diffTextBox);
            this.difficultyBox.Controls.Add(this.titleTextBox);
            this.difficultyBox.Location = new System.Drawing.Point(38, 40);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(280, 173);
            this.difficultyBox.TabIndex = 1;
            this.difficultyBox.TabStop = false;
            this.difficultyBox.Text = "Puzzle Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Difficulty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Puzzle Title";
            // 
            // diffTextBox
            // 
            this.diffTextBox.Location = new System.Drawing.Point(120, 85);
            this.diffTextBox.Name = "diffTextBox";
            this.diffTextBox.Size = new System.Drawing.Size(144, 27);
            this.diffTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(120, 36);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(144, 27);
            this.titleTextBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(170, 127);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 29);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // CreateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(this.gridPanel);
            this.Location = new System.Drawing.Point(500, 500);
            this.Name = "CreateView";
            this.Size = new System.Drawing.Size(956, 730);
            this.difficultyBox.ResumeLayout(false);
            this.difficultyBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gridPanel;
        public System.Windows.Forms.Panel GridPanel { get => gridPanel; }
        private System.Windows.Forms.GroupBox difficultyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox diffTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}
