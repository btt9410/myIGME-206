using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreVariables3_PE8
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Replacing strings
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt user for string input
        //          Change all instances of no to yes
        // Restrictions: None
        static void Main(string[] args)
        {
            // variable to hold user input
            string userInput;

            // get user's input
            Console.Write("Enter a string (all instances of the word 'no' will be changed to 'yes') >> ");
            userInput = Console.ReadLine();

            // change to lowercase in case user typed 'no' in a different way
            userInput = userInput.ToLower();

            // replace the string no with yes
            userInput = userInput.Replace("no", "yes");

            // display result
            Console.WriteLine(userInput);
        }
    }
}
