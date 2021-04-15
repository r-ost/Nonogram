
namespace Nonogram.Views
{
    partial class CountRowView
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
            this.rowCountTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // rowCountTable
            // 
            this.rowCountTable.ColumnCount = 2;
            this.rowCountTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rowCountTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rowCountTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowCountTable.Location = new System.Drawing.Point(0, 0);
            this.rowCountTable.Name = "rowCountTable";
            this.rowCountTable.RowCount = 2;
            this.rowCountTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rowCountTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rowCountTable.Size = new System.Drawing.Size(150, 150);
            this.rowCountTable.TabIndex = 0;
            // 
            // CountRowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rowCountTable);
            this.Name = "CountRowView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel rowCountTable;
        public System.Windows.Forms.TableLayoutPanel RowCountTable { get => rowCountTable; }
    }
}
