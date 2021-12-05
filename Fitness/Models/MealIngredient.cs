using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class MealIngredient
    {
        [Key]
        public int Id { get; set; }
        public int MealId { get; set; }
        public int IngredientId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}
