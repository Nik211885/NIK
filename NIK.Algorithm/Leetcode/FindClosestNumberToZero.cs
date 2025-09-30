namespace Leetcode;

/*
 * Given an integer array nums of size n, return the number with the value closest to 0
 * in nums. If there are multiple answers, return the number with the largest value
 *
 * Example 1
 * Input: nums [-4,-2,1,4,8]
 * Output: 1
 * Explanation:
 *    The distance from -4 to 0 is |-4| = 4
 *    The distance from -2 to 0 is |-2| = -2
 *    The distance from 1 to 0 is |1| = 1
 *    The distance from 4 to 0 is |4| = 4
 *    The distance from 8 to 0 is |8| = 8
 * Thus, the closest number to 0 in the array is 1.
 *
 * Example 2:
 * Inputs: nums = [2,-1,1]
 * Output: 1
 * Explanation: 1 and -1 are both the closest number to 0 so 1 being large is returned
 */

public class FindClosestNumberToZero
{
    /*
     * Nums is not has not sorted or have any key to pass some step to find closest num
     * so just is loop for each num in nums and calculate for distance and find distance min
     * with max value in num 
     * So complex algorithm is O(n) and space to store is O(1)
     */
    public static int Solution(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        int maxValueWithMinDistanceToZero = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];
            int distanceForNum = Math.Abs(num);
            int distanceMinLocal = Math.Abs(maxValueWithMinDistanceToZero);
            if (distanceForNum < distanceMinLocal)
            {
                maxValueWithMinDistanceToZero = num;
            }
            else if (distanceForNum == distanceMinLocal)
            {
                if (num > maxValueWithMinDistanceToZero)
                {
                    maxValueWithMinDistanceToZero = num;
                }
            }
        }
        return maxValueWithMinDistanceToZero;
    }
}
