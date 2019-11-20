using System;
using System.Collections.Generic;
using ConferenceApp.Services.Speakers;
using ConferenceApp.Speakers;
using ReactiveUI;
using Sextant;

namespace ConferenceApp
{
    public class BottomNavigationViewModel : NavigationViewModelBase
    {
        private List<Func<IParameterViewStackService, TabViewModel>> _tabViewModels;

        public BottomNavigationViewModel()
        {
            TabViewModels = new List<Func<IParameterViewStackService, TabViewModel>>
            {
                service => new TabViewModel("Agenda", "", service, () => new AgendaViewModel(service)),
                service => new TabViewModel("Speakers", "", service, () => new SpeakerListViewModel(service, new SpeakerServiceMock())),
                service => new TabViewModel("Schedule", "", service, () => new ScheduleViewModel(service)),
                service => new TabViewModel("Sponsors", "", service, () => new SponsorListViewModel(service))
            };
        }

        public List<Func<IParameterViewStackService, TabViewModel>> TabViewModels
        {
            get => _tabViewModels;
            set => this.RaiseAndSetIfChanged(ref _tabViewModels, value);
        }
    }
}