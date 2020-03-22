using BezahlStream.Backend.Database.Entities.Profile;
using BezahlStream.Backend.Database.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BezahlStream.Backend.Database
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<CreatorProfile> CreatorProfiles 
        {
            get;
            set;
        }
    }
}
