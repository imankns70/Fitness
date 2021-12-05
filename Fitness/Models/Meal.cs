using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Meal
    {
        public Meal()
        {
            Ingredients = new HashSet<MealIngredient>();
            Users = new HashSet<UserMeal>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MealIngredient> Ingredients { get; set; }
        public virtual ICollection<UserMeal> Users { get; set; }
    }
}
