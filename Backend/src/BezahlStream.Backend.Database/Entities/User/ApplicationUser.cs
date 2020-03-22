using System;
using BezahlStream.Backend.Database.Entities.Profile;
using Microsoft.AspNetCore.Identity;

namespace BezahlStream.Backend.Database.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public CreatorProfile Profile { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
        
        public override bool Equals(object obj){
            return obj is ApplicationUser u && u.Id == this.Id;
        }
    }
}