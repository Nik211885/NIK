namespace NIK.Mediator.Interfaces;
/// <summary>
/// Action for event
/// </summary>
public interface IEventHandle
{
    /// <summary>
    ///     Handle for event type 
    /// </summary>
    /// <param name="event">Event</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <typeparam name="TEvent">Type for event</typeparam>
    /// <returns></returns>
    Task Handle<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
        where TEvent : IEvent;
}
