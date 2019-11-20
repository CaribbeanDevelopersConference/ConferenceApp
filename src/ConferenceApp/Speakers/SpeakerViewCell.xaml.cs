using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using Rocket.Surgery.ReactiveUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp.Speakers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakerViewCell : ReactiveContentView<SpeakerItemViewModel>
    {
        protected CompositeDisposable ViewCellBindings = new CompositeDisposable();

        public SpeakerViewCell()
        {
            InitializeComponent();

            this.OneWayBind(ViewModel, x => x.Name, x => x.Name.Text).DisposeWith(ViewCellBindings);

            this.OneWayBind(ViewModel, x => x.Title, x => x.Title.Text).DisposeWith(ViewCellBindings);

            this.OneWayBind(ViewModel, x => x.Company, x => x.Company.Text).DisposeWith(ViewCellBindings);

            this.OneWayBind(ViewModel, x => x.ImageSource, x => x.SpeakerImage.Source).DisposeWith(ViewCellBindings);
        }
    }
}