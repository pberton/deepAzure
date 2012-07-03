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
        public string DoWork(string @in)
        {
            return "out:" + @in;
        }

        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
