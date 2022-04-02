using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace MtconnectCoreDocumentation.Models
{

    public class UpdateAvailableEventHelper
    {
        private readonly Func<Task> _callback;

        public UpdateAvailableEventHelper(Func<Task> callback)
        {
            _callback = callback;
        }

        [JSInvokable]
        public Task OnUpdateAvailable() => _callback();
    }
    public class UpdateAvailableEventInterop : IDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private DotNetObjectReference<UpdateAvailableEventHelper> Reference;

        public UpdateAvailableEventInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> SetupCallback(Func<Task> callback)
        {
            Reference = DotNetObjectReference.Create(new UpdateAvailableEventHelper(callback));
            // addCustomEventListener will be a js function we create later
            return _jsRuntime.InvokeAsync<string>("serviceWorker.addUpdateAvailableListener", Reference);
        }

        public void Dispose()
        {
            Reference?.Dispose();
        }
    }

}
