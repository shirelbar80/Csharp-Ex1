using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            int sizeFromUser;
            while (true)
            {
                Console.WriteLine("Enter tree size (4-15)");
                string input = Console.ReadLine();
                bool v_isValid = int.TryParse(input, out sizeFromUser);
                bool v_isInRange = sizeFromUser >= 4 && sizeFromUser <= 15;

                if (v_isValid && v_isInRange)
                {
                    break;
                }

                Console.WriteLine("Invalid input, enter size again");
            }

            int maxRowIndex = sizeFromUser - 3;
            int currentNum = 1;
            Ex01_02.Program.PrintTree(ref currentNum, maxRowIndex);
        }
    }
}
