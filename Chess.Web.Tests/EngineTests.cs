using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Web.Models.Chess;

namespace Chess.Web.Tests
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void EngineConstructorTest()
        {
            IEngine engine = new Engine();
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void EngineLoadPiecesTest()
        {
            IEngine engine = new Engine();

            engine.LoadBoardFromArray(new string[] { "a2", "Rb2", "Nc2", "Bd2", "Qe2", "Kf2" }, null);
            AssertPieceLoaded(engine, 48, typeof(PiecePawn), PieceColor.White);
            AssertPieceLoaded(engine, 49, typeof(PieceRook), PieceColor.White);
            AssertPieceLoaded(engine, 50, typeof(PieceKnight), PieceColor.White);
            AssertPieceLoaded(engine, 51, typeof(PieceBishop), PieceColor.White);
            AssertPieceLoaded(engine, 52, typeof(PieceQueen), PieceColor.White);
            AssertPieceLoaded(engine, 53, typeof(PieceKing), PieceColor.White);

            engine.LoadBoardFromArray(null, new string[] { "a8", "Rb8", "Nc8", "Bd8", "Qe8", "Kf8" });
            AssertPieceLoaded(engine, 0, typeof(PiecePawn), PieceColor.Black);
            AssertPieceLoaded(engine, 1, typeof(PieceRook), PieceColor.Black);
            AssertPieceLoaded(engine, 2, typeof(PieceKnight), PieceColor.Black);
            AssertPieceLoaded(engine, 3, typeof(PieceBishop), PieceColor.Black);
            AssertPieceLoaded(engine, 4, typeof(PieceQueen), PieceColor.Black);
            AssertPieceLoaded(engine, 5, typeof(PieceKing), PieceColor.Black);
        }

        private void AssertPieceLoaded(IEngine engine, int index, Type type, PieceColor color)
        {
            var piece = engine.Board[index].Piece;
            Assert.IsNotNull(piece);
            Assert.AreEqual(color, piece.Color);
            Assert.IsInstanceOfType(piece, type);
        }
    }
}
