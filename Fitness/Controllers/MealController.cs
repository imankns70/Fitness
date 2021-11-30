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
        //[HttpGet]
        [HttpGet("{id}")]
        public ApiResult<List<MealViewModel>> Get(int? id)
        {
            //return Ok(new List<MealViewModel>());
            return Ok(_mealBusiness.GetMeals(id));


        }

        [HttpPost]
        public ApiResult Add(MealViewModel viewModel)
        {
            if (viewModel != null)
            {
                _mealBusiness.AddMeal(viewModel);
                return Ok();
            }
            return BadRequest("هیچ داده ای ارسال نشد");
        }
        // update the action
        [HttpPut]
        public ApiResult Edit(MealViewModel viewModel)
        {
            if (viewModel != null)
            {
                _mealBusiness.EditMeal(viewModel);
                return Ok();
            }
            return BadRequest("هیچ داده ای ارسال نشد");
        }
        [HttpDelete]
        public ApiResult Delete(MealViewModel viewModel)
        {
            if (viewModel != null)
            {
                _mealBusiness.Remove(viewModel.Id, viewModel.UserId);            
                return Ok();
            }

            return BadRequest("هیچ غذایی یافت نشد");
        }

    }
}