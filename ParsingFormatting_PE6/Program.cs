using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ParsingFormatting_PE6
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Testing parsing and formatting
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Generate a random number (1 - 100)
        //          Give the user 8 tries to guess the number
        //          Make sure all 8 tries are valid
        // Restrictions: None
        static void Main(string[] args)
        {
            Random rand = new Random();

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);

            // variables to get users guess, the amount of tries they have and boolean to end testing if valid
            string userGuess;
            int numberGuess = 0;
            const int USER_TRIES = 7;
            bool valid = false;

            for(int x = USER_TRIES; x >= 0; x--)
            {
                do
                {
                    // do loop prompts user for guess and does not remove an attempt until guess is made
                    try
                    {
                        Console.WriteLine("Enter your guess from 1 to 100");
                        userGuess = Console.ReadLine();
                        numberGuess = int.Parse(userGuess);
                        if(numberGuess < 101 && numberGuess >= 0)
                        {
                            valid = true;
                            // ends the loop
                        }
                        else
                        {
                            // if the guess doesn't land inbetween 1 and 100, it will not count as valid
                            Console.WriteLine("The integer must be between 1 and 100. Please enter a valid integer.");
                            valid = false;
                        }
                    }
                    catch
                    {
                        // makes sure number is a valid integer before testing
                        Console.WriteLine("Please enter a valid integer.");
                        valid = false;
                    }
                } while (valid == false);

                if(numberGuess != randomNumber)
                {
                    // if and else if hint if the user is too high or too low compared to random number
                    if(numberGuess > randomNumber)
                    {
                        Console.WriteLine("Your number was too high."); 
                    }
                    else if(numberGuess < randomNumber)
                    {
                        Console.WriteLine("Your number was too low.");
                    }
                    // number of attempts left only displays when number is wrong
                    Console.WriteLine("You have " + x + " attempts left.");
                    if (x == 0)
                    {
                        // displays when user has run out of attempts
                        Console.WriteLine("You are out of attempts. The number was " + randomNumber + ".");
                    }
                }
                else
                {
                    Console.WriteLine("Your number was correct!");
                    x = 0;
                    // sets to 0 so the program does not prompt user for another guess
                }
            }
        }
    }
}
