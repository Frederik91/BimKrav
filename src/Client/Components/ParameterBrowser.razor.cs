using BimKrav.Client.Services;
using BimKrav.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BimKrav.Client.Components
{
    public class ParameterBrowserBase : ComponentBase
    {
        private string? _project;
        private string? _phase;
        private string? _discipline;
        private Parameter? _selectedParameter;

        [Inject] public IParameterService ParameterService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;

        [Parameter]
        public string? Project
        {
            get => _project;
            set { _project = value; RefreshParameters(); }
        }

        [Parameter]
        public string? Phase
        {
            get => _phase;
            set { _phase = value; RefreshParameters(); }
        }

        [Parameter]
        public string? Discipline
        {
            get => _discipline;
            set { _discipline = value; RefreshParameters(); }
        }

        public string? ParameterSearchText { get; set; }

        protected bool IsLoading { get; set; }

        protected List<Parameter>? Parameters { get; set; }
        protected Parameter? SelectedParameter
        {
            get => _selectedParameter;
            set { _selectedParameter = value; StateHasChanged(); }
        }

        protected bool Filter(Parameter parameter)
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
            if (string.IsNullOrEmpty(Project) || string.IsNullOrEmpty(Phase))
            {
                Parameters = null;
                return;
            }
            IsLoading = true;
            try
            {
                Parameters = await ParameterService.GetParameters(Project, Phase, Discipline);
            }
            catch (AccessTokenNotAvailableException accessException)
            {
                accessException.Redirect();
            }
            catch (Exception e)
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
