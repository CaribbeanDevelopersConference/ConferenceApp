using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI.Forms;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SponsorList : ContentPageBase<SponsorListViewModel>, IEnableLogger
    {
        public SponsorList()
        {
            InitializeComponent();
        }

        protected override void BindControls()
        {
            base.BindControls();

            //this.OneWayBind(ViewModel, x => x.Sponsors, x => x.SponsorsListView.ItemsSource)
            //    .DisposeWith(ViewBindings);
        }

        protected override void RegisterObservers()
        {
            base.RegisterObservers();

            this.WhenAnyValue(x => x.ViewModel.SponsorItemViewModels)
                .WhereNotNull()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Do(_ => this.Log().Info($"{nameof(SponsorItemViewModel)} list count: {_.Count}"))
                .Subscribe(items =>
                {
                    if (SponsorsListView == null)
                    {
                        return;
                    }

                    //SponsorsListView.ItemTemplate = new DataTemplate(typeof(SponsorViewCell));
                    SponsorsListView.ItemsSource = items;
                })
                .DisposeWith(ViewBindings);

            this.WhenAnyValue(x => x.ViewModel.InitializeData)
                .Select(x => Unit.Default)
                .InvokeCommand(this, x => x.ViewModel.InitializeData)
                .DisposeWith(ViewBindings);
        }
    }
}
