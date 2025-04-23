using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        private const int k_ValidLengthOfABinaryNumber = 7;
        private const int k_TotalOfBinaryNumbers = 4;

        static public void Main()
        {
            string[] binaryNumbers = new string[k_TotalOfBinaryNumbers];

            Console.WriteLine(string.Format("Enter {0} binary numbers with {1} digits: ", k_TotalOfBinaryNumbers, k_ValidLengthOfABinaryNumber));

            //getting all 4 binary numbers
            for (int currentBinaryNumber = 0; currentBinaryNumber < 4; currentBinaryNumber++)
            {
                binaryNumbers[currentBinaryNumber] = Console.ReadLine();//read binary number

                //check if valid
                while (!validBinaryNumber(binaryNumbers[currentBinaryNumber]))
                {
                    //number is not valid
                    Console.Write("Binary number is not valid, try again: ");
                    binaryNumbers[currentBinaryNumber] = Console.ReadLine();//read binary number

                }
            }

            int[] decimalNumbers = binaryToDecimal(binaryNumbers);
            printInDescendingOrder(decimalNumbers);
            //average of the decimal numbers
            Console.WriteLine("\nAverage: " + decimalNumbers.Average());
            printLargestSequenceOfOnes(binaryNumbers);
            printNumberOfTransitions(binaryNumbers);
            printBinaryNumberWithTheMostNumberOfOnes(binaryNumbers);
            printTotalNumberOfOnes(binaryNumbers);
        }

        static private bool validBinaryNumber(string i_binaryNumber) //check if the binary number is valid for the program
        {
            bool isBinaryNumberValid = true;

            //check length of 7 bits
            if (i_binaryNumber.Length != k_ValidLengthOfABinaryNumber)
            {
                isBinaryNumberValid = false;
            }

            //check only 0 or 1 in the string
            for (int currentBit = 0; currentBit < k_ValidLengthOfABinaryNumber; currentBit++)
            {
                if (i_binaryNumber[currentBit] != '0' && i_binaryNumber[currentBit] != '1')
                {
                    isBinaryNumberValid = false;
                }
            }

            return isBinaryNumberValid;

        }

        static private int[] binaryToDecimal(string[] i_binaryNumbers) //calculates the decimal values of the binary numbers
        {
            int[] decimalNumbers = new int[k_TotalOfBinaryNumbers];

            for (int currentBinaryNumber = 0; currentBinaryNumber < k_TotalOfBinaryNumbers; currentBinaryNumber++) //for every binary number
            {
                int currentPower = 1;
                // Loop from right to left
                for (int currentBit = i_binaryNumbers[currentBinaryNumber].Length - 1; currentBit >= 0; currentBit--)
                {
                    if (i_binaryNumbers[currentBinaryNumber][currentBit] == '1')
                    {
                        decimalNumbers[currentBinaryNumber] += currentPower;
                    }

                    currentPower *= 2;
                }

            }

            return decimalNumbers;

        }

        static private void printInDescendingOrder(int[] io_decimalNumbers)
        {

            Array.Sort(io_decimalNumbers); //orginize them from lowest to highest
            //print in descending order
            Console.Write("Here are the decimal numbers in descending order: ");
            for (int currentDecimalNumber = io_decimalNumbers.Length - 1; currentDecimalNumber >= 0; currentDecimalNumber--)
            {
                Console.Write(io_decimalNumbers[currentDecimalNumber] + ", ");
            }

        }

        //finds and prints the longest sequence of ones in a binary number 
        static private void printLargestSequenceOfOnes(string[] i_binaryNumbers)
        {
            int largestSequenceOfOnes = 0;
            string binaryNumberWithTheLargestSequenceOfOnes = i_binaryNumbers[0];

            for (int currentBinaryNumber = 0; currentBinaryNumber < i_binaryNumbers.Length; currentBinaryNumber++)//for each binary number
            {
                int currentSequenceOfOnes = 0;
                int currentLargestSequenceOfOnes = 0;

                for (int currentBit = 0; currentBit < i_binaryNumbers[currentBinaryNumber].Length; currentBit++)   //for each bit in the binary number
                {

                    //this is the first 1 or this is 1 and the one before it is 1
                    if (i_binaryNumbers[currentBinaryNumber][currentBit] == '1')
                    {
                        currentSequenceOfOnes++;

                        //change the largest if the current is bigger
                        if (currentLargestSequenceOfOnes < currentSequenceOfOnes)
                        {
                            currentLargestSequenceOfOnes = currentSequenceOfOnes;
                        }
                    }
                    else if (i_binaryNumbers[currentBinaryNumber][currentBit] == '0')  //the sequence was broken
                    {
                        currentSequenceOfOnes = 0;
                    }
                }
                //update the largest sequece and the binary number
                if (currentLargestSequenceOfOnes > largestSequenceOfOnes)
                {
                    largestSequenceOfOnes = currentLargestSequenceOfOnes;
                    binaryNumberWithTheLargestSequenceOfOnes = i_binaryNumbers[currentBinaryNumber];
                }

            }

            Console.WriteLine(string.Format("The longest sequence of ones is: {0} ({1})", largestSequenceOfOnes, binaryNumberWithTheLargestSequenceOfOnes));

        }

        static private void printNumberOfTransitions(string[] i_binaryNumbers)
        {
            int[] numberOfTransitions = new int[4];

            Console.Write("The number of transitions for each binary number: ");

            for (int currentBinaryNumber = 0; currentBinaryNumber < i_binaryNumbers.Length; currentBinaryNumber++)//for each binary number
            {
                int currentNumberOfTransitions = 0;

                for (int currentBit = 0; currentBit < i_binaryNumbers[currentBinaryNumber].Length; currentBit++)//for each bit in the binary number
                {
                    if (currentBit != 0 && i_binaryNumbers[currentBinaryNumber][currentBit - 1] != i_binaryNumbers[currentBinaryNumber][currentBit])
                    {
                        currentNumberOfTransitions++;
                    }

                }

                Console.Write(currentNumberOfTransitions + " (" + i_binaryNumbers[currentBinaryNumber] + "), ");

            }
        }

        static private int calculateNumberOfOnesInABinaryNumber(string i_binaryNumber)
        {
            int numberOfOnes = 0;

            for (int currentBit = 0; currentBit < i_binaryNumber.Length; currentBit++)
            {
                if (i_binaryNumber[currentBit] == '1')
                {
                    numberOfOnes++;
                }
            }

            return numberOfOnes;
        }

        static private void printBinaryNumberWithTheMostNumberOfOnes(string[] i_binaryNumbers)
        {
            int[] decimalNumbers = binaryToDecimal(i_binaryNumbers);  //build the decimal array
            int maxNumberOfOnes = 0;
            int decimalNumberWithTheMostOnes = decimalNumbers[0];
            string binaryNumberWithTheMostOnes = i_binaryNumbers[0];

            for (int currentBinaryNumber = 0; currentBinaryNumber < i_binaryNumbers.Length; currentBinaryNumber++)  //for each binary number
            {
                int currentNumberOfOnes = calculateNumberOfOnesInABinaryNumber(i_binaryNumbers[currentBinaryNumber]); //calculate the number of ones
                if (currentNumberOfOnes > maxNumberOfOnes)//switch if bigger than max
                {
                    maxNumberOfOnes = currentNumberOfOnes;
                    decimalNumberWithTheMostOnes = decimalNumbers[currentBinaryNumber];
                    binaryNumberWithTheMostOnes = i_binaryNumbers[currentBinaryNumber];
                }
            }

            Console.WriteLine(string.Format("\nThe number with the most ones in it is: {0} ({1})", decimalNumberWithTheMostOnes, binaryNumberWithTheMostOnes));

        }

        static private void printTotalNumberOfOnes(string[] i_binaryNumbers)
        {
            int totalNumberOfOnes = 0;

            for (int currentBinaryNumber = 0; currentBinaryNumber < i_binaryNumbers.Length; currentBinaryNumber++)
            {
                totalNumberOfOnes += calculateNumberOfOnesInABinaryNumber(i_binaryNumbers[currentBinaryNumber]);
            }


            Console.WriteLine("The total number of ones is: " + totalNumberOfOnes);
        }
    }
}
