using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.Profile;
using BezahlStream.Backend.Database.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezahlStream.Backend.Application.Creator
{
    public class GetCreator
    {
        private AppDbContext _context;

        public GetCreator(AppDbContext context)
        {
            _context = context;
        }

        public class Request
        {
            public ISearchOperator SearchOperator { get; set; }
            public string SearchQuery { get; set; }
        }

        public enum ISearchOperator
        {
            NAME,
            ID
        }

        public async Task<Response> DoModelAsync(Request request)
        {
            Response response = new Response();

            // A dict where I store the operator so i can append the result and we can later change ISearchOperator in the request to an List of operators.
            Dictionary<ISearchOperator, CreatorProfile> resultDict = new Dictionary<ISearchOperator, CreatorProfile>();

            switch (request.SearchOperator)
            {
                case ISearchOperator.NAME:  // TODO: Change so that it responses with more that are close to the result username
                    CreatorProfile userResult = _context.CreatorProfiles.FirstOrDefault(x => x.Name == request.SearchQuery);
                    resultDict.Add(request.SearchOperator, userResult);
                    break;
                case ISearchOperator.ID:
                    CreatorProfile resultId = await _context.CreatorProfiles.FindAsync(request.SearchQuery);
                    resultDict.Add(request.SearchOperator, resultId);
                    break;
                default:
                    break;
            }
            return new Response
            {
                // if empty is notSucceeded
                isSucceeded = resultDict.ElementAt(0).Value != null,
                Users = resultDict.ElementAt(0).Value
            };
        }

        public class Response
        {
            public bool isSucceeded { get; set; }
            public CreatorProfile Users { get; set; }
        }

    }
}
