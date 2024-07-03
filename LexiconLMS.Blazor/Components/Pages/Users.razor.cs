using LexiconLMS.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Blazor.Components.Pages;

public partial class Users
{
    [Inject]
    private UserManager<ApplicationUser> UserManager { get; set; } = null!;

    // Used to add or edit currently selected user
    ApplicationUser ObjUser = new();
    // Tracks role for the selected user
    string ObjUserRole { get; set; } = "None";
    // Collection to display existing users
    List<(ApplicationUser, IList<string>)> AllUsersWithRoles = [];
    // Options to display in the roles dropdown when editing a user
    List<string> RoleOptions = [];
    // To hold any errors
    string ErrorMessage = "";
    // To enable showing the Popup
    bool ShowPopup;

    protected override async Task OnInitializedAsync()
    {
        await GetUsers();
    }

    public async Task GetUsers()
    {
        // Clear error messages
        ErrorMessage = "";

        // Get users from UserManager
        foreach (var user in UserManager.Users)
        {
            var roles = await UserManager.GetRolesAsync(user);
            AllUsersWithRoles.Add((user, roles));
        }
    }

    void AddNewUser()
    {

    }

    async Task SaveUser()
    {

    }

    async Task EditUser(ApplicationUser user)
    {

    }

    async Task DeleteUser()
    {

    }

    void ClosePopup() =>
        ShowPopup = false;
}
