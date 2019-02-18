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
            if (cell.X + 1 < ChessBoard.SIZE && cell.Y + 2 < ChessBoard.SIZE && board.IsEmptyOrEnemyFigure(cell.X + 1, cell.Y + 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 1, cell.Y + 2));
            }
            if (cell.X - 1 > 0 && cell.Y + 2 < ChessBoard.SIZE && board.IsEmptyOrEnemyFigure(cell.X - 1, cell.Y + 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 1, cell.Y + 2));
            }
            if (cell.X + 1 < ChessBoard.SIZE && cell.Y - 2 >= 0 && board.IsEmptyOrEnemyFigure(cell.X + 1, cell.Y - 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 1, cell.Y - 2));
            }
            if (cell.X - 1 > 0 && cell.Y - 2 >= 0 && board.IsEmptyOrEnemyFigure(cell.X - 1, cell.Y - 2, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 1, cell.Y - 2));
            }
            if (cell.X + 2 < ChessBoard.SIZE && cell.Y + 1 < ChessBoard.SIZE && board.IsEmptyOrEnemyFigure(cell.X + 2, cell.Y + 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 2, cell.Y + 1));
            }
            if (cell.X + 2 < ChessBoard.SIZE && cell.Y - 1 >= 0 && board.IsEmptyOrEnemyFigure(cell.X + 2, cell.Y - 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X + 2, cell.Y -1));
            }
            if (cell.X - 2 >= 0 && cell.Y + 1 < ChessBoard.SIZE && board.IsEmptyOrEnemyFigure(cell.X - 2, cell.Y + 1, this.Color))
            {
                availableMoves.Add(new Square(cell.X - 2, cell.Y + 1));
            }
            if (cell.X - 2 >= 0 && cell.Y - 1 >= 0 && board.IsEmptyOrEnemyFigure(cell.X - 2, cell.Y - 1, this.Color))
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
