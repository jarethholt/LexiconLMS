using System.Globalization;
using LexiconLMS.API.Entities;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Blazor.Data;

public class ApplicationRole : IdentityRole
{
    public UserRole UserRole { get; set; }
    public override string? Name
    {
        get => UserRole.ToString();
        //set
        //{
        //    if (!Enum.TryParse(value, out UserRole userRole))
        //        throw new InvalidOperationException($"The provided value {value} is not a valid {nameof(UserRole)}");
        //    if (!Enum.IsDefined(userRole))
        //        throw new InvalidOperationException($"The provided value {value} is not a valid {nameof(UserRole)}");
        //    UserRole = userRole;
        //}
    }
    public override string? NormalizedName
    {
        get => UserRole.ToString().ToUpperInvariant();
        //set
        //{
        //    if (value is null)
        //        throw new InvalidOperationException($"The provided value {value} is not a valid {nameof(UserRole)}");
        //    var normVal = CultureInfo.InvariantCulture.TextInfo
        //        .ToTitleCase(value.ToLowerInvariant());
        //    if (!Enum.TryParse(normVal, out UserRole userRole))
        //        throw new InvalidOperationException($"The provided value {value} is not a valid {nameof(UserRole)}");
        //    if (!Enum.IsDefined(userRole))
        //        throw new InvalidOperationException($"The provided value {value} is not a valid {nameof(UserRole)}");
        //    UserRole = userRole;
        //}
    }

    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
}
