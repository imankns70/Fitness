using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Models.ViewModels;
namespace Fitness.Models.Business
{
    public class ScheduleBusiness
    {
        private readonly FitnessContext _fitnessContext;
        private readonly MealBusiness _mealBusiness;
        private readonly WorkoutBusiness _workoutBusiness;
        public ScheduleBusiness(
            FitnessContext fitnessContext,
            MealBusiness mealBusiness,
            WorkoutBusiness workoutBusiness
            )
        {
            _fitnessContext = fitnessContext;
            _mealBusiness = mealBusiness;
            _workoutBusiness = workoutBusiness;
        }

        public List<ScheduleViewModel> GetSchedule(int userId, DateTime selectedDay)
        {
            List<ScheduleViewModel> schedules = new List<ScheduleViewModel>();

            List<Section> sections = _fitnessContext.Sections.ToList();
            Schedule schedule = _fitnessContext.Schedules.FirstOrDefault(a => a.SelectedDay == selectedDay);

            if (schedule != null)
            {
                foreach (var section in sections)
                {
                    schedules.Add(new ScheduleViewModel
                    {
                        Meals = _mealBusiness.GetMeals(userId, section.Id, schedule.Id),
                        Workouts = _workoutBusiness.GetWorkouts(userId, section.Id, schedule.Id),
                        Section = section.SectionKey


                    });

                }
            }


            return schedules;
        }
    }
}
