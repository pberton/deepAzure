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
            Board engine = new Board();
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void GetIndexFromCoordinateTest()
        {
            Assert.AreEqual(0, Board.GetIndexFromCoordinate('a', '8'));
            Assert.AreEqual(56, Board.GetIndexFromCoordinate('a', '1'));
            Assert.AreEqual(7, Board.GetIndexFromCoordinate('h', '8'));
            Assert.AreEqual(63, Board.GetIndexFromCoordinate('h', '1'));
            Assert.AreEqual(27, Board.GetIndexFromCoordinate('d', '5'));
        }
    }
}
