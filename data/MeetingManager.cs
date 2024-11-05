using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Xml;
using System.Text.Json;
using Newtonsoft.json; // TODO: Find alternative to newtonsoft.json

namespace MeetingManager.Data
{
    public class SaveLoadMeeting
    {
        private readonly string filepath = "data/meetings.json";

        public List<Meetings> LoadMeeting()
        {
            if (!File.Exists(filepath))
                return new List<Meetings>();

            string json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<Meetings>>(json) ?? new List<Meetings>();
        }

        public void SaveMeeting(List<Meetings> meetings)
        {
            string json = JsonConvert.SerializeObject(meetings, Formatting.Intended);
            File.WriteAllText(filepath, json);
        }
    }
}