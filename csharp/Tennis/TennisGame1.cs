using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private enum Score
        {
            Love = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3
        }
        private string player1Name;
        private string player2Name;
        private int m_score1;
        private int m_score2;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            string score = "";
            if (m_score1 == m_score2)
            {
                score = Draw();
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                score = AdvantageOrEndOfGame();
            }
            else
            {
                score = GameScoreBoard();
            }
            return score;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1++;
            else
                m_score2++;
        }

        private string Draw()
        {
            return m_score1 < 3
                ? ((Score)m_score1).ToString() + "-All"
                : "Deuce";
        }

        private string AdvantageOrEndOfGame()
        {
            var minusResult = m_score1 - m_score2;
            return (Math.Abs(minusResult) == 1 ? "Advantage " : "Win for ")
                   + (minusResult > 0 ? player1Name : player2Name);
        }

        private string GameScoreBoard()
        {
            return ((Score)m_score1).ToString() + "-" + ((Score)m_score2).ToString();
        }
    }
}

