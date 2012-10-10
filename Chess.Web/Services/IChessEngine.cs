using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Chess.Web.Services
{
    [ServiceContract]
    public interface IChessEngine
    {
        [OperationContract, WebInvoke(Method = "POST")]
        MoveResponse Move(MoveRequest request);
    }
}
