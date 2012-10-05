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
    public class PieceRookTest
    {
        [TestMethod]
        public void RookBasicValidMovesTest()
        {
            Board board = new Board();
            PieceRook piece = new PieceRook(PieceColor.White);

            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(14, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a8"));
            Assert.IsTrue(piece.IsValidMove("h1"));

            board.ClearPieces();
            board.LoadPiece("h8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(14, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a8"));
            Assert.IsTrue(piece.IsValidMove("h1"));

            board.ClearPieces();
            board.LoadPiece("d4", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(14, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("d1"));
            Assert.IsTrue(piece.IsValidMove("d8"));
            Assert.IsTrue(piece.IsValidMove("a4"));
            Assert.IsTrue(piece.IsValidMove("h4"));
        }

        [TestMethod]
        public void RookCaptureMovesTest()
        {
            Board board = new Board();
            PieceRook whitePiece = new PieceRook(PieceColor.White);
            PieceRook blackPiece = new PieceRook(PieceColor.Black);

            board.LoadPiece("a1", whitePiece);
            board.LoadPiece("a7", blackPiece);
            board.LoadPiece("g1", new PieceRook(PieceColor.White));
            whitePiece.CalculateValidMoves();
            Assert.AreEqual(5+6, whitePiece.GetValidMovesCount());
            Assert.IsTrue(whitePiece.IsValidMove("a7"));
            Assert.IsFalse(whitePiece.IsValidMove("a8"));
            Assert.IsFalse(whitePiece.IsValidMove("g1"));
            Assert.IsTrue(whitePiece.IsValidMove("f1"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(1+6+7, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("a1"));
            Assert.IsTrue(blackPiece.IsValidMove("a8"));
            Assert.IsTrue(blackPiece.IsValidMove("h7"));
            Assert.IsFalse(blackPiece.IsValidMove("f1"));
        }
    }
}
