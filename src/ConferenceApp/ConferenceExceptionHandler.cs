using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using ReactiveUI;

namespace ConferenceApp
{
    public class ConferenceExceptionHandler : IObserver<Exception>
    {
        public void OnNext(Exception ex)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            RxApp.MainThreadScheduler.Schedule(() => { throw ex; });
        }

        public void OnError(Exception ex)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            RxApp.MainThreadScheduler.Schedule(() => { throw ex; });
        }

        public void OnCompleted()
        {
            if (Debugger.IsAttached)
                Debugger.Break();
            RxApp.MainThreadScheduler.Schedule(() => { throw new NotImplementedException(); });
        }
    }
}