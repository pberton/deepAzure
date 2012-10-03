using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public enum PieceColor
    {
        White = 0,
        Black = 1
    }

    public static class PieceColorExtensions
    {
        public static PieceColor Opposite(this PieceColor color)
        {
            return (PieceColor)(((int)color + 1) % 2);
        }
    }
}