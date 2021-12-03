using Fitness.Models.ViewModels.Workouts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.Business
{
    public class WorkoutBusines
    {
        private readonly FitnessContext _fitnessContext;
        public WorkoutBusines(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public List<WorkoutViewModel> GetWorkout()
        {
            return _fitnessContext.Workouts.Select(w=>new WorkoutViewModel() {
            WorkoutId=w.Id,
            Name=w.Name,
            Type=w.Type,
            UserId=w.UserId,
            Endurance=new EnduranceViewModel()
            {
                Distance=w.Distance,
                Duration=w.Duration
            },
            Strength=new StrengthViewModel()
            {
                Reps=w.Reps,
                Sets=w.Sets,
                Weight=w.Weight
            }
            
            
            }).ToList();
        }
        public WorkoutViewModel GetWorkoutById(int workoutId)
        {
            Workout workout=_fitnessContext.Workouts.Find(workoutId);
            return new WorkoutViewModel()
            {
                WorkoutId=workout.Id,
                Name=workout.Name,
                Type=workout.Type,
                UserId=workout.UserId,
                Endurance=new EnduranceViewModel()
                {
                    Distance=workout.Distance,
                    Duration=workout.Duration
                },
                Strength=new StrengthViewModel()
                {
                    Reps=workout.Reps,
                    Sets=workout.Sets,
                    Weight=workout.Weight
                }
            };
        }
        public void AddWorkouts(WorkoutViewModel viewModel)
        {
            Workout workout = new Workout
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                UserId = viewModel.UserId

            };
            if (viewModel.Type == "Strength")
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
            Workout workout = _fitnessContext.Workouts.SingleOrDefault(a => a.Id == viewModel.WorkoutId);
            if (workout != null)
            {
                workout.Id = viewModel.WorkoutId.Value;
                workout.Name = viewModel.Name;
                workout.Type = viewModel.Type;
                
                if (viewModel.Type == "Strength")
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
    }
}
