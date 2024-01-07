using System.ComponentModel.DataAnnotations;

namespace beyondsports.models {

    public class Team {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Team name is required!", AllowEmptyStrings=false)]
        public string name { get; set; }
        [Required(ErrorMessage = "Team country is required!", AllowEmptyStrings=false)]
        public string country { get; set; }
    };

    public class Player {
        [Key] 
        public int id { get; set; }

        [Required(ErrorMessage = "Player name is required!", AllowEmptyStrings=false)]
        public string name { get; set; }
        [Required(ErrorMessage = "Player age is required!", AllowEmptyStrings=false)]
        public int? age { get; set; }
        [Required(ErrorMessage = "Player team id is required!")]
        public int? team_id { get; set; }
    };
}