using Data.Contracts;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastucture.Implementation
{
    public class Game : IGame
    {
        private readonly int min = 0;
        private readonly int max = 100;
        private readonly int countForWin = 10;
        private readonly ICalculateScore calculate;


        private Status gameStatus = Status.Stopped;
        private DateTime started = DateTime.Now;
        private double period = 0;

        private int first;
        private int second;
        private int score = 0;

        public Game(ICalculateScore calculate)
        {
            this.calculate = calculate;
        }

        public Dictionary<Status, int> Bet(bool more)
        {
            if (gameStatus != Status.Started)
                throw new Exception("Please start game before");

            if (more && first > second)
                score += calculate.GetScore();
            else
                gameStatus = Status.Losed;

            if (score >= countForWin)
            {
                period = (DateTime.Now - started).TotalMilliseconds;
                gameStatus = Status.Wined;
            }

            return new Dictionary<Status, int>() { { this.gameStatus, this.score } };
        }

        public void StartGame()
        {
            this.score = 0;
            this.started = DateTime.Now;
            this.period = 0;
            this.gameStatus = Status.Started;
        }

        public void SetValues()
        {
            Random rand = new Random();
            first = rand.Next(min, max);
            while (first != second)
                second = rand.Next(min, max);

        }

        public GameResult GetGameResult(User user)
        {
            return new GameResult() { Period = period, Score = score, User = user };
           
        }
    }
}
