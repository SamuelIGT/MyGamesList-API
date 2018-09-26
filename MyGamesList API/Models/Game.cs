using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGamesListAPI.Models {
    public class Game {

        [Key]
        public long Id { get; set; }
        public long SteamAppid { get; set; }

        [StringLength(300)]
        public string Title { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        [StringLength(3000)]
        public string DetailedDescription { get; set; }

        [StringLength(300)]
        public string HeaderImage { get; set; }
        public double Price { get; set; }

    }
}
