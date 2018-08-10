using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisGameTdd
{
    [TestClass]
    public class TennisGameTests
    {
        private TennisGame _sut;

        public TennisGameTests()
        {
            _sut = new TennisGame();
        }

        [TestMethod]
        public void LoveAll()
        {
            var actual = _sut.Score();
            Assert.AreEqual("Love All", actual);
        }
        
        [TestMethod]
        public void FifteenLove()
        {
            _sut.HomePlayerScored();
            var actual = _sut.Score();
            Assert.AreEqual("Fifteen Love", actual);
        }
        
        [TestMethod]
        public void ThirtyLove()
        {
            GivenHomePlayerScoreTimes(2);
            var actual = _sut.Score();
            Assert.AreEqual("Thirty Love", actual);
        }

        private void GivenHomePlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _sut.HomePlayerScored();
            }
        }
    }

    public class TennisGame
    {
        private int _homePlayerScore;

        public string Score()
        {
            if (_homePlayerScore == 2)
            {
                return "Thirty Love";
            }
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