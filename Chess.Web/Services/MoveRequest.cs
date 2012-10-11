using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Chess.Web.Services
{
    [DataContract]
    public struct MoveRequest
    {
        [DataMember]
        public BoardData Board;
        [DataMember] 
        public string From { get; set; }
        [DataMember] 
        public string To { get; set; }
        [DataMember]
        public byte PlayerColor { get; set; }

        [DataContract]
        public struct BoardData
        {
            [DataMember]
            public string[] WhitePieces { get; set; }
            [DataMember]
            public string[] BlackPieces { get; set; }
            [DataMember]
            public string EnPassantSquare { get; set; }
        }
    }

}