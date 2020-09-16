using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            // int nY
            // compile time error: missing semicolon
            int nY;
            int nAnswer;

            // Console.WriteLine(This program calculates x ^ y.);
            // compile time error: missing quotations
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                // Console.ReadLine();
                // compile time error: sNumber not set equal to ReadLine() so it is undeclared
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            /* do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
                // } while (int.TryParse(sNumber, out nX));
                // logical error: nX already declared in first do...while loop, should be nY
            } while (!int.TryParse(sNumber, out nY)); */
            // logic error: missing way to stop user from inputting negative number
            do
            {
                do
                {
                    Console.Write("Enter a positive whole number for y: ");
                    sNumber = Console.ReadLine();
                } while (!int.TryParse(sNumber, out nY));
            } while (nY < 0);
            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            // Console.WriteLine("{nX}^{nY} = {nAnswer}");
            // logic error: does not display inputs and answer correctly
            Console.WriteLine("{0}^{1} = {2}", nX, nY, nAnswer);
        }


        // int Power(int nBase, int nExponent)
        // compile time error, Power function needs to be static
        static int Power(int nBase, int nExponent)
        {
            int returnVal;
            // int nextVal;
            // compile time error: nextVal needs to be double for Math.Pow
            double nextVal;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                returnVal = 0;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                // nextVal = Power(nBase, nExponent + 1);
                // run time error: cannot call Power in Power function, creates infinite loop
                // run time error: nExponent should be - 1 not + 1
                nextVal = Math.Pow((double)nBase, ((double)nExponent - 1));
                // multiply the base with all subsequent values
                // returnVal = nBase * nextVal;
                // compile time error: need to parse back into int for returnVal
                returnVal = (int)(nBase * nextVal);
            }

            // returnVal;
            // compile time error: does not return value
            return returnVal;
        }
    }
}
