using Rocket.Surgery.ReactiveUI;
using Sextant;
using Splat;

namespace ConferenceApp
{
    public abstract class NavigationViewModelBase : ViewModelBase, Sextant.IViewModel
    {
        protected IParameterViewStackService ViewStackService =>
            Locator.Current.GetService<IParameterViewStackService>();
    }
}