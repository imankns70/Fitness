using Fitness.Models.ViewModels.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public List<MealViewModel> Meals { get; set; }
        public List<WorkoutViewModel> Workouts { get; set; }
        public string Section { get; set; }
    }
}
