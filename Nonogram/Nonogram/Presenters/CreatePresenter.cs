using Nonogram.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Presenters
{
    class CreatePresenter
    {
        private CreateView _createView;

        public int GridHeight { get; set; }
        public int GridWidth { get; set; }

        public CreatePresenter(CreateView createView, int width, int height)
        {
            GridHeight = height;
            GridWidth = width;
            _createView = createView;

            var grid = new GridControlView();
            var gridPresenter = new GridPresenter(grid, false, GridWidth, GridHeight);
            

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

            //gridPresenter.RowsCounts = rows;
            //gridPresenter.ColumnsCounts = columns;
            //gridPresenter.RowsCounts = ;
            //gridPresenter.ColumnsCounts = 3;
            _createView.GridPanel.Controls.Add(grid);
        }
    }
}
