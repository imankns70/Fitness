using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MealIngredient> Ingredients { get; set; }
        public virtual ICollection<UserMeal> Users { get; set; }
    }
}
