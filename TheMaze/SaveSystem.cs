using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMaze
{
    public class SaveSystem
    {
        public static void SavePlayer(Player player)
        {
            string json = JsonConvert.SerializeObject(player);
            File.WriteAllText("playerData.json", json);
            Console.WriteLine("Player data saved successfully.");
        }

        public static Player LoadPlayer()
        {
            if (File.Exists("playerData.json"))
            {
                string json = File.ReadAllText("playerData.json");
                Player player = JsonConvert.DeserializeObject<Player>(json);
                Console.WriteLine("Player data loaded successfully.");
                return player; //can not figure out why when load save it loops main menu..needs to load player to store where they quit.
            }
            else
            {
                Console.WriteLine("No saved player data found.");
                return null;
            }
        }

        public static void DeleteSaveData()
        {
            if (File.Exists("playerData.json"))
            {
                File.Delete("playerData.json");
                Console.WriteLine("Player data deleted successfully.");
            }
            else
            {
                Console.WriteLine("No saved player data found to delete.");
            }
        }
    }
}

