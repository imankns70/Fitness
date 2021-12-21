using Fitness.Models;
using Fitness.Models.Business;
using Fitness.Models.Commons;
using Fitness.Models.ViewModels;
using Fitness.Models.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class WorkOutController : ControllerBase
    {
        private WorkoutBusiness workoutBusines;
        public WorkOutController(WorkoutBusiness workoutBusines)
        {
            this.workoutBusines = workoutBusines;
        }
       
    
        [HttpGet("GetAllWorkouts")]
        public ApiResult<List<WorkoutViewModel>> GetAllWorkouts()
        {
            return Ok(workoutBusines.GetWorkouts());
        }
        //[HttpGet("{id}")]
        //public ApiResult<WorkoutViewModel> GetWorkoutById(int id)
        //{
        //    return Ok(workoutBusines.GetWorkoutById(id));
        //}
 
        [HttpPost]
        public ApiResult AddWorkout(WorkoutViewModel workout)
        {
            workoutBusines.AddWorkouts(workout);
            return Ok();
        }

     

        [HttpPut]
        public ApiResult EditWorkout(WorkoutViewModel viewModel)
        {
            try
            {
                workoutBusines.EditWorkouts(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


            return Ok();

        }

        // DELETE api/<WorkOutController>/5
        [HttpDelete]
        public void DeleteWorkout(int id)
        {
            workoutBusines.DeleteWorkouts(id);
        }
    }
}
