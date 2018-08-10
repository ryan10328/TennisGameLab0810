using System;
using System.Collections.Generic;

namespace TennisGameTdd
{
    public class TennisGame
    {
        private int _homePlayerScore;
        private int _awayPlayerScore;
        private readonly Dictionary<int, string> _scoreMappings;

        public TennisGame()
        {
            _scoreMappings = new Dictionary<int, string>
            {
                {0, "Love"},
                {1, "Fifteen"},
                {2, "Thirty"},
                {3, "Forty"}
            };
        }

        public string Score()
        {
            if (_homePlayerScore == _awayPlayerScore)
            {
                if (_homePlayerScore >= 3)
                {
                    return "Deuce";
                }

                return $"{_scoreMappings[_homePlayerScore]} All";
            }

            if (_homePlayerScore >= 3 && _awayPlayerScore >= 3)
            {
                var advPlayer = _homePlayerScore > _awayPlayerScore ? "John" : "Tom";
                if (Math.Abs(_homePlayerScore - _awayPlayerScore) == 1)
                {
                    return $"{advPlayer} Adv";
                }
                return $"{advPlayer} Win";
            }

            return $"{_scoreMappings[_homePlayerScore]} {_scoreMappings[_awayPlayerScore]}";
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