using Hall_App.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Hall_App.Service
{
    public class LoginService : ILoginService
    {
        public bool ValidateUser(UserDto user)
        {
            if (user == null) return false;
            if (string.IsNullOrEmpty(user.Email)) return false;
            if (string.IsNullOrEmpty(user.Password)) return false;
            if (user.Email == "Admin@adminmail.se" && user.Password == "password")
            {
                return true;
            }
            return false;
        }



    }
}
