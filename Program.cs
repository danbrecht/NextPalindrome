using System;

namespace NextPalindrome
{
    class Program
    {
        // https://www.reddit.com/r/dailyprogrammer/comments/n3var6/20210503_challenge_388_intermediate_next/
        //A palindrome is a whole number that's the same when read backward in base 10, such as 12321 or 9449.

        //Given a positive whole number, find the smallest palindrome greater than the given number.

        //nextpal(808) => 818
        //nextpal(999) => 1001
        //nextpal(2133) => 2222
        //For large inputs, your solution must be much more efficient than incrementing and checking each subsequent number to see if it's a palindrome. Find nextpal(339) before posting your solution. Depending on your programming language, it should take a fraction of a second.

        static void Main(string[] args)
        {
            WriteResults(1);
            WriteResults(9);
            WriteResults(808); 
            WriteResults(998);
            WriteResults(999);
            WriteResults(1998);
            WriteResults(2133);
            WriteResults(9999);
            WriteResults(17203);
            WriteResults(51223);
            WriteResults(2514241);
            WriteResults(111998);
            WriteResults(1111999);
            WriteResults((ulong)Math.Pow(3, 39));
            WriteResults(18446644073709551615);
        }

        private static void WriteResults(ulong val)
        {
            Console.WriteLine(val + " => " + NextPalindrome(val));
        }

        static string NextPalindrome(ulong val)
        {
            char[] chChars;
            int mid;
            ulong tens;

            chChars = (++val).ToString().ToCharArray();

            mid = chChars.Length / 2;

            // check each value along the first half of the string string with it's reflection in the second half
            // if the reflection is larger then we increment the tens place value in front of the reflection and set the reflection and all values after to 0
            for (int i = 0; i < mid; i++)
            {
                if (chChars[i] < chChars[chChars.Length - i - 1])
                {
                    // this handles the case of a 9 going to 10 cleanly
                    tens = (ulong)Math.Pow(10, i + 1);
                    val += tens;
                    val /= tens;
                    val *= tens;
                    chChars = (++val).ToString().ToCharArray();
                }
            }

            // ensure the last half of the digits reflect the first half
            for (int i = 0; i < chChars.Length / 2; i++)
                chChars[chChars.Length - i - 1] = chChars[i];

            return new String(chChars);
        }
    }
}
