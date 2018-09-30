using MyGamesListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Services {
    public interface IOwnedGame {
        IEnumerable<OwnedGame> GetOwnedGames { get; }
        OwnedGame GetOwnedGame(long id);
        void Add(OwnedGame ownedGame);
        Boolean Remove(long id);
        Boolean Update(long id, OwnedGame newGame);

    }
}
