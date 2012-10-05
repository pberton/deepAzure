using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Engine;

namespace Chess.Web.Tests
{
    [TestClass]
    public class BasicEngineTests
    {
        [TestMethod]
        public void BasicEngineConstructorTest()
        {
            IEngine engine = new BasicEngine();
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void BasicEngineLoadPiecesTest()
        {
            IEngine engine = new BasicEngine();

            engine.LoadBoardFromArray(new string[] { "a2", "Rb2", "Nc2", "Bd2", "Qe2", "Kf2" }, null);
            AssertPieceLoaded(engine, "a2", typeof(PiecePawn), PieceColor.White);
            AssertPieceLoaded(engine, "b2", typeof(PieceRook), PieceColor.White);
            AssertPieceLoaded(engine, "c2", typeof(PieceKnight), PieceColor.White);
            AssertPieceLoaded(engine, "d2", typeof(PieceBishop), PieceColor.White);
            AssertPieceLoaded(engine, "e2", typeof(PieceQueen), PieceColor.White);
            AssertPieceLoaded(engine, "f2", typeof(PieceKing), PieceColor.White);

            engine.LoadBoardFromArray(null, new string[] { "a8", "Rb8", "Nc8", "Bd8", "Qe8", "Kf8" });
            AssertPieceLoaded(engine, "a8", typeof(PiecePawn), PieceColor.Black);
            AssertPieceLoaded(engine, "b8", typeof(PieceRook), PieceColor.Black);
            AssertPieceLoaded(engine, "c8", typeof(PieceKnight), PieceColor.Black);
            AssertPieceLoaded(engine, "d8", typeof(PieceBishop), PieceColor.Black);
            AssertPieceLoaded(engine, "e8", typeof(PieceQueen), PieceColor.Black);
            AssertPieceLoaded(engine, "f8", typeof(PieceKing), PieceColor.Black);
        }

        private void AssertPieceLoaded(IEngine engine, string coord, Type type, PieceColor color)
        {
            var piece = engine.Board[coord].Piece;
            Assert.IsNotNull(piece);
            Assert.AreEqual(color, piece.Color);
            Assert.IsInstanceOfType(piece, type);
        }
    }
}
