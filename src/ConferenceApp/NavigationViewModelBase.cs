using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI;
using Sextant;
using Splat;

namespace ConferenceApp
{
    public abstract class NavigationViewModelBase : ReactiveObject, INavigable
    {
        private ReactiveCommand<Unit, Unit> _initializeData;
        
        protected CompositeDisposable Subscriptions { get; } = new CompositeDisposable();

        protected IParameterViewStackService ViewStackService =>
            Locator.Current.GetService<IParameterViewStackService>();

        public virtual string Id { get; }

        public ReactiveCommand<Unit, Unit> InitializeData
        {
            get => _initializeData;
            set => this.RaiseAndSetIfChanged(ref _initializeData, value);
        }

        protected NavigationViewModelBase()
        {
            InitializeData = ReactiveCommand.CreateFromTask(async () => await ExecuteInitializeData());
        }

        public virtual IObservable<Unit> WhenNavigatedTo(INavigationParameter parameter) => Observable.Return(Unit.Default);

        public virtual IObservable<Unit> WhenNavigatedFrom(INavigationParameter parameter) => Observable.Return(Unit.Default);

        public virtual IObservable<Unit> WhenNavigatingTo(INavigationParameter parameter) => Observable.Return(Unit.Default);
        
        protected virtual async Task ExecuteInitializeData() => await Task.CompletedTask;
    }
}