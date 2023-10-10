using System.ComponentModel.DataAnnotations;

namespace NBA_Tracker.Models
{
    public class GamePlayerStats
    {

        //primary key 
        [Key]
        public int StatId { get; set; }

        [Required] 
        public int Points { get; set; }
        [Required]
        public int Rebounds { get; set; }
        [Required]
        public int Assists { get; set; }
        [Required]
        public int Steals { get; set; }
        [Required]
        public int Blocks { get; set; }

        //foreign keys
        [Required]
        public int GameId { get; set; }
        [Required]
        public int PlayerId { get; set; } 

        //refs to the parent
        public Game? Game { get; set; }
        public Player? Player { get; set; }

    }
}
