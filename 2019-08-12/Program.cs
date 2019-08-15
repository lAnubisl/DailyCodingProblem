using System;
using System.Collections.Generic;

namespace _2019_08_12
{

    /*
       Given a string s and an integer k, break up the string into multiple lines such that each line has a length of k or less.
       You must break it up so that words don't break across lines. Each line has to have the maximum possible amount of words. 
       If there's no way to break the text up, then return null.
       You can assume that there are no spaces at the ends of the string and that there is exactly one space between each word.
       For example, given the 
          string "the quick brown fox jumps over the lazy dog" 
          and k = 10, you should 
          return: ["the quick", "brown fox", "jumps over", "the lazy", "dog"]. 
       No string in the list has a length of more than 10.
    */
    class Program
    {
        static void Main(string[] args)
        {
            var text = "the quick brown fox jumps over the lazy dog";
            var items = SplitText(text, 10);

            if (items != null)
            {
                foreach(var item in items)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }

        static string[] SplitText(string text, int itemsLength)
        {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var items = new List<string>();
            var item = string.Empty;
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (item == string.Empty)
                {
                    item = word;
                    if (item.Length > itemsLength)
                        return null;
                    else continue;
                }

                if (item.Length + 1 + word.Length > itemsLength)
                {
                    items.Add(item);
                    item = string.Empty;
                    i--;
                    continue;
                }

                item = item + " " + word;
            }

            if (item != string.Empty)
            {
                items.Add(item);
            }

            return items.ToArray();
        }
    }
}