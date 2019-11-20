using Rocket.Surgery.ReactiveUI;
using Sextant;

namespace ConferenceApp
{
    public class ScheduleViewModel : NavigationViewModelBase
    {
        private IParameterViewStackService _viewStackService;

        public ScheduleViewModel(IParameterViewStackService viewStackService)
        {
            _viewStackService = viewStackService;
        }
    }
}