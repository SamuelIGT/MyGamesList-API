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

        public Game GetGame(long id) {
            Game game = db.Games.Find(id);
            return game;
        }

        public void Add(Game game) {
            db.Games.Add(game);
            db.SaveChanges();
        }

        public bool Remove(long id) {
            var game = db.Games.Find(id);

            if (game == null) {
                return false;
            }

            db.Games.Remove(game);
            db.SaveChanges();
            return true;
        }

        public bool Update(long id, Game newGame) {
            var game = db.Games.Find(id);

            if(game == null) {
                return false;
            }

            game.SteamAppid = newGame.SteamAppid;
            game.Title = newGame.Title;
            game.ShortDescription = newGame.ShortDescription;
            game.DetailedDescription = newGame.DetailedDescription;
            game.HeaderImage = newGame.HeaderImage;
            game.Price = newGame.Price;

            db.SaveChanges();
            return true;
        }
    }
}
