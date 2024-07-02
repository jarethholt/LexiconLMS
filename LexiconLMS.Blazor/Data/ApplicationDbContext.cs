using LexiconLMS.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Blazor.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        string,
        IdentityUserClaim<string>,
        ApplicationUserRole,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>
    >(options)
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var adminUser = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin@admin.org",
            NormalizedUserName = "ADMIN@ADMIN.ORG",
            Email = "admin@admin.org",
            NormalizedEmail = "ADMIN@ADMIN.ORG",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        var hasher = new PasswordHasher<ApplicationUser>();
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin");

        builder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many entries in the UserRole join table
            b.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            b.HasData(adminUser);
        });
        //builder.Entity<ApplicationUser>().HasData(adminUser);

        Dictionary<LMSRole, ApplicationRole> roleDict = [];
        foreach (var role in Enum.GetValues<LMSRole>())
        {
            roleDict[role] = new ApplicationRole
            {
                UserRole = role,
                Name = role.ToString(),
                NormalizedName = role.ToString().ToUpperInvariant(),
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
        }

        builder.Entity<ApplicationRole>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            b.HasData([.. roleDict.Values]);
        });
        //builder.Entity<ApplicationRole>().HasData([.. roleDict.Values]);

        ApplicationUserRole appUserRole = new()
        {
            UserId = adminUser.Id,
            RoleId = roleDict[LMSRole.Admin].Id
        };
        builder.Entity<ApplicationUserRole>().HasData(appUserRole);
    }
}
