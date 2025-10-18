using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Topics.Dictionary.T3_Dictionary
{
    public static class DictionaryTasks
    {
        public static List<KeyValuePair<string, int>> TopNWords(string text, int n)
        {
       
            if (n <= 0 || string.IsNullOrWhiteSpace(text))
                return new List<KeyValuePair<string, int>>();

     
            var words = SplitTextIntoWords(text);

            
            var frequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (frequency.ContainsKey(word))
                        frequency[word]++;
                    else
                        frequency[word] = 1;
                }
            }

            return frequency
                .OrderByDescending(pair => pair.Value)  
                .ThenBy(pair => pair.Key)               
                .Take(n)                                
                .ToList();
        }

        private static IEnumerable<string> SplitTextIntoWords(string text)
        {
            var words = new List<string>();
            var currentWord = new System.Text.StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    currentWord.Append(c);
                }
                else
                {
                   
                    if (currentWord.Length > 0)
                    {
                        words.Add(currentWord.ToString().ToLowerInvariant());
                        currentWord.Clear();
                    }
                }
            }

         
            if (currentWord.Length > 0)
            {
                words.Add(currentWord.ToString().ToLowerInvariant());
            }

            return words;
        }
    }
}