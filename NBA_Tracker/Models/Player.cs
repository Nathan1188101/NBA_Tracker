using System.ComponentModel.DataAnnotations;

namespace NBA_Tracker.Models
{
    public class Player
    {

        //Primary Key
        public int PlayerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Position { get; set; }

        //Foreign Key
        [Required]
        public int TeamID { get; set; } 

        //ref
        public Team Team { get; set; }  


    }
}
