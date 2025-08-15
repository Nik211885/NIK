using NIK.Mediator.Interfaces;

namespace NIK.Mediator;

public sealed class DispatcherEventHandle
    : IDispatcherEventHandle
{
    private readonly IServiceProvider _serviceProvider;

    public DispatcherEventHandle(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;        
    }
    public Task DispatcherAsync<TEvent>(IReadOnlyCollection<TEvent> events, 
        CancellationToken cancellationToken = default) where TEvent : IEvent
    {
        throw new NotImplementedException();
    }
}
