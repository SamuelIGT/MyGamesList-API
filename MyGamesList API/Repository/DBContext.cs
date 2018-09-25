using Microsoft.EntityFrameworkCore;
using MyGamesListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Repository {
    public class DBContext : DbContext {
        public DBContext(DbContextOptions<DBContext> options) : base(options) {}

        public DbSet<Game> Games { get; set; }
        public DbSet<OwnedGame> OwnedGames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
    }
}
