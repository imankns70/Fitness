using Fitness.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public List<MealViewModel> GetMeals(int? userId)
        {
            var result = _fitnessContext.UserMeals.AsQueryable();
            if (userId.HasValue)
            {
                result = result.Where(a => a.UserId == userId);
            }

            return result
                 .Select(a => new MealViewModel
                 {
                     Id = a.MealId,
                     Name = a.Meal.Name,
                     Ingredients = a.Meal.Ingredients.Select(x => x.Ingredient.Name).ToArray(),
                     UserId = a.UserId
                 }
                 ).ToList();
        }
       

        public void Remove(int mealId, int userId)
        {
            
            //UserMeal userMeal = _fitnessContext.UserMeals.Where(a => a.MealId == mealId && a.UserId == userId).Single();
            List<UserMeal> userMeals = _fitnessContext.UserMeals.Where(c => c.MealId == mealId).ToList();
            List<UserMeal> anotherUserMeals = userMeals.Where(a => a.UserId != userId).ToList();
            List<MealIngredient> mealIngredients = _fitnessContext.MealIngredients.Where(c => c.MealId == mealId).ToList();
            List<MealIngredient> anotheringridents = mealIngredients.Where(a => a.MealId != mealId).ToList();
            if (!anotheringridents.Any() && !anotherUserMeals.Any())
            {

                Meal meal = _fitnessContext.Meals.Single(a=> a.Id==mealId);
                _fitnessContext.Meals.Remove(meal);
            }

            else
            {
                if (anotheringridents.Any())
                {
                    _fitnessContext.MealIngredients.RemoveRange(mealIngredients);
                }

                if (anotherUserMeals.Any())
                {
                    UserMeal userMeal = userMeals.Single(a => a.UserId == userId);
                    _fitnessContext.UserMeals.Remove(userMeal);
                }
            }

            _fitnessContext.SaveChanges();




        }


        //public void DeleteMeal(int mealId)
        //{
        //    Meal meal = _fitnessContext.Meals.Include(a => a.Ingredients).Include(a => a.Users)
        //        .SingleOrDefault(a => a.Id == mealId);
        //    if (meal != null)
        //    {
        //        List<int> ingredientId = _fitnessContext.MealIngredients.Where(a => a.MealId == meal.Id).Select(a => a.IngredientId).ToList();
        //        if (ingredientId.Any())
        //        {
        //            foreach (var item in ingredientId)
        //            {
        //                MealIngredient mealIngredient1 = new MealIngredient()
        //                {
        //                    MealId = meal.Id,
        //                    IngredientId = item
        //                };
        //                _fitnessContext.MealIngredients.Remove(mealIngredient1);
        //            }

        //        }

        //        List<int> usersId = _fitnessContext.UserMeals.Where(a => a.MealId == meal.Id).Select(a => a.UserId).ToList();
        //        if (usersId.ToString() != null)
        //        {
        //            foreach (var userid in usersId)
        //            {
        //                UserMeal userMeal = new UserMeal()
        //                {
        //                    MealId = meal.Id,
        //                    UserId = userid
        //                };
        //                _fitnessContext.UserMeals.Remove(userMeal);
        //            }
        //        }

        //        _fitnessContext.Meals.Remove(meal);
        //        if (!_fitnessContext.MealIngredients.Any(a => a.IngredientId == a.Ingredient.Id))
        //        {


        //        }
        //        _fitnessContext.SaveChanges();

        //    }

        //}
        //public void RemoveMeal(int mealId)
        //{
        //    List<UserMeal> userMeals = _fitnessContext.UserMeals.Where(a => a.MealId == mealId).ToList();
        //    List<MealIngredient> mealIngredients = _fitnessContext.MealIngredients.Where(a => a.MealId == mealId).ToList();
        //    List<Ingredient> ingredients = _fitnessContext.Ingredients.
        //        Where(a => mealIngredients.Select(s => s.IngredientId).Contains(a.Id)).ToList();
        //    Meal meal = _fitnessContext.Meals.First(a => a.Id == mealId);
        //    _fitnessContext.MealIngredients.RemoveRange(mealIngredients);
        //    _fitnessContext.UserMeals.RemoveRange(userMeals);
        //    _fitnessContext.Ingredients.RemoveRange(ingredients);
        //    _fitnessContext.Meals.Remove(meal);


        //}

        public void EditMeal(MealViewModel viewModel)
        {
            var meal = _fitnessContext.Meals.SingleOrDefault(i => i.Id == viewModel.Id);
            if (meal != null)
            {
                if (viewModel.Name != null)
                {
                    if (!_fitnessContext.Meals.Any(n => n.Name == viewModel.Name))
                    {
                        meal.Name = viewModel.Name;
                    }

                }
                if (viewModel.Ingredients != null)
                {
                    foreach (var item in viewModel.Ingredients)
                    {
                        if (!_fitnessContext.Ingredients.Any(i => i.Name == item))
                        {
                            _fitnessContext.Ingredients.Add(new Ingredient()
                            {
                                Name = item
                            });
                        }

                    }
                }
            }

            _fitnessContext.Meals.Update(meal);
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

