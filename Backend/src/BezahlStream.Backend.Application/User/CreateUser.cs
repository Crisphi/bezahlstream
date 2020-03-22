using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.Profile;
using BezahlStream.Backend.Database.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezahlStream.Backend.Application.User
{
    public class CreateUser
    {
        private UserManager<ApplicationUser> _userManager;

        public CreateUser(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public class Request
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public async Task<Response> DoModelAsync(Request request)
        {
            Response response = new Response();

            GetUser.Response userResponse = await new GetUser(_userManager).DoModelAsync(new GetUser.Request { SearchOperator = GetUser.ISearchOperator.USERNAME, SearchQuery = request.Email });
            if (userResponse.isSucceeded)
            {
                response.Errors.Add("Email allready exist.");
            }

            IdentityResult result = await _userManager.CreateAsync(new ApplicationUser { Email = request.Email, UserName = request.UserName }, request.Password);

            if (result.Succeeded)
            {
                response.isSucceeded = true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Errors.Add($"Code: {error.Code}, \nDescription: {error.Description}");
                }
            }

            return response;
        }

        public class Response
        {
            public bool isSucceeded { get; set; }
            public List<string> Errors { get; set; } = new List<string>();
        }


    }
}
