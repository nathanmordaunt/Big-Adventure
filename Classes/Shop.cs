using System;

internal class Shop
{

    public UI ui = new UI();
    public bool over = false;

    public void Update(Player p)
    {


        while (!over)
        {

            ui.ShopUi("shop", p);

            Input(p);
        }



    }

    public void Input(Player p)
    {

        string input = Console.ReadLine().ToLower();

        switch (input)
        {

            case "b":
            case "bu":
            case "buy":
                return;

            case "s":
            case "se":
            case "sel":
            case "sell":
                return;


            case "p":
            case "pl":
            case "pla":
            case "play":
                return;


            case "m":
            case "me":
            case "men":
            case "menu":
                //ui.menu();
                ui.Commands(p);
                return;

            case "l":
            case "le":
            case "lea":
            case "leav":
            case "leave":
                over = true;
                return;

            default:
                Console.WriteLine();
                Console.WriteLine("Please enter a valid command ");
                return;
        }



    }
}