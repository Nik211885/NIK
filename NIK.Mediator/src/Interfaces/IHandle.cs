namespace NIK.Mediator.Interfaces;

/// <summary>
/// Defined for request with request expected returning to response type
/// </summary>
public interface IHandle<in TRequest, TResponse>
    where TRequest : IRequest<TResponse> 
{
    /// <summary>
    /// Action for request have returning response type
    /// </summary>
    /// <param name="request">Request is just base for IRequest type for generic TResponse</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
}

/// <summary>
/// Defined for request with request don't returning to response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public interface IHandle<in TRequest>
    where TRequest : IRequest
{
    /// <summary>
    /// Action don't have returning to response
    /// </summary>
    /// <param name="request">Request is just base for IRequest type</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task Handle(TRequest request, CancellationToken cancellationToken = default);
}
