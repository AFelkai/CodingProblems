using System;
using System.Linq;

namespace Palindrome
{
    class Program //Look into sorting the string first and see if that would optimize anything. Add a special case to exclude any strings that don't have any duplicate characters 
    {             //Put characters in structure with indices in string. take two indices kabbobb = (b) 2,3,5,6 | bb = 23, bob = 345, bb = 56. kababoaob = (a) 1,3,6 | aba = 123. (b) 2,4,8 | bab = 234, boaob = 45678. (o) 5,7 | oao = 567
        static void Main(string[] args)
        {
            string userInput = "";
            while (!userInput.Equals("exit"))
            {
                Console.WriteLine("Please input a string and we will see if it is a palindrome!");
                userInput = Console.ReadLine();
                Console.WriteLine();
                //Console.WriteLine(IsPalindromeOptimized(userInput) + "\n");
                GetPalindromes(userInput);
                Console.WriteLine();
            }
        }

        public static bool IsPalindrome(string input) //O(n/2)
        {
            if (input.Length < 2) //Base case, is palindrome
                return true;

            if (input[0] == input.Last())
                return IsPalindrome(input.Substring(1, input.Length - 2));
            else
                return false;
        }

        public static bool IsPalindromeOptimized(string input) //O(n/4)
        {
            string firstHalf = input.Substring(0, input.Length / 2);
            string secondHalf = input.Substring(input.Length / 2);

            if (input.Length % 2 == 1) //Is odd
                secondHalf = secondHalf.Substring(1);

            secondHalf = ReverseString(secondHalf);

            if (firstHalf.Equals(secondHalf))
                return true;
            return false;
        }

        public static bool BruteForcePalindrome(string input)
        {
            return false;
        }

        public static string ReverseString(string input, int index = 0) //Reverses string in O(n/2) time
        {
            if (index == input.Length / 2)
                return input.ToString();

            char[] reversed = input.ToCharArray();
            char temp;

            temp = reversed[index];
            reversed[index] = reversed[reversed.Length - 1 - index];
            reversed[reversed.Length - 1 - index] = temp;

            return ReverseString(new string(reversed), index + 1);
        }

        public static void GetPalindromes(string input)
        {
            Console.WriteLine("Results:");
            for (int i = 0; i < input.Length - 1; i++)
            {
                int j = i;
                if (input[i] == input[++j])
                    Expand(input, i, j);
            }

            for (int i = 0; i < input.Length - 2; i++)
            {
                int j = i + 1;
                if (input[i] == input[++j])
                    Expand(input, i, j);
            }
        }

        public static void Expand(string input, int first, int second)
        {
            Console.WriteLine(input.Substring(first, second - first + 1) + "(" + first + "," + second + ")");

            if (first > 0 && second < input.Length - 1) //If string can be expanded
                if (input[--first] == input[++second])
                    Expand(input, first, second);
        }
    }
}
