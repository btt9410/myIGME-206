using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            // four strings that will be converted to the four doubles
            string icInput1, icInput2, rcInput1, rcInput2;
            double icDouble1 = 0;
            double icDouble2 = 0;
            double rcDouble1 = 0;
            double rcDouble2 = 0;
            // boolean variables to end loops 
            bool valid1 = false;
            bool valid2 = false;
            do
            {
                do
                {
                    // prompt user for start and end values of imagCoord
                    Console.WriteLine("Enter a start value for imagCoord. Start value must be larger than end value.");
                    icInput1 = Console.ReadLine();
                    Console.WriteLine("Enter a end value for imagCoord. End value must be smaller than start value.");
                    icInput2 = Console.ReadLine();
                    // prompt user for start and end values of realCoord
                    Console.WriteLine("Enter a start value for realCoord. Start value must be smaller than end value.");
                    rcInput1 = Console.ReadLine();
                    Console.WriteLine("Enter a end value for realCoord. End value must be larger than small value.");
                    rcInput2 = Console.ReadLine();
                    try
                    {
                        // parses inputs to doubles
                        icDouble1 = Double.Parse(icInput1);
                        icDouble2 = Double.Parse(icInput2);
                        rcDouble1 = Double.Parse(rcInput1);
                        rcDouble2 = Double.Parse(rcInput2);
                        valid1 = true;
                    }
                    catch
                    {
                        // resets loop if the double values are not valid
                        Console.WriteLine("Enter valid double values for the start and end values.");
                        valid1 = false;
                    }
                } while (valid1 = false);
                // tests to make sure that double values will work in for loops
                // icDouble1 must have a greater value than icDouble2, rcDouble1 must have a lower value than rcDouble2
                if(icDouble1 > icDouble2 && rcDouble1 < rcDouble2)
                {
                    valid2 = true;
                }
                else
                {
                    Console.WriteLine("imagCoord start value must be greater than imagCoord end value. readCoord start value must be lower than realCoord end value.");
                    valid2 = false;
                }    
            } while (valid2 == false);
            for (imagCoord = icDouble1; imagCoord >= icDouble2; imagCoord -= 0.05)
            {
                for (realCoord = rcDouble1; realCoord <= rcDouble2; realCoord += 0.03)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }
        }
    }
}