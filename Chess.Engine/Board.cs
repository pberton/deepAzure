using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Chess.Engine
{
    /// <summary>
    /// Board representation
    /// </summary>
    public class Board
    {
        // a8 ... h8
        // ...
        // a2 ...
        // a1 ... h1
        Dictionary<int, BoardSquare> squares;

        /// <summary>
        /// Board constructor
        /// </summary>
        public Board()
        { 
            squares = new Dictionary<int,BoardSquare>(8*8);
            for (char x = 'a'; x < 'i'; x++)
            {
                for (char y = '1'; y < '9'; y++)
                {
                    BoardSquare square = new BoardSquare(this, x, y);
                    squares.Add(square.GetHashCode(), square);
                }
            }
        }

        /// <summary>
        /// Lists all pieces on the board
        /// </summary>
        public IEnumerable<PieceBase> Pieces
        {
            get
            {
                foreach (var square in squares.Values)
                {
                    if (square.Piece != null)
                    {
                        yield return square.Piece;
                    }
                }
            }
        }

        public void LoadPiece(char x, char y, char type, PieceColor color)
        {
            var piece = PieceBase.CreatePiece(type, color);
            LoadPiece(x, y, piece);
        }

        public void LoadPiece(string coord, PieceBase piece)
        {
            LoadPiece(coord[0], coord[1], piece);
        }

        public void LoadPiece(char x, char y, PieceBase piece)
        {
            var square = this[x, y];

            piece.Square = square;
            piece.Board = this;

            square.Piece = piece;
        }

        public BoardSquare this[char x, char y]
        {
            get { return this.squares[BoardSquare.GetHashCode(x,y)]; }
        }

        public BoardSquare this[string coord]
        {
            get { return this[coord[0], coord[1]]; }
        }

        public void CalculateValidMoves()
        {
            // TODO: Parallel.ForEach<PieceBase>(this.Pieces, p => p.CalculateValidMoves());
            foreach (PieceBase piece in this.Pieces)
            {
                piece.CalculateValidMoves();
            }
        }

        public void ClearPieces()
        {
            foreach (var square in squares.Values)
            {
                square.Piece = null;
            }
        }

        public bool IsEmptySquare(char x, char y)
        {
            if (Board.IsInRange(x, y))
                return (this[x, y].Piece == null);
            return false;
        }

        private static bool IsInRange(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        public bool IsOccupiedSquare(char x, char y, PieceColor color)
        {
            if (Board.IsInRange(x, y))
            {
                var piece = this[x, y].Piece;
                if (piece != null && piece.Color == color)
                    return true;
            }
            return false;
        }

        public bool IsValidMove(PieceBase piece, BoardSquare destSquare)
        {
            return piece.IsValidMove(destSquare);
        }
    }
}