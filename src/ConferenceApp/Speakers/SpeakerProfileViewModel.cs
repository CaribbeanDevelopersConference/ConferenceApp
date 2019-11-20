using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ConferenceApp.Services;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI;
using Sextant;
using Xamarin.Forms;

namespace ConferenceApp
{
    public class SpeakerProfileViewModel : NavigationViewModelBase
    {
        private IParameterViewStackService _viewStackService;
        private readonly ISpeakerService _speakerService;
        private Guid _speakerId;
        private SpeakerDto _speaker;

        public SpeakerProfileViewModel(IParameterViewStackService viewStackService, ISpeakerService speakerService)
        {
            _viewStackService = viewStackService;
            _speakerService = speakerService;

            this.WhenAnyValue(x => x.SpeakerId)
                .Subscribe(id =>
                {
                    Observable
                        .Return(Unit.Default)
                        .SelectMany(async x =>
                        {
                            Speaker = await _speakerService.Get(SpeakerId.ToString());
                            return Unit.Default;
                        })
                        .Subscribe();
                });
        }

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

        public override IObservable<Unit> WhenNavigatingTo(INavigationParameter parameter)
        {
            if (parameter.ContainsKey("Id"))
            {
                SpeakerId = Guid.Parse(parameter["Id"].ToString());
            }

            return base.WhenNavigatingTo(parameter);
        }
    }
}