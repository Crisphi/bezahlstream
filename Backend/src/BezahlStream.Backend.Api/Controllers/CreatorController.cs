using BezahlStream.Backend.Application.Creator;
using BezahlStream.Backend.Application.User;
using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezahlStream.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreatorController: ControllerBase
    {
        private AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CreatorController(AppDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetCreator.Response>> GetCreatorAsnyc(string id)
        {
            GetCreator.Request request = new GetCreator.Request { SearchOperator= GetCreator.ISearchOperator.ID, SearchQuery = id};
            GetCreator.Response response = await new GetCreator(_context).DoModelAsync(request);
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
        public async Task<ActionResult<GetCreator.Response>> GetCreatorsAsnyc([System.Web.Http.FromUri]GetCreators.Request request)
        {
            GetCreators.Response response = await new GetCreators(_context).DoModelAsync(request);
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
        public async Task<ActionResult<CreateUser.Response>> CreateCreatorAsnyc(CreateCreator.Request request)
        {
            CreateCreator.Response response = await new CreateCreator(_userManager, _context).DoModelAsync(request);

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
