using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Variables_PE3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1;
            string input2;
            string input3;
            string input4;

            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            int number4 = 0;

            bool valid = false;
            do
            {
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
                    number1 = Convert.ToInt32(input1);
                    number2 = Convert.ToInt32(input2);
                    number3 = Convert.ToInt32(input3);
                    number4 = Convert.ToInt32(input4);
                    valid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid integer for all four inputs.");
                    valid = false;
                }
            } while (valid == false);
            Console.WriteLine("The product of your inputs is: " + (number1 * number2 * number3 * number4));
        }
    }
}
