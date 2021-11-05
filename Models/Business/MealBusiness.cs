using Fitness.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.Business
{
    public class MealBusiness
    {

        private readonly FitnessContext _fitnessContext;
        public MealBusiness(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public List<MealViewModel> GetMeals(int userId)
        {

            return _fitnessContext.UserMeals.Where(a => a.UserId == userId)
                 .Select(a => new MealViewModel
                 {
                     Id = a.MealId,
                     Name = a.Meal.Name,
                     Ingridiants = a.Meal.Ingrediants.Select(x => x.Ingrediant.Name).ToArray()
                 }
                 ).ToList();
        }

    }
}
