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
    public class PiecKingTest
    {
        [TestMethod]
        public void KingValidMovesTest()
        {
            Board board = new Board();
            var piece = new PieceKing(PieceColor.White);

            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(3, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b1"));
            Assert.IsTrue(piece.IsValidMove("a2"));
            Assert.IsTrue(piece.IsValidMove("b2"));

            board.ClearPieces();
            board.LoadPiece("a8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(3, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a7"));
            Assert.IsTrue(piece.IsValidMove("b7"));
            Assert.IsTrue(piece.IsValidMove("b8"));

            board.ClearPieces();
            board.LoadPiece("h1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(3, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h2"));
            Assert.IsTrue(piece.IsValidMove("g1"));
            Assert.IsTrue(piece.IsValidMove("g2"));

            board.ClearPieces();
            board.LoadPiece("h8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(3, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("g8"));
            Assert.IsTrue(piece.IsValidMove("g7"));
            Assert.IsTrue(piece.IsValidMove("h7"));

            board.ClearPieces();
            board.LoadPiece("d4", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(3 + 2 + 3, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("c3"));
            Assert.IsTrue(piece.IsValidMove("d3"));
            Assert.IsTrue(piece.IsValidMove("e3"));
            Assert.IsTrue(piece.IsValidMove("c4"));
            Assert.IsTrue(piece.IsValidMove("e4"));
            Assert.IsTrue(piece.IsValidMove("c5"));
            Assert.IsTrue(piece.IsValidMove("d5"));
            Assert.IsTrue(piece.IsValidMove("e5"));
        }

        [TestMethod]
        public void KingCaptureMovesTest()
        {
            Board board = new Board();
            var whitePiece = new PieceKing(PieceColor.White);
            var blackPiece = new PieceKing(PieceColor.Black);

            board.LoadPiece("d4", whitePiece);
            board.LoadPiece("e5", blackPiece);
            board.LoadPiece("e3", new PieceQueen(PieceColor.White));

            whitePiece.CalculateValidMoves();
            Assert.AreEqual(2 + 2 + 3, whitePiece.GetValidMovesCount());
            Assert.IsTrue(whitePiece.IsValidMove("c3"));
            Assert.IsTrue(whitePiece.IsValidMove("d3"));
            Assert.IsFalse(whitePiece.IsValidMove("e3"));
            Assert.IsTrue(whitePiece.IsValidMove("c4"));
            Assert.IsTrue(whitePiece.IsValidMove("e4"));
            Assert.IsTrue(whitePiece.IsValidMove("c5"));
            Assert.IsTrue(whitePiece.IsValidMove("d5"));
            Assert.IsTrue(whitePiece.IsValidMove("e5"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(3 + 2 + 3, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("d4"));
            Assert.IsTrue(blackPiece.IsValidMove("e4"));
            Assert.IsTrue(blackPiece.IsValidMove("f4"));
            Assert.IsTrue(blackPiece.IsValidMove("d5"));
            Assert.IsTrue(blackPiece.IsValidMove("f5"));
            Assert.IsTrue(blackPiece.IsValidMove("d6"));
            Assert.IsTrue(blackPiece.IsValidMove("e6"));
            Assert.IsTrue(blackPiece.IsValidMove("f6"));
        }
    }
}
