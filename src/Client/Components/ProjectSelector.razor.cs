using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BimKrav.Client.Components
{
    public class ProjectSelectorBase : ComponentBase
    {
        private string? _selectedProject;

        [Inject] public IProjectService ProjectService { get; set; } = null!;

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
            var projects = await ProjectService.GetProjects();
            AvailableProjects = projects.Select(x => x.Name).ToList();
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
