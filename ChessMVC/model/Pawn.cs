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

        public override List<Cell> GetAvailableCells()
        {
            Cell cell = this.Cell;
            ChessBoard board = this.ChessBoard;
            List<Cell> availableCells = new List<Cell>();
            if (this.Color == Color.WHITE)
            {
                if (cell.Y == 1)
                {
                    availableCells.Add(new Cell(cell.X, cell.Y + 2));
                }
                availableCells.Add(new Cell(cell.X, cell.Y + 1));
                if (board.Figures[cell.X + 1, cell.Y + 1] != null)
                {
                    availableCells.Add(new Cell(cell.X + 1, cell.Y + 1));
                }
                if (board.Figures[cell.X - 1, cell.Y + 1] != null)
                {
                    availableCells.Add(new Cell(cell.X - 1, cell.Y + 1));
                }
            }
            if (this.Color == Color.BLACK)
            {
                if (cell.Y == 6)
                {
                    availableCells.Add(new Cell(cell.X, cell.Y - 2));
                }
                availableCells.Add(new Cell(cell.X, cell.Y - 1));
                if (board.Figures[cell.X + 1, cell.Y - 1] != null)
                {
                    availableCells.Add(new Cell(cell.X + 1, cell.Y - 1));
                }
                if (board.Figures[cell.X - 1, cell.Y - 1] != null)
                {
                    availableCells.Add(new Cell(cell.X - 1, cell.Y - 1));
                }
            }
            return availableCells;
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
