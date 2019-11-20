using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakerProfile : DataPageBase<SpeakerProfileViewModel>
    {
        public SpeakerProfile()
        {
            InitializeComponent();
        }
    }
}
