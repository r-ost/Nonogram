using Nonogram.Models;
using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonogram.Presenters
{
    class GridPresenter 
    {
        private GridControlView _gridControlView;
        private TilesGrid _grid;

        public TilesGrid Grid { get => _grid; }

        //public int GridHeight { get => _grid.Height; } 
        //public int GridWidth { get => _grid.Width; }

        //public int TileWidth { get => Tile.Width; }
        //public int TileHeight { get => Tile.Height; }


        public GridPresenter(GridControlView gridControlView)
        {
            _gridControlView = gridControlView;
            _grid = new TilesGrid();
            
            CreateGridOnStartup();
            DrawTiles(_grid.Height, _grid.Height);
        }

        public void CreateGridOnStartup()
        {
            int width = 10;
            int height = 10;

            _grid.Height = height;
            _grid.Width = width;
            _grid.Tiles = new Tile[height, width];

            Random rand = new Random();
            for (int i = 0; i < _grid.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.Tiles.GetLength(1); j++)
                {
                    Tile tile = new Tile();

                    if (rand.Next() % 100 < 50)
                        tile.Selected = false;
                    else
                        tile.Selected = true;

                    _grid.Tiles[i, j] = tile;
                }
            }

            InitializeGrid();
        }

        private void DrawTiles(int rows, int columns)
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
                        TableLayoutPanelCellPosition pos = _gridControlView.GridPanel.GetCellPosition((Control)s);

                        _grid.Tiles[pos.Row, pos.Column].Selected = !_grid.Tiles[pos.Row, pos.Column].Selected;
                    };


                    Binding bind = new Binding("BackColor", _grid.Tiles[i, j], "Selected");
                    bind.Format += (s, e) => {
                        e.Value = (bool)e.Value ? Color.Black : Color.White;
                    };
                    newButton.DataBindings.Add(bind);


                    _gridControlView.GridPanel.Controls.Add(newButton, j, i);
                }
            }
        }

        private void InitializeGrid()
        {
            _gridControlView.GridPanel.Controls.Clear();
            _gridControlView.GridPanel.ColumnStyles.Clear();
            _gridControlView.GridPanel.RowStyles.Clear();

            _gridControlView.GridPanel.ColumnCount = _grid.Width;
            _gridControlView.GridPanel.RowCount = _grid.Height;

            int width = Tile.Width * _gridControlView.GridPanel.ColumnCount;
            int height = Tile.Height * _gridControlView.GridPanel.RowCount;

            _gridControlView.GridPanel.Width = width;
            _gridControlView.GridPanel.Height = height;

            _gridControlView.Width = width;
            _gridControlView.Height = height;



            for (int i = 0; i < _gridControlView.GridPanel.ColumnCount; i++)
            {
                _gridControlView.GridPanel.ColumnStyles.Add(new ColumnStyle() { Width = Tile.Width, SizeType = SizeType.Absolute });
            }

            for (int i = 0; i < _gridControlView.GridPanel.RowCount; i++)
            {
                _gridControlView.GridPanel.RowStyles.Add(new RowStyle() { Height = Tile.Height, SizeType = SizeType.Absolute });
            }

        }
    }
}
