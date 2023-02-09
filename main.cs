using System;
using System.Text.Json;
using System.IO; 

class Program
{
  
  public static void Main(string[] args)
  {
    //initialise objects
    Game g;
    
   
    //initialises game state
    try{
    string saveData = File.ReadAllText("save.txt");
    g = JsonSerializer.Deserialize<Game>(saveData);  
    }catch{
    g = new Game();
    }

    //tests if a player has been created
    //if no, one is created
    if(g.player == null){
      g.player = new Player();
    }

    g.chapter = 0; 

    NPC n = new NPC();
    n.name = "NI "
    
    //draws ui prompts
    g.ui.Layout();     
    
    
    // core game loop  
    while (g.chapter < 4)
    {
    g.UpdateLvl();
    }
  }

}

