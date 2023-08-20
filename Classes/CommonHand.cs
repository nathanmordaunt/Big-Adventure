using System;

internal class CommonHand
{
    public enum RollType
    {
        Runt = 1,
        Pair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        FullHouse = 5,
        Straight = 6,
        FourOfAKind = 7,
        FiveOfAKind = 8
    }

    public UI ui = new UI();
    Random rng = new Random();

    public int round { get; set; }
    public int playerWin { get; set; }
    public int npcWin { get; set; }
    public int prizePool { get; set; }
    public int turn { get; set; }
    
    public bool gameOver = false;
    public bool hasRolled = false;
    
    public int[] pd = new int[5];
    public int[] nd = new int[5];

    //TODO Test Two Pair

    public void Play(Player p, NPC n)
    {
        p.currency = 450;

        DisplayDice(turn);

        turn = 0;

        while (true) 
        {
            while (gameOver != true)
            {
                ui.CommonHandUI("title", p, pd, nd, turn);
    
                DisplayDice(turn);
                Console.WriteLine();
    
                Input(p);
                //npc behaviour method to be added below
    
                if (turn == 5)
                {
                    CompareRoll(pd, nd, p);
                    gameOver = true;
                }
            }

            // want to play again? y/n
            Console.WriteLine();
            Console.WriteLine("Play again? y/n");
            string input = Console.ReadLine().ToLower();
            
            if (input == "y")
            {
                pd = new int[5];
                nd = new int[5];
                gameOver = false;
                hasRolled = false;
                turn = 0;
                continue;
            } else if (input == "n") 
            {
                break;
            } else
            {   Console.WriteLine();
                Console.WriteLine("invalid input");
            }
        }
    }

    public int[] Roll()
    {

        int[] dice = new int[5];

        for (int i = 0; i < dice.Length; i++)
        {
            int diceRoll = rng.Next(1, 7);
            dice[i] = diceRoll;
        }

        return dice;
    }

    //compares dice to see which player has the higher hand
    public void CompareRoll(int[] pd, int[] nd, Player p)
    {
        DisplayDice(5);

        // Compare the hand types.
        if (RankDice(pd) > RankDice(nd))
        {
            win(p);
            return;
        }
        if (RankDice(pd) < RankDice(nd))
        {
            lose(p);
            return;
        }

        // Sum the hands to break the tie.
        int pTotal = pd[0] + pd[1] + pd[2] + pd[3] + pd[4];
        int nTotal = nd[0] + nd[1] + nd[2] + nd[3] + nd[4];
    
        if (pTotal > nTotal)
        {
           win(p);
           return; 
        }
        else
        {
            lose(p);
            return;
        }
    }

    // win processes the win condition.
    void win(Player p) {
        Console.WriteLine();
        Console.WriteLine("You win the round ");
        prizePool += p.currency;
    }

    // lose processes the lose condition.
    void lose(Player p) {
        Console.WriteLine();
        Console.WriteLine("Your opponent wins the round ");
        prizePool -= p.currency;
    }
    
    // sorts dice from lowest to highest
    public void SortDice(int[] dice)
    {
        int i, j, temp;
        for (i = 0; i < dice.Length; i++)
        {
            for (j = i + 1; j < dice.Length; j++)
            {
                if (dice[i] > dice[j])
                {
                    temp = dice[i];
                    dice[i] = dice[j];
                    dice[j] = temp;
                }
            }
        }
    }

    // checks for consecutive dice rolls
    //public int returnConsecutive(int[] dice)
    //{
    //    for (int i = 0; i < dice.Length; i++)
    //    {
    //        for (int j = i + 1; j < dice.Length; j++)
    //        {
    //            if (dice[i] == dice[j])
    //            {
    //                return dice[i];
    //            }
    //        }
    //    }
    //    return 0;
    //}


    //checks if all five elements of the array are the same
    public bool FiveOfKind(int[] dice)
    {

        SortDice(dice);

        if (dice[0] == dice[1] && dice[0] == dice[2] && dice[0] == dice[3] && dice[0] == dice[4])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //checks if four elements in an array are the same
    public bool FourOfKind(int[] dice)
    {
        SortDice(dice);

        for (int i = 0; i < dice.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < dice.Length; j++)
            {
                if (dice[i] == dice[j])
                {
                    count++;
                }
                if (count == 4)
                {
                    return true;
                }
            }
        }
        return false;
    }



