using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Web.Models.Chess;

namespace Chess.Web.Tests
{
    [TestClass]
    public class PieceTests
    {
        [TestMethod]
        public void PawnBasicValidMovesTest()
        {
            Board board = new Board();
            PiecePawn piece = new PiecePawn();

            board.LoadPiece("a2", piece, PieceColor.White);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a3"));
            Assert.IsTrue(piece.IsValidMove("a4"));

            board.ClearPieces();
            board.LoadPiece("a7", piece, PieceColor.White);
            piece.CalculateValidMoves();
            Assert.AreEqual(1, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a8"));

            board.ClearPieces();
            board.LoadPiece("a8", piece, PieceColor.White);
            piece.CalculateValidMoves();
            Assert.AreEqual(0, piece.GetValidMovesCount());

            board.ClearPieces();
            board.LoadPiece("h2", piece, PieceColor.White);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h3"));
            Assert.IsTrue(piece.IsValidMove("h4"));

            board.ClearPieces();
            board.LoadPiece("h7", piece, PieceColor.White);
            piece.CalculateValidMoves();
            Assert.AreEqual(1, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h8"));
        }
    }
}
