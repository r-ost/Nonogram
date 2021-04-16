using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonogram.Views
{
    public partial class SizeDialogBoxView : Form
    {
        public int GridHeight { get; set; } = 10;
        public int GridWidth { get; set; } = 10;
        public SizeDialogBoxView()
        {
            InitializeComponent();
        }

        

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            GridWidth = int.Parse(widthTextBox.Text);
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            GridHeight = int.Parse(heightTextBox.Text);
        }

        private void widthTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(this.widthTextBox.Text) < 2 || int.Parse(this.widthTextBox.Text) > 15)
            {
                errorProvider1.SetError(this.widthTextBox, "Width must be integer number from 2 to 15.");
                e.Cancel = true;
            }   
        }

        private void heightTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(this.heightTextBox.Text) < 2 || int.Parse(this.heightTextBox.Text) > 15)
            {
                errorProvider2.SetError(this.heightTextBox, "Height must be integer number from 2 to 15.");
                e.Cancel = true;
            }
            else
                errorProvider2.Clear();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
