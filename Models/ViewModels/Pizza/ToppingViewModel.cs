using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels.Pizza
{
    public class ToppingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PizzaId { get; set; }
    }
}
