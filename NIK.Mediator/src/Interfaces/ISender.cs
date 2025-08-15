namespace NIK.Mediator.Interfaces;
/// <summary>
/// Create handle with correction request
/// </summary>
public interface ISender
{
    /// <summary>
    /// Create handle with expected returning response type
    /// </summary>
    /// <param name="request">type for request</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <typeparam name="TResponse">type for response</typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns></returns>
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) 
        where TRequest : IRequest<TResponse>;

    /// <summary>
    /// Create handle with don't returning response type
    /// </summary>
    /// <param name="request">type for request</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}

