using LexiconLMS.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Blazor.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
    }

}
