using System;

/*
 *  Brandon Eiler 8 / 26 / 2022 Intro to C# Assessment
 *  Task 1: Introductory Exercises
 */
namespace AIE
{
    class Program
    {
        static void Main()
        {
            

            //TODO add user input
            Console.WriteLine(AddNumbers(1.1f, 3.89f));
            //should output 4 even though the float sum is 4.99f

            Fibonacci();

            FizzBuzz();

        }
        //Exercise 1: Adding Two Numbers
        /*  
            Determine the integer floor of the sum of two floating point numbers.
            The floor function is the function that takes as input a real number x, and gives as output the greatest integer less than or equal to x.
            Create a function called AddNumbers that accepts two parameters of type float, and returns an integer.
            Example:
            floor(1.1 + 3.89) = floor(4.99) = 4 
        */
        static int AddNumbers(float x, float y)
        {
            //cast the sum of x and y to type int
            return (int)(x + y);
        }

        //Exercise 2: Fibonacci
        /*
            The Fibonacci numbers are a sequence of numbers where each number after the first two is a sum of the prior two. 
            As an illustration, here is a short sequence given starting values of (0, 1):
            Fibonacci series =  (0, 1, 1, 2, 3, 5, 8, 13)
            Given an integer n, calculate the first n numbers in the Fibonacci sequence given starting elements of (0, 1). 
            Print out n integers, including the given (0, 1) in the sequence.
         */
        static void Fibonacci()
        {
            string output = "";
            int length = 0;
            Console.WriteLine("How long would you like the fibonacci sequence to run for?");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out length);
            int[] fibSequence = new int[length];
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    fibSequence[i] = 0;
                }
                else if (i == 1)
                {
                    fibSequence[i] = 1;
                }
                else
                {
                    fibSequence[i] = fibSequence[i - 1] + fibSequence[i - 2];
                }
                output += ((fibSequence[i]) + " ");
            }
            Console.WriteLine(output);
        }

        //Exercise 3: FizzBuzz
        /* 
            Given a number n, for each integer i in the range from 1 to n inclusive, print one value per line as follows:

                >If i is a multiple of both 3 and 5, print FizzBuzz.
                >If i is a multiple of 3 (but not 5), print Fizz.
                >If i is a multiple of 5 (but not 3), print Buzz.
                >If i is not a multiple of 3 or 5, print the value of i.
            The function must print the appropriate response for each value i in the set {1, 2, ... n} in ascending order, each on a separate line.
         */
        static void FizzBuzz()
        {
            int startingNumber = 1;
            int endingNumber = -1;
            int arrayLength = 0;

            Console.WriteLine("Please provide an ending number: ");
            string userInput = Console.ReadLine();
            int.TryParse((string)userInput, out endingNumber);

            arrayLength = (endingNumber - startingNumber) + 1;
            int[] fizzBuzzArray = new int[arrayLength];
            for (int i = 0; i < fizzBuzzArray.Length; i++)
            {

                fizzBuzzArray[i] = startingNumber + i;
                if (fizzBuzzArray[i] % 3 == 0 && fizzBuzzArray[i] % 5 == 0)
                {
                    Console.Write("FizzBuzz ");
                }
                else if (fizzBuzzArray[i] % 3 == 0)
                {
                    Console.Write("Fizz ");
                }
                else if (fizzBuzzArray[i] % 5 == 0)
                {
                    Console.Write("Buzz ");
                }
                else
                {
                    Console.Write(fizzBuzzArray[i] + " ");
                }
            }
        }
    }
}
