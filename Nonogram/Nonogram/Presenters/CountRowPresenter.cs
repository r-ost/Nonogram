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
    class CountRowPresenter
    {
        private CountRowView _view;

        private List<int>[] _counts;

        public CountRowPresenter(CountRowView view, TilesGrid tilesGrid)
        {
            _view = view;

            _counts = new List<int>[tilesGrid.Height];
            for (int i = 0; i < tilesGrid.Height; i++)
            {
                _counts[i] = new List<int>();
            }

            int count = tilesGrid.Height;


            bool prev = false;
            int current = 0;
            for (int i = 0; i < tilesGrid.Height; i++)
            {
                current = 0;
                prev = false;
                for (int j = 0; j < tilesGrid.Width; j++)
                {
                    if (tilesGrid.Tiles[i, j].Selected)
                    {
                        current++;
                        prev = true;
                    }
                    else if (prev && !tilesGrid.Tiles[i, j].Selected)
                    {
                        _counts[i].Add(current);
                        current = 0;
                        prev = false;
                    }
                    else if (!tilesGrid.Tiles[i, j].Selected)
                        prev = false;

                }

                if (current > 0)
                    _counts[i].Add(current);
            }

            _view.RowCountTable.Controls.Clear();
            _view.RowCountTable.ColumnStyles.Clear();
            _view.RowCountTable.RowStyles.Clear();

            _view.RowCountTable.ColumnCount = 1;
            _view.RowCountTable.RowCount = count;

            for (int i = 0; i < count; i++)
            {
                _view.RowCountTable.RowStyles.Add(new RowStyle() { Height = Tile.Height, SizeType = SizeType.Absolute });

            }
            _view.RowCountTable.ColumnStyles.Add(new ColumnStyle() { Width = Tile.Width, SizeType = SizeType.Absolute });

            int maxWidth = 100;

            _view.RowCountTable.Width = maxWidth;
            _view.RowCountTable.Height = count * Tile.Width;

            _view.Width = maxWidth;
            _view.Height = count * Tile.Width;


            for (int i = 0; i < count; i++)
            {
                Label l = new Label();
                l.FlatStyle = FlatStyle.Flat;

                string text = "";
                foreach (var num in _counts[i])
                    text += $"{num} ";

                text = text.Trim(' ');
                l.Text = text;

                l.Size = new Size(maxWidth, Tile.Height);
                l.Dock = DockStyle.Fill;
                l.TextAlign = ContentAlignment.MiddleRight;

                _view.RowCountTable.Controls.Add(l);
            }

            
        }
    }
}
