using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Models {
    public class OwnedGame {
        [Key]
        public long Id { get; set; }
        public long PlaytimeForever { get; set; }
        public long PlaytimeTwoWeeks { get; set; }

        [Required]
        public virtual Game Game { get; set; }

    }
}
