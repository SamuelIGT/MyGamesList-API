using MyGamesListAPI.Models;
using MyGamesListAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Repository {
    public class WishlistItemRepository : IWishlistItem {
        private DBContext db;

        public WishlistItemRepository(DBContext _db) {
            db = _db;
        }
        public IEnumerable<WishlistItem> GetWishlistItems => db.WishlistItems;

        public void Add(WishlistItem wishlistItem) {
            db.WishlistItems.Add(wishlistItem);
            db.SaveChanges();
        }

        public WishlistItem GetWishlistItem(long id) {
            return db.WishlistItems.Find(id);
        }

        public void Remove(long id) {
            WishlistItem wishlistItem = db.WishlistItems.Find(id);

            db.WishlistItems.Remove(wishlistItem);
            db.SaveChanges();
        }
    }
}
