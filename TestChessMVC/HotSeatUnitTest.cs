using System;
using ChessMVC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestChessMVC
{
    [TestClass]
    public class HotSeatUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChessBoard board = new ChessBoard();
            IChessController controller = new HotSeatController(board);
            TestBoardView view = new TestBoardView(board);
            view.OnFigureSelected += controller.Select;
            view.OnFigureMove += controller.MoveTo;

            int viewUpdateCount = 0;
            board.OnChanged += () => {
                viewUpdateCount++;
            };

            // White Pawn d2 -> d4
            view.Select(new Cell(3, 1));
            Assert.AreEqual(1, viewUpdateCount);
            view.Move(new Cell(3, 3));
            Assert.AreEqual(2, viewUpdateCount);

            Assert.IsInstanceOfType(board.Figures[3, 3], typeof(Pawn));
            Assert.AreEqual(Color.WHITE, board.Figures[3, 3].Color);

            // Black Pawn e7 -> e5
            view.Select(new Cell(4, 6));
            Assert.AreEqual(3, viewUpdateCount);
            view.Move(new Cell(4, 4));
            Assert.AreEqual(4, viewUpdateCount);

            Assert.IsInstanceOfType(board.Figures[4, 4], typeof(Pawn));
            Assert.AreEqual(Color.BLACK, board.Figures[4, 4].Color);

            // White Pawn eat Back Pawn
            view.Select(new Cell(3, 3));
            Assert.AreEqual(5, viewUpdateCount);
            view.Move(new Cell(4, 4));
            Assert.AreEqual(6, viewUpdateCount);

            Assert.IsInstanceOfType(board.Figures[4, 4], typeof(Pawn));
            Assert.AreEqual(Color.WHITE, board.Figures[4, 4].Color);
            Assert.AreEqual(1, board.EatenFigures.Count);
            Assert.IsInstanceOfType(board.EatenFigures[0], typeof(Pawn));

        }
    }
}
