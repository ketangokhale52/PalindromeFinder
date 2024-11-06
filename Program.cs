using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string to find the longest unique palindromes:");
        string input = Console.ReadLine();
        
        var longestPalindromes = FindLongestUniquePalindromes(input, 3);
        
        Console.WriteLine("\nThe 3 longest unique palindromes are:");
        foreach (var palindromeInfo in longestPalindromes)
        {
            Console.WriteLine($"Palindrome: '{palindromeInfo.Palindrome}', Start Index: {palindromeInfo.StartIndex}, Length: {palindromeInfo.Length}");
        }
    }

    public static List<PalindromeInfo> FindLongestUniquePalindromes(string input, int count)
    {
        HashSet<string> uniquePalindromes = new HashSet<string>();
        List<PalindromeInfo> palindromeInfos = new List<PalindromeInfo>();
        
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i + 1; j <= input.Length; j++)
            {
                string substring = input.Substring(i, j - i);
                if (IsPalindrome(substring) && uniquePalindromes.Add(substring))
                {
                    palindromeInfos.Add(new PalindromeInfo
                    {
                        Palindrome = substring,
                        StartIndex = i,
                        Length = substring.Length
                    });
                }
            }
        }
        
        return palindromeInfos
            .OrderByDescending(p => p.Length)
            .Take(count)
            .ToList();
    }

    public static bool IsPalindrome(string str)
    {
        int left = 0;
        int right = str.Length - 1;
        
        while (left < right)
        {
            if (str[left] != str[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    public class PalindromeInfo
    {
        public string Palindrome { get; set; }
        public int StartIndex { get; set; }
        public int Length { get; set; }
    }
}
