using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public class PiecePawn : PieceBase
    {
        public PiecePawn(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {
            this.ValidMoves.Clear();

            char x =  this.Square.X;
            char y = this.Square.Y;
            char nextYIndex = y;
            char leftXIndex = (char)(x - 1);
            char rightXIndex = (char)(x + 1);

            if (this.Color == PieceColor.White)
            {
                nextYIndex ++;
                if (this.Board.IsEmptySquare(x, nextYIndex))
                    this.AddValidMove(x, nextYIndex, false);

                CheckForCapture(leftXIndex, rightXIndex, nextYIndex, PieceColor.Black);

                if (y == '2')
                {
                    char secondYIndex = (char)(nextYIndex + 1);
                    if (this.Board.IsEmptySquare(x, secondYIndex))
                    {
                        var move = this.AddValidMove(x, secondYIndex, false);
                        move.EnPassant = this.Board[x, nextYIndex];
                    }
                }
            }
            else
            {
                nextYIndex --;
                if (this.Board.IsEmptySquare(x, nextYIndex))
                    this.AddValidMove(x, nextYIndex, false);

                CheckForCapture(leftXIndex, rightXIndex, nextYIndex, PieceColor.White);

                if (y == '7')
                {
                    char secondYIndex = (char)(nextYIndex - 1);
                    if (this.Board.IsEmptySquare(x, secondYIndex))
                    {
                        var move = this.AddValidMove(x, secondYIndex, false);
                        move.EnPassant = this.Board[x, nextYIndex];
                    }
                }
            }
        }

        private void CheckForCapture(char leftX, char rightX, char y, PieceColor color)
        {
            if (this.Board.IsOccupiedSquare(leftX, y, color))
            {
                this.AddValidMove(leftX, y, true);
            }

            if (this.Board.IsOccupiedSquare(rightX, y, color))
            {
                this.AddValidMove(rightX, y, true);
            }

            // En Passant
            if (this.Board.EnPassantSquare != null)
            {
                if (this.Board.EnPassantSquare.X == leftX && this.Board.EnPassantSquare.Y == y)
                {
                    this.AddValidMove(leftX, y, true, this.Board[leftX, this.Square.Y].Piece);
                }

                if (this.Board.EnPassantSquare.X == rightX && this.Board.EnPassantSquare.Y == y)
                {
                    this.AddValidMove(rightX, y, true, this.Board[rightX, this.Square.Y].Piece);
                }
            }
        }

    }
}