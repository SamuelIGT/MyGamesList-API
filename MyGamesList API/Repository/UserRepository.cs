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

        public void Remove(long id) {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
        }
    }
}
