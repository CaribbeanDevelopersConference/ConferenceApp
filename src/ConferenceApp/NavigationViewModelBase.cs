using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI;
using Sextant;
using Splat;

namespace ConferenceApp
{
    public abstract class NavigationViewModelBase : ViewModelBase, Sextant.IViewModel
    {
        private ReactiveCommand<Unit, Unit> _initializeData;

        protected IParameterViewStackService ViewStackService =>
            Locator.Current.GetService<IParameterViewStackService>();

        public ReactiveCommand<Unit, Unit> InitializeData
        {
            get => _initializeData;
            set => this.RaiseAndSetIfChanged(ref _initializeData, value);
        }

        protected NavigationViewModelBase()
        {
            InitializeData = ReactiveCommand.CreateFromTask(async () => await ExecuteInitializeData());
        }

        protected virtual async Task ExecuteInitializeData() => await Task.CompletedTask;
    }
}