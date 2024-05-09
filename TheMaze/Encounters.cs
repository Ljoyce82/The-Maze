using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMaze;

namespace TheMaze
{
    public class Encounters
    {
        Shop shop = new Shop();
        static Random rng = new Random();
        //Encounters Generic

        //Encounters

        public static void FirstEncounter()
        {
            Console.WriteLine();
           // Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You sneak up behind the creature and try grab it with out it noticing...");
            Console.WriteLine("The goblin turns and squalls @#$@#%$^%^! you dont speak goblin but\nknow if you don't shut it up theres always more than one! ");
            Console.ReadKey ();
            Console.Clear();
            Combat(false, "Goblin", 1, 2);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("After the fight you regain your self you grab the torch off the wall waveing it around you see.\nYour in some kind maze nothing but corridors " +
                "left and right as far as can see. You turn around\nwhere you came from moments ago but theres nothig but a wall what is this place and more importantly\nhow do you get out. Just then you hear" +
                " what sounds like bustling of market in one direction and\nsomething else in another.Like bones scraping on rocks, You press on grabbing the goblins rusty cleaver.");
            Program.currentPlayer.damage++;
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void FightEncounter()
        {
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine($"You turn the corner and see movement as you focus on it, you ready yourself as it attacks!");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }


        //Encounter Tools

        public static void RandomEncounter() //switch case to add more encounters special enemies or bosses
        {
            switch (rng.Next(0, 4))
            {
                case 0:
                    FightEncounter();
                    break;
            }

        }
        public static void Combat(bool random, string name, int power, int health)
        {
            //string nam = "";
           // int pow = 0;
           // int life = 0;

            if (random)
            {
                name = GetName();
                power = Program.currentPlayer.GetStat();
                health = Program.currentPlayer.GetToughness();

            }
          //  else
         //   {
               //name = name;
              //  power = power;
               // life = health;   
          //  }
            while (health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(name);
                Console.WriteLine(power + " Attack/Health " + health);
                Console.WriteLine("============================");

                Console.WriteLine("|    (A)ttack (D)efend  |  ");

                Console.WriteLine("|      (R)un (H)eal     |  ");

                Console.WriteLine("============================");

                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);
                Console.WriteLine("Your Choice..");
                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack") //Attack
                {
                    Console.WriteLine($"You swing at the creature as you bring your weapon down feel it sink in, the {name} strikes back at you!");
                    int damage = power - Program.currentPlayer.armorValue;

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attack = rng.Next(0, Program.currentPlayer.weaponValue) + rng.Next(1, 5);

                    Console.WriteLine($"You lose {damage} health and deal {attack} damage to the {name}");

                    Program.currentPlayer.health -= damage;
                    health -= attack;

                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend") //Defend
                {
                    Console.WriteLine($"As the {name} rasies its weapon to end your life you ready yourself to parry the blow");
                    int damage = (power / 4) - Program.currentPlayer.armorValue;

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attack = rng.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine($"You lose {damage} health and deal {attack} to the {name}");

                    Program.currentPlayer.health -= damage;
                    health -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run") //Run
                {
                    int damage = power - Program.currentPlayer.armorValue;
                    int amount = Program.currentPlayer.coins;
                    string item = "Weapon";
                    Console.WriteLine($"You look for quickest path past the {name}");

                    if (rng.Next(0, 2) == 0)
                    {
                        Console.WriteLine($"As you dodge past the {name} it strikes catchs you in the back");
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine($"You lose {damage} health and are unable to escape");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You use your dexterity and roll past the {name}, its weapon strikes the ground as you come to you feet and run!");
                        Console.ReadKey();
                        Console.WriteLine($"You run towards the sounds of the market and lights you see down a corridor");
                        //Player.currentPlayer.health = Player.health;  //trying to call reset on health after escape to market.
                        Shop.RunShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal") //Heal
                {
                    int potionV = (5);
                    int damage = power - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You fumble for a potion in your bag and there are none left.");
                        Console.WriteLine($"The {name} strikes you with staggering blow and you lose {damage} health!");
                    }
                    else
                    {
                        Console.WriteLine($"You reach in your bag pull out little vial of glowing fluid pop the cork and drink it");
                        Console.WriteLine($"You gain {potionV} health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine($"As you were finishing the potion the {name} advanced and strikes you");
                        int surpriseStrike = (power / 2 - Program.currentPlayer.armorValue);
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine($"You lose {damage} health.");
                    }
                }
                if (Program.currentPlayer.health <= 0) //death
                {
                    Console.WriteLine($"As the {name} stands over you last thing you see and hear is it evil laugh and all goes dark");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.ReadKey();

            }// rewards for winning comabat 
            int coin = Program.currentPlayer.GetCoins();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"As the {name} falls to ground with a thud you search it for anything of value, You find {coin} gold. ");
            Program.currentPlayer.coins += coin;
            Console.ReadKey();
        }
        public static string GetName()
        {
            switch (rng.Next(0,6))
            {
                case 0:

                    return"Skeleton";

                case 1:

                    return "Zombie";

                case 2:
                    return "Cultist";

                case 3:
                    return "Fiend";

            }
            return "Human";

        }

    }
}
