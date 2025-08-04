namespace NIK.Mediator.Interfaces;

/// <summary>
/// Defined for request read data sources  in cqrs,
/// and it is expected returning type is response, base type is iQuery
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<TResponse> : IRequest<TResponse>, IQuery;

/// <summary>
///Defined for request read data sources in cqrs,
/// and it don't expect returning response
/// </summary>
public interface IQuery : IRequest;
