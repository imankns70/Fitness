using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class User
    {
        public User()
        {
            Meals = new HashSet<UserMeal>();
            UserWorkouts = new HashSet<UserWorkout>();
           
        }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserMeal> Meals { get; set; }
        public virtual ICollection<UserWorkout> UserWorkouts { get; set; }
        
    }
}
