using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    internal class Program
    {
        static public void Main()
        {
            Console.WriteLine("Please enter a string of 12 characters: ");

            string userString = Console.ReadLine();

            //checking if input is valid
            while (!isValidString(userString))
            {
                Console.WriteLine("Input is not valid, please try again: ");
                userString = Console.ReadLine();
            }

            Console.WriteLine("The string a palindrome: " + isStringAPalindromeRecursive(userString));

            //only if all characters are digits
            if (double.TryParse(userString, out double numberOfUserString))
            { 
                Console.WriteLine("The number is divisible by 3 with no remainder: " + (numberOfUserString % 3 == 0));
            }
              //only if all chars are english letters
            if (userString.All(char.IsLetter))
            {
                Console.WriteLine("There are " + userString.Count(char.IsUpper) + " uppercase letters.");

                Console.WriteLine("The string is in alphabetical ascending order: " + isStringInAscendingAlphabeticalOrder(userString));
            }

        }

        static private bool isValidString(string i_stringToCheck)
        {
            bool isStringValid = true;

            if (i_stringToCheck.Length != 12)//string is not 12 characters
            {
                isStringValid = false;
            }
      
            return isStringValid;
        }

        static private bool isStringAPalindromeRecursive(string i_stringToCheck)
        {
            string lowerCaseStr = i_stringToCheck.ToLower();

            return isStringAPalindromeRecursiveHelper(lowerCaseStr, 0, i_stringToCheck.Length - 1);
        }

        static private bool isStringAPalindromeRecursiveHelper(string i_stringToCheck, int i_left, int i_right)
        {
            if (i_left >= i_right)
            {   //only one character or that left bypassed right
                return true;
            }
            // If characters don't match, it's not a palindrome
            if (i_stringToCheck[i_left] != i_stringToCheck[i_right])
            { 
                return false;
            }
            //move inward
            return isStringAPalindromeRecursiveHelper(i_stringToCheck, i_left + 1, i_right - 1);
        }

        static private bool isStringInAscendingAlphabeticalOrder(string i_userString)                                                        
        {
            bool isStringInAscendingAlphabeticalOrder = true;

            for (int currentCharIndex = 0; currentCharIndex < i_userString.Length - 1; currentCharIndex++)//for every letter
            {
                if (char.ToLower(i_userString[currentCharIndex]) > char.ToLower(i_userString[currentCharIndex + 1])) //Ascii value of the letter before is bigger than the letter after 
                {
                    isStringInAscendingAlphabeticalOrder = false;
                }
            }

            return isStringInAscendingAlphabeticalOrder;
        }


    }
    
}
