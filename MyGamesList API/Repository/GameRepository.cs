using MyGamesListAPI.Models;
using MyGamesListAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Repository {
    public class GameRepository : IGame {

        private DBContext db;

        public GameRepository(DBContext _db) {
            db = _db;
        }

        public IEnumerable<Game> GetGames => db.Games;

        public void Add(Game game) {
            db.Games.Add(game);
            db.SaveChanges();
        }

        public Game GetGame(long id) {
            Game game = db.Games.Find(id);
            return game;
        }

        public void Remove(long id) {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();

        }
    }
}
