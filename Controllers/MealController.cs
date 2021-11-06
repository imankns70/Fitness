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
    [ApiController]
    [Route("api/[controller]")]
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
    }
}