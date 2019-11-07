using ReactiveUI;
using Rocket.Surgery.ReactiveUI;

namespace ConferenceApp
{
    public class SponsorItemViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        protected override void ComposeObservables()
        {
        }

        protected override void RegisterObservers()
        {
        }
    }
}