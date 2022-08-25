using System;

namespace AIE
{
    class Program
    {
        static void Main (string[] args)
        {
            //in class demo
            ////arrays
            //char[] charArray = new char[5];
            //char[] charArrayFilled = { 'a', 'b', 'c', 'd', 'e' };
            ////char[] nullChar; //DONT DO THIS LOL
            //
            ////accessing arrays
            //
            //Console.WriteLine(charArray[0]);
            //charArray[0] = '1';
            //Console.WriteLine(charArray[0]);
            //
            ////loops
            ////1. intitializer
            ////2. condition
            ////3. iterator
            //
            //for (int i = 0; i < charArrayFilled.Length; i++)
            //{
            //    Console.WriteLine(charArrayFilled[i] + "this is a for loop");
            //}
            //
            //foreach (char c in charArrayFilled)
            //{
            //    Console.WriteLine(c + "this is a foreach loop");
            //}


            //favorite numbers
            string userInput = "";                                      //blank user input string for each exercise
            int userFavNumberAmount = -1;                               //blank favorite number amount initialized to -1
            int userInputCounter = 0;                                   //blank user input counter set to 0

            //prompt for number of favorite numbers
            Console.WriteLine("Hello! How many favorite numbers do you have?");
            userInput = Console.ReadLine();
            int.TryParse(userInput, out userFavNumberAmount);

            //initialize array of length equal to user specified number
            int[] favNumbers = new int[userFavNumberAmount];

            //iterate through the array
            for (int i = 0; i < favNumbers.Length; i++)
            {
                //ask for the i'th favorite number
                Console.WriteLine("What is number " + (i+1) + "?");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out favNumbers[i]);
                userInputCounter++;                                     //increment input counter

                //check if we are looking at the first entry
                if (i == 0)
                {
                    //if so, print this
                    Console.WriteLine("Your first number is " + favNumbers[i]);
                }
                //check if we are after the first entry of the array, but NOT the last entry
                else if (i > 0 && i < (favNumbers.Length - 1))
                {
                    //if so, list favorites
                    Console.Write("Your favorites have been ");
                    //if the second entry of the array
                    if (i == 1)
                    {
                        //print this
                        Console.WriteLine(favNumbers[0] + " and " + favNumbers[1] + ".");
                    }
                    //otherwise, list each entry so far separating with a comma and ending with a period
                    else
                    {
                        for (int j = 0; j < userInputCounter; j++)
                        {
                            if (j == (userInputCounter - 1))
                            {
                                Console.WriteLine(favNumbers[j] + ".");
                            }
                            else
                            {
                                Console.Write(favNumbers[j] + ", ");
                            }
                        }
                    }
                }
            }
            //print the final list of favorite numbers 
            Console.Write("Okay, your favorite numbers are: ");
            for (int f = 0; f < favNumbers.Length; f++)
            {
                if(f == favNumbers.Length-1)
                {
                    Console.WriteLine(favNumbers[f] + ".");                    
                }
                else
                {
                    Console.Write(favNumbers[f] + ", ");
                }
            }

            //fizz bizz
            //1. if the number is a multiple of three, print "Fizz"
            //2. if the number is a multiple of five, print "Buzz"
            //3. if the number is a multiple of both three and five, print "FizzBuzz"
            //4. if the number does not match any of the above conditions, then print the number
            int startingNumber = -1;
            int endingNumber = -1;
            int arrayLength = 0;

            Console.WriteLine("Please provide a starting number: ");
            userInput = Console.ReadLine();
            int.TryParse((string)userInput, out startingNumber);
            Console.WriteLine("Please provide an ending number: ");
            userInput = Console.ReadLine();
            int.TryParse((string)userInput,out endingNumber);

            arrayLength = (endingNumber - startingNumber) + 1;
            int[] fizzBuzzArray = new int[arrayLength];
            for (int i = 0; i < fizzBuzzArray.Length; i++)
            {

                fizzBuzzArray[i] = startingNumber + i;
                if (fizzBuzzArray[i]%3 == 0 && fizzBuzzArray[i]%5 == 0)
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
            Console.WriteLine();

            //Fibonacci Sequence
            //fibonacci sequence starts with 0 and 1 and then each successive value is the sum of the previous two numbers
            int fibSequenceLength = 0;
            Console.WriteLine("How long would you like the fibonacci sequence to run for?");
            userInput = Console.ReadLine();
            int.TryParse(userInput,out fibSequenceLength);
            int[] fibSequence = new int[fibSequenceLength];
            for (int i = 0;i < fibSequenceLength;i++)
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
                Console.WriteLine(fibSequence[i]);
            }

            //Grid Generator
            int gridRows = 0;
            int gridColumns = 0;
            Console.WriteLine("Please input the number of rows your grid will have: ");
            userInput = Console.ReadLine();
            int.TryParse(userInput, out gridRows);
            Console.WriteLine("Please input the number of columns your grid will have: ");
            userInput = Console.ReadLine();
            int.TryParse(userInput, out gridColumns);

            char [,] grid = new char[gridRows, gridColumns];
            for (int rows = 0; rows < gridRows; rows++)
            {
                for (int columns = 0; columns < gridColumns; columns++)
                {
                    grid[rows, columns] = 'X';
                    Console.Write(grid[rows, columns]);
                }
                Console.WriteLine();
            }

            //Higher or Lower
            //Implement and test some functionality that prompts the user to guess a randomly generated value within a
            //specified range and a given number of tries. If the user successfully guesses within the given number of
            //tries, return true.Otherwise, return false to indicate that the user failed.
            //With each guess, provide information on whether their guess was too high or too low.
            //Use the following example output to structure your function implementation.
            //Text that is prepended with a '>' character should be considered input from the user, otherwise it is a
            //message that was printed out by the console application.

            Random rnd = new Random();
            int randomNumber = rnd.Next(10);
            int currentGuess = 0;
            bool rightGuess = false;
            Console.WriteLine("Hey there!\nI'm going to generate a number between 1 and 10. you have 5 tries to guess it!");
            
            for(int guessCounter = 0; guessCounter < 5; guessCounter++)
            {
                Console.WriteLine("Round " + (guessCounter + 1) + " - Make Your Guess!");
                userInput = Console.ReadLine();
                int.TryParse (userInput, out currentGuess);
                if (currentGuess == randomNumber)
                {
                    rightGuess = true;
                    guessCounter = 5;
                }
                else if (currentGuess < randomNumber)
                {
                    Console.WriteLine("Sorry, that isn't quite it. Your guess is too low!");
                }
                else
                {
                    Console.WriteLine("Sorry, that isn't quite it. Your guess is too high!");
                }
            }
            if (rightGuess == true)
            {
                Console.WriteLine("That's it! You guessed the number!");
            }
            else
            {
                Console.WriteLine("Unfortunately you could not guess the number. The random number was: " + randomNumber);
            }
        }
    }
}
