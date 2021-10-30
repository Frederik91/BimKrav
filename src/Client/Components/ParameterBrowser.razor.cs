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
    public class ParameterBrowserBase : ComponentBase
    {
        private int? _projectId;
        private int? _phaseId;
        private int? _disciplineId;
        private Property? _selectedParameter;

        [Inject] public IParameterService ParameterService { get; set; } = null!;
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

        public string? ParameterSearchText { get; set; }

        protected bool IsLoading { get; set; }

        protected List<Property>? Parameters { get; set; }
        protected Property? SelectedParameter
        {
            get => _selectedParameter;
            set { _selectedParameter = value; StateHasChanged(); }
        }

        protected bool Filter(Property parameter)
        {
            if (string.IsNullOrWhiteSpace(ParameterSearchText))
                return true;
            if (parameter.PropertyName.Contains(ParameterSearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.RevitPropertyType.Contains(ParameterSearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.PropertyGUID.ToString().Contains(ParameterSearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.Level.Contains(ParameterSearchText, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (parameter.Categories.Any(x => x.Contains(ParameterSearchText, StringComparison.InvariantCultureIgnoreCase)))
                return true;

            return false;
        }

        protected async void RefreshParameters()
        {
            if (ProjectId is null || PhaseId is null)
            {
                Parameters = null;
                return;
            }
            IsLoading = true;
            try
            {
                Parameters = await ParameterService.GetParameters(ProjectId.Value, PhaseId.Value, DisciplineId);               
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
