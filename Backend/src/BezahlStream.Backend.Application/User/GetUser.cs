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
    public class GetUser
    {
        private UserManager<ApplicationUser> _userManager;

        public GetUser(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public class Request
        {
            public ISearchOperator SearchOperator { get; set; }
            public string SearchQuery { get; set; }
        }

        public enum ISearchOperator
        {
            USERNAME,
            ID,
            EMAIL
        }

        public async Task<Response> DoModelAsync(Request request)
        {
            Response response = new Response();

            // A dict where I store the operator so i can append the result and we can later change ISearchOperator in the request to an List of operators.
            Dictionary<ISearchOperator, ApplicationUser> resultDict = new Dictionary<ISearchOperator, ApplicationUser>();

            switch (request.SearchOperator)
            {
                case ISearchOperator.USERNAME:  // TODO: Change so that it responses with more that are close to the result username
                    ApplicationUser userResult = _userManager.Users.FirstOrDefault(x => x.UserName == request.SearchQuery);
                    resultDict.Add(request.SearchOperator, userResult);
                    break;
                case ISearchOperator.ID:
                    ApplicationUser resultId = await _userManager.FindByIdAsync(request.SearchQuery);
                    resultDict.Add(request.SearchOperator, resultId);
                    break;
                case ISearchOperator.EMAIL:
                    ApplicationUser resultEmail = await _userManager.FindByEmailAsync(request.SearchQuery);
                    resultDict.Add(request.SearchOperator, resultEmail);
                    break;
                default:
                    break;
            }
            return new Response
            {
                // if empty is notSucceeded
                isSucceeded = resultDict.ElementAt(0).Value != null,
                User = resultDict.ElementAt(0).Value
            };
        }

        public class Response
        {
            public bool isSucceeded { get; set; }
            public ApplicationUser User { get; set; }
        }

    }
}
