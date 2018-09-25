﻿using MyGamesListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Services {
    public interface IGame {
        IEnumerable<Game> GetGames { get; }
        Game GetGame(long id);
        void Add(Game game);
        void Remove(long id);
    }
}
