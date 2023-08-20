using System;

internal class Player
{

    public string name { get; set; }
    public string type { get; set; }//paladin or mage
    public int level { get; set; } // stores players level to be updated at end of chapter
    public int hp { get; set; }
    public int dmg { get; set; }// base attack damage will be use to multiply castables
    public int wpnDmg { get; set; } // add weapon dmg to base dmg
    public int accuracy { get; set; }// number that offsets hit chance
    public int iniative { get; set; }// tests for who attacks first
    public int mana { get; set; }
    public int manaPot { get; set; }
    public int healthPot { get; set; }
    public int currency { get; set; }
    public bool hasFled { get; set; }
    public bool abilities { get; set; }

    public enum Class
    {
        paladin,
        mage,
        rogue
    }

    Random rng = new Random();

    public string[] items { get; set; }

    public Player(string n, string t, bool abilities, int h, int d, int a, int l, int i)
    {
        this.name = n;
        this.type = t;
        this.hp = h;
        this.dmg = d;
        this.accuracy = a;
        this.level = l;
        this.iniative = i;
        this.abilities = abilities;
    }

    public Player()
    {

    }

    public void Attack(NPC n)
    {

        int hitChance = rng.Next(0, this.accuracy);
        if (hitChance > 0)
        {
            int dmgDealt = rng.Next(dmg / 2, dmg + wpnDmg);
            Console.WriteLine();
            Console.WriteLine("You strike " + n.name + " dealing: " + dmgDealt + " damage");
            n.hp = n.hp - dmgDealt;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You missed your attack");
        }
    }

    //stratifies player type re casting abilities
    public void Cast(NPC n)
    {
        switch (this.type)
        {
            case "mage":
                this.MCast(n);
                break;
            case "paladin":
                this.PCast(n);
                break;
            case "rogue":
                this.RCast(n);
                break;
            default:
                // This type cannot cast. 
                break;
        }
    }

