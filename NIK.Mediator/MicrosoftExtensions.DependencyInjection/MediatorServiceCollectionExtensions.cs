using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NIK.Mediator.Extensions;
using NIK.Mediator.Interfaces;

namespace NIK.Mediator.MicrosoftExtensions.DependencyInjection;

public static class MediatorServiceCollectionExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddMediator(this IServiceCollection services,
        Action<MediatorServicesConfiguration> configure)
    {
        var configuration = new MediatorServicesConfiguration();
        configure.Invoke(configuration);
        return services.AddMediator(configuration);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <typeparam name="TScanning"></typeparam>
    /// <returns></returns>
    public static IServiceCollection AddMediator<TScanning>(this IServiceCollection services)
    {
        var configuration = new MediatorServicesConfiguration();
        configuration.RegisterFromAssembly<TScanning>();
        return services.AddMediator(configuration);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddMediator(this IServiceCollection services,
        MediatorServicesConfiguration configuration)
    {
        services.TryAddScoped<ISender, Mediator>();
        services.TryAddScoped<IPublisher, Mediator>();
        services.TryAddScoped<IMediator, Mediator>();
        // Scan in assembly for configuration
        Parallel.ForEach(configuration.AssembliesRegister, assembly =>
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type is not { IsClass: true, IsAbstract: false })
                {
                    continue;
                }
                IEnumerable<Type> interfacesImplementedForType = type.FindDirectInterfaces(
                    typeof(IEventHandle<>),
                    typeof(IHandle<>),
                    typeof(IPipelineBehavior<,>)
                );
                services.TryAdd(interfacesImplementedForType
                    .Select(interfaceImp=> new ServiceDescriptor(interfaceImp, type, configuration.Lifetime)));
            }
        });
        services.TryAdd(configuration.BehaviorServiceDescriptors);
        services.TryAdd(configuration.EventServiceDescriptors);
        services.TryAdd(configuration.RequestServiceDescriptors);
        return services;
    }
}
