using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using Rocket.Surgery.ReactiveUI;
using Sextant;
using Sextant.XamForms;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavigation : ReactiveTabbedPage<BottomNavigationViewModel>
    {
        public BottomNavigation()
        {
            InitializeComponent();

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            NavigationPage.SetHasNavigationBar(this, false);

            this.WhenActivated(disposables => { ViewModel.TabViewModels.ForEach(x => Children.Add(CreateTab(x))); });
        }

        private Page CreateTab(Func<IParameterViewStackService, TabViewModel> viewModelFunc)
        {
            var bgScheduler = RxApp.TaskpoolScheduler;
            var mScheduler = RxApp.MainThreadScheduler;
            var vLocator = Locator.Current.GetService<IViewLocator>();

            var navigationView = new NavigationView(mScheduler, bgScheduler, vLocator);
            var viewStackService = new ParameterViewStackService(navigationView);
            var model = viewModelFunc(viewStackService);

            navigationView.Title = model.TabTitle;
            navigationView.Icon = model.TabIcon;

            navigationView.PushPage(model.ViewModel as NavigationViewModelBase, null, true, false).Subscribe();
            return navigationView;
        }
    }
}