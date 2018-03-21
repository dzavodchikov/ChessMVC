using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class Knight : Figure
    {
        public Knight(Color color)
        {
            this.Color = color;
        }

        public override List<Cell> GetAvailableCells(Cell cell, ChessBoard board)
        {
            throw new NotImplementedException();
        }

        public override Bitmap GetImage()
        {
            if (this.Color == Color.WHITE)
            {
                return Resources.white_knight;
            }
            else
            {
                return Resources.black_knight;
            }
        }
    }
}
