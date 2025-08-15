namespace NIK.Mediator.Extensions;

internal static class TypeExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="interfaceBaseType"></param>
    /// <returns></returns>
    public static IEnumerable<Type> FindDirectInterfaces(this Type source, params Type[] interfaceBaseType)
    {
        IEnumerable<Type> interfacesForSource = 
             source.GetInterfaces()
                 .Where(x=>x.IsGenericType && interfaceBaseType.Contains(x.GetGenericTypeDefinition()));
        return interfacesForSource.Distinct();
    }
    
}
