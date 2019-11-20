using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI;
using Sextant;
using Xamarin.Forms;

namespace ConferenceApp
{

    public class TabViewModel : NavigationViewModelBase
    {
        private readonly Func<NavigationViewModelBase> _pageCreate;

        public string TabTitle { get; }

        public FileImageSource TabIcon { get; }

        public NavigationViewModelBase ViewModel { get; private set; }

        public TabViewModel(string tabTitle, string tabIcon, IParameterViewStackService stackService, Func<NavigationViewModelBase> pageCreate)
        {
            _pageCreate = pageCreate;
            TabIcon = tabIcon;
            TabTitle = tabTitle;
            ViewModel = _pageCreate();
        }
    }
}
