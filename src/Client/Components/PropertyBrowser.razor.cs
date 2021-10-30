using BimKrav.Client.Services;
using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BimKrav.Client.Components
{
    public class PropertyBrowserBase : ComponentBase
    {
        private int? _projectId;
        private int? _phaseId;
        private int? _disciplineId;
        private Property? _selectedProperty;

        [Inject] public IPropertyService PropertyService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

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

        protected List<Property>? Properties { get; set; }
        protected Property? SelectedProperty
        {
            get => _selectedProperty;
            set { _selectedProperty = value; StateHasChanged(); }
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                RefreshParameters();
            return Task.CompletedTask;
        }

        protected bool Filter(Property parameter)
        {
            if (string.IsNullOrWhiteSpace(PropertySearchText))
                return true;
            if (parameter.PropertyName.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.RevitPropertyType.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.PropertyGUID.ToString().Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.Level.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.Categories.Any(x => x.Contains(PropertySearchText, StringComparison.InvariantCultureIgnoreCase)))
                return true;

            return false;
        }

        protected async void RefreshParameters()
        {
            IsLoading = true;
            try
            {
                Properties = await PropertyService.GetProperties(ProjectId, PhaseId, DisciplineId);
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
    }
}
