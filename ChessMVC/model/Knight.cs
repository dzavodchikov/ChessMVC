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

        public override IList<Square> GetAvailableMoves(ChessBoard board)
        {
            Square cell = this.Square;
            List<Square> availableMoves = new List<Square>();
            if (board.IsValid(cell.X + 1, cell.Y + 2) && board.IsEmptyOrEnemyFigure(cell.X + 1, cell.Y + 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 1, cell.Y + 2));
            }
            if (board.IsValid(cell.X - 1, cell.Y + 2) && board.IsEmptyOrEnemyFigure(cell.X - 1, cell.Y + 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 1, cell.Y + 2));
            }
            if (board.IsValid(cell.X + 1, cell.Y - 2) && board.IsEmptyOrEnemyFigure(cell.X + 1, cell.Y - 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 1, cell.Y - 2));
            }
            if (board.IsValid(cell.X - 1, cell.Y - 2) && board.IsEmptyOrEnemyFigure(cell.X - 1, cell.Y - 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 1, cell.Y - 2));
            }
            if (board.IsValid(cell.X + 2, cell.Y + 1) && board.IsEmptyOrEnemyFigure(cell.X + 2, cell.Y + 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 2, cell.Y + 1));
            }
            if (board.IsValid(cell.X + 2, cell.Y - 1) && board.IsEmptyOrEnemyFigure(cell.X + 2, cell.Y - 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 2, cell.Y -1));
            }
            if (board.IsValid(cell.X - 2, cell.Y + 1) && board.IsEmptyOrEnemyFigure(cell.X - 2, cell.Y + 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 2, cell.Y + 1));
            }
            if (board.IsValid(cell.X - 2, cell.Y - 1) && board.IsEmptyOrEnemyFigure(cell.X - 2, cell.Y - 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 2, cell.Y - 1));
            }
            return availableMoves;
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
