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
    /// <typeparam name="TRequest">value of request</typeparam>
    /// <typeparam name="TResponse">type for response</typeparam>
    /// <returns></returns>
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>;
    /// <summary>
    /// Create handle with don't returning response type
    /// </summary>
    /// <param name="request">type for request</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <typeparam name="TRequest">type for response</typeparam>
    /// <returns></returns>
    Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest;
}

