//using System.Text.Json;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

public class EditMeeting
{
    public void CreateMeeting()
    {
        Console.WriteLine("Lag ny valgt");

        Console.Write("Velg tittel: ");
        string? title = Console.ReadLine();
        Console.WriteLine(title); // TODO remove when æøå is fixed. Check out encoding settings
        Console.WriteLine($"Møte tittel: {title}");

        Console.Write("Velg tidspunkt: ");
        string? time = Console.ReadLine(); // TODO ?string to TimeDate? Look into TimeDate
        Console.WriteLine($"Møte tidspunkt: {time}");
        int meetingParticipants = 0;
        while (meetingParticipants <= 0)
        {
            Console.Write("Velg antall deltagere: ");
            try
            {
                meetingParticipants = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Antall deltagere må oppgis som et tall. Prøv igjen.");
            }
        }

        List<string> people = new List<string>{};
        for(int i = 0; i < meetingParticipants; i++) 
        {
            Console.Write("Add a person to the meeting: ");
            
            people.Add(Console.ReadLine() ?? "unnamed");

        }
        Console.Write("Møtet er klart. Trykk enter for å fortsette.");
        Console.ReadLine();
        Console.WriteLine($"Møte: {title}");
        Console.WriteLine($"Tidspunkt: {time}");
        Console.Write("Møtedeltagere: ");
        string participants = "";
        foreach (string str in people)
        {
            participants += $", {str}";
        }
        Console.WriteLine(participants.Remove(0,2));
        //TODO save meeting to json

    }
}