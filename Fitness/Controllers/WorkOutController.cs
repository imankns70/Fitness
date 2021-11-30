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
        private WorkoutBusines workoutBusines;
        public WorkOutController(WorkoutBusines workoutBusines)
        {
            this.workoutBusines = workoutBusines;
        }
        // GET: api/<WorkOutController>
        [HttpGet]
        public ApiResult<IEnumerable<Workout>> Get()
        {
            return Ok(workoutBusines.GetWorkout());
        }
       
        //}
        // GET api/<WorkOutController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(workoutBusines.GetWorkoutById(id));
        }

        // POST api/<WorkOutController>
        [HttpPost]
        public ApiResult AddWorkout(WorkoutViewModel workout)
        {
            workoutBusines.AddWorkout(workout);
            return Ok();
        }

        // PUT api/<WorkOutController>/5
       
        [HttpPut]
        public ApiResult EditWorkout(WorkoutViewModel viewModel)
        {

            //workoutBusines.EditWorkout(id);
            return Ok();
           
        }

        // DELETE api/<WorkOutController>/5
        [HttpDelete]
        public void Delete(int workoutId)
        {
            //workoutBusines.DeleteWorkout(id);
        }
    }
}
