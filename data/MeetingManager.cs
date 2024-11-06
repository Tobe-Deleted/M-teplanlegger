using System.Net.Mail;
using System.Xml;
using System.Text.Json;

namespace MeetingManager.Data
{
    public class SaveLoadMeeting
    {
        private readonly string filepath = "data/meetings.json";

        /*public List<Meetings> LoadMeeting()
        {
            if (!File.Exists(filepath))
                return new List<Meetings>();

            string json = File.ReadAllText(filepath);
            return 
        }*/

        public void SaveMeeting(List<Meetings> meetings)
        {
            string json = JsonSerializer.Serialize(meetings);
            File.WriteAllText(filepath, json);
        }
    }
}