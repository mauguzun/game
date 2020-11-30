using Data.Contracts;
using System;

namespace Infrastucture.Implementation
{
    public class CalculateScore : ICalculateScore
    {
        public int GetScore() =>  1;
       
        public int GetScore(int currentScore) => 1;
    
        public int GetScore(int currentScore, DateTime time) => 1;
       
    }
}
