using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Models {
    public class OwnedGame {
        public long Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Game")]
        public long GameId { get; set; }
        public Game Game { get; set; }
        
        public long PlaytimeForever { get; set; }
        public long PlaytimeTwoWeeks { get; set; }
    }
}
