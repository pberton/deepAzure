﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public class BasicEngine: IEngine
    {
        Board board = new Board();

        public BasicEngine()
        { 
        
        }

        public Board Board
        {
            get { return board; }
        }

        public void LoadBoardFromArray(string[] whitePieces, string[] blackPieces)
        {
            char type, x, y;

            if (whitePieces != null)
            {
                foreach (string pieceText in whitePieces)
                {
                    ReadPieceData(pieceText, out type, out x, out y);
                    board.LoadPiece(x, y, type, PieceColor.White);
                }
            }

            if (blackPieces != null)
            {
                foreach (string pieceText in blackPieces)
                {
                    ReadPieceData(pieceText, out type, out x, out y);
                    board.LoadPiece(x, y, type, PieceColor.Black);
                }
            }

            board.CalculateValidMoves();
        }

        private void ReadPieceData(string pieceText, out char type, out char x, out char y)
        {
            if (pieceText.Length == 2)
            {
                type = ' ';
                x = pieceText[0];
                y = pieceText[1];
            }
            else
            {
                type = pieceText[0];
                x = pieceText[1];
                y = pieceText[2];
            }
        }

        public bool IsValidMove(string from, string to)
        {
            var piece = board[from[0], from[1]].Piece;
            if (piece != null)
            {
                var destSquare = this.board[to[0], to[1]];
                return board.IsValidMove(piece, destSquare);
            }
            else
            {
                return false;
            }
        }

        public bool Move(string from, string to)
        {
            var piece = board[from[0], from[1]].Piece;
            if (piece != null)
            {
                var destSquare = this.board[to[0], to[1]];
                if (board.IsValidMove(piece, destSquare))
                {
                    piece.Square.Piece = null;
                    piece.Square = destSquare;
                    destSquare.Piece.Board = null;
                    destSquare.Piece = piece;
                    return true;
                }
            }
            return false;
        }
    }
}