    //checks if dice roll has a set of two and a set of three numbers 
    //to be debugged
    public bool FullHouse(int[] dice)
    {
        SortDice(dice);

        if (dice[0] == dice[1] && dice[2] == dice[3] && dice[2] == dice[4])
        {
            return true;
        }
        else if (dice[0] == dice[1] && dice[0] == dice[3] && dice[3] == dice[4])
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    //sorts and checks if dice roll contains a consecutive set
    public bool Straight(int[] dice)
    {
        SortDice(dice);

        for (int i = 0; i < dice.Length - 1; i++)
        {
            if (dice[i + 1] != dice[i] + 1)
            {
                return false;
            }
        }
        return true;
    }

    //checks for a set of three identical numbers
    public bool ThreeOfKind(int[] dice)
    {
        SortDice(dice);

        for (int i = 0; i < dice.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < dice.Length; j++)
            {
                if (dice[i] == dice[j])
                {
                    count++;
                }
                if (count == 3)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // checks dice array for two duplicate sets of integers
    public bool TwoPairs(int[] dice)
    {
        SortDice(dice);
        
        int pairCount = 0;
        bool[] checkedIndex = new bool[dice.Length]; // Keep track of checked indices

        for (int i = 0; i < dice.Length; i++)
        {
            if (!checkedIndex[i]) // If not already checked
            {
                int countEqualNumbers = 0; // Track the duplicates

                for (int j = i + 1; j < dice.Length; j++)
                {
                    if (dice[i] == dice[j])
                    {
                        countEqualNumbers++;
                        checkedIndex[j] = true;
                    }
                }

                if (countEqualNumbers >= 1)
                {
                    pairCount++;
                }

                if (pairCount == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }


    //need to add two pair method beloew

    //checks for a set of two identical numbers
    public bool TwoOfKind(int[] dice)
    {
        SortDice(dice);

        for (int i = 0; i < dice.Length; i++)
        {
            int count = 0;

            for (int j = i + 1; j < dice.Length; j++)
            {
                if (dice[i] == dice[j])
                {
                    count++;
                }
                if (count == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void UpBid(int currency, Player p)
    {
        Console.WriteLine();
        Console.WriteLine("Enter Bid: ");
        int bid = Console.Read();
        Console.WriteLine(bid);

        if (currency >= bid)
        {
            bid -= p.currency;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You do no have enough currency ");
            Console.WriteLine("You can leave this round or offer a lower bid ");
            Console.ReadLine();
        }
    }

    void Exit(bool gameOver)
    {
        gameOver = true;
    }

    //returns rank of a given roll
    public int RankDice(int[] dice)
    {
        int rank = 0;
        if (FiveOfKind(dice))
        {
            rank = (int)RollType.FiveOfAKind;
        }
        else if (FourOfKind(dice))
        {
            rank = (int)RollType.FourOfAKind;
        }
        else if (FullHouse(dice))
        {
            rank = (int)RollType.FullHouse;
        }
        else if (Straight(dice))
        {
            rank = (int)RollType.Straight;
        }
        else if (ThreeOfKind(dice))
        {
            rank = (int)RollType.ThreeOfAKind;
        }
        else if (TwoPairs(dice))
        {
            rank = (int)RollType.TwoPair;
        }
        else if (TwoOfKind(dice))
        {
            rank = (int)RollType.Pair;
        }
        else
        {
            rank = (int)RollType.Runt;
        }
        return rank;
    }

    //Controls player input
    public void Input(Player p)
    {
        string input = Console.ReadLine().ToLower();

        switch (input)
        {
            case "roll":
            case "rol":
            case "ro":
                if (hasRolled == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("You have rolled your hand already ");
                    Console.WriteLine("Please try another action or leave the game and lose your bid ");
                    Console.WriteLine();
                    Console.ReadLine();
                    return;
                }
                else
                {
                    hasRolled = true;
                    
                    pd = Roll();
                    nd = Roll();

                    turn += 1;
                    return;
                }

            case "call":
            case "cal":
            case "ca":
            case "c":
                CompareRoll(pd, nd,p);
                gameOver = true;
                return;

            case "rules":
            case "rul":
            case "ru":
                ui.CommonHandUI("rules", p, pd, nd, turn);
                return;

            case "up bid":
            case "u":
            case "up":
                UpBid(p.currency, p);
                Console.ReadLine();

                turn += 1;
                return;

            case "menu":
            case "men":
            case "m":
                ui.Commands(p);
                return;

            case "f":
            case "fo":
            case "fol":
            case "fold":
        
                turn += 1;
                return;
            
            case "leave":
            case "l":
                gameOver = true;
                Console.WriteLine();
                Console.WriteLine("You have left this game of Liars Dice ");
                return;

            default:
                Console.WriteLine();
                Console.WriteLine("Please enter a valid command ");
                Console.ReadLine();
                return;
        }
    }

    void Test(int[] dice)
    {

        pd = Roll();

        Console.WriteLine();
        DisplayDice(5);
        Console.WriteLine();
        Console.WriteLine(RankDice(pd));
        Console.WriteLine();

        DisplayDice(5);
    }

    void DisplayDice(int turn)
    {
        switch (turn)
        {
            case 0:
                {
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Your Dice:      " + pd[0] + ", " + pd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("Opponents Dice: " + nd[0] + ", " + nd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("=============================");
                    return;
                }
            case 1:
                {

                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Your Dice:      " + pd[0] + ", " + pd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("Opponents Dice: " + nd[0] + ", " + "*" + ", " + "*" + ", " + "*" + ", " + "*");
                    Console.WriteLine("=============================");
                    return;
                }
            case 2:
                {
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Your Dice:      " + pd[0] + ", " + pd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("Opponents Dice: " + nd[0] + ", " + nd[1] + ", " + "* " + ", " + "* " + ", " + "* ");
                    Console.WriteLine("=============================");
                    return;
                }
            case 3:
                {
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Your Dice:      " + pd[0] + ", " + pd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("Opponents Dice: " + nd[0] + ", " + nd[1] + ", " + pd[2] + ", " + "* " + ", " + "* ");
                    Console.WriteLine("=============================");
                    return;

                }
            case 4:
                {
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Your Dice:      " + pd[0] + ", " + pd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("Opponents Dice: " + nd[0] + ", " + nd[1] + ", " + pd[2] + ", " + pd[3] + ", " + "* ");
                    Console.WriteLine("=============================");
                    return;
                }
            case 5:
                {
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Your Dice:      " + pd[0] + ", " + pd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("Opponents Dice: " + nd[0] + ", " + nd[1] + ", " + pd[2] + ", " + pd[3] + ", " + pd[4]);
                    Console.WriteLine("=============================");
                    return;
                }
        }
    }
}

