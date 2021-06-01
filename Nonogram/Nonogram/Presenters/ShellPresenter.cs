using Newtonsoft.Json;
using Nonogram.Models;
using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nonogram.Presenters
{
    class ShellPresenter
    {
        private readonly ShellFormView _view;

        public ShellPresenter(ShellFormView view)
        {
            _view = view;
            var gridControlView = new GridControlView();
            var countColumnView = new CountColumnView();
            var countRowView = new CountRowView();

            var gridPresenter = new GridPresenter(gridControlView, true, false, 10, 10);
            var columnPresenter = new CountColumnPresenter(countColumnView, gridPresenter.TilesGrid, false);
            var rowPresenter = new CountRowPresenter(countRowView, gridPresenter.TilesGrid, false);
            gridPresenter.RowsCounts = rowPresenter.Counts;
            gridPresenter.ColumnsCounts = columnPresenter.Counts;

            var grid = gridPresenter.TilesGrid;
            for (int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    grid.Tiles[i, j].Selected = false;
                }
            }

            int meshWidth = gridControlView.Width;
            int meshHeight = gridControlView.Height;
            int X = (_view.GridWrapper.Width - meshWidth) / 2;
            int Y = (_view.GridWrapper.Height - meshHeight) / 2;

            gridControlView.Location = new Point(X, Y);
            countColumnView.Location = new Point(X, Y - 100);
            countRowView.Location = new Point(X - 100, Y);

            _view.GridWrapper.Controls.Add(gridControlView);
            _view.GridWrapper.Controls.Add(countRowView);
            _view.GridWrapper.Controls.Add(countColumnView);


            _view.CreatePuzzleSubMenuItem.Click += (s, e) =>
            { 
                var sizeDialog = new SizeDialogBoxView();
                int height = 0, width = 0;

                if (sizeDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _view.GridWrapper.Controls.Clear();


                    height = sizeDialog.GridHeight;
                    width = sizeDialog.GridWidth;

                    var createView = new CreateView();
                    var presenter = new CreatePresenter(createView, width, height);

                    presenter.GridWidth = width;
                    presenter.GridHeight = height;

                    createView.Enabled = true;

                    createView.Location = new Point(0, 0);
                    _view.GridWrapper.Controls.Add(createView);
                }
            };

            _view.LoadSubMenuItem.Click += (s, e) =>
            {
                Stream myStream = null;
                OpenFileDialog theDialog = new OpenFileDialog();

                theDialog.Title = "Open Puzzle JSON File";
                theDialog.Filter = "Json files (*.json)|*.json";
                theDialog.InitialDirectory = @"C:\";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = theDialog.OpenFile()) != null)
                        {
                            StreamReader sr = new StreamReader(myStream);

                            string text = sr.ReadToEnd();
                            Game newGame;// = new Game();
                            using (myStream)
                            {
                               
                                newGame = (Game)JsonConvert.DeserializeObject<Game>(text);
                            }

                            _view.GridWrapper.Controls.Clear();
                            gridControlView = new GridControlView();
                            countColumnView = new CountColumnView();
                            countRowView = new CountRowView();

                            gridPresenter = new GridPresenter(gridControlView, false, false, newGame.Width, newGame.Height, newGame.RowsLabels, newGame.ColumnsLabels);


                            columnPresenter = new CountColumnPresenter(countColumnView, gridPresenter.TilesGrid, false);
                            rowPresenter = new CountRowPresenter(countRowView, gridPresenter.TilesGrid, false);
                            gridPresenter.ColumnPresenter = columnPresenter;
                            gridPresenter.ColumnPresenter.Counts = newGame.ColumnsLabels;
                            gridPresenter.RowPresenter = rowPresenter;
                            gridPresenter.RowPresenter.Counts = newGame.RowsLabels;


                            gridPresenter.RowsCounts= newGame.RowsLabels;
                            gridPresenter.ColumnsCounts = newGame.ColumnsLabels;



                            gridPresenter.ColumnPresenter.Draw();
                            gridPresenter.RowPresenter.Draw();

                            grid = gridPresenter.TilesGrid;
                            for (int i = 0; i < grid.Height; i++)
                            {
                                for (int j = 0; j < grid.Width; j++)
                                {
                                    grid.Tiles[i, j].Selected = false;
                                }
                            }

                            int meshWidth = gridControlView.Width;
                            int meshHeight = gridControlView.Height;
                            int X = (_view.GridWrapper.Width - meshWidth) / 2;
                            int Y = (_view.GridWrapper.Height - meshHeight) / 2;

                            gridControlView.Location = new Point(X, Y);
                            countColumnView.Location = new Point(X, Y - 100);
                            countRowView.Location = new Point(X - 100, Y);

                            _view.GridWrapper.Controls.Add(gridControlView);
                            _view.GridWrapper.Controls.Add(countRowView);
                            _view.GridWrapper.Controls.Add(countColumnView);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }

            };

            _view.RandomSubMenuItem.Click += (s, e) =>
            {
                var sizeDialog = new SizeDialogBoxView();
                int height = 0, width = 0;

                if (sizeDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _view.GridWrapper.Controls.Remove(gridControlView);
                    _view.GridWrapper.Controls.Remove(countColumnView);
                    _view.GridWrapper.Controls.Remove(countRowView);
                    height = sizeDialog.GridHeight;
                    width = sizeDialog.GridWidth;

                    _view.GridWrapper.Controls.Clear();
                    gridControlView = new GridControlView();
                    countColumnView = new CountColumnView();
                    countRowView = new CountRowView();

                    gridPresenter = new GridPresenter(gridControlView, true, false, width, height);


                    columnPresenter = new CountColumnPresenter(countColumnView, gridPresenter.TilesGrid, false);
                    rowPresenter = new CountRowPresenter(countRowView, gridPresenter.TilesGrid, false);
                    gridPresenter.ColumnPresenter = columnPresenter;
                    gridPresenter.RowPresenter = rowPresenter;

                    gridPresenter.RowsCounts = rowPresenter.Counts;
                    gridPresenter.ColumnsCounts = columnPresenter.Counts;


                    gridPresenter.ColumnPresenter.Draw();
                    gridPresenter.RowPresenter.Draw();

                    grid = gridPresenter.TilesGrid;
                    for (int i = 0; i < grid.Height; i++)
                    {
                        for (int j = 0; j < grid.Width; j++)
                        {
                            grid.Tiles[i, j].Selected = false;
                        }
                    }

                    int meshWidth = gridControlView.Width;
                    int meshHeight = gridControlView.Height;
                    int X = (_view.GridWrapper.Width - meshWidth) / 2;
                    int Y = (_view.GridWrapper.Height - meshHeight) / 2;

                    gridControlView.Location = new Point(X, Y);
                    countColumnView.Location = new Point(X, Y - 100);
                    countRowView.Location = new Point(X - 100, Y);

                    _view.GridWrapper.Controls.Add(gridControlView);
                    _view.GridWrapper.Controls.Add(countRowView);
                    _view.GridWrapper.Controls.Add(countColumnView);
                }
            };

            _view.ChooseSubMenuItem.Click += (s, e) =>
           {
               var listDialog = new ChooseView();

               if (listDialog.ShowDialog() == DialogResult.OK)
               {
                   
               }
           };
        }

    }
}
