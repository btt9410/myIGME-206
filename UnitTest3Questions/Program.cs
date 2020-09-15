using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UnitTest3Questions
{
    class Program
    {
        static Timer time;

        static bool timeOut = false;

        static void Main(string[] args)
        {
            string question;
            string userAnswer;
            string play;
            string answer1 = "black";
            string answer2 = "42";
            string answer3 = "What do you mean? African or European swallow?";

            bool playAgain = true;
            bool timeOut = false;
            bool valid = false;

        start:
            do
            {
                time = new Timer(5000);
                ElapsedEventHandler outOfTime;
                outOfTime = new ElapsedEventHandler(TimesUp);
                time.Elapsed += outOfTime;
                Console.Write("Choose your question (1-3) >> ");
                question = Console.ReadLine();
                if (question == "1")
                {
                    Console.WriteLine("You have five seconds to answer the following question:");
                    Console.WriteLine("What is your favorite color?");
                    time.Start();
                    userAnswer = Console.ReadLine();
                    time.Stop();
                    if (userAnswer == answer1)
                    {
                        Console.WriteLine("Well done!");
                    }
                    else if (userAnswer != answer1 || timeOut == true)
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer1);
                    }
                }
                else if(question == "2")
                {
                    Console.WriteLine("You have five seconds to answer the following question:");
                    Console.WriteLine("What is the answer to life, the universe and everything?");
                    time.Start();
                    userAnswer = Console.ReadLine();
                    time.Stop();
                    if (userAnswer == answer2)
                    {
                        Console.WriteLine("Well done!");
                    }
                    else if (userAnswer != answer1 || timeOut == true)
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer2);
                    }

                }
                else if(question == "3")
                {
                    Console.WriteLine("You have five seconds to answer the following question:");
                    Console.WriteLine("What is the airspeed of an unladen swallow?");
                    time.Start();
                    userAnswer = Console.ReadLine();
                    time.Stop();

                    if (userAnswer == answer3)
                    {
                        Console.WriteLine("Well done!");
                    }
                    else if (userAnswer != answer1 || timeOut == true)
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer3);
                    }

                }
                else
                {
                    goto start;
                }
                do
                {
                    Console.Write("Play again? ");
                    play = Console.ReadLine();
                    play = play.ToLower();
                    if (play == "yes")
                    {
                        valid = true;
                        playAgain = true;
                    }
                    else if(play == "no")
                    {
                        valid = true;
                        playAgain = false;
                    }
                    else
                    {
                        valid = false;
                    }
                } while (!valid);

            } while (playAgain == true);
        }
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time's Up!");
            Console.WriteLine("Please press enter.");
            timeOut = true;
        }
    }
}
