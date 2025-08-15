namespace NIK.Mediator.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IDispatcherEventHandle
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="events"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEvent"></typeparam>
    /// <returns></returns>
    Task DispatcherAsync<TEvent>(IReadOnlyCollection<TEvent> @events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
