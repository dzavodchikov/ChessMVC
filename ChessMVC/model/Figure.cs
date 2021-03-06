﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public abstract class Figure
    {
        public int Points { get; set; }
        public Color Color { get; set; }
        public Square Square { get; set; }
        public abstract IList<Square> GetAvailableMoves(ChessBoard board);
        public abstract Bitmap GetImage();
    }
}
