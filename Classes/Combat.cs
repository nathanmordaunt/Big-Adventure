
enum Command
{
    Attack,
    Cast,
    UseItem,
    Run,
    Menu,
    Invalid,

}

internal class Combat
{

    public Combat(){
        
    }
    //controls combat interactions
    //called when ever combat occurs
    public void Update(Player p, NPC n, UI ui)
    {
        int turn = 0;

        while (p.hp > 0 && n.hp > 0)
        {

            ui.CombatUI(p, n, turn);

            string input = Console.ReadLine().ToLower();

            Command cmd = parseCombatInput(input);

            switch (cmd)
            {
                case Command.Attack:
                    {
                        if (p.iniative > n.iniative)
                        {
                            p.Attack(n);
                            n.Behaviour(p);
                        }
                        else
                        {
                            n.Behaviour(p);
                            p.Attack(n);
                        }
                        turn += 1;
                        ui.Pause();
                        break;
                    }

                case Command.Cast:
                    {
                        if (p.mana > 0)
                        {
                            p.Cast(n);
                            n.Behaviour(p);
                            turn += 1;
                            ui.Pause();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("You are out of mana ");
                            Console.WriteLine("Try something else...");
                            Console.ReadLine();
                        }

                        break;
                    }

                case Command.UseItem:
                    {
                        //show items and allow player use item if available
                        p.UseItem();
                        ui.Pause();
                        break;
                    }

                case Command.Run:
                    {
                        //attempt to flee
                        p.Flee(n);
                        //breaks loop if player hass fled
                        if (p.hasFled == true)
                        {
                            p.hasFled = false;
                            return;
                        }
                        turn += 1;
                        ui.Pause();
                        break;
                    }

                case Command.Menu:
                    {
                        ui.Commands(p);
                        break;
                    }

                case Command.Invalid:
                    {
                        // Retry the loop without consuming a turn. 
                        continue;
                    }

            }

            // TODO: move into UI. 
            if (n.disableTick > 0)
            {
                Console.WriteLine();
                Console.WriteLine(n.name + " is disabled by your spell but will recover shortly");
            }

            if (p.hp <= 0)
            {
                p.hp = 0;
                ui.CombatUI(p, n, turn);
                Console.WriteLine();
                ui.DeathMessage();
                ui.Pause();
            }
            else if (n.hp <= 0)
            {
                n.hp = 0;
                ui.CombatUI(p, n, turn);
                Console.WriteLine();
                Console.WriteLine("You have slain " + n.name);
                ui.Pause();
            }

        }
    }


    Command parseCombatInput(String s)
    {
        switch (s)
        {
            case "a":
            case "attack":
                return Command.Attack;

            case "c":
            case "cast":
                return Command.Cast;

            case "u":
            case "use item":
                return Command.UseItem;

            case "r":
            case "run":
                return Command.Run;

            case "m":
            case "menu":
                return Command.Menu;

            default:
                return Command.Invalid;
        }
    }

}