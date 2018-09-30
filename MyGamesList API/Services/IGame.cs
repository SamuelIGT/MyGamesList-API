using MyGamesListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Services {
    public interface IGame {
        IEnumerable<Game> GetGames { get; }
        Game GetGame(long id);
        void Add(Game game);
        Boolean Remove(long id);
        Boolean Update(long id, Game newGame);
    }
}
