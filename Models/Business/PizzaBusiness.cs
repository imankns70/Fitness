using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Models.ViewModels;
using Fitness.Models.ViewModels.Pizza;
using Microsoft.EntityFrameworkCore;

namespace Fitness.Models.Business
{
    public class PizzaBusiness
    {
        private readonly FitnessContext _fitnessContext;

        public PizzaBusiness(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;

        }

        public List<PizzaViewModel> GetPizzas()
        {


            return _fitnessContext.Pizzas.Include(a => a.Toopings).ThenInclude(t => t.Topping).Select(a => new
                  PizzaViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Toppings = a.Toopings.Select(topping => new ToppingViewModel
                {
                    Id = topping.ToppingId,
                    Name = topping.Topping.Name,
                    PizzaId = topping.PizzaId
                }).ToList()

            }).ToList();
        }
        public List<ToppingViewModel> GetToppings()
        {
            return _fitnessContext.Toppings.Select(a => new ToppingViewModel
            {
                Id = a.Id,
                Name = a.Name,

            }).ToList();


        }

        public void UpdatePizza(PizzaViewModel pizzaModel)
        {
            Pizza pizza = _fitnessContext.Pizzas.Include(a => a.Toopings).First(a => a.Id == pizzaModel.Id);

            pizza.Name = pizzaModel.Name;

            List<PizzaTopping> removeToppings = pizza.Toopings.Where(pizzaTopping => !pizzaModel.Toppings.Select(s => s.Id).Contains(pizzaTopping.ToppingId)).ToList();
            List<ToppingViewModel> addToppings = pizzaModel.Toppings.Where(topping => !pizza.Toopings.Select(s => s.ToppingId).Contains(topping.Id)).ToList();
            _fitnessContext.PizzaToppings.RemoveRange(removeToppings);
            foreach (var topping in addToppings)
            {
                pizza.Toopings.Add(new PizzaTopping
                {
                    ToppingId = topping.Id
                });
            };
            _fitnessContext.SaveChanges();


        }
        public PizzaViewModel CreatePizza(PizzaViewModel pizzaModel)
        {
            Pizza pizza = new Pizza
            {
                Name = pizzaModel.Name,

                Toopings = pizzaModel.Toppings.Select(a => new PizzaTopping
                {

                    ToppingId = a.Id

                }).ToList()
            };
            _fitnessContext.Pizzas.Add(pizza);
            _fitnessContext.SaveChanges();
            pizzaModel.Id = pizza.Id;
            foreach (var topping in pizzaModel.Toppings)
            {
                topping.PizzaId = pizza.Toopings.First(a => a.ToppingId == topping.Id).PizzaId;
            }
         

            return pizzaModel;

        }
        public void DeletePizza(int id)
        {
            Pizza pizza = _fitnessContext.Pizzas.Include(p=>p.Toopings).ThenInclude(t=>t.Topping).First(a=>a.Id==id);
            _fitnessContext.Pizzas.Remove(pizza);
            _fitnessContext.SaveChanges();
        }

    }
}
