using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Variables_PE3
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Variable and parsing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Get four numbers from user
        //          Convert numbers in strings to integers
        //          Multiply four integers together and display result
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare four string inputs
            string input1;
            string input2;
            string input3;
            string input4;
            // declare four integer values, 0 for placeholder values
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;
            // boolean for the loop
            bool valid = false;
            do
            {
                // four console lines that prompt user for their integer values, assigning values to input
                Console.WriteLine("Please enter a valid integer: ");
                input1 = Console.ReadLine();
                Console.WriteLine("Please enter a second valid integer: ");
                input2 = Console.ReadLine();
                Console.WriteLine("Please enter a third valid integer: ");
                input3 = Console.ReadLine();
                Console.WriteLine("Please enter a fourth valid integer: ");
                input4 = Console.ReadLine();
                try
                {
                    // attempt to convert inputs to corresponding ints, if convert doesn't work throws to catch
                    number1 = Convert.ToInt32(input1);
                    number2 = Convert.ToInt32(input2);
                    number3 = Convert.ToInt32(input3);
                    number4 = Convert.ToInt32(input4);
                    valid = true;
                }
                catch
                {
                    // reprompts user
                    Console.WriteLine("Please enter a valid integer for all four inputs.");
                    valid = false;
                }
            } while (valid == false);
            // after loop all values should be valid, can multiply to get final result
            Console.WriteLine("The product of your inputs is: " + (number1 * number2 * number3 * number4));
        }
    }
}
