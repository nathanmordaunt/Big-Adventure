using System;
using System.Text.Json;
using System.IO; 

internal class UI{

  public void Menu(){
    Console.WriteLine("******************************************************");
    Console.WriteLine("Input 'i' for inventory");
    Console.WriteLine("Input 'c' to clear console");
    Console.WriteLine("Input 'r' to restart game progress");
    Console.WriteLine("Input 'q' to save and quit game"); 
    Console.WriteLine("******************************************************");
    
  }
  public void Layout(){

    Console.WriteLine("******************************************************");
    Console.WriteLine("...Game Title...");
    Console.WriteLine("Input 'm' to access command list");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("******************************************************");
    
  }

  //manages user inputs 
  public void Commands(Game g){
    string input = Console.ReadLine().ToLower();
    switch(input){
    case "i":
    {
      Console.WriteLine("Pee pee poo poo");
      return;  
    }
    case "m":
    {
      Menu();
      return;
      
    }
    //allows player to reset game progress
    case "r":
    {
        Console.WriteLine("Are you sure that you want to restart game progress? Type 'yes' if so or 'no' to return");
        while(true){
          input = Console.ReadLine().ToLower();
        if(input == "yes"){
          string saveData = JsonSerializer.Serialize(new Game());
          File.WriteAllText("save.txt", saveData);
          Console.WriteLine("Game progress has been reset ");
          return;
        }else if (input == "no"){
          Console.WriteLine("Game progress has not been reset ");
          return;
        }else{
          Console.WriteLine("Please enter 'yes' or 'no' ");
        }   
      }
    }
    case "c":
    {
      Console.Clear();
      Layout();
      return;
    }
    case "q":
      {
       Console.WriteLine("You have chosen to leave your adventure. Goodbye, for now...");
       string saveData = JsonSerializer.Serialize(g);
       File.WriteAllText("save.txt", saveData);
       Console.WriteLine("...Game Saved...");
       System.Environment.Exit(0);
       return; 
       
      }
    default:
    {
      Console.WriteLine("Please input a valid option");
      return;
    }
      
      
    }
  }

  
 
  
}