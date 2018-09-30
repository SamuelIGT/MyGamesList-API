using MyGamesListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Services {
    public interface IUser {
        IEnumerable<User> GetUsers { get; }
        User GetUser(long id);
        void Add(User user);
        Boolean Remove(long id);
        Boolean Update(long id, User newUser);
    }
}
