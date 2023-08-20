using System;

internal class CharacterSelect
{

    //controls player set up and introduces player to the game
    //a prologue
    public void SelelctProces(Player player, UI ui)
    {
        int m = 0; int p = 0; int r = 0;

        ui.CharacterQuestions(1);

        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                m++;
                break;
            }
            else if (input == "b")
            {
                p++;
                break;
            }
            else if (input == "c")
            {
                r++;
                break;
            }
            else
            {
                Console.WriteLine("Please enter 'a', 'b', or 'c'");
            }
        }

        ui.Pause();

        ui.CharacterQuestions(2);

        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                p++;
                break;
            }
            else if (input == "b")
            {
                m++;
                break;
            }
            else if (input == "c")
            {
                r++;
                break;
            }
            else
            {
                Console.WriteLine("Please enter 'a', 'b', or 'c'");
            }

        }


        ui.Pause();

        ui.CharacterQuestions(3);

        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                r++;
                break;
            }
            else if (input == "b")
            {
                p++;
                break;
            }
            else if (input == "c")
            {
                m++;
                break;
            }
            else
            {
                Console.WriteLine("Please enter 'a', 'b', or 'c'");
            }

        }

        ui.Pause();

        ui.CharacterQuestions(4);

        while (true)
        {

            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                m++;
                break;
            }
            else if (input == "b")
            {
                p++;
                break;
            }
            else if (input == "c")
            {
                r++;
                break;
            }
            else
            {
                Console.WriteLine("Please enter 'a', 'b', or 'c'");
            }
        }
        ui.Pause();

        ui.CharacterQuestions(5);


        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                r++;
                break;
            }
            else if (input == "b")
            {
                m++;
                break;
            }
            else if (input == "c")
            {
                p++;
                break;
            }
            else
            {
                Console.WriteLine("Please enter 'a', 'b', or 'c'");
            }
        }

        ui.Pause();

        if (m > p && m > r)
        {
            player.type = "mage";
        }
        else if (p > m && p > r)
        {
            player.type = "paladin";
        }
        else if (r > m && r > p)
        {
            player.type = "rogue";
        }


        ui.Clear();
        Console.WriteLine();
        Console.WriteLine("Hello there, What is your name??");
        player.name = Console.ReadLine();
        ui.Pause();

        //decides player type
        //needs to be converted to enums

        Console.WriteLine("Your name " + player.name);
        Console.WriteLine("Your type " + player.type);


    }


}