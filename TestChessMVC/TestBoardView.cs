using ChessMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChessMVC
{
    class TestBoardView : IBoardView
    {
        private ChessBoard board;
        private Cell selectedFigure;

        public TestBoardView(ChessBoard board)
        {
            this.board = board;
        }

        public event FigureSelected OnFigureSelected;
        public event FigureMove OnFigureMove;

        public void Select(Cell cell)
        {
            selectedFigure = cell;
            this.OnFigureSelected(selectedFigure);
        }

        public void Move(Cell cell)
        {
            this.OnFigureMove(selectedFigure, cell);
        }
    }
}
