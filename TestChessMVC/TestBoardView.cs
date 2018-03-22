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
        private Figure selectedFigure;

        public TestBoardView(ChessBoard board)
        {
            this.board = board;
        }

        public event FigureSelected OnFigureSelected;
        public event FigureMove OnFigureMove;

        public void Select(Square square)
        {
            selectedFigure = this.board.Figures[square.X, square.Y];
            this.OnFigureSelected(selectedFigure);
        }

        public void Move(Square square)
        {
            this.OnFigureMove(square);
        }
    }
}
