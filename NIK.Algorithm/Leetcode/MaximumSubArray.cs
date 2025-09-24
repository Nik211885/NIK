namespace Leetcode;
/* Give an integer array nums, find sub array with the large sum, and return its sum
 * Example:
 *      Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
 *      Output: 6
 *      Explanation: The subarray [4,-1,2,1] has the largest sum 6
 *  
 *      Input: nums = [1]
 *      Output: 1
 *      Explanation: The subarray [1] has the largest sum 1.
 *
 *      Input: nums = [5,4,-1,7,8]
 *      Output: 23
 *      Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
 */
public static class MaximumSubArray
{
    /* sub array has array is sequence so
     * i have two maxes it is global maximum and local maximum
     * global max is value i want to for solution
     * local max is max in value i in source or global + value i 
     * loop for end source it has get result for solution
     * so complex algorithm is o(n) and space storage is 0(1)
     */
    public static int Solution(int[] source)
    {
        if (source.Length == 0)
        {
            return 0;
        }
        int globalMax = source[0];
        int localMax = source[0];
        for (int i = 1; i < source.Length; i++)
        {
            int sequenceSum = localMax + source[i];
            localMax = Math.Max(source[i], sequenceSum);
            globalMax = Math.Max(globalMax, localMax);
        }
        return globalMax;
    }
}
