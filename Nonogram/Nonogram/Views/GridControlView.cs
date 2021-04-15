using Nonogram.Models;
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
            _gridPresenter = new GridPresenter(this);
            _gridPresenter.CreateGridOnStartup();

            _tiles = _gridPresenter.Grid;

            InitializeComponent();

            InitializeGrid();
        }


        private TilesGrid _tiles;

        private GridPresenter _gridPresenter;

        private void GridControlView_Load(object sender, EventArgs e)
        {
            CreateTiles(_gridPresenter.GridHeight, _gridPresenter.GridWidth);
        }

        private void CreateTiles(int rows, int columns)
        {
            var rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var newButton = new Button();
                    newButton.Margin = new Padding(0, 0, 0, 0);
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 1;

                    newButton.Dock = DockStyle.Fill;
                    newButton.Click += (s, e) =>
                    {
                        TableLayoutPanelCellPosition pos = this.gridPanel.GetCellPosition((Control)s);

                        _tiles.Tiles[pos.Row, pos.Column].Selected = !_tiles.Tiles[pos.Row, pos.Column].Selected;
                    };


                    Binding bind = new Binding("BackColor", _tiles.Tiles[i, j], "Selected");
                    bind.Format += (s, e) => {
                        e.Value = (bool)e.Value ? Color.Black : Color.White;
                    };
                    newButton.DataBindings.Add(bind);


                    this.gridPanel.Controls.Add(newButton, j, i);
                }
            }
        }

        private void InitializeGrid()
        {
            this.gridPanel.Controls.Clear();
            this.gridPanel.ColumnStyles.Clear();
            this.gridPanel.RowStyles.Clear();

            this.gridPanel.ColumnCount = _gridPresenter.GridWidth;
            this.gridPanel.RowCount = _gridPresenter.GridHeight;

            int width = _gridPresenter.TileWidth * this.gridPanel.ColumnCount;
            int height = _gridPresenter.TileHeight * this.gridPanel.RowCount;

            this.gridPanel.Width = width;
            this.gridPanel.Height = height;

            this.Width = width;
            this.Height = height;



            for (int i = 0; i < this.gridPanel.ColumnCount; i++)
            {
                this.gridPanel.ColumnStyles.Add(new ColumnStyle() { Width = _gridPresenter.TileWidth, SizeType = SizeType.Absolute });
            }

            for (int i = 0; i < this.gridPanel.RowCount; i++)
            {
                this.gridPanel.RowStyles.Add(new RowStyle() { Height = _gridPresenter.TileHeight, SizeType = SizeType.Absolute });
            }

        }
    }
}
