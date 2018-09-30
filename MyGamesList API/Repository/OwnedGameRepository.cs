using MyGamesListAPI.Models;
using MyGamesListAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Repository {
    public class OwnedGameRepository : IOwnedGame {
        private DBContext db;

        public OwnedGameRepository(DBContext _db) {
            db = _db;
        }
        public IEnumerable<OwnedGame> GetOwnedGames => db.OwnedGames;

        public void Add(OwnedGame ownedGame) {
            db.OwnedGames.Add(ownedGame);
            db.SaveChanges();
        }

        public OwnedGame GetOwnedGame(long id) {
            return db.OwnedGames.Find(id);
        }

        public bool Remove(long id) {
            OwnedGame ownedGame = db.OwnedGames.Find(id);

            if (ownedGame == null) {
                return false;
            }

            db.OwnedGames.Remove(ownedGame);
            db.SaveChanges();
            return true;
        }

        public bool Update(long id, OwnedGame newGame) {
            var ownedGame = db.OwnedGames.Find(id);

            if (ownedGame == null) {
                return false;
            }

            
            if (ownedGame.Game.Id != newGame.Game.Id) {
                var game = db.Games.Find(newGame.Game.Id);
                ownedGame.Game = game;
            }

            ownedGame.PlaytimeForever = newGame.PlaytimeForever;
            ownedGame.PlaytimeTwoWeeks = newGame.PlaytimeTwoWeeks;

            db.SaveChanges();
            return true;

        }


    }
}
