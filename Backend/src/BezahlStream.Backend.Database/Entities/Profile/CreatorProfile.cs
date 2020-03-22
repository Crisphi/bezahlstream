using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BezahlStream.Backend.Database.Entities.User;

namespace BezahlStream.Backend.Database.Entities.Profile
{
    public class CreatorProfile
    {
        [Key]
        public string Id{ get; set; }
        
        public string OwnerId{ get; set; }
        public ApplicationUser Owner 
        {
            get;
            set;
        }

        public bool CanEdit(ApplicationUser user)
        {
            return this.Owner == user;
        }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}