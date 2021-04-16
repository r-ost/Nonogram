using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Models
{
    class Game
    {
        public string Difficulty { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<int>[] RowsLabels { get; set; }
        public List<int>[] ColumnsLabels { get; set; }
    }
}
