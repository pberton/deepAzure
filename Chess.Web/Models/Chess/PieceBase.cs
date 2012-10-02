using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public abstract class PieceBase
    {
        public PieceColor Color { get; set; }
        public BoardSquare Square { get; set; }
        public Board Board { get; set; }
        protected List<BoardSquare> ValidMoves = new List<BoardSquare>();

        public static PieceBase CreatePiece(char type)
        {
            switch (type)
            {
                case 'R': // Rook
                    return new PieceRook();
                case 'N': // Knight
                    return new PieceKnight();
                case 'B': // Bishop
                    return new PieceBishop();
                case 'K': // King
                    return new PieceKing();
                case 'Q': // Queen
                    return new PieceQueen();
                default: // Pawn
                    return new PiecePawn();
            }
        }

        public bool IsValidMove(string coord)
        {
            return IsValidMove(coord[0], coord[1]);
        }

        private bool IsValidMove(char x, char y)
        {
            return IsValidMove(this.Board[x, y]);
        }

        public bool IsValidMove(BoardSquare destSquare)
        {
            return (ValidMoves.Contains(destSquare));
        }

        public int GetValidMovesCount()
        {
            return this.ValidMoves.Count;
        }

        public abstract void CalculateValidMoves();
    }

    public enum PieceColor
    {
        White = 0,
        Black = 1
    }
}