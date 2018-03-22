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
        public Knight(Color color, ChessBoard chessBoard)
        {
            this.Color = color;
            this.ChessBoard = chessBoard;
        }

        private bool IsEmptyOnEnemyFigure(int x, int y)
        {
            return this.ChessBoard.Figures[x, y] == null || this.ChessBoard.Figures[x, y].Color != this.Color;
        }

        public override IList<Square> GetAvailableMoves()
        {
            Square cell = this.Square;
            ChessBoard board = this.ChessBoard;
            List<Square> availableMoves = new List<Square>();
            if (cell.X + 1 < ChessBoard.SIZE && cell.Y + 2 < ChessBoard.SIZE && IsEmptyOnEnemyFigure(cell.X + 1, cell.Y + 2))
            {
                availableMoves.Add(new Square(cell.X + 1, cell.Y + 2));
            }
            if (cell.X - 1 > 0 && cell.Y + 2 < ChessBoard.SIZE && IsEmptyOnEnemyFigure(cell.X - 1, cell.Y + 2))
            {
                availableMoves.Add(new Square(cell.X - 1, cell.Y + 2));
            }
            if (cell.X + 1 < ChessBoard.SIZE && cell.Y - 2 >= 0 && IsEmptyOnEnemyFigure(cell.X + 1, cell.Y - 2))
            {
                availableMoves.Add(new Square(cell.X + 1, cell.Y - 2));
            }
            if (cell.X - 1 > 0 && cell.Y - 2 >= 0 && IsEmptyOnEnemyFigure(cell.X - 1, cell.Y - 2))
            {
                availableMoves.Add(new Square(cell.X - 1, cell.Y - 2));
            }
            if (cell.X + 2 < ChessBoard.SIZE && cell.Y + 1 < ChessBoard.SIZE && IsEmptyOnEnemyFigure(cell.X + 2, cell.Y + 1))
            {
                availableMoves.Add(new Square(cell.X + 2, cell.Y + 1));
            }
            if (cell.X + 2 < ChessBoard.SIZE && cell.Y - 1 >= 0 && IsEmptyOnEnemyFigure(cell.X + 2, cell.Y - 1))
            {
                availableMoves.Add(new Square(cell.X + 2, cell.Y -1));
            }
            if (cell.X - 2 >= 0 && cell.Y + 1 < ChessBoard.SIZE && IsEmptyOnEnemyFigure(cell.X - 2, cell.Y + 1))
            {
                availableMoves.Add(new Square(cell.X - 2, cell.Y + 1));
            }
            if (cell.X - 2 >= 0 && cell.Y - 1 >= 0 && IsEmptyOnEnemyFigure(cell.X - 2, cell.Y - 1))
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
