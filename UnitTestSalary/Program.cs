using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSalary
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Calling functions
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt user for name
        //          If correct name, call function to give them a raise
        // Restrictions: None
        static bool raise = false;
        // placed here to be used in function and main program
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            Console.Write("What is your name?");
            sName = Console.ReadLine();
            // gets name from user
            GiveRaise(sName, ref dSalary);
            // calls function then tests if raise has been changed
            if (raise == true)
            {
                Console.WriteLine("Congratulations! You have eanred a raise, your new salary is " + dSalary);
            }
            else
            {
                Console.WriteLine("You did not qualify for a raise.");
            }
        }
        static bool GiveRaise(string name, ref double salary)
        {
            string validName = "Bryan";
            if(name == validName)
            {
                salary += 19999.99;
                return raise = true;
            }
            else
            {
                return raise = false;
            }
        }
    }
}
