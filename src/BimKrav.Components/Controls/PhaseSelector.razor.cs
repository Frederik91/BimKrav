using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BimKrav.Components.Services;

namespace BimKrav.Components.Controls;

public class PhaseSelectorBase : ComponentBase
{
    private Shared.Models.Phase? _selectedPhase;

    [Inject] public IPhaseService PhaseService { get; set; } = null!;

    [Parameter]
    public Shared.Models.Phase? SelectedPhase
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

    protected List<Shared.Models.Phase>? AvailablePhases { get; set; }

    [Parameter]
    public EventCallback<Shared.Models.Phase> SelectedPhaseChanged { get; set; }

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

    protected Task<IEnumerable<Shared.Models.Phase>> SearchPhase(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText) || AvailablePhases is null)
            return Task.FromResult(AvailablePhases as IEnumerable<Shared.Models.Phase> ?? new List<Shared.Models.Phase>());

        var phases = AvailablePhases.Where(x => x.Name.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
        if (phases.Count == 1 && phases.First().Name == searchText && phases.First().Id == SelectedPhaseId)
            phases = AvailablePhases;

        return Task.FromResult(phases as IEnumerable<Shared.Models.Phase>);
    }

    async void UpdateSelectedPhase()
    {
        await SelectedPhaseChanged.InvokeAsync(SelectedPhase);
        await SelectedPhaseIdChanged.InvokeAsync(SelectedPhase?.Id);
    }
}
