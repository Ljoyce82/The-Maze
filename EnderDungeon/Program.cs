using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EnderDungeon
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
                                                                                                                      
                                                                                                                      
                                                                                                                      
                                                                                                                      
                                                                                                                      
                                                                                                                      
                                                                                                                      
                                                                                                                      
                                                                                                                      
░▒▓████████▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░       ░▒▓██████████████▓▒░   ░▒▓██████▓▒░  ░▒▓████████▓▒░ ░▒▓████████▓▒░ 
   ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░              ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        
   ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░              ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░      ░▒▓██▓▒░  ░▒▓█▓▒░        
   ░▒▓█▓▒░     ░▒▓████████▓▒░ ░▒▓██████▓▒░         ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░    ░▒▓██▓▒░    ░▒▓██████▓▒░   
   ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░              ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓██▓▒░      ░▒▓█▓▒░        
   ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░              ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
   ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░       ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░ ░▒▓████████▓▒░ 
                                                                                                                      
                                                                                                                      
");

            Console.WriteLine("Please name your character: ");

            currentPlayer.name = Console.ReadLine();

            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You awake in a dark cold stone room, you feel dazed and are having trouble remembering\n anything about your past.");

            if (currentPlayer.name == "")
            {
                Console.WriteLine("You can not even remember your own name...");
                Program.currentPlayer.name = "Nobody";
            }
            else
            {
                Console.WriteLine($"You know your name is {currentPlayer.name}");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness till you feel what seems to be a old wooden door with iron handle.\nYou tug with all your strength and door seems to fight you as you pull and strain." +
                "The door opens\nand your eyes adjust to the dim light givin off by the torch in the corner. You grab the torch and\nnotice the door closed behind you on it's own" +
                " you turn around again to try to come to grips how you\ngot here but mind is foggy and nothing is coming back to you. Just then you hear " +
                "what sounds like\nrunning water..As you look down the corridor squinting to see what it is.You seem to make small\nhuminoid figure in the hallway to your left taking a piss on the wall. Goblin you would know that smell anywhere!");
        }


    }
}
