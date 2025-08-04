namespace NIK.Mediator.Interfaces;

/// <summary>
/// Defined for request change sources it is written operate in cqrs,
/// and it is expected returning type is response, base type is iCommand
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<TResponse>
    : IRequest<TResponse>, ICommand;

/// <summary>
///Defined for request change sources it is written operate in cqrs,
/// and it don't expect returning response
/// </summary>
public interface ICommand : IRequest;
    

