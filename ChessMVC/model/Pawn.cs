using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class Pawn : Figure
    {
        public Pawn(Color color)
        {
            this.Points = 1;
            this.Color = color;
        }

        public override IList<Square> GetAvailableMoves(ChessBoard board)
        {
            Square cell = this.Square;
            List<Square> availableMoves = new List<Square>();
            if (this.Color == Color.WHITE)
            {
                if (board.IsValid(cell.X, cell.Y + 1) && board.IsEmpty(cell.X, cell.Y + 1))
                {
                    if (cell.Y == 1 && board.IsEmpty(cell.X, cell.Y + 2))
                    {
                        availableMoves.Add(new Square(cell.X, cell.Y + 2));
                    }
                    availableMoves.Add(new Square(cell.X, cell.Y + 1));
                }
                if (board.IsValid(cell.X + 1, cell.Y + 1) && board.IsEnemyFigure(cell.X + 1, cell.Y + 1, this.Color))
                {
                    availableMoves.Add(new Square(cell.X + 1, cell.Y + 1));
                }
                if (board.IsValid(cell.X - 1, cell.Y + 1) && board.IsEnemyFigure(cell.X - 1, cell.Y + 1, this.Color))
                {
                    availableMoves.Add(new Square(cell.X - 1, cell.Y + 1));
                }
            }
            if (this.Color == Color.BLACK)
            {
                if (board.IsValid(cell.X, cell.Y - 1) && board.IsEmpty(cell.X, cell.Y - 1))
                {
                    if (cell.Y == 6 && board.IsEmpty(cell.X, cell.Y -2))
                    {
                        availableMoves.Add(new Square(cell.X, cell.Y - 2));
                    }
                    availableMoves.Add(new Square(cell.X, cell.Y - 1));
                }
                if (board.IsValid(cell.X + 1, cell.Y - 1) && board.IsEnemyFigure(cell.X + 1, cell.Y - 1, this.Color))
                {
                    availableMoves.Add(new Square(cell.X + 1, cell.Y - 1));
                }
                if (board.IsValid(cell.X - 1, cell.Y - 1) && board.IsEnemyFigure(cell.X - 1, cell.Y - 1, this.Color))
                {
                    availableMoves.Add(new Square(cell.X - 1, cell.Y - 1));
                }
            }
            return availableMoves;
        }

        public override Bitmap GetImage()
        {
            if (this.Color == Color.WHITE)
            {
                return Resources.white_pawn;
            }
            else
            {
                return Resources.black_pawn;
            }
        }
    }
}
