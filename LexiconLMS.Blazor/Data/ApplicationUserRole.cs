using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Blazor.Data;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser? User { get; set; }
    public virtual ApplicationRole? Role { get; set; }
}
