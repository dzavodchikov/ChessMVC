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

            // White Pawn moved d2 -> d4
            view.Select(new Square(3, 1));
            Assert.AreEqual(1, viewUpdateCount);
            view.Move(new Square(3, 3));
            Assert.AreEqual(2, viewUpdateCount);

            Assert.IsInstanceOfType(board.Figures[3, 3], typeof(Pawn));
            Assert.AreEqual(Color.WHITE, board.Figures[3, 3].Color);

            // Black Pawn moved e7 -> e5
            view.Select(new Square(4, 6));
            Assert.AreEqual(3, viewUpdateCount);
            view.Move(new Square(4, 4));
            Assert.AreEqual(4, viewUpdateCount);

            Assert.IsInstanceOfType(board.Figures[4, 4], typeof(Pawn));
            Assert.AreEqual(Color.BLACK, board.Figures[4, 4].Color);

            // White Pawn capture Back Pawn
            view.Select(new Square(3, 3));
            Assert.AreEqual(5, viewUpdateCount);
            view.Move(new Square(4, 4));
            Assert.AreEqual(6, viewUpdateCount);

            Assert.IsInstanceOfType(board.Figures[4, 4], typeof(Pawn));
            Assert.AreEqual(Color.WHITE, board.Figures[4, 4].Color);
            Assert.AreEqual(1, board.CapturedFigures.Count);
            Assert.IsInstanceOfType(board.CapturedFigures[0], typeof(Pawn));

        }
    }
}
