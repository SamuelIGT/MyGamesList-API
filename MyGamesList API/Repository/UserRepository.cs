using MyGamesListAPI.Models;
using MyGamesListAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Repository {
    public class UserRepository : IUser {
        private DBContext db;

        public UserRepository(DBContext _db) {
            db = _db;
        }

        public IEnumerable<User> GetUsers => db.Users;

        public void Add(User user) {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User GetUser(long id) {
            User user = db.Users.Find(id);
            return user;
        }

        public bool Remove(long id) {
            User user = db.Users.Find(id);

            if (user == null) {
                return false;
            }

            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public bool Update(long id, User newUser) {
            var user = db.Users.Find(id);

            if (user == null) {
                return false;
            }

            user.Name = newUser.Name;
            user.Email = newUser.Email;

            foreach (OwnedGame ownedGame in newUser.OwnedGames) {
                if(ownedGame.Id == 0) {
                    ownedGame.Game = db.Games.Find(ownedGame.Game.Id);
                    user.OwnedGames.Add(ownedGame);
                }
            }

            foreach (WishlistItem item in newUser.Wishlist) {
                if (item.Id == 0) {
                    item.Game = db.Games.Find(item.Game.Id);
                    user.Wishlist.Add(item);
                }
            }

            db.SaveChanges();
            return true;
        }
    }
}
