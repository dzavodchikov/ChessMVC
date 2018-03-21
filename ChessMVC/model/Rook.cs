using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class Rook : Figure
    {
        public Rook(Color color)
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
                return Resources.white_rook;
            }
            else
            {
                return Resources.black_rook;
            }
        }
    }
}
