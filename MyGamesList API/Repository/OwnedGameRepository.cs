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

        public void Remove(long id) {
            OwnedGame ownedGame = db.OwnedGames.Find(id);

            db.OwnedGames.Remove(ownedGame);
            db.SaveChanges();
        }
    }
}
