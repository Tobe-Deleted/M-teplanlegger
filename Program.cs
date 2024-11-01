namespace Møteplanlegger;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Møteplanlegger v0.1");

       Meeting mt = new Meeting();

       mt.CreateMeeting();
    }
}
