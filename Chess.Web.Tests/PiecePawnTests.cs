using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Web.Models.Chess;

namespace Chess.Web.Tests
{
    [TestClass]
    public class PiecePawnTests
    {
        [TestMethod]
        public void WhitePawnBasicValidMovesTest()
        {
            Board board = new Board();
            PiecePawn piece = new PiecePawn(PieceColor.White);

            board.LoadPiece("a2", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a3"));
            Assert.IsTrue(piece.IsValidMove("a4"));

            board.ClearPieces();
            board.LoadPiece("a7", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(1, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a8"));

            board.ClearPieces();
            board.LoadPiece("a8", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(0, piece.GetValidMovesCount());

            board.ClearPieces();
            board.LoadPiece("h2", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h3"));
            Assert.IsTrue(piece.IsValidMove("h4"));

            board.ClearPieces();
            board.LoadPiece("h7", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(1, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h8"));
        }

        [TestMethod]
        public void BlackPawnBasicValidMovesTest()
        {
            Board board = new Board();
            PiecePawn piece = new PiecePawn(PieceColor.Black);

            board.LoadPiece("a7", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a6"));
            Assert.IsTrue(piece.IsValidMove("a5"));

            board.ClearPieces();
            board.LoadPiece("a2", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(1, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("a1"));

            board.ClearPieces();
            board.LoadPiece("a1", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(0, piece.GetValidMovesCount());

            board.ClearPieces();
            board.LoadPiece("h7", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(2, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h6"));
            Assert.IsTrue(piece.IsValidMove("h5"));

            board.ClearPieces();
            board.LoadPiece("h2", piece);
            piece.CalculateValidMoves();
            Assert.AreEqual(1, piece.GetValidMovesCount());
            Assert.IsTrue(piece.IsValidMove("h1"));
        }

        [TestMethod]
        public void PawnCaptureMovesTest()
        {
            Board board = new Board();
            PiecePawn whitePiece = new PiecePawn(PieceColor.White);
            PiecePawn blackPiece = new PiecePawn(PieceColor.Black);

            board.LoadPiece("a2", whitePiece);
            board.LoadPiece("b3", blackPiece);
            whitePiece.CalculateValidMoves();
            Assert.AreEqual(3, whitePiece.GetValidMovesCount());
            Assert.IsTrue(whitePiece.IsValidMove("a3"));
            Assert.IsTrue(whitePiece.IsValidMove("a4"));
            Assert.IsTrue(whitePiece.IsValidMove("b3"));

            blackPiece.CalculateValidMoves();
            Assert.AreEqual(2, blackPiece.GetValidMovesCount());
            Assert.IsTrue(blackPiece.IsValidMove("b2"));
            Assert.IsTrue(blackPiece.IsValidMove("a2"));
        }
    }
}
