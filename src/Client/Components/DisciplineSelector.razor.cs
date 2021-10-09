using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BimKrav.Client.Components
{
    public class DisciplineSelectorBase : ComponentBase
    {
        private string? _selectedDiscipline;

        [Inject] public IDisciplineService DisciplineService { get; set; } = null!;

        [Parameter]
        public string? SelectedDiscipline
        {
            get => _selectedDiscipline;
            set
            {
                if (_selectedDiscipline == value)
                    return;
                _selectedDiscipline = value; UpdateSelectedDiscipline();
            }
        }
        protected List<string>? AvailableDisciplines { get; set; }

        [Parameter]
        public EventCallback<string?> SelectedDisciplineChanged { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var disciplines = await DisciplineService.GetDisciplines();
            AvailableDisciplines = disciplines.Select(x => x.Code).ToList();
        }

        protected Task<IEnumerable<string>> SearchDiscipline(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || AvailableDisciplines is null)
                return Task.FromResult(AvailableDisciplines as IEnumerable<string> ?? new List<string>());
            return Task.FromResult(AvailableDisciplines.Where(x => x?.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) == true));
        }

        async void UpdateSelectedDiscipline()
        {
            await SelectedDisciplineChanged.InvokeAsync(SelectedDiscipline);
        }
    }
}
