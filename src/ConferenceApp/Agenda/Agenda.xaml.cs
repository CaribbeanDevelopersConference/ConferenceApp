using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConferenceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agenda : DataPageBase<AgendaViewModel>
    {
        public Agenda()
        {
            InitializeComponent();
        }
    }
}