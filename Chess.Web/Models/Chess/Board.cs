using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    /// <summary>
    /// Board representation
    /// </summary>
    public class Board
    {
        // 0  1  2  3  4  5  6  7
        // 8  9  10 11 12 13 14 15
        // 16 17 18 19 20 21 22 23
        // 24 25 26 27 28 29 30 31
        // 32 33 34 35 36 37 38 39
        // 40 41 42 43 44 45 46 47
        // 48 49 50 51 52 53 54 55
        // 56 57 58 59 60 61 62 63
        BoardSquare[] squares;

        /// <summary>
        /// Board constructor
        /// </summary>
        public Board()
        { 
            squares = new BoardSquare[8*8];
            for (int i = 0; i < squares.Length; i++)
            {
                squares[i] = new BoardSquare(this, i);
            }
        }

        public void LoadPiece(char x, char y, char type, PieceColor color)
        {
            var piece = PieceBase.CreatePiece(type);
            LoadPiece(x, y, piece, color);
        }

        public void LoadPiece(string coord, PieceBase piece, PieceColor color)
        {
            LoadPiece(coord[0], coord[1], piece, color);
        }

        public void LoadPiece(char x, char y, PieceBase piece, PieceColor color)
        {
            int index = Board.GetIndexFromCoordinate(x, y);
            var square = this.squares[index];

            piece.Color = color;
            piece.Square = square;
            piece.Board = this;

            square.Piece = piece;
        }

        public static int GetIndexFromCoordinate(char x, char y)
        {
            return ((y - '1' - 7) * -8) + (x - 'a');
        }

        public PieceBase GetPieceFrom(char x, char y)
        {
            return this[x,y].Piece;
        }

        public BoardSquare this[int index]
        {
            get { return this.squares[index]; }
            set { this.squares[index] = value; }
        }

        public BoardSquare this[char x, char y]
        {
            get { return this.squares[GetIndexFromCoordinate(x,y)]; }
        }

        public void CalculateValidMoves()
        {
            foreach (var square in squares)
            {
                if (square.Piece != null)
                {
                    square.Piece.CalculateValidMoves();
                }
            }
        }

        public void ClearPieces()
        {
            for (int i = 0; i < squares.Length; i++)
            {
                squares[i].Piece = null;
            }
        }
    }
}