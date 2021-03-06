﻿using MyGamesListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Services {
    public interface IWishlistItem {
        IEnumerable<WishlistItem> GetWishlistItems { get; }
        WishlistItem GetWishlistItem(long id);
        void Add(WishlistItem wishlistItem);
        Boolean Remove(long id);
        Boolean Update(long id, WishlistItem newItem);
    }
}
