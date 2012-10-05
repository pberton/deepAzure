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
    public class PieceQueenTest
    {
        [TestMethod]
        public void QueenValidDiagonalMovesTest()
        {
            Board board = new Board();
            var piece = new PieceQueen(PieceColor.White);

            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(21, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b2"));
            Assert.IsTrue(piece.IsValidMove("h8"));

            board.ClearPieces();
            board.LoadPiece("a8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(21, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b7"));
            Assert.IsTrue(piece.IsValidMove("h1"));

            board.ClearPieces();
            board.LoadPiece("h1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(21, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b7"));
            Assert.IsTrue(piece.IsValidMove("a8"));

            board.ClearPieces();
            board.LoadPiece("h8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(21, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("b2"));
            Assert.IsTrue(piece.IsValidMove("a1"));

            board.ClearPieces();
            board.LoadPiece("d4", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(13 + 14, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a1"));
            Assert.IsTrue(piece.IsValidMove("h8"));
            Assert.IsTrue(piece.IsValidMove("a7"));
            Assert.IsTrue(piece.IsValidMove("g1"));
        }

        [TestMethod]
        public void QueenCaptureDiagonalMovesTest()
        {
            Board board = new Board();
            var whitePiece = new PieceQueen(PieceColor.White);
            var blackPiece = new PieceQueen(PieceColor.Black);

            board.LoadPiece("d4", whitePiece);
            board.LoadPiece("g7", blackPiece);
            board.LoadPiece("a1", new PieceQueen(PieceColor.White));

            whitePiece.CalculateValidMoves();
            Assert.AreEqual(3 + 3 + 2 + 3 + 14, whitePiece.GetValidMovesCount());
            Assert.IsTrue(whitePiece.IsValidMove("c3"));
            Assert.IsTrue(whitePiece.IsValidMove("g7"));
            Assert.IsTrue(whitePiece.IsValidMove("f6"));
            Assert.IsTrue(whitePiece.IsValidMove("a7"));
            Assert.IsFalse(whitePiece.IsValidMove("a1"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(1 + 3 + 1 + 1 + 14, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("h8"));
            Assert.IsTrue(blackPiece.IsValidMove("d4"));
            Assert.IsTrue(blackPiece.IsValidMove("f8"));
            Assert.IsTrue(blackPiece.IsValidMove("h6"));
        }
        [TestMethod]
        public void QueenBasicValidLateralMovesTest()
        {
            Board board = new Board();
            var piece = new PieceQueen(PieceColor.White);

            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(21, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a8"));
            Assert.IsTrue(piece.IsValidMove("h1"));

            board.ClearPieces();
            board.LoadPiece("h8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(21, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a8"));
            Assert.IsTrue(piece.IsValidMove("h1"));

            board.ClearPieces();
            board.LoadPiece("d4", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(13 + 14, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("d1"));
            Assert.IsTrue(piece.IsValidMove("d8"));
            Assert.IsTrue(piece.IsValidMove("a4"));
            Assert.IsTrue(piece.IsValidMove("h4"));
        }

        [TestMethod]
        public void QueenCaptureLateralMovesTest()
        {
            Board board = new Board();
            var whitePiece = new PieceQueen(PieceColor.White);
            var blackPiece = new PieceQueen(PieceColor.Black);

            board.LoadPiece("a1", whitePiece);
            board.LoadPiece("a7", blackPiece);
            board.LoadPiece("g1", new PieceRook(PieceColor.White));

            whitePiece.CalculateValidMoves();
            Assert.AreEqual(5 + 6 + 7, whitePiece.GetValidMovesCount());
            Assert.IsTrue(whitePiece.IsValidMove("a7"));
            Assert.IsFalse(whitePiece.IsValidMove("a8"));
            Assert.IsFalse(whitePiece.IsValidMove("g1"));
            Assert.IsTrue(whitePiece.IsValidMove("f1"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(1 + 6 + 7 + 6 + 1, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("a1"));
            Assert.IsTrue(blackPiece.IsValidMove("a8"));
            Assert.IsTrue(blackPiece.IsValidMove("h7"));
            Assert.IsFalse(blackPiece.IsValidMove("f1"));
        }
    }
}
