using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI;
using Rocket.Surgery.ReactiveUI.Forms;

namespace ConferenceApp
{
    public abstract class DataPageBase<T> : ContentPageBase<T>
        where T : NavigationViewModelBase
    {
        protected override void RegisterObservers()
        {
            base.RegisterObservers();

            this.WhenAnyValue(x => x.ViewModel.InitializeData)
                .SelectMany(cmd => cmd.Execute())
                .Subscribe()
                .DisposeWith(ViewBindings);
        }
    }
}
