public class Meetings
{
    public string? Title {get; set;}
    public string? Time {get; set;}

    public List<string> people {get; set;}
    public Meetings (string title, string time)
    {
        Title = title;
        Time = time;
    }
}