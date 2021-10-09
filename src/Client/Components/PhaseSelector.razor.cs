using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BimKrav.Client.Components
{
    public class PhaseSelectorBase : ComponentBase
    {
        private string? _selectedPhase;

        [Inject] public IPhaseService PhaseService { get; set; } = null!;

        [Parameter]
        public string? SelectedPhase
        {
            get => _selectedPhase;
            set
            {
                if (_selectedPhase == value)
                    return;
                _selectedPhase = value; UpdateSelectedPhase();
            }
        }
        protected List<string>? AvailablePhases { get; set; }

        [Parameter]
        public EventCallback<string?> SelectedPhaseChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            AvailablePhases = await PhaseService.GetPhases();
        }

        protected Task<IEnumerable<string>> SearchPhase(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || AvailablePhases is null)
                return Task.FromResult(AvailablePhases as IEnumerable<string> ?? new List<string>());
            return Task.FromResult(AvailablePhases.Where(x => x?.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) == true));
        }

        async void UpdateSelectedPhase()
        {
            await SelectedPhaseChanged.InvokeAsync(SelectedPhase);
        }
    }
}
