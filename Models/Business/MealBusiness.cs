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

        public List<MealViewModel> GetMeals(int userId, int? sectionId, int? scheduleId)
        {
            var result = _fitnessContext.UserMeals.Include(s => s.Meal).ThenInclude(f => f.Ingredients).Where(a => a.UserId == userId);

            if (sectionId.HasValue)
                result = result.Where(a => a.SectionId == sectionId);
            if (scheduleId.HasValue)
                result = result.Where(a => a.ScheduleId == scheduleId);

            var groupMeal = result.ToList().GroupBy(
                   x => x.MealId,
                   x => x,
                   (key, g) => new { MealId = key, List = g }).ToList();

            List<MealViewModel> meals = new List<MealViewModel>();
            foreach (var item in groupMeal)
            {
                var ingredients = _fitnessContext.MealIngredients.Where(a => a.MealId == item.MealId).Select(s => s.Ingredient.Name).ToArray();
                meals.Add(
                    new MealViewModel
                    {
                        Id = item.MealId,
                        Name = item.List.First().Meal?.Name,
                        Ingredients = ingredients,
                        UserId = item.List.First().UserId
                    }
                    );
            }
            return meals;
        }

        //حذف غذا
        public void Remove(int mealId, int userId)
        {

            //UserMeal userMeal = _fitnessContext.UserMeals.Where(a => a.MealId == mealId && a.UserId == userId).Single();
            List<UserMeal> userMeals = _fitnessContext.UserMeals.Where(c => c.MealId == mealId).ToList();
            List<UserMeal> anotherUserMeals = userMeals.Where(a => a.UserId != userId).ToList();
            List<MealIngredient> mealIngredients = _fitnessContext.MealIngredients.Where(c => c.MealId == mealId).ToList();
            List<MealIngredient> anotheringridents = mealIngredients.Where(a => a.MealId != mealId).ToList();
            if (!anotheringridents.Any() && !anotherUserMeals.Any())
            {

                Meal meal = _fitnessContext.Meals.Single(a => a.Id == mealId);
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
                            UserId= viewModel.UserId,
                            Section= new Section
                            {
                                Name= viewModel.Section
                            }
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
        public void AssignedMealToSchedule(ScheduleAssign scheduleAssign)
        {
            List<Meal> meals = _fitnessContext.Meals.Where(a => scheduleAssign.Assigned.Contains(a.Name)).ToList();
            var sectionId = _fitnessContext.Sections.Single(a => a.Name == scheduleAssign.Section).Id;
            var schedule = _fitnessContext.Schedules.FirstOrDefault(a => a.SelectedDay == scheduleAssign.Day.Date);


            List<UserMeal> userMealsInDb = _fitnessContext.UserMeals
                .Where(a => a.UserId == scheduleAssign.UserId && a.SectionId == sectionId && a.ScheduleId == schedule.Id).ToList();

            var addList = meals.Where(a => !userMealsInDb.Select(s => s.MealId).Contains(a.Id)).ToList();

            List<UserMeal> adds = new List<UserMeal>();
            foreach (var item in meals)
            {
                _fitnessContext.UserMeals.Add(new UserMeal
                {
                    SectionId = sectionId,
                    Schedule = schedule == null ? new Schedule { SelectedDay = scheduleAssign.Day } : schedule,
                    MealId = item.Id,
                    UserId = scheduleAssign.UserId
                }
                  );


            }

            List<UserMeal> removeList = userMealsInDb.Where(a => !meals.Select(s => s.Id).Contains(a.Id)).ToList();
            _fitnessContext.RemoveRange(removeList);


            _fitnessContext.SaveChanges();
        }


    }
}

