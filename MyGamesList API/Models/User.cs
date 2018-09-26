using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Models {
    public class User {
        [Key]
        public long Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [StringLength(250)]
        [Required]
        public string Email { get; set; }

        public ICollection<WishlistItem> Wishlist { get; set; }
        //public ICollection<Game> OwnedGames { get; set; }

    }
}
