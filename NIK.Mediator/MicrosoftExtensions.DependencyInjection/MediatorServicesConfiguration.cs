using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NIK.Mediator.Extensions;
using NIK.Mediator.Interfaces;

namespace NIK.Mediator.MicrosoftExtensions.DependencyInjection;

public class MediatorServicesConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
    /// <summary>
    /// 
    /// </summary>
    public List<Assembly> AssembliesRegister { get; } = [];
    /// <summary>
    /// 
    /// </summary>
    public List<ServiceDescriptor> RequestServiceDescriptors { get;} = [];
    /// <summary>
    /// 
    /// </summary>
    public List<ServiceDescriptor> EventServiceDescriptors { get; } = [];
    /// <summary>
    /// 
    /// </summary>
    public List<ServiceDescriptor> BehaviorServiceDescriptors { get; } = [];
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    
    public MediatorServicesConfiguration RegisterFromAssembly<T>()
    {
        AssembliesRegister.Add(typeof(T).Assembly);
        return this;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="assemblies"></param>
    /// <returns></returns>

    public MediatorServicesConfiguration RegisterFromAssemblies(params Assembly[] assemblies)
    {
        AssembliesRegister.AddRange(assemblies);
        return this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lifetime"></param>
    /// <typeparam name="TRequestHandle"></typeparam>
    /// <returns></returns>
    public MediatorServicesConfiguration AddRequest<TRequestHandle>(
        ServiceLifetime lifetime = ServiceLifetime.Transient)
     =>AddRequest(typeof(TRequestHandle));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lifetime"></param>
    /// <param name="typeRequest"></param>
    /// <returns></returns>
    public MediatorServicesConfiguration AddRequest(Type typeRequest,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        RequestServiceDescriptors.AddRange(
            CreateServiceDescriptorForSource(typeRequest,typeof(IHandle<>), lifetime));
        return this;
    }
    /// <summary>   
    /// 
    /// </summary>
    /// <param name="lifetime"></param>
    /// <typeparam name="TEventHandle"></typeparam>
    /// <returns></returns>
    public MediatorServicesConfiguration AddEvent<TEventHandle>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        => AddEvent(typeof(TEventHandle));
    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeEvent"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public MediatorServicesConfiguration AddEvent(Type typeEvent, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        EventServiceDescriptors.AddRange(
            CreateServiceDescriptorForSource(typeEvent, typeof(IEventHandle<>), lifetime));
        return this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lifetime"></param>
    /// <typeparam name="TBehavior"></typeparam>
    /// <returns></returns>
    public MediatorServicesConfiguration AddBehavior<TBehavior>(
        ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        AddBehavior(typeof(TBehavior)); 
        return this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeBehavior"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    public MediatorServicesConfiguration AddBehavior(Type typeBehavior,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        BehaviorServiceDescriptors.AddRange(
            CreateServiceDescriptorForSource(typeBehavior, typeof(IPipelineBehavior<,>), lifetime));
        return this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeImplementationForSource"></param>
    /// <param name="interfaceBase"></param>
    /// <param name="lifetime"></param>
    /// <returns></returns>
    private IEnumerable<ServiceDescriptor> CreateServiceDescriptorForSource(Type typeImplementationForSource, Type interfaceBase,
        ServiceLifetime lifetime)
    {
        IEnumerable<Type> interfaceForSources = typeImplementationForSource.FindDirectInterfaces(interfaceBase).ToList();
        ThrowHelper.ThrowIfCollectionIsNullOrEmpty(interfaceForSources, $"Not find interface assignee for {interfaceBase.Name.ToString()} in {typeImplementationForSource.Name.ToString()}");
        return interfaceForSources.Select(interfacesForSource=> new ServiceDescriptor(typeImplementationForSource, interfacesForSource, lifetime));
    }
}
