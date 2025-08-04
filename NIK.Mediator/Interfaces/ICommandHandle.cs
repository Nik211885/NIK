namespace NIK.Mediator.Interfaces;

/// <summary>
/// Defined for request with request expected returning to response type
/// and request is will change data source
/// </summary>
/// <typeparam name="TCommand">Type for request will change data source</typeparam>
/// <typeparam name="TResponse">Type for response</typeparam>
public interface ICommandHandle<in TCommand, TResponse>
    : IHandle<TCommand, TResponse>
    where TCommand : ICommand<TResponse>;

/// <summary>
/// Defined for request with request don't returning to response
/// and request is will change data source
/// </summary>
/// <typeparam name="TCommand">Type for request will change data source</typeparam>
public interface ICommandHandle<in TCommand> : IHandle<TCommand>
    where TCommand : ICommand;
