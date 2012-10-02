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
        }

        [TestMethod]
        public void GetIndexFromCoordinateTest()
        {
            Board engine = new Board();
            Assert.IsNotNull(engine['a', '8']);
            Assert.IsNotNull(engine['a', '1']);
            Assert.IsNotNull(engine['h', '8']);
            Assert.IsNotNull(engine["h1"]);
            Assert.IsNotNull(engine['d', '5']);
        }
    }
}
