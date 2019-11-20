using Rocket.Surgery.ReactiveUI;
using Sextant;
using Splat;
using Xamarin.Essentials;

namespace ConferenceApp
{
    public class AgendaViewModel : NavigationViewModelBase
    {
        private readonly IParameterViewStackService _viewStackService;

        public AgendaViewModel(IParameterViewStackService viewStackService)
        {
            _viewStackService = viewStackService;
        }
    }
}