using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Workout
    {
        public Workout()
        {
     
          Users = new HashSet<UserWorkout>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Reps { get; set; }
        public int? Sets { get; set; }
        public int? Weight { get; set; }
        public int? Distance { get; set; }
        public int? Duration { get; set; }
        public int UserId { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<UserWorkout> Users { get; set; }

    }
}
