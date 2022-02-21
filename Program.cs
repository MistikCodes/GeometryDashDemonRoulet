using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyD_demonRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            //fields
            string[] _demons = new string[100];
            int[] _procent = new int[100];
            int _keuze = 0;
            bool _loop = true;
            bool _loop2 = true;
            Random rnd = new Random();

            //looks
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //program
            Console.Clear();
            Console.Write("Welcome to Mistik's Demon Roulet terminal Aplication." +
                "\nUse Controll+the scroll wheel to enlarge this text untill its visible!" +
                "\nPress enter to continue to the main menu");
            Console.ReadKey();
            do
            {
                //clear screen
                Console.Clear();

                Console.Write("1) add new demon" +
                    "\n2) view demons in the roullet" +
                    "\n3) roll the roullet" +
                    "\n4) delete all items in roulet" +
                    "\n5) shut down aplication (warning all settings will be delted)");
               try
                {
                    Console.WriteLine("\n\nType your choice and be sure to press enter!\n\n");
                    Console.Write("Your choice: ");
                    _keuze = int.Parse(Console.ReadLine());
                }
               catch
                {
                    //clear screen
                    Console.Clear();

                    //error code
                    Console.Write("You didn't enter a number press enter to try again.");
                    Console.ReadKey();
                }
            if (_keuze == 1)
                {
                    if (CheckEmptySpot() != -1 )
                    {
                        //clear screen
                        Console.Clear();
                        Console.Write("you picked to add a demon\n");
                        int ontvPlaats = CheckEmptySpot();
                        Console.Write("What demon would you like to add: ");
                        string demon = "";
                        demon = Console.ReadLine();
                        SaveData(ontvPlaats,demon);
                    }
                    else
                    {
                        //clear screen
                        Console.Clear();
                        //no empty spot error
                        Console.Write("There are no empty spots to save a demon in, \n" +
                            "delete the list or a list item to be able to save more\n" +
                            "Press enter to contiue.");
                        Console.ReadKey();
                    }
                }
            if (_keuze == 2)
                {
                    //clear screen
                    Console.Clear();

                    string fullList = "";
                    fullList = ReadAndSendAllData();
                    Console.WriteLine("You picked the option to vieuw the list" +
                        "\nthe current demons in your roulet are listed below");
                    Console.WriteLine("\n"+fullList);
                    Console.WriteLine("\nPress enter to return to the main menu");
                    Console.ReadKey();
                }
            if (_keuze == 3)
                {
                    _loop2 = true;
                    do
                    {

                        //clear screen
                        Console.Clear();

                        Console.WriteLine("Rolling random demon...");
                        string randomDemon = pickRandomDemon();
                        if (randomDemon != null)
                        {
                            Console.WriteLine("your random Demon is {0}", randomDemon);
                            Console.Write("\nProcent you achieved: ");
                                Console.ReadLine();


                        }
                        else
                        {
                            Console.WriteLine("There are no demons pressent in the roulet.\npress enter to return to the main menu");
                            _loop2 = false;
                            Console.ReadKey();
                        }
                        
                    }
                    while (_loop2 == true);
                }
            
            
            
            } while (_loop == true);

            //functions
            int CheckEmptySpot()
            {
                int answer = -1;
                for (int i = 0; i < _demons.Count(); i++)
                {
                    if (_demons[i] == null)
                    {
                        answer = i;
                        break;
                    }
                }
                return answer;
            }
            void SaveData(int ontPlaats, string saveDemon)
                {
                    _demons[ontPlaats] = saveDemon;
                }
            string ReadAndSendAllData()
            {
                string answer = null;
                for (int i = 0; i < _demons.Count(); i++)
                {
                    if (_demons[i] != null)
                    {
                        answer = _demons[i] + ", " + answer;
                    }
                }
                if (answer == null)
                {
                    answer = "there are none currently in the list";
                }
                return answer;
            }
            string pickRandomDemon()
            {
                string answer = null;
                int x = 0;
                x = rnd.Next(0, _demons.Count());
                for (int i = 0; i < _demons.Count(); i++)
                {
                    if (_demons[i] != null)
                    {
                        if (i == x)
                        {
                            answer = _demons[i];
                            break;
                        }
                        
                    }
                }
                return answer;
            }




            }
        }
    }

