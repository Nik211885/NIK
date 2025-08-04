namespace NIK.Mediator.Interfaces;

/// <summary>
/// Mark to this is type of request for user send to server
/// and expected returning type is response and base is iRequest usefully
/// create pipeline before get to handle 
/// </summary>
public interface IRequest<TResponse> : IRequest;

/// <summary>
/// Mark to this is type of request for user send to
/// server and don't anything send back
/// </summary>
public interface IRequest;
