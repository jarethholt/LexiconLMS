using LexiconLMS.API.Entities;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Blazor.Components.Widgets;

public partial class RoleDropdown : ComponentBase
{
    [Parameter]
    public LMSRole? InitialRole { get; set; } = null;
    [Parameter]
    public EventCallback<LMSRole> OnRoleChanged { get; set; }

    private readonly Dictionary<LMSRole, string> RolesDict = [];

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        var roleNames = Enum.GetNames<LMSRole>();
        var roleValues = (LMSRole[])Enum.GetValuesAsUnderlyingType<LMSRole>();
        var numRoles = roleNames.Length;
        for (int i = 0; i < numRoles; i++)
            RolesDict[roleValues[i]] = roleNames[i];
    }
}
