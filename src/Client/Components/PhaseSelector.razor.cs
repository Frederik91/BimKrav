using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Client.Components
{
    public class PhaseSelectorBase : ComponentBase
    {
        private Phase? _selectedPhase;

        [Inject] public IPhaseService PhaseService { get; set; } = null!;

        [Parameter]
        public Phase? SelectedPhase
        {
            get => _selectedPhase;
            set
            {
                if (_selectedPhase == value)
                    return;
                _selectedPhase = value; 
                SelectedPhaseId = value?.Id;
                UpdateSelectedPhase();
            }
        }

        [Parameter]
        public int? SelectedPhaseId { get; set; }

        protected List<Phase>? AvailablePhases { get; set; }

        [Parameter]
        public EventCallback<Phase?> SelectedPhaseChanged { get; set; }

        [Parameter]
        public EventCallback<int?> SelectedPhaseIdChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AvailablePhases = await PhaseService.GetPhases();
        }

        protected override void OnParametersSet()
        {
            SelectedPhase = AvailablePhases?.FirstOrDefault(x => x.Id == SelectedPhaseId);
        }

        protected Task<IEnumerable<Phase>> SearchPhase(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || AvailablePhases is null)
                return Task.FromResult(AvailablePhases as IEnumerable<Phase> ?? new List<Phase>());
            return Task.FromResult(AvailablePhases.Where(x => x.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) == true));
        }

        async void UpdateSelectedPhase()
        {
            await SelectedPhaseChanged.InvokeAsync(SelectedPhase);
            await SelectedPhaseIdChanged.InvokeAsync(SelectedPhase?.Id);
        }
    }
}
