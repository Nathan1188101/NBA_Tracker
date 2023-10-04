using System.ComponentModel.DataAnnotations;

namespace NBA_Tracker.Models
{
    public class Team
    {
        //Primary Key
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string City { get; set; }


    }
}
