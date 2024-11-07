//using System.Text.Json;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using MeetingManager.Data;

public class EditMeeting
{
    public void CreateMeeting()
    {
        Console.Clear();
        Console.WriteLine("Lag nytt møte valgt");

        Console.Write("Velg tittel: ");
        string? title = Console.ReadLine();
        Console.Clear();

        Console.Write("Velg tidspunkt: ");
        string? time = Console.ReadLine(); // TODO: string to TimeDate? Look into TimeDate
        Console.Clear();

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
        Console.Clear();
        List<string> people = new List<string>{};
        for(int i = 0; i < meetingParticipants; i++) 
        {
            Console.Write("Add a person to the meeting: ");
            
            people.Add(Console.ReadLine() ?? "No name given");

        }
        Console.Write("Møtet er klart. Trykk en knapp for å få oversikt over møtet");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine($"Møte: {title}");
        Console.WriteLine($"Tidspunkt: {time}");
        Console.Write("Møtedeltagere: ");
        string participants = "";
        foreach (string str in people)
        {
            participants += $", {str}";
        }
        Console.WriteLine(participants.Remove(0,2));
        Console.WriteLine();

        Meetings mts = new Meetings()
        {
            Title = title,
            Time = time,
            People = people
        };

        SaveLoadMeeting SLM = new SaveLoadMeeting();
        var meeting = SLM.LoadMeeting();
        meeting.Add(mts);
        SLM.SaveMeeting(meeting);

        Console.WriteLine("Møtet er lagret. Trykk en knapp for å fortsette");
        Console.ReadKey();
    }
    
    public void ViewMeetings()
    {
        Console.Clear();
        SaveLoadMeeting SLM = new SaveLoadMeeting();
        var meetings = SLM.LoadMeeting();
        int counter = 0;
        string participants = "";
        Console.WriteLine("Alle eskisterende møter:");
        foreach (var meeting in meetings)
        {
            counter++;
            Console.WriteLine($"{counter}: {meeting.Title}");
        }
        
        Console.Write("Velg et møte(nr) å se nærmere på:");
        string viewChoice = Console.ReadLine() ?? "Invalid input";//TODO: parse input
        Console.Clear();
        if(Convert.ToInt16(viewChoice) <= meetings.Count())
        {
            Console.WriteLine($"Tittel: {meetings[Convert.ToInt16(viewChoice) -1].Title}");
            Console.WriteLine($"Tidspunkt: {meetings[Convert.ToInt16(viewChoice) -1].Time}");
            foreach(string person in meetings[Convert.ToInt16(viewChoice) -1].People)
            //TODO: fiks. Blir ikke printet. Blir lagret.
            {
                participants += $", {person}";
            }
            Console.WriteLine($"Møtedeltagere: {participants.Remove(0,2)}");
            Console.WriteLine();
            Console.WriteLine("Trykk en knapp for å gå tilbake til meny");
            Console.ReadKey();
        }
    }

    public void ChangeMeeting()
    {
        //TODO: set up Meeting edit
    }

    public void DeleteMeeting()
    {
        //TODO: set up delete
    }
        //TODO save meeting to json
}