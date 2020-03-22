using System.Collections.Generic;
using System.Linq;
using BezahlStream.Backend.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BezahlStream.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private AppDbContext ctx;
        public TestController(AppDbContext ctx){
            this.ctx = ctx;
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Get(int id)
        {
            return this.Get().ToList()[id];
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
                "Test",
                "Test2"
            };
        }
    }
}