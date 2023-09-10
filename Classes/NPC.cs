using System;

internal class NPC
{

    //add enumeration variables to control behaiviour of the npc
    //state machine features

    Random rng = new Random();

    public string name { get; set; }
    public int level { get; set; }
    public int hp { get; set; }
    public int dmg { get; set; }
    public int wpnDmg { get; set; }
    public int accuracy { get; set; }
    public int iniative { get; set; }
    public int disableTick { get; set; }
    public int blindDuration { get; set; }


    public enum CombatBehaviors
    {
        Aggressive,
        Defensive,
        Cowardly,
    }

    public enum CHBehaviours{
        Greedy,
        Conservative,
        WildCArd,
    }

    
    public NPC(string n, int h, int d, int a, int i)
    {
        this.name = n;
        this.hp = h;
        this.dmg = d;
        this.accuracy = a;
        this.iniative = i;
    }

    public NPC()
    {

    }


    public void Heal()
    {
        if (this.hp > 0)
        {
            int healingFactor = (hp / 2) * level;

            Console.WriteLine();
            Console.WriteLine(this.name + " heals for " + healingFactor);
            this.hp += healingFactor;
        }

    }

    public void Attack(Player p)
    {
        var hitChance = rng.Next(0, this.accuracy);

        if (this.blindDuration > 0)
        {
            hitChance = 0;
        }

        if (hitChance == 0)
        {
            Console.WriteLine();
            Console.WriteLine("The " + this.name + " missed");
        }
        else
        {
            int dmgDealt = rng.Next(this.dmg / 2, this.dmg + wpnDmg);

            Console.WriteLine();
            Console.WriteLine(this.name + " Attacks! you take: " + dmgDealt);
            p.hp = p.hp - dmgDealt;
        }
    }

    public void UseItem()
    {
        //add code to allow npc to use items if appicable
    }

    //flees every turn 
    public void Cowardly(Player p)
    {
        Console.WriteLine();
        Console.WriteLine(this.name + " cowers at the sight of you and attempts to flee");
        int escChance = rng.Next(0, this.iniative);
        int trapChance = rng.Next(0, p.iniative);
        if (escChance < trapChance)
        {
            return;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You are too persistant ");
            Console.WriteLine(this.name + " was unable to escape ");

            if (this.hp < p.hp / 4)
            {
                Console.WriteLine();
                Console.WriteLine("Out of desperation, " + this.name + " attempts to retaliate");
                Console.WriteLine();
                Attack(p);
            }
        }
    }

    public void Behaviour(Player p)
    {
        if (this.disableTick > 0)
        {

            this.disableTick--;
            return;
        }

        if (this.blindDuration > 1)
        {
            Console.WriteLine();
            Console.WriteLine(this.name + " is disorientated. ");
            this.blindDuration--;
            Console.WriteLine(this.blindDuration);
        }

        if (this.hp < p.hp / 2)
        {
            Heal();
        }
        else if (this.hp < p.hp / 3)
        {
            Cowardly(p);
        }
        else
        {
            Attack(p);
        }
    }

    //create behaviour tree for common hand 
    //use switch statement for to branch behaviour
    public void CHBehaviour(int bidTotal,string behaviour){

        
    }

    
}
