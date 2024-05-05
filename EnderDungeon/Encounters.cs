using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnderDungeon
{
    public class Encounters
    {
        static Random rng = new Random();
        //Encounters Generic

        //Encounters

        public static void FirstEncounter()
        {
            Console.WriteLine("You sneak up behind the creature and try grab them with out it noticing...");
            Console.WriteLine("The goblin turns and squalls @#$@#%$^%^! you dont understand goblin but know if you dont shut them up more may come.");
            Console.ReadKey();
            Combat(false, "Goblin", 1, 4);
        }
        

        //Encounter Tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string nam = "";
            int pow = 0;
            int life = 0;

            if (random)
            {

            }
            else
            {
                nam = name;
                pow = power;
                life = health;
            }
            while(health > 0)
            {
                Console.WriteLine(name);
                Console.WriteLine(pow + "/" + health);
                Console.WriteLine("============================");

                Console.WriteLine("|    (A)ttack (D)efend|  ");

                Console.WriteLine("|      (R)un (H)eal   |  ");

                Console.WriteLine("============================");

                Console.WriteLine("Potions: "+Program.currentPlayer.potion+" Health: " +Program.currentPlayer.health);

                string input = Console.ReadLine();

                if(input.ToLower() == "a"|| input.ToLower() == "attack") //Attack
                {
                    Console.WriteLine($"You swing at the creature as you bring your weapon down feel it sink in, the {nam} strikes back at you!");
                    int damage = pow - Program.currentPlayer.armorValue;

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attack = rng.Next(0, Program.currentPlayer.weaponValue) + rng.Next(1, 5);

                    Console.WriteLine($"You lose {damage} health and deal {attack} to the {nam}");

                    Program.currentPlayer.health -= damage;
                    health -= attack;

                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend") //Defend
                {
                    Console.WriteLine($"As the {nam} rasies its weapon to end your life you ready yourself to parry the blow");
                    int damage = (pow / 4) - Program.currentPlayer.armorValue;

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attack = rng.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine($"You lose {damage} health and deal {attack} to the {nam}");

                    Program.currentPlayer.health -= damage;
                    health -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run") //Run
                {
                    int damage = pow - Program.currentPlayer.armorValue;

                    Console.WriteLine($"You look for quickest path past the {nam}");

                    if (rng.Next(0, 2) == 0)
                    {
                        Console.WriteLine($"As you dodge past the {nam} it strikes catchs you in the back");
                        if ( damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine($"You lose {damage} health and are unable to escape");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine($"You use your dexterity and roll past the {nam}, its weapon strikes the ground as you come to you feet and run!");
                        Console.ReadKey();
                        // go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal") //Heal
                {
                    int potionV = (5);
                    int damage = pow - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You fumble for a potion in your bag and there are none left.");
                        Console.WriteLine($"The {nam} strikes you with staggering blow and you lose {damage} health!");
                    }
                    else
                    {
                        Console.WriteLine($"You reach in your bag pull out little vial of glowing fluid pop the cork and drink it");
                        Console.WriteLine($"You gain {potionV} health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine($"As you were finishing the potion the {name} advanced and strikes you");
                        int surpriseStrike = (pow / 2 - Program.currentPlayer.armorValue);
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine($"You lose {damage} health.");
                    }
                }
                Console.ReadKey();
                
                

                

            }
        }
        
    }
}
