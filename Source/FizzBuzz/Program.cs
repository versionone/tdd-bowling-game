using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            const int start = 1;
            const int end = 100;
            int threeRemainder = 0;
            int fiveRemainder = 0;

            for (int index = start; index <= end; index++)
            {
                Math.DivRem(index, 3, out threeRemainder);
                Math.DivRem(index, 5, out fiveRemainder);

                if (threeRemainder == 0 && fiveRemainder == 0)
                {
                    WriteMatch(index, "FizzBuzz");
                }
                else if (threeRemainder == 0)
                {
                    WriteMatch(index, "Fizz");
                }
                else if (fiveRemainder == 0)
                {
                    WriteMatch(index, "Buzz");
                }
                else
                {
                    // intentionally left blank
                }

            }

            Console.ReadKey();
        }

        private static void WriteMatch(int index, string message)
        {
            Console.WriteLine(string.Format("{0}: {1}", index, message));
        }
    }
}
