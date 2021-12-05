using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class UserWorkout
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkoutId { get; set; }
     
    }
}
