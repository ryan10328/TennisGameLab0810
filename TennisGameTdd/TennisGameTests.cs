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

        [TestMethod]
        public void FifteenAll()
        {
            _sut.HomePlayerScored();
            _sut.AwayPlayerScored();
            var actual = _sut.Score();
            Assert.AreEqual("Fifteen All", actual);
        }

        [TestMethod]
        public void ThirtyAll()
        {
            GivenHomePlayerScoreTimes(times: 2);
            GivenAwayPlayerScoreTimes(times: 2);
            var actual = _sut.Score();
            Assert.AreEqual("Thirty All", actual);
        }

        [TestMethod]
        public void Deuce()
        {
            GivenHomePlayerScoreTimes(times: 3);
            GivenAwayPlayerScoreTimes(times: 3);
            var actual = _sut.Score();
            Assert.AreEqual("Deuce", actual);
        }

        [TestMethod]
        public void Deuce_4_4()
        {
            GivenHomePlayerScoreTimes(times: 4);
            GivenAwayPlayerScoreTimes(times: 4);
            var actual = _sut.Score();
            Assert.AreEqual("Deuce", actual);
        }

        [TestMethod]
        public void HomeAdv()
        {
            GivenHomePlayerScoreTimes(times: 4);
            GivenAwayPlayerScoreTimes(times: 3);
            var actual = _sut.Score();
            Assert.AreEqual("John Adv", actual);
        }

        [TestMethod]
        public void AwayAdv()
        {
            GivenHomePlayerScoreTimes(times: 3);
            GivenAwayPlayerScoreTimes(times: 4);
            var actual = _sut.Score();
            Assert.AreEqual("Tom Adv", actual);
        }

        [TestMethod]
        public void HomeWin()
        {
            GivenHomePlayerScoreTimes(times: 5);
            GivenAwayPlayerScoreTimes(times: 3);
            var actual = _sut.Score();
            Assert.AreEqual("John Win", actual);
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
}