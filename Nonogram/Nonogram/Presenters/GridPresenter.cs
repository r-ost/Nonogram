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
        private TilesGrid _tilesGrid;
         
        public TilesGrid TilesGrid { get => _tilesGrid; }
        private bool _createMode = false;


        private List<int>[] _rowsCounts;

        public List<int>[] RowsCounts
        {
            get { return _rowsCounts; }
            set { _rowsCounts = value; }
        }

        private List<int>[] _columnsCounts;

        public List<int>[] ColumnsCounts
        {
            get { return _columnsCounts; }
            set { _columnsCounts = value; }
        }


        public CountColumnPresenter ColumnPresenter { get; set; } = null;
        public CountRowPresenter RowPresenter { get; set; } = null;


        public GridPresenter(GridControlView gridControlView, bool createOnStartup, bool createMode = false, int w = 0, int h = 0, 
            List<int>[] rowsCount = null, List<int>[] columnsCount = null)
        {
            if (rowsCount == null)
            { _rowsCounts = new List<int>[w]; }
            else
                _rowsCounts = rowsCount;
            if (columnsCount == null)
                _columnsCounts = new List<int>[h];
            else
                _columnsCounts = columnsCount;
           

            currRows = new List<int>[w];
            currColumns = new List<int>[h];

            _gridControlView = gridControlView;
            _tilesGrid = new TilesGrid();
            
            if (createOnStartup)
                CreateGridOnStartup(w, h);
            else
            {
                _createMode = createMode;
                _tilesGrid.Height = h;
                _tilesGrid.Width = w;
                _tilesGrid.Tiles = new Tile[h, w];
                Random rand = new Random();
                for (int i = 0; i < _tilesGrid.Tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < _tilesGrid.Tiles.GetLength(1); j++)
                    {
                        Tile tile = new Tile();
                        tile.Crossed = false;

                        //if (rand.Next() % 100 < 50)
                        //    tile.Selected = false;
                        //else
                            tile.Selected = false;

                        _tilesGrid.Tiles[i, j] = tile;
                    }
                }

                InitializeGrid();
            }

            DrawTiles(_tilesGrid.Height, _tilesGrid.Width);

            currRows = new List<int>[_tilesGrid.Height];
            currColumns = new List<int>[_tilesGrid.Width];
        }

        public void CreateGridOnStartup(int width, int height)
        {
   

            _tilesGrid.Height = height;
            _tilesGrid.Width = width;
            _tilesGrid.Tiles = new Tile[height, width];

            Random rand = new Random();
            for (int i = 0; i < _tilesGrid.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tilesGrid.Tiles.GetLength(1); j++)
                {
                    Tile tile = new Tile();
                    tile.Crossed = false;

                    if (rand.Next() % 100 < 50)
                        tile.Selected = false;
                    else
                        tile.Selected = true;

                    _tilesGrid.Tiles[i, j] = tile;
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
                    
                    newButton.MouseUp += (s, e) =>
                    {
                        TableLayoutPanelCellPosition pos = _gridControlView.GridPanel.GetCellPosition((Control)s);

                        if (e.Button == MouseButtons.Left)
                        {
                            _tilesGrid.Tiles[pos.Row, pos.Column].Selected = !_tilesGrid.Tiles[pos.Row, pos.Column].Selected;
                            _tilesGrid.Tiles[pos.Row, pos.Column].Crossed = false;
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            _tilesGrid.Tiles[pos.Row, pos.Column].Crossed = !_tilesGrid.Tiles[pos.Row, pos.Column].Crossed;
                            _tilesGrid.Tiles[pos.Row, pos.Column].Selected = false;
                        }
                    };


                    Binding leftClick = new Binding("BackColor", _tilesGrid.Tiles[i, j], "Selected");
                    leftClick.Format += (s, e) => {
                        e.Value = (bool)e.Value ? Color.Black : Color.White;

                        if (_createMode)
                        {
                            for (int k = 0; k < _rowsCounts.Length; k++)
                            {
                                int current = 0;
                                bool prev = false;
                                currRows[k] = new List<int>();
                                for (int kk = 0; kk < _tilesGrid.Width; kk++)
                                {
                                    if (_tilesGrid.Tiles[k, kk].Selected)
                                    {
                                        current++;
                                        prev = true;
                                    }
                                    else if (prev && !_tilesGrid.Tiles[k, kk].Selected)
                                    {
                                        currRows[k].Add(current);
                                        current = 0;
                                        prev = false;
                                    }
                                    else if (!_tilesGrid.Tiles[k, kk].Selected)
                                        prev = false;

                                }

                                if (current > 0)
                                    currRows[k].Add(current);
                            }

                            for (int k = 0; k < _columnsCounts.Length; k++)
                            {
                                int current = 0;
                                bool prev = false;
                                currColumns[k] = new List<int>();
                                for (int kk = 0; kk < _tilesGrid.Height; kk++)
                                {
                                    if (_tilesGrid.Tiles[kk, k].Selected)
                                    {
                                        current++;
                                        prev = true;
                                    }
                                    else if (prev && !_tilesGrid.Tiles[kk, k].Selected)
                                    {
                                        currColumns[k].Add(current);
                                        current = 0;
                                        prev = false;
                                    }
                                    else if (!_tilesGrid.Tiles[kk, k].Selected)
                                        prev = false;

                                }

                                if (current > 0)
                                    currColumns[k].Add(current);
                            }

                            ColumnPresenter.Counts = currColumns;
                            RowPresenter.Counts = currRows;

                            ColumnPresenter.Draw();
                            RowPresenter.Draw();
                        }

                        if (!_createMode && Win())
                        {
                            Disable();
                            MessageBox.Show("You won!");
                        }
                    };
                    newButton.DataBindings.Add(leftClick);

                    var img = new Bitmap("./cross.png");
                    
                    Binding rightClick = new Binding("BackgroundImage", _tilesGrid.Tiles[i, j], "Crossed", true);
                    rightClick.Format += (s, e) =>
                    {
                        Button button = (Button)((Binding)s).Control;
                        TableLayoutPanelCellPosition pos = _gridControlView.GridPanel.GetCellPosition(button);

                        if (_tilesGrid.Tiles[pos.Row, pos.Column].Crossed)
                        {
                            e.Value = img;
                        }
                        else
                        {
                            e.Value = null;
                        }
                    };
                    newButton.DataBindings.Add(rightClick);


                    _gridControlView.GridPanel.Controls.Add(newButton, j, i);
                }
            }
        }

        private void Disable()
        {
            _gridControlView.GridPanel.Enabled = false;
        }
        private void InitializeGrid()
        {
            _gridControlView.GridPanel.Controls.Clear();
            _gridControlView.GridPanel.ColumnStyles.Clear();
            _gridControlView.GridPanel.RowStyles.Clear();

            _gridControlView.GridPanel.ColumnCount = _tilesGrid.Width;
            _gridControlView.GridPanel.RowCount = _tilesGrid.Height;

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

        private List<int>[] currRows;
        private List<int>[] currColumns;
        private bool Won = false;
        private bool Win()
        {
            if (Won)
                return false;
            for (int k = 0; k < _rowsCounts.Length; k++)
            {
                int current = 0;
                bool prev = false;
                currRows[k] = new List<int>();
                for (int kk = 0; kk < _columnsCounts.Length; kk++)
                {
                    if (_tilesGrid.Tiles[k, kk].Selected)
                    {
                        current++;
                        prev = true;
                    }
                    else if (prev && !_tilesGrid.Tiles[k, kk].Selected)
                    {
                        currRows[k].Add(current);
                        current = 0;
                        prev = false;
                    }
                    else if (!_tilesGrid.Tiles[k, kk].Selected)
                        prev = false;

                }

                if (current > 0)
                    currRows[k].Add(current);
            }

            for (int k = 0; k < _columnsCounts.Length; k++)
            {
                int current = 0;
                bool prev = false;
                currColumns[k] = new List<int>();
                for (int kk = 0; kk < _rowsCounts.Length; kk++)
                {
                    if (_tilesGrid.Tiles[kk, k].Selected)
                    {
                        current++;
                        prev = true;
                    }
                    else if (prev && !_tilesGrid.Tiles[kk, k].Selected)
                    {
                        currColumns[k].Add(current);
                        current = 0;
                        prev = false;
                    }
                    else if (!_tilesGrid.Tiles[kk, k].Selected)
                        prev = false;

                }

                if (current > 0)
                    currColumns[k].Add(current);
            }


            bool equals = true;

            for (int i = 0; i < currRows.Length; i++)
            {
                if (!currRows[i].SequenceEqual(_rowsCounts[i]))
                {
                    equals = false;
                    break;
                }
            }

            if (equals == false)
                return false;

            for (int i = 0; i < currColumns.Length; i++)
            {
                if (currColumns.SequenceEqual(_columnsCounts))
                {
                    equals = false;
                    break;
                }    
            }

            if (equals)
                Won = true;
            return equals;
        }
    }
}
