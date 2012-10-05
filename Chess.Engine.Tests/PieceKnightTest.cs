using Chess.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Web.Tests
{
    [TestClass]
    public class PiecKnightTest
    {
        [TestMethod]
        public void KnightValidMovesTest()
        {
            Board board = new Board();
            var piece = new PieceKnight(PieceColor.White);

            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b3"));
            Assert.IsTrue(piece.IsValidMove("c2"));

            board.ClearPieces();
            board.LoadPiece("a8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b6"));
            Assert.IsTrue(piece.IsValidMove("c7"));

            board.ClearPieces();
            board.LoadPiece("h1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("f2"));
            Assert.IsTrue(piece.IsValidMove("g3"));

            board.ClearPieces();
            board.LoadPiece("h8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("g6"));
            Assert.IsTrue(piece.IsValidMove("f7"));

            board.ClearPieces();
            board.LoadPiece("d4", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(8, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("c2"));
            Assert.IsTrue(piece.IsValidMove("e2"));
            Assert.IsTrue(piece.IsValidMove("b3"));
            Assert.IsTrue(piece.IsValidMove("f3"));
            Assert.IsTrue(piece.IsValidMove("b5"));
            Assert.IsTrue(piece.IsValidMove("f5"));
            Assert.IsTrue(piece.IsValidMove("c6"));
            Assert.IsTrue(piece.IsValidMove("e6"));
        }

        [TestMethod]
        public void KnightCaptureMovesTest()
        {
            Board board = new Board();
            var whitePiece = new PieceKnight(PieceColor.White);
            var blackPiece = new PieceKnight(PieceColor.Black);

            board.LoadPiece("d4", whitePiece);
            board.LoadPiece("f5", blackPiece);
            board.LoadPiece("c2", new PieceQueen(PieceColor.White));

            whitePiece.CalculateValidMoves();
            Assert.AreEqual(7, whitePiece.GetValidMovesCount());
            Assert.IsFalse(whitePiece.IsValidMove("c2"));
            Assert.IsTrue(whitePiece.IsValidMove("e2"));
            Assert.IsTrue(whitePiece.IsValidMove("b3"));
            Assert.IsTrue(whitePiece.IsValidMove("f3"));
            Assert.IsTrue(whitePiece.IsValidMove("b5"));
            Assert.IsTrue(whitePiece.IsValidMove("f5"));
            Assert.IsTrue(whitePiece.IsValidMove("c6"));
            Assert.IsTrue(whitePiece.IsValidMove("e6"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(8, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("e3"));
            Assert.IsTrue(blackPiece.IsValidMove("g3"));
            Assert.IsTrue(blackPiece.IsValidMove("h4"));
            Assert.IsTrue(blackPiece.IsValidMove("d4"));
            Assert.IsTrue(blackPiece.IsValidMove("h6"));
            Assert.IsTrue(blackPiece.IsValidMove("d6"));
            Assert.IsTrue(blackPiece.IsValidMove("e7"));
            Assert.IsTrue(blackPiece.IsValidMove("g7"));
        }
    }
}
