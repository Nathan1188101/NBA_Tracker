namespace NBA_Tracker.Models
{
    public class Game
    {
        //The Primary Key
        public int GameId { get; set; } // unique identifier for each game

        //Date (maybe add start time as well?)
        public DateTime Date { get; set; }  // represent the date when the game takes place 
        //public TimeSpan StartTime { get; set; }

        public string Location { get; set; } // here we are storing the city/area/location of where the game is taking place 

        //Foreign keys 
        public int HomeTeamID { get; set; } // these foreign keys link us to the Team model and the TeamID within to specify which teams are playing in said game
        public int AwayTeamID { get; set; }

        //parent ref
        public Team HomeTeam { get; set; }  
        public Team AwayTeam { get; set; } 




    }
}
