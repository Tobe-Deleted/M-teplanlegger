interface ISaveLoadMeeting
{
    /// <summary>
    /// Saves the input to meetings.json
    /// </summary>
    /// <param name="meetings"></param>
    public void SaveMeeting(List<Meetings> meetings);

    /// <summary>
    /// Converts meetings.json to a List
    /// </summary>
    /// <returns>List<Meetings> with content from meetings.json</retuns>
    public List<Meetings> LoadMeeting();
}