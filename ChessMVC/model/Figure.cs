using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public abstract class Figure
    {
        public Color Color { get; set; }
        public Cell Cell { get; set; }
        public ChessBoard ChessBoard { get; set; }
        public abstract List<Cell> GetAvailableCells();
        // FIXME 
        public abstract Bitmap GetImage();
    }
}
