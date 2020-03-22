using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BezahlStream.Backend.Database;
using BezahlStream.Backend.Database.Entities.Profile;
using BezahlStream.Backend.Database.Entities.User;
using Localization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BezahlStream.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IStringLocalizer<ApiErrorMessages> errorMessagelocalizer;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext ctx;
        public ProfilesController(AppDbContext ctx, UserManager<ApplicationUser> userManager,  IStringLocalizer<ApiErrorMessages> errorMessagelocalizer)
        {
            this.ctx = ctx;
            this.userManager = userManager;
            this.errorMessagelocalizer = errorMessagelocalizer;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreatorProfile>> Get(string id)
        {
            var profile = await this.ctx.CreatorProfiles.FindAsync(id);
            if(profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<CreatorProfile>> Get()
        {
            return Ok(this.ctx.CreatorProfiles.AsQueryable());
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Profile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreatorProfile>> Post(CreatorProfile profile)
        {
            profile.Owner = await this.userManager.GetUserAsync(User);
            profile.Id = null;
            if(profile.Owner.Profile != null)
            {
                throw new InvalidOperationException(this.errorMessagelocalizer["You can't create two Profiles!"]);
            }

            profile.Owner.Profile = profile;
            this.ctx.Users.Update(profile.Owner);
            await this.ctx.CreatorProfiles.AddAsync(profile);
            await this.ctx.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {
                id = profile.Id
            }, profile);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Profile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(string id, CreatorProfile profile)
        {
            var dbProfile = this.ctx.CreatorProfiles.FirstOrDefault(p => p.Id == id);
            if(!dbProfile?.CanEdit(await this.userManager.GetUserAsync(User)) ?? true)
            {
                throw new InvalidOperationException(this.errorMessagelocalizer["You can't edit the profile {0}!", id]);
            }

            profile.Id = id;
            this.ctx.CreatorProfiles.Update(profile);
            await this.ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            this.ctx.CreatorProfiles.Remove(await this.ctx.CreatorProfiles.FindAsync(id));
            await this.ctx.SaveChangesAsync();
            return NoContent();    
        }
    }
}