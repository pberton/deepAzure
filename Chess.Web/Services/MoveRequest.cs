using Chess.Web.Models.Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Chess.Web.Services
{
    [DataContract]
    public class MoveRequest
    {
        [DataMember] 
        public string[] WhitePieces {get; set; }
        [DataMember]
        public string[] BlackPieces { get; set; }
        [DataMember] 
        public string From { get; set; }
        [DataMember] 
        public string To { get; set; }
    }
}