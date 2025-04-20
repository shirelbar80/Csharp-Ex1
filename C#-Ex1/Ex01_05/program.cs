using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main() {

            Console.WriteLine("Please enter a number of 8 digits: ");

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


        private static int generateSmallerDigitsInfo(string io_userString, out string io_digitsList)
        {
            char firstDigitChar = io_userString[0];
            int firstDigit = firstDigitChar - '0';
            string smallerDigits = "";
            int totalSmallerDigits = 0;

            for (int currentChar = 1; currentChar < io_userString.Length; currentChar++)
            {
                int currentDigit = io_userString[currentChar] - '0';

                if (currentDigit < firstDigit)
                {
                    smallerDigits += io_userString[currentChar];
                    totalSmallerDigits++;
                }
            }

            io_digitsList = smallerDigits;

            return totalSmallerDigits;
        }


        private static string digitsDividedBy3WithoutRemainder(string io_userString)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < io_userString.Length; i++)
            {
                char currentChar = io_userString[i];

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



        private static int digitDifferenceFromBiggestToSmallest(string io_userString)
        {
            int maxDigit = 0;
            int minDigit = 9;

            for (int currentChar = 0; currentChar < io_userString.Length; currentChar++)//find the smallest and biggest digits
            {
                int digit = io_userString[currentChar] - '0';

                maxDigit = Math.Max(maxDigit, digit);
                
                minDigit = Math.Min(minDigit, digit);
               
            }

            return (maxDigit - minDigit);
        }

        private static int countTheMostFrequentDigit(string io_userString, out char o_mostFrequentDigit)
        {
            int maxCountOfDigit = 0;
            o_mostFrequentDigit = '0';

            for (char currentDigit = '0'; currentDigit <= '9'; currentDigit++) // check each digit character
            {
                int currentCountOfDigit = 0;

                for (int currentChar = 0; currentChar < io_userString.Length; currentChar++)
                {
                    if (io_userString[currentChar] == currentDigit)
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


        private static bool isValidString(string io_userString) {
        
            if(io_userString.Length != 8) //not the good length
            {
                return false; 
            }

            for (int currentChar = 0; currentChar < io_userString.Length; currentChar++)
            {
                if (!Char.IsDigit(io_userString[currentChar])) //not all are digits
                {
                    return false;
                }
            }

            return true;  //all good

        }

    }
}
