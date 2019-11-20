using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using ReactiveUI;
using ReactiveUI.XamForms;
using Rocket.Surgery.ReactiveUI;
using Rocket.Surgery.ReactiveUI.Forms;
using Splat;

namespace ConferenceApp
{
    public abstract class DataPageBase<T> : ReactiveContentPage<T>, IEnableLogger
        where T : NavigationViewModelBase
    {
        protected  CompositeDisposable ViewBindings = new CompositeDisposable();

        protected DataPageBase()
        {
            this.WhenAnyValue(x => x.ViewModel.InitializeData)
                .Select(x => Unit.Default)
                .InvokeCommand(this, x => x.ViewModel.InitializeData)
                .DisposeWith(ViewBindings);
        }
    }
}
