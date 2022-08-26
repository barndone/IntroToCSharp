using System;

/*
 *  Brandon Eiler 8 / 26 / 2022 Intro to C# Assessment
 *  Task 2: Exercises on Arrays
 */


namespace AIE
{
    class Program
    { 
        static void Main()
        {
            //sumNumbers() test arrays
            int[] test1 = { 0, 1, 2, 3 };
            int[] test2 = { 2, 4, 8, 16, 32, 64 };
            int[] test3 = { 33, 74, 52, 9 };

            //sortDescending() test arrays
            int[] sortTest = { 45, 6, 12, 51, 4, 23, 31, 100, 99, 1};
            int[] sortTest2 = { 1, 8, 9, 4, 0, 6, 7, 5 };

            Console.WriteLine(sumNumbers(test1));               //returns 6
            Console.WriteLine(sumNumbers(test2));               //returns 126
            Console.WriteLine(sumNumbers(test3));               //returns 168

            Console.WriteLine();

            //will sort to: 100, 99, 51, 45, 31, 23, 12, 6, 4, 1
            sortDescending(sortTest);
            foreach (int i in sortTest)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            //will sort to: 9, 8, 7, 6, 5, 4, 1, 0
            sortDescending(sortTest2);
            foreach (int i in sortTest2)
            {
                Console.Write(i + " ");
            }
        }

        //Exercise 1: Sum of Array
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

        //Exercuse 2: Sorting an Array (Descending)
        //given an array, sort in descending order
        static void sortDescending(int[] numbers)
        {   
            int temp = 0;                                                               //temp variable to reasign values as needed
            //initial traversal:
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                //for each i = 0, do a sort through the array
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    //if out of order, swap
                    if (numbers[j] < numbers[j + 1])
                    {
                        temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
                //  otherwise do nothing
            }
        }
    }
}
