internal class NPC{
    
  public string name { get; set; }
  public string type { get; set; }
  public int hp { get; set; }
  public int dmg { get; set; }
  public int accuracy {get; set;}
  public int entrapment {get; set;}
  
  

  //below methods define different npc behaviours or strategies 
  public void Aggressive(){
    
  }

  public void Defensive(){
    
  }

  public void Cowardly(){
    
  }

  public NPC(){
    
  }

  public NPC(string n, string t, int h, int d, int a, int e){
    this.name = n;
    this.type = t;
    this.hp = h;
    this.dmg = d;
    this.accuracy = a;
    this.entrapment = e;
    
  }
  
  
  
  
}