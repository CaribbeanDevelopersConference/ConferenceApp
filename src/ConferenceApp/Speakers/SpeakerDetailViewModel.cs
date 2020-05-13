using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ConferenceApp.Services;
using ReactiveUI;
using Sextant;
using Xamarin.Forms;

namespace ConferenceApp
{
    public class SpeakerDetailViewModel : NavigationViewModelBase
    {
        private IParameterViewStackService _viewStackService;
        private readonly ISpeakerService _speakerService;
        private Guid _speakerId;
        private SpeakerDto _speaker;
        private ImageSource _imageSource;
        private string _name;
        private string _biography;

        public SpeakerDetailViewModel(IParameterViewStackService viewStackService, ISpeakerService speakerService)
        {
            _viewStackService = viewStackService;
            _speakerService = speakerService;

            this.WhenAnyValue(x => x.Speaker)
                .WhereNotNull()
                .Subscribe(x => ImageSource = ImageSource.FromUri(x.ProfilePicture));

            GetSpeaker = ReactiveCommand.CreateFromTask<Guid>(ExecuteGetSpeaker);
        }

        public ReactiveCommand<Guid, Unit> GetSpeaker { get; set; }

        public SpeakerDto Speaker
        {
            get => _speaker;
            set => this.RaiseAndSetIfChanged(ref _speaker, value);
        }

        public Guid SpeakerId
        {
            get => _speakerId;
            set => this.RaiseAndSetIfChanged(ref _speakerId, value);
        }

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => this.RaiseAndSetIfChanged(ref _imageSource, value);
        }

        public override IObservable<Unit> WhenNavigatingTo(INavigationParameter parameter)
        {
            if (parameter.ContainsKey("Id"))
            {
                SpeakerId = Guid.Parse(parameter["Id"].ToString());
            }

            return base.WhenNavigatingTo(parameter);
        }
    
        private async Task ExecuteGetSpeaker(Guid speakerId)
        {
            Speaker = await _speakerService.Get(speakerId.ToString());
        }
    }
}