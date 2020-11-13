using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome_UT3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Console.Write("Please enter a string >> ");
            input = Console.ReadLine();

            LinkedList<object> sentence = new LinkedList<object>();
            foreach(char c in input)
            {
                sentence.AddLast(c);
            }

            string counterInput = input.ToUpper();
            counterInput = counterInput.Replace(",", "");
            counterInput = counterInput.Replace(".", "");
            counterInput = counterInput.Replace("!", "");
            counterInput = counterInput.Replace("?", "");
            counterInput = counterInput.Replace("'", "");
            counterInput = counterInput.Replace(" ", "");
            while (counterInput.Length > 0)
            {
                int counter = 0;
                for(int i = 0; i < counterInput.Length; i++)
                {
                    if(counterInput[0] == counterInput[i])
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counterInput[0] + " = " + counter);
                counterInput = counterInput.Replace(counterInput[0].ToString(), String.Empty);
            }

            string reverseInput = "";
            LinkedList<object> reverseList = new LinkedList<object>();
            LinkedListNode<object> node;

            node = sentence.Last;
            while(node != null)
            {
                reverseList.AddLast(node.Value);
                node = node.Previous;
            }

            foreach(char c in reverseList)
            {
                Console.Write(c);
                reverseInput += c;
            }
            Console.WriteLine();

            input = input.Replace(",", "");
            reverseInput = reverseInput.Replace(",", "");
            input = input.Replace(".", "");
            reverseInput = reverseInput.Replace(".", "");
            input = input.Replace("!", "");
            reverseInput = reverseInput.Replace("!", "");
            input = input.Replace("?", "");
            reverseInput = reverseInput.Replace("?", "");
            input = input.Replace("'", "");
            reverseInput = reverseInput.Replace("'", "");
            input = input.Replace(" ", "");
            reverseInput = reverseInput.Replace(" ", "");

            if (input.ToLower().Equals(reverseInput.ToLower()))
            {
                Console.WriteLine("This string is a palindrome.");
            }
        }
    }
}