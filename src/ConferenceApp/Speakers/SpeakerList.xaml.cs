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

namespace ConferenceApp.Speakers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakerList : DataPageBase<SpeakerListViewModel>
    {
        public SpeakerList()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, x => x.Speakers, x => x.SpeakersListView.ItemsSource)
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.IsRefreshing, x => x.SpeakersListView.IsRefreshing)
                .DisposeWith(ViewBindings);

            SpeakersListView
                .Events()
                .Refreshing
                .WhereNotNull()
                .ToSignal()
                .InvokeCommand(this, x => x.ViewModel.Refresh)
                .DisposeWith(ViewBindings);

            SpeakersListView
                .Events()
                .ItemTapped
                .Select(x => x.Item as SpeakerItemViewModel)
                .WhereNotNull()
                .InvokeCommand(this, x => x.ViewModel.ItemTapped)
                .DisposeWith(ViewBindings);
        }
    }
}