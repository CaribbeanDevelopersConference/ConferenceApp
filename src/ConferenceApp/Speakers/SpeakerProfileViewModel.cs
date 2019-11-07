using Rocket.Surgery.ReactiveUI;
using Sextant;

namespace ConferenceApp
{
    public class SpeakerProfileViewModel : NavigationViewModelBase
    {
        private IParameterViewStackService _viewStackService;

        public SpeakerProfileViewModel(IParameterViewStackService viewStackService)
        {
            _viewStackService = viewStackService;
        }

        protected override void ComposeObservables()
        {
        }

        protected override void RegisterObservers()
        {
        }
    }
}