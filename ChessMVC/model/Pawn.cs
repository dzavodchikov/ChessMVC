using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class Pawn : Figure
    {
        public Pawn(Color color)
        {
            this.Color = color;
        }

        public override List<Cell> getAvailableCells(Cell cell, ChessBoard board)
        {
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
    }
}
