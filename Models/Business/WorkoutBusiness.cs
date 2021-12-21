using Fitness.Models.ViewModels;
using Fitness.Models.ViewModels.Workouts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.Business
{
    public class WorkoutBusiness
    {
        private readonly FitnessContext _fitnessContext;
        public WorkoutBusiness(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public List<WorkoutViewModel> GetWorkouts()
        {
            var result = _fitnessContext.Workouts.AsQueryable();



            return result.Select(w => new WorkoutViewModel()
            {
                Id = w.Id,
                Name = w.Name,
                Type = w.Type,
                //UserId = w,
                Endurance = new EnduranceViewModel()
                {
                    Distance = w.Distance,
                    Duration = w.Duration
                },
                Strength = new StrengthViewModel()
                {
                    Reps = w.Reps,
                    Sets = w.Sets,
                    Weight = w.Weight
                }


            }).ToList();
        }
        public WorkoutViewModel GetWorkoutById(int id)
        {
            return _fitnessContext.Workouts.Where(a => a.Id == id).Select(w => new WorkoutViewModel()
            {
                Id = w.Id,
                Name = w.Name,
                Type = w.Type,
                //UserId = w,
                Endurance = new EnduranceViewModel()
                {
                    Distance = w.Distance,
                    Duration = w.Duration
                },
                Strength = new StrengthViewModel()
                {
                    Reps = w.Reps,
                    Sets = w.Sets,
                    Weight = w.Weight
                }


            }).First();
        }
        public List<WorkoutViewModel> GetWorkoutsBySchedule(int userId, int sectionId, int scheduleId)
        {

            return _fitnessContext.UserWorkouts.Where(a => a.UserId == userId && a.SectionId == sectionId && a.ScheduleId == scheduleId)
                .Include(s => s.Workout).Select(w => new WorkoutViewModel()
                {
                    Id = w.Id,
                    Name = w.Workout.Name,
                    Type = w.Workout.Type,
                    UserId = w.UserId,
                    Endurance = new EnduranceViewModel()
                    {
                        Distance = w.Workout.Distance,
                        Duration = w.Workout.Duration
                    },
                    Strength = new StrengthViewModel()
                    {
                        Reps = w.Workout.Reps,
                        Sets = w.Workout.Sets,
                        Weight = w.Workout.Weight
                    }


                }).ToList();
        }

        public void AddWorkouts(WorkoutViewModel viewModel)
        {
            Workout workout = new Workout
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                //UserId = viewModel.UserId

            };
            if (viewModel.Type == "strength")
            {
                workout.Reps = viewModel.Strength.Reps;
                workout.Sets = viewModel.Strength.Sets;
                workout.Weight = viewModel.Strength.Weight;
            }
            else
            {
                workout.Duration = viewModel.Endurance.Duration;
                workout.Distance = viewModel.Endurance.Distance;
            }
            _fitnessContext.Workouts.Add(workout);
            _fitnessContext.SaveChanges();
        }
        public void EditWorkouts(WorkoutViewModel viewModel)
        {
            Workout workout = _fitnessContext.Workouts.SingleOrDefault(a => a.Id == viewModel.Id);
            if (workout != null)
            {
                workout.Id = viewModel.Id.Value;
                workout.Name = viewModel.Name;
                workout.Type = viewModel.Type;

                if (viewModel.Type == "strength")
                {
                    workout.Sets = viewModel.Strength.Sets;
                    workout.Reps = viewModel.Strength.Reps;
                    workout.Weight = viewModel.Strength.Weight;
                }
                else
                {
                    workout.Duration = viewModel.Endurance.Duration;
                    workout.Distance = viewModel.Endurance.Distance;
                }

                _fitnessContext.Workouts.Update(workout);
                _fitnessContext.SaveChanges();
            }
            else
            {
                throw new Exception("هیچ تمرینی برایشما یافت نشد");
            }
        }
        public void DeleteWorkouts(int WorkoutId)
        {
            Workout workout = _fitnessContext.Workouts.Find(WorkoutId);
            if (workout != null)
            {
                _fitnessContext.Workouts.Remove(workout);
            }
            _fitnessContext.SaveChanges();
        }


        public void AssignedWorkoutToSchedule(ScheduleAssign scheduleAssign)
        {

            List<Workout> workouts = _fitnessContext.Workouts.Where(a => scheduleAssign.Assigned.Contains(a.Name)).ToList();
            var sectionId = _fitnessContext.Sections.Single(a => a.SectionKey == scheduleAssign.Section).Id;
            DateTime startDate = scheduleAssign.Day.Date.Add(new TimeSpan(0, 0, 0));
            DateTime endDate = scheduleAssign.Day.Date.Add(new TimeSpan(23, 59, 59));
            Schedule schedule = _fitnessContext.Schedules.FirstOrDefault(a => a.SelectedDay >= startDate && a.SelectedDay <= endDate);


            if (schedule != null)
            {
                List<UserWorkout> userWorkoutsInDb = _fitnessContext.UserWorkouts
                              .Where(a => a.UserId == scheduleAssign.UserId && a.SectionId == sectionId && a.ScheduleId == schedule.Id).ToList();

                var addList = workouts.Where(a => !userWorkoutsInDb.Select(s => s.WorkoutId).Contains(a.Id)).ToList();

                if (addList.Any())
                    AddWorkoutToNewSchedule(scheduleAssign, sectionId, addList, schedule.Id);

                List<UserWorkout> removeList = userWorkoutsInDb.Where(a => !workouts.Select(s => s.Id).Contains(a.WorkoutId)).ToList();

                _fitnessContext.UserWorkouts.RemoveRange(removeList);



            }
            else
            {
                AddWorkoutToNewSchedule(scheduleAssign, sectionId, workouts, null);
            }



            _fitnessContext.SaveChanges();
        }
        public void AddWorkoutToNewSchedule(ScheduleAssign scheduleAssign, int sectionId, List<Workout> workouts, int? scheduleId)
        {
            int currentSchedulId;
            if (scheduleId.HasValue)
            {
                currentSchedulId = scheduleId.Value;

            }
            else
            {
                Schedule schedule = new Schedule { SelectedDay = scheduleAssign.Day };
                _fitnessContext.Schedules.Add(schedule);
                _fitnessContext.SaveChanges();
                currentSchedulId = schedule.Id;
            }



            foreach (var item in workouts)
            {
                _fitnessContext.UserWorkouts.Add(new UserWorkout
                {
                    SectionId = sectionId,
                    ScheduleId = currentSchedulId,
                    WorkoutId = item.Id,
                    UserId = scheduleAssign.UserId
                });


            }
        }
    }
}
