using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels.Pizza
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToppingViewModel> Toppings { get; set; }
        

        
    }
  
}
