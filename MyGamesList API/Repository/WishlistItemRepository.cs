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

        public bool Remove(long id) {
            WishlistItem wishlistItem = db.WishlistItems.Find(id);

            if (wishlistItem == null) {
                return false;
            }

            db.WishlistItems.Remove(wishlistItem);
            db.SaveChanges();
            return true;
        }

        public bool Update(long id, WishlistItem newItem) {
            var item = db.WishlistItems.Find(id);
            
            if (item == null) {
                return false;
            }

            if (item.Game.Id != newItem.Game.Id) {
                var game = db.Games.Find(newItem.Game.Id);
                item.Game = game;
            }

            item.RankPosition = newItem.RankPosition;

            db.SaveChanges();
            return true;
        }
    }
}
