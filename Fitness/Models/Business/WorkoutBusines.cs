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

        public List<Workout> GetWorkout()
        {
            return _fitnessContext.Workouts.ToList();
        }
        public Workout GetWorkoutById(int workoutId)
        {
            return _fitnessContext.Workouts.Find(workoutId);
        }
        public void AddWorkout(WorkoutViewModel viewModel)
        {
            Workout workout = new Workout {
                Name = viewModel.Name,
                Type=viewModel.Type

            };
            if (viewModel.Type== "Strength")
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
        //public void AddWorkout(Workout workout)
        //{
        //    _fitnessContext.Workouts.Add(workout);
        //    _fitnessContext.SaveChanges();

        //    if (workout.TypeId == "1")
        //    {
        //        var endurance = _fitnessContext.WorkoutEndurances.FirstOrDefault(w => w.Workout_Id == workout.Id);

        //        EnduranceworkoutViewModel enduranceworkout = new EnduranceworkoutViewModel()
        //        {
        //            WorkoutId = workout.Id,
        //            Name = workout.Name,
        //            Distance =endurance.Distance,
        //            Duration=endurance.Duration,
        //            TypeId=workout.TypeId

        //        };

        //    }
        //    if (workout.TypeId == "2")
        //    {
        //        var strength = _fitnessContext.WorkoutStrengths.FirstOrDefault(w => w.Workout_Id == workout.Id);
        //        StrengthWorkoutViewModel strengthWorkout = new StrengthWorkoutViewModel()
        //        {
        //            WorkoutId=workout.Id,
        //            Name=workout.Name,
        //            TypeId=workout.TypeId,
        //            Sets= strength.Sets,
        //            Reps= strength.Reps,
        //            Weight=strength.Weight

        //        };
        //    }
        //}

        public void EditWorkout(int workoutId)
        {
            Workout workout = _fitnessContext.Workouts.Find(workoutId);
            if (workout != null)
            {             
                _fitnessContext.Workouts.Update(workout);

                _fitnessContext.SaveChanges();
            }
        }
        public void DeleteWorkout(int WorkoutId)
        {       
            Workout workout = _fitnessContext.Workouts.Find(WorkoutId);
            //var UserWorkout = _fitnessContext.UserWorkouts.Where(w => w.WorkoutId == WorkoutId).ToList();
            //if (UserWorkout != null)
            //{
            //    _fitnessContext.UserWorkouts.RemoveRange(UserWorkout);
            //}
            if (workout != null)
            {
                _fitnessContext.Workouts.Remove(workout);
            }
            _fitnessContext.SaveChanges();
        }
    }
}
