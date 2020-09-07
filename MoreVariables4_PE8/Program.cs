using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreVariables4_PE8
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Inserting double quotes
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Take a string world and split it up
        //          Add double quotes around the word and put the string back together
        // Restrictions: None
        static void Main(string[] args)
        {
            string quotes = "Put quotes around each word";
            string finalResult = String.Empty;

            var words = quotes.Split(' ');

            foreach (var word in words)
            {
                string tempWord = word;
                tempWord = '"' + word + '"';
                finalResult += tempWord;
            }

            Console.WriteLine(finalResult);
        }
    }
}
