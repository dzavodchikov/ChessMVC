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
        public Rook(Color color, ChessBoard chessBoard)
        {
            this.Color = color;
            this.ChessBoard = chessBoard;
        }

        public override IList<Square> GetAvailableMoves()
        {
            Square cell = this.Square;
            ChessBoard board = this.ChessBoard;
            List<Square> availableMoves = new List<Square>();
            for (int dir = 0; dir < 4; dir++)
            {
                int x = this.Square.X;
                int y = this.Square.Y;
                Figure figure = null;
                while (figure == null)
                {
                    if (dir < 2)
                    {
                        if (dir % 2 == 0) { x++; } else { x--; }
                    }
                    else
                    {
                        if (dir % 2 == 0) { y++; } else { y--; }
                    }
                    if (x < 0 || y < 0 || x >= ChessBoard.SIZE || y >= ChessBoard.SIZE)
                    {
                        break;
                    }
                    figure = this.ChessBoard.Figures[x, y];
                    if (figure == null)
                    {
                        availableMoves.Add(new Square(x, y));
                    }
                    else
                    {
                        if (figure.Color != this.Color)
                        {
                            availableMoves.Add(new Square(x, y));
                        }
                    }
                }
            }
            return availableMoves;
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
