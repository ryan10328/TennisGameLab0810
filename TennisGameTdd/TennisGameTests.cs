using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGameTdd
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void LoveAll()
        {
            var sut = new TennisGame();
            var actual = sut.Score();
            Assert.AreEqual("Love All", actual);
        }
    }

    public class TennisGame
    {
        public string Score()
        {
            return "Love All";
        }
    }
}