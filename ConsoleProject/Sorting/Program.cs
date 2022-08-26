using System;

namespace AIE
{
    class Program
    { 
        static void Main()
        {
            int[] test1 = { 0, 1, 2, 3 };
            int[] test2 = { 2, 4, 8, 16, 32, 64 };
            int[] test3 = { 33, 74, 52, 9 };

            Console.WriteLine(sumNumbers(test1));
            Console.WriteLine(sumNumbers(test2));
            Console.WriteLine(sumNumbers(test3));

        }

        //given an array of integers, return the sum of all elements of the array
        static int sumNumbers(int[] numbers)
        {
            int sum = 0;
            foreach (int i in numbers)
            {
                sum += i;
            }
            return sum;
        }

        //given an array, sort in descending order
        static void sortDescending(int[] numbers)
        {
            //compare first value to next value,
            //  if, value 1 < val 2, swap
            //  otherwise, move to next pair
            //iterate until the loop is ordered properly
        }
    }
}
