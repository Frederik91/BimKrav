using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Client.Components
{
    public class ProjectSelectorBase : ComponentBase
    {
        private Project? _selectedProject;

        [Inject] public IProjectService ProjectService { get; set; } = null!;

        [Parameter]
        public Project? SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (_selectedProject == value)
                    return;
                _selectedProject = value;
                SelectedProjectId = value?.Id;
                UpdateSelectedProject();
            }
        }

        [Parameter]
        public int? SelectedProjectId { get; set; }

        protected List<Project>? AvailableProjects {  get; set; }

        [Parameter]
        public EventCallback<Project?> SelectedProjectChanged { get; set; }

        [Parameter]
        public EventCallback<int?> SelectedProjectIdChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AvailableProjects = await ProjectService.GetProjects();
        }

        protected override void OnParametersSet()
        {
            if (SelectedProject?.Id != SelectedProjectId)
                SelectedProject = AvailableProjects?.FirstOrDefault(x => x.Id == SelectedProjectId);
        }

        protected Task<IEnumerable<Project>> SearchProject(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || AvailableProjects is null)
                return Task.FromResult(AvailableProjects as IEnumerable<Project> ?? new List<Project>());

            var projects = AvailableProjects.Where(x => x.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (projects.Count == 1 && projects.First().Name == searchText && projects.First().Id == SelectedProjectId)
                projects = AvailableProjects;

            return Task.FromResult(projects as IEnumerable<Project>);
        }

        async void UpdateSelectedProject()
        {
            await SelectedProjectChanged.InvokeAsync(SelectedProject);
            await SelectedProjectIdChanged.InvokeAsync(SelectedProject?.Id);
        }

    }
}
