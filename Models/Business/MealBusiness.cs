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
                     Ingredients = a.Meal.Ingredients.Select(x => x.Ingredient.Name).ToArray()
                 }
                 ).ToList();
        }


        public void RemoveMeal(int mealId)
        {
            List<UserMeal> userMeals = _fitnessContext.UserMeals.Where(a => a.MealId == mealId).ToList();
            List<MealIngredient> mealIngredients = _fitnessContext.MealIngredients.Where(a => a.MealId == mealId).ToList();
            List<Ingredient> ingredients = _fitnessContext.Ingredients.
                Where(a => mealIngredients.Select(s => s.IngredientId).Contains(a.Id)).ToList();
            Meal meal = _fitnessContext.Meals.First(a => a.Id == mealId);
            _fitnessContext.MealIngredients.RemoveRange(mealIngredients);
            _fitnessContext.UserMeals.RemoveRange(userMeals);
            _fitnessContext.Ingredients.RemoveRange(ingredients);
            _fitnessContext.Meals.Remove(meal);
            _fitnessContext.SaveChanges();

        }

        public void AddMeal(MealViewModel viewModel)
        {
            var name = _fitnessContext.Meals.SingleOrDefault(n => n.Name == viewModel.Name);
            //var userId = _fitnessContext.UserMeals.SingleOrDefault(u => u.UserId == viewModel.UserId);
            
            if (name == null)
            {
                Meal meal = new Meal
                {
                    Name = viewModel.Name,
                    Users = new List<UserMeal>
                    {
                        new UserMeal
                        {
                            UserId= viewModel.UserId
                        }
                    }
                };
                List<Ingredient> existIngrediants = _fitnessContext.Ingredients.Where(a => viewModel.Ingredients.Contains(a.Name)).ToList();
                foreach (var item in viewModel.Ingredients)
                {
                    var ingredient = existIngrediants.SingleOrDefault(i => i.Name == item);
                    if (ingredient == null)
                    {
                        meal.Ingredients.Add(new MealIngredient

                        {
                            Ingredient = new Ingredient()
                            {
                                Name = item
                            }

                        });

                    }
                    else
                    {
                        meal.Ingredients.Add(new MealIngredient
                        {
                            Ingredient = ingredient

                        });

                    }


                }


                _fitnessContext.Meals.Add(meal);
                _fitnessContext.SaveChanges();
            }
            else
            {
                throw new Exception("نام غذا تکراری می باشد");
            }
        }
    }
}

