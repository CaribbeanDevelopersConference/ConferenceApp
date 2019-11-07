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
        private IEnumerable<SponsorItemViewModel> _sponsors;
        private ReactiveCommand<Unit, Unit> _initializeData;
        private ReadOnlyObservableCollection<SponsorItemViewModel> _sponsorItemViewModels;
        private SourceList<SponsorItemViewModel> _listItems;
        private IObservable<IChangeSet<SponsorItemViewModel>> _sponsorItemViewModelsChangeSet;

        public SponsorListViewModel(IParameterViewStackService viewStackService)
        {
            _viewStackService = viewStackService;

            _listItems = new SourceList<SponsorItemViewModel>();

            _sponsorItemViewModelsChangeSet = _listItems.Connect().Bind(out _sponsorItemViewModels);
        }

        public ReadOnlyObservableCollection<SponsorItemViewModel> SponsorItemViewModels => _sponsorItemViewModels;

        public IEnumerable<SponsorItemViewModel> Sponsors
        {
            get => _sponsors;
            set => this.RaiseAndSetIfChanged(ref _sponsors, value);
        }

        public ReactiveCommand<Unit, Unit> InitializeData
        {
            get => _initializeData;
            set => this.RaiseAndSetIfChanged(ref _initializeData, value);
        }

        protected override void ComposeObservables()
        {
            InitializeData = ReactiveCommand.CreateFromTask(ExecuteInitializeData);
        }

        protected override void RegisterObservers()
        {
        }

        private async Task ExecuteInitializeData()
        {
            Sponsors = new List<SponsorItemViewModel>
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

            _listItems.AddRange(new List<SponsorItemViewModel>
            {
                new SponsorItemViewModel
                {
                    Name = "Coca-Cola"
                },
                new SponsorItemViewModel
                {
                    Name = "Pepsi"
                }
            });

            _sponsorItemViewModelsChangeSet
                .DisposeMany()
                .Subscribe()
                .DisposeWith(Subscriptions);
        }
    }
}