using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using praca_magisterska_API.Interfaces;
using praca_magisterska_API.Models.UserController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace praca_magisterska_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetUser")]
        public Task<UserResponse> Get(UserRequest arguments)
        {
            return _userService.GetUserByUsername(arguments);
        }

        [HttpPost("AddUser")]
        public Task<AddUserResponse> Add (AddUserRequest arguments)
        {
            return _userService.AddNewUser(arguments);
        }

        [HttpPost("ValidateUser")]
        public Task<ValidateUserResponse> ValidateUser(ValidateUserRequest arguments)
        {
            return _userService.ValidateUser(arguments);
        }
    }
}
