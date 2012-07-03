﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Chess.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChessEngine" in both code and config file together.
    [ServiceContract]
    public interface IChessEngine
    {
        [OperationContract, WebInvoke(Method="POST")]
        string DoWork(string @in);

        [OperationContract, WebGet]
        string HelloWorld();
    }
}
