using LexiconLMS.API.Entities;
using LexiconLMS.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Blazor.Components.Pages;

public partial class Users
{
    [Inject]
    private UserManager<ApplicationUser> UserManager { get; set; } = null!;

    // Used to add or edit currently selected user
    ApplicationUser? UserToEdit = null;
    // Tracks role for the selected user
    LMSRole? UserToEditRole { get; set; } = null;
    // Collection to display existing users
    readonly List<(ApplicationUser, IEnumerable<LMSRole>)> AllUsersWithRoles = [];
    // To hold any errors
    string? ErrorMessage = null;
    // To enable showing the Popup
    bool ShowPopup;

    protected override async Task OnInitializedAsync() =>
        await GetUsers();

    public async Task GetUsers()
    {
        // Clear error messages
        ErrorMessage = null;
        // Clear users
        AllUsersWithRoles.Clear();
        // Get users from UserManager
        foreach (var user in UserManager.Users)
        {
            var roles = (await UserManager.GetRolesAsync(user)).Select(r => Enum.Parse<LMSRole>(r));
            AllUsersWithRoles.Add((user, roles));
        }
    }

    public void OnRoleChanged(LMSRole? role) =>
        UserToEditRole = role;

    public bool IsNewUser =>
        string.IsNullOrWhiteSpace(UserToEdit?.Id);

    void OnAddNewUserClicked()
    {
        // Make new user
        UserToEdit = new ApplicationUser { Id = "" };
        ShowPopup = true;
    }

    void OnEditUserClicked(ApplicationUser userToEdit, IEnumerable<LMSRole> userRoles)
    {
        UserToEdit = userToEdit;
        UserToEditRole = userRoles.FirstOrDefault();
        ShowPopup = true;
    }

    async Task SaveUser()
    {
        try
        {
            // Throw error immediately if a role has not been chosen
            if (UserToEditRole is null)
            {
                throw new Exception("A user role must be selected.");
            }

            // Is this a new user?
            if (IsNewUser)
            {
                // Insert new user
                var newUser = new ApplicationUser
                {
                    Email = UserToEdit?.Email,
                    UserName = UserToEdit?.Email
                };
                var createResult = await UserManager.CreateAsync(newUser);

                if (!createResult.Succeeded)
                {
                    ErrorMessage = createResult.Errors.FirstOrDefault()?.Description
                        ?? "Unknown error when creating user";
                    return;  // Do not close the popup
                }

                // Handle roles
                var addRoleResult = await UserManager.AddToRoleAsync(newUser, (UserToEditRole ?? default).ToString());
                if (!addRoleResult.Succeeded)
                {
                    ErrorMessage = addRoleResult.Errors.FirstOrDefault()?.Description
                        ?? "Unknown error when adding user role";
                    return;
                }
            }
            else
            {
                // Handle roles
                var userRole = (await UserManager.GetRolesAsync(UserToEdit!)).FirstOrDefault() ?? LMSRole.None.ToString();
                if (!userRole.Equals(UserToEditRole))
                {
                    await UserManager.RemoveFromRoleAsync(UserToEdit!, userRole);
                    await UserManager.AddToRoleAsync(UserToEdit!, (UserToEditRole ?? default).ToString());
                }
            }

            // Close the Popup
            ClosePopup();
            // Refresh users
            await GetUsers();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.GetBaseException().Message;
        }
    }

    async Task DeleteUser(ApplicationUser user)
    {
        await UserManager.DeleteAsync(user);
        ClosePopup();
        await GetUsers();
    }

    void ClosePopup()
    {
        ShowPopup = false;
        UserToEdit = null;
        UserToEditRole = null;
        ErrorMessage = null;
    }
}
