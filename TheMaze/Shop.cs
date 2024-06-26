﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheMaze
{
    public class Shop
    {
        public static void RunShop(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("         Market            ");
                Console.WriteLine("===========================");
                Console.WriteLine("(W)eapon:    $100");
                Console.WriteLine("(A)rmor:     $100");
                Console.WriteLine("(P)otions:   $20");
                Console.WriteLine("(D)ifficulty Mod:  $300");
                Console.WriteLine("(E)xit");
                Console.WriteLine("Save and (Q)uit");
                Console.WriteLine("===============================");

                Console.WriteLine($" {player.name}'s Stats");
                Console.WriteLine("===============================");
                Console.WriteLine($"Current Health: {player.health}");
                Console.WriteLine($"Coins: {player.coins}");
                Console.WriteLine($"Weapon Strength: {player.weaponValue}");
                Console.WriteLine($"Armor Toughness: {player.armorValue}");
                Console.WriteLine($"Potions: {player.potion}");
                Console.WriteLine($"Difficulty Mods: {player.mods}");
                Console.WriteLine("===========================");

                // Player input
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "w":
                        BuyItem(player, 100, "weapon");
                        break;

                    case "a":
                        BuyItem(player, 100, "armor");
                        break;

                    case "p":
                        BuyItem(player, 20, "potion");
                        break;

                    case "d":
                        BuyItem(player, 300, "difficulty");
                        break;

                    case "e": //this is where game breaks if loaded a save file..
                        Console.WriteLine("You leave the market and return to the maze!");
                        Console.ResetColor();
                        Console.Clear();
                        Console.WriteLine("You wonder back down the changing corridors hoping to find way out. Then...");
                        return; //right here it loops back to main menu..ive tried forcing encouter.randomencouters..that dont work

                    case "q":
                        SaveSystem.SavePlayer(player);
                        Console.WriteLine("You rent a room at the inn and fall asleep");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input! Please try again.");
                        break;
                }
            }
        }

        public static void BuyItem(Player player, int itemCost, string itemType)
        {
            if (player.coins >= itemCost)
            {
                switch (itemType)
                {
                    case "weapon":
                        player.weaponValue++;
                        break;

                    case "armor":
                        player.armorValue++;
                        break;

                    case "potion":
                        player.potion++;
                        break;

                    case "difficulty":
                        player.mods++;
                        break;
                }
                player.coins -= itemCost;
            }
            else if (player.coins <= itemCost)
            {
                Console.WriteLine("You don't have enough coins!");
            }
           
        }

    }
}








