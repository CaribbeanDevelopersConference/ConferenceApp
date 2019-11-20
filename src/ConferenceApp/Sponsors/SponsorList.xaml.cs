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
    public partial class SponsorList : DataPageBase<SponsorListViewModel>
    {
        public SponsorList()
        {
            InitializeComponent();
        }
    }
}
