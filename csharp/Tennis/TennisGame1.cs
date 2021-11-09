using System;

namespace Tennis
{
    class ScoreBoard
    {
        public int MScore1 { get; set; }

        public int MScore2 { get; set; }
        
        private enum Score
        {
            Love = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3
        }

        public string GetScore()
        {
            string score = "";
            if (MScore1 == MScore2)
            {
                score = Draw();
            }
            else if (MScore1 >= 4 || MScore2 >= 4)
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
                MScore1++;
            else
                MScore2++;
        }

        private string Draw()
        {
            return MScore1 < 3 
                ? ((Score) MScore1).ToString() + "-All" 
                : "Deuce";
        }

        private string AdvantageOrEndOfGame()
        {
            string score;
            var minusResult = MScore1 - MScore2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string GameScoreBoard()
        {
            return ((Score)MScore1).ToString() + "-" + ((Score)MScore2).ToString();
        }
    }

    class TennisGame1 : ITennisGame
    {
        private string player1Name;
        private string player2Name;
        private readonly ScoreBoard scoreBoard;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            scoreBoard = new ScoreBoard();
        }

        public void WonPoint(string playerName)
        {
            scoreBoard.WonPoint(playerName);
        }

        public string GetScore()
        {
            return scoreBoard.GetScore();
        }
    }
}

