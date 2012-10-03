using Chess.Web.Models.Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Web.Tests
{
    [TestClass]
    public class PieceBishopTest
    {
        [TestMethod]
        public void BishopBasicValidMovesTest()
        {
            Board board = new Board();
            var piece = new PieceBishop(PieceColor.White);

            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(7, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b2"));
            Assert.IsTrue(piece.IsValidMove("h8"));

            board.ClearPieces();
            board.LoadPiece("a8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(7, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b7"));
            Assert.IsTrue(piece.IsValidMove("h1"));

            board.ClearPieces();
            board.LoadPiece("h1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(7, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b7"));
            Assert.IsTrue(piece.IsValidMove("a8"));

            board.ClearPieces();
            board.LoadPiece("h8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(7, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b2"));
            Assert.IsTrue(piece.IsValidMove("a1"));

            board.ClearPieces();
            board.LoadPiece("d4", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(13, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a1"));
            Assert.IsTrue(piece.IsValidMove("h8"));
            Assert.IsTrue(piece.IsValidMove("a7"));
            Assert.IsTrue(piece.IsValidMove("g1"));
        }

        [TestMethod]
        public void BishopCaptureMovesTest()
        {
            Board board = new Board();
            var whitePiece = new PieceBishop(PieceColor.White);
            var blackPiece = new PieceBishop(PieceColor.Black);

            board.LoadPiece("d4", whitePiece);
            board.LoadPiece("g7", blackPiece);
            board.LoadPiece("a1", new PieceRook(PieceColor.White));

            whitePiece.CalculateValidMoves();
            Assert.AreEqual(3 + 3 + 2 + 3, whitePiece.GetValidMovesCount());
            Assert.IsTrue(whitePiece.IsValidMove("c3"));
            Assert.IsTrue(whitePiece.IsValidMove("g7"));
            Assert.IsTrue(whitePiece.IsValidMove("f6"));
            Assert.IsTrue(whitePiece.IsValidMove("a7"));
            Assert.IsFalse(whitePiece.IsValidMove("a1"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(1 + 3 + 1 + 1, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("h8"));
            Assert.IsTrue(blackPiece.IsValidMove("d4"));
            Assert.IsTrue(blackPiece.IsValidMove("f8"));
            Assert.IsTrue(blackPiece.IsValidMove("h6"));
        }
    }
}
