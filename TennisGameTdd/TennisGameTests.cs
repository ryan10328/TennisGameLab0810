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
        
        [TestMethod]
        public void FifteenLove()
        {
            var sut = new TennisGame();
            sut.HomePlayerScored();
            var actual = sut.Score();
            Assert.AreEqual("Fifteen Love", actual);
        }
    }

    public class TennisGame
    {
        private int _homePlayerScore;

        public string Score()
        {
            if (_homePlayerScore == 1)
            {
                return "Fifteen Love";
            }
            return "Love All";
        }

        public void HomePlayerScored()
        {
            _homePlayerScore++;
        }
    }
}