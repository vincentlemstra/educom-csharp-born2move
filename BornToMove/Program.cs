using BornToMove.BLL;
using static System.Console;

namespace BornToMove
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // todo verplaats checks naar business logic
            // -> validate() maken
                // Console.Readline() gaat door deze validate
                    // if empty
                    // if int / if string
                    // if < x / if > x

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Clear();
            WriteLine("Welkom! Het is tijd om te bewegen!\n");
            WriteLine("Toets [1] voor bewegingssugestie.");
            WriteLine("Toets [2] om beweging te kiezen/toe te voegen.");
            WriteLine("Toets [x] om beweging uit te stellen.");
            Write("\rToets: ");

            switch (ReadLine())
            {
                case "1":
                    Clear();
                    var move = new MoveBL().GetRndMove();
                    WriteLine($"{move.Move.Name} " +
                        $"| Sweat Rate: {move.Move.SweatRate} " +
                        $"| Beoordeling: {move.Rating:n1} " +
                        $"| Intensiteit: {move.Intensity:n1} " +
                        $"\n{move.Move.Description}");
                    GetReview(move.Move.MoveId);
                    return false;

                case "2":
                    bool showSubMenu = true;
                    while (showSubMenu)
                    {
                        showSubMenu = SubMenu();
                    }
                    return false;

                case "x":
                    WriteLine("Tot ziens.");
                    return false;

                default:
                    WriteLine("Geen gelde keuze. Probeer opnieuw...");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    return true;
            }
        }

        private static bool SubMenu()
        {
            // start new menu
            Clear();
            WriteLine("Toets [ ] voor gewenste beweging: ");

            // show all moves
            var moves = new MoveBL().GetAllMoves();
            moves.ForEach(move =>
            {
                WriteLine("Toets [" + move.MoveId + "] " + move.Name + " | sweat rate: " + move.SweatRate);
            });
            WriteLine("\nToets [0] om beweging toe te voegen.");
            Write("\rToets: ");

            // get valid choice
            int maxChoice = new MoveBL().GetMoveCount();
            bool isInt = int.TryParse(ReadLine(), out int choice);
            if (isInt)
            {
                if (choice <= maxChoice)
                {
                    if (choice == 0)
                    {
                        // start new menu
                        Clear();
                        WriteLine("Beweging toevoegen:");
                        Write("Naam: ");
                        string name = ReadLine();

                        // check if name is unique
                        var CheckMove = new MoveBL().GetMoveByName(name);
                        if (CheckMove != null)
                        {
                            WriteLine("Deze beweging bestaat al! Kies deze uit de lijst...");
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                            return true;
                        }

                        // add description and sweatRate
                        Write("Beschrijving: ");
                        string description = ReadLine();
                        Write("Sweat Rate: ");
                        int sweatRate = Convert.ToInt32(ReadLine());

                        // make sure input is correct
                        WriteLine("Beweging correct ingevuld? [y/n]");
                        if (ReadLine() == "y")
                        {
                            new MoveBL().AddMove(name, description, sweatRate);
                        }
                        return true;
                    }
                    else
                    {
                        // show chosen move
                        Clear();
                        var move = new MoveBL().GetMoveById(choice);
                        WriteLine($"{move.Move.Name} " +
                            $"| Sweat Rate: {move.Move.SweatRate} " +
                            $"| Beoordeling: {move.Rating:n1} " +
                            $"| Intensiteit: {move.Intensity:n1} " +
                            $"\n{move.Move.Description}");
                        GetReview(choice);
                    }
                }
                else
                {
                    WriteLine("Geen geldige keuze. Probeer opnieuw...");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    return true;
                }
            }
            else
            {
                WriteLine("Geen geldige keuze. Probeer opnieuw...");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                return true;
            }
            return false;
        }

        private static void GetReview(int moveId)
        {
            // wait untill move is done
            WriteLine("\nDruk op een willekeurige toets wanneer beweging voltooid is...");
            ReadKey(true);

            // add review to db
            Write("Beoordeling [1-5]: ");
            int rating = Convert.ToInt32(ReadLine());
            Write("Intensiteit [1-5]: ");
            int intensity = Convert.ToInt32(ReadLine());
            new MoveBL().AddReview(moveId, rating, intensity);

            WriteLine("Goed bezig! Fijne dag verder.");
        }
    }
}