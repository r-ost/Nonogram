﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Models
{
    class TilesGrid
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public Tile[,] Tiles { get; set; }
    }
}
