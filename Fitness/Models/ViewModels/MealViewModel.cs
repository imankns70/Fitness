using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Ingredients { get; set; }
        public int UserId { get; set; }

    }
}
