using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lastname_PE1
{
    // Class: Program
    // Author: Bryan Taber
    // Purpose: Console Write and Integer Test
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Test printing general phrase and name
        //          Test adding and writing integers
        // Restriction: None
        static void Main(string[] args)
        {
            // Prints Hello World
            Console.WriteLine("Hello World!");
            // Prints Name
            Console.WriteLine("Bryan Taber");
            // Creating two integers and adding together, printing result
            int one = 1;
            int two = 2;
            int result = one + two; // Should print as 3
            Console.WriteLine(result);
        }
    }
}
