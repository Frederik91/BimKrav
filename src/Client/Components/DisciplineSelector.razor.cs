using BimKrav.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BimKrav.Shared.Models;

namespace BimKrav.Client.Components
{
    public class DisciplineSelectorBase : ComponentBase
    {
        private Discipline? _selectedDiscipline;

        [Inject] public IDisciplineService DisciplineService { get; set; } = null!;

        [Parameter]
        public Discipline? SelectedDiscipline
        {
            get => _selectedDiscipline;
            set
            {
                if (_selectedDiscipline == value)
                    return;
                _selectedDiscipline = value; UpdateSelectedDiscipline();
            }
        }

        [Parameter]
        public int? SelectedDisciplineId { get; set; }

        protected List<Discipline>? AvailableDisciplines { get; set; }

        [Parameter]
        public EventCallback<Discipline?> SelectedDisciplineChanged { get; set; }

        [Parameter]
        public EventCallback<int?> SelectedDisciplineIdChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AvailableDisciplines = await DisciplineService.GetDisciplines();
        }

        protected override void OnParametersSet()
        {
            SelectedDiscipline = AvailableDisciplines?.FirstOrDefault(x => x.Id == SelectedDisciplineId);
        }

        protected Task<IEnumerable<Discipline>> SearchDiscipline(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || AvailableDisciplines is null)
                return Task.FromResult(AvailableDisciplines as IEnumerable<Discipline> ?? new List<Discipline>());

            var disciplines = AvailableDisciplines.Where(x => x.Name?.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) == true).ToList();
            if (disciplines.Count == 1 && disciplines.First().Name == searchText && disciplines.First().Id == SelectedDisciplineId)
                disciplines = AvailableDisciplines;

            return Task.FromResult(disciplines as IEnumerable<Discipline>);
        }

        async void UpdateSelectedDiscipline()
        {
            await SelectedDisciplineChanged.InvokeAsync(SelectedDiscipline);
            await SelectedDisciplineIdChanged.InvokeAsync(SelectedDiscipline?.Id);
        }
    }
}
