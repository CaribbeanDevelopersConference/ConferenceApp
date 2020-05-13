using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakerDetail : ContentPageBase<SpeakerDetailViewModel>
    {
        public SpeakerDetail()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, x => x.ImageSource, x => x.SpeakerImage.Source)
                .DisposeWith(ViewBindings);

            this.WhenAnyValue(x => x.ViewModel.SpeakerId)
                .WhereNotNull()
                .Where(x => x != Guid.Empty)
                .InvokeCommand(this, x => x.ViewModel.GetSpeaker)
                .DisposeWith(ViewBindings);
        }
    }
}