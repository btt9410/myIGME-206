using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavColorNumber
{
    // Class: Program
    // Author: Bryan Taber
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favorite color (in limited text colors) their favorite number of times
        // Restrictions: None
        static void Main(string[] args)
        {
            string color;
            string strNumber;
            int number = 0;
            bool valid;
            // prompt for favorite color
            Console.Write("Enter your favorite color: \t");

            // read their favorite color from the keyboard
            color = Console.ReadLine();

            do
            {
                // prompt for favorite number
                Console.WriteLine("Enter your favorite number: \t");

                // read their favorite number from the keyboard
                strNumber = Console.ReadLine();
                try
                {
                    number = Convert.ToInt32(strNumber);
                    valid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    valid = false;
                }
            } while (!valid);
            

            // change the text color to their favorite color
            switch(color.ToLower())
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }


            // print their favorite color their favorite number of times
            for (int i = 0; i < number; ++i)
            {
                Console.WriteLine($"Your favorite color is {color + "!"}");
            }
        }
    }
}
