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
<<<<<<< HEAD:Fitness/Models/User.cs
            Workouts = new HashSet<Workout>();
=======
            Workouts = new HashSet<UserWorkout>();
>>>>>>> c08814e842f53f7208e4a156eb3d20d71fca3d43:Models/User.cs
        }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserMeal> Meals { get; set; }
<<<<<<< HEAD:Fitness/Models/User.cs
        public virtual ICollection<Workout> Workouts { get; set; }
=======
        public virtual ICollection<UserWorkout> Workouts { get; set; }
>>>>>>> c08814e842f53f7208e4a156eb3d20d71fca3d43:Models/User.cs
    }
}
