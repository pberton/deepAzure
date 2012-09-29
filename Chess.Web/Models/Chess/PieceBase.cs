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
        protected  List<int> ValidMoves = new List<int>();

        public static PieceBase CreatePiece(char type)
        {
            switch (type)
            {
                case 'R':
                    return new PieceRook();
                case 'N':
                    return new PieceKnight();
                case 'B':
                    return new PieceBishop();
                case 'K':
                    return new PieceKing();
                case 'Q':
                    return new PieceQueen();
                default:
                    return new PiecePawn();
            }
        }

        public bool IsValidMove(char x, char y)
        {
            int destIndex = Board.GetIndexFromCoordinate(x, y);
            return (ValidMoves.Contains(destIndex));
        }

        public abstract void CalculateValidMoves();
    }

    public enum PieceColor
    {
        White = 0,
        Black = 1
    }
}