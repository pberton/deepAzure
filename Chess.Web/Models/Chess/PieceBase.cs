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

        public static PieceBase CreatePiece(char type, PieceColor color)
        {
            switch (type)
            {
                case 'R': // Rook
                    return new PieceRook(color);
                case 'N': // Knight
                    return new PieceKnight(color);
                case 'B': // Bishop
                    return new PieceBishop(color);
                case 'K': // King
                    return new PieceKing(color);
                case 'Q': // Queen
                    return new PieceQueen(color);
                default: // Pawn
                    return new PiecePawn(color);
            }
        }

        public bool IsValidMove(string coord)
        {
            return IsValidMove(this.Board[coord]);
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

        protected void AddValidMove(char x, char y)
        {
            this.ValidMoves.Add(this.Board[x,y]);
        }

        public abstract void CalculateValidMoves();

        protected bool ReadSquareMove(char x, char y)
        {
            if (this.Board.IsEmptySquare(x, y))
            {
                this.AddValidMove(x, y);
                return true;
            }
            else
            {
                if (this.Board.IsOccupiedSquare(x, y, this.Color.Opposite()))
                    this.AddValidMove(x, y);
                return false;
            }
        }
    }

}