    public void MCast(NPC n)
    {
        if (this.abilities == false)
        {
            Console.WriteLine();
            Console.WriteLine("Your memory fails you");
            Console.WriteLine("It seems you cannot remember how to cast spells ");
            Console.WriteLine("Perhaps in time you shall recall your arcane knowledge");

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("| (F)ire Ball   (P)olymorph |");
            Console.WriteLine("|                           |");
            Console.WriteLine("=============================");



            //add a burn duration to npc 
            //add code to deduct an additional amount each turn while burnt
            while (true)
            {
                string input = Console.ReadLine().ToLower();


                if (input == "f" || input == "fire ball")
                {

                    int dmgDealt = rng.Next(this.dmg, this.dmg * 2);

                    Console.WriteLine();
                    Console.WriteLine("You utter an incantation that summons a ferocious flame");
                    Console.WriteLine("Targetng your enemy, you cast the flame at them");
                    Console.WriteLine("You burn " + n.name + " for " + dmgDealt + " damage...");

                    n.hp = n.hp - dmgDealt;
                    this.mana--;
                }
                else if (input == "p" || input == "polymorph")
                {
                    //add logic that prevents the enemy from attacking next turn
                    //communicate to player what has happened

                    Console.WriteLine();
                    Console.WriteLine("You reach out hand toward your enemy and exclaim a phrase few understand ");
                    Console.WriteLine(n.name + " drops to floor writhing in pain as they scream");
                    Console.WriteLine("Their body starts to change shape as they become what looks like a fluffy sheep");
                    Console.WriteLine("Although temporary, this should render them harmless... for now");

                    n.disableTick = 3;
                    this.mana--;
                }
                else if (input == "e")
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid command ");
                }

            }


        }
    }

    public void PCast(NPC n)
    {

        if (this.abilities == false)
        {
            Console.WriteLine();
            Console.WriteLine("Your memory fails you");
            Console.WriteLine("It seems you cannot remember how to call upon the Light");
            Console.WriteLine("Perhaps in time your abilities will return to you...");

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("| (H)eal     (B)lind        |");
            Console.WriteLine("|                           |");
            Console.WriteLine("=============================");

            //heal will add hp to paladin class
            //blind will disable an enemy for a turn and reduce their defence 
            //apply cool downs
            string input = Console.ReadLine().ToLower();

            if (input == "h" || input == "heal")
            {
                int healingFactor = rng.Next(this.hp / 2, this.hp / 2 + 5);
                this.hp += healingFactor;
                Console.WriteLine();
                Console.WriteLine("You have healed yourself for " + healingFactor);

                this.mana--;
            }
            else if (input == "b" || input == "blind")
            {
                Console.WriteLine();
                Console.WriteLine("You raise hand in the air");
                Console.WriteLine("A beam of light falls upon your oponent");
                Console.WriteLine("blinding them for a moment");
                Console.WriteLine();
                //set enemies accuracy to zero
                //need to make that change temporary, lasting only one turn
                n.blindDuration = 2;
                this.mana--;
                return;
            }


        }
    }

    public void RCast(NPC n)
    {
        Console.WriteLine();
        Console.WriteLine("=============================");
        Console.WriteLine("| (S)moke_Bomb  (B)ack_stab |");
        Console.WriteLine("|                           |");
        Console.WriteLine("=============================");

        string input = Console.ReadLine().ToLower();

        if (input == "s" || input == "smoke_bomb")
        {
            Console.WriteLine();
            Console.WriteLine("You remove a smoke bomb from your belt and throw it at the floor ");
            Console.WriteLine("It explodes emiting smoke into the air disorienting your opponent... ");
            Console.WriteLine(n.name + " has lost track of you.. for now ");
            n.blindDuration += 3 + this.level;
            this.mana--;
        }
        else if (input == "b" && n.blindDuration > 0 || input == "back_stab" && n.blindDuration > 0)
        {
            int hitChance = rng.Next(0, this.accuracy);
            if (hitChance > 0)
            {
                int dmgDealt = rng.Next(dmg, dmg + wpnDmg * 2);

                Console.WriteLine();
                Console.WriteLine("You appear from the shadows, catching " + n.name + " off guard. You deal: " + dmgDealt + " damage");
                n.hp = n.hp - dmgDealt;
                this.mana--;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You missed your attack");
            }

        }
        else
        {
            
        }

    }

    public void Flee(NPC n)
    {
        int flee = rng.Next(0, this.iniative);
        int trap = rng.Next(0, n.iniative);
        if (flee > trap)
        {
            Console.WriteLine();
            Console.WriteLine("You have fled the battle");
            this.hasFled = true;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You were unable to flee");
            Console.WriteLine(n.name + " retaliates to punish your cowardice");
            n.Attack(this);
        }
    }

    public void UseItem()
    {

        //need to test for items in array
        if (this.manaPot > 0 || this.healthPot > 0)
        {

            Console.WriteLine();
            Console.WriteLine("Inventory:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Health Potions:" + this.healthPot);
            Console.WriteLine("Mana Potions: " + this.manaPot);
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("| (H)ealth    (M)ana        |");
            Console.WriteLine("=============================");

            string input = Console.ReadLine().ToLower();

            if (input == "h" && healthPot > 0 || input == "health" && healthPot > 0)
            {
                int healingFactor = 10 * level;
                Console.WriteLine();
                Console.WriteLine("You consume a health potion and are healed for: " + healingFactor);
                Console.WriteLine();
                this.hp += healingFactor;
                this.healthPot--;
            }
            else if (input == "m" && manaPot > 0 || input == "mana" && manaPot > 0)
            {
                Console.WriteLine();
                Console.WriteLine("You consume a mana potion... ");
                Console.WriteLine("You feel your power increase!");
                this.mana++;
                this.manaPot--;
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You do not have any items");
            Console.WriteLine("how unfortunate...");
        }
    }
}



