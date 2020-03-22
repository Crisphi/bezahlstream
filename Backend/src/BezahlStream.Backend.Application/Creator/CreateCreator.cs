using BezahlStream.Backend.Application.User;
using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezahlStream.Backend.Application.Creator
{
    public class CreateCreator
    {
        private UserManager<ApplicationUser> _userManager;
        private AppDbContext _context;

        public CreateCreator(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public class Request
        {
            public string UserId { get; set; }
            public string CreatorName { get; set; }
            public string Description { get; set; }
        }

        public async Task<Response> DoModelAsync(Request request)
        {
            Response response = new Response();

            GetUser.Response userResponse = await new GetUser(_userManager).DoModelAsync(new GetUser.Request { SearchOperator = GetUser.ISearchOperator.ID, SearchQuery = request.UserId });
            if (userResponse.isSucceeded)
            {
                response.Error = "Email allready exist.";
            }

            Database.Entities.Profile.CreatorProfile creator = new Database.Entities.Profile.CreatorProfile
            {
                Name = request.CreatorName,
                OwnerId = request.UserId,
                Owner = userResponse.User,
                Description = request.Description
            };

            _context.CreatorProfiles.Add(creator);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.isSucceeded = false;
                switch (ex.InnerException.ToString())
                {
                    case nameof(DbUpdateException):
                        response.Error = "Database update exception";
                        break;
                    case nameof(DbUpdateConcurrencyException):
                        response.Error = "Db update concurrency exception";
                        break;
                    default:
                        response.Error = ex.Message;
                        break;
                }
            }

            return response;
        }

        public class Response
        {
            public bool isSucceeded { get; set; }
            public string Error { get; set; }
        }
    }
}
