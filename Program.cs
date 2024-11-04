namespace Møteplanlegger;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Møteplanlegger v0.1");

        EditMeeting emt = new EditMeeting();
        Console.WriteLine("Velg handling: ");
        Console.WriteLine("1. lag nytt møte");
        //Console.WriteLine("2. Display all meetings");
        string menuChoice = Console.ReadLine() ?? "0";
        if (menuChoice == "1" || menuChoice.ToLower() == "nytt møte")
            emt.CreateMeeting();
        
    }
}
