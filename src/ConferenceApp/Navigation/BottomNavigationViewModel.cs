using System;
using System.Collections.Generic;
using ReactiveUI;
using Sextant;

namespace ConferenceApp
{
    public class BottomNavigationViewModel : NavigationViewModelBase
    {
        private List<Func<IParameterViewStackService, TabViewModel>> _tabViewModels;

        protected override void ComposeObservables()
        {
            TabViewModels = new List<Func<IParameterViewStackService, TabViewModel>>
            {
                service => new TabViewModel("Agenda", "", service, () => new AgendaViewModel(service)),
                service => new TabViewModel("Sponsors", "", service, () => new SponsorListViewModel(service)),
                service => new TabViewModel("Schedule", "", service, () => new ScheduleViewModel(service))
            };
        }

        public List<Func<IParameterViewStackService, TabViewModel>> TabViewModels
        {
            get => _tabViewModels;
            set => this.RaiseAndSetIfChanged(ref _tabViewModels, value);
        }

        protected override void RegisterObservers()
        {
        }
    }
}