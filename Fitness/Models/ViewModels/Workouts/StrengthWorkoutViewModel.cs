using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels.Workouts
{
    public class StrengthWorkoutViewModel
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }
       
    }
}
