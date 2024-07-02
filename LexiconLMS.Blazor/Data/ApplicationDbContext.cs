using LexiconLMS.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Blazor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var roleName in Enum.GetNames<UserRole>())
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpperInvariant(),
                    Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
        }
    }
}
