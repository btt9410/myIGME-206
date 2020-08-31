using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FlowControl_PE4
{
	// Class Program
	// Author: Bryan Taber
	// Purpose: Testing logical expressions
	// Restrictions: None
	class Program
    {
		// Method: Main
		// Purpose: Get two values from user
		//          Test if values are greater than ten
		//          Accepts input if only one value is greater than ten
		// Restrictions: None
		static void Main(string[] args)
        {
			// two strings to get input from users, values to test
			// bools to test if one or if both are true and others to end loops
			string input1;
			string input2;
			int val1 = 0;
			int val2 = 0;
			bool valid1 = false;
			bool valid2 = false;
			bool operand1;
			bool operand2;
			bool result;
			do
			{
				// second do while loop is to make sure integers are valid before testing
				do
				{
					Console.WriteLine("Enter the first integer, only one should be greater than ten.");
					input1 = Console.ReadLine();
					Console.WriteLine("Enter the second integer, only one should be greater than ten.");
					input2 = Console.ReadLine();
					try
                    {
						// parsing the values and changing valid1 to end loop
						val1 = int.Parse(input1);
						val2 = int.Parse(input2);
						valid1 = true;
                    }
					catch
                    {
						Console.WriteLine("Please enter valid integers.");
						valid1 = false;
                    }
				} while (valid1 == false);
				if (val1 > 10)
				{
					operand1 = true;
				}
				else
				{
					operand1 = false;
				}
				if (val2 > 10)
				{
					operand2 = true;
				}
				else
				{
					operand2 = false;
				}
				// result uses exclusive or operator so it will be set to false if operand1 and operand2 are both true or false
				result = operand1 ^ operand2;
				if(result == true)
                {
					valid2 = true;
                }
				else
                {
					Console.WriteLine("One integer should be over ten, please re-enter integers.");
					valid2 = false;
                }
			} while (valid2 == false);
		}
    }
}
