using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NIK.Mediator.Extensions;
using NIK.Mediator.Interfaces;

namespace NIK.Mediator;

/// <summary>
/// 
/// </summary>
public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;
    
    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) 
        where TRequest : IRequest<TResponse>
    {
        IHandle<TRequest, TResponse> handle = _serviceProvider.GetRequiredService<IHandle<TRequest, TResponse>>();
        IEnumerable<IPipelineBehavior<TRequest, TResponse>> pipelines = _serviceProvider
            .GetServices<IPipelineBehavior<TRequest, TResponse>>()
            .Reverse();
        RequestHandleDelegate<TResponse> next = ()=> handle.Handle(request, cancellationToken);
        foreach (IPipelineBehavior<TRequest, TResponse> pipeline in pipelines)
        {
            RequestHandleDelegate<TResponse> current = next;
            next = () => pipeline.Handle(request, current, cancellationToken);
        }
        return await next();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
    {
        IHandle<TRequest> handle = _serviceProvider.GetRequiredService<IHandle<TRequest>>();
        IEnumerable<IPipelineBehavior<TRequest, VoidResult>> pipelines = _serviceProvider
            .GetServices<IPipelineBehavior<TRequest, VoidResult>>()
            .Reverse();
        RequestHandleDelegate<VoidResult> next = () =>
        {
            handle.Handle(request, cancellationToken);
            return Task.FromResult(new VoidResult());
        };
        foreach (IPipelineBehavior<TRequest, VoidResult> pipeline in pipelines)
        {
            RequestHandleDelegate<VoidResult> current = next;
            next = () => pipeline.Handle(request, current, cancellationToken);
        }
        await next();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        Type typeRequest = request.GetType();
        Type typeResponse = typeof(TResponse);
        Type handleType = typeof(IHandle<>).MakeGenericType(typeRequest, typeResponse);
        Type pipeLineType = typeof(IPipelineBehavior<,>).MakeGenericType(typeRequest, typeResponse);
        object handle = _serviceProvider.GetRequiredService(handleType);
        IEnumerable<object?> pipelines = _serviceProvider.GetServices(pipeLineType);
        MethodInfo? handleMethod = handle.GetType().GetMethod("Handle");
        ThrowHelper.ThrowIfArgumentNull(handleMethod, $"Not find handle method in request {typeRequest.Name} and handle {handleType.Name}");
        RequestHandleDelegate<TResponse> next = () => 
            handleMethod.Invoke(handle, [request, cancellationToken]) as Task<TResponse> ?? throw new InvalidOperationException($"Can't not convert to handler response type {typeResponse.Name}");
        foreach (object? pipe in pipelines)
        {
            if (pipe is null)
            {
                continue;
            }
            Type pipelineType = pipe.GetType();
            MethodInfo? pipeMethod = pipelineType.GetMethod("Handle");
            ThrowHelper.ThrowIfArgumentNull(pipeMethod, $"Not find handle method in request {typeRequest.Name} and handle {pipelineType.Name}");
            RequestHandleDelegate<TResponse> current = next;
            next =()=> pipeMethod.Invoke(pipe, [request, current, cancellationToken]) as Task<TResponse> ?? throw new InvalidOperationException($"Can't convert to handler response type {pipelineType.Name}");
        } 
        return await next();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="event"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEvent"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>

    public Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
    {
        throw new NotImplementedException();
    }   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="events"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEvent"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>

    public Task Publish<TEvent>(IReadOnlyList<TEvent> events, CancellationToken cancellationToken = default) where TEvent : IEvent
    {
        throw new NotImplementedException();
    }
}
