using Microsoft.AspNetCore.Identity;

namespace SiteZnakomstv.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Interests { get; set; } // через запятую
        public string? Info { get; set; }
        public string? AvatarPath { get; set; }
        public DateTime? BirthDate { get; set; }  
        public string? City { get; set; }        
        public string? Gender { get; set; }       
    }

}
