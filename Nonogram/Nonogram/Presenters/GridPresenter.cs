using Nonogram.Models;
using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Presenters
{
    class GridPresenter 
    {
        private GridControlView _gridControlView;
        private TilesGrid _grid;

        public TilesGrid Grid { get => _grid; }

        public int GridHeight { get => _grid.Height; } 
        public int GridWidth { get => _grid.Width; }

        public int TileWidth { get => Tile.Width; }
        public int TileHeight { get => Tile.Height; }


        public GridPresenter(GridControlView gridControlView)
        {
            _gridControlView = gridControlView;
            _grid = new TilesGrid();
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
        }

        public bool isSelected(int i, int j)
        {
            return _grid.Tiles[i, j].Selected;
        }

        
    }
}
