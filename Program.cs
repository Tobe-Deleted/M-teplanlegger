using System.Text.Json.Serialization;

namespace Møteplanlegger;

class Program
{
    static void Main(string[] args)
    {
        EditMeeting emt = new EditMeeting(); //se classes
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Møteplanlegger v0.3");
            Console.WriteLine("Velg handling: ");
            Console.WriteLine("1. Nytt møte");
            Console.WriteLine("2. Møteoversikt");
            Console.WriteLine("0. Avslutt");

            ConsoleKey menuChoice = Console.ReadKey().Key;
            switch(menuChoice)
            {
                case ConsoleKey.D0:
                    Console.Clear();
                    exit = true;
                    break;
                case ConsoleKey.D1:
                    emt.CreateMeeting();
                    break;
                case ConsoleKey.D2:
                    emt.ViewMeetings();
                    break;
                default:
                    Console.ReadKey();
                    break;
            }
        }
    }
}
