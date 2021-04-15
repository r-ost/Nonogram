﻿using Nonogram.Models;
using Nonogram.Presenters;
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
    public partial class GridControlView : UserControl
    {
        public GridControlView()
        {
            InitializeComponent();
            new GridPresenter(this);
        }
    }
}
