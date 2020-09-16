using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSalaryStruct
{
    class Program
    {
        static bool valid = false;
        struct employee
        {
            public string sName;
            public double dSalary;
        }
        static bool GiveRaise(employee user)
        {
            string validName = "Bryan";
            if(validName == user.sName)
            {
                user.dSalary += 19999.99;
                return valid = true;
            }
            else
            {
                return valid = false;
            }
        }
        static void Main(string[] args)
        {
            employee test = new employee();
            test.dSalary = 30000;
            Console.Write("Enter your name >> ");
            test.sName = Console.ReadLine();
            GiveRaise(test);
            if(valid == true)
            {
                Console.WriteLine("Congratulations! You have earned a raise, your new salary is " + test.dSalary);
            }
            else
            {
                Console.WriteLine("You did not earn a raise.");
            }
        }
    }
}
