using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels.Workouts
{
    public class EnduranceworkoutViewModel
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string TypeId { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }
       
    }
}
