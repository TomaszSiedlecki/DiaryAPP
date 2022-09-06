using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Models.UserController;
using praca_magisterska_API.Interfaces;

namespace praca_magisterska_API.Services
{
    public class UserService : IUserService
    {
        private readonly DiaryDataSourceContext _context;

        public UserService(DiaryDataSourceContext context)
        {
            _context = context;
        }
        public async Task<UserResponse> GetUserByUsername(UserRequest arguments)
        {
            var result = new UserResponse { IsSuccessfull = true };
            try
            {
                var user = _context.User.Where(s => s.FirstName == arguments.FirstName && s.SecondName == arguments.SecondName).FirstOrDefault();
                if (user == null)
                {
                    result.IsSuccessfull = false;
                    return result;
                }
                result.FirstName = user.FirstName;
                result.SecondName = user.SecondName;
                result.BornDate = user.BornDate;
                result.Address = user.Address;

                var classDetails = _context.Class.Where(s => s.ClassID == user.ClassID).FirstOrDefault();

                if (classDetails != null)
                {
                    result.ClassName = classDetails.Name;
                }

                var roleDetails = _context.Role.Where(s => s.RoleID == user.RoleID).FirstOrDefault();

                if (roleDetails != null)
                {
                    result.Role = roleDetails.Name;
                }

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
        }
        public async Task<AddUserResponse> AddNewUser(AddUserRequest arguments)
        {
            var result = new AddUserResponse { IsSuccessfull = true };
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(arguments.Password);

                var newUser = _context.User.Add(new User
                {
                    AccountName = arguments.AccountName,
                    Address = arguments.Address,
                    BornDate = arguments.BornDate,
                    Email = arguments.Email,
                    FirstName = arguments.FirstName,
                    Password = passwordHash,
                    SecondName = arguments.SecondName,
                    ClassID = arguments.ClassID,
                    RoleID = arguments.RoleID
                });

                _context.SaveChanges();
                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
        }
        public async Task<ValidateUserResponse> ValidateUser(ValidateUserRequest arguments)
        {
            var result = new ValidateUserResponse { IsSuccessfull = true };
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(arguments.Password);
                var account = _context.User.Where(s => s.AccountName == arguments.UserName && s.Password == arguments.Password).FirstOrDefault();
                if (account == null)
                {
                    result.IsSuccessfull = false;
                    return result;
                }
                if (account.ClassID == null)
                {
                    result.ClassID = 0;
                }
                else
                {
                    result.ClassID = (long)account.ClassID;
                }
                result.IsValid = true;
                result.Username = account.FirstName;
                result.Surname = account.SecondName;
                result.StudentID = account.UserID;

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
        }
    }
}
