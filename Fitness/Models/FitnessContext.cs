using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Fitness.Models
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
        public DbSet<Workout> Workouts { get; set; }
<<<<<<< HEAD:Fitness/Models/FitnessContext.cs
   
=======
        public DbSet<UserWorkout> UserWorkouts { get; set; }
>>>>>>> c08814e842f53f7208e4a156eb3d20d71fca3d43:Models/FitnessContext.cs
    }
}
