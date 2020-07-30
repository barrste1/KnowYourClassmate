using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace _07292020_gettoknowyourclassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            int index = 0;
            while (!end)
            {
                List<string> options = new List<string>
                {
                    "Confirmed Kills",
                    "Agent Status",
                    "Agent Locations"
                };
                List<string> agents = new List<string>
                {
                    "Tommy",
                    "Anna",
                    "Stephen",
                    "Kamesha",
                    "Stephen B.",
                    "You"
                };
                index = DisplayMainMenu(agents);
                Console.Clear();
                if (index != 5)
                {
                    PrintGreen($"You have selected Agent {agents[index]}.");
                }
                else
                {
                    PrintGreen($"Getting to know yourself is very important.");
                }
                DisplayInfoMenu(options,agents[index],index);
                end = ContinuePlay("Do you wish to learn about another agent?");
            }
            DestroyMessage();
        }
        public static void PrintGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintCyan(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DestroyMessage()
        {
            Console.Clear();
            Console.WriteLine("Briefing concluded. Message will self destruct in: ");
            for (int i = 5; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(i);
                Console.Beep(600, 400);
                Thread.Sleep(600);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BOOOOOOOOOOOOM!!!!!");
            Console.Beep(250, 1000);
        }
        public static bool ContinuePlay(string message)
        {
            bool end = false;
            string cont = "";
            PrintGreen(message);
            while (cont.ToLower() != "n")
            {
                cont = Console.ReadLine().ToLower();
                if (cont == "y")
                {
                    break;
                }
                else if (cont == "n")
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter (y) or (n).");
                }
            }
            return end;
        }
        public static string GetInput(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            return input;
        }
        public static int IndexInput(string input)
        {
            int index = 6;
            if (input == "1" || input == "tommy")
            {
                Console.Clear();
                return index = 0;
            }
            else if (input == "2" || input == "anna")
            {
                Console.Clear();
                return index = 1;
            }
            else if (input == "3" || input == "stephen")
            {
                Console.Clear();
                return index = 2;
            }
            else if (input == "4" || input == "kamesha")
            {
                Console.Clear();
                return index = 3;
            }
            else if (input == "5" || input == "stephen b.")
            {
                Console.Clear();
                return index = 4;
            }
            else if (input == "6" || input == "myself")
            {
                Console.Clear();
                return index = 5;
            }
            else if (input == "you")
            {
                Console.Clear();
                PrintGreen($"You meaning yourself, correct? I'm just a computer. I'll assume you mean 'myself'. Remember that I am an advanced AI! " +
                        "\nI'll give you a moment to reflect on this. Press any key to continue. ");
                Console.ReadKey();
                Console.Clear();
                return index = 5;
            }
            else
            {
                Console.Clear();
                PrintGreen($"Not a valid input; Please input an agents name or number designation. Press any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                return index = -1;
            }
        }
        public static int DisplayMainMenu(List<string> agents)
        {
            int index;
            while (true)
            {
                PrintGreen("Welcome to MI6, 006. Included is information on all other agents. Which agent do you wish to learn more about?");
                DisplayList(agents);
                string input = GetInput("Agent Name/Number: ");
                index = IndexInput(input.ToLower());
                if (index < 6 && index > -1)
                {
                    break;
                }
            }
            return index;
        }
        public static void DisplayInfoMenu(List<string> options, string agent, int index)
        {
            bool end = false;
            int input = -1;
            List<string> kills = new List<string>
                {   "13 kills. MI6 record holder for most people disarmed with a single shot (12).",
                    "27 kills. MI6 record holder for both least casaulties and most casaulties(enemy) in a mission ",
                    "3 kills. Low kill count a result of most work taking place around HQ.",
                    "9 kills. Administrative tasks mask a true talent.",
                    "20 kills, all agents of MI6 from friendly fire. How 00 status was granted is beyond me. ",
                    "2 kills. Congratulations on your recent 00 status."
                };
            List<string> status = new List<string>
                {   "Field Agent. Tasked with carrying out missions on site and in person.",
                    "Top Undercover Agent. Expert adept at infiltration and subterfuge.",
                    "Quatermaster and Tech Expert. Every single state of the art tech we use was designed by him.",
                    "Lead Agent Liaison. Tasked with coordinating web of agent operations. Gets things done.",
                    "To be terminated. Too much of a liability. This is you mission.",
                    "Secret Agent. Newly Appointed. Show us what you're capable of."
                };
            List<string> location = new List<string>
                {   "In the Caribbean. Tasked with taking out a cult leader with a laser beam that will force everyone to dab motion constantly.",
                    "In Venice. Deep undercover to stop the largest planned bank robbery, conducted by the enterprise known as Grande Catburglars (GC).",
                    "At HQ. Currently developing a gadget which looks like a pen, but is actually a tooth brush.",
                    "In France. Thwarting a conspiracy to turn all dogs into cats.",
                    "At HQ. Often in the company hammock for a period of time that exceeds company policy.",
                    "Little Caesars. Yes, this console has GPS."
                };
            while (end == false)
            {
                DisplayList(options);
                while (!int.TryParse(GetInput($"What would you like to know about {agent}?"), out input))
                {
                    GetInput("Please enter a number (1-3). Anything else is considered rude.");
                    DisplayList(options);
                };
                if (input ==1)
                {
                    PrintCyan(kills[index]);
                }
                else if (input == 2)
                {
                    PrintCyan(status[index]);
                }
                else if (input == 3)
                {
                    PrintCyan(location[index]);
                }
                else
                {
                    PrintGreen("Not a valid input. Please enter 1-3. Press any key to continue.");
                    Console.ReadKey(); Console.Clear(); continue;
                }
                end = ContinuePlay($"Would you like to learn more about {agent}? (Y/N)");
            }
        }
        public static void DisplayList(List<string> list)
        {   
            for (int i = 0; i< list.Count; i++)
            {
                PrintCyan($"{i+1}. {list[i]}");
            }
        }
    }
}
