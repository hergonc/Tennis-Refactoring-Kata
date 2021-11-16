using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Tennis
{
    public class ScoreBoard
    {
        private readonly Player player1;
        private readonly Player player2;

        public ScoreBoard(string player1, string player2)
        {
            this.player1 = new Player(player1);
            this.player2 = new Player(player2);
        }

        public string GetScore()
        {
            int pointPlayer1 = player1.GetPoint();
            int pointPlayer2 = player2.GetPoint();
            if (pointPlayer1 == pointPlayer2) return EqualsScore();
            if(pointPlayer1 > 3 || pointPlayer2 > 3) return AdvantageOrWin(pointPlayer1, pointPlayer2);
            return player1.GetScore() + "-" + player2.GetScore();
        }

        public void WonPoint(string player)
        {
            if (player1.IsPlayer(player))
                player1.AddPoint();
            else
                player2.AddPoint();
        }

        private string EqualsScore() => player1.GetPoint() > 2 ? "Deuce" : player1.GetScore() + "-All";
       
        private string AdvantageOrWin(int pointPlayer1, int pointPlayer2) =>
            (Math.Abs(pointPlayer1 - pointPlayer2) >= 2 ? "Win for " : "Advantage ")
            + (pointPlayer1 > pointPlayer2 ? player1.GetName() : player2.GetName());
    }

    public class Player
    {
        private string Name { get; }
        private Point Point { get; }

        public Player(string name)
        {
            Name = name;
            Point = new Point();
        }

        public void AddPoint() => Point.Add();

        public int GetPoint() => Point.GetPoint();

        public string GetScore() => Point.ToString();

        public bool IsPlayer(string player) => Name == player;

        public object GetName() => Name;
    }

    public class Point
    {
        private int Value { get; set; }

        public void Add() => Value++;

        public int GetPoint() => Value;

        public override string ToString() =>
            Value switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
    }
    
    public class TennisGame2 : ITennisGame
    {
        private readonly ScoreBoard scoreBoard;

        public TennisGame2() => scoreBoard = new ScoreBoard("player1", "player2");

        public string GetScore() => scoreBoard.GetScore();

        public void WonPoint(string player) => scoreBoard.WonPoint(player);
    }
}

