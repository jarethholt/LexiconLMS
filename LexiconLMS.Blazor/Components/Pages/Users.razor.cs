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
    ApplicationUser ObjUser = new();
    // Tracks role for the selected user
    string ObjUserRole { get; set; } = LMSRole.None.ToString();
    // Collection to display existing users
    readonly List<(ApplicationUser, IList<string>)> AllUsersWithRoles = [];
    // To hold any errors
    string ErrorMessage = "";
    // To enable showing the Popup
    bool ShowPopup;

    protected override async Task OnInitializedAsync() =>
        await GetUsers();

    public async Task GetUsers()
    {
        // Clear error messages
        ErrorMessage = "";
        // Clear users
        AllUsersWithRoles.Clear();
        // Get users from UserManager
        foreach (var user in UserManager.Users)
        {
            var roles = await UserManager.GetRolesAsync(user);
            AllUsersWithRoles.Add((user, roles));
        }
    }

    public void OnRoleChanged(LMSRole role) =>
        ObjUserRole = role.ToString();

    void AddNewUser()
    {
        // Make new user
        ObjUser = new ApplicationUser
        {
            Id = ""
        };
        ShowPopup = true;
    }

    async Task SaveUser()
    {
        try
        {
            // Is this an existing user?
            if (!string.IsNullOrWhiteSpace(ObjUser.Id))
            {
                // Get the user
                var user = await UserManager.FindByIdAsync(ObjUser.Id);
                if (user is null)
                {
                    ErrorMessage = $"Could not find user with ID {ObjUser.Id}";
                    return;
                }
                user.Email = ObjUser.Email;
                await UserManager.UpdateAsync(user);

                // Handle roles
                var userRole = (await UserManager.GetRolesAsync(user)).FirstOrDefault() ?? LMSRole.None.ToString();
                if (!userRole.Equals(ObjUserRole))
                {
                    await UserManager.RemoveFromRoleAsync(user, userRole);
                    await UserManager.AddToRoleAsync(user, ObjUserRole);
                }
                ShowPopup = false;
                await GetUsers();
            }
            else
            {
                // Insert new user
                var newUser = new ApplicationUser
                {
                    Email = ObjUser.Email,
                    UserName = ObjUser.Email
                };
                var createResult = await UserManager.CreateAsync(newUser);

                if (!createResult.Succeeded)
                {
                    ErrorMessage = createResult.Errors.FirstOrDefault()?.Description
                        ?? "Unknown error when creating user";
                    return;  // Do not close the popup
                }
                else
                {
                    // Handle roles
                    var addRoleResult = await UserManager.AddToRoleAsync(newUser, ObjUserRole);
                    if (!addRoleResult.Succeeded)
                    {
                        ErrorMessage = addRoleResult.Errors.FirstOrDefault()?.Description
                            ?? "Unknown error when adding user role";
                        return;
                    }
                }
                // Close the Popup
                ShowPopup = false;
                // Refresh users
                await GetUsers();
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.GetBaseException().Message;
        }
    }

    async Task EditUser(ApplicationUser userToEdit)
    {
        var user = await UserManager.FindByIdAsync(userToEdit.Id);
        if (user is null)
        {
            ErrorMessage = $"An error occurred trying to retrieve the user {userToEdit.Id}";
        }
        else
        {
            ObjUser = userToEdit;
            var userRoles = await UserManager.GetRolesAsync(user);
            ObjUserRole = userRoles?.FirstOrDefault() ?? LMSRole.None.ToString();
        }
        ShowPopup = true;
    }

    async Task DeleteUser(string userId)
    {
        // Close the popup
        ShowPopup = false;
        // Get the user
        var user = await UserManager.FindByIdAsync(userId);
        if (user is not null)
            await UserManager.DeleteAsync(user);
        await GetUsers();
    }

    void ClosePopup() =>
        ShowPopup = false;
}
