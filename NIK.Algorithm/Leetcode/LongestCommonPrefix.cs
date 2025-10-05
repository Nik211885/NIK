namespace Leetcode;
/*
 *  Write a function to find longest common prefix string amongst an array of string
 * If there is no common prefix, return an empty string ""
 *
 *  Example:
 *  Inputs: strs = ["flower", "flow", "flight"]
 *  Output: "fl"
 */
public static class LongestCommonPrefix
{
    /*
     *  use first string in strs is stumped
     *  defined char at index in stump
     *  loop sequences in other  string in strs
     *  and find character match char need find in stump char at index has defined
     *  if don't have character find break out
     *  and set other char in stump and loop again for strs
     */
    public static string BasicSolution(string[] strs)
    {
        if (strs.Length == 0)
        {
            return string.Empty;
        }

        if (strs.Length == 1)
        {
            return strs[0];
        }
        string globalResult = "";
        string localResult = "";
        int[] localState = new int[strs.Length];
        for (int i = 1; i < strs.Length; i++)
        {
            localState[i] = 0;
        }
        string stumpStr = strs[0];
        bool flagMatch = false;
        // Loop character in stump
        foreach (var s in stumpStr)
        {
            // Find character in other string in strs match character in stump
            // Defined flag if find character in strs match  charter in stump
            for (int i = 1; i < strs.Length; i++)
            {
                for (int j = localState[i]; j < strs[i].Length; j++)
                {
                    if (strs[i][j] == s)
                    {
                        localState[i] = j;
                        flagMatch = true;
                        break;
                    }

                    if (j == strs[i].Length - 1)
                    {
                        for (int k = 1; k < strs.Length; k++)
                        {
                            localState[k] = 0;
                        }
                        flagMatch = false;
                    }
                }
            }
            // If  match increment local common prefix otherwise reset value and try agian loop
            // save state in loop with find character match stump
            if (flagMatch)
            {
                localResult = localResult + s;
                if (localResult.Length > globalResult.Length)
                {
                    globalResult = localResult;
                }
            }
            else
            {
                localResult = "";
            }
        }

        return globalResult;

    }
    /*
     *
     *
     *
     * 
     */
    public static string Solution(string[] strs)
    {
        throw new NotImplementedException();
    }
}
