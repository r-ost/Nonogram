using Nonogram.Models;
using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonogram.Presenters
{
    class CountColumnPresenter
    {
        private CountColumnView _view;

        private List<int>[] _counts;

        public CountColumnPresenter(CountColumnView view, TilesGrid tilesGrid)
        {
            _view = view;

            _counts = new List<int>[tilesGrid.Width];
            for (int i = 0; i < tilesGrid.Width; i++)
            {
                _counts[i] = new List<int>();
            }

            int count = tilesGrid.Width;

            bool prev = false;
            int current = 0;
            for (int j = 0; j < tilesGrid.Width; j++)
            {
                current = 0;
                prev = false;
                for (int i = 0; i < tilesGrid.Height; i++)
                {
                    if (tilesGrid.Tiles[i, j].Selected)
                    {
                        current++;
                        prev = true;
                    }
                    else if (prev && !tilesGrid.Tiles[i, j].Selected)
                    {
                        _counts[j].Add(current);
                        current = 0;
                        prev = false;
                    }
                    else if (!tilesGrid.Tiles[i, j].Selected)
                        prev = false;
                    
                }

                if (current > 0)
                    _counts[j].Add(current);
            }

            _view.ColumnCountTable.Controls.Clear();
            _view.ColumnCountTable.ColumnStyles.Clear();
            _view.ColumnCountTable.RowStyles.Clear();

            _view.ColumnCountTable.ColumnCount = count;
            _view.ColumnCountTable.RowCount = 1;

            for (int i = 0; i < count; i++)
            {
                _view.ColumnCountTable.ColumnStyles.Add(new ColumnStyle() { Width = Tile.Width, SizeType = SizeType.Absolute });

            }
            _view.ColumnCountTable.RowStyles.Add(new RowStyle() { Height = Tile.Height, SizeType = SizeType.Absolute });


            int maxHeight = 100;

            _view.ColumnCountTable.Width = count * Tile.Width;
            _view.ColumnCountTable.Height = maxHeight;

            _view.Width = count * Tile.Width;
            _view.Height = maxHeight;

            for (int i = 0; i < count; i++)
            {
                Label l = new Label();
                l.FlatStyle = FlatStyle.Flat;
                l.Size = new Size(Tile.Width, maxHeight);
                l.Dock = DockStyle.Fill;
                string text = "";
                foreach (var num in _counts[i])
                {
                    text += $"{num}\n";
                }
                text = text.Trim('\n');
                l.Text = text;
                l.TextAlign = ContentAlignment.BottomCenter;
                _view.ColumnCountTable.Controls.Add(l);
            }
        }
    }
}
