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
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleBusiness _scheduleBusiness;
        public ScheduleController(ScheduleBusiness scheduleBusiness)
        {
            _scheduleBusiness = scheduleBusiness;
        }

        [HttpGet]
        public ApiResult<List<ScheduleViewModel>> Get(int userId, DateTime selectedDay)
        {
            List<ScheduleViewModel> schedules = _scheduleBusiness.GetSchedule(userId, selectedDay);
            return Ok(schedules);
        }

        [HttpPost]
        public ApiResult<List<ScheduleViewModel>> ScheculeAssigned(ScheduleAssign viewModel)
        {
            // add assigned
            return Ok(_scheduleBusiness.GetSchedule(viewModel.UserId, viewModel.Day));
        }

    }
}