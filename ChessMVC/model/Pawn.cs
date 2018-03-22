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
        public Pawn(Color color, ChessBoard chessBoard)
        {
            this.Color = color;
            this.ChessBoard = chessBoard;
        }

        public override IList<Square> GetAvailableMoves()
        {
            Square cell = this.Square;
            ChessBoard board = this.ChessBoard;
            List<Square> availableMoves = new List<Square>();
            if (this.Color == Color.WHITE)
            {
                if (board.Figures[cell.X, cell.Y + 1] == null)
                {
                    if (cell.Y == 1)
                    {
                        availableMoves.Add(new Square(cell.X, cell.Y + 2));
                    }
                    availableMoves.Add(new Square(cell.X, cell.Y + 1));
                }
                if (cell.X != ChessBoard.SIZE - 1 && board.Figures[cell.X + 1, cell.Y + 1] != null && board.Figures[cell.X + 1, cell.Y + 1].Color != this.Color)
                {
                    availableMoves.Add(new Square(cell.X + 1, cell.Y + 1));
                }
                if (cell.X != 0 && board.Figures[cell.X - 1, cell.Y + 1] != null && board.Figures[cell.X - 1, cell.Y + 1].Color != this.Color)
                {
                    availableMoves.Add(new Square(cell.X - 1, cell.Y + 1));
                }
            }
            if (this.Color == Color.BLACK)
            {
                if (board.Figures[Square.X, Square.Y - 1] == null)
                {
                    if (cell.Y == 6)
                    {
                        availableMoves.Add(new Square(cell.X, cell.Y - 2));
                    }
                    availableMoves.Add(new Square(cell.X, cell.Y - 1));
                }
                if (cell.X != ChessBoard.SIZE - 1 && board.Figures[cell.X + 1, cell.Y - 1] != null && board.Figures[cell.X + 1, cell.Y - 1].Color != this.Color)
                {
                    availableMoves.Add(new Square(cell.X + 1, cell.Y - 1));
                }
                if (cell.X != 0 && board.Figures[cell.X - 1, cell.Y - 1] != null && board.Figures[cell.X - 1, cell.Y - 1].Color != this.Color)
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
