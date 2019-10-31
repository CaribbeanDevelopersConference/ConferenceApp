using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Surgery.ReactiveUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Schedule : DataPageBase<ScheduleViewModel>
    {
        public Schedule()
        {
            InitializeComponent();
        }
    }
}
