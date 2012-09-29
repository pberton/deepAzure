using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class Board
    {
        BoardSquare[] squares;

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
            int index = Board.GetIndexFromCoordinate(x, y);
            var square = this.squares[index];

            var piece = PieceBase.CreatePiece(type);
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
            int index = Board.GetIndexFromCoordinate(x, y);
            return this.squares[index].Piece;
        }

        public BoardSquare this[int index]
        {
            get { return this.squares[index]; }
            set { this.squares[index] = value; }
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
    }
}