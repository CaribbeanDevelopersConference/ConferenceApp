using System;
using ConferenceApp.Speakers;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI.Forms;
using Serilog;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sextant;
using Sextant.XamForms;
using Splat;
using Splat.Serilog;

namespace ConferenceApp
{
    public partial class App : ApplicationBase
    {

        public App()
            : base()
        {
            InitializeComponent();

            Locator
                .Current
                .GetService<IParameterViewStackService>()
                .PushPage(new BottomNavigationViewModel())
                .Subscribe();

            MainPage = Locator.Current.GetNavigationView("NavigationView");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void ComposeApplicationRoot()
        {
            base.ComposeApplicationRoot();

            RxApp.DefaultExceptionHandler = new ConferenceExceptionHandler();

            Sextant.Sextant.Instance.InitializeForms();

            Locator
                .CurrentMutable
                .UseSerilogFullLogger(
                    new LoggerConfiguration()
                        .WriteTo
                        .AppCenterCrashes()
                        .CreateLogger());

            Locator
                .CurrentMutable
                .RegisterView<BottomNavigation, BottomNavigationViewModel>()
                .RegisterView<TabView, TabViewModel>()
                .RegisterView<Agenda, AgendaViewModel>()
                .RegisterView<Schedule, ScheduleViewModel>()
                .RegisterView<SpeakerList, SpeakerListViewModel>()
                .RegisterView<SpeakerDetail, SpeakerDetailViewModel>()
                .RegisterView<SponsorProfile, SponsorProfileViewModel>()
                .RegisterView<SponsorList, SponsorListViewModel>();
        }
    }
}
