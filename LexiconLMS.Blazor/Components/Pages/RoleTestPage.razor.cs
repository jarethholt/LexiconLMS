using LexiconLMS.API.Entities;
using LexiconLMS.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Blazor.Components.Pages
{
    public partial class RoleTestPage : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState>? AuthStateTask { get; set; }
        [Inject]
        private RoleManager<ApplicationRole> RoleManager { get; set; } = null!;

        private string AuthMessage = "The user is NOT authenticated.";
        private List<ApplicationRole> AvailableRoles = [];
        private string AvailableRolesString =>
            string.Join(", ", AvailableRoles);
        private List<ApplicationRole> UsersRoles = [];
        private string UsersRolesString =>
            string.Join(", ", UsersRoles);

        protected override async Task OnInitializedAsync()
        {
            AvailableRoles = await RoleManager.Roles.ToListAsync();
            if (AuthStateTask is not null)
            {
                var authState = await AuthStateTask;
                var user = authState?.User;
                foreach (var role in AvailableRoles)
                {
                    if (user is not null && user.IsInRole(role.Name ?? ""))
                        UsersRoles.Add(role);
                }
                if (user is null)
                    AuthMessage = "The user is NOT authenticated.";
                else if (user.IsInRole(LMSRole.Teacher.ToString()) || user.IsInRole(LMSRole.Admin.ToString()))
                    AuthMessage = $"{user.Identity?.Name ?? "The user"} can change other users' roles.";
                else if (user?.Identity is not null && user.Identity.IsAuthenticated)
                    AuthMessage = $"{user.Identity.Name} is authenticated.";
            }
        }
    }
}