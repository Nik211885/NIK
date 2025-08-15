namespace NIK.Mediator.Interfaces;

/// <summary>
///     Defined delegate in next pipeline
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public delegate Task<TResponse> RequestHandleDelegate<TResponse>();
/// <summary>
/// Defined action in pipeline with request and response type
/// </summary>s
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IPipelineBehavior<in TRequest, TResponse>
    where TRequest : notnull
{
    /// <summary>
    /// Create pipeline before create handle
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="next">delegate before create handle</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    Task<TResponse> Handle(TRequest request, 
        RequestHandleDelegate<TResponse> next,
        CancellationToken cancellationToken = default);
}
