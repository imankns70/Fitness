using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class UserMeal
    {
        [Key]
        public int Id { get; set; }
        public int MealId { get; set; }
        public int UserId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual User User { get; set; }
        public int  SectionId { get; set; }
        public virtual Section Section { get; set; }

    }
}
