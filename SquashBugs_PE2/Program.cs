using System;

namespace SquashBugs_PE2
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // int i = 0
            // compile time error: no semi colon
            int i = 0;

            // declare string to hold all numbers
            string allNumbers = null;

            // loop through the numbers 1 through 10
            for (i = 1; i < 10; ++i)
            {
                // declare string to hold all numbers
                // string allNumbers = null;
                // compile time error: allNumbers cannot be found if it's declared within the loop, moved to before the loop (line 24)


                // output the calculation based on the number
                // Console.WriteLine(i / (i - 1));
                // runtime error: first loop divides by 0
                if (i == 1)
                {
                    // output explanation of calculation
                    Console.Write(i + " / " + i + " = ");
                    Console.WriteLine(i - 1);
                }
                else
                {
                    // output explanation of calculation
                    // Console.Write(i + "/" + i - 1 + " = ");
                    // compile time error: missing quotation marks and parantheses
                    Console.Write(i + "/ (" + i + " - 1) " + " = ");
                    Console.WriteLine(i / (i - 1));
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // i = i + 1;
                // logic error: no need to increment the counter, already does so in for loop
            }

            // output all numbers which have been processed
            // Console.WriteLine("These numbers have been processed: " allNumbers);
            // compile time error: plus sign needed
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
