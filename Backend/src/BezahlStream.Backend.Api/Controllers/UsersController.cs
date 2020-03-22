using BezahlStream.Backend.Application.User;
using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BezahlStream.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private AppDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager,AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetUser.Response>> GetUser(string id)
        {
            GetUser.Request request = new GetUser.Request { SearchOperator = Application.User.GetUser.ISearchOperator.ID, SearchQuery = id };
            GetUser.Response response = await new GetUser(_userManager).DoModelAsync(request);
            if (response.isSucceeded)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }


        // TODO: At current state this works more like a GetUser!
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetUsers.Response>> GetUsers([System.Web.Http.FromUri]GetUsers.Request request)
        {
            GetUsers.Response response = await new GetUsers(_userManager).DoModelAsync(request);
            if (response.isSucceeded)
            {
                return Ok(response);
            }
            else 
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Profile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateUser.Response>> CreateUserAsnyc(CreateUser.Request request)
        {
            CreateUser.Response response = await new CreateUser(_userManager).DoModelAsync(request);

            if (response.isSucceeded)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
