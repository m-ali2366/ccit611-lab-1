using Backend.Service.Common.Views;
using System.Collections.Generic;

namespace Backend.Service.Features.Authentication.Login
{
    public class LoginResult
    {
        public string Token { get; set; }
        public string Message { get; set; }
    }
    public static class LoginErrors
    {
        public static Error InvalidCredentials => new("InvalidCredentials", "Invalid Credentials");
        public static Error InvalidUserNameOrPassword=> new("Invalid Username Or Password", "Invalid Username Or Password");
    }
}
