using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Globalization;
using MeetingManager.Data;

public class EditMeeting
{
    public void CreateMeeting()
    {
        TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
        Console.Clear();
        SaveLoadMeeting SLM = new SaveLoadMeeting();//se data
        var meeting = SLM.LoadMeeting();

        if (meeting.Count() > 8)
        {
            Console.WriteLine("For mange møter lagret.");
        }
        else
        {
        Console.WriteLine("Lag nytt møte:");

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
            Console.Write("Legg til en person til møtet: ");
            
            people.Add(myTI.ToTitleCase(Console.ReadLine() ?? "Ikke navngitt"));

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

        Meetings mts = new Meetings()//se models
        {
            Title = title,
            Time = time,
            People = people
        };

        meeting.Add(mts);
        SLM.SaveMeeting(meeting);

        Console.WriteLine("Møtet er lagret. Trykk en knapp for å fortsette");
        }
        Console.ReadKey();
    }
    
    public void ViewMeetings()
    {
        bool exit = false;
        while(!exit)
        {
            Console.Clear();
            SaveLoadMeeting SLM = new SaveLoadMeeting();//se data
            var meetings = SLM.LoadMeeting();
            int counter = 0;
            string participants = "";
            Console.WriteLine("Møteoversikt:");
            foreach (var meeting in meetings)
            {
                counter++;
                Console.WriteLine($"{counter}: {meeting.Title}");
            }
            Console.Write("Velg et møte eller 0 for å gå tilbake: ");

            ConsoleKey viewChoice = Console.ReadKey().Key;
            if (viewChoice == ConsoleKey.D0)break;
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            if(Convert.ToInt16(viewChoice) -48 <= meetings.Count() && Convert.ToInt16(viewChoice) -48 > 0)
            {
                Console.WriteLine($"Tittel: {meetings[Convert.ToInt16(viewChoice) -49].Title}");
                Console.WriteLine($"Tidspunkt: {meetings[Convert.ToInt16(viewChoice) -49].Time}");
                foreach(string person in meetings[Convert.ToInt16(viewChoice) -49].People)
                {
                    participants += $", {person}";
                }
                Console.WriteLine($"Møtedeltagere: {participants.Remove(0,2)}");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Velg handling:");
                Console.WriteLine("1. Gå tilbake");
                Console.WriteLine("2. Endre møte");
                Console.WriteLine("3. Slett møte");
                Console.Write("0. Gå tilbake til hovedmeny");
                ConsoleKey response = 0;
                while (Convert.ToInt16(response) < 48 || Convert.ToInt16(response) > 51)// increase if more options are added 48 = 0 & 51 = 3
                {
                    response = Console.ReadKey(false).Key;
                    switch(response)
                    {
                        case ConsoleKey.D1:
                            break;
                        case ConsoleKey.D2:
                            ChangeMeeting(Convert.ToInt16(viewChoice)-49);
                            break;
                        case ConsoleKey.D3:
                            DeleteMeeting(Convert.ToInt16(viewChoice)-49);
                            break;
                        case ConsoleKey.D0:
                            exit = true;
                            break;
                    }
                }

            }
            else Console.WriteLine("ugyldig valg");
        }
    }

    public void ChangeMeeting(int indexValue)
    {
        TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
        SaveLoadMeeting SLM = new SaveLoadMeeting();
        var meetings = SLM.LoadMeeting();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"Endrer på {meetings[indexValue].Title}");
            Console.WriteLine("Hvilke endring vil du utføre?");
            Console.WriteLine("1. Endre tittel");
            Console.WriteLine("2. Endre tidspunkt");
            Console.WriteLine("3. Endre deltakere");
            Console.WriteLine("0. Gå tilbake");
            ConsoleKey editChoice = Console.ReadKey().Key;
            switch (editChoice)
            {
                case ConsoleKey.D0:
                    Console.Clear();
                    exit = true;
                    break;
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine($"Tittel: {meetings[indexValue].Title}");
                    Console.Write("Skriv inn ny tittel: ");
                    string title = Console.ReadLine() ?? "Ingen tittel";
                    meetings[indexValue].Title = title;
                    Console.WriteLine("Tittel endret");
                    SLM.SaveMeeting(meetings);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine($"Tidspunkt: {meetings[indexValue].Time}");
                    Console.Write("Sett nytt tidspunkt: ");
                    string time = Console.ReadLine() ?? "Tidspunkt ikke satt";
                    meetings[indexValue].Time = time;
                    Console.WriteLine("Tidspunkt endret");
                    SLM.SaveMeeting(meetings);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    string participants;
                    bool exitPeople = false;
                    while (!exitPeople)
                    {
                        participants = "";
                        foreach(string person in meetings[indexValue].People)
                        {
                            participants += $", {person}";
                        }
                        Console.Clear();
                        Console.WriteLine($"Møtedeltagere: {participants.Remove(0,2)}");
                        Console.Write("For å legge til/slette, skriv inn navn på ny/eksisterende deltaker: ");
                        string editPerson = myTI.ToTitleCase(Console.ReadLine() ?? "");
                        if (editPerson == "") break;
                        if (meetings[indexValue].People.Contains(editPerson))
                        {
                            meetings[indexValue].People.Remove(editPerson);
                            Console.WriteLine($"{editPerson} er fjernet fra møtet. Ønsker du å gjøre flere endringer? y/n");
                        }

                        else 
                        {
                            meetings[indexValue].People.Add(editPerson);
                            Console.WriteLine($"{editPerson} er lagt til møtet. Ønsker du å gjøre flere endringer? y/n");
                        }
                        SLM.SaveMeeting(meetings);
                        ConsoleKey yn = Console.ReadKey().Key;
                        if (yn == ConsoleKey.N)
                            exitPeople = true;
                    }
                    break;
                default:
                break;
            }
        }
    }

    public void DeleteMeeting(int indexValue)
    {
        SaveLoadMeeting SLM = new SaveLoadMeeting();
        var meetings = SLM.LoadMeeting();
        meetings.Remove(meetings[indexValue]);
        SLM.SaveMeeting(meetings);
    }
}