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
    public partial class ShellFormView : Form
    {
        private GridControlView _gridControlView;

        public ShellFormView()
        {
            InitializeComponent();

            _gridControlView = new GridControlView();

            int meshWidth = this._gridControlView.Width;
            int meshHeight = this._gridControlView.Height;
            int X = (this.gridWrapper.Width - meshWidth) / 2;
            int Y = (this.gridWrapper.Height - meshHeight) / 2;

            _gridControlView.Location = new Point(X, Y); 
            
            this.gridWrapper.Controls.Add(_gridControlView);
        }
    }
}
