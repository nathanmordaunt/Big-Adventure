using System;
using System.Text.Json;
using System.IO;

internal class UI
{

    public void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("**************************************");
        Console.WriteLine("Input 's' for player stats");
        Console.WriteLine("Input 'c' to clear console");
        Console.WriteLine("Input 'i' for inventory");
        Console.WriteLine("Input 'r' to restart game progress");
        Console.WriteLine("Input 'q' to save and quit game");
        Console.WriteLine("**************************************");
    }
    public void Layout()
    {

        Console.WriteLine();
        Console.WriteLine("**************************************");
        Console.WriteLine("        ...A Sacred Moon...");
        Console.WriteLine("**************************************");
    }

    public void PlayerStats(Player p)
    {
        Console.WriteLine();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Player HP:" + p.hp + "     | " + "Player MAX DMG:" + p.dmg);
        Console.WriteLine("Player Iniative:" + p.iniative + "| " + "Player Mana:" + p.mana);
        Console.WriteLine("---------------------------------------");
        Pause();
    }

    public void Clear()
    {
        Console.Clear();
        Layout();
    }

    public void PlayerInventory(Player p)
    {
        Console.WriteLine();
        Console.WriteLine("Inventory:");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Health Potions:" + p.healthPot);
        Console.WriteLine("Mana Potions: " + p.manaPot);
        Console.WriteLine("---------------------------------------");
        Pause();
    }

    //manages user inputs 
    public void Commands(Player p)
    {
        Menu();

        string input = Console.ReadLine().ToLower();
        switch (input)
        {
            case "s":
                PlayerStats(p);
                return;

            case "m":
                Menu();
                return;

            case "i":
                PlayerInventory(p);
                return;

            case "r":
                //allows player to reset game progress
                Console.WriteLine("Are you sure that you want to restart game progress? Type 'yes' if so or 'no' to return");
                while (true)
                {
                    input = Console.ReadLine().ToLower();
                    if (input == "yes")
                    {
                        string data = JsonSerializer.Serialize(new GameState());
                        File.WriteAllText("save.txt", data);
                        Console.WriteLine("Game progress has been reset ");
                        return;
                    }
                    else if (input == "no")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Game progress has not been reset ");
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter 'yes' or 'no' ");
                    }
                }

            case "c":
                Clear();
                return;

            case "q":
                Console.WriteLine();
                Console.WriteLine("You have chosen to leave your adventure. Goodbye, for now...");
                //string saveData = JsonSerializer.Serialize(Main);
                //File.WriteAllText("save.txt", saveData);
                //Console.WriteLine("...Game Saved...");
                System.Environment.Exit(0);
                return;

            default:
                Console.WriteLine("Please input a valid option");
                return;
        }
    }

    public void CombatUI(Player p, NPC n, int turn)
    {
        Clear();
        Console.WriteLine("  ...........BATTLE...........");
        Console.WriteLine("Turn Number:" + turn);
        Console.WriteLine("Player HP:" + p.hp + "       | " + "Enemy HP:" + n.hp);
        Console.WriteLine("Player MAX DMG:" + p.dmg + "  | " + "Enemy MAX DMG:" + n.dmg);
        Console.WriteLine("Player Iniative:" + p.iniative + "  | " + "Enemy Iniative:" + n.iniative);
        Console.WriteLine("Player Mana:" + p.mana);



        Console.WriteLine("");
        Console.WriteLine("=============================");
        Console.WriteLine("| (A)ttack      (C)ast      |");
        Console.WriteLine("| (U)se Item    (R)un       |");
        Console.WriteLine("| (M)enu                    |");
        Console.WriteLine("=============================");

    }

    public void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("...Press enter to continue...");
        Console.ReadLine();

    }

    public void DeathMessage()
    {
        Random rng = new Random();
        switch (rng.Next(1, 3))
        {
            case 1:
                {
                    Console.WriteLine();
                    Console.WriteLine("You have died gruesomely... game over");
                    return;
                }
            case 2:
                {
                    Console.WriteLine();
                    Console.WriteLine("You have been torn asunder by your opponent... game over");
                    return;
                }
            case 3:
                {
                    Console.WriteLine();
                    Console.WriteLine("Your foe points in the distance and says 'HEY! look over there'... ");
                    Console.WriteLine("You fall for it and are impaled from behind... game over");
                    return;
                }
        }

    }


    //TODO: pull the processing of the method into its own method and run that on the game class
    //need to decouple computation from console output
    public void CharacterQuestions(int i)
    {
        switch (i)
        {
            case 1:
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("You find a litter of kittens but it appears the mother is gone");
                    Console.WriteLine("Given the choice, what do you do? ");

                    Console.WriteLine();
                    Console.WriteLine("(a) leave them to fend for themselves. As you look around, they appear to be safe and you're sure the mother will return. ");

                    Console.WriteLine();
                    Console.WriteLine("(b) take them to your home, they are weak and need to protecting. If the mother returns too bad, she shoudn't have left them alone in the first place.");

                    Console.WriteLine();
                    Console.WriteLine("(c) You don't even consider the kittens and walk on without a single care given");

                    break;

                }


            case 2:
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("Freedom, security or indiffernce? ");
                    Console.WriteLine("Given the choice, what do you choose? ");

                    Console.WriteLine();
                    Console.WriteLine("(a) security");

                    Console.WriteLine();
                    Console.WriteLine("(b) freedom");

                    Console.WriteLine();
                    Console.WriteLine("(c) who cares??");

                    break;
                }

            case 3:
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("How do you feel about Kings, Queens and centralised authority??");

                    Console.WriteLine();
                    Console.WriteLine("(a) fuck the king...");


                    Console.WriteLine();
                    Console.WriteLine("(b) The rule of a good king/queen or central leadership is essential in order to maintain peace and stability...");
                    Console.WriteLine("Without that we would have chaos... ");

                    Console.WriteLine();
                    Console.WriteLine("(c) it does not matter who is in leadership provided one is left alone...");
                    Console.WriteLine("Centralised leadership is tolerable if individual autonomy is respected...");

                    break;
                }
            case 4:
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("People are starving and many others are sick... ");
                    Console.WriteLine("How do you respond??");

                    Console.WriteLine();
                    Console.WriteLine("(a) Rely on the goodwill of others to provide charity");
                    Console.WriteLine("Generosity can not be compelled...");

                    Console.WriteLine();
                    Console.WriteLine("(b) Enforce a donation system that ensures everyone pays their share");
                    Console.WriteLine("Individuals can't be trusted to help others and must be compelled to fill the deficit...");

                    Console.WriteLine();
                    Console.WriteLine("(c) You do not care about the plight of others");
                    Console.WriteLine("People should fend for themseves...");

                    break;
                }
            case 5:
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("If you could have a loyal companion to travel with,");
                    Console.WriteLine("what would it be? ");

                    Console.WriteLine();
                    Console.WriteLine("(a) no companion, you work alone");

                    Console.WriteLine();
                    Console.WriteLine("(b) a dragon..");

                    Console.WriteLine();
                    Console.WriteLine("(b) a griffin..");

                    break;

                }
            default:
                {
                    break;
                }


        }

    }

    public void CommonHandUI(string input, Player p, int[] pd, int[] nd, int turn, int pool)
    {

        switch (input)
        {

            case "rules":
                {
                    Clear();
                    //needs to be updating
                    Console.WriteLine();
                    Console.WriteLine("..Rules of Liars Dice..");
                    Console.WriteLine();
                    Console.WriteLine("One player calls their hand. ");
                    Console.WriteLine("The other may either up the bid by calling a higher ranking hand, ");
                    Console.WriteLine("call the bluff, ");
                    Console.WriteLine("or re roll some or all of their dice. ");
                    Console.WriteLine();
                    Console.WriteLine("To call the bluff will reveal both players dice. ");
                    Console.WriteLine("The player with the strongest roll will win that round. ");
                    Console.WriteLine("First player to win 3 rounds wins overall.");
                    Console.WriteLine();
                    Console.WriteLine("The hands are ranked in a similar style to poker. ");
                    Console.WriteLine("They are ranked top to bottom from strongest to weakest as follows: ");
                    Console.WriteLine("-- Five of a kind: e.g. 66666");
                    Console.WriteLine("-- Four of a kind: e.g. 55553");
                    Console.WriteLine("-- High straight: e.g. 23456");
                    Console.WriteLine("-- Full house: e.g. 44222");
                    Console.WriteLine("-- Three of a kind: e.g. 11145");
                    Console.WriteLine("-- Low Straight: e.g. 12345 ");
                    Console.WriteLine("-- Two pair: e.g. 14455");
                    Console.WriteLine("-- Pair: e.g. 66123 ");
                    Console.WriteLine("-- Runt: e.g. 13456");

                    Console.WriteLine();
                    Console.WriteLine("...Press any key to continue... ");
                    Console.ReadLine();


                    return;
                }
            case "title":
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("        Common Hand          ");
                    Console.WriteLine("Your Currency: $" + p.currency);
                    Console.WriteLine("Total Pool: $" + pool);
                    Console.WriteLine("=============================");

                    Console.WriteLine();
                    Console.WriteLine("Turn: " + turn);

                    Console.WriteLine("");
                    Console.WriteLine("=============================");
                    Console.WriteLine("| (Ro)ll      (C)heck       |");
                    Console.WriteLine("| (U)p bid    (F)old        |");
                    Console.WriteLine("| (M)enu      (Ru)les       |");
                    Console.WriteLine("=============================");

                    // Roll starts the game by assigning ints to dice.
                    // Check allows player to do nothing but still keep their dice. 
                    // Up bid prompts user to increase bid and call to match bet
                    // Fold allows player to forfeit the round losing their cards and bid

                    return;
                }

        }

    }


    public void ShopUi(String input, Player p)
    {

        switch (input)
        {

            case "shop":
                {
                    Clear();

                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("          ...Shop...         ");
                    Console.WriteLine("Your Currency: " + p.currency);
                    Console.WriteLine("=============================");

                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("| (B)uy      (S)ell         |");
                    Console.WriteLine("| (P)lay Liars Dice         |");
                    Console.WriteLine("| (M)enu     (L)eave        |");
                    Console.WriteLine("=============================");

                    return;
                }

        }

    }
}
