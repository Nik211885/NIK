namespace Leetcode;
/*
 *  You are give two strings word 1 and word 2/ Merge string by adding
 *  letters at alternating order, starting with word 1. If string is longer
 *  than the other, append the additional letters onto the end of the merged string
 *  
 *  Example:
 *  Input: word1 =  "abc", word2 = "pqr"
 *  Output: apbqcr
 *  Explanation: The merged  string  will be merged as so
 *  word 1: a b c
 *  word 2:  p q  r
 * merged: apbqcr
 */
public static class MergeStringAlternately
{
    /*
     * 1.Find length word smaller
     * 2. Loop for 0 to length word have smaller length
     * 3. add word1[i] before  add word[i] to string builder or
     *      create array of char split max length word1 and word 2
     * 4. after loop slice element to end of word has length bigger
     * => Complex algorithm is 0(n+m) and space to store is o(n+m)
     */
    public static string Solution(string word1, string word2)
    {
        int length1 = word1.Length;
        int length2 = word2.Length; 
        int minLength = Math.Min(length1, length2);
        System.Text.StringBuilder merged = new(length1 + length2);
        for (int i = 0; i < minLength; i++)
        {
            merged.Append(word1[i])
                .Append(word2[i]);
        }

        if (minLength == length1)
        {
            for (int i = minLength; i < length2; i++)
            {
                merged.Append(word2[i]);
            }
        }
        else
        {
            for (int i = minLength; i<  length1; i++)
            {
                merged.Append(word1[i]);
            }
        }
        return merged.ToString();
    }
}
