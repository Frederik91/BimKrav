using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BimKrav.Components.Services;
using BimKrav.Components.ViewModels;

namespace BimKrav.Components.Controls;

public class PropertyBrowserBase : ComponentBase
{
    private int? _projectId;
    private int? _phaseId;
    private int? _disciplineId;
    private PropertyViewModel? _selectedProperty;

    [Inject] public IPropertyService PropertyService { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IMapper Mapper { get; set; } = null!;

    [Parameter]
    public int? ProjectId
    {
        get => _projectId;
        set { _projectId = value; RefreshParameters(); }
    }

    [Parameter]
    public int? PhaseId
    {
        get => _phaseId;
        set { _phaseId = value; RefreshParameters(); }
    }

    [Parameter]
    public int? DisciplineId
    {
        get => _disciplineId;
        set { _disciplineId = value; RefreshParameters(); }
    }

    public string? PropertySearchText { get; set; }

    protected bool IsLoading { get; set; }


    protected List<PropertyViewModel>? Properties { get; set; }
    protected PropertyViewModel? SelectedProperty
    {
        get => _selectedProperty;
        set { _selectedProperty = value; StateHasChanged(); }
    }

    protected MudMessageBox MessageBox { get; set; } = null!;
    protected PropertyViewModel? ClickedRowItem { get; set; }


    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            RefreshParameters();
        return Task.CompletedTask;
    }

    protected bool Filter(PropertyViewModel? parameter)
    {
        if (parameter is null)
            return false;
        if (string.IsNullOrWhiteSpace(PropertySearchText))
            return true;
        if (parameter.Name.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
            return true;
        if (parameter.PSets.Any(x => x.Name.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase)))
            return true;
        if (parameter.RevitPropertyType.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
            return true;
        if (parameter.Guid?.ToString().Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase) == true)
            return true;
        if (parameter.TypeInstance.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
            return true;
        if (parameter.RevitCategories.Any(x => x.Name.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase)))
            return true;

        return false;
    }

    protected async void RefreshParameters()
    {
        IsLoading = true;
        try
        {
            var properties = await PropertyService.GetProperties(ProjectId, PhaseId, DisciplineId);
            Properties = Mapper.Map<List<PropertyViewModel>>(properties).OrderBy(x => x.PSets.FirstOrDefault()?.Name ?? "None").ToList();
        }
        catch (Exception)
        {
            Snackbar.Add("Failed to get parameters", Severity.Error);
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    public async Task RowClicked(TableRowClickEventArgs<PropertyViewModel> p)
    {
        ClickedRowItem = p.Item;
        _ = await MessageBox.Show();
        StateHasChanged();
    }
}
