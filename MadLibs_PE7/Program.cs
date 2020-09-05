using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Schema;

namespace MadLibs_PE7
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Testing string split and replace methods
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt user for entries in Mad Libs
        //          Use split and replace methods to place entries in story
        //          Display the result
        // Restrictions: None
        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;

            string userName;
            string iChoice;
            string userPrompt;
            string resultString = null;
            string wantToPlay;

            // value for if user made the proper input to choose a Mad Lib
            bool valid = false;
            bool valid2 = false;

            do
            {
                Console.Write("Do you want to play Mab Libs? (Type only yes or no) >> ");
                wantToPlay = Console.ReadLine();
                // .toLower makes it so that regardless of how the user typed yes or no, the system will recognize it
                wantToPlay = wantToPlay.ToLower();
                if (wantToPlay == "yes")
                {
                    valid2 = true;
                }
                else if(wantToPlay == "no")
                {
                    Console.WriteLine("Goodbye.");
                    // Environment.Exit(0) ends the program
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please type only yes or no, try again.");
                    // resets the loop
                    valid2 = false;
                }
            }while(valid2 == false);

            // prompts user for their name
            Console.Write("What is your name? >> ");
            userName = Console.ReadLine();

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();

            // prompt the user for which Mad Lib they want to play (nChoice)
            do
            {
                Console.Write("Which Mad Lib do you want to play? (Select between 0 and 5) >> ");
                iChoice = Console.ReadLine();
                try
                {
                    nChoice = int.Parse(iChoice);
                    // if a number between 1 and 6 is not selected, the user will be reprompted
                    if (nChoice > 5 || nChoice < 0)
                    {
                        Console.WriteLine("Please select between 0 and 5.");
                        valid = false;
                    }
                    else
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.WriteLine("That is not a valid Mad Lib selection, please try again.");
                    valid = false;
                }
            } while (valid == false);
            
            // split the Mad Lib into separate words
            string[] words = madLibs[nChoice].Split(' ');

            foreach (string word in words)
            {
                // if word is a placeholder
                // prompt the user for the replacement
                // and append the user response to the result string
                if (word.StartsWith("{"))
                {
                    // word cannot be changed as its a foreach variable, so tempWord must be declared
                    string tempWord = word.Replace('_', ' ');
                    tempWord = tempWord.Trim('{', '}', ',');
                    Console.Write("Enter a " + tempWord + ": ");
                    userPrompt = Console.ReadLine();
                    resultString += userPrompt + " ";
                }
                // else append word to the result string
                else
                {
                    resultString += word + " ";
                }
            }
            Console.WriteLine(resultString);
        }
    }
}