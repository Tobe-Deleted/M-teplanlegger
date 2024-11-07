using System.Text.Json.Serialization;

namespace Møteplanlegger;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Møteplanlegger v0.2");
        EditMeeting emt = new EditMeeting();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Velg handling: ");
            Console.WriteLine("1. Lag nytt møte");
            Console.WriteLine("2. Se eksisterende møter");
            Console.WriteLine("0. For å avslutte");

            string menuChoice = Console.ReadLine() ?? "0";
            switch(menuChoice)
            {
                case "0":
                    Console.Clear();
                    exit = true;
                    break;
                case "1":
                    emt.CreateMeeting();
                    break;
                case "2":
                    emt.ViewMeetings();
                    break;
                default:
                    Console.WriteLine($"Invalid menu choice press any key to try again./n");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
