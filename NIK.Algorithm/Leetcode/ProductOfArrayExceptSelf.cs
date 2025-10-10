namespace Leetcode;
/*
 *  Given an integer array is nums, return an array answer such that
 * answer[i] is equal to the  product of all the element of nums expect nums[i]
 *
 * The product of any prefix or suffix of nums is guaranteed to fit in a 32 bit integer
 *
 * You must write an algorithm that run is 0(n) time and without using division operation
 *
 * Example
 * Input: nums [1,2,3,4]
 * Output [24,12,8,6]
 */
public static class ProductOfArrayExceptSelf
{
    /*
     * Loop for element in array and after loop for element again and check
     * if value has designate in first loop dont add to nums otherwise add to num
     *  Algorithm has complex is O(n^2) and space store is O(n)
     *
     * Problem in Time Limit Exceeded
     */
    public static int[] BasicSolution(int[] nums)
    {
        int[] result = new int [nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = 1;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            for (int j = 0; j < nums.Length; j++)
            {
                if (j != i)
                {
                    result[j] *= num;
                }
            }
        }

        return result;
    }
    /*
     * Explain out is space to store is O(1) so i think i can caluculate in nums 
     * and has algorithm is O(n)
     *  You cant multiplication for all nums and loop again and divide element at i
     *  But problem is divide 0 so if count 0 bigger 1 all element in result is 0
     *  => complex algorithm is O(2n) => O(n)
     */
    public static int[] Solution(int[] nums)
    {
        int multiplication = 1;
        int countZero = 0;
        foreach (var num in nums)
        {
            if (num == 0)
            {
                countZero ++;
                continue;
            }
            multiplication *= num;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            switch (countZero)
            {
                case 1 when nums[i] == 0:
                    nums[i] = multiplication;
                    break;
                case 1:
                case > 1:
                    nums[i] = 0;
                    break;
                default:
                    nums[i] = multiplication / nums[i];
                    break;
            }
        }

        return nums;
    }
}
