using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace BimKrav.Client.Components
{
    public class ProjectSelectorBase : ComponentBase
    {
        private string? _selectedProject;

        [Inject] public IProjectService ProjectService { get; set; } = null!;
        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public ILogger<ProjectSelector> Logger { get; set; } = null!;

        [Parameter]
        public string? SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (_selectedProject == value)
                    return;
                _selectedProject = value; UpdateSelectedProject();
            }
        }
        protected List<string>? AvailableProjects {  get; set; }

        [Parameter]
        public EventCallback<string?> SelectedProjectChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                var projects = await ProjectService.GetProjects();
                AvailableProjects = projects.Select(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to load projects", e);
                Snackbar.Add("Failed to load projects", Severity.Error);
            }
        }

        protected Task<IEnumerable<string>> SearchProject(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || AvailableProjects is null)
                return Task.FromResult(AvailableProjects as IEnumerable<string> ?? new List<string>());
            return Task.FromResult(AvailableProjects.Where(x => x?.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) == true));
        }

        async void UpdateSelectedProject()
        {
            await SelectedProjectChanged.InvokeAsync(SelectedProject);
        }

    }
}
