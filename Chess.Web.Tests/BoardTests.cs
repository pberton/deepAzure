using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Web.Models.Chess;

namespace Chess.Web.Tests
{
    /// <summary>
    /// Summary description for BoardTests
    /// </summary>
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardConstructorTest()
        {
            Board board = new Board();
            Assert.IsNotNull(board);

            Assert.IsNotNull(board['a', '8']);
            Assert.IsNotNull(board['a', '1']);
            Assert.IsNotNull(board['h', '8']);
            Assert.IsNotNull(board["h1"]);
            Assert.IsNotNull(board['d', '5']);
        }
    }
}
