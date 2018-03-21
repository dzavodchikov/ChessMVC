using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class HotSeatController : IChessController
    {
        private ChessBoard board;

        public HotSeatController(ChessBoard board)
        {
            this.board = board;
        }

        public void MoveTo(Cell from, Cell to)
        {
            Figure figure = this.board.Figures[from.X, from.Y];
            if (figure == null)
            {
                throw new Exception();
            }
            if (figure.GetAvailableCells(from, board).Contains(to) == false)
            {
                throw new Exception();
            }
            Figure other = this.board.Figures[to.X, to.Y];
            if (other != null)
            {
                if (figure.Color != other.Color)
                {
                    this.board.EatenFigures.Add(other);
                }
                else
                {
                    throw new Exception();
                }
            }
            this.board.Figures[from.X, from.Y] = null;
            this.board.Figures[to.X, to.Y] = figure;
            this.board.SelectedFigure = null;
            this.board.FireUpdate();
        }

        public void Select(Cell cell)
        {
            Figure figure = this.board.Figures[cell.X, cell.Y];
            if (figure == null)
            {
                throw new Exception();
            }
            this.board.SelectedFigure = cell;
            this.board.FireUpdate();
        }
    }
}
