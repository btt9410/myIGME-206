using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Timers;

namespace DontDie_PE22
{
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }
    class Program
    {
        public static Timer timer;

        public static bool timeOut = false;
        static bool[,] neighborGraph = new bool[,]
        {//            A      B      C      D      E      F      G     H
        /* A (0) */ { true, false, false, false, false, false, false, false },
        /* B (1) */ { true, false, true, true, false, false, false, false },
        /* C (2) */ { false, true, false, true, false, false, false, false },
        /* D (3) */ { false, true, false, false, false, false, false, false },
        /* E (4) */ { false, false, false, true, false, false, false, false },
        /* F (5) */ { false, false, false, true, true, false, false, false },
        /* G (6) */ { false, false, false, false, false, true, false, false },
        /* H (7) */ { false, false, true, false, false, false, true, false }
        };

        static int[][] neighborList = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 2, 3 },
            new int[] { 1, 7 },
            new int[] { 1, 2, 4, 5 },
            new int[] { 5 },
            new int[] { 6 },
            new int[] { 7 },
            null
        };


        static int[,] costGraph = new int[,]
        {//            A   B   C   D   E   F   G   H
        /* A (0) */ {  0, -1, -1, -1, -1, -1, -1, -1 },
        /* B (1) */ {  2, -1,  2,  3, -1, -1, -1, -1 },
        /* C (2) */ { -1,  2, -1,  5, -1, -1, -1, -1 },
        /* D (3) */ { -1,  3, -1, -1, -1, -1, -1, -1 },
        /* E (4) */ { -1, -1, -1,  2, -1, -1, -1, -1 },
        /* F (5) */ { -1, -1, -1,  4,  3, -1, -1, -1 },
        /* G (6) */ { -1, -1, -1, -1, -1,  1, -1, -1 },
        /* H (7) */ { -1, -1, 20, -1, -1, -1,  2, -1 }
        };
        static int[][] costList = new int[][]
        {
            new int[] { 0, 2 },
            new int[] { 2, 3 },
            new int[] { 2, 20 },
            new int[] { 3, 5, 2, 4 },
            new int[] { 3 },
            new int[] { 1 },
            new int[] { 2 },
            null
        };


        static string[,] directionGraph = new string[,]
        {//              A       B         C        D         E       F       G     H
        /* A (0) */ {"North",    null,    null,    null,    null,   null,    null, null},
        /* B (1) */ {"South",    null, "North",  "West",    null,   null,    null, null},
        /* C (2) */ {   null, "South",    null, "South",    null,   null,    null, null},
        /* D (3) */ {   null,  "East",    null,    null,    null,   null,    null, null},
        /* E (4) */ {   null,    null,    null, "North",    null,   null,    null, null},
        /* F (5) */ {   null,    null,    null,  "East", "South",   null,    null, null},
        /* G (6) */ {   null,    null,    null,    null,    null, "East",    null, null},
        /* H (7) */ {   null,    null,  "East",    null,    null,   null, "South", null}
        };
        static string[][] directionList = new string[][]
        {
            new string[] { "North", "South" },
            new string[] { "South", "East" },
            new string[] { "North", "East" },
            new string[] { "West", "South", "North", "East" },
            new string[] { "South" },
            new string[] { "East" },
            new string[] { "South" },
            null
        };
        static void Main(string[] args)
        {
            Random rand = new Random();

            int numState;
            string userState;

            string url;
            string s;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            string desiredState;

            int playerHealth = 1;

            numState = 0;
            userState = "A";

            while (numState != 7)
            {
                switch (numState)
                {
                    case 0:
                        {
                            Console.WriteLine("You are in a dark room, the walls seem to be made of dirt and stone.");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("You are in a damp room, there is a small pool of water in the center.");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("You are in a flooded room, the water is up to your ankles.");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("You are in a cold room, the floor seems quite slippery.");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("You are in a room full of ice, there are icicles on the ceiling, watch out.");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("You are in a room made of what looks to be sand. The air is getting warmer.");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("You are in a heated room, you can see hot charcoals on the ground.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You are in a dark room, the walls seem to be made of dirt and stone.");
                            break;
                        }
                }
                if (numState != 0)
                {
                    if (playerHealth <= 1)
                    {
                        Console.WriteLine("Current Health: " + playerHealth);
                    }
                    else
                    {
                        playerHealth -= rand.Next(2, 6);
                        Console.WriteLine("You are attacked by a small bat. You fend it off but lose health. Current Health: " + playerHealth);
                    }
                }
                List<string> dList = null;
                List<int> cList = null;
                bool valid = false;
                for (int x = 0; x < neighborGraph.Length; x++)
                {
                    if (neighborGraph[numState, x] != false)
                    {
                        if (playerHealth - 1 > costGraph[numState, x])
                        {
                            Console.WriteLine("You see a door to the " + directionGraph[numState, x]);
                            dList.Add(directionGraph[numState, x]);
                            cList.Add(costGraph[numState, x]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You cannot see any doors.");
                    }
                }

                while (!valid)
                {
                    Console.WriteLine("Do you want to travel to a different room or wager HP on a trivia question to potentially see more doors? (Type 'travel' to move, 'trivia' for wager) ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "travel")
                    {
                        valid = true;
                        bool validTravel = false;
                        while(validTravel == false)
                        {
                            Console.WriteLine("Which direction do you want to travel to? ");
                            desiredState = Console.ReadLine();
                            if (dList.Contains(desiredState))
                            {
                                validTravel = true;
                                playerHealth -= cList[dList.IndexOf(desiredState)];
                                dList.Clear();
                                cList.Clear();
                                userState = desiredState;
                                switch(userState)
                                {
                                    case "A":
                                        numState = 0;
                                        break;
                                    case "B":
                                        numState = 1;
                                        break;
                                    case "C":
                                        numState = 2;
                                        break;
                                    case "D":
                                        numState = 3;
                                        break;
                                    case "E":
                                        numState = 4;
                                        break;
                                    case "F":
                                        numState = 5;
                                        break;
                                    case "G":
                                        numState = 6;
                                        break;
                                    case "H":
                                        numState = 7;
                                        break;
                                    default:
                                        numState = 0;
                                        break;
                                }
                            }
                            else
                            {
                                validTravel = false;
                                Console.WriteLine("That is not a valid selection, please try again.");
                            }
                        }
                    }
                    else if (choice.ToLower() == "trivia")
                    {
                        valid = true;
                        bool validWager = false;
                        while(validWager == false)
                        {
                            Console.WriteLine("How much would you like to wager? ");
                            string sWager = Console.ReadLine();
                            int wager = int.Parse(sWager);
                            if (wager > playerHealth)
                            {
                                Console.WriteLine("Your wager is too high. Your current health is " + playerHealth);
                                validWager = false;
                            }
                            else
                            {
                                validWager = true;
                                url = "https://opentdb.com/api.php?amount=1";

                                request = (HttpWebRequest)WebRequest.Create(url);
                                response = (HttpWebResponse)request.GetResponse();
                                reader = new StreamReader(response.GetResponseStream());
                                s = reader.ReadToEnd();
                                reader.Close();

                                Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

                                trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                                trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

                                for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
                                {
                                    trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                                }
                                Console.WriteLine(trivia.results[0].question);
                                List<string> answerList = null;
                                answerList.Add(trivia.results[0].incorrect_answers.ToString());
                                answerList.Add(trivia.results[0].correct_answer.ToString());
                                for(int x = rand.Next(0, 4); x < answerList.Count; x++)
                                {
                                    Console.WriteLine((x + 1) + ": " + answerList[x]);
                                    if(x >= 3)
                                    {
                                        x = 0;
                                    }
                                }
                                Console.WriteLine("You have 15 seconds to select an answer.");
                                string userAnswer = Console.ReadLine();
                                while (timeOut == false)
                                {
                                    timer.Elapsed += new ElapsedEventHandler(OutOfTime);
                                    timer.Start();
                                    userAnswer = Console.ReadLine();
                                    timer.Stop();
                                }
                                if (userAnswer == trivia.results[0].correct_answer)
                                {
                                    playerHealth = wager * 2;
                                }
                                else
                                {
                                    playerHealth -= wager;
                                }
                            }
                        
                        }
                    }
                    else
                    {
                        valid = false;
                        Console.WriteLine("That is not a valid selection.");
                    }
                }
                if (playerHealth <= 0)
                {
                    Console.WriteLine("You have died.");
                    break;
                }
            }
            if (playerHealth > 0)
            {
                Console.WriteLine("Congratulations, you've won!");
            }
        }
        public static void OutOfTime(object source, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Your time is up!");

            timeOut = true;
            timer.Stop();
        }
    }
}