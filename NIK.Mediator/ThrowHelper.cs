using System.Diagnostics.CodeAnalysis;
using NIK.Mediator.Interfaces;

namespace NIK.Mediator;

/// <summary>
/// 
/// </summary>
internal static class ThrowHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="message"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentException"></exception>
    public  static void ThrowIfArgumentNull<T>([NotNull]T? argument, string message)
    {
        if (argument is null)
        {
            throw new ArgumentException(message);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="message"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="Exception"></exception>
    
    public static void ThrowIfCollectionIsNullOrEmpty<T>([NotNull] IEnumerable<T>? collection, string message)
    {
        if (collection is null || !collection.Any())
        {
            throw new Exception(message);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="Exception"></exception>

    [DoesNotReturn]
    public static void Throw(string message)
    {
        throw new Exception(message);
    }
    
}
