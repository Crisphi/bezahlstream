using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.Profile;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BezahlStream.Backend.Application.Creator
{
    public class GetCreators
    {
        private AppDbContext _context;

        public GetCreators(AppDbContext context)
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
            ID,
            ALL
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
                    response.Creators.Add(userResult);
                    break;
                case ISearchOperator.ID:
                    CreatorProfile resultId = await _context.CreatorProfiles.FindAsync(request.SearchQuery);
                    response.Creators.Add(resultId);
                    break;
                case ISearchOperator.ALL:
                    var resultAll = _context.CreatorProfiles.ToList();
                    response.Creators.AddRange(resultAll);
                    break;
                default:
                    break;
            }

            if (response.Creators.Count == 0) response.isSucceeded = false;
            return response;
        }

        public class Response
        {
            public bool isSucceeded { get; set; } = true;
            public List<CreatorProfile> Creators { get; set; } = new List<CreatorProfile>();
        }

    }
}
