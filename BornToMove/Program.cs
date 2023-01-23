using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace BornToMove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welkom! Het is tijd om te bewegen!\n");
            Console.WriteLine("Toets [1] voor bewegingssugestie.");
            Console.WriteLine("Toets [2] om beweging te kiezen/toe te voegen.");
            Console.WriteLine("Toets [x] om beweging uit te stellen.");
            Console.Write("\rToets: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Random rnd = new Random();
                    int count = new MoveBLL().GetMoveCount();
                    int id = rnd.Next(1, count);

                    Move RndMove = new MoveBLL().GetMoveById(id);
                    Console.WriteLine("\n" + RndMove.Name + " | Sweat Rate: " + RndMove.SweatRate + "\n" + RndMove.Description);
                    GetReview();

                    return false;
                case "2":
                    bool showSubMenu = true;
                    while (showSubMenu)
                    {
                        showSubMenu = SubMenu2();
                    }
                    return false;
                case "x":
                    Console.WriteLine("Tot ziens.");
                    return false;
                default:
                    Console.WriteLine("Geen gelde keuze. Probeer opnieuw...");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    return true;
            }
        }

        private static bool SubMenu2()
        {
            Console.Clear();
            Console.WriteLine("Toets [ ] voor gewenste beweging: ");

            List<Move> movesList = new MoveBLL().GetAllMoves();
            movesList.ForEach(move =>
            {
                Console.WriteLine("Toets [" + move.Id + "] " + move.Name + " | sweat rate: " + move.SweatRate);
            });
            Console.WriteLine("\nToets [0] om beweging toe te voegen.");
            Console.Write("\rToets: ");

            int maxChoice = new MoveBLL().GetMoveCount();
            bool isInt = int.TryParse(Console.ReadLine(), out int choice);

            if (isInt)
            {
                if (choice <= maxChoice)
                {
                    if (choice == 0)
                    {
                        Move newMove = new Move();
                        Console.Clear();
                        Console.WriteLine("Beweging toevoegen:");
                        Console.Write("Naam: ");
                        newMove.Name = Console.ReadLine();

                        Move CheckMove = new MoveBLL().GetMoveByName(newMove.Name);
                        if (CheckMove != null)
                        {
                            Console.WriteLine("Deze beweging bestaat al! Kies deze uit de lijst...");
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                            return true;
                        }

                        Console.Write("Beschrijving: ");
                        newMove.Description = Console.ReadLine();
                        Console.Write("Sweat Rate: ");
                        newMove.SweatRate = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Beweging correct ingevuld? [y]");
                        if (Console.ReadLine() == "y")
                        {
                            new MoveBLL().SetMove(newMove);
                        }
                        return true;
                    }
                    else
                    {
                        Move ChoiceMove = new MoveBLL().GetMoveById(choice);
                        Console.WriteLine(ChoiceMove.Name + " | Sweat Rate: " + ChoiceMove.SweatRate + "\n" + ChoiceMove.Description);
                        GetReview();
                    }
                }

            }
            else
            {
                Console.WriteLine("Geen geldige keuze. Probeer opnieuw...");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                return true;
            }
            return false;
        }

        private static void GetReview()
        {
            Console.WriteLine("\nDruk op een willekeurige toets wanneer beweging voltooid is...");
            Console.ReadKey(true);
            Console.Write("Beoordeling [1-5]: ");
            Console.ReadLine();
            Console.Write("Intensiteit [1-5]: ");
            Console.ReadLine();
            Console.WriteLine("Goed bezig! Fijne dag verder.");
        }
    }
}