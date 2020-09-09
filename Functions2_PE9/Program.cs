using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions2_PE9
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
        // Restrictions: None
        static void Main(string[] args)
        {
            ConsoleRead read;
            read = new ConsoleRead(Console.ReadLine);
        }
    }
}
