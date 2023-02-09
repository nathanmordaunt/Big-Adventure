using System;

internal class Player{
  
  public string name { get; set; }
  public string type { get; set; }
  public int level {get; set;} // stores players level to be updated at end of chapter
  public int hp { get; set; }
  public int dmg { get; set; }// base attack damage will be use to multiply castables
  public int accuracy {get; set;}// number that offsets hit chance
  public int escapability {get; set;}
  
  
  public string[] items { get; set; }

  public void Cast(int lvl){
    //at the end of chapter 1 and 2 the player will level up giving them more abilities
    //lvl will be set to 2
    if (type == "mage" && lvl == 1){
      Console.WriteLine("=============================");
      Console.WriteLine("| (F)ire Ball  (P)olymorph  |");
      Console.WriteLine("=============================");
      //add spell logic here 
      //fireball deals bonus damage and applies a burn
      //polymorph disables enemy for a turn
      //each spell is affected by cool downs of x amount of turns
      
    }else if (type == "paladin" && lvl == 1){
      Console.WriteLine("=============================");
      Console.WriteLine("| (H)eal     (B)lind        |");
      Console.WriteLine("=============================");
      //heal will add hp to paladin class
      //blind will disable an enemy for a turn and reduce their defence 
      //apply cool downs
    }
    
  }

  
  
}
