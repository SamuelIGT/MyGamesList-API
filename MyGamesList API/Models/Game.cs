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
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string DetailedDescription { get; set; }
        public string HeaderImage { get; set; }
        public double Price { get; set; }

    }
}
