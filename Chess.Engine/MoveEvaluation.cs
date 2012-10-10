using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Engine
{
    public class MoveEvaluation
    {
        public BoardSquare Square { get; private set; }
        public bool IsCapture { get; private set; }
        public BoardSquare EnPassant { get; set; }

        public MoveEvaluation(BoardSquare square)
        {
            this.Square = square;
        }

        public MoveEvaluation(BoardSquare square, bool isCapture): this(square)
        {
            this.Square= square;
            this.IsCapture = isCapture;
        }

        public override bool Equals(object obj)
        {
            if (obj is MoveEvaluation)
            {
                return this.Square.Equals(((MoveEvaluation)obj).Square);
            }
            if (obj is BoardSquare)
            {
                return this.Square.Equals(((BoardSquare)obj));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Square.GetHashCode();
        }
    }
}
