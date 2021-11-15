using System.Runtime.CompilerServices;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point;
        private int player2Point;

        public string GetScore()
        {
            var score = "";
            if (player1Point == player2Point && player1Point < 3)
            {
                score = EqualsScore();
            }
            if (player1Point == player2Point && player1Point > 2)
                score = "Deuce";

            if (player1Point > 0 && player2Point == 0)
            {
                score = PointToScore(player1Point) +"-" + PointToScore(player2Point);
            }
            if (player2Point > 0 && player1Point == 0)
            {
                score = PointToScore(player1Point) + "-" + PointToScore(player2Point);
            }

            if (player1Point > player2Point && player1Point < 4)
            {
                score = PointToScore(player1Point) + "-" + PointToScore(player2Point);
            }
            if (player2Point > player1Point && player2Point < 4)
            {
                score = PointToScore(player1Point) + "-" + PointToScore(player2Point);
            }

            if (player1Point > player2Point && player2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Point > player1Point && player1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Point >= 4 && player2Point >= 0 && (player1Point - player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Point >= 4 && player1Point >= 0 && (player2Point - player1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private string PointToScore(int point) =>
            point switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };

        private string EqualsScore() => PointToScore(player1Point) + "-All";

        public void WonPoint(string player) => _ = player == "player1" ? player1Point++ : player2Point++;
    }
}

