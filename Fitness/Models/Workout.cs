using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Models
{
    public class Workout
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Distance { get; set; }
        public int? Duration { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public int? Weight { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
