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
        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
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
    }
}
