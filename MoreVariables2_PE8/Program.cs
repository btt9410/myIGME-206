using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreVariables2_PE8
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Reversing strings
    // Restrictions: None
    class Program
    {   
        // Method: Main
        // Purpose: Prompt user for string input
        //          Reverse the string and print the result
        // Restrictions: None
        static void Main(string[] args)
        {
            // two variables to hold the user input and the result
            string userInput;
            string reversed = "";

            // obtains input from the user
            Console.Write("Please enter a string >> ");
            userInput = Console.ReadLine();

            // takes input and changes it to char array so it can be reversed with Reverse method
            char[] charArray = userInput.ToCharArray();
            Array.Reverse(charArray);

            // puts each char back into string in for loop
            for(int x = 0; x < charArray.Length; x++)
            {
                reversed += charArray[x];
            }

            // displays result
            Console.WriteLine(reversed);
        }
    }
}
