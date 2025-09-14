namespace NIK.Mediator.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IDispatcher
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="events"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEvent"></typeparam>
    /// <returns></returns>
    Task Dispatcher<TEvent>(IReadOnlyCollection<TEvent> @events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
