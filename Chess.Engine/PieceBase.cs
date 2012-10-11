using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public abstract class PieceBase
    {
        public PieceColor Color { get; set; }
        public BoardSquare Square { get; set; }
        public Board Board { get; set; }
        protected List<MoveEvaluation> ValidMoves = new List<MoveEvaluation>();

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

        public abstract void CalculateValidMoves();

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
            return (ValidMoves.Contains(new MoveEvaluation(destSquare)));
        }

        public int GetValidMovesCount()
        {
            return this.ValidMoves.Count;
        }

        protected MoveEvaluation AddValidMove(char x, char y, bool isCapture, PieceBase pieceCapture = null)
        {
            BoardSquare square = this.Board[x, y];
            PieceBase capture = null;
            if (isCapture)
            {
                if (pieceCapture == null)
                    capture = square.Piece;
                else
                    capture = pieceCapture;
            }
            var move = new MoveEvaluation(this.Board[x, y], isCapture, capture);
            this.ValidMoves.Add(move);
            return move;
        }

        protected bool ReadSquareMove(char x, char y)
        {
            if (this.Board.IsEmptySquare(x, y))
            {
                this.AddValidMove(x, y, false);
                return true;
            }
            else
            {
                if (this.Board.IsOccupiedSquare(x, y, this.Color.Opposite()))
                    this.AddValidMove(x, y, true);
                return false;
            }
        }

        public MoveEvaluation GetValidMove(BoardSquare destSquare)
        {
            return this.ValidMoves.Find(move => move.Equals(destSquare));
        }
    }

}