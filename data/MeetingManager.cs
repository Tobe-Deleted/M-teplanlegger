using System.Net.Mail;
using System.Xml;
using System.Text.Json;

namespace MeetingManager.Data
{
    public class SaveLoadMeeting
    {
        private readonly string filepath = "data/meetings.json";

        public void SaveMeeting(List<Meetings> meetings)
        {
            string json = JsonSerializer.Serialize(meetings);
            File.WriteAllText(filepath, json);
        }

        public List<Meetings> LoadMeeting()//TODO: endre vekk fra list? 
        {
            if (!File.Exists(filepath))
            {
                return new List<Meetings>();
            }
            string meetingsJson = File.ReadAllText(filepath);
            Meetings? test = JsonSerializer.Deserialize<Meetings>(meetingsJson);
            Console.WriteLine(test.Title);
            return new List<Meetings>();
        }
    }
}