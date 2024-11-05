using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Xml;
using System.Text.Json;

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
            return JsonConvert.DeserializeObject<List<Meetings>>(json) ?? new List<Meetings>();//funker ikke uten NuGet
        }

        public void SaveMeeting(List<Meetings> meetings)
        {
            string json = jsonSerializer.Serialize(meetings);//funker ikke uten NuGet
            File.WriteAllText(filepath, json);
        }
    }
}