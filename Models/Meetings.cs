public class Meetings
{
    public string? Title {get; set;}
    public string? Time {get; set;}

    public List<string> people {get; set;}//TODO figure out how to put list into Meetings
    public Meetings (string title, string time)//solve null issue(might solve itself)
    {
        Title = title;
        Time = time;
    }
}