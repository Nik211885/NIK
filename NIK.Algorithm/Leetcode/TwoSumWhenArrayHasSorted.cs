namespace Leetcode;
/*
    Give a 1 indexed array of integers number that is already sorted
    in non-descreasing order, find two number such that they add up to a specific target number,
    Let these two number be number[index1] and number[index2] where 1<=index1<index2<=numbers.length
    Return indeces of the two number index1 and index2 added by one as an integer array [index1, index2]
    of length 2
    The tests are generated such that there's is exactly one solution you may not use the same element twice
    Your sulution muse use only constant extra space

    numbers = [2,7,11,15], target = 9
    [1,2]
    The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].

    numbers = [2,3,4], target = 6
    [1,3]
    The sum of 2 and 4 is 6. Therefore, index1 = 1, index2 = 3. We return [1, 3].

    numbers = [-1,0], target = -1
    [1,2]
    The sum of -1 and 0 is -1. Therefore, index1 = 1, index2 = 2. We return [1, 2].
 */
public static class TwoSumWhenArrayHasSorted
{
    // This solution has complex algorithm is o(n^2) ana space stored is o(1)
    public static int[] BasicSolution(int[] source, int target)
    {
        for (int i = 0; i < source.Length - 1; i++)
        {
            for (int j = i + 1; j < source.Length; j++)
            {
                int  sum = source[i] + source[j];
                if (sum > target)
                {
                    break;
                }
                if (sum == target)
                {
                    return [i + 1,j + 1];
                }
            }
        }
        return [];
    }
    // You can use hash map to stored data has loop and check element in source with complex is 0(1)=> in here solution is 0(n)
    // but it implementation for source not sorted
    // but in here source has sorted
    // You can loop for source and find other element with binary search => but not work with hashmap => it has space store is 0(1) otherwise hash map stored is 0(n)
    //if array has stored and question required space is o(1) you can't use two pointer in left and right 
    // and plus left and right => if bigger move right
        // else move left
    // example 1 2 3 4 5 6 7 8 9 
    // target 8
    // left is 0 and right is 8
    // case 1 source at [0] + source at [8] = 10 bigger 8 move right pointer -1
    // case 2 source at [0] + source at [7] = 9 bigger 8 move right pointer -1
    // case 3 source at [0] + source at [6] = 8 equals 8 break
    // has o(1) space and o(n) complex algorithm
    // implementation solution
    public static int[] TwoPointerSolution(int[] source, int target)
    {
        int left = 0;
        int right = source.Length - 1;
        while (left < right)
        {
            int expectedResult = source[left] + source[right];
            if (expectedResult == target)
            {
                return [left + 1, right + 1];
            }
            if (expectedResult < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return [];
    }
    
}
