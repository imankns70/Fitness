using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels.Workouts
{
    public class WorkoutViewModel
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public StrengthWorkoutViewModel Strength { get; set; }
        public EnduranceworkoutViewModel Endurance { get; set; }
       
    }
}
