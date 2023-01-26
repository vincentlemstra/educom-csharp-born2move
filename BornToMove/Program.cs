using BornToMove.BLL;
using static System.Console;

namespace BornToMove
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // todo verplaats menu dingen naar business logic (?)
            // todo verplaats meer checks naar business logic

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
                    var move = new MoveBL().GetRndMove();
                    WriteLine($"{move.Name} | {move.SweatRate} \n{move.Description}");
                    GetReview();
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
            Clear();
            WriteLine("Toets [ ] voor gewenste beweging: ");

            var moves = new MoveBL().GetAllMoves();
            moves.ForEach(move =>
            {
                WriteLine("Toets [" + move.MoveId + "] " + move.Name + " | sweat rate: " + move.SweatRate);
            });
            WriteLine("\nToets [0] om beweging toe te voegen.");
            Write("\rToets: ");

            int maxChoice = new MoveBL().GetMoveCount();
            bool isInt = int.TryParse(ReadLine(), out int choice);

            if (isInt)
            {
                if (choice <= maxChoice)
                {
                    if (choice == 0)
                    {
                        Clear();
                        WriteLine("Beweging toevoegen:");
                        Write("Naam: ");
                        string name = ReadLine();

                        var CheckMove = new MoveBL().GetMoveByName(name);
                        if (CheckMove != null)
                        {
                            WriteLine("Deze beweging bestaat al! Kies deze uit de lijst...");
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                            return true;
                        }

                        Write("Beschrijving: ");
                        string description = ReadLine();
                        Write("Sweat Rate: ");
                        int sweatRate = Convert.ToInt32(ReadLine());

                        WriteLine("Beweging correct ingevuld? [y]");
                        if (ReadLine() == "y")
                        {
                            new MoveBL().AddMove(name, description, sweatRate);
                        }
                        return true;
                    }
                    else
                    {
                        var move = new MoveBL().GetMoveById(choice);
                        WriteLine($"{move.Name} | {move.SweatRate} \n{move.Description}");
                        GetReview();
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

        private static void GetReview()
        {
            WriteLine("\nDruk op een willekeurige toets wanneer beweging voltooid is...");
            ReadKey(true);
            Write("Beoordeling [1-5]: ");
            ReadLine();
            Write("Intensiteit [1-5]: ");
            ReadLine();
            WriteLine("Goed bezig! Fijne dag verder.");
        }
    }
}