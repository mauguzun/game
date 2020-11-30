using System;

namespace Data.Contracts
{
    public interface ICalculateScore
    {
         int GetScore();
         int GetScore(int currentScore);
         int GetScore(int currentScore,DateTime time);
    }
}
