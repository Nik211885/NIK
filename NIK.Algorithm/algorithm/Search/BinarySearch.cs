using NIK.Shared.Exceptions;

namespace algorithm.Search;
/// <summary>
///  Implementation for binary algorithm with recursive 
/// </summary>
/// Draft algorithm
/// source 1 2 3 4 5 6 7 8 9 target = 11
/// step 1 left = 0 right = 8 => middle = 4 => midValue = 5 dont equal target
/// step 2 => midlValue small target slice array to right array => left = mid + 1 = 5
///         newMid = 7 => newMidValue = 8 don't equal target
/// step 3 => midValue small target slice to array to right array => left = oldMid + 1 = 7+1 = 8
///         newMid = 8 => newMidValue = 9 don't equal target
/// step 4 => midValue small target slice to array to right array => left = oldMid + 1 = 8+1=9
///         but mid has bigger right => base case for recursive algorithm
public static partial class SearchAlgorithm  
{
    /// <summary>
    ///    Find element with binary algorithm
    ///     If has find element has match target return index has value equals target
    ///     Return -1 if don't find index has value match target
    /// </summary>
    /// <param name="source">
    ///     Source want to find in element it is implementation binary
    ///     search so make sure source has asc sort after call method
    /// </param>
    /// <param name="target">
    ///     Value want to find in source 
    /// </param>
    /// <param name="star">
    ///     Index has star find target in source
    /// </param>
    /// <param name="end">
    ///     Index has end find target in source
    /// </param>
    /// <typeparam name="T">
    ///     if generic is object type it will compare with all value type in object
    /// </typeparam>
    /// <returns>
    ///     Return index has match target in source and if don't find any element in source has match target return -1
    /// </returns>
    public static int BinarySearch(IEnumerable<int> source, int target, int star = 0, int end = 0)
    {
        int[] sourceArray = source.ToArray();
        ThrowHelper.ThrowIfArgumentNull(sourceArray, "Source cant not be null.");
        // Base case for collection don't have any elements
        if (sourceArray.Length == 0)
        {
            return -1;
        }
        // If dont pass star and end params for collection star is 0 and end find is length for collection
        if (end == 0)
        {
            end =  sourceArray.Length - 1;
        }
        int midIndex = star / 2 + end / 2;
        // Base case for algorithm
        if (midIndex > end)
        {
            return -1;
        }

        if (midIndex < star)
        {
            return -1;
        }
        int midValue = sourceArray[midIndex];
        if (target == midValue)
        {
            return midIndex;
        }
        // Call recursive if dont midValue dont equal target
        // if midValue smaller target slice array to right
        if (midValue < target)
        {
            star = midIndex + 1;
            return BinarySearch(sourceArray,  target, star, end);
        }
        end = midIndex - 1;
        return BinarySearch(sourceArray,  target, star, end);
    }
}
