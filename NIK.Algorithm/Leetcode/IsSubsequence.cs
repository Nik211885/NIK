namespace Leetcode;
/*
 * Give two string s and t return true if s os a subsequence of t of false is otherwise
 * A subsequence of a string is a new string that is formed from the original string  by
 * deleting some (can be none) of the character without disturbing the relative position
 * of the remaining character. (i,e , "ace" is subsequence of "abcde" while "aec" is not
 *
 * Example
 * Input s = "abc" t = "ahbgdc"
 * Output: true
 */
public static class IsSubsequence
{
    /*
     * Simple for that is loop for star and star to s and find character in s match
     */
    public static bool Solution(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }
        int indexInT = 0;
        foreach (var character in t)
        {
            if (character == s[indexInT])
            {
                indexInT++;
            }
            if (indexInT == s.Length)
            {
                return true;
            }
        }

        return false;
    }
}
