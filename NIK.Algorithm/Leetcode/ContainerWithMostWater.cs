namespace Leetcode;
/* You are given an integer array height of length n. There are n  vertical lines drawn
 * such that the two endpoints of the ith line are (i,0) and (i, height[i])
 *
 * Find two lines that together with the x-axios from a containers, such that the container
 * contain the most water 
 *
 * Return the maximum amount of water a container can store
 *
 * Notice: thay you may not slant the container
 *
 *
 * Example: Input height = [1,8,6,2,5,4,8,3,7]
 * Output => 49
 * Explation: The above vertical lines are represented by array [1,8,6,2,5,8,3,7].
 * In this case, the max area of water ( blue section) the container can contain is 49
 */
public static class ContainerWithMostWater
{
    /* Think simple
     * We need find two lines in container has area maximum
     * => simple: need two pointer is p1 and p2 and loop for all height match p1 and p2
     * and calculate any situation above area can in height
     * it is two loop nested so => complex algorithm is O(n^2)
     * and space to store is O(1)
     * Use solution for that it throw is time limit exceeded
     */
    public static int BasicSolution(int[] heights)
    {
        int maxArea = 0;
        for (int i = 0; i < heights.Length - 1; i++)
        {
            for (int j = i + 1; j < heights.Length; j++)
            {
                int yAxios = Math.Min(heights[i], heights[j]);
                int xAxios = j - i;
                int localArea = xAxios * yAxios; 
                maxArea = Math.Max(maxArea, localArea);
            }
        }
        return maxArea;
    }
    /*Think about basic solution we don't have duplicate calculate => you can't use memo is hash map for
     * store duplicate
     * So you can  just use logic and basic knowledge about math
     * I can hold with x axios hold to small for each height because if height down
     * In algorithm is has complex algorithm is O(n)
     * and space store is O(1)
     */
    public static int Solution(int[] heights)
    {
        int left = 0;
        int right = heights.Length - 1;
        int maxArea = 0;
        while (left < right)
        {
            int xAxios = right - left;
            int yAxios = heights[left];
            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                yAxios = heights[right];
                right--;
            }
            int localArea =  xAxios * yAxios;
            maxArea = Math.Max(maxArea, localArea);
        }
        return maxArea;
    }
}
