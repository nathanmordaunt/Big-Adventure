using System;
using System.IO;

internal class Game{

  public int chapter { get; set; }
  public Player player { get; set; } = new Player();
  public NPC enemy {get; set;} = new NPC();
  public UI ui = new UI();
  Random rnd = new Random();
    
  //switch statement to control level, stage or chapter
  //needs work
  public void UpdateLvl(){

    
    switch(this.chapter){
    case 0:
      {
        CharacterSetUp();
        this.chapter = 1;
        return;
      }
    case 1:
      {
        Chapter01();
        this.chapter = 2;
        return;
      }
    case 2:
      {
        Chapter02();
        this.chapter = 3;
        return;
      }
    case 3:
      {
        Chapter03();
        this.chapter = 4;
        return;
      }
    }
  }

  //controls combat interactions
  //called when ever combat occurs
  public void Combat(Player p, NPC e){

    while (p.hp > 0 || e.hp > 0){
      Console.WriteLine(" =============================");
      Console.WriteLine(" | (A)ttack      (C)ast      |");
      Console.WriteLine(" | (U)se Item    (R)un       |");
      Console.WriteLine(" | (M)enu                    |");
      Console.WriteLine(" =============================");
      string input = Console.ReadLine().ToLower();
      if(input == "a" || input == "attack"){
        //write attack logic
        int pHitChance = rnd.Next(0,p.accuracy);
        int eHitChance = rnd.Next(0,e.accuracy);
        if(pHitChance > 0){
          Console.WriteLine("You strike " + e.name + " Dealing: " + p.dmg + " damage");
          e.hp = e.hp - p.dmg;
        }else{
          Console.WriteLine("You missed your attack");
        }
        //need to add more customisable and saphisticated retaliation code
        if(eHitChance > 0){
          Console.WriteLine(e.name + " strikes back! you take: " + e.dmg);
          p.hp = p.hp - e.dmg;
        }
        
      } else if(input == "c"|| input == "cast"){
        //outputs castable abilities to player
        //allows player to cast ability if available
      }else if(input == "u"|| input == "use item"){
        //show items and allow player use item if available
      }else if(input == "r" || input == "run"){
        //attempt to flee
        int flee = rnd.Next(e.entrapment,p.escapability);
        if(flee < p.escapability){
          return;
        }else{
          continue;
        }
        
      }else if (input == "m" || input == "menu"){
        ui.Menu();
        ui.Commands(this);
      }
      if(p.hp < 0){
        Console.WriteLine("You have died gruesomely... game over");
      }else if (e.hp < 0){
        Console.WriteLine("You have slain " + e.name);
      }
    }
  }

  
  //controls player set up and introduces player to the game
  //a prologue
  void CharacterSetUp(){
    
    Console.WriteLine("Hello there, What is your name??");
    player.name = Console.ReadLine();
      
    
  }

  //manages the first chapter of the game. 
  //will contain naration, games to challenge player and npcs to interact with
  void Chapter01 (){
      Console.WriteLine("Chapter 01");

  }

  //further progress story, add new game types and various other content
  void Chapter02(){
    Console.WriteLine("Chapter 02");
  }


  //the final stage of the game
  //should contain a conclusion to the previous two chapters
  void Chapter03(){
    Console.WriteLine("Chapter 03");
  }


 
  
}