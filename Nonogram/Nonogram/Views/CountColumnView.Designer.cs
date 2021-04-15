
namespace Nonogram.Views
{
    partial class CountColumnView
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
            this.columnCountTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // columnCountTable
            // 
            this.columnCountTable.ColumnCount = 2;
            this.columnCountTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.columnCountTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.columnCountTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnCountTable.Location = new System.Drawing.Point(0, 0);
            this.columnCountTable.Name = "columnCountTable";
            this.columnCountTable.RowCount = 2;
            this.columnCountTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.columnCountTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.columnCountTable.Size = new System.Drawing.Size(150, 150);
            this.columnCountTable.TabIndex = 0;
            // 
            // CountColumnView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.columnCountTable);
            this.Name = "CountColumnView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel columnCountTable;
        public System.Windows.Forms.TableLayoutPanel ColumnCountTable { get => columnCountTable;}
    }
}
