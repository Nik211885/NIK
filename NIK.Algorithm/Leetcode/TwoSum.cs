namespace Leetcode;
/*
Give an  array integer array and integer target, return indices of the two number
such that they add up to target

You may assume that each input would have extractly
one solution, and you many not use them same element twice
You can return the answer in any order

Example 
array = [2,7,11,15], target = 9
=> num[0] + num[1] = target => 
return [0,1]

array [3,2,4], target = 6
=> num[1] + num[2] = 6
=> return [1,2]

array[3,3], target = 6,
num[0] + num[1] = target
=> return [0,1]
 */
public static class TwoSum
{
    // Use two cursor i and j lop and sum value in source at i and j
    // while sum value i with j equals target => return i and j
    // It has complex algorithm is O (n^2) and space store is o(1)
    public static int[] BasicSolution(int[] source, int target)
    {
        for (int i = 0; i < source.Length - 1; i++)
        {
            for (int j = i + 1; j < source.Length; j++)
            {
                int sum = source[i] + source[j];
                if (target == sum)
                {
                    return [ i, j ];
                }
            }
        }
        return [];
    }
    // You can use hash map to slove problem with complex algorithm is O(n) and space store is o(n)
    // It is use hash map for memory because access and add new element to dict it is has complex o(1)
    public static int[] HasMapSolution(int[] source, int target)
    {
        Dictionary<int, int> map = new();
        for (int i = 0; i < source.Length; i++)
        {
            int complement = target - source[i];
            if (map.TryGetValue(complement, out int indexComplement))
            {
                return [indexComplement, i];
            }
            map.Add(source[i], i);
        }
        return [];
    }
    
}
