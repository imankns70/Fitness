using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Models;
using Fitness.Models.Business;
using Fitness.Models.Commons;
using Fitness.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class MealController : ControllerBase
    {
        private readonly MealBusiness _mealBusiness;
        public MealController(MealBusiness mealBusiness)
        {
            _mealBusiness = mealBusiness;
        }
        [HttpGet("{id}")]
        public ApiResult<List<MealViewModel>> Get(int? id)
        {
            if (id.HasValue)
            {
                //return Ok(new List<MealViewModel>());
                return Ok(_mealBusiness.GetMeals(id.Value));
            }
            return BadRequest("هیچ کاربری یافت نشد");
        }

        [HttpPost]
        public ApiResult Add(MealViewModel viewModel)
        {
            if (viewModel != null)
            {
                //return Ok(new List<MealViewModel>());
                _mealBusiness.AddMeal(viewModel);
                return Ok();
            }
            return BadRequest("هیچ داده ای ارسال نشد");
        }
       
        [HttpDelete("{id}")]
        public ApiResult Delete(int? id)
        {
            if (id != null)
            {
                //return Ok(new List<MealViewModel>());
                _mealBusiness.RemoveMeal(id.Value);
                return Ok();
            }
            return BadRequest("هیچ غذایی یافت نشد");
        }

    }
}