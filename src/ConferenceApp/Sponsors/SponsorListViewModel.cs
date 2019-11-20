using DynamicData;
using ReactiveUI;
using Sextant;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace ConferenceApp
{
    public class SponsorListViewModel : NavigationViewModelBase
    {
        private IParameterViewStackService _viewStackService;
        private ObservableCollection<SponsorItemViewModel> _sponsors;

        public SponsorListViewModel(IParameterViewStackService viewStackService)
        {
            _viewStackService = viewStackService;
        }

        public ObservableCollection<SponsorItemViewModel> Sponsors
        {
            get => _sponsors;
            set => this.RaiseAndSetIfChanged(ref _sponsors, value);
        }

        protected override Task ExecuteInitializeData()
        {
            Sponsors = new ObservableCollection<SponsorItemViewModel>
            {
                new SponsorItemViewModel
                {
                    Name = "Coca-Cola"
                },
                new SponsorItemViewModel
                {
                    Name = "Pepsi"
                },
            };

            return Task.CompletedTask;
        }
    }
}