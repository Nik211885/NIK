using algorithm.Search;

namespace tests.Search;

public class BinarySearchTest
{
    [Theory]
    [InlineData(8, 1,2,3,4,5,6,7,8,9)]
    public void BinarySearch_WithSourceHasMatchTargetValue_ThenReturnIndexSourceHasMatchTargetValue(int target, params int[] sources)
    {
        int indexValue = SearchAlgorithm.BinarySearch(sources, target);
        Assert.Equal(7, indexValue);
    } 
    [Theory]
    [InlineData(11, 1,2,3,4,5,6,7,8,9)]
    public void BinarySearch_WithSourceHasDontMatchTargetValue_ThenReturnPositive1(int target, params int[] sources)
    {
        int indexValue = SearchAlgorithm.BinarySearch(sources, target);
        Assert.Equal(-1, indexValue);
    } 
}
