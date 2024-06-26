﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMaze
{
    public class Player
    {
        Random rng = new Random(); 

        public string name;
        public int coins = 59999;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;

        public int mods = 0;


        public int GetToughness()
        {
            int upper = (2 * mods + 7);
            int lower = (mods + 2);
            return rng.Next(lower, upper);
        }
        public int GetStat()
        {
            int upper = (2 * mods + 3);
            int lower = (mods + 1);
            return rng.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (15 * mods + 50);
            int lower = (10 * mods + 10);
            return rng.Next(lower, upper);
        }

    }
}
