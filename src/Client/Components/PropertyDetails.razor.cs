using System;
using BimKrav.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BimKrav.Client.Components;

public class PropertyDetailsBase : ComponentBase
{
    [Parameter]
    public PropertyViewModel? Context { get; set; }

    [CascadingParameter] private MudDialogInstance MudDialog { get; set; } = null!;

    protected void Close() => MudDialog.Close();
}
