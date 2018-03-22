using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class King : Figure
    {
        public King(Color color, ChessBoard chessBoard)
        {
            this.Color = color;
            this.ChessBoard = chessBoard;
        }

        public override IList<Square> GetAvailableMoves()
        {
            throw new NotImplementedException();
        }

        public override Bitmap GetImage()
        {
            if (this.Color == Color.WHITE)
            {
                return Resources.white_king;
            }
            else
            {
                return Resources.black_king;
            }
        }
    }
}
