﻿using System;
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
        public DbSet<Ingrediant> Ingrediants { get; set; }
        public DbSet<MealIngrediant> MealIngrediants { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
    }
}