using Chess.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chess.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChessEngine" in code, svc and config file together.
    public class ChessEngine : IChessEngine
    {
        public bool IsValidMove(MoveRequest request)
        {
            IEngine engine = new BasicEngine();
            engine.LoadBoardFromArray(request.WhitePieces, request.BlackPieces);

            return engine.IsValidMove(request.From, request.To);
        }
    }
}
