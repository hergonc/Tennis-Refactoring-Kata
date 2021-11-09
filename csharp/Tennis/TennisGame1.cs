namespace Tennis
{
    class ScoreBoard
    {
        public int MScore1 { get; set; }

        public int MScore2 { get; set; }

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

        private string Draw()
        {
            string score;
            switch (MScore1)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
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
            string score = "";
            int tempScore;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = MScore1;
                else
                {
                    score += "-";
                    tempScore = MScore2;
                }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
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
            if (playerName == "player1")
                scoreBoard.MScore1 += 1;
            else
                scoreBoard.MScore2 += 1;
        }

        public string GetScore()
        {
            return scoreBoard.GetScore();
        }
    }
}

