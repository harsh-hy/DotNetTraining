using System;
using System.Collections.Generic;

class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> lastIndex = new Dictionary<char, int>();
        int left = 0;
        int maxLen = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char ch = s[right];
            if (lastIndex.ContainsKey(ch) && lastIndex[ch] >= left)
            {
                left = lastIndex[ch] + 1;
            }
            lastIndex[ch] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen;
    }
}