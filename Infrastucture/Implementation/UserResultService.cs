using Data.Contracts;
using Data.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Infrastucture.Implementation
{
    public class UserResultService : IUserResult
    {
        private readonly string _db = "users.json";
        public List<GameResult> GameResults { get; private set; } = new List<GameResult>();
        public IList<GameResult> BestPlayers(int count)
        {
            Load();
            return GameResults.OrderBy(x => x.Period).Take(count).ToList();
        }

        public void SaveUser(GameResult result)
        {
            Load();
            this.GameResults.Add(result);
            Save();
        }

        private void Load()
        {
            try { this.GameResults =  JsonSerializer.Deserialize<List<GameResult>>(File.ReadAllText(_db));}
            catch { }
           
        }
        private void  Save()
        {
            File.WriteAllText(_db, JsonSerializer.Serialize(GameResults, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
