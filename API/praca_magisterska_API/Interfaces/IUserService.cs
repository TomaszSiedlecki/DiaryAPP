using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using praca_magisterska_API.Models.UserController;

namespace praca_magisterska_API.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetUserByUsername(UserRequest arguments);
        Task<AddUserResponse> AddNewUser(AddUserRequest arguments);
        Task<ValidateUserResponse> ValidateUser(ValidateUserRequest arguments);
    }
}
