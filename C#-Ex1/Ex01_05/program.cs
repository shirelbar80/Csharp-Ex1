using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    internal class Program
    {
        private const int k_ValidLengthOfANumber = 8;

        public static void Main() {

            Console.WriteLine(string.Format("Please enter a number of {0} digits: ", k_ValidLengthOfANumber));

            string userString = Console.ReadLine();

            while (!isValidString(userString))
            {                                                                                   
                Console.WriteLine("Input is not valid, please try again: ");
                userString = Console.ReadLine();
            }

            int totalOfSmallerDigits = generateSmallerDigitsInfo(userString, out string stringOfSmallerDigits);

                    
            Console.Write("Left digit is: "+ userString[0] + ". Digits that are smaller: ");
            for (int currentChar = 0; currentChar < totalOfSmallerDigits; currentChar++)
            {
                Console.Write(stringOfSmallerDigits[currentChar]+ ", ");
            }
            if(totalOfSmallerDigits == 0)
            {
                Console.Write("None, ");
            }
            Console.WriteLine("A total of: " + totalOfSmallerDigits);
            

            string stringOfDigitsDividedBy3WithoutRemainder = digitsDividedBy3WithoutRemainder(userString);

            Console.Write("The digits that are devided by 3 without remainder: ");
            for (int currentChar = 0; currentChar < stringOfDigitsDividedBy3WithoutRemainder.Length; currentChar++)
            {
                Console.Write(stringOfDigitsDividedBy3WithoutRemainder[currentChar] + ", ");
            }
            Console.WriteLine("A total of: " + stringOfDigitsDividedBy3WithoutRemainder.Length);


            Console.WriteLine("The difference between the biggest digit to the smallest digit is: " + digitDifferenceFromBiggestToSmallest(userString));

            int countOfTheMostFrequentDigit = countTheMostFrequentDigit(userString, out char mostFrequentDigit);
            Console.WriteLine("The Digit that appears the most times is: " + mostFrequentDigit + " (appears " + countOfTheMostFrequentDigit + " times)");


        }


        private static int generateSmallerDigitsInfo(string i_userString, out string o_digitsList)
        {
            char firstDigitChar = i_userString[0];
            int firstDigit = firstDigitChar - '0';
            string smallerDigits = "";
            int totalSmallerDigits = 0;

            for (int currentChar = 1; currentChar < i_userString.Length; currentChar++)
            {
                int currentDigit = i_userString[currentChar] - '0';

                if (currentDigit < firstDigit)
                {
                    smallerDigits += i_userString[currentChar];
                    totalSmallerDigits++;
                }
            }

            o_digitsList = smallerDigits;

            return totalSmallerDigits;
        }


        private static string digitsDividedBy3WithoutRemainder(string i_userString)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < i_userString.Length; i++)
            {
                char currentChar = i_userString[i];

                if (char.IsDigit(currentChar))
                {
                    int digit = currentChar - '0';
                    if (digit % 3 == 0)
                    {
                        result.Append(currentChar);
                    }
                }
            }

            return result.ToString();
        }



        private static int digitDifferenceFromBiggestToSmallest(string i_userString)
        {
            int maxDigit = 0;
            int minDigit = 9;

            for (int currentChar = 0; currentChar < i_userString.Length; currentChar++)//find the smallest and biggest digits
            {
                int digit = i_userString[currentChar] - '0';

                maxDigit = Math.Max(maxDigit, digit);
                
                minDigit = Math.Min(minDigit, digit);
               
            }

            return (maxDigit - minDigit);
        }

        private static int countTheMostFrequentDigit(string i_userString, out char o_mostFrequentDigit)
        {
            int maxCountOfDigit = 0;

            o_mostFrequentDigit = '0';

            for (char currentDigit = '0'; currentDigit <= '9'; currentDigit++) // check each digit character
            {
                int currentCountOfDigit = 0;

                for (int currentChar = 0; currentChar < i_userString.Length; currentChar++)
                {
                    if (i_userString[currentChar] == currentDigit)
                        currentCountOfDigit++;
                }

                if (currentCountOfDigit > maxCountOfDigit)
                {
                    maxCountOfDigit = currentCountOfDigit;
                    o_mostFrequentDigit = currentDigit;
                }
            }

            return maxCountOfDigit;
        }


        private static bool isValidString(string i_userString) {
        
            bool isStringValid = true;

            if(i_userString.Length != k_ValidLengthOfANumber) //not the good length
            {
                isStringValid = false; 
            }

            for (int currentChar = 0; currentChar < i_userString.Length; currentChar++)
            {
                if (!Char.IsDigit(i_userString[currentChar])) //not all are digits
                {
                    isStringValid = false;
                }
            }

            return isStringValid;  //all good

        }

    }
}
