using Microsoft.AspNetCore.Components.Server.Circuits;

namespace GestionNotes.Blazor.Services
{
    public class CustomCircuitHandler : CircuitHandler
    {
        public bool IsConnected { get; private set; } = true;

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            IsConnected = true;
            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            IsConnected = false;
            return Task.CompletedTask;
        }
    }
}
