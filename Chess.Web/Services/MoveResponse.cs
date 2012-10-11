using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Chess.Web.Services
{
    [DataContract]
    public struct MoveResponse
    {
        [DataMember]
        public bool IsValid;

        [DataMember]
        public bool IsCapture;

        [DataMember]
        public string EnPassantSquare;

        [DataMember]
        public string CapturedPieceSquare { get; set; }
            
    }
}