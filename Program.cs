using System;
using System.IO;

namespace BigAdventure // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Combat c = new Combat();
            Random rng = new Random();
            
            Player p = new Player("Mortanuel", "paladin", true, rng.Next(50, 100), rng.Next(50, 100), rng.Next(50, 100), 1, rng.Next(50, 100));
            NPC n = new NPC("Troll", rng.Next(50, 100), rng.Next(50, 100), rng.Next(50, 100), rng.Next(50, 100));
            UI ui= new UI();    

            c.Update(p, n, ui);


        }
    }
}