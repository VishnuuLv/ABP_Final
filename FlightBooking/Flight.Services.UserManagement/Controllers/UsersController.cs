using Flight.Services.UserManagement.Authorization;
using Flight.Services.UserManagement.Entities;
using Flight.Services.UserManagement.Helpers;
using Flight.Services.UserManagement.Models.Users;
using Flight.Services.UserManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.UserManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly DataContext _db;
        public UsersController(IUserService userService,DataContext db)
        {
            _db = db;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("action")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            //var currentUser = (User)HttpContext.Items["User"];
            //if (id != currentUser.Id && currentUser.Role != Role.Admin)
            //    return Unauthorized(new { message = "Unauthorized" });

            var user = _userService.GetById(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Post([FromBody] UserDto userdto)
        {
            try
            {
                UserDto model = await _userService.CreateUser(userdto);
                //_response.Result = model;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User Creation Failed" });
                //_response.IsSuccess = false;
                //_response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(new { Status = "Success", Message = "User Created Successfully" });
        }
    }
}
