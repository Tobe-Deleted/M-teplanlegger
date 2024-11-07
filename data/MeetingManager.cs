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

        public List<Meetings> LoadMeeting()
        { 
            return JsonSerializer.Deserialize<List<Meetings>>(File.ReadAllText(filepath)) 
                    ?? new List<Meetings>();
        }
    }
}