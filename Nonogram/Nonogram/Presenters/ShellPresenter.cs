using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Presenters
{
    class ShellPresenter
    {
        private ShellFormView _view;
        private GridControlView _gridControlView;
        private CountColumnView _countColumnView;
        private CountRowView _countRowView;

        public ShellPresenter(ShellFormView view)
        {
            _view = view;
            _gridControlView = new GridControlView();
            _countColumnView = new CountColumnView();
            _countRowView = new CountRowView();

            var gridPresenter = new GridPresenter(_gridControlView);
            var columnPresenter = new CountColumnPresenter(_countColumnView, gridPresenter.TilesGrid);
            var rowPresenter = new CountRowPresenter(_countRowView, gridPresenter.TilesGrid);
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

            int meshWidth = _gridControlView.Width;
            int meshHeight = _gridControlView.Height;
            int X = (_view.GridWrapper.Width - meshWidth) / 2;
            int Y = (_view.GridWrapper.Height - meshHeight) / 2;

            _gridControlView.Location = new Point(X, Y);
            _countColumnView.Location = new Point(X, Y - 100);
            _countRowView.Location = new Point(X - 100, Y);

            _view.GridWrapper.Controls.Add(_gridControlView);
            _view.GridWrapper.Controls.Add(_countRowView);
            _view.GridWrapper.Controls.Add(_countColumnView);
        }

    }
}
