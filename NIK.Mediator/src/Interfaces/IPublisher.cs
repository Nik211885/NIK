namespace NIK.Mediator.Interfaces;

/// <summary>
///     Publisher event in event type
/// </summary>
public interface IPublisher
{
    /// <summary>
    ///     Find and publish event has handle for type is event
    /// </summary>
    /// <param name="event">event</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <typeparam name="TEvent">Type for event</typeparam>
    /// <returns></returns>
    Task Publish<TEvent>(TEvent @event, 
        CancellationToken cancellationToken = default)
        where TEvent : IEvent;
    /// <summary>
    /// Find and publish event has handle for type is
    /// event with collection event and currency
    /// </summary>
    /// <param name="events">collection for event</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <typeparam name="TEvent">Type for event</typeparam>
    /// <returns></returns>
    Task Publish<TEvent>(IReadOnlyList<TEvent> events, 
        CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
