using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Models;
using Fitness.Models.Business;
using Fitness.Models.Commons;
using Fitness.Models.ViewModels;
using Fitness.Models.ViewModels.Pizza;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaBusiness _PizzaBusiness;
        public PizzaController(PizzaBusiness PizzaBusiness)
        {
            _PizzaBusiness = PizzaBusiness;
        }

        [HttpGet]
        public ApiResult<List<PizzaViewModel>> Get()
        {
            List<PizzaViewModel> Pizzas = _PizzaBusiness.GetPizzas();

            return Ok(Pizzas); 
        }
        [HttpGet("GetToppings")]
        public ApiResult<List<ToppingViewModel>> GetToppings()
        {
            List<ToppingViewModel> toppings = _PizzaBusiness.GetToppings();

            return Ok(toppings);
        }
        [HttpPost]
        public ApiResult<PizzaViewModel> Post(PizzaViewModel viewModel)
        {

            return Ok(_PizzaBusiness.CreatePizza(viewModel));
        }
        [HttpPut]
        public ApiResult Put(PizzaViewModel viewModel)
        {
            _PizzaBusiness.UpdatePizza(viewModel);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            _PizzaBusiness.DeletePizza(id);
            return Ok();
        }

    }
}