interface IEditMeeting
{
    /// <summary>
    /// Takes the user through the create meeting process
    /// </summary>
    public void CreateMeeting();

    /// <summary>
    /// Takes the user to a menu with all meetings. The user selects a
    /// a meeting and is fed the information about that meeting.
    /// </summary>
    public void ViewMeetings();

    /// <summary>
    /// Gives the user an option to change meeting details like time, title or participants
    /// Meeting is chosen by indexValue
    /// </summary>
    /// <param name="indexValue"></param>
    public void ChangeMeeting(int indexValue);

    /// <summary>
    /// Allows the user to delete a meeting in its entirety. 
    /// Meeting is chosen by indexValue
    /// </summary>
    /// <param name="indexValue"></param>
    public void DeleteMeeting(int indexValue);
}