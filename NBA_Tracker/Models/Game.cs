using System.ComponentModel.DataAnnotations;

namespace NBA_Tracker.Models
{
    public class Game
    {
        //The Primary Key
        public int GameId { get; set; } // unique identifier for each game

        //Date (maybe add start time as well?)
        [Required]
        public DateTime Date { get; set; }  // represent the date when the game takes place 
        //public TimeSpan StartTime { get; set; }
        [Required]
        public string Location { get; set; } // here we are storing the city/area/location of where the game is taking place 

        //Foreign keys 
        [Required]
        public int HomeTeamID { get; set; } // these foreign keys link us to the Team model and the TeamID within to specify which teams are playing in said game
        [Required]
        public int AwayTeamID { get; set; }

        //parent ref
        public Team HomeTeam { get; set; }  
        public Team AwayTeam { get; set; } 




    }
}
