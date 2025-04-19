using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    public class Program
    {
        private const int k_MaxNum = 9;
        public static void Main()
        {
            int maxRowIndex = 4;
            int currentNum = 1;
            PrintTree(ref currentNum, maxRowIndex);
        }
        public static void PrintTree(ref int o_currentNum, int o_maxRowIndex)
        {
            PrintTreeRec(0, ref o_currentNum, o_maxRowIndex);
            PrintTreeTrunk(o_currentNum, o_maxRowIndex);
        }
        
        public static void PrintTreeRec(int i_currentRow, ref int io_currentNum, int io_maxRowIndex)
        {
            bool v_isCurrentRawLargerThanMaxRow = i_currentRow > io_maxRowIndex;
             char letter = (char)('A' + i_currentRow);
            int numOfSpaces = io_maxRowIndex - i_currentRow + 1;
            int amountOfNumber = i_currentRow + i_currentRow + 1;
            StringBuilder sb = new StringBuilder();

            if (v_isCurrentRawLargerThanMaxRow)
            {

                return;
            }

            sb.Append($"{letter} ");
            sb.Append(" ");
            sb.Append(new string(' ', (numOfSpaces * 2) - 1));
            for (int i = 0; i < amountOfNumber; i++)
            {
                sb.Append(io_currentNum + " ");
                io_currentNum++;
                bool v_isCurrentNumLargerThanMaxNum = io_currentNum > k_MaxNum;
                if (v_isCurrentNumLargerThanMaxNum)
                {
                    io_currentNum = 1;
                }
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine();
            PrintTreeRec(++i_currentRow, ref io_currentNum, io_maxRowIndex);
        }
        public static void PrintTreeTrunk(int io_currentNum, int io_maxRowIndex)
        {
            for (int i = 0; i < 2; i++)
            {
                char letter = (char)('A' + io_maxRowIndex + i + 1);
                int numOfSpaces = (io_maxRowIndex * 2) + 1;
                string line = $"{letter} {new string(' ', numOfSpaces)}|{io_currentNum}|";
                
                System.Console.WriteLine(line);
            }
        } 
    }
}
