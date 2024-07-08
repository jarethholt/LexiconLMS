using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Blazor.Components.Widgets;

public partial class GenericDropdown<TValue> : ComponentBase where TValue : struct
{
    [Parameter]
    public required string ForName { get; set; }
    [Parameter]
    public string LabelText { get; set; } = string.Empty;
    [Parameter]
    public string DisplayName { get; set; } = string.Empty;
    [Parameter]
    public string DefaultLabel { get; set; } = string.Empty;
    [Parameter]
    public TValue? InitialValue { get; set; } = null;
    [Parameter]
    public Dictionary<TValue, string> ValuesDict { get; set; } = [];
    [Parameter]
    public EventCallback<TValue> OnValueChanged { get; set; }

    private TValue _selectedValue;
    public TValue SelectedValue
    {
        get => _selectedValue;
        set
        {
            _selectedValue = value;
            OnValueChanged.InvokeAsync(value);
        }
    }

    protected override void OnInitialized()
    {
        _selectedValue = (InitialValue is null) ? default : (TValue)InitialValue;
    }
}
