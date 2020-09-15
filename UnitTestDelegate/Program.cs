using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDelegate
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Using delegate to call method
    // Restrictions: None
    class Program
    {
        delegate string ConsoleRead();
        // Method: Main
        // Purpose: Declare variable for delegate
        //          Set variable to method Console.ReadLine()
        //          Display user's value
        // Restrictions: None
        static void Main(string[] args)
        {
            ConsoleRead read;
            // gives delegate the ReadLine() method
            read = new ConsoleRead(Console.ReadLine);
            Console.Write("Enter whatever you want >> ");
            // sets the entry of the user to a stringt
            string entry = read();
            Console.WriteLine("You wrote: " + entry);
        }
    }
}
