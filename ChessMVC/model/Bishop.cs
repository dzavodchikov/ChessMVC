using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class Bishop : Figure
    {
        public Bishop(Color color)
        {
            this.Color = color;
        }

        public override IList<Square> GetAvailableMoves(ChessBoard board)
        {
            Square cell = this.Square;
            List<Square> availableMoves = new List<Square>();
            for (int dir = 0; dir < 4; dir++)
            {
                int x = cell.X;
                int y = cell.Y;
                Figure figure = null;
                while (figure == null)
                {
                    if (dir < 2) { x++; } else { x--; }
                    if (dir % 2 == 0) { y++; } else { y--; }
                    if (x < 0 || y < 0 || x >= ChessBoard.SIZE || y >= ChessBoard.SIZE)
                    {
                        break;
                    }
                    figure = board.Figures[x, y];
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
                return Resources.white_bishop;
            }
            else
            {
                return Resources.black_bishop;
            }
            
        }
    }
}
