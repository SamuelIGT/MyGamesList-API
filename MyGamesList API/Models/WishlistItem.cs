using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Models
{
    public class WishlistItem
    {
        [Key]
        public long Id { get; set; }
        public int RankPosition { get; set; }
        
        public long GameId { get; set; }
    }
}
