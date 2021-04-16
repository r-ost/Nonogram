using Newtonsoft.Json;
using Nonogram.Models;
using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Nonogram.Presenters
{
    class CreatePresenter
    {
        private CreateView _createView;

        public int GridHeight { get; set; } = 10;
        public int GridWidth { get; set; } = 10;

        public CreatePresenter(CreateView createView, int width, int height)
        {
            GridHeight = height;
            GridWidth = width;
            _createView = createView;

            var grid = new GridControlView();
            var gridPresenter = new GridPresenter(grid, false, true, GridWidth, GridHeight);

            var columnsLabels = new CountColumnView();
            var columnPresenter = new CountColumnPresenter(columnsLabels, gridPresenter.TilesGrid, true);

            var rowsLabels = new CountRowView();
            var rowPresenter = new CountRowPresenter(rowsLabels, gridPresenter.TilesGrid, true);

            gridPresenter.RowPresenter = rowPresenter;
            gridPresenter.ColumnPresenter = columnPresenter;

            List<int>[] rows = new List<int>[GridHeight];
            List<int>[] columns = new List<int>[GridWidth];

            for (int i = 0; i < GridHeight; i++)
            {
                rows[i] = new List<int>();
                rows[i].Add(0);
            }
            for (int i = 0; i < GridWidth; i++)
            {   
                columns[i] = new List<int>();
                columns[i].Add(0);
            }

            columnPresenter.Counts = columns;
            rowPresenter.Counts = rows;

            gridPresenter.RowsCounts = rows;
            gridPresenter.ColumnsCounts = columns;


            var location = grid.Location;

            grid.Location = new System.Drawing.Point(location.X + 100, location.Y + 100);

            location = grid.Location;
            columnsLabels.Location = new System.Drawing.Point(location.X, location.Y - 100);
            rowsLabels.Location = new System.Drawing.Point(location.X - 100, location.Y);

            _createView.GridPanel.Width = GridWidth * Tile.Width + 100;
            _createView.GridPanel.Height = GridHeight * Tile.Height + 100;

            _createView.GridPanel.Controls.Add(grid);
            _createView.GridPanel.Controls.Add(columnsLabels);
            _createView.GridPanel.Controls.Add(rowsLabels);

            _createView.Save.Click += (s, e) =>
            {
                Game newGame = new Game() {
                    ColumnsLabels = gridPresenter.ColumnPresenter.Counts,
                    RowsLabels = gridPresenter.RowPresenter.Counts,
                    Difficulty = _createView.Difficulty.Text,
                    Height = GridHeight,
                    Width = GridWidth,
                    Title = _createView.Title.Text
                };

                using (System.Windows.Forms.SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Json files (*.json)|*.json";
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {

                        System.IO.StreamWriter file = new System.IO.StreamWriter(dialog.FileName.ToString());

                        var stringJson = JsonConvert.SerializeObject(newGame); 

                        file.WriteLine(stringJson);

                        file.Close();
                    }
                }

            };

        }
    }
}
