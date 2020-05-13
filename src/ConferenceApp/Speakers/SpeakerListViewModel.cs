using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ConferenceApp.Services;
using ConferenceApp.Services.Speakers;
using DynamicData;
using ReactiveUI;
using Sextant;
using Xamarin.Forms;

namespace ConferenceApp.Speakers
{
    public class SpeakerListViewModel : NavigationViewModelBase
    {
        private readonly IParameterViewStackService _viewStackService;
        private readonly ISpeakerService _speakerService;
        private ObservableCollection<SpeakerItemViewModel> _speakers;
        private ObservableAsPropertyHelper<bool> _isRefreshing;
        private ReactiveCommand<Unit, Unit> _refresh;
        private ReactiveCommand<SpeakerItemViewModel, Unit> _itemTapped;

        public SpeakerListViewModel(IParameterViewStackService viewStackService, ISpeakerService speakerService)
        {
            _viewStackService = viewStackService;
            _speakerService = speakerService;
            
            Refresh = ReactiveCommand.CreateFromTask(ExecuteRefresh);
            ItemTapped = ReactiveCommand.Create<SpeakerItemViewModel, Unit>(item =>
            {
                var profile = new SpeakerDetailViewModel(_viewStackService, new SpeakerServiceMock());
                _viewStackService.PushPage(profile, new NavigationParameter { { "Id", item.SpeakerId.ToString() } }).Subscribe();
                return Unit.Default;
            });
            
            _isRefreshing =
                this.WhenAnyObservable(x => x.Refresh.IsExecuting)
                    .ToProperty(this, x => x.IsRefreshing)
                    .DisposeWith(Subscriptions);
        }

        public ReactiveCommand<Unit, Unit> Refresh
        {
            get => _refresh;
            set => this.RaiseAndSetIfChanged(ref _refresh, value);
        }

        public ObservableCollection<SpeakerItemViewModel> Speakers
        {
            get => _speakers;
            set => this.RaiseAndSetIfChanged(ref _speakers, value);
        }

        public ReactiveCommand<SpeakerItemViewModel, Unit> ItemTapped
        {
            get => _itemTapped;
            set => this.RaiseAndSetIfChanged(ref _itemTapped, value);
        }

        public bool IsRefreshing => _isRefreshing?.Value ?? false;

        protected override async Task ExecuteInitializeData()
        {
            await base.ExecuteInitializeData();

            var speakers = await _speakerService.GetAll();
            
            Speakers = new ObservableCollection<SpeakerItemViewModel>(speakers.Select(x => new SpeakerItemViewModel
            {
                SpeakerId = x.Id,
                Name =  x.FullName,
                Title =  x.Title,
                Company = x.Company,
                ImageSource = ImageSource.FromUri(x.ProfilePicture)
            }));
        }

        private async Task ExecuteRefresh()
        {
            var speakers = await _speakerService.GetAll();
            
            Speakers = new ObservableCollection<SpeakerItemViewModel>(speakers.Select(x => new SpeakerItemViewModel
            {
                Name =  x.FullName,
                Title =  x.Title,
                Company = x.Company,
                ImageSource = ImageSource.FromUri(x.ProfilePicture)
            }));
        }
    }
}