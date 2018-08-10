using System.Collections.Generic;
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
            GivenHomePlayerScoreTimes(times: 2);
            var actual = _sut.Score();
            Assert.AreEqual("Thirty Love", actual);
        }
        
        [TestMethod]
        public void FortyLove()
        {
            GivenHomePlayerScoreTimes(times: 3);
            var actual = _sut.Score();
            Assert.AreEqual("Forty Love", actual);
        }

        [TestMethod]
        public void LoveFifteen()
        {
            _sut.AwayPlayerScored();
            var actual = _sut.Score();
            Assert.AreEqual("Love Fifteen", actual);
        }

        [TestMethod]
        public void LoveThirty()
        {
            GivenAwayPlayerScoreTimes(times: 2);
            var actual = _sut.Score();
            Assert.AreEqual("Love Thirty", actual);
        }

        private void GivenAwayPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _sut.AwayPlayerScored();
            }
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
        private int _awayPlayerScore;
        private readonly Dictionary<int, string> _scoreMappings;

        public TennisGame()
        {
            _scoreMappings = new Dictionary<int, string>
            {
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"}
            };
        }

        public string Score()
        {
            if (_awayPlayerScore > 0)
            {
                return $"Love {_scoreMappings[_awayPlayerScore]}";
            }

            if (_homePlayerScore > 0)
            {
                return $"{_scoreMappings[_homePlayerScore]} Love";
            }

            return "Love All";
        }

        public void HomePlayerScored()
        {
            _homePlayerScore++;
        }

        public void AwayPlayerScored()
        {
            _awayPlayerScore++;
        }
    }
}