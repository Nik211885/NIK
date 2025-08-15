namespace NIK.Mediator.Interfaces;

/// <summary>
/// Defined for request with request expected returning to response type
/// and request is will read data source
/// </summary>
/// <typeparam name="TQuery">type for query</typeparam>
/// <typeparam name="TResponse">type for response</typeparam>
public interface IQueryHandle<in TQuery, TResponse>
    : IHandle<TQuery, TResponse>
    where TQuery : IQuery<TResponse>;

/// <summary>
/// Defined for request with request don't returning to response
/// and request is will read data source
/// </summary>
/// <typeparam name="TQuery">type for query</typeparam>
public interface IQueryHandle<in TQuery>
    : IHandle<TQuery> where TQuery : IRequest;
