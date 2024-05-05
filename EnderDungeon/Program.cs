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
      
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();

        }

        static void Start() 
        {
            Console.WriteLine("The Maze");

            Console.WriteLine("Please name your character: ");

            currentPlayer.name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("You awake in a cold stone dark room, you feel dazed and are having trouble remembering\n anything about your past.");

            if (currentPlayer.name == "")
            {
                Console.WriteLine("You can not even remember your own name...");
            }
            else
            {
                Console.WriteLine($"You know your name is {currentPlayer.name}");
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness till you feel what seems to be a old wooden door with iron handle.\n You tug on what feels  to be the handle and door seems to fight you as you pull with all your strength.\n" +
                "The door opens and your eyes adjust to the dim light givin off by the torch in the corner.\nAs you your squint you seem to make small huminoid figure in the hallway to your left.");
        }

    }
}
