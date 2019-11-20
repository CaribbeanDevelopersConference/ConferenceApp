using System;
using System.Reactive;
using ReactiveUI;
using Sextant;
using Xamarin.Forms;

namespace ConferenceApp
{
    public class SpeakerItemViewModel : ReactiveObject
    {
        private string _name;
        private string _title;
        private string _company;
        private ImageSource _imageSource;
        private Guid _speakerId;

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => this.RaiseAndSetIfChanged(ref _imageSource, value);
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string Company
        {
            get => _company;
            set => this.RaiseAndSetIfChanged(ref _company, value);
        }

        public Guid SpeakerId
        {
            get => _speakerId;
            set => this.RaiseAndSetIfChanged(ref _speakerId, value);
        }

        public string Id => "";
    }
}