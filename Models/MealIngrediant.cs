using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class MealIngrediant
    {
        [Key]
        public int Id { get; set; }
        public int MealId { get; set; }
        public int IngrediantId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Ingrediant Ingrediant { get; set; }

    }
}
