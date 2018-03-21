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
            if (figure.GetAvailableCells().Contains(to) == false)
            {
                throw new Exception("Can't move to this cell");
            }
            Figure other = this.board.Figures[to.X, to.Y];
            if (other != null)
            {
                if (figure.Color != other.Color)
                {
                    this.board.EatFigure(other);
                }
                else
                {
                    throw new Exception("Can't eat own figure");
                }
            }
            this.board.ClearField(new Cell(from.X, from.Y));
            this.board.PutFigureOnField(new Cell(to.X, to.Y), figure);
            this.board.SelectedFigure = null;
            this.board.Turns.Add(this.CreateTurn(figure, from, to));
            this.board.NextTurn = this.board.NextTurn == Color.WHITE ? Color.BLACK : Color.WHITE;
            this.board.FireUpdate();
        }

        private string CreateTurn(Figure figure, Cell from, Cell to)
        {
            return figure.Color + " " + figure.GetType().Name + " " + GetFieldAlpha(from.X) + GetFieldNum(from.Y) + " -> " + GetFieldAlpha(to.X) + GetFieldNum(to.Y);
        }

        private char GetFieldAlpha(int x)
        {
            byte b = (byte) (65 + x);
            return (char) b;
        }

        private int GetFieldNum(int x)
        {
            return x + 1;
        }

        public void Select(Cell cell)
        {
            Figure figure = this.board.Figures[cell.X, cell.Y];
            if (figure == null)
            {
                throw new Exception("Please select " + this.board.NextTurn + " figure");
            }
            if (figure.Color != this.board.NextTurn)
            {
                throw new Exception("Please select " + this.board.NextTurn + " figure");
            }
            this.board.SelectedFigure = cell;
            this.board.FireUpdate();
        }
    }
}
