using Data.Entity;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IUserResult
    {
        void SaveUser(GameResult result);
        IList<GameResult> BestPlayers(int count);
    }
}
