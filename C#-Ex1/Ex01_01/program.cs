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
        static public void Main()
        {
            string[] binaryNumbers = new string[4];

            Console.WriteLine("Enter 4 binary numbers with 7 digits: ");

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
            double averageOfNumbers = average(decimalNumbers);
            Console.WriteLine("\nAverage: " + averageOfNumbers);

            printLargestSequenceOfOnes(binaryNumbers);

            printNumberOfTransitions(binaryNumbers);

            printBinaryNumberWithTheMostNumberOfOnes(binaryNumbers);

            printTotalNumberOfOnes(binaryNumbers);

        }

        static private bool validBinaryNumber(string io_binaryNumber) //check if the binary number is valid for the program
        {

            //check length of 7 bits
            if (io_binaryNumber.Length != 7)
            {
                return false;
            }

            //check only 0 or 1 in the string
            for (int currentBit = 0; currentBit < 7; currentBit++)
            {
                if (io_binaryNumber[currentBit] != '0' && io_binaryNumber[currentBit] != '1')
                {
                    return false;

                }
            }


            return true;

        }

        static private int[] binaryToDecimal(string[] io_binaryNumbers)
        {

            int[] decimalNumbers = new int[4];

            for (int currentBinaryNumber = 0; currentBinaryNumber < 4; currentBinaryNumber++) //for every binary number
            {
                int currentPower = 1;
                // Loop from right to left
                for (int currentBit = io_binaryNumbers[currentBinaryNumber].Length - 1; currentBit >= 0; currentBit--)
                {
                    if (io_binaryNumbers[currentBinaryNumber][currentBit] == '1')
                    {
                        decimalNumbers[currentBinaryNumber] += currentPower;
                    }

                    currentPower *= 2;
                }

            }

            return decimalNumbers;

        }//calculates the decimal values of the binary numbers

        static private double average(int[] io_decimalNumbers)
        {  //calculates the average of the array

            int sumOfNumbers = 0;

            for (int currentNumber = 0; currentNumber < io_decimalNumbers.Length; currentNumber++)
            {
                sumOfNumbers += io_decimalNumbers[currentNumber];
            }

            return (sumOfNumbers / io_decimalNumbers.Length);
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
        static private void printLargestSequenceOfOnes(string[] io_binaryNumbers)
        {
            int largestSequenceOfOnes = 0;
            string binaryNumberWithTheLargestSequenceOfOnes = io_binaryNumbers[0];

            for (int currentBinaryNumber = 0; currentBinaryNumber < io_binaryNumbers.Length; currentBinaryNumber++)//for each binary number
            {
                int currentSequenceOfOnes = 0;
                int currentLargestSequenceOfOnes = 0;

                for (int currentBit = 0; currentBit < io_binaryNumbers[currentBinaryNumber].Length; currentBit++)   //for each bit in the binary number
                {

                    //this is the first 1 or this is 1 and the one before it is 1
                    if (io_binaryNumbers[currentBinaryNumber][currentBit] == '1')
                    {
                        currentSequenceOfOnes++;

                        //change the largest if the current is bigger
                        if (currentLargestSequenceOfOnes < currentSequenceOfOnes)
                        {
                            currentLargestSequenceOfOnes = currentSequenceOfOnes;
                        }
                    }
                    else if (io_binaryNumbers[currentBinaryNumber][currentBit] == '0')  //the sequence was broken
                    {
                        currentSequenceOfOnes = 0;
                    }
                }
                //update the largest sequece and the binary number
                if (currentLargestSequenceOfOnes > largestSequenceOfOnes)
                {
                    largestSequenceOfOnes = currentLargestSequenceOfOnes;
                    binaryNumberWithTheLargestSequenceOfOnes = io_binaryNumbers[currentBinaryNumber];
                }

            }

            Console.WriteLine(string.Format("The longest sequence of ones is: {0} ({1})", largestSequenceOfOnes, binaryNumberWithTheLargestSequenceOfOnes));

        }

        static private void printNumberOfTransitions(string[] io_binaryNumbers)
        {
            int[] numberOfTransitions = new int[4];

            Console.Write("The number of transitions for each binary number: ");
            for (int currentBinaryNumber = 0; currentBinaryNumber < io_binaryNumbers.Length; currentBinaryNumber++)//for each binary number
            {
                int currentNumberOfTransitions = 0;

                for (int currentBit = 0; currentBit < io_binaryNumbers[currentBinaryNumber].Length; currentBit++)//for each bit in the binary number
                {
                    if (currentBit != 0 && io_binaryNumbers[currentBinaryNumber][currentBit - 1] != io_binaryNumbers[currentBinaryNumber][currentBit])
                    {
                        currentNumberOfTransitions++;
                    }

                }

                Console.Write(currentNumberOfTransitions + " (" + io_binaryNumbers[currentBinaryNumber] + "), ");

            }
        }

        static private int calculateNumberOfOnesInABinaryNumber(string io_binaryNumber)
        {
            int numberOfOnes = 0;

            for (int currentBit = 0; currentBit < io_binaryNumber.Length; currentBit++)
            {
                if (io_binaryNumber[currentBit] == '1')
                {
                    numberOfOnes++;
                }
            }

            return numberOfOnes;
        }

        static private void printBinaryNumberWithTheMostNumberOfOnes(string[] io_binaryNumbers)
        {
            int[] decimalNumbers = binaryToDecimal(io_binaryNumbers);  //build the decimal array

            int maxNumberOfOnes = 0;
            int decimalNumberWithTheMostOnes = decimalNumbers[0];
            string binaryNumberWithTheMostOnes = io_binaryNumbers[0];

            for (int currentBinaryNumber = 0; currentBinaryNumber < io_binaryNumbers.Length; currentBinaryNumber++)  //for each binary number
            {
                int currentNumberOfOnes = calculateNumberOfOnesInABinaryNumber(io_binaryNumbers[currentBinaryNumber]); //calculate the number of ones
                if (currentNumberOfOnes > maxNumberOfOnes)//switch if bigger than max
                {
                    maxNumberOfOnes = currentNumberOfOnes;
                    decimalNumberWithTheMostOnes = decimalNumbers[currentBinaryNumber];
                    binaryNumberWithTheMostOnes = io_binaryNumbers[currentBinaryNumber];
                }
            }

            Console.WriteLine(string.Format("\nThe number with the most ones in it is: {0} ({1})", decimalNumberWithTheMostOnes, binaryNumberWithTheMostOnes));

        }

        static private void printTotalNumberOfOnes(string[] io_binaryNumbers)
        {
            int totalNumberOfOnes = 0;

            for (int currentBinaryNumber = 0; currentBinaryNumber < io_binaryNumbers.Length; currentBinaryNumber++)
            {
                totalNumberOfOnes += calculateNumberOfOnesInABinaryNumber(io_binaryNumbers[currentBinaryNumber]);
            }


            Console.WriteLine("The total number of ones is: " + totalNumberOfOnes);
        }
    }
}
