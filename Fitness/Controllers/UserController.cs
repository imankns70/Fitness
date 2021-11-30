using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Models;
using Fitness.Models.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fitness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiResultFilter]
    public class UserController : ControllerBase
    {
        private readonly FitnessContext _fitnessContext;
        public UserController(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        [HttpGet]
        public ApiResult<IEnumerable<User>> Get()
        {
            var users = _fitnessContext.Users.ToList();
            return Ok(users);
        }



        [HttpPost("[action]")]
        public async Task<ApiResult<User>> Register([FromBody] User user)
        {
            bool users = _fitnessContext.Users.Any(e => e.Email == user.Email.Trim().ToLower());
            
            if (!users)
            {
                user.Email = user.Email.Trim().ToLower();
                await _fitnessContext.Users.AddAsync(user);
                await _fitnessContext.SaveChangesAsync();
                return Ok(user);
            }
            return BadRequest("ایمیل تکراری میباشد");
        }
        [HttpPost("[action]")]
        public ApiResult<User> Login([FromBody] User user)
        {

            User userModel = _fitnessContext.Users.FirstOrDefault(a => a.Email== user.Email.Trim().ToLower());
            if (userModel != null)
                return Ok(userModel);
            return BadRequest("هیچ کاربری پیدا نشد");

        }
    }
}
