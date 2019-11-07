using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Rocket.Surgery.ReactiveUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SponsorViewCell : ViewCellBase<SponsorItemViewModel>
    {
        public SponsorViewCell()
        {
            InitializeComponent();
        }

        protected override void BindControls()
        {
            base.BindControls();

            this.OneWayBind(ViewModel, x => x.Name, x => x.SponsorName.Text)
                .DisposeWith(ViewCellBindings);
        }
    }
}