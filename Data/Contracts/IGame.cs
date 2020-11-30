using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contracts
{
    public interface IGame
    {
        public void SetValues();
        public Dictionary<Status, int> Bet(bool more);
        public void StartGame();
        public GameResult GetGameResult(User user);
       
	}
}
